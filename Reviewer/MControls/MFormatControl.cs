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
    public partial class MFormatControl : UserControl
    {
        private IMFormat m_pMFormat;
        public bool m_bTextDescription = false;
        public eMFormatType m_eFormatType = eMFormatType.eMFT_Convert;
        private int startVideoFormat;
        private int startAudioFormat;

        public MFormatControl()
        {
            InitializeComponent();
        }

        public bool MInputFormat
        {
            get { return m_eFormatType == eMFormatType.eMFT_Input ? true : false; }
            set { m_eFormatType = value ? eMFormatType.eMFT_Input : eMFormatType.eMFT_Convert; }
        }

        public bool MTextFormatDescription
        {
            get { return m_bTextDescription; }
            set { m_bTextDescription = value; }
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMFormat;
            try
            {
                m_pMFormat = (IMFormat)pObject;

                UpdateFormats();
            }
            catch (System.Exception) { }

            return pOld;
        }

        void UpdateFormats()
        {
            comboBoxAudio.Items.Clear();
            comboBoxVideo.Items.Clear();
            if (m_pMFormat != null)
            {
                FillVideoFormats();
                FillAudioFormats();

                comboBoxVideo.SelectedIndex = startVideoFormat;
                comboBoxAudio.SelectedIndex = startAudioFormat;
            }
        }

        void FillVideoFormats()
        {
            try
            {
                int nIndex;
                string strFormat;
                M_VID_PROPS vidProps;
                comboBoxVideo.Items.Clear();

                int nCount = 0;
                m_pMFormat.FormatVideoGetCount(m_eFormatType, out nCount);

                for (int i = 0; i < nCount; i++)
                {
                    m_pMFormat.FormatVideoGetByIndex(m_eFormatType, i, out vidProps, out strFormat);
		    if (vidProps.eVideoFormat == eMVideoFormat.eMVF_HD1080_50i) startVideoFormat = i;

                    if (m_bTextDescription)
                        comboBoxVideo.Items.Add(strFormat);
                    else
                        comboBoxVideo.Items.Add(vidProps.eVideoFormat);
                }

                m_pMFormat.FormatVideoGet(m_eFormatType, out vidProps, out nIndex, out strFormat);
                comboBoxVideo.SelectedIndex = nIndex;
            }
            catch (System.Exception){}
        }

        void FillAudioFormats()
        {
            try
            {
                int nIndex;
                string strFormat;
                M_AUD_PROPS audProps;
                comboBoxAudio.Items.Clear();

                int nCount = 0;
                m_pMFormat.FormatAudioGetCount(m_eFormatType, out nCount);

                for (int i = 0; i < nCount; i++)
                {
                    m_pMFormat.FormatAudioGetByIndex(m_eFormatType, i, out audProps, out strFormat);
                    if (audProps.nBitsPerSample == 16 && audProps.nChannels == 2 && audProps.nSamplesPerSec == 48000) startAudioFormat = i;
                    // For audio always text desc
                    comboBoxAudio.Items.Add(strFormat);
                }

                m_pMFormat.FormatAudioGet(m_eFormatType,out audProps, out nIndex, out strFormat);
                comboBoxAudio.SelectedIndex = nIndex;
            }
            catch (System.Exception) { }
        }


        private void comboBoxVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                M_VID_PROPS vidProps = new M_VID_PROPS();
                if (m_bTextDescription)
                {
                    string strFormat;
                    m_pMFormat.FormatVideoGetByIndex(m_eFormatType, comboBoxVideo.SelectedIndex, out vidProps, out strFormat);
                }
                else
                {
                    vidProps.eVideoFormat = (eMVideoFormat)comboBoxVideo.SelectedItem;
                }

                // TODO: FCC Selection
                // vidProps.fccType = eMFCC.eMFCC_UYVY;
                //vidProps.eScaleType = eMScaleType.eMST_LetterBox;
                m_pMFormat.FormatVideoSet(m_eFormatType, ref vidProps);
            }
            catch (System.Exception)
            {
                FillVideoFormats();
            }
            
        }

        private void comboBoxAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                M_AUD_PROPS audProps = new M_AUD_PROPS();
                string strFormat;
                m_pMFormat.FormatAudioGetByIndex(m_eFormatType, comboBoxAudio.SelectedIndex, out audProps, out strFormat);
                m_pMFormat.FormatAudioSet(m_eFormatType, ref audProps);
            }
            catch (System.Exception)
            {
                FillAudioFormats();
            }
        }
    }
}
