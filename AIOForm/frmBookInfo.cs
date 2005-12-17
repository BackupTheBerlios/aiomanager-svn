using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using AIOCommon;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmBookInfo.
	/// </summary>
	public class frmBookInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btnEditGenre;
		private System.Windows.Forms.Button btnEditPublisher;
		private System.Windows.Forms.Button btnEditAuthor;
		private System.Windows.Forms.ComboBox cboTitle;
		private System.Windows.Forms.ComboBox cboGenre;
		private System.Windows.Forms.ComboBox cboPublisher;
		private System.Windows.Forms.ComboBox cboAuthor;
		private System.Windows.Forms.NumericUpDown udYear;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//Database
		private AIODatabase aioDb;
		//Tables
		private DataTable tableAuthor;
		private DataTable tableGenre;
		private System.Windows.Forms.Button btnClose;
		private DataTable tablePublisher;

		//data
        private AIOBook book;
		private AIOForm.frmCommonInfo commonInfo;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.PictureBox picCover;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Label lblUpdate;		
		//Controller;
		private AIOBookController controller;
		
		public frmBookInfo(AIODatabase aioDb, AIOCommonController controller, string ID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.aioDb = aioDb;
			this.controller = (AIOBookController)controller;
			this.book = (AIOBook)this.controller.Select(ID);

			//Init for udYear
			udYear.Maximum = DateTime.Now.Year;
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
			this.label1 = new System.Windows.Forms.Label();
			this.cboTitle = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboGenre = new System.Windows.Forms.ComboBox();
			this.btnEditGenre = new System.Windows.Forms.Button();
			this.btnEditPublisher = new System.Windows.Forms.Button();
			this.cboPublisher = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnEditAuthor = new System.Windows.Forms.Button();
			this.cboAuthor = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.udYear = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.picCover = new System.Windows.Forms.PictureBox();
			this.button4 = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.commonInfo = new AIOForm.frmCommonInfo();
			this.lblUpdate = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.udYear)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Title";
			// 
			// cboTitle
			// 
			this.cboTitle.Location = new System.Drawing.Point(64, 8);
			this.cboTitle.MaxLength = 255;
			this.cboTitle.Name = "cboTitle";
			this.cboTitle.Size = new System.Drawing.Size(456, 24);
			this.cboTitle.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Genre";
			// 
			// cboGenre
			// 
			this.cboGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGenre.Location = new System.Drawing.Point(64, 72);
			this.cboGenre.Name = "cboGenre";
			this.cboGenre.Size = new System.Drawing.Size(120, 24);
			this.cboGenre.TabIndex = 4;
			// 
			// btnEditGenre
			// 
			this.btnEditGenre.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditGenre.Location = new System.Drawing.Point(192, 72);
			this.btnEditGenre.Name = "btnEditGenre";
			this.btnEditGenre.Size = new System.Drawing.Size(56, 24);
			this.btnEditGenre.TabIndex = 5;
			this.btnEditGenre.Text = "Edit";
			this.btnEditGenre.Click += new System.EventHandler(this.btnEditGenre_Click);
			// 
			// btnEditPublisher
			// 
			this.btnEditPublisher.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditPublisher.Location = new System.Drawing.Point(192, 104);
			this.btnEditPublisher.Name = "btnEditPublisher";
			this.btnEditPublisher.Size = new System.Drawing.Size(56, 24);
			this.btnEditPublisher.TabIndex = 8;
			this.btnEditPublisher.Text = "Edit";
			this.btnEditPublisher.Click += new System.EventHandler(this.btnEditPublisher_Click);
			// 
			// cboPublisher
			// 
			this.cboPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPublisher.Location = new System.Drawing.Point(64, 104);
			this.cboPublisher.Name = "cboPublisher";
			this.cboPublisher.Size = new System.Drawing.Size(120, 24);
			this.cboPublisher.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Publisher";
			// 
			// btnEditAuthor
			// 
			this.btnEditAuthor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditAuthor.Location = new System.Drawing.Point(464, 40);
			this.btnEditAuthor.Name = "btnEditAuthor";
			this.btnEditAuthor.Size = new System.Drawing.Size(56, 24);
			this.btnEditAuthor.TabIndex = 11;
			this.btnEditAuthor.Text = "Edit";
			this.btnEditAuthor.Click += new System.EventHandler(this.btnEditAuthor_Click);
			// 
			// cboAuthor
			// 
			this.cboAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAuthor.Location = new System.Drawing.Point(64, 40);
			this.cboAuthor.Name = "cboAuthor";
			this.cboAuthor.Size = new System.Drawing.Size(392, 24);
			this.cboAuthor.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Author";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Year";
			// 
			// udYear
			// 
			this.udYear.Location = new System.Drawing.Point(64, 136);
			this.udYear.Maximum = new System.Decimal(new int[] {
																   2999,
																   0,
																   0,
																   0});
			this.udYear.Minimum = new System.Decimal(new int[] {
																   1900,
																   0,
																   0,
																   0});
			this.udYear.Name = "udYear";
			this.udYear.TabIndex = 13;
			this.udYear.Value = new System.Decimal(new int[] {
																 2005,
																 0,
																 0,
																 0});
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(344, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 14;
			this.label6.Text = "Cover";
			// 
			// picCover
			// 
			this.picCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picCover.Location = new System.Drawing.Point(392, 72);
			this.picCover.Name = "picCover";
			this.picCover.Size = new System.Drawing.Size(128, 152);
			this.picCover.TabIndex = 15;
			this.picCover.TabStop = false;
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(344, 96);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(40, 24);
			this.button4.TabIndex = 16;
			this.button4.Text = "...";
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(8, 424);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(104, 32);
			this.btnUpdate.TabIndex = 18;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClear.Location = new System.Drawing.Point(120, 424);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(104, 32);
			this.btnClear.TabIndex = 19;
			this.btnClear.Text = "Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(416, 424);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(104, 32);
			this.btnClose.TabIndex = 20;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// commonInfo
			// 
			this.commonInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.commonInfo.Location = new System.Drawing.Point(8, 232);
			this.commonInfo.Name = "commonInfo";
			this.commonInfo.Size = new System.Drawing.Size(512, 168);
			this.commonInfo.TabIndex = 21;
			// 
			// lblUpdate
			// 
			this.lblUpdate.ForeColor = System.Drawing.Color.Firebrick;
			this.lblUpdate.Location = new System.Drawing.Point(232, 400);
			this.lblUpdate.Name = "lblUpdate";
			this.lblUpdate.Size = new System.Drawing.Size(296, 24);
			this.lblUpdate.TabIndex = 22;
			this.lblUpdate.Text = "Remember to UPDATE before close this window.";
			this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblUpdate.Click += new System.EventHandler(this.lblUpdate_Click);
			// 
			// frmBookInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(528, 460);
			this.Controls.Add(this.lblUpdate);
			this.Controls.Add(this.commonInfo);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.picCover);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.udYear);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnEditAuthor);
			this.Controls.Add(this.cboAuthor);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnEditPublisher);
			this.Controls.Add(this.cboPublisher);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnEditGenre);
			this.Controls.Add(this.cboGenre);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cboTitle);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBookInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update Book Information";
			this.Load += new System.EventHandler(this.frmBookInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.udYear)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void LoadData() 
		{
			cboAuthor.DisplayMember = AIOConstant.GetColumnName(AIOSubInfoType.BOOK_AUTHOR);
			cboAuthor.ValueMember = "ID";

			cboGenre.DisplayMember = AIOConstant.GetColumnName(AIOSubInfoType.BOOK_GENRE);
			cboGenre.ValueMember = "ID";

			cboPublisher.DisplayMember = AIOConstant.GetColumnName(AIOSubInfoType.BOOK_PUBLISHER);
			cboPublisher.ValueMember = "ID";

			ReloadAuthor();
			ReloadGenre();
			ReloadPublisher();
		}

		private void ReloadAuthor() 
		{
			tableAuthor = aioDb.GetAllName(AIOSubInfoType.BOOK_AUTHOR);			
			cboAuthor.DataSource = tableAuthor;	
		}

		private void ReloadGenre() 
		{
			tableGenre = aioDb.GetAllName(AIOSubInfoType.BOOK_GENRE);			
			cboGenre.DataSource = tableGenre;						
		}

		private void ReloadPublisher() 
		{
			tablePublisher = aioDb.GetAllName(AIOSubInfoType.BOOK_PUBLISHER);			
			cboPublisher.DataSource = tablePublisher;								
		}

		private void LoadDetails() 
		{
			commonInfo.LoadDetails(book);

			cboTitle.Text = book.title;

			if (book.authorID.Equals("") == false)
				cboAuthor.SelectedValue = book.authorID;
			if (book.genreID.Equals("") == false)
				cboGenre.SelectedValue = book.genreID;
			if (book.publisherID.Equals("") == false)
				cboPublisher.SelectedValue = book.publisherID;

			if (book.year >= udYear.Minimum && book.year <= udYear.Maximum)
				udYear.Value = book.year;
			else udYear.Value = DateTime.Now.Year;
		}

		//-------------------Event handler------------------------------
		private void btnEditAuthor_Click(object sender, System.EventArgs e)
		{
			frmSubInfo subInfo = new frmSubInfo(AIOSubInfoType.BOOK_AUTHOR, aioDb);
			subInfo.ShowDialog();
			ReloadAuthor();
		}

		private void btnEditGenre_Click(object sender, System.EventArgs e)
		{
			frmSubInfo subInfo = new frmSubInfo(AIOSubInfoType.BOOK_GENRE, aioDb);
			subInfo.ShowDialog();
			ReloadGenre();
		}

		private void btnEditPublisher_Click(object sender, System.EventArgs e)
		{
			frmSubInfo subInfo = new frmSubInfo(AIOSubInfoType.BOOK_PUBLISHER, aioDb);
			subInfo.ShowDialog();
			ReloadPublisher();
		}

		private void frmBookInfo_Load(object sender, System.EventArgs e)
		{
			LoadData();
			LoadDetails();
		}

		private void Clear() 
		{
			//Clear common info
			commonInfo.Clear();

			//Clear the boxes
			cboTitle.Text = "";
			cboAuthor.SelectedIndex = 0;
			cboGenre.SelectedIndex = 0;
			cboPublisher.SelectedIndex = 0;
			udYear.Value = DateTime.Now.Year;			
		}

		//Event handler---------------------------------------------
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//ID already available
			//Get common info from the CommonInfo usercontrol
			commonInfo.GetCommonInfo2(book);
			//Extends to book info
			book.title = cboTitle.Text.Trim();
			book.authorID = cboAuthor.SelectedValue.ToString();
			book.genreID = cboGenre.SelectedValue.ToString();
			book.publisherID = cboPublisher.SelectedValue.ToString();
			book.year = (int)udYear.Value;
			book.cover = Encoding.UTF8.GetBytes("(No cover)");

			//Update it
			controller.UpdateInfo(book);			
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Clear();
		}

		private void lblUpdate_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
