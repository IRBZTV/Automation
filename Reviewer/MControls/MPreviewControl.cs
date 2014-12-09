using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class MPreviewControl : UserControl
    {
        public IMPreview m_pPreview;
        protected bool m_bFullScreen;

        public MPreviewControl()
        {
            InitializeComponent();
        }

        public class MPreview_EventArgs : MouseEventArgs
        {
            public PointF ptRelative;

            public MPreview_EventArgs(PointF ptPos, MouseEventArgs e)
                : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
            {
                ptRelative = ptPos;
            }
        };

        // Called if user change breaks list selection
        public event EventHandler OnPreviewMouseUp;
        public event EventHandler OnPreviewMouseDown;
        public event EventHandler OnPreviewMouseMove;
        public event EventHandler OnPreviewMouseLeave;
        

        public virtual Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pPreview;
            try
            {
                if (m_pPreview != null)
                {
                    m_pPreview.PreviewEnable("", 0, 0);
                }


                m_pPreview = (IMPreview)pObject;

    
                // TODO: Normal get/set props

                //Initialize preview
                m_pPreview.PreviewWindowSet("", panelPreview.Handle.ToInt32());
                
                m_pPreview.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
                string srtDeinterlace;
                ((IMProps)m_pPreview).PropsGet("deinterlace", out srtDeinterlace);
                if (srtDeinterlace == "true" || srtDeinterlace == "1")
                {
                    checkBoxDeinterlace.CheckedChanged -= new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
                    checkBoxDeinterlace.Checked = true;
                    checkBoxDeinterlace.CheckedChanged += new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
                }

                string srtAR;
                ((IMProps)m_pPreview).PropsGet("maintain_ar", out srtAR);
                checkBoxAR.CheckedChanged -= new System.EventHandler(this.checkBoxAR_CheckedChanged);
                if (srtAR == null || srtAR == String.Empty || srtAR == "none")
                    checkBoxAR.Checked = false;
                else
                    checkBoxAR.Checked = true;
                checkBoxAR.CheckedChanged += new System.EventHandler(this.checkBoxAR_CheckedChanged);
            }
            catch (System.Exception) { }

            

            return pOld;
        }

        /// <summary>
        /// Enable/desable the video preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            m_pPreview.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Enable/desable the audio preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            m_pPreview.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Set audio volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            // Volume in dB
            // 0 - full volume, -100 silence
            double dblPos = (double)trackBarVolume.Value / trackBarVolume.Maximum;
            m_pPreview.PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos));
        }

        private void checkBoxAR_CheckedChanged(object sender, EventArgs e)
        {
            ((IMProps)m_pPreview).PropsSet("maintain_ar", checkBoxAR.Checked ? "letter-box" : "none");
        }

        private void checkBoxFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            // Enable full screen (use -1 for auto-select monitor)
            if (checkBoxFullScreen.Checked)
                if (checkBoxFullScreen.Checked)
                {
                    m_pPreview.PreviewFullScreen("", 1,-1);
                    m_bFullScreen = true;
                }
                else
                    m_pPreview.PreviewFullScreen("", 0,-1);
        }

        private void trackBarVolume_MouseDown(object sender, MouseEventArgs e)
        {
            int nTBPadding = 14;
            double dblPos = (double)(e.Location.X - nTBPadding) / (trackBarVolume.Width - nTBPadding * 2);
            dblPos = dblPos > 0 ? dblPos < 1.0 ? dblPos : 1.0 : 0;
            trackBarVolume.Value = trackBarVolume.Minimum + (int)((trackBarVolume.Maximum - trackBarVolume.Minimum) * dblPos + 0.5);

            trackBarVolume_Scroll(sender, EventArgs.Empty);
        }

        private void panelPreview_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pPreview != null && checkBoxVideo.Checked )
                    m_pPreview.PreviewWindowSet("", panelPreview.Handle.ToInt32());
                
            }
            catch (System.Exception) { }
        }

        private PointF PointToRelative( Point ptPos )
        {
            PointF ptRes = new PointF( (float)ptPos.X / panelPreview.Width, (float)ptPos.Y / panelPreview.Height );

            return ptRes;
            // TODO: Check for AR
//             int nIndex;
//             string sName;
//             M_VID_PROPS vidProps;
//             ((IMFormat)m_pPreview).FormatVideoGet(eMFormatType.eMFT_Output, out vidProps, out nIndex, out sName);
// 
//             string strAR = "";
//             ((IMProps)m_pPreview).PropsSet("maintain-ar", out strAR );
//             if( strAR == "letter-box" ) // TODO: Other types of ar - Crop, No-Scale
//             {
//                 
//             }


        }

        private void panelPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.OnPreviewMouseUp != null)
                this.OnPreviewMouseUp(sender, new MPreview_EventArgs(PointToRelative(e.Location), e));

            string srtDeinterlace;
            ((IMProps)m_pPreview).PropsGet("deinterlace", out srtDeinterlace);
            if (srtDeinterlace == "true" || srtDeinterlace == "1") ;

            m_bFullScreen = false;
        }

        private void panelPreview_MouseDown(object sender, MouseEventArgs e)
        {
           // Disable full screen
           ((IMProps)m_pPreview).PropsSet("full_screen", "false");
           checkBoxFullScreen.Checked = false;
            
           if (this.OnPreviewMouseDown != null)
               this.OnPreviewMouseDown(sender, new MPreview_EventArgs(PointToRelative(e.Location), e));
           
        }

        private void panelPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.OnPreviewMouseMove != null)
                this.OnPreviewMouseMove(sender, new MPreview_EventArgs(PointToRelative(e.Location), e));
        }

        private void panelPreview_MouseLeave(object sender, EventArgs e)
        {
            if (this.OnPreviewMouseLeave != null)
                this.OnPreviewMouseLeave(sender, e);
        }

        private void checkBoxDeinterlace_CheckedChanged(object sender, EventArgs e)
        {
            ((IMProps)m_pPreview).PropsSet("deinterlace", checkBoxDeinterlace.Checked ? "true" : "false");
        }

        private void MPreviewControl_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        
    }
}
