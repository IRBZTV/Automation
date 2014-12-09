using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using MPLATFORMLib;


namespace MControls
{
    public partial class MAttributesList : ListViewEx
    {
        IMAttributes m_pAttributes;
        IMElement m_pElement; // Optionally
        private List<MElemementDescriptor> m_ElementDescriptors;

        public List<MElemementDescriptor> ElementDescriptors
        {
            get { return m_ElementDescriptors; }
            set { m_ElementDescriptors = value; }
        }

        public MAttributesList()
        {
            InitializeComponent();

            Columns[0].Tag = new TextBox();
            Columns[1].Tag = new TextBox();

            this.ListSubItemChanged += new EventHandler(MAttributesList_ListSubItemChanged);
            this.ListSubItemOnStartChange += new EventHandler(MAttributesList_ListSubItemOnStartChange);
            this.KeyDown += new KeyEventHandler(MAttributesList_KeyDown);

            this.ShowItemToolTips = true;
        }

        void MAttributesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && this.SelectedItems != null && this.SelectedItems.Count > 0 && this.SelectedItems[0].Tag != null)
            {
                ListViewItem lvItem = this.SelectedItems[0];
                string strFullName = lvItem.Tag.ToString() + lvItem.Text;
                try
                {
                    // Use try as attribute could be displayed as default
                    m_pAttributes.AttributesRemove(strFullName);
                }
                catch (System.Exception) { }
                

                UpdateList();
            }
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pAttributes;
            try
            {
                m_pAttributes = (IMAttributes)pObject;
                m_pElement = null;
                try
                {
                    m_pElement = (IMElement)pObject;
                }
                catch (System.Exception) { }

                UpdateList();
            }
            catch (System.Exception ex) { }

