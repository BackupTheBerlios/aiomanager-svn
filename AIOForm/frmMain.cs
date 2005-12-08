using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AIOCommon;
using System.Threading;

namespace AIOForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstDirectory;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.TextBox txtPath;
		private AIOUserControls.DateTextBox dateTextBox1;
		private AIOUserControls.RatingField ratingField1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox txtPattern;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ContextMenu ctxMenu;
		private System.Windows.Forms.Label lblFound;			
		private System.ComponentModel.IContainer components;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstDirectory = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.lblTotal = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.txtPattern = new System.Windows.Forms.TextBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.ctxMenu = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.lblFound = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lstDirectory
			// 
			this.lstDirectory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstDirectory.ItemHeight = 16;
			this.lstDirectory.Location = new System.Drawing.Point(8, 40);
			this.lstDirectory.Name = "lstDirectory";
			this.lstDirectory.Size = new System.Drawing.Size(96, 228);
			this.lstDirectory.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(456, 328);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "Synch";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblTotal
			// 
			this.lblTotal.BackColor = System.Drawing.Color.Beige;
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(8, 280);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(432, 80);
			this.lblTotal.TabIndex = 2;
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(8, 8);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(320, 23);
			this.txtPath.TabIndex = 3;
			this.txtPath.Text = "D:\\Ebooks";
			// 
			// treeView1
			// 
			this.treeView1.AllowDrop = true;
			this.treeView1.HotTracking = true;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(112, 40);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(192, 232);
			this.treeView1.TabIndex = 6;
			this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
			// 
			// txtPattern
			// 
			this.txtPattern.Location = new System.Drawing.Point(336, 8);
			this.txtPattern.Name = "txtPattern";
			this.txtPattern.Size = new System.Drawing.Size(104, 23);
			this.txtPattern.TabIndex = 7;
			this.txtPattern.Text = "*.chm";
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(312, 40);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(344, 232);
			this.listView1.TabIndex = 8;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
			this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File Name";
			this.columnHeader1.Width = 237;
			// 
			// ctxMenu
			// 
			this.ctxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.menuItem1,
																					this.menuItem2,
																					this.menuItem3,
																					this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Cut";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Copy";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Paste";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Delete";
			// 
			// lblFound
			// 
			this.lblFound.Location = new System.Drawing.Point(456, 288);
			this.lblFound.Name = "lblFound";
			this.lblFound.Size = new System.Drawing.Size(200, 32);
			this.lblFound.TabIndex = 9;
			this.lblFound.Text = "0";
			// 
			// frmMain
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(664, 378);
			this.Controls.Add(this.lblFound);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.txtPattern);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.lblTotal);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lstDirectory);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmMain";
			this.Text = "ALL in ONE Manager";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
	/*	[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new frmMain());
		}*/

		AccurateTimer timer = new AccurateTimer();
		AIOFolderTree tree = new AIOFolderTree();

		Thread thread = null;
		private void button1_Click(object sender, System.EventArgs e)
		{
			treeView1.Nodes.Clear();
			timer.Start();
			
			thread = new Thread(new ThreadStart(Synchronize));
			thread.Start();			
		}

		public void Synchronize() {
			tree.Synchronize(txtPath.Text.Trim(), txtPattern.Text.Trim(), true);

			/*					
			lstDirectory.Items.Clear();			
			ArrayList list = tree.PrintTree();
			lstDirectory.Items.AddRange(list.ToArray());			
			*/

			treeView1.Invoke(new FillTree_Dele(FillTree));

			
		}
		
		public delegate void FillTree_Dele();
		public void FillTree() {
			//FillTreeView			
			tree.FillOneLevelTree(treeView1);
			
			
			ImageList imgList = new ImageList();
			imgList.ColorDepth = ColorDepth.Depth32Bit;
			imgList.Images.Add(new Icon(@"D:\Working\ALLinONE_Manager\Coding\ALLinONE_Manager\AIOIcon\folder3.ico"));
			imgList.Images.Add(new Icon(@"D:\Working\ALLinONE_Manager\Coding\ALLinONE_Manager\AIOIcon\file1.ico"));
			imgList.Images.Add(new Icon(@"D:\Working\ALLinONE_Manager\Coding\ALLinONE_Manager\AIOIcon\folder2_green.ico"));
			treeView1.ImageList = imgList;
			treeView1.SelectedImageIndex = 2;

			treeView1.Nodes[0].Expand();
			treeView1.SelectedNode = treeView1.Nodes[0];
			treeView1.Refresh();

			//FillListView		
			listView1.SmallImageList = imgList;
			listView1.LargeImageList = imgList;

			timer.Stop();
			lblTotal.Text = "Folders: " + tree.FoldersCount + " Files: " + tree.FilesCount + " List: " + lstDirectory.Items.Count + " Elapsed: " + timer.Duration + " (s)";			
		}

		private void ratingField1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void UpdateListView() {
			listView1.Items.Clear();
			TreeNode node = treeView1.SelectedNode;
			if (node == null) return;

			AIONode aionode = (AIONode)node.Tag;
			aionode = aionode.childNode;
			while (aionode != null) 
			{
				ListViewItem item = listView1.Items.Add(aionode.data.Name, 0);
				item.Tag = aionode;
				if (aionode.data.isFile)
					item.ImageIndex = 1;
				aionode = aionode.nextNode;
			}
		}
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			UpdateListView();
		}

		private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			
		}

		private void treeView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{			/*
			MessageBox.Show(sender.ToString());
			AIONode nodeToAttach = (AIONode)treeView1.SelectedNode.Tag;			
			AIONode nodeToDrop = (AIONode)e.Data.GetData(typeof(AIONode));
			 
			bool toMove = true;
			if (e.Effect == DragDropEffects.Move) //Move
			{
				//Logically move
				tree.MoveNode(nodeToDrop, nodeToAttach);					
			} 
			else 
			{
				if (e.Effect == DragDropEffects.Copy) //Copy
				{
					//Logical copy
					tree.CopyNode(nodeToDrop, nodeToAttach);
					toMove = false;
				}
			}

			if (nodeToDrop.isFile == false) //Update Tree View
			{
				//TreeView process
				TreeNode toAttach = treeView1.SelectedNode;
				TreeNode toDrop = new TreeNode();
				tree.CopyNodeInfo(toDrop, nodeToDrop);
				
				if (toMove) //Move
				{
					//Delete old folder node
					int i = 0;
					for (i = 0;i<previousSelected.Nodes.Count;i++)
						if (previousSelected.Nodes[i].Text.Equals(toDrop.Text))
							break;
					previousSelected.Nodes.RemoveAt(i);
				}

				//Attach to new parent
				toAttach.Nodes.Insert(0, toDrop);
				
				//Refresh
				toAttach.Collapse();
				toAttach.Expand();				
			}
	

			UpdateListView();*/
		}

		//AIONode previousNode = null;
		//bool isParent = false;
		TreeNode previousSelected = null; //Save previous selected node in DragDrop for Delete old node
		private void listView1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left) 
			{				
				if (listView1.SelectedIndices.Count == 0) return;

				int index = listView1.SelectedIndices[0];
				AIONode node = (AIONode)listView1.Items[index].Tag;

				//Copy or Move				
				listView1.DoDragDrop(node, DragDropEffects.All);
			}
		}

		private void treeView1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			// Retrieve the client coordinates of the mouse position.
			Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

			// Select the node at the mouse position.
			treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
			treeView1.Select();

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
			tree.FillOneLevelNode(node, (AIONode)(node.Tag));						
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{			
			if (e.KeyCode == Keys.Delete) //Delete
			{
				if (listView1.SelectedIndices.Count == 0) return;

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
					//Delete node at tree
					selected.Nodes.RemoveAt(i);*/
					TreeNode node = (TreeNode)nodeToDelete.container;
					node.Remove();
				}
				//Refresh
				UpdateListView();			
			}
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{/*
			if (listView1.SelectedIndices.Count == 0) return;

			//Refresh previousNode, used for move and delete
			int index = listView1.SelectedIndices[0];
			if (index > 0) 
			{
				previousNode = (AIONode)listView1.Items[index-1].Tag;
				isParent = false;
			}
			else  
			{
				previousNode = (AIONode)treeView1.SelectedNode.Tag;
				isParent = true;
			}		*/
		}

		private void treeView1_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			//Save previous selected node for delete use
			previousSelected = treeView1.SelectedNode;
		}				
	}
}
