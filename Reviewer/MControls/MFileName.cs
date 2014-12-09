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
    public partial class MFileName : UserControl
    {
        private IMFile m_pFile;

        public MFileName()
        {
            InitializeComponent();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pFile;
            try
            {
                m_pFile = (IMFile)pObject;

                UpdateControl();
            }
            catch (System.Exception){}

            return pOld;
        }

        public void UpdateControl()
        {
            try
            {
                // Get path
                string strPath, strProps, strInfo;
                m_pFile.FileNameGet(out strPath);

                textBoxPath.Text = strPath;


                // Get In/Out
                double dblIn, dblOut, dblLen;
                m_pFile.FileInOutGet(out dblIn, out dblOut, out dblLen);

                numericIn.Value = (decimal)dblIn;
                numericOut.Value = (decimal)dblOut;
                numericLen.Value = (decimal)dblLen;

                // Get loop
                string sLoop;
                ((IMProps)m_pFile).PropsGet("loop", out sLoop);
                checkBoxLoop.Checked = (sLoop != null && sLoop != "" && sLoop != "0" && sLoop != "false");
            }
            catch (System.Exception){}
        }

        private void ChangeFileName(string sType)
        {
            if (textBoxPath.Text == "")
                BrowseForFile();
            
            if (textBoxPath.Text != "")
            {
                // For In/Out
                string sProps = "In=" + numericIn.Value.ToString() + " Out=" + numericOut.Value.ToString();

                if (textBoxProps.Text != "" && textBoxProps.Text[0] != '<')
                    sProps += " " + textBoxProps.Text;

                try
                {
                    if (sType != "")
                        sProps = "change_type='" + sType + "' " + sProps;
                    m_pFile.FileNameSet(textBoxPath.Text, sProps);


                    UpdateControl();
                }
                catch (System.Exception ex) { }
            }
        }

        private void BrowseForFile()
        {
            // TODO: Add filter with media extension
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = openDlg.FileName;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFile();
        }

        private void buttonSetName_Click(object sender, EventArgs e)
        {
            ChangeFileName("");
        }

        private void buttonBreak_Click(object sender, EventArgs e)
        {
            ChangeFileName("break");
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            ChangeFileName("next");
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            ChangeFileName("replace");
        }

        private void buttonSetInOut_Click(object sender, EventArgs e)
        {
            try
            {
                m_pFile.FileInOutSet((double)numericIn.Value, (double)numericOut.Value);
            }
            catch (System.Exception) { }
        }

        private void checkBoxLoop_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ((IMProps)m_pFile).PropsSet("loop", checkBoxLoop.Checked ? "true" : "false" );
            }
            catch (System.Exception) { }
        }

        private void textBoxProps_Enter(object sender, EventArgs e)
        {
            if (textBoxProps.Text[0] == '<')
            {
                textBoxProps.Text = "";
                textBoxProps.ForeColor = Color.Black;
            }
        }

        private void textBoxProps_Leave(object sender, EventArgs e)
        {
            if (textBoxProps.Text == "")
            {
                textBoxProps.Text = "<new file properties here>";
                textBoxProps.ForeColor = Color.DarkGray;
            }
        }
    }
}