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
    public partial class MPlaylistStatus2 : UserControl
    {
        IMPlaylist m_pPlaylist;
        bool m_bOnAir;    

        public MPlaylistStatus2()
        {
            InitializeComponent();

            labelCurrent.Tag = 1.0;
            labelNext.Tag = 1.0;
        }

        

        public bool OnAir
        {
            get
            {
                return m_bOnAir;
            }
            set
            {
                m_bOnAir = value;
                UpdateStatus();
            }
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pPlaylist;
            try
            {
                m_pPlaylist = (IMPlaylist)pObject;

                UpdateStatus();

                ((MPlaylist)m_pPlaylist).OnEvent += new IMEvents_OnEventEventHandler(MPlaylistControl_OnEvent);
                ((MPlaylist)m_pPlaylist).OnFrame += new IMEvents_OnFrameEventHandler(MPlaylistStatus_OnFrame);
            }
            catch (System.Exception) { }

            return pOld;
        }

        void MPlaylistStatus_OnFrame(string bsChannelID, object pMFrame)
        {
            UpdateStatus();
        }

        void MPlaylistControl_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            UpdateStatus();
        }

        public void UpdateStatus()
        {
            try
            {
                // Get current & next index
                int nCurrentIdx, nNextIdx;
                double dblListPos;
                double dblPlayingPos; // Playing pos or break pos
                m_pPlaylist.PlaylistPosGet(out nCurrentIdx, out nNextIdx, out dblPlayingPos, out dblListPos);

                // Get items count
                int nItemsCount;
                double dblListLen;
                m_pPlaylist.PlaylistGetCount(out nItemsCount, out dblListLen);

                // Update playlist position
                labelPlaylist.Text = (m_bOnAir ? "Playlist OnAir: " : "Playlist: ") + MHelpers.PosToString(dblListPos, 0) + "/" + MHelpers.PosToString(dblListLen, 0);
                labelPlaylist.Tag = dblListPos / dblListLen;
                labelPlaylist.Invalidate();


                // Get current(break) and next(current) item
                double dblPosFake;
                MItem pItem1, pItem2;
                string sItem1, sItem2;
                m_pPlaylist.PlaylistGetByIndex(-1, out dblPosFake, out sItem1, out pItem1); // Current or Break (eMS_Break state) item
                sItem1 = sItem1.Substring(sItem1.LastIndexOf('\\') + 1);
                m_pPlaylist.PlaylistGetByIndex(-2, out dblPosFake, out sItem2, out pItem2); // Next or Current (eMS_Break state) item
                sItem2 = sItem2.Substring(sItem2.LastIndexOf('\\') + 1);

                // Get current pos & duration
                double dblFilePos;
                pItem1.FilePosGet(out dblFilePos);

                double dblIn = 0, dblOut = 0, dblFileLen = 0;
                pItem1.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
                dblFileLen = dblOut > dblIn ? dblOut : dblFileLen;
                labelCurrent.Tag = (dblFilePos - dblIn) / (dblFileLen - dblIn);
                labelCurrent.Invalidate();

                // Check for state
                eMState eState;
                double dblTimeState;
                ((IMFile)m_pPlaylist).FileStateGet(out eState, out dblTimeState);

                if (eState == eMState.eMS_Break)
                {
                    labelCurrent.TextEx = MHelpers.PosToString(dblFilePos, 0) + "/" + MHelpers.PosToString(dblFileLen, 0);


                    labelPlaylist.BackColor = MHelpers.ColorDarkBlue;
                    labelCurrent.BackColor = m_bOnAir ? MHelpers.ColorActive : MHelpers.ColorReady;
                    
//                     labelNext.BackColor = Color.FromArgb(50, 100, 180);
//                     labelNext.ForeColor = Color.White;
                    labelCurrent.Text = "Break at " + MHelpers.PosToString(dblPlayingPos, 0) + ": " + sItem1;

                    labelNext.Text = "Playing: (" + nCurrentIdx + "/" + nItemsCount + ") " + sItem2;

                    // Update current pos
                    pItem2.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
                    dblFileLen = dblOut > dblIn ? dblOut : dblFileLen;
                    labelNext.Tag = (dblPlayingPos - dblIn) / (dblFileLen - dblIn);
                    labelNext.Invalidate();
                }
                else
                {
                    labelCurrent.TextEx = "(" + nCurrentIdx + "/" + nItemsCount + ") " + MHelpers.PosToString(dblFilePos, 0) + "/" + MHelpers.PosToString(dblFileLen, 0);

                    labelCurrent.BackColor = MHelpers.ColorDarkBlue;
                    labelPlaylist.BackColor = m_bOnAir ? MHelpers.ColorActive : MHelpers.ColorReady;

//                     labelCurrent.BackColor = Color.DeepSkyBlue;
//                     labelCurrent.ForeColor = Color.White;
//                     labelNext.BackColor = Color.DeepSkyBlue;// Color.FromArgb(222, 232, 254);
//                     labelNext.ForeColor = Color.White;// Color.FromArgb(50, 100, 180);

                    labelCurrent.Text = "Playing: " + sItem1;

                    labelNext.Text = "Cued: (" + nNextIdx + "/" + nItemsCount + ") " + sItem2;
                    labelNext.Tag = 1.0;
                    labelNext.Invalidate();
                }

            }
            catch (System.Exception)
            {
                // If list is empty -> this error returns

                labelPlaylist.BackColor = m_bOnAir ? MHelpers.ColorActive : MHelpers.ColorReady;
            }
        }

        private void labelPos_Paint(object sender, PaintEventArgs e)
        {
           
        }

        
    }
}
