using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using AIOCommon;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmSynchronizeWizard.
	/// </summary>
	public class frmSynchronizeWizard : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//--------------------------------------------------------
		private ACTIONS action;
		private System.Windows.Forms.RadioButton radCheckSync;
		private System.Windows.Forms.RadioButton radReSync;
		private System.Windows.Forms.RadioButton radSync;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ComboBox cboFolder;
		private System.Windows.Forms.CheckBox chkAdd;
		private System.Windows.Forms.CheckBox chkRecursive;
		private int step = 1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboPattern;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button btnFinish;

		private enum ACTIONS {ACTION_SYNC, ACTION_RESYNC, ACTION_CHECKSYNC};
		
		private AIOFolderTree tree;
		private AIONode subroot;
		private string path;
		private string pattern;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblElapsed;
		private bool bRecursive;

		//Timer
		AccurateTimer timer = new AccurateTimer();
		//AsyncResult
		IAsyncResult result;

		//Thread
		private Thread progressThread;
		private System.Windows.Forms.Label lblPercent;
		private System.Windows.Forms.CheckBox chkDoNotCreateSubCategory;
		private Thread synchThread;

		
		public frmSynchronizeWizard(AIOFolderTree tree2, AIONode subroot)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.tree = tree2;
			this.subroot = subroot;
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

					//Dispose
					MoreDispose();
				}
			}
			base.Dispose( disposing );
		}

		private void MoreDispose() 
		{
			DisposeThread(progressThread);
			DisposeThread(synchThread);
		}

		private void DisposeThread(Thread thread) 
		{
			if (thread != null)
				if (thread.IsAlive) 
				{
					thread.Abort();
					thread = null;
				}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.radCheckSync = new System.Windows.Forms.RadioButton();
			this.radReSync = new System.Windows.Forms.RadioButton();
			this.radSync = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.cboPattern = new System.Windows.Forms.ComboBox();
			this.chkRecursive = new System.Windows.Forms.CheckBox();
			this.chkAdd = new System.Windows.Forms.CheckBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cboFolder = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkDoNotCreateSubCategory = new System.Windows.Forms.CheckBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblElapsed = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label5 = new System.Windows.Forms.Label();
			this.lblPercent = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.btnFinish = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.radCheckSync);
			this.panel1.Controls.Add(this.radReSync);
			this.panel1.Controls.Add(this.radSync);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(128, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(488, 296);
			this.panel1.TabIndex = 0;
			// 
			// radCheckSync
			// 
			this.radCheckSync.Location = new System.Drawing.Point(24, 120);
			this.radCheckSync.Name = "radCheckSync";
			this.radCheckSync.Size = new System.Drawing.Size(304, 24);
			this.radCheckSync.TabIndex = 3;
			this.radCheckSync.Text = "Check synchronization";
			this.radCheckSync.CheckedChanged += new System.EventHandler(this.radCheckSync_CheckedChanged);
			// 
			// radReSync
			// 
			this.radReSync.Location = new System.Drawing.Point(24, 88);
			this.radReSync.Name = "radReSync";
			this.radReSync.Size = new System.Drawing.Size(304, 24);
			this.radReSync.TabIndex = 2;
			this.radReSync.Text = "Resynchronize existing database";
			this.radReSync.CheckedChanged += new System.EventHandler(this.radReSync_CheckedChanged);
			// 
			// radSync
			// 
			this.radSync.Checked = true;
			this.radSync.Location = new System.Drawing.Point(24, 56);
			this.radSync.Name = "radSync";
			this.radSync.Size = new System.Drawing.Size(304, 24);
			this.radSync.TabIndex = 1;
			this.radSync.TabStop = true;
			this.radSync.Text = "Synchronize and import data from disk";
			this.radSync.CheckedChanged += new System.EventHandler(this.radSync_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(440, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please choose an action";
			// 
			// panelLeft
			// 
			this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(120, 296);
			this.panelLeft.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(8, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 32);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnBack
			// 
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBack.Location = new System.Drawing.Point(120, 320);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(88, 32);
			this.btnBack.TabIndex = 3;
			this.btnBack.Text = "Back";
			// 
			// btnNext
			// 
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNext.Location = new System.Drawing.Point(512, 328);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(88, 32);
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "Next";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.cboPattern);
			this.panel2.Controls.Add(this.chkRecursive);
			this.panel2.Controls.Add(this.chkAdd);
			this.panel2.Controls.Add(this.btnBrowse);
			this.panel2.Controls.Add(this.cboFolder);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.chkDoNotCreateSubCategory);
			this.panel2.Location = new System.Drawing.Point(128, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(528, 304);
			this.panel2.TabIndex = 5;
			this.panel2.Visible = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Pattern";
			// 
			// cboPattern
			// 
			this.cboPattern.Location = new System.Drawing.Point(80, 72);
			this.cboPattern.Name = "cboPattern";
			this.cboPattern.Size = new System.Drawing.Size(104, 24);
			this.cboPattern.TabIndex = 5;
			this.cboPattern.Text = "*.*";
			// 
			// chkRecursive
			// 
			this.chkRecursive.Checked = true;
			this.chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRecursive.Location = new System.Drawing.Point(16, 112);
			this.chkRecursive.Name = "chkRecursive";
			this.chkRecursive.Size = new System.Drawing.Size(200, 16);
			this.chkRecursive.TabIndex = 4;
			this.chkRecursive.Text = "Recursive into sub folders";
			// 
			// chkAdd
			// 
			this.chkAdd.Location = new System.Drawing.Point(16, 136);
			this.chkAdd.Name = "chkAdd";
			this.chkAdd.Size = new System.Drawing.Size(192, 24);
			this.chkAdd.TabIndex = 3;
			this.chkAdd.Text = "Add to current collection";
			// 
			// btnBrowse
			// 
			this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowse.Location = new System.Drawing.Point(456, 40);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(24, 24);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// cboFolder
			// 
			this.cboFolder.Location = new System.Drawing.Point(16, 40);
			this.cboFolder.Name = "cboFolder";
			this.cboFolder.Size = new System.Drawing.Size(432, 24);
			this.cboFolder.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(232, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Choose a folder to synchronize with";
			// 
			// chkDoNotCreateSubCategory
			// 
			this.chkDoNotCreateSubCategory.Location = new System.Drawing.Point(16, 168);
			this.chkDoNotCreateSubCategory.Name = "chkDoNotCreateSubCategory";
			this.chkDoNotCreateSubCategory.Size = new System.Drawing.Size(200, 16);
			this.chkDoNotCreateSubCategory.TabIndex = 4;
			this.chkDoNotCreateSubCategory.Text = "Do not create sub categories";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.lblElapsed);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.progressBar);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.lblPercent);
			this.panel3.Location = new System.Drawing.Point(128, 8);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(528, 304);
			this.panel3.TabIndex = 6;
			this.panel3.Visible = false;
			// 
			// lblElapsed
			// 
			this.lblElapsed.Location = new System.Drawing.Point(80, 80);
			this.lblElapsed.Name = "lblElapsed";
			this.lblElapsed.Size = new System.Drawing.Size(240, 16);
			this.lblElapsed.TabIndex = 3;
			this.lblElapsed.Text = "00:00:00";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Elapsed";
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(16, 40);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(392, 24);
			this.progressBar.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(232, 24);
			this.label5.TabIndex = 0;
			this.label5.Text = "Synchronizing";
			// 
			// lblPercent
			// 
			this.lblPercent.Location = new System.Drawing.Point(416, 40);
			this.lblPercent.Name = "lblPercent";
			this.lblPercent.Size = new System.Drawing.Size(56, 24);
			this.lblPercent.TabIndex = 2;
			this.lblPercent.Text = "0%";
			this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.White;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.radioButton1);
			this.panel4.Controls.Add(this.radioButton2);
			this.panel4.Controls.Add(this.radioButton3);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Location = new System.Drawing.Point(144, 8);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(488, 296);
			this.panel4.TabIndex = 0;
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(24, 120);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(304, 24);
			this.radioButton1.TabIndex = 3;
			this.radioButton1.Text = "Check synchronization";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(24, 88);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(304, 24);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Text = "Resynchronize existing database";
			// 
			// radioButton3
			// 
			this.radioButton3.Checked = true;
			this.radioButton3.Location = new System.Drawing.Point(24, 56);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(304, 24);
			this.radioButton3.TabIndex = 1;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Synchronize and import data from disk";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(440, 24);
			this.label6.TabIndex = 0;
			this.label6.Text = "Please choose an action";
			// 
			// btnFinish
			// 
			this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnFinish.Location = new System.Drawing.Point(512, 328);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(88, 32);
			this.btnFinish.TabIndex = 7;
			this.btnFinish.Text = "Finish";
			this.btnFinish.Visible = false;
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// frmSynchronizeWizard
			// 
			this.AcceptButton = this.btnNext;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(608, 370);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.btnFinish);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmSynchronizeWizard";
			this.ShowInTaskbar = false;
			this.Text = "Synchronization";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSynchronizeWizard_Closing);
			this.Load += new System.EventHandler(this.frmSynchronizeWizard_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void radSync_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radSync.Checked)
				action = ACTIONS.ACTION_SYNC;
		}

		private void radReSync_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radReSync.Checked)
				action = ACTIONS.ACTION_RESYNC;
		}

		private void radCheckSync_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radCheckSync.Checked)
				action = ACTIONS.ACTION_CHECKSYNC;
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			step++;
			switch (action) 
			{
				case ACTIONS.ACTION_SYNC:
					ShowPanel(step);
					if (step == 3) //Synchronization
					{
						//Get parameters for synch thread
						path = cboFolder.Text.Trim();
						pattern = cboPattern.Text.Trim();
						bRecursive = chkRecursive.Checked;

						//Progress
						progressBar.Value = 0;

						//Run thread
						if (chkDoNotCreateSubCategory.Checked)
							RunFlattenSynchThread();
						else
							RunSynchThread();						
						
						RunProgressThread();
						
						//Invoke to update GUI
						//progressBar.BeginInvoke(new RunInvoke(UpdateProgress));										
					}
					break;
				case ACTIONS.ACTION_RESYNC:					
					break;
				case ACTIONS.ACTION_CHECKSYNC:
					break;
			}			
		}

		private void ShowPanel(int index) 
		{
			panel1.Visible = false;
			panel2.Visible = false;
			panel3.Visible = false;
			switch (index) 
			{
				case 1:
					panel1.Visible = true;
					break;

				case 2:
					panel2.Visible = true;
					break;

				case 3:
					panel3.Visible = true;
					break;
			}
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result.Equals(DialogResult.OK)) 
			{
				cboFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		//Synchronization Thread-------------------------------------------
		private void RunSynchThread() 
		{
			synchThread = new Thread(new ThreadStart(RunSynch));			
			synchThread.Start();			
		}
		
		private void RunSynch() 
		{			
			//Start timer
			timer.Start();

			tree.Synchronize(path, pattern, bRecursive, subroot);

			//Stop timer
			timer.Stop();
		}
		//Flatten Synchronization Thread
		private void RunFlattenSynchThread() 
		{
			synchThread = new Thread(new ThreadStart(RunFlattenSynch));
			synchThread.Start();
		}

		private void RunFlattenSynch() 
		{
			//Start timer
			timer.Start();

			tree.FlatSynchronize(path, pattern, bRecursive, subroot);													

			//Stop timer
			timer.Stop();
		}
		
		//Update Progress Thread--------------------------------------------
		private void RunProgressThread() 
		{
			progressThread = new Thread(new ThreadStart(RunProgress));
			progressThread.Start();
		}

		private void RunProgress() 
		{			
			do
			{
				lblElapsed.Invoke(new RunInvoke(UpdateProgress));	
				//Wait 100ms
				Thread.Sleep(100);
			}
			while (tree.IsProcessing);
			lblElapsed.Invoke(new RunInvoke(UpdateProgress));	
		}

		private delegate void RunInvoke();
		private void UpdateProgress() 
		{
			if (tree.IsProcessing) 
			{
				if (AIOProgress.progressValue < 100)
					progressBar.Value = AIOProgress.progressValue;
				else progressBar.Value = 100;
			}			
			else	
			{
				//Update Progress bar
				progressBar.Value = 100;				

				//Update button
				btnNext.Visible = false;
				btnFinish.Visible = true;	
			}		
			//Update label Elapsed Time			
			lblElapsed.Text = timer.CurrentDuration.ToString(".## second(s)");
			
			//Percent
			lblPercent.Text = progressBar.Value.ToString("") + "%";
		}

		private void frmSynchronizeWizard_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//Check to see if available to close
			if (tree.IsProcessing) 
			{
				DialogResult result = MessageBox.Show("Are you sure?","Confirmation", MessageBoxButtons.YesNo);
				if (!result.Equals(DialogResult.Yes)) 
				{
					e.Cancel = true;
				}
			}
			
		}

		private void frmSynchronizeWizard_Load(object sender, System.EventArgs e)
		{
			step = 1;
			ShowPanel(step);
		}
	}
}
