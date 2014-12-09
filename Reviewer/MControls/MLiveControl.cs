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
    public partial class MLiveControl : UserControl
    {
        IMDevice m_pDevice;
		MLive ml;
        public MLiveControl()
        {
            InitializeComponent();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pDevice;
            try
            {
                if (pObject == null) timerDelay.Enabled = false;
                m_pDevice = (IMDevice)pObject;

                if (!FillCombo("video", comboBoxVideo))
                    FillCombo("audio", comboBoxAudio);

                mPropsControl1.SetControlledObject(pObject);

                UpdateDelay();
            }
            catch (System.Exception) { }

            return pOld;
        }

        

        /// <summary>
        /// Fill combo boxes (Audio/Video device and Audio/Video input line (if available))
        /// </summary>
        /// <param name="pDevice"></param>
        /// <param name="strType"></param>
        /// <param name="cbxType"></param>
        private bool FillCombo(string strType, ComboBox cbxType)
        {
            cbxType.Items.Clear();
            cbxType.Tag = strType;
            int nCount = 0;
            //Get device count / input line count
            m_pDevice.DeviceGetCount(0, strType, out nCount);
            cbxType.Enabled = nCount > 0;
            if (nCount <= 0)
                return false;

            {
                for (int i = 0; i < nCount; i++)
                {
                    string strName;
                    string strDesc;
                    //Get deveice / input line
                    m_pDevice.DeviceGetByIndex(0, strType, i, out strName, out strDesc);
                    cbxType.Items.Add(strName);
                }
                string strCur = "";
                string strParam = "";
                int nIndex = 0;
                try
                {
                    //Check if there is already selected device / input line
                    m_pDevice.DeviceGet(strType, out strCur, out strParam, out nIndex);
                    if (strCur != "")
                    {
                        cbxType.SelectedIndex = cbxType.FindStringExact(strCur);
                    }
                    else cbxType.SelectedIndex = 0;
                }
                catch
                {
                    cbxType.SelectedIndex = 0;
                }
            }

            return true;
        }

        /// <summary>
        /// Fill combo boxes (Audio / Video format)
        /// </summary>
        /// <param name="pDevice"></param>
        /// <param name="strType"></param>
        /// <param name="cbxTarget"></param>
        private void FillComboFomat(IMDevice pDevice, string strType, ComboBox cbxTarget)
        {
            if (strType == "video")
            {
                int nCount = 0;
                int nIndex;
                string strFormat;
                M_VID_PROPS vidProps;
                cbxTarget.Items.Clear();
                //Get video format count
                ((IMFormat)m_pDevice).FormatVideoGetCount(eMFormatType.eMFT_Input,out nCount);
                cbxTarget.Enabled = nCount > 0;
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        //Get format by index
                        ((IMFormat)m_pDevice).FormatVideoGetByIndex(eMFormatType.eMFT_Input, i, out vidProps, out strFormat);
                        //                        cbxTarget.Items.Add(vidProps.eVideoFormat);
                        cbxTarget.Items.Add(strFormat);

                    }
                    //Check if there is selected format
                    ((IMFormat)m_pDevice).FormatVideoGet(eMFormatType.eMFT_Input, out vidProps, out nIndex, out strFormat);
                    if (nIndex > 0)
                        cbxTarget.SelectedIndex = nIndex;
                    else cbxTarget.SelectedIndex = 0;
                }

            }
            else if (strType == "audio")
            {
                int nCount = 0;
                int nIndex;
                string strFormat;
                M_AUD_PROPS audProps;
                cbxTarget.Items.Clear();
                //Get video format count
                ((IMFormat)m_pDevice).FormatAudioGetCount(eMFormatType.eMFT_Input, out nCount);
                cbxTarget.Enabled = nCount > 0;
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        //Get audio format
                        ((IMFormat)m_pDevice).FormatAudioGetByIndex(eMFormatType.eMFT_Input, i, out audProps, out strFormat);
                        cbxTarget.Items.Add(strFormat);
                    }
                    //Check if there is selected format
                    ((IMFormat)m_pDevice).FormatAudioGet(eMFormatType.eMFT_Input, out audProps, out nIndex, out strFormat);
                    if (nIndex > 0)
                        cbxTarget.SelectedIndex = nIndex;
                    else cbxTarget.SelectedIndex = 0;
                }
            }
            cbxTarget.Tag = strType;
        }

        /// <summary>
        /// Device / input line changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbxChanged = (ComboBox)sender;
            string strType = (string)cbxChanged.Tag;
            //Set device
            m_pDevice.DeviceSet(strType, (string)cbxChanged.SelectedItem, "");
            if (strType == "video")
            {
                // Update audio
                FillCombo("audio", comboBoxAudio);
                // Update input lines
                FillCombo(strType + "::line-in", comboBoxVL);
                //Update Formats
                FillComboFomat(m_pDevice, strType, comboBoxVF);
            }
            else if (strType == "audio")
            {
                // Update Lines
                FillCombo(strType + "::line-in", comboBoxAL);
                //Update Formats
                FillComboFomat(m_pDevice, strType, comboBoxAF);
            }
        }

        /// <summary>
        /// Format changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbxChanged = (ComboBox)sender;
            string strType = (string)cbxChanged.Tag;

            if (strType == "video")
            {
                M_VID_PROPS vidProps = new M_VID_PROPS();
                string strFormat;
                ((IMFormat)m_pDevice).FormatVideoGetByIndex(eMFormatType.eMFT_Input, cbxChanged.SelectedIndex, out vidProps, out strFormat);
                //Set new video format
                ((IMFormat)m_pDevice).FormatVideoSet(eMFormatType.eMFT_Input, ref vidProps);
            }
            else if (strType == "audio")
            {
                M_AUD_PROPS audProps = new M_AUD_PROPS();
                string strFormat;
                ((IMFormat)m_pDevice).FormatAudioGetByIndex(eMFormatType.eMFT_Input, cbxChanged.SelectedIndex, out audProps, out strFormat);
                //Set new audio format
                ((IMFormat)m_pDevice).FormatAudioSet(eMFormatType.eMFT_Input, ref audProps);
            }
        }

        /// <summary>
        /// Close current live source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            ((IMObject)m_pDevice).ObjectClose();
        }

        /// <summary>
        /// Show video device properties (if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonV_Click(object sender, EventArgs e)
        {
            try
            {
                m_pDevice.DeviceShowProps("video", "device", 0);
            }
            catch { }
        }

        /// <summary>
        /// Show audio device properties (if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonA_Click(object sender, EventArgs e)
        {
            try
            {
                m_pDevice.DeviceShowProps("audio", "device", 0);
            }
            catch { }
        }

        /// <summary>
        /// Show video format properties (if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVF_Click(object sender, EventArgs e)
        {
            try
            {
                m_pDevice.DeviceShowProps("video", "stream", 0);
            }
            catch { }
        }

        /// <summary>
        /// Show audio format properties(if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAF_Click(object sender, EventArgs e)
        {
            try
            {
                m_pDevice.DeviceShowProps("audio", "stream", 0);
            }
            catch { }
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            ((IMObject)m_pDevice).ObjectStart(null);
        }

        //////////////////////////////////////////////////////////////////////////
        // Delay impl.

        void UpdateDelay()
        {
            try
            {
                IMProps pProps = (IMProps)m_pDevice;
                string sValue = string.Empty;
                pProps.PropsGet("object::mdelay.enabled", out sValue);
                if (sValue == "true" || sValue == "1")
                    checkBoxDelay.Checked = true;
                else
                    checkBoxDelay.Checked = false;

                pProps.PropsGet("object::mdelay.buffer_duration", out sValue);  // The value in seconds
                

                pProps.PropsGet("object::mdelay.quality", out sValue);
                numericDelayQuality.Value = Decimal.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);

                pProps.PropsGet("object::mdelay.available", out sValue);
                numericDelayTime.Value = Decimal.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);
                trackBarSeek.Minimum = -1 * (int)Decimal.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);
                trackBarSeek.TickFrequency = -1 * trackBarSeek.Minimum / 20;

                pProps.PropsGet("object::mdelay.time", out sValue);
                numericPos.Value = Decimal.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);
                trackBarSeek.Value = -1 * Int32.Parse(sValue, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture);

                pProps.PropsGet("object::mdelay.live_preview", out sValue);
                if (sValue != null && sValue != string.Empty && sValue == "true")
                    comboPreviewType.SelectedIndex = 1;
                else
                    comboPreviewType.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {

            }
        }

        void UpdatePos()
        {
            try
            {
                IMProps pProps = (IMProps)m_pDevice;
                string sValue;
                
                pProps.PropsGet("object::mdelay.available", out sValue);
                numericDelayTime.Value = Decimal.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);
                trackBarSeek.Minimum = -1 * (int)Decimal.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);
                trackBarSeek.TickFrequency = -1 * trackBarSeek.Minimum / 20;

                pProps.PropsGet("object::mdelay.time", out sValue);
                trackBarSeek.Value = -1 * Int32.Parse(sValue, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.Exception) { }
        }


        private void checkBoxDelay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pDevice;
                pProps.PropsSet("object::mdelay.enabled", checkBoxDelay.Checked ? "true" : "false");

                numericPos.Enabled = checkBoxDelay.Checked;
                trackBarSeek.Enabled = checkBoxDelay.Checked;
                timerDelay.Enabled = checkBoxDelay.Checked;
            }
            catch (System.Exception) { }
        }

        private void numericDelayQuality_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pDevice;
                pProps.PropsSet("object::mdelay.quality", numericDelayQuality.Value.ToString() );
            }
            catch (System.Exception) { }
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pDevice;
                pProps.PropsSet("object::mdelay.time", (-1 * trackBarSeek.Value).ToString());
                numericPos.Value = -1 * trackBarSeek.Value;
            }
            catch (System.Exception) { }
        }

        private void numericPos_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pDevice;
                pProps.PropsSet("object::mdelay.time", numericPos.Value.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture));
                trackBarSeek.Value = -1 * (int)numericPos.Value;
            }
            catch (System.Exception) { }
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            UpdatePos();
        }

        private void comboPreviewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_pDevice != null)
            {
                try
                {
                    IMProps pProps = (IMProps)m_pDevice;
                    if (comboPreviewType.SelectedIndex == 1)
                        pProps.PropsSet("object::mdelay.live_preview", "true");
                    else
                        pProps.PropsSet("object::mdelay.live_preview", "false");
                }
                catch (System.Exception) { }
            }
        }
       
    }
}
