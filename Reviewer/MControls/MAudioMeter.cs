using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MPLATFORMLib;

namespace MControls
{
    public partial class MAudioMeter : UserControl
    {
        int m_nCurrentTrack = 0;
        IMAudio m_pMAudio;
        IMAudioTrack    m_pMAudioTrack;

        // The indent for first VU meter (calc from text)
        float fLeftIndent = 22.0f;
        float fRightIndent = 22.0f;

        // This is for shorter combox-box: 'eMAT_Mix_Exclusive' - too long
        private eMAudioTrackMode[] pModes = new eMAudioTrackMode[6] 
            { eMAudioTrackMode.eMAT_Enabled, eMAudioTrackMode.eMAT_Disabled, 
              eMAudioTrackMode.eMAT_Exclusive, eMAudioTrackMode.eMAT_Mix_Exclusive,
              eMAudioTrackMode.eMAT_Enabled_AddTo, eMAudioTrackMode.eMAT_Disabled_AddTo };
        public MAudioMeter()
        {
            InitializeComponent();

            //comboBoxMode.Items.Add("Enabled");
            //comboBoxMode.Items.Add("Disabled");
            //comboBoxMode.Items.Add("Exclusive");
            //comboBoxMode.Items.Add("Mix_Exclusive");
            // Next modes not implemented (in control)
            //comboBoxMode.Items.Add(eMAudioTrackMode.eMAT_Enabled_AddTo);
            //comboBoxMode.Items.Add(eMAudioTrackMode.eMAT_Disabled_AddTo);
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMAudio;
            try
            {
                m_pMAudio = (IMAudio)pObject;

                FillTracks();
                UpdateControl( );

                if (  SetCallback())
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

        Color colorLevelOrg = Color.LightGray;
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

        Color colorLevelMid = Color.Blue;
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

        Color backColorHi = Color.FromArgb(222, 232, 254);
        public Color BackColorHi
        {
            get { return backColorHi; }
            set { backColorHi = value; }
        }

        MAudioChannel[] arrChannels;

        // Convert split bits to channels number
        // e.g. (binary) 00001001000 -> mean two track with 4 & 3 channels
        int SplitBits2Channels(M_AUD_PROPS _audProps, int _nTrack)
        {
            // Note: If track disabled -> skipped 
            
            int nSplitBits = _audProps.nTrackSplitBits;

            int nTrack = 0;
            int nCount = 1;
            int nShift = 0;
            while (nShift < _audProps.nChannels)
            {
                if( (nSplitBits & 1) != 0 )
                {
                    if (nTrack == _nTrack)
                        return nCount;

                    nCount = 0;
                    nTrack++;
                }

                nShift++;
                nCount++;
                nSplitBits >>= 1;
            }

            if (_nTrack == 0) // No split bits 
                return _audProps.nChannels;

            return 0;
        }

        void FillTracks()
        {
            if (m_pMAudio != null)
            {
              //  comboBoxTrack.Items.Clear();

                int nCount = 0;
                m_pMAudio.AudioTracksGetCount(out nCount);
                for (int i = 0; i < nCount; i++)
                {
                    string sName;
                    IMAudioTrack pTrack;
                    m_pMAudio.AudioTrackGetByIndex(i, out sName, out pTrack);

                  //  comboBoxTrack.Items.Add(sName);
                }

               // comboBoxTrack.SelectedIndex = m_nCurrentTrack;
            }
        }

        void UpdateControl()
        {
            int _nSelTrack = 0;
            if (m_pMAudio != null)
            {
                try
                {
                    string strTrack;
                    m_pMAudio.AudioTrackGetByIndex(_nSelTrack, out strTrack, out m_pMAudioTrack);
                    // Get number of channels
                    int nChIn, nChOut, nChOutIdx;
                    m_pMAudioTrack.TrackChannelsGet( out nChIn, out nChOutIdx, out nChOut);


                    // Update track mode
                    int nAdd;
                    double dblAddGain;
                    eMAudioTrackMode eMode;
                    m_pMAudioTrack.TrackModeGet(out eMode, out nAdd, out dblAddGain);
                    // eMAT_Enabled -> Enabled
                    //int nSel = comboBoxMode.FindStringExact(eMode.ToString().Substring(5) );
                    //comboBoxMode.SelectedIndex = Math.Max(0, nSel);
                    eMode = eMAudioTrackMode.eMAT_Enabled;
                    // if track disabled -> 0 real track channels
                    // TODO: Exclusive modes
                    if (eMode == eMAudioTrackMode.eMAT_Disabled || eMode == eMAudioTrackMode.eMAT_Disabled_AddTo)
                        nChOut = 0;
                       

                    if (arrChannels != null)
                    {
                        for (int i = 0; i < arrChannels.Length; i++)
                        {
                            if (arrChannels[i] != null )
                                arrChannels[i].Dispose();
                        }
                    }

                    arrChannels = new MAudioChannel[nChOut];
                    for (int i = 0; i < nChOut; i++)
                    {
                        arrChannels[i] = new MAudioChannel();
                        arrChannels[i].Parent = this;
                        arrChannels[i].Visible = true;
                        arrChannels[i].ColorLevelBack = ColorLevelBack;
                        arrChannels[i].ColorLevelOrg = ColorLevelOrg;
                        arrChannels[i].ColorLevelHi = ColorLevelHi;
                        arrChannels[i].ColorLevelMid = ColorLevelMid;
                        arrChannels[i].ColorLevelLo = ColorLevelLo;
                        arrChannels[i].ColorOutline = ColorOutline;
                        arrChannels[i].ColorGainSlider = ColorGainSlider;
                        arrChannels[i].Risk = 6;

                       // int nTop = comboBoxMode.Bounds.Bottom;
                        

                        arrChannels[i].Location = new Point((int)(arrChannels[i].Bounds.Width * i + fLeftIndent), 
                            (int)(Font.Height / 2) + 0 );
                        arrChannels[i].Height = (int)(this.Height - Font.Height / 2.0 - 0);
                        arrChannels[i].Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
                        arrChannels[i].OnGainChanged += new EventHandler(MAudioControl_OnGainChanged);
                        arrChannels[i].OnEnableChanged += new EventHandler(MAudioMeter_OnEnableChanged);

                        int nMute = 0;
                        double dblGain = 0;
                        try
                        {
                            // The channels could be changed in this moment.
                            m_pMAudioTrack.TrackGainGet(i, out dblGain);
                            m_pMAudioTrack.TrackMuteGet(i, out nMute);
                        }
                        catch (System.Exception) {}
                        
                        arrChannels[i].Gain = dblGain;
                        arrChannels[i].ChannelEnabled = (nMute != 1);
                    }

                    float fWidth = nChOut > 0 ? (int)(arrChannels[0].Bounds.Width * nChOut + fLeftIndent + fRightIndent)
                        : (int)(fLeftIndent + fRightIndent);

                    this.Width = (int)Math.Max(fWidth,comboBoxBase.Width);

                    m_nCurrentTrack = _nSelTrack;

                    Invalidate();
                }
                catch (System.Exception ex)
                {

                }
            }
        }

        bool SetCallback()
        {
            return false;
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

        private void comboBoxTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (m_nCurrentTrack != comboBoxTrack.SelectedIndex )
                UpdateControl();
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_pMAudioTrack != null)
            {
                m_pMAudioTrack.TrackModeSet(pModes[1], 0, 0.0);
            }
        }

        void MAudioControl_OnFrame(string bsChannelID, object pMFrame)
        {
            if (m_pMAudioTrack != null)
            {
                try
                {
                    // Check number of tracks
                    int nTracks = 0;
                    m_pMAudio.AudioTracksGetCount(out nTracks);
                    if (nTracks <= 0)
                    {
                        this.Enabled = false;
                        m_pMAudioTrack = null;
                        return;
                    }
                    //else if (comboBoxTrack.Items.Count != nTracks)
                    //{
                    //    m_nCurrentTrack = Math.Min(nTracks - 1, m_nCurrentTrack);
                    //    FillTracks();
                    //    UpdateControl();
                    //}


                    // Get number of channels
                    int nChIn, nChOut, nChOutIdx;
                    m_pMAudioTrack.TrackChannelsGet(out nChIn, out nChOutIdx, out nChOut);

                    int nAdd;
                    double dblAddGain;
                    eMAudioTrackMode eMode;
                    m_pMAudioTrack.TrackModeGet(out eMode, out nAdd, out dblAddGain);

                    // if track disabled -> 0 real track channels
                    // TODO: Exclusive modes
                    if (eMode == eMAudioTrackMode.eMAT_Disabled || eMode == eMAudioTrackMode.eMAT_Disabled_AddTo)
                        nChOut = 0;

                    if (nChOut != arrChannels.Length)
                    {
                        UpdateControl();
                    }

                    M_AV_PROPS avProp;
                    ((IMFrame)pMFrame).FrameAVPropsGet(out avProp);

                    for (int i = 0; i < arrChannels.Length; i++)
                    {
                        arrChannels[i].Level = avProp.ancData.audOutput.arrVUMeter[nChOutIdx + i];
                        arrChannels[i].LevelOrg = avProp.ancData.audOriginal.arrVUMeter[nChOutIdx + i];
                        arrChannels[i].Invalidate();
                    }

                    //Invalidate();
                }
                catch (System.Exception ex)
                {

                }
            }
        }

        int Control2Channel(object sender)
        {
            for (int i = 0; i < arrChannels.Length; i++)
            {
                if (arrChannels[i].Equals(sender))
                    return i;
            }

            return -1;
        }

        void MAudioControl_OnGainChanged(object sender, EventArgs e)
        {
            int nChannel = Control2Channel(sender);
            if (nChannel >= 0)
            {
                bool bAllChange = false; 
                try
                {
                    // By right button chnage all channels gain
                    MouseEventArgs ea = (MouseEventArgs)e;
                    if (ea.Button == MouseButtons.Right)
                        bAllChange = true;
                }
                catch (System.Exception) {}
                m_pMAudioTrack.TrackGainSet( bAllChange ? -1 : nChannel, arrChannels[nChannel].Gain, 0.1);

                if (bAllChange)
                {
                    for (int i = 0; i < arrChannels.Length; i++)
                    {
                        double dblGain = 0;
                        m_pMAudioTrack.TrackGainGet(i, out dblGain);
                        arrChannels[i].Gain = dblGain;
                    }
                }
            }
        }

        void MAudioMeter_OnEnableChanged(object sender, EventArgs e)
        {
            int nChannel = Control2Channel(sender);
            if (nChannel >= 0)
            {
                m_pMAudioTrack.TrackMuteSet(nChannel, arrChannels[nChannel].ChannelEnabled ? 0 : 1, 0.1);
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            // Check number of tracks
            int nTracks = 0;
            m_pMAudio.AudioTracksGetCount(out nTracks);
            if (nTracks <= 0)
            {
                this.Enabled = false;
                m_pMAudioTrack = null;
                return;
            }
            //else if (comboBoxTrack.Items.Count != nTracks)
            //{
            //    m_nCurrentTrack = Math.Min(nTracks - 1, m_nCurrentTrack);
            //    FillTracks();
            //    UpdateControl(m_nCurrentTrack);
            //}


            if (m_pMAudioTrack != null)
            {
                try
                {
                    // TODO: use loudOut.nValidChannels
//                     int nChIn, nChOut, nChOutIdx;
//                     m_pMAudioTrack.TrackChannelsGet(out nChIn, out nChOutIdx, out nChOut);
//                     if (nChOut != arrChannels.Length)
//                     {
//                         UpdateControl(comboBoxTrack.SelectedIndex);
//                     }


                    M_AUDIO_TRACK_LOUDNESS loudOrg;
                    M_AUDIO_TRACK_LOUDNESS loudOut;
                    m_pMAudioTrack.TrackLoudnessGet(out loudOrg, out loudOut);

                    // Get number of channels
                    int nChIn, nChOut, nChOutIdx;
                    m_pMAudioTrack.TrackChannelsGet(out nChIn, out nChOutIdx, out nChOut);

                    if (nChOut != arrChannels.Length)
                    {
                        UpdateControl();
                    }

                    for (int i = 0; i < arrChannels.Length; i++)
                    {
                        if (i >= loudOut.nValidChannels)
                        {
                            arrChannels[i].Level = -60;
                            arrChannels[i].LevelOrg = -60;
                            arrChannels[i].Invalidate();
                            arrChannels[i].Enabled = false;
                        }
                        else
                        {
                            arrChannels[i].Level = loudOut.arrVUMeter[i];
                            arrChannels[i].LevelOrg = loudOrg.arrVUMeter[i]; // Original
                            arrChannels[i].Invalidate();
                            arrChannels[i].Enabled = true;
                        }
                        
                    }
                }
                catch (System.Exception ex)
                {
                    // If number of tracks changed or e.g. playlist loaded -> the current track may be not valid
                    UpdateControl();
                }
            }
        }

        
        private void MAudioMeter_Paint(object sender, PaintEventArgs e)
        {
            int nIndent = 0;

            float fMax = this.Bounds.Height - mAudioCh1.Width - Font.Height / 2.0f;

            string[] pLevel = new string[] { "0dB", "-10", "-20", "-30", "-60" };
            string[] pGain = new string[] { "+20", "+10", "0dB", "-10", "-20" };

            float fStep = fMax / (pLevel.Length - 1);

            RectangleF rcBG_Block = new RectangleF(0, Font.Height / 2.0f, Bounds.Width, fStep);
            //             Brush brBG_1 = new LinearGradientBrush(rcBG_Block, this.BackColor, this.BackColorHi, LinearGradientMode.Horizontal);
            //             Brush brBG_2 = new LinearGradientBrush(rcBG_Block, this.BackColorHi, this.BackColor, LinearGradientMode.Horizontal);
            Brush brBG_1 = new SolidBrush(this.BackColorHi);
            Brush brBG_2 = new SolidBrush(this.BackColor);


            Brush brText = new SolidBrush(this.ForeColor);

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Far;

            fLeftIndent = 0;
            fRightIndent = 0;
            RectangleF rcString = new RectangleF(0, 0, Bounds.Width, Font.Height);
            for (int i = 0; i < pLevel.Length; i++)
            {
                rcString.Y = nIndent + fStep * i;

                rcBG_Block.Y = nIndent + fStep * i + Font.Height / 2.0f;
                e.Graphics.FillRectangle(i % 2 == 0 ? brBG_1 : brBG_2, rcBG_Block);

                // For VU indent
                float fWidth = e.Graphics.MeasureString(pLevel[i], Font).Width;
                fLeftIndent = fLeftIndent < fWidth ? fWidth : fLeftIndent;

                fWidth = e.Graphics.MeasureString(pGain[i], Font).Width;
                fRightIndent = fRightIndent < fWidth ? fWidth : fRightIndent;

                e.Graphics.DrawString(pLevel[i], this.Font, brText, rcString);
                e.Graphics.DrawString(pGain[i], this.Font, brText, rcString, strFormat);
            }


        }

        private void MAudioMeter_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

       
    }
}
