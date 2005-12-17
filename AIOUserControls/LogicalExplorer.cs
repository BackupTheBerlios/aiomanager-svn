using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;
using AIOCommon;

namespace AIOUserControls
{
	/// <summary>
	/// Summary description for LogicalExplorer.
	/// </summary>	

	public class LogicalExplorer : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TreeView treeView1;

		private AIOFolderTree tree = null;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		//Boolean
		private bool IsDragDroping = false;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem ctxCut;
		private System.Windows.Forms.MenuItem ctxCopy;
		private System.Windows.Forms.MenuItem ctxPaste;
		private System.Windows.Forms.MenuItem ctxDelete;
		private System.Windows.Forms.MenuItem ctxNew;
		private System.Windows.Forms.MenuItem ctxRename;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		
		private System.Windows.Forms.MenuItem menuItem9;
	
		//Drag Drop
		//private enum DragDropType {TREE, LIST, TREE_TO_TREE, TREE_TO_LIST, LIST_TO_TREE, LIST_TO_LIST};
		//private DragDropType ddType;

		//State for Context Menu: Cut - Copy - Paste
		private enum ContextState {CTX_READY, CTX_CUT, CTX_COPY};
		private ContextState ctxState;

		//Node to operate - cut - copy - paste
		private AIONode nodeToOperate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;

		//Save sender for cut - copy - paste
		private object objSender; //Context menu hien len tai control nao, treeview hay listview
		
		//Database
		private AIODatabase aioDb;
		//ViewDetailsEvent
		public delegate void ViewDetailsInfoDele(object [] info);
		public event ViewDetailsInfoDele ViewDetailsInfo;

		//EditFileInfoEvent
		public delegate void EditFileInfoDele(string ID);
		public event EditFileInfoDele EditFileInfo;


