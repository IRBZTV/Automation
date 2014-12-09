using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MLCHARGENLib;

namespace MControls
{
    public partial class FormCG_XML : Form
    {
        public FormCG_XML()
        {
            InitializeComponent();
        }

        public IMLCharGen m_pMLCharGen;
        public string m_strItemID;

        private void FormCG_XML_Load(object sender, EventArgs e)
        {
            try
            {
                string strItemDesc;
                m_pMLCharGen.GetItemProperties(m_strItemID, "", out strItemDesc);
                textBoxXML.Text = strItemDesc;
            }
            catch (System.Exception){}
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            m_pMLCharGen.SetItemProperties(m_strItemID, "", textBoxXML.Text, "", 0);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            m_pMLCharGen.SetItemProperties(m_strItemID, "", textBoxXML.Text, "", 0);
        }
    }
}