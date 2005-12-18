using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmSplash.
	/// </summary>
	public class frmSplash : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblLoading;

		private Image imgSplash;

		public frmSplash()
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
			this.lblLoading = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblLoading
			// 
			this.lblLoading.BackColor = System.Drawing.Color.White;
			this.lblLoading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLoading.ForeColor = System.Drawing.Color.DimGray;
			this.lblLoading.Location = new System.Drawing.Point(24, 16);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(320, 24);
			this.lblLoading.TabIndex = 0;
			this.lblLoading.Text = "Loading";
			this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLoading.Click += new System.EventHandler(this.lblLoading_Click);
			// 
			// frmSplash
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(360, 64);
			this.Controls.Add(this.lblLoading);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSplash";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmSplash_Load);
			this.ResumeLayout(false);

		}
		#endregion

		//Methods-------------------------------------------------------
		private void LoadSplash() 
		{
			ResourceManager resMan = new ResourceManager("AIOForm.Splash", this.GetType().Assembly);
			this.imgSplash = (Image)resMan.GetObject("AIOSplash");
			this.Width = imgSplash.Width;
			this.Height = imgSplash.Height;

			lblLoading.Left = (imgSplash.Width - lblLoading.Width) / 2;
			lblLoading.Top = 250;
		}

		private void DrawSplash(Graphics g) 
		{			
			g.DrawImage(imgSplash, 0, 0, imgSplash.Width, imgSplash.Height);
		}

		//Handlers------------------------------------------------------
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground (pevent);
			//Draw background
			DrawSplash(pevent.Graphics);
		}

		private void frmSplash_Load(object sender, System.EventArgs e)
		{
			LoadSplash();
		}

		private void lblLoading_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

	}
}
