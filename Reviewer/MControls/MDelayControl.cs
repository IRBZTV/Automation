using System;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class MDelayControl : UserControl
    {
        private IMFile m_pMFile;

        public MDelayControl()
        {
            InitializeComponent();
        }

        // Common controls methods
        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMFile;
            try
            {
                m_pMFile = (IMFile)pObject;

                UpdateDelay();
            }
            catch (System.Exception) { }

            return pOld;
        }

        void UpdateDelay()
        {
            try
            {
                IMProps pProps = (IMProps)m_pMFile;
                string sValue;
                pProps.PropsGet("object::mdelay.enabled", out sValue);
                if (sValue == "true" || sValue == "1")
                    checkBoxDelay.Checked = true;
                else
                    checkBoxDelay.Checked = false;

                pProps.PropsGet("object::mdelay.buffer_duration", out sValue);  // The value in seconds


                pProps.PropsGet("object::mdelay.quality", out sValue);
                numericDelayQuality.Value = Decimal.Parse(sValue);

                pProps.PropsGet("object::mdelay.available", out sValue);
                numericDelayTime.Value = Decimal.Parse(sValue);
                trackBarSeek.Minimum = -1 * (int)Decimal.Parse(sValue);
                trackBarSeek.TickFrequency = -1 * trackBarSeek.Minimum / 20;

                pProps.PropsGet("object::mdelay.time", out sValue);
                numericPos.Value = Decimal.Parse(sValue);
                trackBarSeek.Value = -1 * Int32.Parse(sValue);
            }
            catch (System.Exception) { }
        }

        void UpdatePos()
        {
            try
            {
                IMProps pProps = (IMProps)m_pMFile;
                string sValue;

                pProps.PropsGet("object::mdelay.available", out sValue);
                numericDelayTime.Value = Decimal.Parse(sValue);
                trackBarSeek.Minimum = -1 * (int)Decimal.Parse(sValue);
                trackBarSeek.TickFrequency = -1 * trackBarSeek.Minimum / 20;

                pProps.PropsGet("object::mdelay.time", out sValue);
                trackBarSeek.Value = -1 * Int32.Parse(sValue);
            }
            catch (System.Exception) { }
        }

        private void checkBoxDelay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pMFile;
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
                IMProps pProps = (IMProps)m_pMFile;
                pProps.PropsSet("object::mdelay.quality", numericDelayQuality.Value.ToString());
            }
            catch (System.Exception) { }
        }

        private void numericPos_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pMFile;
                pProps.PropsSet("object::mdelay.time", numericPos.Value.ToString("0.0"));
                trackBarSeek.Value = -1 * (int)numericPos.Value;
            }
            catch (System.Exception) { }
        }

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            try
            {
                IMProps pProps = (IMProps)m_pMFile;
                pProps.PropsSet("object::mdelay.time", (-1 * trackBarSeek.Value).ToString());
                numericPos.Value = -1 * trackBarSeek.Value;
            }
            catch (System.Exception) { }
        }

        private void timerDelay_Tick(object sender, EventArgs e)
        {
            UpdatePos();
        }

    }
}



