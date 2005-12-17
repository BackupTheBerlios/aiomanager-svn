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
	/// Summary description for frmSubInfo.
	/// </summary>
		
	public class frmSubInfo : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;	
		private System.Windows.Forms.ComboBox cboName;
		private System.Windows.Forms.DataGrid gridData;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnAdd;

		//SubInfoType
		private AIOSubInfoType subInfoType;
		
		//Title
		private const int COLUMNS = 1;
		private string title;
		private string [] columnName = new string[COLUMNS];
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;

		//Database
		private AIODatabase aioDb;
		private System.Windows.Forms.DataGridTableStyle tableStyle;
		private System.Windows.Forms.DataGridTextBoxColumn colIDStyle;
		private System.Windows.Forms.DataGridTextBoxColumn colNameStyle;
		//Table
		private DataTable table;

		public frmSubInfo(AIOSubInfoType type, AIODatabase db)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.subInfoType = type;
			this.aioDb = db;
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
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.cboName = new System.Windows.Forms.ComboBox();
			this.lblName = new System.Windows.Forms.Label();
			this.gridData = new System.Windows.Forms.DataGrid();
			this.tableStyle = new System.Windows.Forms.DataGridTableStyle();
			this.colIDStyle = new System.Windows.Forms.DataGridTextBoxColumn();
			this.colNameStyle = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btnAdd = new System.Windows.Forms.Button();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(416, 328);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(104, 32);
			this.btnClose.TabIndex = 62;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDelete.Location = new System.Drawing.Point(168, 328);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(72, 32);
			this.btnDelete.TabIndex = 61;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Location = new System.Drawing.Point(88, 328);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(72, 32);
			this.btnUpdate.TabIndex = 60;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// cboName
			// 
			this.cboName.Location = new System.Drawing.Point(8, 32);
			this.cboName.MaxLength = 255;
			this.cboName.Name = "cboName";
			this.cboName.Size = new System.Drawing.Size(512, 24);
			this.cboName.TabIndex = 44;
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(8, 8);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(160, 16);
			this.lblName.TabIndex = 43;
			this.lblName.Text = "Title";
			// 
			// gridData
			// 
			this.gridData.AlternatingBackColor = System.Drawing.Color.Beige;
			this.gridData.DataMember = "";
			this.gridData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridData.Location = new System.Drawing.Point(8, 64);
			this.gridData.Name = "gridData";
			this.gridData.ReadOnly = true;
			this.gridData.Size = new System.Drawing.Size(512, 256);
			this.gridData.TabIndex = 64;
			this.gridData.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.tableStyle});
			this.gridData.CurrentCellChanged += new System.EventHandler(this.gridData_CurrentCellChanged);
			// 
			// tableStyle
			// 
			this.tableStyle.AlternatingBackColor = System.Drawing.Color.Beige;
			this.tableStyle.DataGrid = this.gridData;
			this.tableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.colIDStyle,
																										 this.colNameStyle});
			this.tableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.tableStyle.MappingName = "";
			this.tableStyle.PreferredRowHeight = 24;
			// 
			// colIDStyle
			// 
			this.colIDStyle.Format = "";
			this.colIDStyle.FormatInfo = null;
			this.colIDStyle.MappingName = "";
			this.colIDStyle.Width = 75;
			// 
			// colNameStyle
			// 
			this.colNameStyle.Format = "";
			this.colNameStyle.FormatInfo = null;
			this.colNameStyle.MappingName = "";
			this.colNameStyle.Width = 200;
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAdd.Location = new System.Drawing.Point(8, 328);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 32);
			this.btnAdd.TabIndex = 65;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.MappingName = "";
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// frmSubInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(528, 370);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.gridData);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.cboName);
			this.Controls.Add(this.lblName);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSubInfo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update Author/Album/Artist... information";
			this.Load += new System.EventHandler(this.frmSubInfo_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void ViewModuleName() 
		{
			switch(subInfoType) 
			{
				case AIOSubInfoType.BOOK_AUTHOR:
					title = "Book Author";					
					columnName[0] = "Author Name";
					break;

				case AIOSubInfoType.BOOK_GENRE:
					title = "Book Genre";					
					columnName[0] = "Genre Name";
					break;

				case AIOSubInfoType.BOOK_PUBLISHER:
					title = "Book Publisher";					
					columnName[0] = "Publisher Name";
					break;

				case AIOSubInfoType.CD_GENRE:
					break;

				case AIOSubInfoType.MOVIE_ACTOR:
					break;

				case AIOSubInfoType.MOVIE_ACTRESS:
					break;

				case AIOSubInfoType.MOVIE_DIRECTOR:
					break;

				case AIOSubInfoType.MUSIC_ALBUM:
					break;

				case AIOSubInfoType.MUSIC_ARTIST:
					break;

				case AIOSubInfoType.PHOTO_ALBUM:
					break;				
			}			

			this.Text = title;
			lblName.Text = columnName[0];
			gridData.CaptionText = columnName[0];
		}

		public void InsertName() 
		{
			string name = cboName.Text.Trim();
			if (aioDb.IsDuplicateName(name, subInfoType) == false)
				aioDb.InsertName(name, subInfoType);
		}

		public void UpdateName() 
		{
			int index = gridData.CurrentRowIndex;
			if (index < 0 || index >= table.Rows.Count) return;

			string ID = table.Rows[index].ItemArray[0].ToString();
			string name = cboName.Text.Trim();

			if (aioDb.IsDuplicateName(name, subInfoType) == false)
				aioDb.UpdateName(ID, name, subInfoType);
		}

		public void DeleteName() 
		{
			int index = gridData.CurrentRowIndex;
			if (index < 0 || index >= table.Rows.Count) return;
			           
			string ID = table.Rows[index].ItemArray[0].ToString();

			//Do not delete the Unknown ID
			int id = Convert.ToInt32(ID);
			if (id <= 1) return;

			//Ask for confirmation
			if (MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes) == false) 
				return;

			//Now can delete anything
			aioDb.DeleteName(ID, subInfoType);
		}

		private void LoadData() 
		{
			//Change styes
			//DataGridTableStyle tableStyle = gridData.TableStyles[0];
			//DataGridColumnStyle colStyle = tableStyle.GridColumnStyles[1];
			//colStyle.Width = 200;
			table = aioDb.GetAllName(subInfoType);
			gridData.DataSource = table;	
			
			//Change some styles
			colIDStyle.MappingName = "ID";
			colIDStyle.HeaderText = "No.";
			colNameStyle.MappingName = AIOConstant.GetColumnName(subInfoType);
			colNameStyle.HeaderText = lblName.Text;
			colNameStyle.Width = 200;

			//Bind to combobox
			cboName.DataSource = table;
			cboName.DisplayMember = AIOConstant.GetColumnName(subInfoType);
			cboName.ValueMember = "ID";
		}

		private void ReloadAll() 
		{
			table = aioDb.GetAllName(subInfoType);
			gridData.DataSource = table;
			cboName.DataSource = table;
		}

		//Events Handler-------------------------------------------------
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			InsertName();
			ReloadAll();
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			UpdateName();
			ReloadAll();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			DeleteName();
			ReloadAll();
		}

		private void frmSubInfo_Load(object sender, System.EventArgs e)
		{
			ViewModuleName();
			LoadData();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void gridData_CurrentCellChanged(object sender, System.EventArgs e)
		{
			int index = gridData.CurrentRowIndex;
			if (index < table.Rows.Count) 
			{
				cboName.Text = table.Rows[index].ItemArray[1].ToString();
			}
		}
	}
}
