using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;
using System.Threading;

namespace AIOCommon
{
	[Serializable]
	public class AIONode 
	{
		//public FileSystemInfo info; //Chua thong tin ve folder, tree
		//public bool isFile; //La file hay la folder	
		public AIOInfo data;

		public AIONode prevNode;
		public bool prevIsParent;
		public AIONode nextNode;
		public AIONode childNode;

		public object container;
	
		public AIONode() : this(new AIOInfo()) {}
		public AIONode(AIOInfo data) 
		{
			//this.info = info;
			//this.isFile = isFile;
			this.data = data;

			prevNode = null;
			childNode = null;
			nextNode = null;
			prevIsParent = false;
		}

		public void Clone(AIONode src, string newID) 
		{
		//	if (this.data == null)
		//		this.data = new AIOInfo(newID, true);

			this.data.Clone(src.data);			
			this.data.ID = newID;
		}
	}
	/// <summary>
	/// Summary description for AIODataStructure.
	/// </summary>
	[Serializable]
	public class AIOFolderTree
	{
		public enum AIOModule {MODULE_BOOK, MODULE_MUSIC, MODULE_MOVIE, MODULE_CDDVD, MODULE_PHOTO};
		public string [] modulePrefix = {"B", "M", "F", "C", "P"};
		public string directoryPrefix = "#";
		//module
		private AIOModule module;
		public AIOModule Module 
		{
			get {return module;}
			set {module = value;}
		}
		//ID
		//Save deleted ID to reuse
		private Queue queueFileID = new Queue();
		private Queue queueFolderID = new Queue();

		//root
		private AIONode root;
		//size
		private int size = 0;
		private int foldersCount = 0;
		private int filesCount = 0;
		private int totalCount = 0;

		private bool isProcessing = false;

		public int Size
		{
			get
			{
				return size;
			}
		}

		public int FoldersCount 
		{
			get
			{
				return foldersCount;
			}
			set 
			{
				foldersCount = value;
			}
		}

		public int FilesCount 
		{
			get
			{
				return filesCount;
			}
			set 
			{
				filesCount = value;
			}
		}

		public bool IsProcessing 
		{
			get 
			{
				return isProcessing;
			}			
		}

		public AIOFolderTree()
		{
		}

		public string GenerateFileID() 
		{
			if (queueFileID.Count > 0)
				return queueFileID.Dequeue().ToString();

			string id = "";			
			id = filesCount.ToString();
			int len = id.Length;
			for(int i = 0;i<6-len;i++)
				id = "0" + id;
			id = modulePrefix[(int)module] + id;
			return id;
		}

		public string GenerateFolderID() 
		{
			if (queueFolderID.Count > 0)
				return queueFolderID.Dequeue().ToString();

			string id = "";
			id = foldersCount.ToString();
			int len = id.Length;
			for(int i = 0;i<5-len;i++)
				id = "0" + id;
			id = directoryPrefix + modulePrefix[(int)module] + id;
			return id;
		}