		public LogicalExplorer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();					
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LogicalExplorer));
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.ctxNew = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.ctxCut = new System.Windows.Forms.MenuItem();
			this.ctxCopy = new System.Windows.Forms.MenuItem();
			this.ctxPaste = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.ctxRename = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.ctxDelete = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.LabelEdit = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(152, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(456, 312);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 10;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
			this.listView1.DragOver += new System.Windows.Forms.DragEventHandler(this.listView1_DragOver);
			this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
			this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
			this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File Name";
			this.columnHeader1.Width = 182;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// treeView1
			// 
			this.treeView1.AllowDrop = true;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.LabelEdit = true;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 2;
			this.treeView1.Size = new System.Drawing.Size(152, 312);
			this.treeView1.TabIndex = 9;
			this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
			this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
			this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
			this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
			this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
			this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(152, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 312);
			this.splitter1.TabIndex = 11;
			this.splitter1.TabStop = false;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.ctxNew,
																						 this.menuItem9,
																						 this.ctxCut,
																						 this.ctxCopy,
																						 this.ctxPaste,
																						 this.menuItem8,
																						 this.ctxRename,
																						 this.menuItem7,
																						 this.ctxDelete});
			// 
			// ctxNew
			// 
			this.ctxNew.Index = 0;
			this.ctxNew.Text = "New Category";
			this.ctxNew.Click += new System.EventHandler(this.ctxNew_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "-";
			// 
			// ctxCut
			// 
			this.ctxCut.Index = 2;
			this.ctxCut.Text = "Cut";
			this.ctxCut.Click += new System.EventHandler(this.ctxCut_Click);
			// 
			// ctxCopy
			// 
			this.ctxCopy.Index = 3;
			this.ctxCopy.Text = "Copy";
			this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
			// 
			// ctxPaste
			// 
			this.ctxPaste.Index = 4;
			this.ctxPaste.Text = "Paste";
			this.ctxPaste.Click += new System.EventHandler(this.ctxPaste_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 5;
			this.menuItem8.Text = "-";
			// 
			// ctxRename
			// 
			this.ctxRename.Index = 6;
			this.ctxRename.Text = "Rename";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 7;
			this.menuItem7.Text = "-";
			// 
			// ctxDelete
			// 
			this.ctxDelete.Index = 8;
			this.ctxDelete.Text = "Delete";
			this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(416, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(176, 56);
			this.label1.TabIndex = 12;
			this.label1.Text = "label1";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Ratings";
			this.columnHeader2.Width = 105;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Comment";
			this.columnHeader3.Width = 104;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Path";
			this.columnHeader4.Width = 100;
			// 
			// LogicalExplorer
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.treeView1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "LogicalExplorer";
			this.Size = new System.Drawing.Size(608, 312);
			this.ResumeLayout(false);

		}
		#endregion

		public void SetTree(AIOFolderTree tree2) 
		{
			this.tree = tree2;

			//RegisterEvent
			tree.UpdateLogicalExplorer += new AIOCommon.AIOFolderTree.UpdateLogicalExplorerDele(tree_UpdateLogicalExplorer);

			tree.FillOneLevelTree(treeView1);
			treeView1.SelectedNode = treeView1.Nodes[0];
			UpdateListView();
		}

		public AIODatabase AioDatabase
		{
			set 
			{
				aioDb = value;
			}
		}

		private void UpdateListView() 
		{
			listView1.Items.Clear();
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			AIONode aionode = (AIONode)node.Tag;
			if (aionode == null) return;

			aionode = aionode.childNode;
			while (aionode != null) 
			{
				string name = "null";
				//if (aionode.data != null)
					name = aionode.data.Name;
					//name = aionode.data.ID;
				ListViewItem item = listView1.Items.Add(name, 0);
				//Save tag
				item.Tag = aionode;

				//View sub items info
				if (aionode.data.isFile) 
				{
					object [] obj = aioDb.GetCommonInfo(aionode.data.ID);

					//View it
					if (obj != null)
						for(int i = 0;i<obj.Length;i++)
							item.SubItems.Add(obj[i].ToString());

				}

				if (aionode.data.isFile)
					item.ImageIndex = 1;
				aionode = aionode.nextNode;
			}
		}

		private void GoToSelectedFolder() 
		{
			if (listView1.SelectedItems.Count == 0) return;
			AIONode node = (AIONode)listView1.SelectedItems[0].Tag;
			if (node.data.isFile == false) //IsFolder
			{
				TreeNode selected = treeView1.SelectedNode;
				if (selected.IsExpanded == false)
					selected.Expand();
				
				TreeNode treenode = (TreeNode)node.container;				

				treeView1.SelectedNode = treenode;
				treeView1.Select();
				UpdateListView();
				if (listView1.Items.Count > 0)
					listView1.Items[0].Selected = true;

				listView1.Select();
			} 
			else //IsFile - Execute here-----------------
			{				
				//System.Diagnostics.Process.Start(node.info.FullName);
				string ID = node.data.ID;

				EditFileInfo(ID);
			}
		}
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//if (!IsDragDroping)
				UpdateListView();

			//Debug Info
			int [] count = tree.Count((AIONode)e.Node.Tag);
			label1.Text = "Folders: " + count[0] + " Files: " + count[1];
		}

		private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//Cancel drag drop
			IsDragDroping = false;

			AIONode nodeToAttach;
			if (listView1.SelectedItems.Count == 0) 
				nodeToAttach = (AIONode)treeView1.SelectedNode.Tag;
			else
				nodeToAttach = (AIONode)listView1.SelectedItems[0].Tag;			

			if (nodeToAttach == null) return;

			AIONode nodeToDrop = (AIONode)e.Data.GetData(typeof(AIONode));

			//Must be a folder
			if (nodeToAttach.data.isFile) return;

			//Check if valid to move or copy
			if (!tree.IsValidMoveCopy(nodeToDrop, nodeToAttach)) 
			{
				MessageBox.Show("Can't move or copy to sub folder.");
				return;
			}

			//Create container if not available
			if (nodeToAttach.container == null) 
			{
				CreateContainerNode(nodeToAttach);
			}

			if (nodeToDrop.data.isFile == false && nodeToDrop.container == null) 
			{
				CreateContainerNode(nodeToDrop);
			}

			if (e.Effect.Equals(DragDropEffects.Move)) //Move
			{
				//Logically move
				MoveNode(nodeToDrop, nodeToAttach);					
			} 
			else 
			{
				if (e.Effect.Equals(DragDropEffects.Copy)) //Copy
				{
					//Logical copy
					CopyNode(nodeToDrop, nodeToAttach);										
				}
			}
		}

		private void treeView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{			
			//Cancel drag drop
			IsDragDroping = false;			

			AIONode nodeToAttach = (AIONode)treeView1.SelectedNode.Tag;			
			AIONode nodeToDrop = (AIONode)e.Data.GetData(typeof(AIONode));

			//Check if valid to move or copy
			if (!tree.IsValidMoveCopy(nodeToDrop, nodeToAttach)) {
				MessageBox.Show("Can't move or copy to sub folder.");
				return;
			}

			if (nodeToDrop.data.isFile == false && nodeToDrop.container == null) 
			{
				CreateContainerNode(nodeToDrop);
			}


			if (e.Effect.Equals(DragDropEffects.Move)) //Move
			{
				MoveNode(nodeToDrop, nodeToAttach);
			} 
			else 
			{				
				if (e.Effect.Equals(DragDropEffects.Copy)) //Copy
				{
					//Logical copy
					CopyNode(nodeToDrop, nodeToAttach);			
				}
			}

		}

		private TreeNode previousSelected = null; //Save previous selected node in DragDrop for Delete old node

		private void listView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left && !IsDragDroping) 
			{				
				if (listView1.SelectedIndices.Count == 0) return;

				int index = listView1.SelectedIndices[0];
				AIONode node = (AIONode)listView1.Items[index].Tag;

				IsDragDroping = true;
				//ddType = DragDropType.LIST;

				previousSelected = treeView1.SelectedNode;

				//Copy or Move				
				listView1.DoDragDrop(node, DragDropEffects.Copy | DragDropEffects.Move);				
			}
		}

		private void treeView1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{		
			TreeViewSelectAt(treeView1.PointToClient(new Point(e.X, e.Y)));			

			//Determine DragDrop Effects			
			if ((e.KeyState & 4) == 4) //Shift
			{
				e.Effect = DragDropEffects.Move;
			}
			else 
			{
				if ((e.KeyState & 8) == 8) //Ctrl
				{
					e.Effect = DragDropEffects.Copy;
				}
				else 
				{
					if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) //Move by default;
					{
						e.Effect = DragDropEffects.Move;

					}
				}
			}
		}

		private void treeView1_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{	
			TreeNode node = e.Node;						
			if (node.Nodes[0].Text.Equals("")) //Khong phai luc na`o expand cung them vao tree (vi se lam cham chuong trinh)
				tree.FillOneLevelNode(node, (AIONode)(node.Tag));													
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{			
			if (e.KeyCode == Keys.Delete) //Delete
			{
				if (listView1.SelectedIndices.Count == 0) return;

				if (e.Shift == false) //Confirmation
				{
					DialogResult result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
					if (result.Equals(DialogResult.No))
						return;
				}                

				int index = listView1.SelectedIndices[0];
				AIONode nodeToDelete = (AIONode)listView1.Items[index].Tag;

				DeleteNode(nodeToDelete);
			}

			if (e.KeyCode == Keys.Enter)
			{
				GoToSelectedFolder();
			}
		}

		//Update details Info on frmAIOMain
		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0) return;
			UpdateDetailsInfo();			
		}

		private void treeView1_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{			
			
		}				

		//Tree view drapdrop
		private void treeView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (((e.Button & MouseButtons.Left) == MouseButtons.Left) && !IsDragDroping) 
			{				
				TreeNode treeNode = treeView1.SelectedNode;
				if (treeNode == null) return;

				AIONode node = (AIONode)treeNode.Tag;

				IsDragDroping = true;
				//ddType = DragDropType.TREE;

				previousSelected = treeView1.SelectedNode;

				//Copy or Move				
				treeView1.DoDragDrop(node, DragDropEffects.Copy | DragDropEffects.Move);				
			}
		}

		private void treeView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			IsDragDroping = false;
		}

		private void listView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{			
			IsDragDroping = false;			
		}

		private void listView1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{				
			ListViewSelectAt(listView1.PointToClient(new Point(e.X, e.Y)));

			//Determine DragDrop Effects			
			if ((e.KeyState & 4) == 4) //Shift
			{
				e.Effect = DragDropEffects.Move;
			}
			else 
			{
				if ((e.KeyState & 8) == 8) //Ctrl
				{
					e.Effect = DragDropEffects.Copy;
				}
				else 
				{
					if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) //Move by default;
					{
						e.Effect = DragDropEffects.Move;

					}
				}
			}
		}

		//Double click to open a folder
		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			GoToSelectedFolder();
		}

		//Delete
		private void treeView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete) //Delete
			{
				TreeNode node = treeView1.SelectedNode;
				if (node == null) return;

				if (e.Shift == false) //Confirmation
				{
					DialogResult result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
					if (result.Equals(DialogResult.No))
						return;
				}                
								
				AIONode nodeToDelete = (AIONode)node.Tag;		
				
				DeleteNode(nodeToDelete);
			}		
		}

		//Context menu
		private void ShowContextMenu(Control owner, int x, int y) 
		{
			//contextMenu1.Show(owner, owner.PointToClient(new Point(x, y)));
			contextMenu1.Show(owner, new Point(x, y));
		}
		private void treeView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right) 
			{
				TreeViewSelectAt(new Point(e.X, e.Y));
				objSender = sender;
				ShowContextMenu(treeView1, e.X, e.Y);
			}
		}

		private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right) 
			{
				ListViewSelectAt(new Point(e.X, e.Y));
				objSender = sender;
				ShowContextMenu(listView1, e.X, e.Y);
			}
		}

		//Get the node to operate in Cut-Copy-Paste
		private AIONode GetOperateNode(object sender) 
		{
			AIONode nodeToOperate = null;
			if (sender.Equals(treeView1)) 
			{
				TreeNode treenode = treeView1.SelectedNode;
				if (treenode == null) return null;
			
				//Save nodeToOperate
				nodeToOperate = (AIONode)treenode.Tag;
			}
			else 
				if (sender.Equals(listView1)) 
			{
				if (listView1.SelectedItems.Count == 0) return null;
				
				//Save nodeToOperate
				nodeToOperate = (AIONode)listView1.SelectedItems[0].Tag;
			}
			return nodeToOperate;
		}

		//x, y la client coordinate
		private void ListViewSelectAt(Point targetPoint) 
		{
			// Select the item at the mouse position.
			listView1.MultiSelect = false;
			ListViewItem item = listView1.GetItemAt(targetPoint.X, targetPoint.Y);
			
			if (item == null) return;

			item.Selected = true;
			listView1.Select();
		}

		//x, y la client coordinate
		private void TreeViewSelectAt(Point targetPoint) 
		{
			// Select the node at the mouse position.
			treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);			
			treeView1.Select();
		}
		private void ctxCut_Click(object sender, System.EventArgs e)
		{
			//Save the node that currently clicked to cut
			nodeToOperate = GetOperateNode(objSender);	
			//Not null is required
			if (nodeToOperate == null) return;
			//Change state
			ctxState = ContextState.CTX_CUT;
		}

		private void ctxCopy_Click(object sender, System.EventArgs e)
		{
			//Save the node that currently clicked to copy
			nodeToOperate = GetOperateNode(objSender);	
			//Not null is required
			if (nodeToOperate == null) return;
			//Change state
			ctxState = ContextState.CTX_COPY;
		}

		private void ctxPaste_Click(object sender, System.EventArgs e)
		{
			if (nodeToOperate == null) return;

			//Get node to operate
			AIONode destNode = GetOperateNode(objSender);
			if (destNode == null) 
			{
				if (objSender.Equals(listView1)) //Neu ListView khong select
				{
					destNode = GetOperateNode(treeView1); //Sau khi lay o tree, destNode luon la mot thu muc
				}
				else return;
			}
			else
			if (destNode.data.isFile) 
			{
				//Change destNode to current category in treeView
				destNode = GetOperateNode(treeView1); 
				if (destNode == null) return;
			}

			//Checking
			if (!tree.IsValidMoveCopy(nodeToOperate, destNode))
			{
				return;
			}

			switch (ctxState) 
			{
				case ContextState.CTX_CUT:
					MoveNode(nodeToOperate, destNode);

					break;
				
				case ContextState.CTX_COPY:
					CopyNode(nodeToOperate, destNode);

					break;
			}
			ctxState = ContextState.CTX_READY;
		}

		private void ctxDelete_Click(object sender, System.EventArgs e)
		{
			nodeToOperate = GetOperateNode(objSender);

			if (nodeToOperate == null) return;

			//Delete
			DeleteNode(nodeToOperate);

			ctxState = ContextState.CTX_READY;
		}

		private void ctxNew_Click(object sender, System.EventArgs e)
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;
			
			node.Expand();

			//Insert new category
			AIONode nodeToAttach = (AIONode)node.Tag;
			tree.FoldersCount++;
			AIONode nodeToInsert = new AIONode(new AIOInfo(tree.GenerateFolderID(), "New Category", false));
			tree.InsertCategory(nodeToInsert, nodeToAttach);

			//Tree
			TreeNode newNode = new TreeNode();
			tree.CopyNodeInfo(newNode, nodeToInsert);

			//Save Container
			nodeToInsert.container = newNode;		

			//Insert();
			node.Nodes.Insert(0, newNode);
			if (node.IsExpanded == false)
				node.Expand();

			newNode.BeginEdit();
		}

		public void InsertFileIntoSelectedNode(string path) 
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;
			
			//Insert new category
			AIONode nodeToAttach = (AIONode)node.Tag;

			tree.FilesCount++;

			string name = AIOUtil.GetNameFromPath(path);
			AIONode nodeToInsert = new AIONode(new AIOInfo(tree.GenerateFileID(), name, true));
			
			tree.InsertFile(nodeToInsert, nodeToAttach, path);

			//Be sure to execute the queue
			aioDb.ExecuteQueueCommand();

			//Update listview
			UpdateListView();
		}

		private void treeView1_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			TreeNode node = e.Node;
			if (e.Label != null) {
				AIONode aionode = (AIONode)node.Tag;
				aionode.data.Name = e.Label;
			}
		}

		private void listView1_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
		{
			if (e.Label != null) 
			{
				AIONode aionode = (AIONode)listView1.Items[e.Item].Tag;
				aionode.data.Name = e.Label;

				TreeNode node = (TreeNode)aionode.container;
				node.Text = e.Label;			
			}
		}


		//My methods-----------------------------------------------------

		//Create a tree node from AIONode
		private TreeNode CreateTreeNode(AIONode node) 
		{
			TreeNode treenode = new TreeNode();
			tree.CopyNodeInfo(treenode, node);

			//Save container
			node.container = treenode;

			return treenode;
		}
		//Insert child to parent - call after AIOTree insert
		private void InsertNode(TreeNode parent, TreeNode child) 
		{	
			if (parent.Nodes.Count > 0)
			{
				if (parent.Nodes[0].Text.Equals("")) //Expand already insert the child node
					parent.Expand();
				else 
				{
					parent.Nodes.Insert(0, child);
					parent.Expand();
				}
			}
			else 
			{
				parent.Nodes.Insert(0, child);
				parent.Expand();
			}
		}

		private void MoveNode(AIONode nodeToMove, AIONode nodeToAttach) 
		{
			//Logically
			tree.MoveNode(nodeToMove, nodeToAttach);
			//Change tree
			if (nodeToMove.data.isFile == false) //Folder
			{
				TreeNode toMove = (TreeNode)nodeToMove.container;
				TreeNode toAttach = (TreeNode)nodeToAttach.container;

				AIONode parent = tree.GetParent(nodeToMove);
				TreeNode parentNode = (TreeNode)parent.container;
                
				//Remove old
				parentNode.Nodes.Remove(toMove);

				//Insert new
				InsertNode(toAttach, toMove);
			}

			//previousSelected
			treeView1.SelectedNode = previousSelected;

			//Update
			UpdateListView();
		}

		private void CopyNode(AIONode nodeToCopy, AIONode nodeToAttach) 
		{
			//Logically
			AIONode newCopy = tree.CopyNode(nodeToCopy, nodeToAttach);
			//Change tree
			if (nodeToCopy.data.isFile == false) //Folder
			{				
				TreeNode toAttach = (TreeNode)nodeToAttach.container;

				TreeNode newCopyNode = CreateTreeNode(newCopy);
				//Insert null child for new copy node
				newCopyNode.Nodes.Insert(0, new TreeNode());

				//Insert new
				InsertNode(toAttach, newCopyNode);
			}

			//previousSelected
			treeView1.SelectedNode = previousSelected;

			//Update
			UpdateListView();
		}

		private void DeleteNode(AIONode nodeToDelete) 
		{
			try 
			{
				tree.DeleteNode(nodeToDelete);

				if (nodeToDelete.data.isFile == false) 
				{
					TreeNode toDelete = (TreeNode)nodeToDelete.container;
					toDelete.Remove();
				}

				UpdateListView();
			}
			catch (Exception e) 
			{
				MessageBox.Show(e.Message);
			}
		}

		private void CreateContainerNode(AIONode node) 
		{
			AIONode parent = tree.GetParent(node);
			TreeNode parentNode = (TreeNode)parent.container;

			//Expand to create childnodes and container
			parentNode.Expand();		
		}

		public AIONode GetCurrentFolder() 
		{
			TreeNode treenode = treeView1.SelectedNode;
			if (treenode == null) return null;
			AIONode node = (AIONode)treenode.Tag;
			return node;
		}
		
		//---------------------------------------------------------------

		//Update details information
		private void UpdateDetailsInfo() 
		{
			AIONode node = (AIONode)listView1.SelectedItems[0].Tag;
			if (node.data.isFile == false) return;

			string path = listView1.SelectedItems[0].SubItems[3].Text;
			FileInfo file = new FileInfo(path);
			long size = file.Length;
			ViewDetailsInfo(new string[] {AIOUtil.ByteToKB_String(size)});
		}

		//Update tree when synchronize
		private delegate void InsertNodeDele(TreeNode parent, TreeNode child);
		private void tree_UpdateLogicalExplorer(AIONode node)
		{
			TreeNode treenode = new TreeNode();
			tree.CopyNodeInfo(treenode, node);
			//Make container			
			node.container = treenode;
			
			AIONode parent = tree.GetParent(node);
			TreeNode parentnode = (TreeNode)parent.container;
			
			tree.FillOneLevelNode(treenode, node);
			//Insert to treeView
			//InsertNode(parentnode, treenode);
			//Marshall to STA thread
			treeView1.Invoke(new InsertNodeDele(InsertNode), new object[] {parentnode, treenode});
		}

		
	}
}
