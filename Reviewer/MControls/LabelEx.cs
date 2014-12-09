using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
    public partial class LabelEx : Label
    {
        public LabelEx()
        {
            InitializeComponent();
            this.Tag = 0.5;

            m_strTextEx = "";
            m_fontTextEx = this.Font;
            m_ptTextEx = new Point();
        }
        
        public string TextEx
        {
            get
            {
                return m_strTextEx;
            }
            set
            {
                m_strTextEx = value;
            }
        }

        public Font FontEx
        {
            get
            {
                return m_fontTextEx;
            }
            set
            {
                m_fontTextEx = value;
            }
        }

        public Point TextExPos
        {
            get
            {
                return m_ptTextEx;
            }
            set
            {
                m_ptTextEx = value;
            }
        }

        private string  m_strTextEx;
        private Font m_fontTextEx;
        private Point m_ptTextEx;

        Color foreColorGrad = MHelpers.ColorLightBlue;
        public Color ForeColorGrad
        {
            get { return foreColorGrad; }
            set { foreColorGrad = value; }
        }

        Color backColorGrad = Color.Gainsboro;
        public Color BackColorGrad
        {
            get { return backColorGrad; }
            set { backColorGrad = value; }
        }

        private void LabelEx_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rcBounds = this.Bounds;
            rcBounds.X = 0;
            rcBounds.Y = 0;

            Brush brFore = new LinearGradientBrush(rcBounds, this.ForeColor, this.ForeColorGrad, LinearGradientMode.Vertical);
            Brush brBack = new LinearGradientBrush(rcBounds, this.BackColor, this.BackColorGrad, LinearGradientMode.Vertical);
            Pen pen = new Pen(brBack);
            pen.Width = 1;

            StringFormat strFormat = new StringFormat();
            strFormat.Trimming = StringTrimming.None;
            strFormat.FormatFlags = StringFormatFlags.NoWrap;

            // Draw background
            
            Rectangle rcRect = rcBounds;
            rcRect.Width -= 1;// +(int)(pen.Width / 2.0);
            rcRect.Height -= 1;// +(int)(pen.Width / 2.0);
            e.Graphics.FillRectangle(brFore, rcRect);

            e.Graphics.DrawRectangle(pen, rcBounds);
            e.Graphics.DrawString(this.Text, this.Font, brBack, rcBounds, strFormat);
            
            // Draw extra string BG
            Rectangle rcBoundEx = rcBounds;
            rcBoundEx.Width -= m_ptTextEx.X;
            rcBoundEx.Height -= m_ptTextEx.Y;
            rcBoundEx.X = m_ptTextEx.X;
            rcBoundEx.Y = m_ptTextEx.Y;
            e.Graphics.DrawString(this.TextEx, this.FontEx, brBack, rcBoundEx, strFormat);

            // Draw foreground
            double dblProgress = (double)this.Tag;
            dblProgress = dblProgress < 0.0 ? 0.0 : dblProgress > 1.0 ? 1.0 : dblProgress;
            rcBounds.Width = (int)(rcBounds.Width * dblProgress);
            if (rcBounds.Width > 0)
            {
                e.Graphics.FillRectangle(brBack, rcBounds);
                e.Graphics.DrawString(this.Text, this.Font, brFore, rcBounds, strFormat);
            }

            // Draw extra string FG
            rcBoundEx.Width = rcBounds.Width - m_ptTextEx.X;
            if (rcBoundEx.Width > 0)
            {
                e.Graphics.DrawString(this.TextEx, this.FontEx, brFore, rcBoundEx, strFormat);
            }
        }
    }
}