		public void Synchronize(string path, string pattern, bool bRecursive) 
		{
			//Process
			isProcessing = true;

			DirectoryInfo di = new DirectoryInfo(path);			
			if (di.Exists) 
			{
				totalCount = 1;
				foldersCount = 1;
				filesCount = 0;
				//root = new AIONode(di, false);
				root = new AIONode(new AIOInfo(GenerateFolderID(), di.Name, false));
				
				Synchronize_R(di, root, pattern, bRecursive);				
			}			

			//End process
			isProcessing = false;
		}
		public void Synchronize_R(DirectoryInfo di, AIONode subRoot, string pattern, bool bRecursive) 
		{
			//DirectoryInfo di = (DirectoryInfo)subRoot.info;
			DirectoryInfo [] subDi = di.GetDirectories();
			AIONode curChild = null;
			AIONode preChild = null;
			if (subDi.Length > 0) //Co thu muc con
			{				
				totalCount += subDi.Length;
				AIOProgress.progressValue = foldersCount / 100;
				Thread.Sleep(1);

				if (bRecursive) 
				{
					//First Child
					foldersCount++;

					AIONode firstChild = new AIONode(new AIOInfo(GenerateFolderID(), subDi[0].Name, false));
					subRoot.childNode = firstChild;
					//Child
					curChild = firstChild;
					for (int i = 0;i<subDi.Length;i++)
					{
						//Recursive
						Synchronize_R(subDi[i], curChild, pattern, bRecursive);

						//Gan parent pointer
						if (preChild != null) 
						{
							curChild.prevNode = preChild;
							curChild.prevIsParent = false;
						}
						else 
						{
							curChild.prevNode = subRoot;
							curChild.prevIsParent = true;
						}
						//Save preChild
						preChild = curChild;
						//Move next
						if (i < subDi.Length - 1) //Chi xet toi node ke cuoi
						{
							foldersCount++;

							curChild.nextNode = new AIONode(new AIOInfo(GenerateFolderID(), subDi[i+1].Name, false));																				
							curChild = curChild.nextNode;
						}
						
					}
					//Sau vong lap nay, curChild se tro toi node thu muc cuoi cung
					//Neu doi curChild (2 dong cuoi) ra ngoai, curChild se tro ve null
					//preChild se chi luon toi node cuoi sau khi het vong lap
				}
			} 
			
			//Duyet het file va tra ve
			FileInfo [] fileInfo = di.GetFiles(pattern);
			if (fileInfo.Length > 0) 
			{
				totalCount += fileInfo.Length;
				//FirstNode
				filesCount++;
				AIONode firstChild = new AIONode(new AIOInfo(GenerateFileID(), fileInfo[0].Name, true));
				if (curChild == null) //Khong co thu muc con, chi co file
				{
					subRoot.childNode = firstChild;					
				} 
				else //Co thu muc con
				{
					curChild.nextNode = firstChild;					
				}
				curChild = firstChild;

				//PreChild
				if (preChild == null) 
				{
					preChild = subRoot;
				} //Nguoc lai thi de nguyen				

				AIONode next = null;
				//Check xem file na`o thoa, bat dau tu firstChild
				for (int i = 0;i<fileInfo.Length;i++)
				{						
					if (i < fileInfo.Length - 1) 
					{
						filesCount++;
						next = new AIONode(new AIOInfo(GenerateFileID(), fileInfo[i+1].Name, true));
					}
					else
						next = null;
					curChild.nextNode = next;

					//Prev
					curChild.prevNode = preChild;
					if (preChild.Equals(subRoot))
						curChild.prevIsParent = true;
					else
						curChild.prevIsParent = false;

					//Next
					preChild = curChild;
					curChild = curChild.nextNode;
				}
			}			
				
		}

		//Flatten-synchronization
		public void FlatSynchronize(string path, string pattern, bool bRecursive) 
		{
			//Process
			isProcessing = true;

			DirectoryInfo di = new DirectoryInfo(path);			
			if (di.Exists) 
			{
				totalCount = 1;
				foldersCount = 1;
				filesCount = 0;
				//root = new AIONode(di, false);
				root = new AIONode(new AIOInfo(GenerateFolderID(), di.Name, false));
				
				AIONode previousNode = new AIONode();

				FlatSynchronize_R(di, ref previousNode , pattern, bRecursive);				
			}			

			//End process
			isProcessing = false;
		}

