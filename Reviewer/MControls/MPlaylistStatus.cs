using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class MPlaylistStatus : UserControl
    {
        IMPlaylist m_pPlaylist;
        bool m_bOnAir;

        public MPlaylistStatus()
        {
            InitializeComponent();

            labelCurrent.Tag = 1.0;
            labelNext.Tag = 1.0;

            MFramesStore.Root.ImageSet("default", pictureBoxCurrent.Image);
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
                int nFiles = 0;
                double dblDuration = 0;
                m_pPlaylist.PlaylistGetCount(out nFiles, out dblDuration);
                if (nFiles > 0)
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
                    MHelpers.PictureBoxSetImage(pictureBoxCurrent, MFramesStore.Root.FileFrameGet(pItem1, 10.0));
                    MHelpers.PictureBoxSetImage(pictureBoxNext, MFramesStore.Root.FileFrameGet(pItem2, 10.0));


                    // Get current pos & duration
                    double dblFilePos;
                    pItem1.FilePosGet(out dblFilePos);

                    double dblIn = 0, dblOut = 0, dblFileLen = 0;
                    pItem1.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
                    dblFileLen = dblOut > dblIn ? dblOut : dblFileLen;
                    dblFileLen = dblIn < dblFileLen ? dblFileLen : dblIn + 0.001;
                    labelCurrent.Tag = (dblFilePos - dblIn) / (dblFileLen - dblIn);
                    labelCurrent.Invalidate();

                    // Check for state
                    eMState eState;
                    double dblTimeState;
                    ((IMFile)m_pPlaylist).FileStateGet(out eState, out dblTimeState);

                    if (eState == eMState.eMS_Break)
                    {
                        labelCurrent.TextEx = MHelpers.PosToString(dblFilePos, 0) + "/" + MHelpers.PosToString(dblFileLen, 0);


                        labelCurrent.BackColor = Color.Maroon;
                        labelCurrent.BackColorGrad = Color.Red;
                        labelNext.BackColor = MHelpers.ColorDarkBlue;
                        labelNext.BackColorGrad = MHelpers.ColorLightBlue;


                        //                     labelNext.BackColor = Color.FromArgb(50, 100, 180);
                        //                     labelNext.ForeColor = Color.White;
                        labelCurrent.Text = "Break at " + MHelpers.PosToString(dblPlayingPos, 0) + ": " + sItem1;

                        labelNext.Text = "Next: " + sItem2;

                        // Update current pos
                        pItem2.FilePosGet(out dblFilePos);
                        pItem2.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
                        dblFileLen = dblOut > dblIn ? dblOut : dblFileLen;
                        dblFileLen = dblIn < dblFileLen ? dblFileLen : dblIn + 0.001;
                        //labelNext.Tag = (dblPlayingPos - dblIn) / (dblFileLen - dblIn);
                        //labelNext.Invalidate();

                        Invalidate();

                        Marshal.ReleaseComObject(pItem1);
                        Marshal.ReleaseComObject(pItem2);
                        GC.Collect();
                    }
                    else
                    {
                        labelCurrent.TextEx = "(" + nCurrentIdx + "/" + nItemsCount + ") " + MHelpers.PosToString(dblFilePos, 0) + "/" + MHelpers.PosToString(dblFileLen, 0);

                        labelCurrent.BackColor = MHelpers.ColorDarkBlue;
                        labelCurrent.BackColorGrad = MHelpers.ColorLightBlue;
                        labelNext.BackColor = MHelpers.ColorLightBlue;
                        labelNext.BackColorGrad = MHelpers.ColorBGBlue;

                        //                     labelCurrent.BackColor = Color.DeepSkyBlue;
                        //                     labelCurrent.ForeColor = Color.White;
                        //                     labelNext.BackColor = Color.DeepSkyBlue;// Color.FromArgb(222, 232, 254);
                        //                     labelNext.ForeColor = Color.White;// Color.FromArgb(50, 100, 180);

                        labelCurrent.Text = "Playing: " + sItem1;

                        labelNext.Text = "Next: " + sItem2;
                        //                     labelNext.Tag = 1.0;
                        //                     labelNext.Invalidate();

                        Invalidate();
                    }

                    return;
                }
            }
            catch (System.Exception ex)
            {
                
            }

            // If list is empty 
            labelPlaylist.BackColor = m_bOnAir ? MHelpers.ColorActive : MHelpers.ColorReady;
            MHelpers.PictureBoxSetImage(pictureBoxCurrent, MFramesStore.Root.ImageGet("default"));
            MHelpers.PictureBoxSetImage(pictureBoxNext, MFramesStore.Root.ImageGet("default"));
        }

      

        
    }
}
