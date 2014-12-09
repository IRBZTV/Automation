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
    public partial class FormFileName : Form
    {
        public IMFile m_pFile;

        public FormFileName()
        {
            InitializeComponent();
        }

        private void FileNameForm_Load(object sender, EventArgs e)
        {
            mFileNameControl1.SetControlledObject(m_pFile);
            mPropsControl1.SetControlledObject(m_pFile);
        }

        private void FormFileName_FormClosing(object sender, FormClosingEventArgs e)
        {
            mFileNameControl1.SetControlledObject(null);
            mPropsControl1.SetControlledObject(null);
        }
    }
}