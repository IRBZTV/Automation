using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MControls
{
    public partial class PictureBoxEx : Control
    {
        public PictureBoxEx()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint , true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

        // http://dotmad.blogspot.com/2007/11/five-steps-for-creating-transparent.html

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        float fRadius = 0;
        public float Radius
        {
            get
            {
                return fRadius;
            }
            set
            {
                fRadius = value;
            }
        }

        float fBorderWidth = 0;
        public float BorderWidth
        {
            get
            {
                return fBorderWidth;
            }
            set
            {
                fBorderWidth = value;
            }
        }

        Color borderColor = Color.Black;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        Image imgDraw = null;
        public Image Image
        {
            get { return imgDraw; }
            set 
            {
                bool bUpdate = false;
                if (imgDraw == null || !imgDraw.Equals(value))
                    bUpdate = true;

                imgDraw = value;

                if (bUpdate)
                    Invalidate();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            return;
        }

        protected override void OnMove(EventArgs e)
        {
            RecreateHandle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if( imgDraw != null )
            {
                Rectangle rcBounds = this.Bounds;
                rcBounds.X = 0;
                rcBounds.Y = 0;

                MHelpers.DrawRoundImage(e.Graphics, Image, rcBounds, fRadius);

                if (BorderWidth > 0 )
                {
                    Pen pen = new Pen(borderColor, fBorderWidth);

                    rcBounds.X += (int)fBorderWidth / 2;
                    rcBounds.Y += (int)fBorderWidth / 2;
                    rcBounds.Width -= rcBounds.X * 2;
                    rcBounds.Height -= rcBounds.Y * 2;

                    MHelpers.DrawRoundRect(e.Graphics, pen, rcBounds, fRadius);
                }
            }

            e.Graphics.Dispose();            
            
        }
    }
}
