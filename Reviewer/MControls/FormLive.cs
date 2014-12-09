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
    public partial class FormLive : Form
    {
        public FormLive()
        {
            InitializeComponent();
        }

        public IMDevice m_pDevice;

        private void FormLive_Load(object sender, EventArgs e)
        {
            mLiveControl1.SetControlledObject(m_pDevice);
            mPreviewControl1.SetControlledObject(m_pDevice);
            
        }

        private void FormLive_FormClosing(object sender, FormClosingEventArgs e)
        {
            mPreviewControl1.SetControlledObject(null);
            mLiveControl1.SetControlledObject(null);
            m_pDevice = null;
            GC.Collect();
        }
    }
}