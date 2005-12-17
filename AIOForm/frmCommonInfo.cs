using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using AIOCommon;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmCommonInfo.
	/// </summary>
	public class frmCommonInfo : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private AIOUserControls.RatingField ratingField1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.Label lblCreatedDate;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnChangePath;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCommonInfo()
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
			this.label1 = new System.Windows.Forms.Label();
			this.ratingField1 = new AIOUserControls.RatingField();
			this.label2 = new System.Windows.Forms.Label();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblCreatedDate = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnChangePath = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ratings";
			// 
			// ratingField1
			// 
			this.ratingField1.BackColor = System.Drawing.Color.White;
			this.ratingField1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ratingField1.Location = new System.Drawing.Point(80, 8);
			this.ratingField1.MaxRatings = 5;
			this.ratingField1.Name = "ratingField1";
			this.ratingField1.Ratings = 0;
			this.ratingField1.Size = new System.Drawing.Size(112, 22);
			this.ratingField1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Comment";
			// 
			// txtComment
			// 
			this.txtComment.BackColor = System.Drawing.Color.Beige;
			this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtComment.Location = new System.Drawing.Point(80, 40);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(424, 48);
			this.txtComment.TabIndex = 3;
			this.txtComment.Text = "";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(8, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 32);
			this.label3.TabIndex = 4;
			this.label3.Text = "Created Date";
			// 
			// lblCreatedDate
			// 
			this.lblCreatedDate.BackColor = System.Drawing.Color.White;
			this.lblCreatedDate.Location = new System.Drawing.Point(80, 104);
			this.lblCreatedDate.Name = "lblCreatedDate";
			this.lblCreatedDate.Size = new System.Drawing.Size(344, 24);
			this.lblCreatedDate.TabIndex = 5;
			this.lblCreatedDate.Text = "28/11/2005";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(8, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Path";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(80, 128);
			this.txtPath.MaxLength = 255;
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(344, 23);
			this.txtPath.TabIndex = 9;
			this.txtPath.Text = "";
			// 
			// btnChangePath
			// 
			this.btnChangePath.BackColor = System.Drawing.Color.White;
			this.btnChangePath.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnChangePath.Location = new System.Drawing.Point(432, 128);
			this.btnChangePath.Name = "btnChangePath";
			this.btnChangePath.Size = new System.Drawing.Size(72, 24);
			this.btnChangePath.TabIndex = 8;
			this.btnChangePath.Text = "Change";
			this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.txtPath);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(512, 160);
			this.panel1.TabIndex = 9;
			// 
			// frmCommonInfo
			// 
			this.Controls.Add(this.btnChangePath);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblCreatedDate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ratingField1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmCommonInfo";
			this.Size = new System.Drawing.Size(512, 160);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void LoadDetails(AIOCommonInfo info) 
		{
			this.ratingField1.Ratings = info.ratings;
			this.txtComment.Text = info.comment;
			this.lblCreatedDate.Text = info.createdDate;
			this.txtPath.Text = info.path;
		}

		//Get all
		public AIOCommonInfo GetCommonInfo() 
		{
			AIOCommonInfo info = new AIOCommonInfo();
			info.ratings = this.ratingField1.Ratings;
			info.comment = txtComment.Text.Trim();
			info.createdDate = lblCreatedDate.Text;
			info.path = txtPath.Text.Trim();

			return info;
		}

		public void GetCommonInfo2(AIOCommonInfo info) 
		{
			info.ratings = this.ratingField1.Ratings;
			info.comment = txtComment.Text.Trim();
			info.createdDate = lblCreatedDate.Text;
			info.path = txtPath.Text.Trim();
		}

		public void Clear() 
		{
			this.ratingField1.Ratings = 0;
			txtComment.Text = "";			
		}

		private void btnChangePath_Click(object sender, System.EventArgs e)
		{
			//Choose another path
			OpenFileDialog file = new OpenFileDialog();
			DialogResult res = file.ShowDialog();
			if (res.Equals(DialogResult.OK))
				txtPath.Text = file.FileName;
		}
	}
}
