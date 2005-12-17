using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using AIOCommon;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmAIOMain.
	/// </summary>
	public class frmAIOMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuEdit;
		private System.Windows.Forms.MenuItem mnuView;
		private System.Windows.Forms.MenuItem mnuReport;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuImportResources;
		private System.Windows.Forms.MenuItem mnuSave;
		private System.Windows.Forms.MenuItem mnuPageSetup;
		private System.Windows.Forms.MenuItem mnuPrintPreview;
		private System.Windows.Forms.MenuItem mnuPrint;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem mnuChangeModule;
		private System.Windows.Forms.MenuItem mnuDash;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem mnuCut;
		private System.Windows.Forms.MenuItem mnuCopy;
		private System.Windows.Forms.MenuItem mnuPaste;
		private System.Windows.Forms.MenuItem mnuDelete;
		private System.Windows.Forms.MenuItem mnuSelectAll;
		private System.Windows.Forms.MenuItem mnuSearch;
		private System.Windows.Forms.MenuItem mnuSynchronize;
		private System.Windows.Forms.MenuItem mnuOpenExecute;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuViewBy;
		private System.Windows.Forms.MenuItem mnuLog;
		private System.Windows.Forms.MenuItem mnuViewCustom;
		private System.Windows.Forms.MenuItem mnuReportBy;
		private System.Windows.Forms.MenuItem mnuReportCustom;
		private System.Windows.Forms.MenuItem mnuPreferences;
		private System.Windows.Forms.MenuItem mnuGettingStarted;
		private System.Windows.Forms.MenuItem mnuAbout;
		private System.Windows.Forms.PictureBox picModule;
		private System.Windows.Forms.ToolBar toolbarMain;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem mnuLanguage;
		private System.Windows.Forms.MenuItem mnuLangEng;
		private System.Windows.Forms.MenuItem mnuLangViet;
		private System.Windows.Forms.ToolBarButton toolBarButton7;
		private System.Windows.Forms.ToolBarButton toolBarButton5;
		private System.Windows.Forms.Panel panelContent;
		private AIOUserControls.LogicalExplorer logicalExplorer1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBarButton btnImport;
		private System.Windows.Forms.ToolBarButton btnSynchronize;
		private System.Windows.Forms.ToolBarButton btnSearch;
		private System.Windows.Forms.ToolBarButton btnView;
		private System.Windows.Forms.ToolBarButton btnHelp;
		private System.Windows.Forms.ToolBarButton btnPreferences;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button button2;

		//Tree
		private AIOFolderTree tree;
		//Database
		private AIODatabase aioDb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSize;

		//Current Module
		private AIOModule curModule = AIOModule.MODULE_BOOK;

		//Controller
		private AIOCommonController controller;

		public frmAIOMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			tree = new AIOFolderTree();		

			aioDb = new AIODatabase();
			aioDb.ConnectToDB(DatabaseType.Access, "AIOManager.mdb");

			//Choose a controller
			switch (curModule) 
			{
				case AIOModule.MODULE_BOOK:
					controller = new AIOBookController(aioDb);
					break;
			}

			tree.CreateRoot(AIOConstant.GetModuleName(curModule));
			tree.AioDatabase = aioDb;
			tree.Controller = controller;
			logicalExplorer1.SetTree(tree);
			logicalExplorer1.AioDatabase = aioDb;
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
				//Cleanup
				aioDb.DisconnectDB();
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAIOMain));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuImportResources = new System.Windows.Forms.MenuItem();
			this.mnuSave = new System.Windows.Forms.MenuItem();
			this.mnuDash = new System.Windows.Forms.MenuItem();
			this.mnuChangeModule = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuPageSetup = new System.Windows.Forms.MenuItem();
			this.mnuPrintPreview = new System.Windows.Forms.MenuItem();
			this.mnuPrint = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuEdit = new System.Windows.Forms.MenuItem();
			this.mnuCut = new System.Windows.Forms.MenuItem();
			this.mnuCopy = new System.Windows.Forms.MenuItem();
			this.mnuPaste = new System.Windows.Forms.MenuItem();
			this.mnuDelete = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuSelectAll = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mnuSearch = new System.Windows.Forms.MenuItem();
			this.mnuSynchronize = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuOpenExecute = new System.Windows.Forms.MenuItem();
			this.mnuView = new System.Windows.Forms.MenuItem();
			this.mnuViewBy = new System.Windows.Forms.MenuItem();
			this.mnuViewCustom = new System.Windows.Forms.MenuItem();
			this.mnuLog = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.mnuLanguage = new System.Windows.Forms.MenuItem();
			this.mnuLangEng = new System.Windows.Forms.MenuItem();
			this.mnuLangViet = new System.Windows.Forms.MenuItem();
			this.mnuReport = new System.Windows.Forms.MenuItem();
			this.mnuReportBy = new System.Windows.Forms.MenuItem();
			this.mnuReportCustom = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuPreferences = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuGettingStarted = new System.Windows.Forms.MenuItem();
			this.mnuAbout = new System.Windows.Forms.MenuItem();
			this.toolbarMain = new System.Windows.Forms.ToolBar();
			this.btnImport = new System.Windows.Forms.ToolBarButton();
			this.btnSynchronize = new System.Windows.Forms.ToolBarButton();
			this.btnSearch = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
			this.btnView = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.btnPreferences = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.btnHelp = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.picModule = new System.Windows.Forms.PictureBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.panelContent = new System.Windows.Forms.Panel();
			this.logicalExplorer1 = new AIOUserControls.LogicalExplorer();
			this.label1 = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			this.panelContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuFile,
																					 this.mnuEdit,
																					 this.mnuView,
																					 this.mnuReport,
																					 this.mnuOptions,
																					 this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuImportResources,
																					this.mnuSave,
																					this.mnuDash,
																					this.mnuChangeModule,
																					this.menuItem1,
																					this.mnuPageSetup,
																					this.mnuPrintPreview,
																					this.mnuPrint,
																					this.menuItem2,
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuImportResources
			// 
			this.mnuImportResources.Index = 0;
			this.mnuImportResources.Text = "Import Resources...";
			this.mnuImportResources.Click += new System.EventHandler(this.mnuImportResources_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.Index = 1;
			this.mnuSave.Text = "Save";
			// 
			// mnuDash
			// 
			this.mnuDash.Index = 2;
			this.mnuDash.Text = "-";
			// 
			// mnuChangeModule
			// 
			this.mnuChangeModule.Index = 3;
			this.mnuChangeModule.Text = "Change Module...";
			this.mnuChangeModule.Click += new System.EventHandler(this.mnuChangeModule_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// mnuPageSetup
			// 
			this.mnuPageSetup.Index = 5;
			this.mnuPageSetup.Text = "Page Setup...";
			// 
			// mnuPrintPreview
			// 
			this.mnuPrintPreview.Index = 6;
			this.mnuPrintPreview.Text = "Print Preview";
			// 
			// mnuPrint
			// 
			this.mnuPrint.Index = 7;
			this.mnuPrint.Text = "Print";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 8;
			this.menuItem2.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 9;
			this.mnuExit.Text = "Exit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.Index = 1;
			this.mnuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuCut,
																					this.mnuCopy,
																					this.mnuPaste,
																					this.mnuDelete,
																					this.menuItem3,
																					this.mnuSelectAll,
																					this.menuItem4,
																					this.mnuSearch,
																					this.mnuSynchronize,
																					this.menuItem5,
																					this.mnuOpenExecute});
			this.mnuEdit.Text = "&Edit";
			// 
			// mnuCut
			// 
			this.mnuCut.Index = 0;
			this.mnuCut.Text = "Cut";
			// 
			// mnuCopy
			// 
			this.mnuCopy.Index = 1;
			this.mnuCopy.Text = "Copy";
			// 
			// mnuPaste
			// 
			this.mnuPaste.Index = 2;
			this.mnuPaste.Text = "Paste";
			// 
			// mnuDelete
			// 
			this.mnuDelete.Index = 3;
			this.mnuDelete.Text = "Delete";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 4;
			this.menuItem3.Text = "-";
			// 
			// mnuSelectAll
			// 
			this.mnuSelectAll.Index = 5;
			this.mnuSelectAll.Text = "Select All";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 6;
			this.menuItem4.Text = "-";
			// 
			// mnuSearch
			// 
			this.mnuSearch.Index = 7;
			this.mnuSearch.Text = "Search...";
			this.mnuSearch.Click += new System.EventHandler(this.mnuSearch_Click);
			// 
			// mnuSynchronize
			// 
			this.mnuSynchronize.Index = 8;
			this.mnuSynchronize.Text = "Synchronize...";
			this.mnuSynchronize.Click += new System.EventHandler(this.mnuSynchronize_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 9;
			this.menuItem5.Text = "-";
			// 
			// mnuOpenExecute
			// 
			this.mnuOpenExecute.Index = 10;
			this.mnuOpenExecute.Text = "Open/Execute";
			// 
			// mnuView
			// 
			this.mnuView.Index = 2;
			this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuViewBy,
																					this.mnuLog,
																					this.menuItem6,
																					this.mnuLanguage});
			this.mnuView.Text = "&View";
			// 
			// mnuViewBy
			// 
			this.mnuViewBy.Index = 0;
			this.mnuViewBy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuViewCustom});
			this.mnuViewBy.Text = "View By";
			// 
			// mnuViewCustom
			// 
			this.mnuViewCustom.Checked = true;
			this.mnuViewCustom.Index = 0;
			this.mnuViewCustom.Text = "Custom...";
			// 
			// mnuLog
			// 
			this.mnuLog.Index = 1;
			this.mnuLog.Text = "Log";
			this.mnuLog.Click += new System.EventHandler(this.mnuLog_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.Text = "-";
			// 
			// mnuLanguage
			// 
			this.mnuLanguage.Index = 3;
			this.mnuLanguage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuLangEng,
																						this.mnuLangViet});
			this.mnuLanguage.Text = "Language";
			// 
			// mnuLangEng
			// 
			this.mnuLangEng.Checked = true;
			this.mnuLangEng.Index = 0;
			this.mnuLangEng.Text = "English";
			// 
			// mnuLangViet
			// 
			this.mnuLangViet.Index = 1;
			this.mnuLangViet.Text = "Vietnamese";
			// 
			// mnuReport
			// 
			this.mnuReport.Index = 3;
			this.mnuReport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuReportBy});
			this.mnuReport.Text = "&Report";
			// 
			// mnuReportBy
			// 
			this.mnuReportBy.Index = 0;
			this.mnuReportBy.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuReportCustom});
			this.mnuReportBy.Text = "Report By";
			// 
			// mnuReportCustom
			// 
			this.mnuReportCustom.Index = 0;
			this.mnuReportCustom.Text = "Custom...";
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 4;
			this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuPreferences});
			this.mnuOptions.Text = "&Options";
			// 
			// mnuPreferences
			// 
			this.mnuPreferences.Index = 0;
			this.mnuPreferences.Text = "Preferences...";
			this.mnuPreferences.Click += new System.EventHandler(this.mnuPreferences_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 5;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuGettingStarted,
																					this.mnuAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuGettingStarted
			// 
			this.mnuGettingStarted.Index = 0;
			this.mnuGettingStarted.Text = "Getting Started";
			this.mnuGettingStarted.Click += new System.EventHandler(this.mnuGettingStarted_Click);
			// 
			// mnuAbout
			// 
			this.mnuAbout.Index = 1;
			this.mnuAbout.Text = "About...";
			this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
			// 
			// toolbarMain
			// 
			this.toolbarMain.AutoSize = false;
			this.toolbarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.btnImport,
																						   this.btnSynchronize,
																						   this.btnSearch,
																						   this.toolBarButton7,
																						   this.btnView,
																						   this.toolBarButton5,
																						   this.btnPreferences,
																						   this.toolBarButton2,
																						   this.btnHelp});
			this.toolbarMain.ButtonSize = new System.Drawing.Size(72, 48);
			this.toolbarMain.DropDownArrows = true;
			this.toolbarMain.ImageList = this.imageList1;
			this.toolbarMain.Location = new System.Drawing.Point(0, 0);
			this.toolbarMain.Name = "toolbarMain";
			this.toolbarMain.ShowToolTips = true;
			this.toolbarMain.Size = new System.Drawing.Size(608, 64);
			this.toolbarMain.TabIndex = 0;
			this.toolbarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolbarMain_ButtonClick);
			// 
			// btnImport
			// 
			this.btnImport.ImageIndex = 0;
			this.btnImport.Text = "Import";
			// 
			// btnSynchronize
			// 
			this.btnSynchronize.ImageIndex = 1;
			this.btnSynchronize.Text = "Synchronize";
			// 
			// btnSearch
			// 
			this.btnSearch.ImageIndex = 2;
			this.btnSearch.Text = "Search";
			// 
			// toolBarButton7
			// 
			this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnView
			// 
			this.btnView.ImageIndex = 4;
			this.btnView.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.btnView.Text = "View";
			// 
			// toolBarButton5
			// 
			this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnPreferences
			// 
			this.btnPreferences.ImageIndex = 5;
			this.btnPreferences.Text = "Preferences";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// btnHelp
			// 
			this.btnHelp.ImageIndex = 3;
			this.btnHelp.Text = "Help";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// picModule
			// 
			this.picModule.BackColor = System.Drawing.Color.White;
			this.picModule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picModule.Location = new System.Drawing.Point(544, 8);
			this.picModule.Name = "picModule";
			this.picModule.Size = new System.Drawing.Size(104, 40);
			this.picModule.TabIndex = 1;
			this.picModule.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tabControl1.HotTrack = true;
			this.tabControl1.Location = new System.Drawing.Point(0, 245);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(608, 104);
			this.tabControl1.TabIndex = 11;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lblSize);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(600, 75);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Details";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(536, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(56, 56);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(480, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(48, 64);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(600, 78);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Preview";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 413);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.statusBarPanel2});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(608, 32);
			this.statusBar1.SizingGrip = false;
			this.statusBar1.TabIndex = 12;
			this.statusBar1.Text = "Ready";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel1.Text = "Ready";
			this.statusBarPanel1.Width = 565;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statusBarPanel2.Text = "100%";
			this.statusBarPanel2.Width = 43;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(400, 424);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(152, 16);
			this.progressBar1.TabIndex = 13;
			this.progressBar1.Visible = false;
			// 
			// panelContent
			// 
			this.panelContent.Controls.Add(this.logicalExplorer1);
			this.panelContent.Controls.Add(this.tabControl1);
			this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContent.Location = new System.Drawing.Point(0, 64);
			this.panelContent.Name = "panelContent";
			this.panelContent.Size = new System.Drawing.Size(608, 349);
			this.panelContent.TabIndex = 14;
			// 
			// logicalExplorer1
			// 
			this.logicalExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logicalExplorer1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.logicalExplorer1.Location = new System.Drawing.Point(0, 0);
			this.logicalExplorer1.Name = "logicalExplorer1";
			this.logicalExplorer1.Size = new System.Drawing.Size(608, 245);
			this.logicalExplorer1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Size";
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(48, 8);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(88, 24);
			this.lblSize.TabIndex = 3;
			// 
			// frmAIOMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(608, 445);
			this.Controls.Add(this.panelContent);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.picModule);
			this.Controls.Add(this.toolbarMain);
			this.Controls.Add(this.statusBar1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Menu = this.mainMenu;
			this.Name = "frmAIOMain";
			this.Text = "ALL in ONE Manager";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAIOMain_Closing);
			this.Load += new System.EventHandler(this.frmAIOMain_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			this.panelContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			//Application.EnableVisualStyles();
			Application.Run(new frmAIOMain());
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		//Features ------------------------------------------------------
		//Import
		public void ImportResources() 
		{
			OpenFileDialog fileDlg = new OpenFileDialog();
			DialogResult result = fileDlg.ShowDialog();
			if (result.Equals(DialogResult.OK)) 
			{
				if (fileDlg.CheckFileExists) 
				{
					string filename = fileDlg.FileName;
					logicalExplorer1.InsertFileIntoSelectedNode(filename);
				}
				else 
				{
					MessageBox.Show("File not exists!");
				}
			}
		}

		public void Synchronize() 
		{			
			//GetSubroot
			AIONode subroot = logicalExplorer1.GetCurrentFolder();

			frmSynchronizeWizard synch = new frmSynchronizeWizard(tree, subroot);
			synch.ShowDialog();
			//logicalExplorer1.SetTree(tree);	
		}

		public void Search() 
		{
			frmSearch search = new frmSearch();
			search.ShowDialog();
		}

		public void ChooseView() 
		{
		}

		public void ShowPreferences() 
		{
			frmOptions options = new frmOptions();
			options.ShowDialog();
		}

		public void ShowHelp() 
		{
			frmHelp help = new frmHelp();
			help.ShowDialog();
		}

		public void ShowAbout() 
		{
			frmAbout about = new frmAbout();
			about.ShowDialog();
		}

		public void ShowLog() 
		{
			frmLogging log = new frmLogging();
			log.ShowDialog();
		}

		public void ChangeModule() 
		{
			frmChangeModule change = new frmChangeModule();
			change.ShowDialog();
		}

		
		//Event-------------------------------------------------------------
		private void mnuImportResources_Click(object sender, System.EventArgs e)
		{
			ImportResources();
		}

		private void toolbarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == toolbarMain.Buttons[0]) //Import
			{
				ImportResources();
			}
			else
			if (e.Button == toolbarMain.Buttons[1]) //Synch
			{
				Synchronize();				
			}
			else
			if (e.Button == toolbarMain.Buttons[2]) //Search
			{
				Search();
			}
			else
			if (e.Button == toolbarMain.Buttons[4]) //View
			{
				ChooseView();
			}
			else
			if (e.Button == toolbarMain.Buttons[6]) //Options
			{
				ShowPreferences();
			}
			else
			if (e.Button == toolbarMain.Buttons[8]) //Help
			{
				ShowHelp();
			}
		}

		//Show Log
		private void mnuLog_Click(object sender, System.EventArgs e)
		{
			ShowLog();
		}

		private void mnuChangeModule_Click(object sender, System.EventArgs e)
		{
			ChangeModule();
		}

		private void mnuSearch_Click(object sender, System.EventArgs e)
		{
			Search();
		}

		private void mnuSynchronize_Click(object sender, System.EventArgs e)
		{
			Synchronize();			
		}

		private void mnuPreferences_Click(object sender, System.EventArgs e)
		{
			ShowPreferences();
		}

		private void mnuAbout_Click(object sender, System.EventArgs e)
		{
			ShowAbout();
		}

		private void mnuGettingStarted_Click(object sender, System.EventArgs e)
		{
			ShowHelp();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			frmCDAddon addon = new frmCDAddon();
			addon.ShowDialog();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			frmMain main = new frmMain();
			main.ShowDialog();
		}


		//----------------------------------------------------------------

		private void LoadTree() 
		{
			//XmlSerializer ser = new XmlSerializer(typeof(AIOFolderTree));
			BinaryFormatter ser = new BinaryFormatter();
			FileStream file = new FileStream("tree.xml", FileMode.OpenOrCreate);
			tree = (AIOFolderTree)ser.Deserialize(file);

			file.Close();
			logicalExplorer1.SetTree(tree);	

		}

		private void SaveTree() 
		{
			//XmlSerializer ser = new XmlSerializer(typeof(AIOFolderTree));
			BinaryFormatter ser = new BinaryFormatter();
			FileStream file = new FileStream("tree.xml", FileMode.OpenOrCreate);
			ser.Serialize(file, tree);
			file.Close();
		}

		private void frmAIOMain_Load(object sender, System.EventArgs e)
		{
			try
			{
				//Clear all old database
				aioDb.ClearAll(curModule);
				//LoadTree();	
				logicalExplorer1.ViewDetailsInfo += new AIOUserControls.LogicalExplorer.ViewDetailsInfoDele(AIOConstant_ViewDetailsInfo);
				logicalExplorer1.EditFileInfo += new AIOUserControls.LogicalExplorer.EditFileInfoDele(logicalExplorer1_EditFileInfo);
			}
			catch (Exception ee) {}
		}

		private void frmAIOMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//SaveTree();
		}

		//ViewDetailsInfo
		private void AIOConstant_ViewDetailsInfo(object[] info)
		{
			//Size
			lblSize.Text = info[0].ToString() + " KB";
		}

		//Call subInfo dialog
		private void logicalExplorer1_EditFileInfo(string ID)
		{
			switch (curModule) 
			{
				case AIOModule.MODULE_BOOK:
					frmBookInfo info = new frmBookInfo(aioDb, controller, ID);
					info.ShowDialog();					
					break;
			}
			
		}
	}
}
