using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Resources;

namespace AIOUserControls
{
	/// <summary>
	/// Summary description for RatingField.
	/// </summary>
	public class RatingField : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		private int ratings = 0;
		private int MAX_PARTS = 10;

		private int partWidth = 0;
		private Image imgStar;
		private Image imgStarBlank;

		public int Ratings 
		{
			get {return ratings;}
			set {if (value >= 0 && value <= MAX_PARTS) ratings = value; this.Refresh();}
		}

		public int MaxRatings 
		{
			get {return MAX_PARTS;}
			set {if (value >= 0 && value <= 10) MAX_PARTS = value; this.Refresh();}
		}
        public RatingField()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();			
			// TODO: Add any initialization after the InitializeComponent call			
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// RatingField
			// 
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Name = "RatingField";
			this.Size = new System.Drawing.Size(240, 64);
			this.Resize += new System.EventHandler(this.RatingField_Resize);
			this.Load += new System.EventHandler(this.RatingField_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RatingField_MouseDown);

		}
		#endregion

		private void RatingField_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{	
			if (ratings == 1) 
			{
				ratings = (int)(e.X / partWidth) + 1;		
				if (ratings == 1)
				{
					ratings = 0;
				}
			} 
			else 
			{
				ratings = (int)(e.X / partWidth) + 1;		
			}
			if (ratings > MAX_PARTS) ratings = MAX_PARTS;
			this.Refresh();
		}

		protected override void OnPaint(PaintEventArgs pe) 
		{
			if (imgStar == null) return;
			Graphics g = pe.Graphics;			
			int i = 0;
			for (i = 0;i<ratings;i++) 
			{
				//g.DrawIcon(icon, i*partWidth, 0);
				g.DrawImage(imgStar, new Point(i*partWidth, 0));
			}
			for (i = ratings;i<MAX_PARTS;i++) 
			{
				//Thay doi ha`m ve o day
				g.DrawImage(imgStarBlank, new Point(i*partWidth, 0));
			}
		}

		private void RatingField_Resize(object sender, System.EventArgs e)
		{
			partWidth = (int)(this.Width / MAX_PARTS);
			this.Height = partWidth;
			this.Refresh();
		}

		private void RatingField_Load(object sender, System.EventArgs e)
		{
			ResourceManager resMan = new ResourceManager("AIOUserControls.RatingResource", this.GetType().Assembly);
			this.imgStar = (Image)resMan.GetObject("Star");
			this.imgStarBlank = (Image)resMan.GetObject("StarBlank");
			//this.imgStar = Image.FromFile(@"Star.gif");
			//this.imgStarBlank = Image.FromFile(@"StarBlank.gif");
		}

	}
}
