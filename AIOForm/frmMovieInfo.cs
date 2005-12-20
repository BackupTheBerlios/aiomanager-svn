using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AIOCommon;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmMovieInfo.
	/// </summary>
	public class frmMovieInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnUpdate;
		private AIOForm.frmCommonInfo commonInfo;
		private System.Windows.Forms.NumericUpDown nudYear;
		private System.Windows.Forms.Button btnEditDirector;
		private System.Windows.Forms.ComboBox cmbDirector;
		private System.Windows.Forms.Button btnEditActress;
		private System.Windows.Forms.ComboBox cmbActress;
		private System.Windows.Forms.Button btnEditActor;
		private System.Windows.Forms.ComboBox cmbActor;
		private System.Windows.Forms.ComboBox cmbMovieName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private AIODatabase aioDb;
		private DataTable DTDirector;
		private DataTable DTActor;
		private DataTable DTActress;
		private AIOMovie movie;
		private AIOMovieController movieController;


		public frmMovieInfo( AIODatabase aioDb, AIOCommonController controller, string ID )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.aioDb = aioDb;
			this.movieController = ( AIOMovieController )controller;
			this.movie = ( AIOMovie )this.movieController.Select( ID );

			nudYear.Maximum = DateTime.Now.Year;

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
			this.btnClose = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.commonInfo = new AIOForm.frmCommonInfo();
			this.button4 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.nudYear = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.btnEditDirector = new System.Windows.Forms.Button();
			this.cmbDirector = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnEditActress = new System.Windows.Forms.Button();
			this.cmbActress = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEditActor = new System.Windows.Forms.Button();
			this.cmbActor = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbMovieName = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
			this.SuspendLayout();
			// 
			// button8
			// 
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button8.Location = new System.Drawing.Point(304, 408);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 32);
			this.button8.TabIndex = 42;
			this.button8.Text = "Apply";
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(416, 408);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(104, 32);
			this.btnClose.TabIndex = 41;
			this.btnClose.Text = "Close";
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClear.Location = new System.Drawing.Point(120, 408);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(104, 32);
			this.btnClear.TabIndex = 40;
			this.btnClear.Text = "Clear";
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(8, 408);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(104, 32);
			this.btnUpdate.TabIndex = 39;
			this.btnUpdate.Text = "Update";
			// 
			// commonInfo
			// 
			this.commonInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.commonInfo.Location = new System.Drawing.Point(8, 232);
			this.commonInfo.Name = "commonInfo";
			this.commonInfo.Size = new System.Drawing.Size(520, 160);
			this.commonInfo.TabIndex = 38;
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(344, 104);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(40, 24);
			this.button4.TabIndex = 37;
			this.button4.Text = "...";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(392, 72);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(128, 152);
			this.pictureBox1.TabIndex = 36;
			this.pictureBox1.TabStop = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(344, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 35;
			this.label6.Text = "Poster";
			// 
			// nudYear
			// 
			this.nudYear.Location = new System.Drawing.Point(64, 136);
			this.nudYear.Maximum = new System.Decimal(new int[] {
																	2999,
																	0,
																	0,
																	0});
			this.nudYear.Minimum = new System.Decimal(new int[] {
																	1900,
																	0,
																	0,
																	0});
			this.nudYear.Name = "nudYear";
			this.nudYear.TabIndex = 34;
			this.nudYear.Value = new System.Decimal(new int[] {
																  2005,
																  0,
																  0,
																  0});
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 33;
			this.label5.Text = "Year";
			// 
			// btnEditDirector
			// 
			this.btnEditDirector.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditDirector.Location = new System.Drawing.Point(464, 40);
			this.btnEditDirector.Name = "btnEditDirector";
			this.btnEditDirector.Size = new System.Drawing.Size(56, 24);
			this.btnEditDirector.TabIndex = 32;
			this.btnEditDirector.Text = "Edit";
			// 
			// cmbDirector
			// 
			this.cmbDirector.Location = new System.Drawing.Point(64, 40);
			this.cmbDirector.Name = "cmbDirector";
			this.cmbDirector.Size = new System.Drawing.Size(392, 24);
			this.cmbDirector.TabIndex = 31;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "Director";
			// 
			// btnEditActress
			// 
			this.btnEditActress.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditActress.Location = new System.Drawing.Point(272, 104);
			this.btnEditActress.Name = "btnEditActress";
			this.btnEditActress.Size = new System.Drawing.Size(56, 24);
			this.btnEditActress.TabIndex = 29;
			this.btnEditActress.Text = "Edit";
			// 
			// cmbActress
			// 
			this.cmbActress.Location = new System.Drawing.Point(64, 104);
			this.cmbActress.Name = "cmbActress";
			this.cmbActress.Size = new System.Drawing.Size(200, 24);
			this.cmbActress.TabIndex = 28;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 16);
			this.label3.TabIndex = 27;
			this.label3.Text = "Actress";
			// 
			// btnEditActor
			// 
			this.btnEditActor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditActor.Location = new System.Drawing.Point(272, 72);
			this.btnEditActor.Name = "btnEditActor";
			this.btnEditActor.Size = new System.Drawing.Size(56, 24);
			this.btnEditActor.TabIndex = 26;
			this.btnEditActor.Text = "Edit";
			// 
			// cmbActor
			// 
			this.cmbActor.Location = new System.Drawing.Point(64, 72);
			this.cmbActor.Name = "cmbActor";
			this.cmbActor.Size = new System.Drawing.Size(200, 24);
			this.cmbActor.TabIndex = 25;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "Actor";
			// 
			// cmbMovieName
			// 
			this.cmbMovieName.Location = new System.Drawing.Point(64, 8);
			this.cmbMovieName.Name = "cmbMovieName";
			this.cmbMovieName.Size = new System.Drawing.Size(456, 24);
			this.cmbMovieName.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 24);
			this.label1.TabIndex = 22;
			this.label1.Text = "Name";
			// 
			// frmMovieInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(528, 450);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.commonInfo);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.nudYear);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnEditDirector);
			this.Controls.Add(this.cmbDirector);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnEditActress);
			this.Controls.Add(this.cmbActress);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnEditActor);
			this.Controls.Add(this.cmbActor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbMovieName);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmMovieInfo";
			this.Text = "Update Movie Information";
			((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
}
