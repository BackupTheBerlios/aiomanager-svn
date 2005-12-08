using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using AIOCommon;
using System.IO;

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
		private enum DragDropType {TREE, LIST, TREE_TO_TREE, TREE_TO_LIST, LIST_TO_TREE, LIST_TO_LIST};
		private DragDropType ddType;

		//State for Context Menu: Cut - Copy - Paste
		private enum ContextState {CTX_READY, CTX_CUT, CTX_COPY};
		private ContextState ctxState;

		//Node to operate - cut - copy - paste
		private AIONode nodeToOperate;

		//Save sender for cut - copy - paste
		private object objSender; //Context menu hien len tai control nao, treeview hay listview
		
		public LogicalExplorer()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call			
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
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
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
			this.columnHeader1.Width = 257;
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
			// LogicalExplorer
			// 
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
			tree.FillOneLevelTree(treeView1);
			treeView1.SelectedNode = treeView1.Nodes[0];
			UpdateListView();
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
				if (aionode.data != null)
					name = aionode.data.Name;
				ListViewItem item = listView1.Items.Add(name, 0);

				item.Tag = aionode;

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
			}
		}
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//if (!IsDragDroping)
				UpdateListView();
		}

		private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			//Cancel drag drop
			IsDragDroping = false;

			//Decide drag drop type
			if (ddType.Equals(DragDropType.TREE))
				ddType = DragDropType.TREE_TO_LIST;
			else
				ddType = DragDropType.LIST_TO_LIST;

			AIONode nodeToAttach = (AIONode)listView1.SelectedItems[0].Tag;			
			AIONode nodeToDrop = (AIONode)e.Data.GetData(typeof(AIONode));

			//Check if valid to move or copy
			if (!tree.IsValidMoveCopy(nodeToDrop, nodeToAttach)) 
			{
				MessageBox.Show("Can't move or copy to sub folder.");
				return;
			}

			bool toMove = true;
			AIONode newCopy = null;

			if (e.Effect.Equals(DragDropEffects.Move)) //Move
			{
				//Logically move
				tree.MoveNode(nodeToDrop, nodeToAttach);					
			} 
			else 
			{
				toMove = false;
				if (e.Effect.Equals(DragDropEffects.Copy)) //Copy
				{
					//Logical copy
					newCopy = tree.CopyNode(nodeToDrop, nodeToAttach);										
				}
			}

			if (nodeToDrop.data.isFile == false) //Update Tree View
			{
				//TreeView process
				TreeNode toAttach = (TreeNode)nodeToAttach.container;
				TreeNode toDrop = new TreeNode();
				toDrop.Nodes.Add(new TreeNode()); //Add a blank node to show expand sign (+)				

				if (toMove)
					tree.CopyNodeInfo(toDrop, nodeToDrop);
				else tree.CopyNodeInfo(toDrop, newCopy);

				//Save container
				//nodeToDrop.container = toDrop;
				
				if (toMove) //Move
				{
					switch (ddType) 
					{
						case DragDropType.TREE_TO_LIST:
							//Delete old folder node
							TreeNode node1 = (TreeNode)(nodeToDrop.container);
							node1.Remove();
							break;

						case DragDropType.LIST_TO_LIST:
							TreeNode node = (TreeNode)(nodeToDrop.container);
							node.Remove();
							break;
					} 
				}

				//Delete blank node
				if (toAttach.Nodes.Count > 0)
				{
					if (toAttach.Nodes[0].Text.Equals("")) 
					{
						toAttach.Nodes.RemoveAt(0);
						tree.FillOneLevelNode(toAttach, nodeToAttach);
					} 
					else 
					{
						//Attach to new parent
						toAttach.Nodes.Insert(0, toDrop);						
					}
				}
				else			
					//Attach to new parent
					toAttach.Nodes.Insert(0, toDrop);					
				
				//Refresh								
				toAttach.Collapse();
				toAttach.Expand();		

				treeView1.Refresh();
			}
	

			UpdateListView();

			
			//Restore selected tree node
			treeView1.SelectedNode = previousSelected;

		}

		private void treeView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{			
			//Cancel drag drop
			IsDragDroping = false;			

			//Decide drag drop type
			if (ddType.Equals(DragDropType.TREE))
				ddType = DragDropType.TREE_TO_TREE;
			else
				ddType = DragDropType.LIST_TO_TREE;


			AIONode nodeToAttach = (AIONode)treeView1.SelectedNode.Tag;			
			AIONode nodeToDrop = (AIONode)e.Data.GetData(typeof(AIONode));

			//Check if valid to move or copy
			if (!tree.IsValidMoveCopy(nodeToDrop, nodeToAttach)) {
				MessageBox.Show("Can't move or copy to sub folder.");
				return;
			}

			bool toMove = true;
			AIONode newCopy = null;

			if (e.Effect.Equals(DragDropEffects.Move)) //Move
			{
				//Logically move
				tree.MoveNode(nodeToDrop, nodeToAttach);					
			} 
			else 
			{
				toMove = false;
				if (e.Effect.Equals(DragDropEffects.Copy)) //Copy
				{
					//Logical copy
					newCopy = tree.CopyNode(nodeToDrop, nodeToAttach);										
				}
			}

			if (nodeToDrop.data.isFile == false) //Update Tree View
			{
				//TreeView process
				TreeNode toAttach = treeView1.SelectedNode;
				TreeNode toDrop = new TreeNode();
				toDrop.Nodes.Add(new TreeNode()); //Add a blank node to show expand sign (+)

				if (toMove)
					tree.CopyNodeInfo(toDrop, nodeToDrop);
				else tree.CopyNodeInfo(toDrop, newCopy);
				
				if (toMove) //Move
				{
					switch (ddType) {
						case DragDropType.LIST_TO_TREE:
							//Delete old folder node
							/*
							int i = 0;
							for (i = 0;i<previousSelected.Nodes.Count;i++)
								if (previousSelected.Nodes[i].Text.Equals(toDrop.Text))
									break;
							if (i < previousSelected.Nodes.Count)
								previousSelected.Nodes.RemoveAt(i);*/
							TreeNode node = (TreeNode)nodeToDrop.container;
							node.Remove();				
						break;

						case DragDropType.TREE_TO_TREE:
							//previousSelected.Remove();
							node = (TreeNode)nodeToDrop.container;
							node.Remove();
							break;
					} 
				}

				//Delete blank node
				if (toAttach.Nodes.Count > 0)
				{
					if (toAttach.Nodes[0].Text.Equals("")) 
					{
						toAttach.Nodes.RemoveAt(0);
						tree.FillOneLevelNode(toAttach, nodeToAttach);
					} 
					else 
					{
						//Attach to new parent
						toAttach.Nodes.Insert(0, toDrop);						
					}
				}
				else			
					//Attach to new parent
					toAttach.Nodes.Insert(0, toDrop);					
				
				//Refresh				
				toAttach.Collapse();
				toAttach.Expand();								

				treeView1.Refresh();
			}
	

			UpdateListView();

			
			//Restore selected tree node
			treeView1.SelectedNode = previousSelected;
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
				ddType = DragDropType.LIST;

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

				//Delete
				tree.DeleteNode(nodeToDelete);

				//Update tree if isFolder
				if (nodeToDelete.data.isFile == false) 
				{/*
					TreeNode selected = treeView1.SelectedNode;
					int i = 0;
					for (i = 0;i<selected.Nodes.Count;i++) 
					{
						if (selected.Nodes[i].Text.Equals(nodeToDelete.info.Name)) 						
							break;						
					}
					if (i < selected.Nodes.Count)
						//Delete node at tree
						selected.Nodes.RemoveAt(i);*/
					TreeNode node = (TreeNode)nodeToDelete.container;
					node.Remove();
				}
				//Refresh
				UpdateListView();			
			}

			if (e.KeyCode == Keys.Enter)
			{
				GoToSelectedFolder();
			}
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
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
				ddType = DragDropType.TREE;

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
				
				//Delete
				tree.DeleteNode(nodeToDelete);

				node.Remove();

				//Refresh
				UpdateListView();
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
					tree.MoveNode(nodeToOperate, destNode);				

					if (nodeToOperate.data.isFile == false) //IsFolder
					{
						TreeNode operateNode = (TreeNode)nodeToOperate.container;
						TreeNode newNode = (TreeNode)operateNode.Clone();

						operateNode.Remove();

						TreeNode nodeToAttach = (TreeNode)destNode.container;
						nodeToAttach.Expand(); //Expand de refresh cai child node cua nodeToAttach

						if (nodeToAttach.IsExpanded == false) //Neu ko expand dc (0 phan tu)
							nodeToAttach.Nodes.Insert(0, newNode); //Thi insert bang tay
					}									
					
					UpdateListView();

					break;
				
				case ContextState.CTX_COPY:
					tree.CopyNode(nodeToOperate, destNode);				

					if (nodeToOperate.data.isFile == false) //IsFolder
					{
						TreeNode operateNode = (TreeNode)nodeToOperate.container;
						TreeNode newNode = (TreeNode)operateNode.Clone();

						TreeNode nodeToAttach = (TreeNode)destNode.container;
						nodeToAttach.Expand(); //Expand de refresh cai child node cua nodeToAttach

						if (nodeToAttach.IsExpanded == false) //Neu ko expand dc (0 phan tu)
							nodeToAttach.Nodes.Insert(0, newNode); //Thi insert bang tay
					}									
					
					UpdateListView();
					break;
			}
			ctxState = ContextState.CTX_READY;
		}

		private void ctxDelete_Click(object sender, System.EventArgs e)
		{
			nodeToOperate = GetOperateNode(objSender);

			if (nodeToOperate == null) return;

			//Delete
			tree.DeleteNode(nodeToOperate);

			//Refresh
			if (nodeToOperate.data.isFile == false) //Neu la folder va thuoc ve treeview
			{
				TreeNode node = (TreeNode)nodeToOperate.container;
				if (node != null)
					node.Remove();

				treeView1.Refresh();
			}

			//UpdateList
			UpdateListView();

			ctxState = ContextState.CTX_READY;
		}

		private void ctxNew_Click(object sender, System.EventArgs e)
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;
			
			node.Expand();

			//Insert new category
			AIONode nodeToAttach = (AIONode)node.Tag;
			AIONode nodeToInsert = new AIONode(new AIOInfo(tree.GenerateID(), "New Category", false));
			tree.Insert(nodeToInsert, nodeToAttach);

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

		public void InsertFileIntoSelectedNode(string name) 
		{
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;
			
			//Insert new category
			AIONode nodeToAttach = (AIONode)node.Tag;
			AIONode nodeToInsert = new AIONode();
			nodeToInsert.data.isFile = true;

			tree.Insert(nodeToInsert, nodeToAttach);

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
	}
}
