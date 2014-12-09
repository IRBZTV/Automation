using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class FormLive2 : Form
    {
        public FormLive2()
        {
            InitializeComponent();
        }

        public IMDevice m_pDevice;

        private void buttonInit_Click(object sender, EventArgs e)
        {
            try
            {
                ((IMObject)m_pDevice).ObjectStart(null);
            }
            catch (System.Exception) { }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            try
            {
                ((IMObject)m_pDevice).ObjectClose();
            }
            catch (System.Exception) { }
        }

        private void FormLive2_Load(object sender, EventArgs e)
        {
            mDeviceControl1.SetControlledObject(m_pDevice);
            mFormatControlIn.SetControlledObject(m_pDevice);
            mFormatControlOut.SetControlledObject(m_pDevice);
            mPreviewControl1.SetControlledObject(m_pDevice);
        }

        private void mDeviceControl1_MDeviceChanged(object sender, EventArgs e)
        {
            // Update format
            mFormatControlIn.SetControlledObject(m_pDevice);
            mFormatControlOut.SetControlledObject(m_pDevice);
        }

        
    }
}