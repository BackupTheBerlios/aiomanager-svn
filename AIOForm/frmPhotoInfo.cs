using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmPhotoInfo.
	/// </summary>
	public class frmPhotoInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private AIOForm.frmCommonInfo frmCommonInfo1;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPhotoInfo()
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
				if(components != null)
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
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.frmCommonInfo1 = new AIOForm.frmCommonInfo();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// button8
			// 
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button8.Location = new System.Drawing.Point(304, 520);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 32);
			this.button8.TabIndex = 61;
			this.button8.Text = "Apply";
			// 
			// button7
			// 
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button7.Location = new System.Drawing.Point(416, 520);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 32);
			this.button7.TabIndex = 60;
			this.button7.Text = "Cancel";
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button6.Location = new System.Drawing.Point(120, 520);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 32);
			this.button6.TabIndex = 59;
			this.button6.Text = "Clear";
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button5.Location = new System.Drawing.Point(8, 520);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 32);
			this.button5.TabIndex = 58;
			this.button5.Text = "Update";
			// 
			// frmCommonInfo1
			// 
			this.frmCommonInfo1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.frmCommonInfo1.Location = new System.Drawing.Point(8, 352);
			this.frmCommonInfo1.Name = "frmCommonInfo1";
			this.frmCommonInfo1.Size = new System.Drawing.Size(520, 160);
			this.frmCommonInfo1.TabIndex = 57;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(512, 336);
			this.pictureBox1.TabIndex = 62;
			this.pictureBox1.TabStop = false;
			// 
			// frmPhotoInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(528, 562);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.frmCommonInfo1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmPhotoInfo";
			this.Text = "Update Photo  Information";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
