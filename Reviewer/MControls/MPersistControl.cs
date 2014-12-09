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
    public partial class MPersistControl : UserControl
    {
        public MPersistControl()
        {
            InitializeComponent();
        }

        private IMPersist m_pMPersist;

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMPersist;
            try
            {
                m_pMPersist = (IMPersist)pObject;
            }
            catch (System.Exception) { }

            return pOld;
        }

        // Called if user change playlist selection
        public event EventHandler OnLoad;

        string strFilter = "";
        public string Filter
        {
            get { return strFilter; }
            set { strFilter = value; }
        }

        string strDefaultExt = "";
        public string DefaultExt
        {
            get { return strDefaultExt; }
            set { strDefaultExt = value; }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = strFilter;
            fileDialog.DefaultExt = strDefaultExt;

//             fileDialog.Filter = "MPlaylist Files (*.mpl, *.xml)|*.mpl;*.xml;*.mlp|All Files|*.*";
//             fileDialog.DefaultExt = ".xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                m_pMPersist.PersistSaveToFile("", fileDialog.FileName, "");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = strFilter;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                m_pMPersist.PersistLoad("", fileDialog.FileName, "");

                // Notify about playlist changing
                if (this.OnLoad != null)
                    this.OnLoad(this, e);
            }
        }
    }
}