            return pOld;
        }

        private double m_dblTimeForChange = 2.0;
        public double TimeForChange
        {
            get { return m_dblTimeForChange; }
            set { m_dblTimeForChange = value; }
        }

        // Allow to show only fixed (items present in info list)
        private bool m_bFixedItems = false;
        public bool FixedItems
        {
            get { return m_bFixedItems; }
            set { m_bFixedItems = value; }
        }
        
        public void UpdateList()
        {
            //Remember selection and scroll position
            EndEdit();

            int nTopItemIndex = -1;
            if (this.TopItem != null && this.TopItem.Index >= 0)
                nTopItemIndex = this.TopItem.Index;

            int nSelectedIndex = -1;
            if (this.SelectedIndices != null && this.SelectedIndices.Count > 0)
                nSelectedIndex = this.SelectedIndices[0];

            Items.Clear();

            HybridDictionary mapTypesPos = new HybridDictionary();
            ListDictionary mapAttributes = new ListDictionary();

            mapTypesPos.Clear();
            mapTypesPos.Add("", AddDelimer(""));

            int nCount = 0;
            
            // Get nodes info
            string strNodes = null, strDescription = null;
            try
            {
                // Try element
                IMElement pElement = (IMElement)m_pAttributes;
                pElement.ElementInfoGet("", out strDescription);
                pElement.ElementInfoGet("show_nodes", out strNodes);
            }
            catch (System.Exception) { }
            if (strNodes == null)
            {
                try
                {
                    // Try node
                    IMNode pNode = (IMNode)m_pAttributes;
                    pNode.NodeInfoGet("", out strDescription);
                    pNode.NodeInfoGet("show_nodes", out strNodes);
                }
                catch (System.Exception) { }
            }

            if (strNodes != null)
            {
                string[] arrNodes = strNodes.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrNodes.Length; i++)
                {
                    mapTypesPos.Add(arrNodes[i], AddDelimer(arrNodes[i]));
                }
            }

                // Default attributes 
            m_pAttributes.AttributesInfoGetCount(out nCount);
            for (int i = 0; i < nCount; i++)
            {
                string strName;
                m_pAttributes.AttributesInfoGetByIndex(i, out strName);

                if (!mapAttributes.Contains(strName))
                    mapAttributes.Add(strName, null);
            }

            // Custom attributes
            if (!m_bFixedItems)
            {
                m_pAttributes.AttributesGetCount(out nCount);
                for (int i = 0; i < nCount; i++)
                {
                    string strName, strValue;
                    m_pAttributes.AttributesGetByIndex(i, out strName, out strValue);
                    if (!mapAttributes.Contains(strName))
                        mapAttributes.Add(strName, null);
                }
            }

            // Insert names and attributes into list
            foreach (DictionaryEntry entry in mapAttributes)
            {
                string strFullName = (string)entry.Key;
                string strName = strFullName;
                string strPrefix = GetPrefix(ref strName);

                if (!mapTypesPos.Contains(strPrefix))
                    mapTypesPos.Add(strPrefix, AddDelimer(strPrefix));

                int nPos = Items.IndexOf((ListViewItem)mapTypesPos[strPrefix]);

                int bHaveValue = 0;

                string strValue;
                m_pAttributes.AttributesHave(strFullName, out bHaveValue, out strValue);

                string strHelp;
                m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Help, out strHelp);

                string strType;
                m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Type, out strType);

                string strDefault;
                m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Default, out strDefault);

                string strValues = "";
                m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Values, out strValues);

                if (bHaveValue == 0)
                    strValue = strDefault;

                string strHelpString = "";
                m_pAttributes.AttributesInfoGet(strName, eMInfoType.eMIT_Help, out strHelpString);

                ListViewItem lvItem = nPos >= 0 ? Items.Insert(nPos, strName) : Items.Add(strName);
                if (strHelpString != string.Empty && strHelpString != "null")
                    lvItem.ToolTipText = strHelpString;
                ListViewItem.ListViewSubItem lvSubItem = lvItem.SubItems.Add(strValue);
                if ( (strType == "option" || strType == "option_fixed") && strValues != null && strValues != "")
                {
                    // The option values may be divided by commas or by '|' if values contain commas
                    string[] arrValues = strValues.Contains("|") ? strValues.Split('|') : strValues.Split(',');
                    if (arrValues.Length > 1)
                    {
                        ComboBox pCombo = SubItem_SetCombo(lvSubItem, null, strType == "option_fixed" ? ComboBoxStyle.DropDownList : ComboBoxStyle.DropDown );
                        for (int k = 0; k < arrValues.Length; k++)
                        {
                            pCombo.Items.Add(arrValues[k].Trim());
                        }
                    }
                }
                else if (strType == "bool")
                {
                    ComboBox pCombo = SubItem_SetCombo(lvSubItem, null, ComboBoxStyle.DropDownList);
                    pCombo.Items.Add("true");
                    pCombo.Items.Add("false");
                }
                else if (strType == "path")
                {
                    OpenFileDialog pDialog = new OpenFileDialog();
                    pDialog.Title = strHelp;
                    TextBox textWithDialog = new TextBox();
                    textWithDialog.Tag = pDialog;
                    SubItem_SetControl(lvSubItem, textWithDialog);
                }

                if (strPrefix != "")
                    strPrefix += "::";
                lvItem.Tag = strPrefix;
                lvItem.UseItemStyleForSubItems = false;
                lvItem.BackColor = Color.White;
                if (strValue != strDefault)
                {
                    // User modified values select by black
                    lvSubItem.ForeColor = Color.Black;
                }
                else
                {
                    lvSubItem.ForeColor = Color.Gray;
                }
            }


            Columns[0].Width = -2;
            Columns[1].Width = -2;

            //Restore selection and scroll
            if (nSelectedIndex > 0 && this.Items.Count - 1 >= nSelectedIndex)
                this.Items[nSelectedIndex].Selected = true;
            if (nTopItemIndex > 0 && this.Items.Count - 1 >= nTopItemIndex)
                this.TopItem = this.Items[nTopItemIndex];

        }

        private ListViewItem AddDelimer(string strName)
        {
            int nPos = 0;
            string strPrefix = "";
            ListViewItem lvItem = null;
            if (strName != "")
            {
                strPrefix = strName + "::";

                // Add delimer
                lvItem = Items.Add(strName);
                lvItem.UseItemStyleForSubItems = true;
                lvItem.BackColor = Color.FromArgb(222, 232, 254);
                lvItem.SubItems.Add("");
            }

            if (!m_bFixedItems)
            {
                lvItem = Items.Add("<Add new>");
                lvItem.Tag = strPrefix;
                lvItem.BackColor = Color.White;
                lvItem.UseItemStyleForSubItems = true;
            }

            return lvItem;
        }

        string GetPrefix(ref string strName)
        {
            string strPrefix = "";
            int nDelimer = strName.IndexOf("::");
            if (nDelimer >= 0)
            {
                strPrefix = strName.Substring(0, nDelimer);
                strName = strName.Substring(nDelimer + 2);
            }

            return strPrefix;
        }


        void MAttributesList_ListSubItemOnStartChange(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;

            // Check for separator
            if (lvArg.lvItem.Tag == null)
                lvArg.Cancel = true;

            // Check for property name (edit only if <new name> - one subitem)
            if (lvArg.nSubItem == 0 && lvArg.lvItem.SubItems.Count > 1)
                lvArg.Cancel = true;
        }

        void MAttributesList_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;

            if (lvArg.nSubItem == 0)
            {
                // Add subitem for value
                lvArg.lvItem.SubItems.Add("");
                //BeginEdit(lvArg.nItem, 1);
            }
            else
            {
                // Update attribute
                string sPrefix = (string)lvArg.lvItem.Tag;
                string sName = sPrefix + lvArg.lvItem.SubItems[0].Text;
                string sValue = lvArg.lvItem.SubItems[1].Text;


                // Check for new element
                int bHave = 0;
                string sOldValue;
                m_pAttributes.AttributesHave(sName, out bHave, out sOldValue);

                string sDefValue;
                m_pAttributes.AttributesInfoGet(sName, eMInfoType.eMIT_Default, out sDefValue);

                // Check for remove attributes
				if (sValue == "" && bHave == 1)
                {
                    m_pAttributes.AttributesRemove(sName);

                    lvArg.lvItem.SubItems[1].Text = sDefValue;
                    lvArg.lvItem.SubItems[1].ForeColor = Color.Gray;
                }
                else
                {
                    if (m_pElement != null)
                    {
                        //m_pElement.ElementMultipleSet( sName+"="+sValue, m_dblTimeForChange);
                        m_pElement.ElementStringSet(sName, sValue, m_dblTimeForChange);
                    }
                    else
                        m_pAttributes.AttributesStringSet(sName, sValue);

                    // TODO: Compare with defaults
                    lvArg.lvItem.SubItems[1].ForeColor = Color.Black;

                    if (bHave == 0 && !m_bFixedItems)
                    {
                        UpdateList();
                    }
                    else if (sValue == "" || sValue == sDefValue)
                    {
                        lvArg.lvItem.SubItems[1].Text = sDefValue;
                        lvArg.lvItem.SubItems[1].ForeColor = Color.Gray;
                    }
                }

               
            }
        }

    }
}
