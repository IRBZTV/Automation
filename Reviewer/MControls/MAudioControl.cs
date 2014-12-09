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
    public partial class MAudioControl : UserControl
    {
        IMAudio m_pMAudio;

        public MAudioControl()
        {
            InitializeComponent();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMAudio;
            try
            {
                m_pMAudio = (IMAudio)pObject;

                UpdateControl();

                if (SetCallback())
                {
                    // Disable timer, use events for get audio level 
                    timerUpdate.Enabled = false;
                }
                else
                {
                    // Enable timer -> update by timer
                    timerUpdate.Enabled = true;
                }
            }
            catch (System.Exception) { }

            return pOld;
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

        Color colorLevelMid = MHelpers.ColorDarkBlue;
        public Color ColorLevelMid
        {
            get { return colorLevelMid; }
            set { colorLevelMid = value; }
        }

        Color colorLevelLo = Color.DarkBlue;
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

        MAudioCh[] arrChannel;

        void UpdateControl()
        {
            try
            {
                // Get number of channels
//                 eMAudioTrackMode eMode;
//                 int nIndex;
//                 double dblGain;
//                 int nChannels;
//                 m_pMAudio.AudioTrackGet(0, out eMode, out nIndex, out dblGain, out nChannels );
// 
//                 arrChannel = new MAudioCh[nChannels];
//                 for (int i = 0; i < nChannels; i++)
//                 {
//                     arrChannel[i] = new MAudioCh();
//                     arrChannel[i].Parent = this;
//                     arrChannel[i].Visible = true;
//                     arrChannel[i].ColorLevelBack = ColorLevelBack;
//                     arrChannel[i].ColorLevelOrg = ColorLevelOrg;
//                     arrChannel[i].ColorLevelHi = ColorLevelHi;
//                     arrChannel[i].ColorLevelMid = ColorLevelMid;
//                     arrChannel[i].ColorLevelLo = ColorLevelLo;
//                     arrChannel[i].ColorOutline = ColorOutline;
//                     arrChannel[i].ColorGainSlider = ColorGainSlider;
// 
// 
//                     arrChannel[i].Location = new Point(arrChannel[i].Bounds.Width * i,0);
//                     arrChannel[i].Height = this.Height;
//                     arrChannel[i].Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
//                     arrChannel[i].OnGainChanged +=new EventHandler(MAudioControl_OnGainChanged);
// 
//                     m_pMAudio.AudioGainGet(-1, i, out dblGain);
//                     arrChannel[i].Gain = dblGain;
//                 }
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }

        bool SetCallback()
        {
            try
            {
                // Try MPlaylist
                ((MPlaylistClass)m_pMAudio).OnFrame += new IMEvents_OnFrameEventHandler(MAudioControl_OnFrame);
                return true;
            }
            catch (System.Exception) { }

            try
            {
                // Try MLive
                ((MLiveClass)m_pMAudio).OnFrame += new IMEvents_OnFrameEventHandler(MAudioControl_OnFrame);
                return true;
            }
            catch (System.Exception) { }

            try
            {
                // Try MFile
                ((MFileClass)m_pMAudio).OnFrame += new IMEvents_OnFrameEventHandler(MAudioControl_OnFrame);
                return true;
            }
            catch (System.Exception) { }

            return false;
        }

        void MAudioControl_OnFrame(string bsChannelID, object pMFrame)
        {
            try
            {
                M_AV_PROPS avProp;
                ((IMFrame)pMFrame).AVPropsGet(out avProp);

                if (avProp.audProps.nChannels != arrChannel.Length)
                {
                    UpdateControl();
                }

                for( int i = 0; i < arrChannel.Length; i++ )
                {
//                     arrChannel[i].Level = avProp.ancData.arrALevelOut[i];
//                     arrChannel[i].LevelOrg = avProp.ancData.arrALevelOrg[i];
//                     arrChannel[i].Invalidate();
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }

        int Control2Channel(object sender)
        {
            for (int i = 0; i < arrChannel.Length; i++)
            {
                if (arrChannel[i].Equals(sender))
                    return i;
            }

            return -1;
        }

        void MAudioControl_OnGainChanged(object sender, EventArgs e)
        {
//             int nChannel = Control2Channel(sender);
//             if (nChannel >= 0)
//             {
//                 m_pMAudio.AudioGainSet(-1, nChannel, arrChannel[nChannel].Gain, 0);
//             }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
//                 eMAudioTrackMode eMode;
//                 int nIndex;
//                 double dblGain;
//                 int nChannels;
//                 m_pMAudio.AudioTrackGet(0, out eMode, out nIndex, out dblGain, out nChannels);
//                 if (nChannels != arrChannel.Length)
//                 {
//                     UpdateControl();
//                 }
// 
//                 double dblLevel, dblLevelOrg;
//                 for (int i = 0; i < arrChannel.Length; i++)
//                 {
//                     m_pMAudio.AudioLevelGet(-1, i, out dblLevelOrg, out dblLevel);
// 
//                     arrChannel[i].Level = dblLevel;
//                     arrChannel[i].LevelOrg = dblLevelOrg; // Original
//                     arrChannel[i].Invalidate();
//                 }
            }
            catch (System.Exception) { }
        }
    }
}
