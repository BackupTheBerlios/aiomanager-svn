using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AIOForm
{
	/// <summary>
	/// Summary description for frmCDAddon.
	/// </summary>
	public class frmCDAddon : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label3;
		private AIOUserControls.LabelCreator labelCreator1;
		private System.Windows.Forms.Button btnSaveAs;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.ComboBox cboLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cboFillChoice;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.Label lblColor2;
		private System.Windows.Forms.Label lblColorText;
		private System.Windows.Forms.Label lblColor2Text;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblTextColor;		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCDAddon()
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button6 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.btnPrint = new System.Windows.Forms.Button();
			this.lblColor = new System.Windows.Forms.Label();
			this.lblColor2Text = new System.Windows.Forms.Label();
			this.lblColorText = new System.Windows.Forms.Label();
			this.btnSaveAs = new System.Windows.Forms.Button();
			this.labelCreator1 = new AIOUserControls.LabelCreator();
			this.cboLabel = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cboFillChoice = new System.Windows.Forms.ComboBox();
			this.lblColor2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblTextColor = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(408, 466);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button6);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button5);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(400, 437);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Burn a CD";
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button6.Location = new System.Drawing.Point(312, 264);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(80, 32);
			this.button6.TabIndex = 1;
			this.button6.Text = "Burn";
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button4.Location = new System.Drawing.Point(8, 264);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 32);
			this.button4.TabIndex = 0;
			this.button4.Text = "Add";
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button5.Location = new System.Drawing.Point(88, 264);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 0;
			this.button5.Text = "Create Folder";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button3);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.comboBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(400, 437);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Create ISO from CD/DVD";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(64, 80);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 32);
			this.button3.TabIndex = 5;
			this.button3.Text = "Create ISO";
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(360, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(32, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "...";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(64, 48);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(288, 23);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Save to";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Drive";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(64, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(328, 24);
			this.comboBox1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.btnPrint);
			this.tabPage3.Controls.Add(this.lblColor);
			this.tabPage3.Controls.Add(this.lblColor2Text);
			this.tabPage3.Controls.Add(this.lblColorText);
			this.tabPage3.Controls.Add(this.btnSaveAs);
			this.tabPage3.Controls.Add(this.labelCreator1);
			this.tabPage3.Controls.Add(this.cboLabel);
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.cboFillChoice);
			this.tabPage3.Controls.Add(this.lblColor2);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.lblTextColor);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(400, 437);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Label";
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnPrint.Location = new System.Drawing.Point(312, 400);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(80, 32);
			this.btnPrint.TabIndex = 2;
			this.btnPrint.Text = "Print";
			// 
			// lblColor
			// 
			this.lblColor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblColor.Location = new System.Drawing.Point(304, 72);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(88, 24);
			this.lblColor.TabIndex = 9;
			this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
			// 
			// lblColor2Text
			// 
			this.lblColor2Text.Location = new System.Drawing.Point(240, 112);
			this.lblColor2Text.Name = "lblColor2Text";
			this.lblColor2Text.Size = new System.Drawing.Size(48, 24);
			this.lblColor2Text.TabIndex = 8;
			this.lblColor2Text.Text = "Color 2";
			// 
			// lblColorText
			// 
			this.lblColorText.Location = new System.Drawing.Point(240, 80);
			this.lblColorText.Name = "lblColorText";
			this.lblColorText.Size = new System.Drawing.Size(48, 24);
			this.lblColorText.TabIndex = 6;
			this.lblColorText.Text = "Color";
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSaveAs.Location = new System.Drawing.Point(8, 400);
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(80, 32);
			this.btnSaveAs.TabIndex = 2;
			this.btnSaveAs.Text = "Save as...";
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// labelCreator1
			// 
			this.labelCreator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCreator1.BackColor = System.Drawing.SystemColors.Control;
			this.labelCreator1.Color1 = System.Drawing.Color.Empty;
			this.labelCreator1.Color2 = System.Drawing.Color.Empty;
			this.labelCreator1.LabelText = "Hello World!";
			this.labelCreator1.Location = new System.Drawing.Point(72, 160);
			this.labelCreator1.Name = "labelCreator1";
			this.labelCreator1.Size = new System.Drawing.Size(256, 256);
			this.labelCreator1.TabIndex = 5;
			this.labelCreator1.TextColor = System.Drawing.Color.Empty;
			// 
			// cboLabel
			// 
			this.cboLabel.Location = new System.Drawing.Point(80, 8);
			this.cboLabel.Name = "cboLabel";
			this.cboLabel.Size = new System.Drawing.Size(312, 24);
			this.cboLabel.TabIndex = 1;
			this.cboLabel.TextChanged += new System.EventHandler(this.cboLabel_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "Label";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(240, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 24);
			this.label5.TabIndex = 0;
			this.label5.Text = "Fill";
			// 
			// cboFillChoice
			// 
			this.cboFillChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFillChoice.Items.AddRange(new object[] {
															   "No Fill",
															   "Color",
															   "Gradient"});
			this.cboFillChoice.Location = new System.Drawing.Point(304, 40);
			this.cboFillChoice.Name = "cboFillChoice";
			this.cboFillChoice.Size = new System.Drawing.Size(88, 24);
			this.cboFillChoice.TabIndex = 1;
			this.cboFillChoice.SelectedIndexChanged += new System.EventHandler(this.cboFillChoice_SelectedIndexChanged);
			// 
			// lblColor2
			// 
			this.lblColor2.BackColor = System.Drawing.Color.IndianRed;
			this.lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblColor2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblColor2.Location = new System.Drawing.Point(304, 104);
			this.lblColor2.Name = "lblColor2";
			this.lblColor2.Size = new System.Drawing.Size(88, 24);
			this.lblColor2.TabIndex = 9;
			this.lblColor2.Click += new System.EventHandler(this.lblColor2_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 24);
			this.label4.TabIndex = 0;
			this.label4.Text = "Preview";
			// 
			// lblTextColor
			// 
			this.lblTextColor.BackColor = System.Drawing.Color.DarkBlue;
			this.lblTextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblTextColor.Location = new System.Drawing.Point(80, 40);
			this.lblTextColor.Name = "lblTextColor";
			this.lblTextColor.Size = new System.Drawing.Size(88, 24);
			this.lblTextColor.TabIndex = 9;
			this.lblTextColor.Click += new System.EventHandler(this.lblTextColor_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 24);
			this.label7.TabIndex = 6;
			this.label7.Text = "Text Color";
			// 
			// frmCDAddon
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
			this.ClientSize = new System.Drawing.Size(408, 466);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmCDAddon";
			this.ShowInTaskbar = false;
			this.Text = "frmCDAddon";
			this.Load += new System.EventHandler(this.frmCDAddon_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog file = new SaveFileDialog();
			file.Filter = "JPEG (*.JPG)|*.JPG|GIF (*.GIF)|*.GIF";			
			DialogResult result = file.ShowDialog();			
			if (result.Equals(DialogResult.OK))
			{
				string filename = file.FileName;
				labelCreator1.SaveAsJPG(filename);
			}			
		}

		private void cboLabel_TextChanged(object sender, System.EventArgs e)
		{
			labelCreator1.LabelText = cboLabel.Text;
			labelCreator1.Refresh();
		}

		//Show color dialog and get a color
		private Color ShowColorDialog() 
		{
			ColorDialog colorDlg = new ColorDialog();			
			DialogResult result = colorDlg.ShowDialog();
			return colorDlg.Color;			
		}
		private void lblColor_Click(object sender, System.EventArgs e)
		{
			Color color = ShowColorDialog();			
			lblColor.BackColor = color;		
			UpdateLabelPic();
		}

		private void lblColor2_Click(object sender, System.EventArgs e)
		{
			Color color = ShowColorDialog();
			lblColor2.BackColor = color;		
			UpdateLabelPic();
		}

		private void cboFillChoice_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int index = cboFillChoice.SelectedIndex;
			if (index == 2) //Fill gradient
			{
				lblColor2.Visible = true;
				lblColor2Text.Visible = true;
			}
			else
			{
				lblColor2.Visible = false;	
				lblColor2Text.Visible = false;
			}
			if (index == 0) 
			{
				lblColor.Visible = false;
				lblColorText.Visible = false;
			}
			else
			{
				lblColor.Visible = true;
				lblColorText.Visible = true;
			}
			UpdateLabelPic();
		}

		private void frmCDAddon_Load(object sender, System.EventArgs e)
		{
			cboFillChoice.SelectedIndex = 1;
			UpdateLabelPic();
		}

		private void btnPreview_Click(object sender, System.EventArgs e)
		{
			
		}

		private void UpdateLabelPic() 
		{
			switch (cboFillChoice.SelectedIndex) 
			{
				case 0: //No Fill
					labelCreator1.Color1 = Color.White;
					labelCreator1.Color2 = Color.White;
					break;
				case 1:	//Solid
					labelCreator1.Color1 = lblColor.BackColor;
					labelCreator1.Color2 = lblColor.BackColor;
					break;
				case 2: //Gradient
					labelCreator1.Color1 = lblColor.BackColor;
					labelCreator1.Color2 = lblColor2.BackColor;
					break;
			}
			labelCreator1.TextColor = lblTextColor.BackColor;
			labelCreator1.Refresh();
		}

		private void lblTextColor_Click(object sender, System.EventArgs e)
		{
			Color color = ShowColorDialog();
			lblTextColor.BackColor = color;		
			UpdateLabelPic();
		}

	}
}
