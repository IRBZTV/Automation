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
    public partial class MPropsControl : UserControl
    {
        IMProps m_pProps;
        private int m_nColumns = 2;

        public MPropsControl()
        {
            InitializeComponent();
        }

        // Called if playlist changed (files,added, removed, rearanged, etc.) 
        public event EventHandler OnPropsChanged;

        public int Columns
        {
            get
            {
                return m_nColumns;
            }
            set
            {
                m_nColumns = value;
            }
        }

        bool m_bSimple = false;
        public bool Simple
        {
            get { return m_bSimple; }
            set 
            { 
                m_bSimple = value;
                UpdateView();
            }
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pProps;
            try
            {
                m_pProps = (IMProps)pObject;

                UpdateView();
                UpdateCombo("<Root>", "");
            }
            catch (System.Exception)
            {
            }

            return pOld;
        }

        private void UpdateView()
        {
            if (m_bSimple)
            {
                listViewProps.Top = 0;
                listViewProps.Height = this.Height;
            }
            else
            {
                listViewProps.Top = textBoxNodeValue.Bottom + 4;
                listViewProps.Height = this.Height - textBoxNodeValue.Bottom + 4;
            }
        }

        private void MPropsControl_Load(object sender, EventArgs e)
        {
            if (m_nColumns <= 0)
                m_nColumns = 1;

            // Add columns
            for (int i = 0; i < m_nColumns; i++)
            {
                ColumnHeader hdrName = listViewProps.Columns.Add("Name");
                hdrName.Width = listViewProps.Width / (m_nColumns * 2) - 1;
                hdrName.Tag = new TextBox(); // For edit values

                ColumnHeader hdrValue = listViewProps.Columns.Add("Value");
                hdrValue.Width = listViewProps.Width / (m_nColumns * 2) - 1;
                hdrValue.Tag = new TextBox(); // For edit values
            }
            // TODO: Not allow to change the properties name
        }

        private string FullNodeName(string sNamePart)
        {
            string sParent = comboBoxParent.SelectedIndex > 0 ? comboBoxParent.SelectedItem.ToString() : "";
            if (sParent != "" && sNamePart != "")
                return sParent + "::" + sNamePart;

            return sParent + sNamePart;
        }

        private void UpdateCombo(string sSelString, string sParentRecurse)
        {
            if (sParentRecurse == "")
            {
                comboBoxParent.Items.Clear();
                comboBoxParent.Items.Add("<Root>");
            }

            int nCount = 0;
            try
            {
                m_pProps.PropsGetCount(sParentRecurse, out nCount);
            }
            catch (Exception) { }

            for (int i = 0; i < nCount; i++)
            {
                string sName;
                string sValue;
                int bNode = 0;
                m_pProps.PropsGetByIndex(sParentRecurse, i, out sName, out sValue, out bNode);
                if (bNode != 0)
                {
                    string sNext = sParentRecurse.Length > 0 ? sParentRecurse + "::" + sName : sName;
                    comboBoxParent.Items.Add(sNext);
                    UpdateCombo(sSelString, sNext);
                }
            }

            if (sParentRecurse == "")
            {
                if (sSelString != "")
                {
                    int nSel = comboBoxParent.FindStringExact(sSelString);
                    comboBoxParent.SelectedIndex = nSel;
                }
                else
                {
                    comboBoxParent.SelectedIndex = 0;
                }
            }
        }

        private void UpdateList(string sParent, bool _bResetList)
        {
            if (_bResetList)
                listViewProps.Items.Clear();

            int nCount = 0;
            try
            {
                m_pProps.PropsGetCount(FullNodeName(sParent), out nCount);
            }
            catch (Exception) { }

            for (int i = 0; i < nCount; i++)
            {
                string sName;
                string sValue;
                int bNode = 0;
                m_pProps.PropsGetByIndex(FullNodeName(sParent), i, out sName, out sValue, out bNode);

                string sRelName = sParent.Length > 0 ? sParent + "::" + sName : sName;
                if (bNode != 0)
                {
                    if (comboBoxParent.FindStringExact(FullNodeName(sRelName)) < 0)
                        comboBoxParent.Items.Add(sRelName);

                    if (sValue != null && sValue != "")
                        AddProps(sRelName, sValue);

                    if (checkBoxShowNested.Checked)
                        UpdateList(sRelName, false);
                }
                else
                {
                    AddProps(sRelName, sValue);
                }
            }

            if (_bResetList)
                AddProps("<New Props>", "");
        }


        private void AddProps(string sName, string sValue)
        {
            if (listViewProps.Items.Count == 0 || listViewProps.Items[listViewProps.Items.Count - 1].SubItems.Count >= m_nColumns * 2)
            {
                // Add new item
                ListViewItem lvItem = listViewProps.Items.Add(sName);
                lvItem.UseItemStyleForSubItems = false;
                
                ListViewItem.ListViewSubItem lvSubItemValue = lvItem.SubItems.Add(sValue);
                lvSubItemValue.ForeColor = Color.DarkBlue;
            }
            else
            {
                ListViewItem lvItem = listViewProps.Items[listViewProps.Items.Count - 1];
                ListViewItem.ListViewSubItem lvSubItemName = lvItem.SubItems.Add(sName);
                
                ListViewItem.ListViewSubItem lvSubItemValue = lvItem.SubItems.Add(sValue);
                lvSubItemValue.ForeColor = Color.DarkBlue;
            }
        }

        private void listViewProps_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;

            if (lvArg.nSubItem % 2 == 0)
            {
                // New property
                m_pProps.PropsSet(FullNodeName(lvArg.lvSubItem.Text), lvArg.lvItem.SubItems[lvArg.nSubItem+1].Text );

                if (this.OnPropsChanged != null)
                    this.OnPropsChanged(sender, e);
            }
            else
            {
                // Chnage value
                m_pProps.PropsSet(FullNodeName(lvArg.lvItem.SubItems[lvArg.nSubItem - 1].Text), lvArg.lvSubItem.Text);
                UpdateCombo(FullNodeName(""), "");

                if (this.OnPropsChanged != null)
                    this.OnPropsChanged(sender, e);
            }
        }

        private void listViewProps_ListSubItemOnStartChange(object sender, EventArgs e)
        {
            // Not allow edit property names
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;
            if (lvArg.nSubItem % 2 == 0 && lvArg.lvSubItem.Text[0] != '<')
            {
                lvArg.Cancel = true;
            }
        }

        private void listViewProps_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewProps.Columns.Count; i++)
            {
                listViewProps.Columns[i].Width = listViewProps.Width / listViewProps.Columns.Count - 1;
            }
        }

        private void comboBoxParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList("", true);

            string sValue = "";
            if (comboBoxParent.SelectedIndex > 0)
            {
                try
                {
                    // If value not set -> the exception may occurs
                    m_pProps.PropsGet(FullNodeName(""), out sValue);
                }
                catch (System.Exception) { }

                textBoxNodeValue.Enabled = true;
            }
            else
            {
                textBoxNodeValue.Enabled = false;
            }

            textBoxNodeValue.Text = sValue;
        }

        private void textBoxNodeValue_Leave(object sender, EventArgs e)
        {
            m_pProps.PropsSet(FullNodeName(""), textBoxNodeValue.Text);
        }

        private void checkBoxShowNested_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCombo(FullNodeName(""), "");
        }
    }
}
