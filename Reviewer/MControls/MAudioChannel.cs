using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
    public partial class MAudioChannel : Control
    {
        public MAudioChannel()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }

        

        // Called if user change playlist selection
        public event EventHandler OnGainChanged;
        public event EventHandler OnEnableChanged;

        float fGain = 0;
        public double Gain
        {
            get { return fGain; }
            set 
            { 
                fGain = (float)value;
                Invalidate();
            }
        }
        public bool ChannelEnabled
        {
            get { return checkBoxOn.Checked; }
            set { checkBoxOn.Checked = value; }
        }

        float fLevel = -20.0f;
        public double Level
        {
            get { return fLevel; }
            set { fLevel = (float)value; }
        }

        float fLevelOrg = -10.0f;
        public double LevelOrg
        {
            get { return fLevelOrg; }
            set { fLevelOrg = (float)value; }
        }

        float fRisk = 5.0f;
        public float Risk
        {
            get { return fRisk; }
            set { fRisk = value; }
        }

        Color colorLevelBack = Color.DarkGray;
        public Color ColorLevelBack
        {
            get { return colorLevelBack; }
            set { colorLevelBack = value; }
        }

        Color colorLevelOrg = Color.Silver;
        public Color ColorLevelOrg
        {
            get { return colorLevelOrg; }
            set { colorLevelOrg = value; }
        }

        Color colorLevelHi = Color.Red;
        public Color ColorLevelHi
        {
            get { return colorLevelHi; }
            set { colorLevelHi = value; }
        }

        Color colorLevelMid = Color.Yellow;
        public Color ColorLevelMid
        {
            get { return colorLevelMid; }
            set { colorLevelMid = value; }
        }

        Color colorLevelLo = Color.Green;
        public Color ColorLevelLo
        {
            get { return colorLevelLo; }
            set { colorLevelLo = value; }
        }

        Color colorOutline = Color.Black;
        public Color ColorOutline
        {
            get { return colorOutline; }
            set { colorOutline = value; }
        }

        Color colorGainSlider = Color.Red;
        public Color ColorGainSlider
        {
            get { return colorGainSlider; }
            set { colorGainSlider = value; }
        }

        float fOutline = 0.0f;
        public float Outline
        {
            get { return fOutline; }
            set { fOutline = value; }
        }

        string[] leftText = null;
        public string[] TextLeft
        {
            get { return leftText; }
            set { leftText = value; }
        }

        string[] rightText = null;
        public string[] TextRight
        {
            get { return rightText; }
            set { rightText = value; }
        }

       

        // For non-lenear display
        static float Level2Pos(float fLevel)
        {
            if (fLevel < -30)
            {
                // 0..0.25
                fLevel = fLevel > -60.0f ? fLevel : -60.0f;
                return 0.25f * (fLevel + 60.0f) / 30.0f ;
            }

            fLevel = fLevel > 0 ? 0.0f : fLevel;
            return 0.25f + 0.75f * (fLevel + 30.0f) / 30.0f;
        }

        static float Gain2Pos(float fGain)
        {
            fGain = fGain > 20.0f ? 20.0f : fGain < -20.0f ? -20.0f : fGain;

            return (fGain + 20.0f) / 40.0f;
        }

        private void MAudioCh_Paint(object sender, PaintEventArgs e)
        {
            // Draw dB risk // 0 ... - 30 dB / -30 dB ...-60 dB for level, +20 ... -20 dB for Gain 
            //             int nIndent = this.Font.Height;
            // 
            //             float fMax = this.Bounds.Height - nIndent * 2;
            //             string [] pLevel = new string[] { "0", "-10", "-20", "-30", "-60"};
            //             string [] pGain = new string[] { "+20", "+10", "0", "-10", "-20"};
            // 
            //             float fStep = fMax / 4;
            // 
            //             Brush brText = new SolidBrush( this.ForeColor );
            // 
            //             StringFormat strFormat = new StringFormat();
            //             strFormat.Alignment = StringAlignment.Far;
            // 
            //             RectangleF rcString = new RectangleF(0, 0, Bounds.Width, Font.Height);
            //             e.Graphics.DrawString("dB", this.Font, brText, rcString);
            //             e.Graphics.DrawString("dB", this.Font, brText, rcString, strFormat);
            //             for (int i = 0; i < pLevel.Length; i++)
            //             {
            //                 rcString.Y = nIndent + fStep * i;
            //                 e.Graphics.DrawString(pLevel[i], this.Font, brText, rcString);
            //                 e.Graphics.DrawString(pGain[i], this.Font, brText, rcString, strFormat);
            //             }

            Brush brBack = new SolidBrush(colorLevelBack);
            Brush brOrg = new SolidBrush(colorLevelOrg);
            Brush brLevelHi = new SolidBrush(ColorLevelHi);
            Brush brLevelMid = new SolidBrush(ColorLevelMid);
            Brush brLevelLow = new SolidBrush(ColorLevelLo);

            float fIndent = 3.0f;
            float fGainH = 2.0f;
            RectangleF rcBack = new RectangleF(fIndent, fGainH / 2.0f, this.Bounds.Width - fIndent * 2, checkBoxOn.Location.Y - fGainH);
            e.Graphics.FillRectangle(brBack, rcBack);

            // Draw level (original)
            RectangleF rcLevelOrg = rcBack;
            rcLevelOrg.Height *= Level2Pos(fLevelOrg);
            rcLevelOrg.Y = rcBack.Bottom - rcLevelOrg.Height;
            e.Graphics.FillRectangle(brOrg, rcLevelOrg);

            // Draw level (out)
            {
                // Hi - 0..-6
                // Mid - -6 ..-12
                // Low ... Other
                RectangleF rcLevelOut = rcBack;


                // Draw higher levels
                Brush brLevel;
                if (fLevel >= -10.0)
                    brLevel = brLevelHi;
                else if( fLevel >= -20.0 )
                    brLevel = brLevelMid;
                else
                    brLevel = brLevelLow;

                rcLevelOut.Height *= Level2Pos(fLevel);
                rcLevelOut.Y = rcBack.Bottom - rcLevelOut.Height;
                e.Graphics.FillRectangle(brLevel, rcLevelOut);

                if (fLevel >= -10.0f)
                {
                    rcLevelOut.Height = rcBack.Height * Level2Pos(-10.0f);
                    rcLevelOut.Y = rcBack.Bottom - rcLevelOut.Height;
                    e.Graphics.FillRectangle(brLevelMid, rcLevelOut);
                }
                if (fLevel >= -20.0)
                {
                    rcLevelOut.Height = rcBack.Height * Level2Pos(-20.0f);
                    rcLevelOut.Y = rcBack.Bottom - rcLevelOut.Height;
                    e.Graphics.FillRectangle(brLevelLow, rcLevelOut);
                }
            }

            // Draw rectangle
            if (fOutline > 0)
            {
                Pen penOutline = new Pen(colorOutline);
                penOutline.Width = fOutline;
                e.Graphics.DrawRectangle(penOutline, Rectangle.Round(rcBack));
            }

            // Draw risks 
            if (fRisk > 0)
            {
                Pen penRisk = new Pen(colorLevelBack);
                for (float fPos = fRisk; fPos < rcBack.Height; fPos += (fRisk + 1.0f)) 
                {
                    // Draw risk
                    e.Graphics.DrawLine(penRisk, rcBack.Left, rcBack.Bottom - fPos, rcBack.Right - 1.0f, rcBack.Bottom - fPos);
                }
            }

            // Draw text
            if ( (leftText != null && leftText.Length > 1))
            {
                float fStep = (float)rcBack.Height / (leftText.Length - 1);

                Brush brText = new SolidBrush(this.ForeColor);

                RectangleF rcString = new RectangleF(0, 0, Bounds.Width, Font.Height);
                for (int i = 0; i < leftText.Length; i++)
                {
                    rcString.Y = fStep * i;
                    e.Graphics.DrawString(leftText[i], this.Font, brText, rcString);
                }
            }

            if ((rightText != null && rightText.Length > 1))
            {
                float fStep = (float)rcBack.Height / (rightText.Length - 1);

                Brush brText = new SolidBrush(this.ForeColor);

                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Far;

                RectangleF rcString = new RectangleF(0, 0, Bounds.Width, Font.Height);
                for (int i = 0; i < rightText.Length; i++)
                {
                    rcString.Y = fStep * i;
                    e.Graphics.DrawString(rightText[i], this.Font, brText, rcString, strFormat);
                }
            }


            // Draw gain
            Pen penGain = new Pen(colorGainSlider);
            penGain.Width = fGainH;

            float fGainPos = rcBack.Bottom - rcBack.Height * Gain2Pos(fGain);
            e.Graphics.DrawLine(penGain, 0, fGainPos, Bounds.Width, fGainPos);
        }

        private void MAudioCh_MouseMove(object sender, MouseEventArgs e)
        {
            float fIndent = 3.0f;
            float fGainH = 2.0f;
            RectangleF rcBack = new RectangleF(fIndent, fGainH / 2.0f, this.Bounds.Width - fIndent * 2, checkBoxOn.Location.Y - fGainH);

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                this.Gain = ((rcBack.Bottom - e.Y) / rcBack.Height) * 40.0f - 20.0f;
                Invalidate();

                // Notify about playlist changing
                if (this.OnGainChanged != null)
                    this.OnGainChanged(this, e);
            }
        }

        private void MAudioCh_MouseDown(object sender, MouseEventArgs e)
        {
            float fIndent = 3.0f;
            float fGainH = 2.0f;
            RectangleF rcBack = new RectangleF(fIndent, fGainH / 2.0f, this.Bounds.Width - fIndent * 2, checkBoxOn.Location.Y - fGainH);

            this.Gain = ((rcBack.Bottom - e.Y) / rcBack.Height) * 40.0f - 20.0f;
            Invalidate();

            if (this.OnGainChanged != null)
                this.OnGainChanged(this, e);
        }

        private void checkBoxOn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.OnEnableChanged != null)
                this.OnEnableChanged(this, e);
        }
    }
}