		//AIONode previousNode = null;
		public void FlatSynchronize_R(DirectoryInfo di, ref AIONode previousNode, string pattern, bool bRecursive) 
		{
			//DirectoryInfo di = (DirectoryInfo)subRoot.info;
			DirectoryInfo [] subDi = di.GetDirectories();						
			if (subDi.Length > 0) //Co thu muc con
			{
				if (bRecursive) 
				{
					for (int i = 0;i<subDi.Length;i++)
					{
						//Recursive
						FlatSynchronize_R(subDi[i], ref previousNode, pattern, bRecursive);						
					}
					//Sau vong lap nay, curChild se tro toi node thu muc cuoi cung
					//Neu doi curChild (2 dong cuoi) ra ngoai, curChild se tro ve null
					//preChild se chi luon toi node cuoi sau khi het vong lap
				}
			} 
			
			//Duyet het file va tra ve
			FileInfo [] fileInfo = di.GetFiles(pattern);
			if (fileInfo.Length > 0) 
			{
				totalCount += fileInfo.Length;
				AIOProgress.progressValue = filesCount / 100;
				Thread.Sleep(1);
				//FirstNode
				filesCount++;
				AIONode firstChild = new AIONode(new AIOInfo(GenerateFileID(), fileInfo[0].Name, true));
				if (root.childNode == null) //Khong co thu muc con, chi co file
				{
					root.childNode = firstChild;
					firstChild.prevNode = root;
					firstChild.prevIsParent = true;
				} 
				else //Co thu muc con
				{
					previousNode.nextNode = firstChild;
					firstChild.prevNode = previousNode;
					firstChild.prevIsParent = false;
				}

				previousNode = firstChild;
				
				//Check xem file na`o thoa, bat dau tu firstChild
				AIONode curChild = null;
				for (int i = 1;i<fileInfo.Length;i++)
				{				
					filesCount++;
					curChild = new AIONode(new AIOInfo(GenerateFileID(), fileInfo[i].Name, true));
					
					previousNode.nextNode = curChild;
					curChild.prevNode = previousNode;
					curChild.prevIsParent = false;

					//Update previousNode;
					previousNode = curChild;
				}
			}			
				
		}

		//----------------------------------------------------
		//Print tree
		public ArrayList PrintTree() 
		{
			ArrayList list = new ArrayList();			
			PrintTree_R(root, list);
			return list;
		}

		public void PrintTree_R(AIONode subRoot, ArrayList list) 
		{
			//list.Add(subRoot.info.FullName);
			list.Add(subRoot.data.Name);
			if (subRoot.childNode != null) 
			{
				PrintTree_R(subRoot.childNode, list);
			}
			if (subRoot.nextNode != null) 
			{
				PrintTree_R(subRoot.nextNode, list);
			}
		}

		//CreateTreeNode
		public void CopyNodeInfo(TreeNode treenode, AIONode aionode) {
			//if (aionode.data != null)
				treenode.Text = aionode.data.Name;
				//treenode.Text = aionode.data.ID;
			//else treenode.Text = "*_*";
			treenode.Tag = aionode;			
		}
		//Fill tree into TreeView
		public void FillTree(TreeView treeview) 
		{
			if (root != null && root.data.isFile == false) 
			{			
				TreeNode rootNode = new TreeNode();
				treeview.Nodes.Add(rootNode);
				FillTree_R(rootNode, root);								
			}
		}

		public void FillTree_R(TreeNode node, AIONode subroot) 
		{
			if (subroot == null) return;
			CopyNodeInfo(node, subroot);

			if (subroot.childNode != null && subroot.childNode.data.isFile == false)
			{
				TreeNode child = new TreeNode();
				node.Nodes.Add(child);				
				FillTree_R(child, subroot.childNode);												
			}

			if (subroot.nextNode != null && subroot.nextNode.data.isFile == false) 
			{
				TreeNode next = new TreeNode();
				node.Parent.Nodes.Add(next);
				FillTree_R(next, subroot.nextNode);							
			}					
		}
		
		//Fill treenode with its child
		public void FillOneLevelNode(TreeNode treenode, AIONode subroot) {			
			treenode.Nodes.Clear();

			if (subroot != null) {				
				//Get first level child
				TreeNode childNode = null;
				AIONode child = subroot.childNode;
				while (child != null) {
					if (child.data.isFile == false) 
					{
						childNode = new TreeNode();
						treenode.Nodes.Add(childNode);
						CopyNodeInfo(childNode, child);
						//Save container
						child.container = childNode;

						//Add blank node for childNode (to show + if has child)
						if (child.childNode != null)
							childNode.Nodes.Add(new TreeNode());						
					}
					child = child.nextNode;
				}			
			}
		}
		
		public void FillOneLevelTree(TreeView treeview) {
			treeview.Nodes.Clear();
			if (root != null) 
			{				
				TreeNode rootNode = new TreeNode();
				CopyNodeInfo(rootNode, root);
				FillOneLevelNode(rootNode, root);
				//Save container
				root.container = rootNode;

				treeview.Nodes.Add(rootNode);
			}
		}

