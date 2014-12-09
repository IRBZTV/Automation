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
    public partial class MFileStateControl : UserControl
    {
        public MFileStateControl()
        {
            InitializeComponent();
        }

        private IMFile m_pFile;

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pFile;
            try
            {
                m_pFile = (IMFile)pObject;

                UpdateState();
            }
            catch (System.Exception){}

            return pOld;
        }

        public void UpdateState()
        {
            try
            {
                eMState eState;
                double dblTime;
                m_pFile.FileStateGet(out eState, out dblTime);

                labelState.Text = eState.ToString();
                if (dblTime > 0)
                    labelState.Text += "(" + dblTime.ToString("0.000") + ")";
                    
            }
            catch (System.Exception) { }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_pFile != null)
                {
                    // Check for emty file
                    string strPath;
                    m_pFile.FileNameGet(out strPath);
                    if (strPath == null )
                    {
                        OpenFileDialog openDlg = new OpenFileDialog();
                        if (openDlg.ShowDialog() == DialogResult.OK)
                        {
                            m_pFile.FileNameSet(openDlg.FileName, "");
                        }
                    }

                    m_pFile.FilePlayStart();
                }
            }
            catch (System.Exception) { }
            
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_pFile != null)
                    m_pFile.FilePlayPause(0);
            }
            catch (System.Exception) { }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_pFile != null)
                    m_pFile.FilePlayStop(0);
            }
            catch (System.Exception) { }
        }

        private void timerState_Tick(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}
