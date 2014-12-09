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
    public partial class FormAttributes : Form
    {
        public IMAttributes m_pAttributes;

        public FormAttributes()
        {
            InitializeComponent();
        }

        public bool FixedItems
        {
            get { return mAttributesList1.FixedItems; }
            set { mAttributesList1.FixedItems = value; }
        }

        private void FormAttributes_Load(object sender, EventArgs e)
        {
            // Temp fix (TODO: make default via default values)
            //mAttributesList1.strDefaultTypes = null;
            //mAttributesList1.strDefaultAttributes = null;
            //mAttributesList1.bShowDefaultAttributes = false;
            //mAttributesList1.BShowDefaultTypes = false;

            mAttributesList1.SetControlledObject(m_pAttributes);
        }

        private void mAttributesList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update help
            if (mAttributesList1.SelectedIndices.Count > 0)
            {
                string strName = mAttributesList1.SelectedItems[0].SubItems[0].Text;

                string strHelp;
                m_pAttributes.AttributesInfoGet(strName, MPLATFORMLib.eMInfoType.eMIT_Help, out strHelp);
                textBoxHelp.Text = strHelp;
            }
        }
    }
}