		public void MoveNode(AIONode nodeToMove, AIONode nodeToAttach) {
			if (nodeToAttach != null && nodeToAttach.data.isFile == false) {
				AIONode previousNode = nodeToMove.prevNode;
				bool previousIsParent = nodeToMove.prevIsParent;
				//Cut old node
				if (previousIsParent) {
					previousNode.childNode = nodeToMove.nextNode;
				} else {
					previousNode.nextNode = nodeToMove.nextNode;
				}
				if (nodeToMove.nextNode != null) {
					nodeToMove.nextNode.prevNode = nodeToMove.prevNode;
					nodeToMove.nextNode.prevIsParent = nodeToMove.prevIsParent;
				}
				
				//Attach into new parent
				if (nodeToAttach.childNode != null) 
				{
					nodeToAttach.childNode.prevNode = nodeToMove;
					nodeToAttach.childNode.prevIsParent = false;
				}

				nodeToMove.nextNode = nodeToAttach.childNode;
				nodeToMove.prevNode = nodeToAttach;
				nodeToMove.prevIsParent = true;
				nodeToAttach.childNode = nodeToMove;
			}
		}

		//Return new AIONode
		public AIONode CopyNode(AIONode nodeToCopy, AIONode nodeToAttach) 
		{
			if (nodeToAttach != null && nodeToAttach.data.isFile == false) //Attach to folder
			{ 
				//AIONode newNode = new AIONode(nodeToCopy.info, nodeToCopy.isFile);
				//newNode.childNode = nodeToCopy.childNode;
				AIONode newNode = new AIONode();
				if (nodeToCopy.data.isFile) 
				{
					filesCount++;
					newNode.Clone(nodeToCopy, GenerateFileID());
				}
				else 
				{
					foldersCount++;
					newNode.Clone(nodeToCopy, GenerateFolderID());
				}

				AIONode newChild = new AIONode();

				CopyNode_R(newChild, nodeToCopy.childNode);

				newNode.childNode = newChild;
				if (newChild != null) 
				{
					newChild.prevNode = newNode;
					newChild.prevIsParent = true;
				}

				//Thay doi parent flag
				if (nodeToAttach.childNode != null) 
				{
					nodeToAttach.childNode.prevNode = newNode;
					nodeToAttach.childNode.prevIsParent = false;
				}

				newNode.nextNode = nodeToAttach.childNode;
				newNode.prevNode = nodeToAttach;
				newNode.prevIsParent = true;
				nodeToAttach.childNode = newNode;

				return newNode;
			}
			return null;
		}

		private void CopyNode_R(AIONode dest, AIONode src) 
		{
			if (src == null) return;
			//Copy 			
			if (src.data.isFile) {
				filesCount++;
				dest.Clone(src, GenerateFileID());
			}
			else 
			{
				foldersCount++;
				dest.Clone(src, GenerateFolderID());
			}
			//Copy child
			if (src.childNode != null) 
			{
				AIONode child = new AIONode();
				CopyNode_R(child, src.childNode);
				dest.childNode = child;
				child.prevNode = dest;
				child.prevIsParent = true;
			}

			if (src.nextNode != null) 
			{
				AIONode next = new AIONode();
				CopyNode_R(next, src.nextNode);
				dest.nextNode = next;
				next.prevNode = dest;
				next.prevIsParent = false;
			}
		}

		private bool deleteNode = false;
		public void DeleteNode(AIONode nodeToDelete) 
		{
			deleteNode = true;
			int [] minus = Count(nodeToDelete);
			deleteNode = false;
			
			foldersCount -= minus[0];
			filesCount -= minus[1];

			AIONode previousNode = nodeToDelete.prevNode;			
            
			if (previousNode != null) //Not to delete the root
			{	
				bool previousIsParent = nodeToDelete.prevIsParent;
				if (previousIsParent) 
				{
					previousNode.childNode = nodeToDelete.nextNode;								
				}
				else 
				{
					previousNode.nextNode = nodeToDelete.nextNode;							
				}

				if (nodeToDelete.nextNode != null)
				{
					nodeToDelete.nextNode.prevIsParent = previousIsParent;
					nodeToDelete.nextNode.prevNode = previousNode;
				}			
			}			

			//Delete
			nodeToDelete = null;
		}

