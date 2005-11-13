using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace AIOUserControls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class DateTextBox : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button button1;
		public System.Windows.Forms.TextBox txtDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DateTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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
			this.button1 = new System.Windows.Forms.Button();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(120, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtDate
			// 
			this.txtDate.BackColor = System.Drawing.Color.White;
			this.txtDate.Location = new System.Drawing.Point(0, 1);
			this.txtDate.Name = "txtDate";
			this.txtDate.ReadOnly = true;
			this.txtDate.Size = new System.Drawing.Size(112, 20);
			this.txtDate.TabIndex = 1;
			this.txtDate.Text = "";
			// 
			// DateTextBox
			// 
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.button1);
			this.Name = "DateTextBox";
			this.Size = new System.Drawing.Size(144, 24);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			sub subform = new sub(this);
			//button1.Location.X, button1.Location.Y
			//subform.Location = new Point(button1.Location.X, button1.Location.Y);
			//this.parent.Location.X + this.Location.X + button1.Location.X
			subform.Left = this.ParentForm.Left + this.Left + txtDate.Left;
			subform.Top = this.ParentForm.Top + this.Top + txtDate.Top + 64;
			subform.ShowDialog();			
		}
	}
}
