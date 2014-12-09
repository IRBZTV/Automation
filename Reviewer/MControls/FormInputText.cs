using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
    public partial class FormInputText : Form
    {
        private string strText;

        public string InputText
        {
            get { return strText; }
            set { strText = value; }
        }

        public FormInputText()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            strText = textBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                strText = textBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}