		public bool IsValidMoveCopy(AIONode nodeToMoveCopy, AIONode nodeToAttach) 
		{
			if (nodeToMoveCopy.Equals(nodeToAttach)) //Truong hop 2 node trung nhau
				return false;

			return IsValidMoveCopy_R(nodeToMoveCopy.childNode, nodeToAttach);
		}

		//De quy vao cac con de kiem tra destination co phai con cua source hay ko
		private bool IsValidMoveCopy_R(AIONode subroot, AIONode nodeToAttach) 
		{
			if (subroot == null) return true;
            if (subroot.Equals(nodeToAttach)) //Invalid
				return false;
			bool valid = IsValidMoveCopy_R(subroot.childNode, nodeToAttach);
			if (!valid) return false;
			valid = IsValidMoveCopy_R(subroot.nextNode, nodeToAttach);
			if (!valid) return false;
			return true;
		}

		public AIONode GetRoot() {
			return root;
		}

		public AIONode GetParent(AIONode node) 
		{
			AIONode current = node;			
			while (current.prevIsParent == false) 
			{
				current = current.prevNode;
			}
			return current.prevNode;
		}

		public void Insert(AIONode nodeToInsert, AIONode nodeToAttach) 
		{
			nodeToInsert.nextNode = nodeToAttach.childNode;

			if (nodeToAttach.childNode != null) 
			{
				nodeToAttach.childNode.prevNode = nodeToInsert;
				nodeToAttach.childNode.prevIsParent = false;
			}

			nodeToInsert.prevIsParent = true;
			nodeToInsert.prevNode = nodeToAttach;

			nodeToAttach.childNode = nodeToInsert;			
		}

		public int[] Count(AIONode subroot) 
		{
			int [] fCount = {0, 0};
			//f[0] //Folder
			//f[1] //File
			if (deleteNode) //Delete node thi can dem luon chinh no'
				if (subroot.data.isFile) 
				{
					fCount[1] = 1;
				}
				else 
				{
					fCount[0] = 1;
				}

			//Save ID if delete
			if (deleteNode) 
			{
				if (subroot.data.isFile)
					queueFileID.Enqueue(subroot.data.ID);
				else queueFolderID.Enqueue(subroot.data.ID);
			}

			Count_R(subroot, ref fCount[0], ref fCount[1]);					
			return fCount;
		}

		private void Count_R(AIONode subroot, ref int folderCount, ref int fileCount)
		{
			//Dem tat ca cac con cua subroot
			if (subroot == null) return;
			//Child
			AIONode current = subroot.childNode;

			while (current != null) 
			{
				if (current.data.isFile == false) //Folder
				{
					Count_R(current, ref folderCount , ref fileCount);
					folderCount++;
					//Save ID
					if (deleteNode) 
						queueFolderID.Enqueue(current.data.ID);
				}
				else 
				{
					fileCount++;
					if (deleteNode)
						queueFileID.Enqueue(current.data.ID);
				}
	
				current = current.nextNode;
			}			
		}

		private void Swap(AIONode node1, AIONode node2) 
		{
			AIONode prev1 = node1.prevNode;
			bool prev1IsParent = node1.prevIsParent;
			AIONode next1 = node1.nextNode;

			AIONode prev2 = node2.prevNode;
			bool prev2IsParent = node2.prevIsParent;
			AIONode next2 = node2.nextNode;

			//Swap link
			//Huong toi
			//Node2
			if (prev1IsParent)
				prev1.childNode = node2;
			else
				prev1.nextNode = node2;

			node2.nextNode = next1;

			//Node1
			if (prev2IsParent) 			
				prev2.childNode = node1;							
			else 			
				prev2.nextNode = node1;			

			node1.nextNode = next2;

			//Huong lui
			//Node1
			node1.prevNode = prev2;
			node1.prevIsParent = prev2IsParent;

			if (next2 != null)
				next2.prevNode = node1;

			//Node2
			node2.prevNode = prev1;
			node2.prevIsParent = prev1IsParent;

			if (next1 != null)
				next1.prevNode = node2;

			//Swap data
			//???
		}

		public void Sort(AIONode subroot) 
		{
			AIONode current = subroot.childNode;
			while (current != null) 
			{

			}
		}

		
	}
}
