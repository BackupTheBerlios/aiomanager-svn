using System;
using System.IO;
using System.Collections;

namespace AIOCommon
{
	public class AIONode 
	{
		public FileSystemInfo info; //Chua thong tin ve folder, tree
		public bool isFile; //La file hay la folder	
		public AIONode nextNode;
		public AIONode childNode;
	
		public AIONode(FileSystemInfo info, bool isFile) 
		{
			this.info = info;
			this.isFile = isFile;
			childNode = null;
			nextNode = null;
		}

	}
	/// <summary>
	/// Summary description for AIODataStructure.
	/// </summary>
	public class AIOFolderTree
	{
		//root
		private AIONode root;
		//size
		private int size = 0;
		private int foldersCount = 0;
		private int filesCount = 0;
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
		}

		public int FilesCount 
		{
			get
			{
				return filesCount;
			}
		}
		public AIOFolderTree()
		{
		}

		public void Synchronize(string path, string pattern, bool bRecursive) 
		{
			DirectoryInfo di = new DirectoryInfo(path);			
			if (di.Exists) 
			{
				root = new AIONode(di, false);
				Synchronize_R(root, pattern, bRecursive);
			}			
		}
		public void Synchronize_R(AIONode subRoot, string pattern, bool bRecursive) 
		{
			DirectoryInfo di = (DirectoryInfo)subRoot.info;
			DirectoryInfo [] subDi = di.GetDirectories();
			AIONode curChild = null;
			if (subDi.Length > 0) //Co thu muc con
			{
				foldersCount += subDi.Length;
				if (bRecursive) 
				{
					//First Child
					AIONode firstChild = new AIONode(subDi[0], false);
					subRoot.childNode = firstChild;
					//Child
					curChild = firstChild;
					for (int i = 0;i<subDi.Length;i++)
					{
						//Recursive
						Synchronize_R(curChild, pattern, bRecursive);

						//Move next
						if (i < subDi.Length - 1) 
						{
							curChild.nextNode = new AIONode(subDi[i+1], false);						
							curChild = curChild.nextNode;
						}
					}
				}
			} 
			
			//Duyet het file va tra ve
			FileInfo [] fileInfo = di.GetFiles(pattern);
			if (fileInfo.Length > 0) 
			{
				filesCount += fileInfo.Length;
				//FirstNode
				AIONode firstChild = new AIONode(fileInfo[0], true);
				if (curChild == null) 
				{
					subRoot.childNode = firstChild;
					curChild = firstChild;
				} 
				else 
				{
					curChild.nextNode = firstChild;
					curChild = firstChild;
				}
				//Check xem file na`o thoa
				for (int i = 1;i<fileInfo.Length;i++)
				{						
					curChild.nextNode = new AIONode(fileInfo[i], true);
					curChild = curChild.nextNode;
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
			list.Add(subRoot.info.FullName);
			if (subRoot.childNode != null) 
			{
				PrintTree_R(subRoot.childNode, list);
			}
			if (subRoot.nextNode != null) 
			{
				PrintTree_R(subRoot.nextNode, list);
			}
		}
	}
}
