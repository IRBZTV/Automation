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
    public partial class FileNameForm : Form
    {
        public IMFile m_pFile;

        public FileNameForm()
        {
            InitializeComponent();
        }

        private void FileNameForm_Load(object sender, EventArgs e)
        {
            mFileNameControl1.SetControlledObject(m_pFile);
        }
    }
}