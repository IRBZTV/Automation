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
    public partial class MFileSeeking : UserControl
    {
        public MFileSeeking()
        {
           
            InitializeComponent();
        }

        private IMFile m_pFile;

        // Common controls methods
        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pFile;
            try
            {
                m_pFile = (IMFile)pObject;

                UpdateControl();

                if ( false && SetCallback())
                {
                    // Disable timer, use events for get audio level 
                    timerPos.Enabled = false;
                }
                else
                {
                    // Enable timer -> update by timer
                    timerPos.Enabled = true;
                }
            }
            catch (System.Exception){}

            return pOld;
        }

        public void UpdateControl()
        {
           UpdatePos();
        }

        bool SetCallback()
        {
            try
            {
                // Try MPlaylist
                ((MPlaylistClass)m_pFile).OnFrame += new IMEvents_OnFrameEventHandler(MFileSeeking_OnFrame);
                return true;
            }
            catch (System.Exception) { }

            try
            {
                // Try MFile
                ((MFileClass)m_pFile).OnFrame += new IMEvents_OnFrameEventHandler(MFileSeeking_OnFrame);
                return true;
            }
            catch (System.Exception) { }

            return false;
        }

        void MFileSeeking_OnFrame(string bsChannelID, object pMFrame)
        {
            UpdatePos();
        }

        public void UpdatePos()
        {
            try
            {
                // Get In/Out
                double dblIn, dblOut, dblLen;
                m_pFile.FileInOutGet(out dblIn, out dblOut, out dblLen);
                dblOut = dblOut > dblIn ? dblOut : dblLen;

                // Get pos
                double dblPos;
                m_pFile.FilePosGet( out dblPos );


                // Correct in/out according to check state
                //if( checkBoxInOut.Checked )
                //{
                //    labelInOut.Visible = false;
                //    dblLen = dblOut - dblIn;
                //    dblPos -= dblIn;
                //}
                //else
                {
                    labelInOut.Width = (int)(labelPosBase.Width * (dblOut - dblIn) / dblLen + 0.5);
                    labelInOut.Left = labelPosBase.Left + (int)(labelPosBase.Width * dblIn / dblLen + 0.5);
                    labelInOut.Visible = true;
                }

                dblLen = dblLen > 0 ? dblLen : 0.001;
                dblPos = dblPos > 0 ? dblPos : 0;
                dblPos = dblPos < dblLen ? dblPos : dblLen;

               // labelPosStr.Text = MHelpers.PosToString(dblPos, 1) + " / " + MHelpers.PosToString(dblLen, 1);
                labelPos.Width = (int)(labelPosBase.Width * dblPos / dblLen + 0.5);
            }
            catch (System.Exception){}
        }

        private void SetPos( double dblValue, double dblPreroll )
        {
            try
            {
                // Get In/Out
                double dblIn, dblOut, dblLen;
                m_pFile.FileInOutGet(out dblIn, out dblOut, out dblLen);

                // Correct in/out according to check state
                //if (checkBoxInOut.Checked)
                //{
                //    dblLen = (dblOut > dblIn ? dblOut : dblLen) - dblIn;
                //}
                //else
                {
                    dblIn = 0;
                }

                dblLen = dblLen > 0 ? dblLen : 0.001;


                double dblPos = dblIn + dblLen * dblValue;
                m_pFile.FilePosSet(dblPos, dblPreroll);

                UpdatePos();
            }
            catch (System.Exception) { }
        }

        private void timerPos_Tick(object sender, EventArgs e)
        {
            UpdatePos();
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            SetPos( (double)trackBarSeek.Value / (double)trackBarSeek.Maximum, 0 );
        }

        private void trackBarSeek_MouseDown(object sender, MouseEventArgs e)
        {
            int nTBPadding = 14;
            double dblPos = (double)(e.Location.X - nTBPadding) / (trackBarSeek.Width - nTBPadding * 2);
            dblPos = dblPos > 0 ? dblPos < 1.0 ? dblPos : 1.0 : 0;
            trackBarSeek.Value = (int)(trackBarSeek.Maximum * dblPos + 0.5);
            SetPos( dblPos, 0.5 );
        }

        private void checkBoxInOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePos();
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (m_pFile != null)
            //        m_pFile.FilePosSet(MHelpers.ParsePos(textBoxRew.Text), 1.0);
            //}
            //catch (System.Exception) { }
        }

        private void textBoxRew_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab)
            //    textBoxRew.Text = MHelpers.PosToString(MHelpers.ParsePos(textBoxRew.Text));
        }

    }
}
