using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MControls
{
    public partial class FormInputElementContent : Form
    {
        private string strbasicContent;

        public string strBasicContent
        {
            get { return strbasicContent; }
            set { strbasicContent = value; }
        }

        private string strdemoContent;

        public string strDemoContent
        {
            get { return strdemoContent; }
            set { strdemoContent = value; }
        }
        private string stroutContent;

        public string strOutContent
        {
            get { return stroutContent; }
        }

        public FormInputElementContent()
        {
            InitializeComponent();
        }

        public FormInputElementContent(string _basicContent, string _demoContent)
        {
            InitializeComponent();
            strbasicContent = _basicContent;
            strdemoContent = _demoContent;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            stroutContent = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormInputElementContent_Load(object sender, EventArgs e)
        {
            bool bDemoContent = ControlsSettings.Default.DemoContent;
            if (bDemoContent)
            {
                textBox.Text = strDemoContent;
                checkBoxDemo.Checked = true;
            }
            else
            {
                textBox.Text = strBasicContent;
                checkBoxDemo.Checked = false;
            }

        }

        private void checkBoxDemo_CheckedChanged(object sender, EventArgs e)
        {
            ControlsSettings.Default.DemoContent = checkBoxDemo.Checked;
            if (checkBoxDemo.Checked)
                textBox.Text = strDemoContent;
            else
                textBox.Text = strBasicContent;
        }
    }
}