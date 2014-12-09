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
    public partial class FormCG : Form
    {
        public IMLCharGen m_pMLCharGen;
        public Form     m_pParentForm;

        private FolderBrowserDialog m_folderDlg;
        private FormCG_XML m_xmlForm;

        public FormCG()
        {
            InitializeComponent();

            m_cbsCurrentGroup = "";
        }

        public void UpdateList()
        {
            listViewItems.Items.Clear();

            try
            {
                int nCount = 0;
                if (m_cbsCurrentGroup != "")
                {
                    m_pMLCharGen.GroupItemsCount(m_cbsCurrentGroup, out nCount);
                    listViewItems.Items.Add("..");
                }
                else
                {
                    m_pMLCharGen.GetItemsCount(out nCount);
                }

                for( int i = 0; i < nCount; i++ )
                {
                    string strItemID;
                    if (m_cbsCurrentGroup.Length > 0)
                        m_pMLCharGen.GroupGetItem(m_cbsCurrentGroup, i, out strItemID);
                    else
                        m_pMLCharGen.GetItem(i, out strItemID);

                    ListViewItem lvItem = listViewItems.Items.Add(strItemID, 0);
                    UpdateListItem(lvItem);
                }

                int nKeying = 0;
                m_pMLCharGen.IsKeyingMode(out nKeying);

                checkBoxKeying.Checked = nKeying != 0 ? true : false;
            }
            catch (System.Exception e) { };

            for (int j = 0; j < listViewItems.Columns.Count - 1; j++)
            {
                listViewItems.Columns[j].Width = -2;
            }
        }

        int Image2Idx( eCG_ItemType _eType )
        {
            if( ((int)_eType & (int)eCG_ItemType.eCGIT_Reference) != 0) return 7;
            if( ((int)_eType & (int)eCG_ItemType.eCGIT_Group) != 0 ) return 6;

            return (int)_eType;
        }

        public void UpdateListItem( ListViewItem _lvItem  )
        {
            try
            {
                // Add missing subitems
                while (_lvItem.SubItems.Count < listViewItems.Columns.Count )
                {
                    ListViewItem.ListViewSubItem lvSubitem = _lvItem.SubItems.Add("");
                    lvSubitem.Tag = _lvItem.SubItems.Count - 1;
                }

                string strPath;
                CG_ITEM_PROPS cgProps;
                m_pMLCharGen.GetItemBaseProps(_lvItem.Text, out strPath, out cgProps );
                int nFrames = 0;
                double dblRate = 0;
                m_pMLCharGen.FlashGetClipInfo(_lvItem.Text, out nFrames, out dblRate);
                double dblSec = dblRate > 0 ? nFrames / dblRate : 0;
                _lvItem.ImageIndex = Image2Idx(cgProps.eType);
                _lvItem.SubItems[1].Text = cgProps.bShowItem != 0 ? "Show" : "";
                _lvItem.SubItems[2].Text = cgProps.bPauseItem != 0 ? "Pause" : "";
                _lvItem.SubItems[3].Text = cgProps.ePlayingMode == eCG_PlayingMode.eCGPM_Loop ? "Loop" : 
                    cgProps.ePlayingMode == eCG_PlayingMode.eCGPM_OneTime_n_Hide ? "One Time & Hide" : "";
                _lvItem.SubItems[4].Text = cgProps.ptPos.x.ToString();
                _lvItem.SubItems[5].Text = cgProps.ptPos.y.ToString();
                _lvItem.SubItems[6].Text = cgProps.nAlpha.ToString();

                _lvItem.SubItems[7].Text = cgProps.szItem.cx.ToString() + "x" + cgProps.szItem.cy.ToString() + "@" + dblRate.ToString("F") + " " +
                    nFrames.ToString() + " frames (" + dblSec.ToString("F") + " sec)";
                _lvItem.SubItems[8].Text = cgProps.eScale == eCG_Scale.eCGS_FitAR ? "Fit AR" :
                    cgProps.eScale == eCG_Scale.eCGS_ExactFit ? "Exact Fit" : "No scale";
                _lvItem.SubItems[9].Text = cgProps.eInterlace == eCG_Interlace.eCGI_Auto ? "Auto" :
                    cgProps.eInterlace == eCG_Interlace.eCGI_Field1First ? "Field 1 First" :
                    cgProps.eInterlace == eCG_Interlace.eCGI_Field2First ? "Field 2 First" : "";
                _lvItem.SubItems[10].Text = cgProps.nEdgesSmooth.ToString();
                //_lvItem.SubItems[11].Text = cgProps. != 0 ? "Yes" : "";
                _lvItem.SubItems[12].Text = "#" + cgProps.nBackColor.ToString("X8");
                _lvItem.SubItems[13].Text = strPath;
                _lvItem.SubItems[14].Text = "<..click..>";
            }
            catch (System.Exception e) { }
        }

        public void UpdateListContent()
        {
            for( int i = 0; i < listViewItems.Items.Count; i++ )
            {
                UpdateListItem(listViewItems.Items[i]);
            }

            for (int j = 0; j < listViewItems.Columns.Count - 1; j++)
            {
                listViewItems.Columns[j].Width = -2;
            }
        }

        public void UpdateItemDesc()
        {
            string strDesc = "<" + comboBoxItemType.SelectedItem + " type='" + comboBoxItemSubType.SelectedItem + "' ";
            if (comboBoxItemType.SelectedItem == "graphics" )
            {
                strDesc += "color='Red(120)-Green(180)-Blue(220)' outline-color='White/Orange/White' outline='3.0'/>";
            }
            else
            {
                strDesc += "font='Arial Narrow Bold' font-size='20' color='White' outline-color='Black/Blue/Black' outline='0.0'>\r\n";
                if (comboBoxItemSubType.SelectedItem != "date-time" )
                    strDesc += "put the new text here...";
                else
                    strDesc += "'Current Time:' yyyy/MM/dd HH:mm:ss";
                strDesc += "\r\n</text>";
            }
            textBoxItemDesc.Text = strDesc;
        }

        private void FormCG_Load(object sender, EventArgs e)
        {
            m_folderDlg = new FolderBrowserDialog();
            m_xmlForm = new FormCG_XML();

            // Select default combo values
            comboBoxItemType.SelectedIndex = 0;

            comboBoxSqIn.SelectedIndex = 0;
            comboBoxSqOut.SelectedIndex = 0;
            comboBoxMoveIn.SelectedIndex = 0;
            comboBoxMoveOut.SelectedIndex = 0;
            comboBoxBlurIn.SelectedIndex = 0;
            comboBoxBlurOut.SelectedIndex = 0;

            comboBoxTickerType.SelectedIndex = 0;
            comboBoxTickerBG.SelectedIndex = 0;

            comboBoxTickerSqIn.SelectedIndex = 0;
            comboBoxTickerSqOut.SelectedIndex = 0;
            comboBoxTickerMoveIn.SelectedIndex = 0;
            comboBoxTickerMoveOut.SelectedIndex = 0;
            comboBoxTickerBlurIn.SelectedIndex = 0;
            comboBoxTickerBlurOut.SelectedIndex = 0;
            

        }

        private void FormCG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;

                if (m_pParentForm != null) m_pParentForm.BringToFront();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (openFileCG.ShowDialog(this) == DialogResult.OK)
            {
                string strItemID = GetNewItemID();

                try
                {
                    m_pMLCharGen.AddNewItem(openFileCG.FileName, 0.05, 0.05, 1, 0, ref strItemID);
                }
                catch (Exception){}

                textBoxName.Text = "<put new item name here>";

                UpdateList();
            }
        }

        private void buttonAddSeq_Click(object sender, EventArgs e)
        {
            if (m_folderDlg.ShowDialog(this) == DialogResult.OK)
            {
                string strItemID = GetNewItemID();

                try
                {
                    // Add the image sequenece
                    string sPath = m_folderDlg.SelectedPath + "\\*.*";
                    m_pMLCharGen.AddNewItem(sPath, 0.05, 0.05, 1, 0, ref strItemID);
                }
                catch (Exception){}

                textBoxName.Text = "<put new item name here>";

                UpdateList();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if( listViewItems.SelectedItems.Count > 0 )
                {
                    if (m_cbsCurrentGroup != "")
                        m_pMLCharGen.GroupRemoveItem(m_cbsCurrentGroup, listViewItems.SelectedItems[0].Text);
                    else
                        m_pMLCharGen.RemoveItemWithDelay(listViewItems.SelectedItems[0].Text, 1000, (int)numericChangeTime.Value );
                }

                for( int i = 0; i < listViewItems.Items.Count; i++ )
                {
                    if( listViewItems.Items[i].Checked )
                    {
                        if (m_cbsCurrentGroup != "")
                            m_pMLCharGen.GroupRemoveItem(m_cbsCurrentGroup, listViewItems.Items[i].Text);
                        else
                            m_pMLCharGen.RemoveItemWithDelay(listViewItems.Items[i].Text, 1000, (int)numericChangeTime.Value);
                    }
                }

                UpdateList();
            }
            catch (Exception){}
        }

        private void buttonRewind_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    m_pMLCharGen.RewindItem(listViewItems.SelectedItems[0].Text);
                }

                UpdateList();
            }
            catch (Exception) { }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    m_pMLCharGen.ChangeItemZOrder(listViewItems.SelectedItems[0].Text, -1);
                }

                UpdateList();
            }
            catch (Exception) { }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    m_pMLCharGen.ChangeItemZOrder(listViewItems.SelectedItems[0].Text, 1);
                }

                UpdateList();
            }
            catch (Exception) { }
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            TextBox pTextBox = (TextBox)sender;
            if( pTextBox.Text.StartsWith("<put ") )
            {
                pTextBox.Text = "";
            }

            pTextBox.ForeColor = Color.Black;
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            TextBox pTextBox = (TextBox)sender;
            if (pTextBox.Text == "" || pTextBox.Text.StartsWith("<put "))
            {
                pTextBox.Text = "<put new item name here>";
                pTextBox.ForeColor = Color.Gray;
            }
        }

        
        private int Color2Int(Color color, long alpha)
        {
            int nColor = (int)(color.R | color.G << 8 | color.B << 16 | alpha << 24);
            return nColor;
        }

        private Color Int2Color(int nColor)
        {
            Color cColor = Color.FromArgb(nColor);
            return Color.FromArgb(cColor.B, cColor.G, cColor.R);
        }

        void UpdateItemProps( string strItemID )
        {
            try
            {
                string strPath;
                CG_ITEM_PROPS cgProps;
                m_pMLCharGen.GetItemBaseProps(strItemID, out strPath, out cgProps);
                textBoxItem.Text = strPath;
                checkBoxShow.Checked = cgProps.bShowItem != 0 ? true : false;
                numericX.Value = cgProps.ptPos.x;
                numericY.Value = cgProps.ptPos.y;
                numericW.Value = cgProps.szItem.cx;
                numericH.Value = cgProps.szItem.cy;
                numericA.Value = cgProps.nAlpha;
                numericBackA.Value = (cgProps.nBackColor >> 24) & 0xFF;
                labelBackcolor.BackColor = Int2Color(cgProps.nBackColor);

                numericLeft.Value = cgProps.rcIndent.left;
                numericRight.Value = cgProps.rcIndent.right;
                numericTop.Value = cgProps.rcIndent.top;
                numericBottom.Value = cgProps.rcIndent.top;

                CG_AUTO_BLEND autoBlend;
                m_pMLCharGen.GetAutoBlend(strItemID, out autoBlend);

                numericOffset.Value = autoBlend.nMsecStart;
                numericRamp.Value = autoBlend.nMsecRamp;
                numericON.Value = autoBlend.nMsecOn;
                numericOFF.Value = autoBlend.nMsecOff;
                checkBoxRepeat.Checked = autoBlend.bRepeat != 0;

                CG_ITEM_MOVEMENT cgMove;
                m_pMLCharGen.GetItemMovement(strItemID, out cgMove);
                numericSpeedX.Value = (decimal)cgMove.dblXSpeed;
                numericSpeedY.Value = (decimal)cgMove.dblYSpeed;

                buttonApply.Enabled = false;
            }
            catch (Exception) { }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    string strPath;
                    CG_ITEM_PROPS cgProps;
                    m_pMLCharGen.GetItemBaseProps(listViewItems.SelectedItems[0].Text, out strPath, out cgProps);
                    cgProps.bShowItem = checkBoxShow.Checked ? 1 : 0;
                    cgProps.ptPos.x = (int)numericX.Value;
                    cgProps.ptPos.y = (int)numericY.Value;
                    cgProps.szItem.cx = (int)numericW.Value;
                    cgProps.szItem.cy = (int)numericH.Value;
                    cgProps.nAlpha = (int)numericA.Value;
                    cgProps.rcIndent.left = (int)numericLeft.Value;
                    cgProps.rcIndent.right = (int)numericRight.Value;
                    cgProps.rcIndent.top = (int)numericTop.Value;
                    cgProps.rcIndent.bottom = (int)numericBottom.Value;
                    cgProps.nBackColor = Color2Int(labelBackcolor.BackColor, (int)numericBackA.Value);

                    m_pMLCharGen.SetItemBaseProps(listViewItems.SelectedItems[0].Text, ref cgProps, (int)numericChangeTime.Value);

                    buttonApply.Enabled = false;
                }
                catch (Exception) { }
            }
        }
        private void labelBackcolor_Click(object sender, EventArgs e)
        {
            colorBackground.Color = labelBackcolor.BackColor;
            if (colorBackground.ShowDialog() == DialogResult.OK)
            {
                labelBackcolor.BackColor = colorBackground.Color;

                buttonApply.Enabled = true;
            }
        }

        private void numeric_ValueChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }
        private void numeric_KeyDown(object sender, KeyEventArgs e)
        {
            buttonApply.Enabled = true;
        }
        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }


        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    Point ptPos = listViewItems.PointToClient(Cursor.Position);
                    ListViewHitTestInfo hitInfo = listViewItems.HitTest(ptPos);

                    if (hitInfo.Item.Text == "..")
                    {
                        m_cbsCurrentGroup = "";
                        UpdateList();
                        return;
                    }
                    
                    string strPath;
                    CG_ITEM_PROPS cgProps;
                    m_pMLCharGen.GetItemBaseProps(listViewItems.SelectedItems[0].Text, out strPath, out cgProps);
                    bool bUpdate = false;

                    if (hitInfo.SubItem.Tag == null) // Item
                    {
                        if (((int)cgProps.eType & (int)eCG_ItemType.eCGIT_Group) != 0)
                        {
                            m_cbsCurrentGroup = listViewItems.SelectedItems[0].Text;
                            UpdateList();
                            return;
                        }
                    }
                    else if ((int)hitInfo.SubItem.Tag == 14) // XML Desc 
                    {
                        m_xmlForm.m_pMLCharGen = m_pMLCharGen;
                        m_xmlForm.m_strItemID = listViewItems.SelectedItems[0].Text;
                        m_xmlForm.ShowDialog(this);

                        {
                            // Update always as may be Apply -> Close
                            UpdateItemProps(listViewItems.SelectedItems[0].Text);
                            UpdateListItem(listViewItems.SelectedItems[0]);
                        }
                    }
                    else if ((int)hitInfo.SubItem.Tag == 7) // Item props
                    {
                        cgProps.bShowItem = cgProps.bShowItem != 0 ? 0 : 1;
                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 1) // Show 
                    {
                        cgProps.bShowItem = cgProps.bShowItem != 0 ? 0 : 1;
                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 2) // Pause 
                    {
                        cgProps.bPauseItem = cgProps.bPauseItem != 0 ? 0 : 1;
                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 3) // Loop 
                    {
                        cgProps.ePlayingMode = (eCG_PlayingMode)(cgProps.ePlayingMode + 1);
                        if (cgProps.ePlayingMode > eCG_PlayingMode.eCGPM_OneTime_n_Hide) cgProps.ePlayingMode = eCG_PlayingMode.eCGPM_Loop;

                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 8) // AR 
                    {
                        cgProps.eScale = (eCG_Scale)(cgProps.eScale + 1);
                        if (cgProps.eScale > eCG_Scale.eCGS_Text) cgProps.eScale = eCG_Scale.eCGS_FitAR;

                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 9) // Interlace 
                    {
                        cgProps.eInterlace = (eCG_Interlace)(cgProps.eInterlace + 1);
                        if (cgProps.eInterlace > eCG_Interlace.eCGI_Field2First) cgProps.eInterlace = eCG_Interlace.eCGI_Progressive;

                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 10) // Smooth 
                    {
                        cgProps.nEdgesSmooth += 2;
                        if (cgProps.nEdgesSmooth > 8) cgProps.nEdgesSmooth = 0;

                        bUpdate = true;
                    }
                    else if ((int)hitInfo.SubItem.Tag == 11) // Rate 
                    {
                        //cgProps.bOriginalRate = cgProps.bOriginalRate != 0 ? 0 : 1;
                        //bUpdate = true;
                    }

                    if (bUpdate)
                    {
                        m_pMLCharGen.SetItemBaseProps(listViewItems.SelectedItems[0].Text, ref cgProps, 0);

                        UpdateItemProps(listViewItems.SelectedItems[0].Text);
                        UpdateListItem(listViewItems.SelectedItems[0]);
                    }
                }
                catch (Exception) { }
            }
        }

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                panelBasicProps.Enabled = true;
                panelEffects.Enabled = true;

                UpdateItemProps(listViewItems.SelectedItems[0].Text);
                UpdateVars(listViewItems.SelectedItems[0].Text);
                UpdateTicker(listViewItems.SelectedItems[0].Text);
                UpdateItemEffects(listViewItems.SelectedItems[0].Text);
                UpdateItemTimes(listViewItems.SelectedItems[0].Text);
                UpdateItemShow_n_Hide(listViewItems.SelectedItems[0].Text);
            }
            else
            {
                UpdateTicker("");
                panelBasicProps.Enabled = false;
                panelEffects.Enabled = false;

                textBoxItem.Text = "";
                comboVarName.Items.Clear();
            }

            UpdateGroup();

            UpdateCompositionsState();
        }

        private void listViewItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateGroup();
        }

        private void listViewItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            UpdateGroup();
        }

        private void listViewItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                // Check mouse pointer (for not change check state for double-click)
                Point ptPos = listViewItems.PointToClient(Cursor.Position);
                ListViewHitTestInfo hitInfo = listViewItems.HitTest(ptPos);

                if (hitInfo.Location != ListViewHitTestLocations.StateImage && listViewItems.Focused)
                {
                    e.NewValue = e.CurrentValue;
                }
            }
            catch (System.Exception) { }
        }
        private void buttonBlendStart_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    CG_AUTO_BLEND autoBlend = new CG_AUTO_BLEND();
                    autoBlend.nMsecStart = (int)numericOffset.Value;
                    autoBlend.nMsecRamp = (int)numericRamp.Value;
                    autoBlend.nMsecOn = (int)numericON.Value;
                    autoBlend.nMsecOff = (int)numericOFF.Value;
                    autoBlend.bRepeat = checkBoxRepeat.Checked ? 1 : 0;

                    m_pMLCharGen.SetAutoBlend(listViewItems.SelectedItems[0].Text, ref autoBlend );
                }
                catch (Exception) { }
            }
        }

        private void buttonBlendReset_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    // Reset bland - set zero CG_AUTO_BLEND
                    CG_AUTO_BLEND autoBlend = new CG_AUTO_BLEND();
                    m_pMLCharGen.SetAutoBlend(listViewItems.SelectedItems[0].Text, ref autoBlend);
                }
                catch (Exception) { }
            }
        }

       
        private void UpdateVars(string strItemID )
        {
            comboVarName.Items.Clear();
            try
            {
                int nCount;
                m_pMLCharGen.FlashGetVariablesCount(strItemID, out nCount);
                for( int i = 0; i < nCount; i++ )
                {
                    string strName;
                    m_pMLCharGen.FlashGetVariableName(strItemID, i, out strName);

                    comboVarName.Items.Add(strName);
                }

                if( nCount > 0 )
                {
                    comboVarName.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }

        private void comboVarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    string strValue;
                    m_pMLCharGen.FlashGetVariable(listViewItems.SelectedItems[0].Text, comboVarName.Text, out strValue);

                    textBoxValue.Text = strValue;
                }
                catch (Exception) { }
            }
        }


        private void buttonLookup_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    string strValue;
                    m_pMLCharGen.FlashGetVariable(listViewItems.SelectedItems[0].Text, comboVarName.Text, out strValue);

                    textBoxValue.Text = strValue;
                    if (comboVarName.FindStringExact(comboVarName.Text) < 0)
                    {
                        comboVarName.Items.Add(comboVarName.Text);
                    }
                }
                catch (Exception) { }
            }
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    m_pMLCharGen.FlashSetVariable(listViewItems.SelectedItems[0].Text, comboVarName.Text, textBoxValue.Text);
                    if (comboVarName.FindStringExact(comboVarName.Text) < 0)
                    {
                        comboVarName.Items.Add(comboVarName.Text);
                    }
                }
                catch (Exception) { }
            }
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    string strRet;
                    m_pMLCharGen.FlashCallFunction(listViewItems.SelectedItems[0].Text, textBoxValue.Text, out strRet );

                    textBoxValue.Text = strRet;
                }
                catch (Exception) { }
            }
        }

      

        private void checkBoxKeying_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_pMLCharGen.EnableKeyingMode(checkBoxKeying.Checked ? 1 : 0);
            }
            catch (Exception) { }
        }


        private void comboBoxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBoxItemType.SelectedItem == "text" )
            {
                comboBoxItemSubType.Items.Clear();
                comboBoxItemSubType.Items.Add("text");
                comboBoxItemSubType.Items.Add("date-time");
                comboBoxItemSubType.Items.Add("timecode");
                comboBoxItemSubType.Items.Add("timecode-ndf");
                comboBoxItemSubType.Items.Add("frame-time");
                comboBoxItemSubType.SelectedIndex = 0;
            }
            else if (comboBoxItemType.SelectedItem == "graphics")
            {
                comboBoxItemSubType.Items.Clear();
                comboBoxItemSubType.Items.Add("rect");
                comboBoxItemSubType.Items.Add("block-1");
                comboBoxItemSubType.Items.Add("block-2");
                comboBoxItemSubType.Items.Add("block-3");
                comboBoxItemSubType.Items.Add("block-4");
                comboBoxItemSubType.Items.Add("block-5");
                comboBoxItemSubType.Items.Add("block-6");
                comboBoxItemSubType.Items.Add("circle");
                comboBoxItemSubType.Items.Add("ellipse");
                comboBoxItemSubType.Items.Add("triangle");
                comboBoxItemSubType.Items.Add("polygon");
                comboBoxItemSubType.Items.Add("star");
                comboBoxItemSubType.SelectedIndex = 0;
            }

            UpdateItemDesc();
        }
        private string GetNewItemID()
        {
            if (textBoxName.Text != "<put new item name here>")
            {
                // Use auto name
                return textBoxName.Text;
            }

            return "";
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if(textBoxItemDesc.Text != "" )
            {
                string strItemID = GetNewItemID();
                try
                {
                    // Add the item via XML desc
                    m_pMLCharGen.AddNewItem(textBoxItemDesc.Text, 0.05, 0.05, 1, 0, ref strItemID);
                }
                catch (Exception) { }

                textBoxName.Text = "<put new item name here>";

                UpdateList();
            }
        }

        private void comboBoxItemSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateItemDesc();
        }

        private void numericSpeedX_ValueChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    CG_ITEM_MOVEMENT cgMove = new CG_ITEM_MOVEMENT();
                    cgMove.dblXSpeed = (double)numericSpeedX.Value;
                    cgMove.dblYSpeed = (double)numericSpeedY.Value;
                    m_pMLCharGen.SetItemMovement(listViewItems.SelectedItems[0].Text, ref cgMove);
                }
                catch (Exception) { }
            }
        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            if( saveFileConfig.ShowDialog(this) == DialogResult.OK )
            {
                try
                {
                    IMLXMLPersist pXMLPersist = (IMLXMLPersist)m_pMLCharGen;
                    pXMLPersist.SaveToXMLFile(saveFileConfig.FileName, 1);
                }
                catch (Exception) { }
            }
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            if (openFileConfig.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    IMLXMLPersist pXMLPersist = (IMLXMLPersist)m_pMLCharGen;
                    pXMLPersist.LoadFromXML(openFileConfig.FileName, -1);
                }
                catch (Exception) { }
            }
        }

        // The Item Enter/Exit, Effects, Times implementation (Pro version only) below
        #region Item Enter/Exit, Effects, Times

        private void UpdateItemShow_n_Hide(string strItemID)
        {
            string strShow = "";
            string strHide = "";
            try
            {
                m_pMLCharGen.GetItemProperties(strItemID, "on-show", out strShow);
                m_pMLCharGen.GetItemProperties(strItemID, "on-hide", out strHide);
            }
            catch (Exception) { }

            // On-Show
            {
                checkBoxFadeIn.Checked = strShow.Contains("fade");

                checkBoxMoveIn.Checked = false;
                if (strShow.Contains("left"))
                {
                    checkBoxMoveIn.Checked = true;
                    comboBoxMoveIn.SelectedIndex = 0;
                }
                else if (strShow.Contains("right"))
                {
                    checkBoxMoveIn.Checked = true;
                    comboBoxMoveIn.SelectedIndex = 1;
                }
                else if (strShow.Contains("top"))
                {
                    checkBoxMoveIn.Checked = true;
                    comboBoxMoveIn.SelectedIndex = 2;
                }
                else if (strShow.Contains("bottom"))
                {
                    checkBoxMoveIn.Checked = true;
                    comboBoxMoveIn.SelectedIndex = 3;
                }

                checkBoxBlurIn.Checked = false;
                if (strShow.Contains("blur-x"))
                {
                    checkBoxBlurIn.Checked = true;
                    comboBoxBlurIn.SelectedIndex = 1;
                }
                else if (strShow.Contains("blur-y"))
                {
                    checkBoxBlurIn.Checked = true;
                    comboBoxBlurIn.SelectedIndex = 2;
                }
                else if (strShow.Contains("blur"))
                {
                    checkBoxBlurIn.Checked = true;
                    comboBoxBlurIn.SelectedIndex = 0;
                }

                checkBoxSqIn.Checked = false;
                if (strShow.Contains("squeeze-x"))
                {
                    checkBoxSqIn.Checked = true;
                    comboBoxSqIn.SelectedIndex = 1;
                }
                else if (strShow.Contains("squeeze-y"))
                {
                    checkBoxSqIn.Checked = true;
                    comboBoxSqIn.SelectedIndex = 2;
                }
                else if (strShow.Contains("squeeze"))
                {
                    checkBoxSqIn.Checked = true;
                    comboBoxSqIn.SelectedIndex = 0;
                }
            }

            // On-Hide
            {
                checkBoxFadeOut.Checked = strHide.Contains("fade");

                checkBoxMoveOut.Checked = false;
                if (strHide.Contains("left"))
                {
                    checkBoxMoveOut.Checked = true;
                    comboBoxMoveOut.SelectedIndex = 0;
                }
                else if (strHide.Contains("right"))
                {
                    checkBoxMoveOut.Checked = true;
                    comboBoxMoveOut.SelectedIndex = 1;
                }
                else if (strHide.Contains("top"))
                {
                    checkBoxMoveOut.Checked = true;
                    comboBoxMoveOut.SelectedIndex = 2;
                }
                else if (strHide.Contains("bottom"))
                {
                    checkBoxMoveOut.Checked = true;
                    comboBoxMoveOut.SelectedIndex = 3;
                }

                checkBoxBlurOut.Checked = false;
                if (strHide.Contains("blur-x"))
                {
                    checkBoxBlurOut.Checked = true;
                    comboBoxBlurOut.SelectedIndex = 1;
                }
                else if (strHide.Contains("blur-y"))
                {
                    checkBoxBlurOut.Checked = true;
                    comboBoxBlurOut.SelectedIndex = 2;
                }
                else if (strHide.Contains("blur"))
                {
                    checkBoxBlurOut.Checked = true;
                    comboBoxBlurOut.SelectedIndex = 0;
                }


                checkBoxSqOut.Checked = false;
                if (strHide.Contains("squeeze-x"))
                {
                    checkBoxSqOut.Checked = true;
                    comboBoxSqOut.SelectedIndex = 1;
                }
                else if (strHide.Contains("squeeze-y"))
                {
                    checkBoxSqOut.Checked = true;
                    comboBoxSqOut.SelectedIndex = 2;
                }
                else if (strHide.Contains("squeeze"))
                {
                    checkBoxSqOut.Checked = true;
                    comboBoxSqOut.SelectedIndex = 0;
                }
            }
        }

        private void UpdateItemTimes(string strItemID)
        {
            numericDefHide.Value = 0;
            try
            {
                string strValue;
                m_pMLCharGen.GetItemProperties(listViewItems.SelectedItems[0].Text, "exit-time", out strValue);
                numericDefHide.Value = decimal.Parse(strValue);
            }
            catch (Exception) { }

            numericDelayIn.Value = 0;
            try
            {
                string strValue;
                m_pMLCharGen.GetItemProperties(listViewItems.SelectedItems[0].Text, "intro-delay", out strValue);
                numericDelayIn.Value = decimal.Parse(strValue);
            }
            catch (Exception) { }

            numericDelayOut.Value = 0;
            try
            {
                string strValue;
                m_pMLCharGen.GetItemProperties(listViewItems.SelectedItems[0].Text, "exit-delay", out strValue);
                numericDelayOut.Value = decimal.Parse(strValue);
            }
            catch (Exception) { }
        }

        private void UpdateItemEffects(string strItemID)
        {
            checkBoxShadow.Checked = false;
            try
            {
                string strEnabled;
                m_pMLCharGen.GetItemProperties(strItemID, "effects::shadow::enabled", out strEnabled );

                if( strEnabled == "true" || strEnabled == "yes" )
                    checkBoxShadow.Checked = true;
                    
            }
            catch (Exception) { }

            checkBoxBlur.Checked = false;
            try
            {
                string strEnabled;
                m_pMLCharGen.GetItemProperties(strItemID, "effects::blur::enabled", out strEnabled );

                if( strEnabled == "true" || strEnabled == "yes" )
                    checkBoxBlur.Checked = true;
            }
            catch (Exception) { }

            checkBoxGlow.Checked = false;
            try
            {
                string strEnabled;
                m_pMLCharGen.GetItemProperties(strItemID, "effects::glow::enabled", out strEnabled);

                if( strEnabled == "true" || strEnabled == "yes" )
                    checkBoxGlow.Checked = true;
                
                    
            }
            catch (Exception) { }

            checkBoxMotion.Checked = false;
            try
            {
                string strEnabled;
                m_pMLCharGen.GetItemProperties(strItemID, "effects::motion-blur::enabled", out strEnabled);

                if( strEnabled == "true" || strEnabled == "yes" )
                    checkBoxMotion.Checked = true;
            }
            catch (Exception) { }

        }


        private void SetItemEffects(string strItemID)
        {
            try
            {
                if (checkBoxShadow.Checked)
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::shadow::enabled", "true", "", 0);
                }
                else
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::shadow::enabled", "false", "", 0);
                }
                if (checkBoxBlur.Checked)
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::blur::enabled", "true", "", 0);
                }
                else
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::blur::enabled", "false", "", 0);
                }
                if (checkBoxGlow.Checked)
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::glow::enabled", "true", "", 0);
                }
                else
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::glow::enabled", "false", "", 0);
                }
                if (checkBoxMotion.Checked)
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::motion-blur::enabled", "true", "", 0);
                }
                else
                {
                    // Note: for additional effects parameters see the XML description
                    m_pMLCharGen.SetItemProperties(strItemID, "effects::motion-blur::enabled", "false", "", 0);
                }
            }
            catch (System.Exception){}
            
        }

        private void SetItemShow_n_Hide(string strItemID)
        {
            string strShow = "";
            if (checkBoxFadeIn.Checked)
                strShow += "fade";

            if (checkBoxMoveIn.Checked)
            {
                if (strShow != "") strShow += ", ";
                strShow += comboBoxMoveIn.SelectedItem.ToString();
            }

            if (checkBoxBlurIn.Checked)
            {
                if (strShow != "") strShow += ", ";

                strShow += comboBoxBlurIn.SelectedIndex == 1 ? "blur-x" :
                    comboBoxBlurIn.SelectedIndex == 2 ? "blur-y" : "blur";
            }

            if (checkBoxSqIn.Checked)
            {
                if (strShow != "") strShow += ", ";

                strShow += comboBoxSqIn.SelectedIndex == 1 ? "squeeze-x" :
                    comboBoxSqIn.SelectedIndex == 2 ? "squeeze-y" : "squeeze";
            }

            string strHide = "";
            if (checkBoxFadeOut.Checked)
                strHide += "fade";

            if (checkBoxMoveOut.Checked)
            {
                if (strHide != "") strHide += ", ";
                strHide += comboBoxMoveOut.SelectedItem.ToString();
            }

            if (checkBoxBlurOut.Checked)
            {
                if (strHide != "") strHide += ", ";

                strHide += comboBoxBlurOut.SelectedIndex == 1 ? "blur-x" :
                    comboBoxBlurOut.SelectedIndex == 2 ? "blur-y" : "blur";
            }

            if (checkBoxSqOut.Checked)
            {
                if (strHide != "") strHide += ", ";

                strHide += comboBoxSqOut.SelectedIndex == 1 ? "squeeze-x" :
                    comboBoxSqOut.SelectedIndex == 2 ? "squeeze-y" : "squeeze";
            }

            try
            {
                m_pMLCharGen.SetItemProperties(strItemID, "on-show", strShow, "", 0);
                m_pMLCharGen.SetItemProperties(strItemID, "on-hide", strHide, "", 0);
            }
            catch (System.Exception) { }
        }

        private void checkBoxItemInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBlurIn.Focused || checkBoxMoveIn.Focused || checkBoxSqIn.Focused || checkBoxMoveIn.Focused ||
                checkBoxBlurOut.Focused || checkBoxMoveOut.Focused || checkBoxSqOut.Focused || checkBoxMoveOut.Focused )
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    SetItemShow_n_Hide(listViewItems.SelectedItems[0].Text);
                }
            }
        }

        private void comboBoxItemInOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMoveIn.Focused || comboBoxSqIn.Focused || comboBoxBlurIn.Focused ||
                comboBoxMoveOut.Focused || comboBoxSqOut.Focused || comboBoxBlurOut.Focused )
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    SetItemShow_n_Hide(listViewItems.SelectedItems[0].Text);
                }
            }
        }

        private void checkBoxEffects_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMotion.Focused || checkBoxGlow.Focused || checkBoxShadow.Focused || checkBoxBlur.Focused)
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    SetItemEffects(listViewItems.SelectedItems[0].Text);
                }
            }
        }

        private void numericItemTimes_ValueChanged(object sender, EventArgs e)
        {
            if( (numericDefHide.Focused || numericDelayIn.Focused || numericDelayOut.Focused) &&listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    m_pMLCharGen.SetItemProperties(listViewItems.SelectedItems[0].Text, "exit-time", numericDefHide.Value.ToString(), "", 0);
                    m_pMLCharGen.SetItemProperties(listViewItems.SelectedItems[0].Text, "intro-delay", numericDelayIn.Value.ToString(), "", 0);
                    m_pMLCharGen.SetItemProperties(listViewItems.SelectedItems[0].Text, "exit-delay", numericDelayOut.Value.ToString(), "", 0);
                }
                catch (System.Exception ex) { }
            }
        }

        #endregion

        // The tickers implementation (Pro version only) below
        #region Tickers Implemetation

        private void UpdateTicker( string strTickerID )
        {
            string strTickerType = "";
            bool bTicker = false;
            try
            {
                m_pMLCharGen.GetItemProperties(strTickerID, "ticker::type", out strTickerType);
                bTicker = true;
            }
            catch (System.Exception){}

            if( bTicker )
            {
                // Enable buttons
                buttonTickerAddText.Enabled = true;
                buttonTickerAddFile.Enabled = true;
                buttonTickerRewind.Enabled = true;

                // Update effects
                if (strTickerType != "roll" && strTickerType != "crawl")
                {
                    try
                    {
                        string strShow;
                        m_pMLCharGen.GetItemProperties(strTickerID, "group-show", out strShow);
                        string strHide;
                        m_pMLCharGen.GetItemProperties(strTickerID, "group-hide", out strHide);

                        // On-Show
                        {
                            checkBoxTickerFadeIn.Checked = strShow.Contains("fade");

                            checkBoxTickerMoveIn.Checked = false;
                            if (strShow.Contains("left"))
                            {
                                checkBoxTickerMoveIn.Checked = true;
                                comboBoxTickerMoveIn.SelectedIndex = 0;
                            }
                            else if (strShow.Contains("right"))
                            {
                                checkBoxTickerMoveIn.Checked = true;
                                comboBoxTickerMoveIn.SelectedIndex = 1;
                            }
                            else if (strShow.Contains("top"))
                            {
                                checkBoxTickerMoveIn.Checked = true;
                                comboBoxTickerMoveIn.SelectedIndex = 2;
                            }
                            else if (strShow.Contains("bottom"))
                            {
                                checkBoxTickerMoveIn.Checked = true;
                                comboBoxTickerMoveIn.SelectedIndex = 3;
                            }


                            checkBoxTickerBlurIn.Checked = false;
                            if (strShow.Contains("blur-x"))
                            {
                                checkBoxTickerBlurIn.Checked = true;
                                comboBoxTickerBlurIn.SelectedIndex = 1;
                            }
                            else if (strShow.Contains("blur-y"))
                            {
                                checkBoxTickerBlurIn.Checked = true;
                                comboBoxTickerBlurIn.SelectedIndex = 2;
                            }
                            else if (strShow.Contains("blur"))
                            {
                                checkBoxTickerBlurIn.Checked = true;
                                comboBoxTickerBlurIn.SelectedIndex = 0;
                            }

                            checkBoxTickerSqIn.Checked = false;
                            if (strShow.Contains("squeeze-x"))
                            {
                                checkBoxTickerSqIn.Checked = true;
                                comboBoxTickerSqIn.SelectedIndex = 1;
                            }
                            else if (strShow.Contains("squeeze-y"))
                            {
                                checkBoxTickerSqIn.Checked = true;
                                comboBoxTickerSqIn.SelectedIndex = 2;
                            }
                            else if (strShow.Contains("squeeze"))
                            {
                                checkBoxTickerSqIn.Checked = true;
                                comboBoxTickerSqIn.SelectedIndex = 0;
                            }
                            
                        }

                        // On-Hide
                        {
                            checkBoxTickerFadeOut.Checked = strHide.Contains("fade");

                            checkBoxTickerMoveOut.Checked = false;
                            if (strHide.Contains("left"))
                            {
                                checkBoxTickerMoveOut.Checked = true;
                                comboBoxTickerMoveOut.SelectedIndex = 0;
                            }
                            else if (strHide.Contains("right"))
                            {
                                checkBoxTickerMoveOut.Checked = true;
                                comboBoxTickerMoveOut.SelectedIndex = 1;
                            }
                            else if (strHide.Contains("top"))
                            {
                                checkBoxTickerMoveOut.Checked = true;
                                comboBoxTickerMoveOut.SelectedIndex = 2;
                            }
                            else if (strHide.Contains("bottom"))
                            {
                                checkBoxTickerMoveOut.Checked = true;
                                comboBoxTickerMoveOut.SelectedIndex = 3;
                            }


                            checkBoxTickerBlurOut.Checked = false;
                            if (strHide.Contains("blur-x"))
                            {
                                checkBoxTickerBlurOut.Checked = true;
                                comboBoxTickerBlurOut.SelectedIndex = 1;
                            }
                            else if (strHide.Contains("blur-y"))
                            {
                                checkBoxTickerBlurOut.Checked = true;
                                comboBoxTickerBlurOut.SelectedIndex = 2;
                            }
                            else if (strHide.Contains("blur"))
                            {
                                checkBoxTickerBlurOut.Checked = true;
                                comboBoxTickerBlurOut.SelectedIndex = 0;
                            }

                            checkBoxTickerSqOut.Checked = false;
                            if (strHide.Contains("squeeze-x"))
                            {
                                checkBoxTickerSqOut.Checked = true;
                                comboBoxTickerSqOut.SelectedIndex = 1;
                            }
                            else if (strHide.Contains("squeeze-y"))
                            {
                                checkBoxTickerSqOut.Checked = true;
                                comboBoxTickerSqOut.SelectedIndex = 2;
                            }
                            else if (strHide.Contains("squeeze"))
                            {
                                checkBoxTickerSqOut.Checked = true;
                                comboBoxTickerSqOut.SelectedIndex = 0;
                            }
                        }

                        panelTickerEffects.Enabled = true;
                    }
                    catch (Exception) { }
                }
                else
                {
                    panelTickerEffects.Enabled = false;
                }
            }
            else
            {
                // Disable buttons
                buttonTickerAddText.Enabled = false;
                buttonTickerAddFile.Enabled = false;
                buttonTickerRewind.Enabled = false;
                panelTickerEffects.Enabled = false;
            }
        }

        private void SetTickerShow_n_Hide( string strTickerID )
        {
            string strShow = "";
            if (checkBoxTickerFadeIn.Checked)
                strShow += "fade";

            if (checkBoxTickerMoveIn.Checked)
            {
                if (strShow != "") strShow += ", ";
                strShow += comboBoxTickerMoveIn.SelectedItem.ToString();
            }

            if (checkBoxTickerBlurIn.Checked)
            {
                if (strShow != "") strShow += ", ";

                strShow += comboBoxTickerBlurIn.SelectedIndex == 1 ? "blur-x" :
                    comboBoxTickerBlurIn.SelectedIndex == 2 ? "blur-y" : "blur";
            }

            if (checkBoxTickerSqIn.Checked)
            {
                if (strShow != "") strShow += ", ";

                strShow += comboBoxTickerSqIn.SelectedIndex == 1 ? "squeeze-x" :
                    comboBoxTickerSqIn.SelectedIndex == 2 ? "squeeze-y" : "squeeze";
            }

            string strHide = "";
            if (checkBoxTickerFadeOut.Checked)
                strHide += "fade";

            if (checkBoxTickerMoveOut.Checked)
            {
                if (strHide != "") strHide += ", ";
                strHide += comboBoxTickerMoveOut.SelectedItem.ToString();
            }

            if (checkBoxTickerBlurOut.Checked)
            {
                if (strHide != "") strHide += ", ";

                strHide += comboBoxTickerBlurOut.SelectedIndex == 1 ? "blur-x" :
                    comboBoxTickerBlurOut.SelectedIndex == 2 ? "blur-y" : "blur";
            }

            if (checkBoxTickerSqOut.Checked)
            {
                if (strHide != "") strHide += ", ";

                strHide += comboBoxTickerSqOut.SelectedIndex == 1 ? "squeeze-x" :
                    comboBoxTickerSqOut.SelectedIndex == 2 ? "squeeze-y" : "squeeze";
            }
                
            try
            {
                m_pMLCharGen.SetItemProperties(strTickerID, "group-show", strShow, "", 0);
                m_pMLCharGen.SetItemProperties(strTickerID, "group-hide", strHide, "", 0);
            }
            catch (System.Exception){}
        }

        private void buttonTickerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strTickerDesc = "";

                if (comboBoxTickerBG.SelectedItem == "none")
                {
                    strTickerDesc = comboBoxTickerType.SelectedItem.ToString();
                }
                else
                {
                    if (comboBoxTickerBG.SelectedItem == "image")
                    {
                        // Set background image (optional)
                        if (openFileCG.ShowDialog(this) == DialogResult.OK)
                        {
                            strTickerDesc = "<ticker type='" + comboBoxTickerType.SelectedItem + "'>" +
                                "<background img='" + openFileCG.FileName + "'>";

                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (comboBoxTickerBG.SelectedItem == "graphics")
                    {
                        // Set background graphics (optional)
                        strTickerDesc = "<ticker type='" + comboBoxTickerType.SelectedItem + "'>" +
                                "<background color='ML(180)-White(180)'/>";
                    }

                    // Set default text props (optional)
                    strTickerDesc += "<default-text bold=true size='20'";
                    if (comboBoxTickerType.SelectedItem != "roll")
                    {
                        // Uppercase for all except rolls
                        strTickerDesc += " style='uppercase'";
                    }
                    strTickerDesc += "/></ticker>";
                }

                string strItemID = textBoxName.Text;
                if (strItemID == "<put new item name here>")
                {
                    // Use auto name
                    strItemID = "";
                }

                try
                {
                    // Add the item via XML desc
                    m_pMLCharGen.TickerAddNew(strTickerDesc, 0.05, 0.05, 0, 0, 1, 0, ref strItemID);
                }
                catch (Exception) {}

                textBoxName.Text = "<put new item name here>";

                UpdateList();

                try
                {
                    listViewItems.FindItemWithText( strItemID ).Selected = true;

                    buttonTickerAddFile_Click(sender, e);
                }
                catch (Exception) { }

            }
            catch (System.Exception){}
        }

        private void buttonTickerAddFile_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                if( openFileTxt.ShowDialog(this) == DialogResult.OK )
                {
                    try
                    {
                        m_pMLCharGen.TickerAddContent(listViewItems.SelectedItems[0].Text, openFileTxt.FileName, checkBoxTikcerReplace.Checked ? "remove-all" : "" );
                    }
                    catch (Exception) { }
                }
            }
        }

        private void buttonTickerAddText_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0 && !textBoxTickerText.Text.StartsWith("<put ") )
            {
                try
                {
                    string sParam = "multiline" + (checkBoxTikcerReplace.Checked ? ", remove-all" : "");
                    m_pMLCharGen.TickerAddContent(listViewItems.SelectedItems[0].Text, textBoxTickerText.Text, sParam);
                }
                catch (Exception) { }
                
            }
        }
        private void textBoxTickerText_Leave(object sender, EventArgs e)
        {
            TextBox pTextBox = (TextBox)sender;
            if (pTextBox.Text == "" || pTextBox.Text.StartsWith("<put ") )
            {
                pTextBox.Text = "<put text lines here - for add to ticker or replace ticker content>\r\n" +
                "\r\n" + 
                "Note:\r\n" + 
                "- You can use the [[item-id]] tags or text format tags:\r\n" +
                "[[logo]]Some Text<tab/><font color='red' bg-color='white'>Red Text</font>";

                pTextBox.ForeColor = Color.Gray;
            }
        }

        private void checkBoxTickerEffects_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTickerFadeIn.Focused || checkBoxTickerMoveIn.Focused || checkBoxTickerSqIn.Focused || checkBoxTickerBlurIn.Focused ||
                checkBoxTickerFadeOut.Focused || checkBoxTickerMoveOut.Focused || checkBoxTickerSqOut.Focused || checkBoxTickerBlurOut.Focused )
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    SetTickerShow_n_Hide(listViewItems.SelectedItems[0].Text);
                }
            }

        }

        private void comboBoxTickerEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTickerMoveIn.Focused || comboBoxTickerBlurIn.Focused || comboBoxTickerSqIn.Focused ||
                comboBoxTickerMoveOut.Focused || comboBoxTickerBlurOut.Focused || comboBoxTickerSqOut.Focused)
            {
                if (listViewItems.SelectedItems.Count > 0)
                {
                    SetTickerShow_n_Hide(listViewItems.SelectedItems[0].Text);
                }
            }
        }

        #endregion

        // The groups implementation (Pro version only) below
        #region Group Implementation

        private string m_cbsCurrentGroup;

        private bool HaveCheckedItems() 
        {
            for (int i = 0; i < listViewItems.Items.Count; i++)
            {
                if (listViewItems.Items[i].Checked)
                {
                    return true;
                }
            }

            return false;
        }

        private void UpdateGroup()
        {
            if (m_cbsCurrentGroup != "" )
            {
                panelGroup.Enabled = false;
            }
            else
            {
                panelGroup.Enabled = true;
                bool bAddToGroup = false;
                bool bHaveChecked = HaveCheckedItems();

                if (listViewItems.SelectedItems.Count > 0)
                {
                    if (!listViewItems.SelectedItems[0].Checked)
                    {
                        bAddToGroup = bHaveChecked ? true : false;
                    }

                    try
                    {
                        string strDesc;
                        CG_ITEM_PROPS cgProps;
                        m_pMLCharGen.GetItemBaseProps(listViewItems.SelectedItems[0].Text, out strDesc, out cgProps);

                        if (((int)cgProps.eType & (int)eCG_ItemType.eCGIT_Group) != 0)
                        {
                            buttonGroupRemoveAll.Enabled = true;
                            buttonGroupSetIndent.Enabled = true;
                        }
                        else
                        {
                            buttonGroupRemoveAll.Enabled = false;
                            buttonGroupSetIndent.Enabled = true;
                        }
                    }
                    catch (System.Exception) { }

                    buttonGroupAddBG.Enabled = !bAddToGroup && comboBoxItemType.SelectedItem == "graphics";
                    buttonGroupAddVA.Enabled = !bAddToGroup;
                }
                else
                {
                    buttonGroupAddBG.Enabled = bHaveChecked && comboBoxItemType.SelectedItem == "graphics";
                    buttonGroupAddVA.Enabled = bHaveChecked;
                    buttonGroupRemoveAll.Enabled = false;
                }

                buttonGroupAdd.Text = bAddToGroup ? "Add to Group" : "Group Items";
                buttonGroupAdd.Enabled = bHaveChecked;
                buttonGroupRemove.Enabled = false;
            }
        }
    
        private void GroupItems( string strGroupID, string strGroupType )
        {
            if(strGroupID == "")
            {
                strGroupID = GetNewItemID();
                if (listViewItems.SelectedItems.Count > 0 && !listViewItems.SelectedItems[0].Checked)
                {
                    strGroupID = listViewItems.SelectedItems[0].Text;
                }
            }

            bool bAdd = false;
            for (int i = 0; i < listViewItems.Items.Count; i++)
            {
                if (listViewItems.Items[i].Checked)
                {
                    try
                    {
                        m_pMLCharGen.GroupAddItem(listViewItems.Items[i].Text, 0, strGroupType, ref strGroupID);

                        bAdd = true;
                    }
                    catch (System.Exception) { }
                }
            }

            if (!bAdd && listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    m_pMLCharGen.GroupAddItem(listViewItems.SelectedItems[0].Text, 0, strGroupType, ref strGroupID);
                }
                catch (System.Exception) { }
            }
        }

        private void buttonGroupAdd_Click(object sender, EventArgs e)
        {
            GroupItems("", "");

            UpdateList();
        }

        private void buttonGroupAddBG_Click(object sender, EventArgs e)
        {
            if (comboBoxItemType.SelectedItem == "graphics")
            {
                string strItemID = GetNewItemID();
                try
                {
                    // Add the item via XML desc
                    m_pMLCharGen.AddNewItem(textBoxItemDesc.Text, 0.05, 0.05, 1, 1, ref strItemID);

                    GroupItems(strItemID, "background");

                    UpdateList();
                }
                catch (Exception) { }

                textBoxName.Text = "<put new item name here>";
            }
        }

        private void buttonGroupAddVA_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 0 || listViewItems.SelectedItems[0].Checked || !HaveCheckedItems() ) 
            {
                GroupItems("", "view-area");

                UpdateList();
            }
        }

        private void buttonGroupRemoveAll_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    m_pMLCharGen.GroupRemoveAll(listViewItems.SelectedItems[0].Text, eCG_GroupItemsRemoveType.eCGRT_Ungroup);
                }
                catch (System.Exception){}

                UpdateList();
            }
        }

        private void buttonGroupSetIndent_Click(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count > 0)
            {
                try
                {
                    string strIndent = "<group-indent left='" + numericGroupLeft.ToString() +
                        "' right='" + numericGroupLeft.ToString() +
                        "' top='" + numericGroupLeft.ToString() +
                        "' bottom='" + numericGroupLeft.ToString() + "'/>";

                    // We can use "cg-props::group-indent::left" for set separated properties
                    // e.g. m_pMLCharGen.SetItemProperties(strItemID, "cg-props::group-indent::left", "10.0", "", 0);
                    // Update several indent values
                    // e.g. m_pMLCharGen.SetItemProperties(strItemID, "cg-props::group-indent", "left='10.0' right='20.0'", "", 0);
                    // or specify the whole 'group-indent' node
                    m_pMLCharGen.SetItemProperties(listViewItems.SelectedItems[0].Text, "cg-props", strIndent, "", 0);
                }
                catch (System.Exception) { }
            }
        }

        #endregion

        // Compositions Implementation (Pro version only)
        #region Compositions Implementation

        public void UpdateCompositionsList()
        {
            listViewCompositions.Items.Clear();

            try
            {
                int nCount = 0;
                m_pMLCharGen.CompositionsGetCount(out nCount);

                for( int i = 0; i < nCount; i++ )
                {
                    string strName;
                    string strComment;
                    m_pMLCharGen.CompositionsGetByIndex(i, out strName, out strComment);

                    ListViewItem lvItem = listViewCompositions.Items.Add(strName, 3);
                    if (strComment != null )
                        lvItem.SubItems.Add( strComment );
                }
            }
            catch (System.Exception e){};

            for (int j = 0; j < listViewCompositions.Columns.Count - 1; j++)
            {
                listViewCompositions.Columns[j].Width = -2;
            }

            UpdateCompositionsState();
        }

        private void UpdateCompositionsState()
        {
            if (HaveCheckedItems())
                buttonCompAdd.Text = "Add Items";
            else
                buttonCompAdd.Text = "Add All";

            if( listViewCompositions.SelectedItems.Count > 0 )
            {
                buttonCompDisplay.Enabled = true;
                buttonCompExit.Enabled = true;
                buttonCompSave.Text = "Save One";
            }
            else
            {
                buttonCompDisplay.Enabled = false;
                buttonCompExit.Enabled = false;
                buttonCompSave.Text = "Save All";
            }
        }

        private void buttonCompAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strCompositionID = "";
                bool bHaveChecked = HaveCheckedItems();
                for (int i = 0; i < listViewItems.Items.Count; i++)
                {
                    if (!bHaveChecked || listViewItems.Items[i].Checked)
                    {
                        m_pMLCharGen.CompositionsAddItems(listViewItems.Items[i].Text, 0, "", ref strCompositionID);
                    }
                }

                UpdateCompositionsList();

                listViewCompositions.FindItemWithText(strCompositionID).Selected = true;
            }
            catch (Exception) { }
        }

        private void buttonCompRemove_Click(object sender, EventArgs e)
        {
            if (listViewCompositions.SelectedItems.Count > 0)
            {
                m_pMLCharGen.CompositionsRemove(listViewCompositions.SelectedItems[0].Text);

                UpdateCompositionsList();
            }
        }

        private void buttonCompSave_Click(object sender, EventArgs e)
        {
            if( saveFileComp.ShowDialog(this) == DialogResult.OK )
            {
                string strCompName = "";
                if (listViewCompositions.SelectedItems.Count > 0)
                {
                    strCompName = listViewCompositions.SelectedItems[0].Text;
                }

                try
                {
                    m_pMLCharGen.CompositionsSaveToFile(strCompName, saveFileComp.FileName);
                }
                catch (System.Exception){}
            }
        }

        private void buttonCompLoad_Click(object sender, EventArgs e)
        {
            if (openFileComp.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    m_pMLCharGen.CompositionsLoadAll(openFileComp.FileName, 0 );
                }
                catch (System.Exception) { }

                UpdateCompositionsList();
            }
        }

        private void buttonCompDisplay_Click(object sender, EventArgs e)
        {
            if (listViewCompositions.SelectedItems.Count > 0)
            {
                string strParam = textBoxCompParam.Text;
                m_pMLCharGen.CompositionsDisplay(listViewCompositions.SelectedItems[0].Text, strParam, 
                    (double)numericCompIn.Value, (double)numericCompShow.Value, (double)numericCompExit.Value );

                UpdateList();
            }
        }

        private void buttonCompExit_Click(object sender, EventArgs e)
        {
            if (listViewCompositions.SelectedItems.Count > 0)
            {
                string strParam = textBoxCompParam.Text.StartsWith("<put ") ? "" : textBoxCompParam.Text;

                m_pMLCharGen.CompositionsDisplay(listViewCompositions.SelectedItems[0].Text, strParam,
                    -1 * (double)numericCompIn.Value, 0, 0 );

                UpdateList();
            }
        }
        private void listViewCompositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCompositionsState();
        }


        private void listViewCompositions_DoubleClick(object sender, EventArgs e)
        {
            // Show rename dialog
        }



        #endregion

        private void textBoxCompParam_Leave(object sender, EventArgs e)
        {
            TextBox pTextBox = (TextBox)sender;
            if (pTextBox.Text == "" || pTextBox.Text.StartsWith("<put "))
            {
                pTextBox.Text = "<put display parameters here e.g.\r\n" +
                    "item-id::text='Some New Text'\r\n" +
                    "item-id::color='Red(90)-Blue-White'\r\n" +
                    "ticker-id::content='file-path.txt'>";

                pTextBox.ForeColor = Color.Gray;
            }
        }

        

        
    }
}