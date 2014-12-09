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
    public partial class MConfigList : ListViewEx
    {
        IMConfig m_pConfigRoot;

        public event EventHandler OnConfigChanged;

        public MConfigList()
        {
            InitializeComponent();

            Columns[1].Tag = new ComboBox();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pConfigRoot;
            try
            {
                m_pConfigRoot = (IMConfig)pObject;

                UpdateList();
            }
            catch (System.Exception) { }

            return pOld;
        }

        void UpdateList()
        {
            Items.Clear();
            Focus();

            int nCount = 0;
            m_pConfigRoot.ConfigTypesGetCount(out nCount);
            for (int i = 0; i < nCount; i++)
            {
                string strType;
                m_pConfigRoot.ConfigTypesGetByIndex(i, out strType);

                UpdateType(m_pConfigRoot, strType);
            }

            for (int i = 0; i < Columns.Count; i++)
            {
                Columns[i].Width = -2;
            }
        }

        void UpdateType(IMConfig pConfig, string sType)
        {
            ListViewItem lvItem = AddNewItem(sType, 0);
            ComboBox pCombo = (ComboBox)lvItem.SubItems[1].Tag;

            int nCount = 0;
            pConfig.ConfigGetCount(sType, out nCount);
            for (int i = 0; i < nCount; i++)
            {
                string strName;
                pConfig.ConfigGetByIndex(sType, i, out strName);

                pCombo.Items.Add(strName);
            }

            string strNameSel;
            IMAttributes pConfigProps;
            pConfig.ConfigGet(sType, out strNameSel, out pConfigProps);
            lvItem.Tag = pConfigProps; // Used for additional column attibutes
            if (pCombo.Items.Count > 0 && strNameSel != null)
            {
                int nIndex = pCombo.FindStringExact(strNameSel);
                pCombo.SelectedIndex = nIndex >= 0 ? nIndex : 0;
            }

            pCombo.Enabled = pCombo.Items.Count > 1 ? true : false;

            if (pConfigProps != null)
            {
                // Update attributes

                for (int i = 2; i < Columns.Count; i++)
                {
                    int nHave = 0;
                    string strValue = null;
                    string strAttrName = Columns[i].Text;

                    if (Columns[i].Tag != null && Columns[i].Tag.GetType().Name == "String")
                        strAttrName = (string)Columns[i].Tag;

                    pConfigProps.AttributesHave(strAttrName, out nHave, out strValue);
                    if (strValue != null)
                    {
                        while (lvItem.SubItems.Count <= i)
                        {
                            lvItem.SubItems.Add("");
                        }

                        lvItem.SubItems[i].Text = strValue;
                        lvItem.SubItems[i].Tag = new TextBox();
                    }
                    else if (lvItem.SubItems.Count > i)
                    {
                        // For now allow edit
                        lvItem.SubItems[i].Tag = null;
                    }


                }
            }
        }

        private void MConfigList_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvEvent = (ListViewEx_EventArgs)e;

            if (lvEvent.nSubItem == 1)
            {
                string strNameSel;
                IMAttributes pConfigProps;
                m_pConfigRoot.ConfigGet(lvEvent.lvItem.SubItems[0].Text, out strNameSel, out pConfigProps);

                if (strNameSel != lvEvent.lvSubItem.Text)
                {
                    m_pConfigRoot.ConfigSet(lvEvent.lvItem.SubItems[0].Text, lvEvent.lvSubItem.Text, out pConfigProps);

                    // The list could be changed
                    // TODO: Keep selection
                    UpdateList();

                    if (this.OnConfigChanged != null)
                        OnConfigChanged(this, e);
                }
            }
            else if (lvEvent.nSubItem > 1)
            {
                IMAttributes pConfigProps = (IMAttributes)lvEvent.lvItem.Tag;

                // The attribute name could be column name or tag (for allow to set user-friendly columns names)
                string strAttrName = Columns[lvEvent.nSubItem].Text;
                if (Columns[lvEvent.nSubItem].Tag != null && Columns[lvEvent.nSubItem].Tag.GetType().Name == "String")
                    strAttrName = (string)Columns[lvEvent.nSubItem].Tag;

                pConfigProps.AttributesStringSet(strAttrName, lvEvent.lvSubItem.Text);

                if (this.OnConfigChanged != null)
                    OnConfigChanged(this, e);
            }
        }

        private void MConfigList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItems.Count > 0)
            {
                string strNameSel;
                IMAttributes pConfigProps;
                m_pConfigRoot.ConfigGet(SelectedItems[0].SubItems[0].Text, out strNameSel, out pConfigProps);

				try
				{
					IMAttributes attr = (IMAttributes)pConfigProps;
					int nCount;
					attr.AttributesInfoGetCount(out nCount);
				}
				catch (System.Exception ex)
				{
					
				}
				

                // We show attributes for selected item 
                FormAttributes formAttributes = new FormAttributes();
                formAttributes.Text = strNameSel;
                formAttributes.m_pAttributes = pConfigProps;
                formAttributes.FixedItems = true;

                formAttributes.ShowDialog();

                if (this.OnConfigChanged != null)
                    OnConfigChanged(this, e);

                UpdateList();

            }
        }
        
    }
}
