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
			this.dateTextBox1 = new AIOUserControls.DateTextBox();
			this.ratingField1 = new AIOUserControls.RatingField();
			this.SuspendLayout();
			// 
			// lstDirectory
			// 
			this.lstDirectory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstDirectory.ItemHeight = 16;
			this.lstDirectory.Location = new System.Drawing.Point(8, 40);
			this.lstDirectory.Name = "lstDirectory";
			this.lstDirectory.Size = new System.Drawing.Size(432, 228);
			this.lstDirectory.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(448, 328);
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
			this.txtPath.Size = new System.Drawing.Size(432, 23);
			this.txtPath.TabIndex = 3;
			this.txtPath.Text = "C:\\";
			// 
			// dateTextBox1
			// 
			this.dateTextBox1.Location = new System.Drawing.Point(456, 64);
			this.dateTextBox1.Name = "dateTextBox1";
			this.dateTextBox1.Size = new System.Drawing.Size(144, 32);
			this.dateTextBox1.TabIndex = 4;
			// 
			// ratingField1
			// 
			this.ratingField1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ratingField1.Location = new System.Drawing.Point(456, 104);
			this.ratingField1.MaxRatings = 5;
			this.ratingField1.Name = "ratingField1";
			this.ratingField1.Ratings = 1;
			this.ratingField1.Size = new System.Drawing.Size(184, 36);
			this.ratingField1.TabIndex = 5;
			this.ratingField1.Load += new System.EventHandler(this.ratingField1_Load);
			// 
			// frmMain
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(664, 378);
			this.Controls.Add(this.ratingField1);
			this.Controls.Add(this.dateTextBox1);
			this.Controls.Add(this.txtPath);
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
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new frmMain());
		}

		AccurateTimer timer = new AccurateTimer();
		
		private void button1_Click(object sender, System.EventArgs e)
		{
			//ArrayList list = AIOCommon.AIOCommon.Synchronize(@"D:\abc", "*", true);
			//lstDirectory.Items.AddRange(list.ToArray());
			timer.Start();			
			lstDirectory.Items.Clear();
			AIOFolderTree tree = new AIOFolderTree();
			tree.Synchronize(txtPath.Text.Trim(), "*", true);
			ArrayList list = tree.PrintTree();
			lstDirectory.Items.AddRange(list.ToArray());
			timer.Stop();
			lblTotal.Text = "Folders: " + tree.FoldersCount + " Files: " + tree.FilesCount + " List: " + lstDirectory.Items.Count + " Elapsed: " + timer.Duration + " (s)";			
			
		}

		private void ratingField1_Load(object sender, System.EventArgs e)
		{
		
		}				
	}
}
