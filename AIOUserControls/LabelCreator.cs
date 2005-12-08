using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace AIOUserControls
{
	/// <summary>
	/// Summary description for LabelCreator.
	/// </summary>
	public class LabelCreator : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private string label;
		public string LabelText 
		{
			get { return label; }
			set { label = value.ToString(); }
		}

		//Radius
		private int r1 = 120; //Ban kinh lon nhat
		private int r2 = 40; //Ban kinh trung binh
		private int r3 = 15; //Ban kinh nho nhat

		private int rr1 = 0;
		private int rr2 = 0;
		private int rr3 = 0;

		//Center
		private int x, y;

		//Pen
		private Pen pen;
		//Brush		
		private PathGradientBrush brushOut;
		private SolidBrush brushCenter;
		private SolidBrush brushIn;
		private SolidBrush brushText;
		//Font
		private Font font;
		
		//Text position (relative from center)
		private int dx, dy;

		//private Graphics g = null;

		private float rate = 0;

		private Color color1;
		private Color color2;
		private Color textColor;
		public Color Color1 
		{
			get {return color1;}
			set {color1 = value;}
		}
		public Color Color2 
		{
			get {return color2;}
			set {color2 = value; CreateBrushOut();}
		}
		public Color TextColor 
		{
			get {return textColor;}
			set {textColor = value; CreateBrushText();}
		}

		//Dpi
		private float dpiX = 0;		

		public LabelCreator()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();		
			this.Width = this.Height;

			//Init center
			x = this.Width / 2;
			y = this.Height / 2;

			//Ti le
			rate = this.Width / r1 / 2;
			UpdateRadius();
			//Pen
			pen = new Pen(Color.Black, 1);

			//Brush
			//Path
			CreateBrushOut();
			
			//Center brush
			brushCenter = new SolidBrush(Color.Gray);

			//Outer brush
			brushIn = new SolidBrush(Color.White);
			
			//Brush Text
			CreateBrushText();

			//Font
			font = new Font("Tahoma", 12);
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
			// LabelCreator
			// 
			this.Name = "LabelCreator";
			this.Size = new System.Drawing.Size(200, 200);

		}
		#endregion

		private void CreateBrushOut() 
		{
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(x-rr1, y-rr1, 2*rr1, 2*rr1);
			brushOut = new PathGradientBrush(path);
			brushOut.CenterColor = color1;
			brushOut.SurroundColors = new Color[] {color2};
			brushOut.CenterPoint = new Point(x, y);
		}

		private void CreateBrushText() 
		{
			brushText = new SolidBrush(textColor);
		}
		public void RenderLabel(Graphics g) 
		{
			if (g == null) return;
			//Ve vong tron lon
			g.FillEllipse(brushOut, x-rr1, y-rr1, 2*rr1, 2*rr1);
			g.DrawEllipse(pen, x-rr1, y-rr1, 2*rr1, 2*rr1);
			//Ve vong tron trung binh
			g.FillEllipse(brushCenter, x-rr2, y-rr2, 2*rr2, 2*rr2);
			g.DrawEllipse(pen, x-rr2, y-rr2, 2*rr2, 2*rr2);
			//Ve vong tron nho nhat
			g.FillEllipse(brushIn, x-rr3, y-rr3, 2*rr3, 2*rr3);	
			g.DrawEllipse(pen, x-rr3, y-rr3, 2*rr3, 2*rr3);	

			//Draw String
			g.DrawString(label, font, brushText, x-rr1/2, y+rr1/2);
		}

		protected override void OnPaint(PaintEventArgs e)
		{			
			//base.OnPaint(e);
			RenderLabel(e.Graphics);

			if (dpiX == 0) 
			{
				dpiX = e.Graphics.DpiX;
				//dpiY = e.Graphics.DpiY;
			}

		}
		
		protected override void OnResize(EventArgs e)
		{
			this.Width = this.Height;
			x = y = this.Width / 2;
			rate = this.Width / r1 / 2;
			//Update rr
			UpdateRadius();
			//Update gradient brush
			CreateBrushOut();

			this.Refresh();
		}

		private void UpdateRadius() 
		{
			//rr1 = (int)(rate * r1);
			rr1 = this.Width / 2;
			rr2 = (int)(rate * r2);
			rr3 = (int)(rate * r3);				
		}

		public void SaveAsJPG(string filename) 
		{			
			float m = 25.4f;
			float w = r1 / m;
			
			Bitmap bmp = new Bitmap((int)(w * dpiX), (int)(w*dpiX));
			//bmp.VerticalResolution
			Graphics g = Graphics.FromImage(bmp);			
			g.PageUnit = GraphicsUnit.Millimeter;
			//Save previous
			int tr1 = rr1;
			int tr2 = rr2;
			int tr3 = rr3;
			int tx = x;			
			rr1 = r1 / 2;
			rr2 = r2 / 2;
			rr3 = r3 / 2;
			x = y = rr1;
			CreateBrushOut();
			RenderLabel(g);			
			bmp.Save(filename);
			//Restore
			rr1 = tr1;
			rr2 = tr2;
			rr3 = tr3;
			x = y = tx;
			CreateBrushOut();
		}				
	}
}
