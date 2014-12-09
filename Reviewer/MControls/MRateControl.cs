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
    public partial class MRateControl : UserControl
    {
        private IMFile m_pMFile;

        public MRateControl()
        {
            InitializeComponent();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMFile;
            try
            {
                m_pMFile = (IMFile)pObject;

                UpdateRate();
            }
            catch (System.Exception) { }

            return pOld;
        }

        void UpdateRate()
        {
            try
            {
                double dblRate;
                m_pMFile.FileRateGet( out dblRate );
                trackBarRate.Value = (int)(dblRate / 5.0 * trackBarRate.Maximum + 0.5);
                labelRate.Text = (dblRate).ToString("0.0%");
            }
            catch (System.Exception){}
        }

        private void trackBarRate_Scroll(object sender, EventArgs e)
        {
            try
            {
                double dblRate = (double)trackBarRate.Value * 5.0 / trackBarRate.Maximum;
                m_pMFile.FileRateSet(dblRate);
                labelRate.Text = (dblRate).ToString("0.0%");
            }
            catch (System.Exception) { }
        }

        private void trackBarRate_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int nTBPadding = 14;
                double dblPos = (double)(e.Location.X - nTBPadding) / (trackBarRate.Width - nTBPadding * 2);
                dblPos = dblPos > 0 ? dblPos < 1.0 ? dblPos : 1.0 : 0;
                trackBarRate.Value = trackBarRate.Minimum + (int)((trackBarRate.Maximum - trackBarRate.Minimum )* dblPos + 0.5);

                // For update rate
                trackBarRate_Scroll(sender, e);
            }
            catch (System.Exception) { }
        }

        private void buttonRev10_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(-10.0);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonRev2_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(-2.0);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonRev_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(-1.0);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonRev05_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(-0.5);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonFwd05_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(0.5);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonFwd_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(1.0);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonFwd20_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(2.0);
                UpdateRate();
            }
            catch (System.Exception) { }
        }

        private void buttonFwd10_Click(object sender, EventArgs e)
        {
            try
            {
                m_pMFile.FileRateSet(10.0);
                UpdateRate();
            }
            catch (System.Exception) { }
        }
    }
}
