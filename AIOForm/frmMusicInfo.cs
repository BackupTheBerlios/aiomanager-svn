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
	/// Summary description for frmMusicInfo.
	/// </summary>
	public class frmMusicInfo : System.Windows.Forms.Form
	{
		private AIOForm.frmCommonInfo frmCommonInfo1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button btnApllyMusicInfo;
		private System.Windows.Forms.Button btnClearMusicInfo;
		private System.Windows.Forms.Button btnUpdateMusicInfo;
		private System.Windows.Forms.Button btnEditArtist;
		private System.Windows.Forms.ComboBox cmbArtist;
		private System.Windows.Forms.ComboBox cmbAlbum;
		private System.Windows.Forms.Button btnEditAlbum;
		private System.Windows.Forms.Label lblLength;
		private System.Windows.Forms.Label lblBitrate;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblFileType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private AIODatabase aioDb;
		private DataTable DTAlbum;
		private DataTable DTArtist;
		private AIOMusic music;
		private System.Windows.Forms.Button btnCloseMusicInfo;
		private AIOMusicController musicControler;

		public frmMusicInfo( AIODatabase aioDb, AIOMusicController controller, string ID )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.aioDb = aioDb;
			this.musicControler = ( AIOMusicController )controller;
			this.music = ( AIOMusic )this.musicControler.Select( ID );

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void loadData()
		{
			cmbAlbum.DisplayMember = AIOConstant.GetColumnName( AIOSubInfoType.MUSIC_ALBUM );
			cmbAlbum.ValueMember = "ID";

			cmbArtist.DisplayMember = AIOConstant.GetColumnName( AIOSubInfoType.MUSIC_ARTIST );
			cmbArtist.ValueMember = "ID";

			reloadAlbum();
			reloadArtist();
		}

		public void reloadAlbum()
		{
			DTAlbum = aioDb.GetAllName( AIOSubInfoType.MUSIC_ALBUM );
			cmbAlbum.DataSource = DTAlbum;
		}

		public void reloadArtist()
		{
			DTArtist = aioDb.GetAllName( AIOSubInfoType.MUSIC_ARTIST );
			cmbArtist.DataSource = DTArtist;
		}

		public void loadDetails()
		{
			frmCommonInfo1.LoadDetails( music );

			if ( !music.album.Equals( "" ) )
			{
				cmbAlbum.SelectedValue = music.album;
			}
			if ( !music.artist.Equals( "" ) )
			{
				cmbArtist.SelectedValue = music.artist;
			}
		}

		public void clearInfo()
		{
			frmCommonInfo1.Clear();
			cmbArtist.SelectedIndex = 0;
			cmbAlbum.SelectedIndex = 0;
			lblLength.Text = "";
			lblBitrate.Text = "";
			lblSize.Text = "";
			lblFileType.Text = "";
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
			this.btnApllyMusicInfo = new System.Windows.Forms.Button();
			this.btnCloseMusicInfo = new System.Windows.Forms.Button();
			this.btnClearMusicInfo = new System.Windows.Forms.Button();
			this.btnUpdateMusicInfo = new System.Windows.Forms.Button();
			this.btnEditArtist = new System.Windows.Forms.Button();
			this.cmbArtist = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbAlbum = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEditAlbum = new System.Windows.Forms.Button();
			this.lblLength = new System.Windows.Forms.Label();
			this.lblBitrate = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblFileType = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnApllyMusicInfo
			// 
			this.btnApllyMusicInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnApllyMusicInfo.Location = new System.Drawing.Point(304, 312);
			this.btnApllyMusicInfo.Name = "btnApllyMusicInfo";
			this.btnApllyMusicInfo.Size = new System.Drawing.Size(104, 32);
			this.btnApllyMusicInfo.TabIndex = 42;
			this.btnApllyMusicInfo.Text = "Apply";
			// 
			// btnCloseMusicInfo
			// 
			this.btnCloseMusicInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCloseMusicInfo.Location = new System.Drawing.Point(416, 312);
			this.btnCloseMusicInfo.Name = "btnCloseMusicInfo";
			this.btnCloseMusicInfo.Size = new System.Drawing.Size(104, 32);
			this.btnCloseMusicInfo.TabIndex = 41;
			this.btnCloseMusicInfo.Text = "Close";
			this.btnCloseMusicInfo.Click += new System.EventHandler(this.btnCloseMusicInfo_Click);
			// 
			// btnClearMusicInfo
			// 
			this.btnClearMusicInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClearMusicInfo.Location = new System.Drawing.Point(120, 312);
			this.btnClearMusicInfo.Name = "btnClearMusicInfo";
			this.btnClearMusicInfo.Size = new System.Drawing.Size(104, 32);
			this.btnClearMusicInfo.TabIndex = 40;
			this.btnClearMusicInfo.Text = "Clear";
			this.btnClearMusicInfo.Click += new System.EventHandler(this.btnClearMusicInfo_Click);
			// 
			// btnUpdateMusicInfo
			// 
			this.btnUpdateMusicInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdateMusicInfo.Location = new System.Drawing.Point(8, 312);
			this.btnUpdateMusicInfo.Name = "btnUpdateMusicInfo";
			this.btnUpdateMusicInfo.Size = new System.Drawing.Size(104, 32);
			this.btnUpdateMusicInfo.TabIndex = 39;
			this.btnUpdateMusicInfo.Text = "Update";
			this.btnUpdateMusicInfo.Click += new System.EventHandler(this.btnUpdateMusicInfo_Click);
			// 
			// btnEditArtist
			// 
			this.btnEditArtist.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditArtist.Location = new System.Drawing.Point(464, 40);
			this.btnEditArtist.Name = "btnEditArtist";
			this.btnEditArtist.Size = new System.Drawing.Size(56, 24);
			this.btnEditArtist.TabIndex = 32;
			this.btnEditArtist.Text = "Edit";
			this.btnEditArtist.Click += new System.EventHandler(this.btnEditArtist_Click);
			// 
			// cmbArtist
			// 
			this.cmbArtist.Location = new System.Drawing.Point(64, 40);
			this.cmbArtist.Name = "cmbArtist";
			this.cmbArtist.Size = new System.Drawing.Size(392, 24);
			this.cmbArtist.TabIndex = 31;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 30;
			this.label4.Text = "Artist";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 27;
			this.label3.Text = "BitRate";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "Length";
			// 
			// cmbAlbum
			// 
			this.cmbAlbum.Location = new System.Drawing.Point(64, 8);
			this.cmbAlbum.Name = "cmbAlbum";
			this.cmbAlbum.Size = new System.Drawing.Size(392, 24);
			this.cmbAlbum.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 24);
			this.label1.TabIndex = 22;
			this.label1.Text = "Album";
			// 
			// btnEditAlbum
			// 
			this.btnEditAlbum.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditAlbum.Location = new System.Drawing.Point(464, 8);
			this.btnEditAlbum.Name = "btnEditAlbum";
			this.btnEditAlbum.Size = new System.Drawing.Size(56, 24);
			this.btnEditAlbum.TabIndex = 43;
			this.btnEditAlbum.Text = "Edit";
			this.btnEditAlbum.Click += new System.EventHandler(this.btnEditAlbum_Click);
			// 
			// lblLength
			// 
			this.lblLength.Location = new System.Drawing.Point(64, 80);
			this.lblLength.Name = "lblLength";
			this.lblLength.Size = new System.Drawing.Size(32, 16);
			this.lblLength.TabIndex = 44;
			this.lblLength.Text = "5:00";
			// 
			// lblBitrate
			// 
			this.lblBitrate.Location = new System.Drawing.Point(64, 112);
			this.lblBitrate.Name = "lblBitrate";
			this.lblBitrate.Size = new System.Drawing.Size(56, 16);
			this.lblBitrate.TabIndex = 45;
			this.lblBitrate.Text = "128 kps";
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(424, 112);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(56, 16);
			this.lblSize.TabIndex = 49;
			this.lblSize.Text = "5 MB";
			// 
			// lblFileType
			// 
			this.lblFileType.Location = new System.Drawing.Point(424, 80);
			this.lblFileType.Name = "lblFileType";
			this.lblFileType.Size = new System.Drawing.Size(32, 16);
			this.lblFileType.TabIndex = 48;
			this.lblFileType.Text = "MP3";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(328, 80);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 16);
			this.label9.TabIndex = 47;
			this.label9.Text = "Extension";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(328, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 16);
			this.label10.TabIndex = 46;
			this.label10.Text = "Size";
			// 
			// frmMusicInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(528, 354);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.lblFileType);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.lblBitrate);
			this.Controls.Add(this.lblLength);
			this.Controls.Add(this.btnEditAlbum);
			this.Controls.Add(this.btnApllyMusicInfo);
			this.Controls.Add(this.btnCloseMusicInfo);
			this.Controls.Add(this.btnClearMusicInfo);
			this.Controls.Add(this.btnUpdateMusicInfo);
			this.Controls.Add(this.btnEditArtist);
			this.Controls.Add(this.cmbArtist);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbAlbum);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmMusicInfo";
			this.Text = "Update Music Information";
			this.Load += new System.EventHandler(this.frmMusicInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnEditAlbum_Click(object sender, System.EventArgs e)
		{
			frmSubInfo subInfo = new frmSubInfo( AIOSubInfoType.MUSIC_ALBUM, aioDb );
			subInfo.ShowDialog();
			reloadAlbum();
		}

		private void btnEditArtist_Click(object sender, System.EventArgs e)
		{
			frmSubInfo subInfo = new frmSubInfo( AIOSubInfoType.MUSIC_ARTIST, aioDb );
			subInfo.ShowDialog();
			reloadArtist();
		}

		private void frmMusicInfo_Load(object sender, System.EventArgs e)
		{
			loadData();
			loadDetails();
		}

		private void btnClearMusicInfo_Click(object sender, System.EventArgs e)
		{
			clearInfo();
		}

		private void btnCloseMusicInfo_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnUpdateMusicInfo_Click(object sender, System.EventArgs e)
		{
			frmCommonInfo1.GetCommonInfo2( music );
			music.album = cmbAlbum.SelectedValue.ToString();
			music.artist = cmbArtist.SelectedValue.ToString();
			musicControler.UpdateInfo( music );
		}
	}
}
