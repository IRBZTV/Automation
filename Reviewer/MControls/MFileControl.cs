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
    public partial class MFileControl : UserControl
    {
        public MFileControl()
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
                m_pFile.FileStateGet(out eState);

                labelState.Text = eState.ToString();
            }
            catch (System.Exception) { }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_pFile != null)
                    m_pFile.FilePlayStart();
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
                    m_pFile.FilePlayStop();
            }
            catch (System.Exception) { }
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_pFile != null)
                    m_pFile.FilePosSet((double)numericRew.Value, 1.0);
            }
            catch (System.Exception) { }
        }

        private void timerState_Tick(object sender, EventArgs e)
        {
            UpdateState();
        }
    }
}
