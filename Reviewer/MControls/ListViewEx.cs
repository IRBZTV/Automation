using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MControls
{
    public partial class ListViewEx : ListView
    {
        public event EventHandler ListSubItemChanged;
        public event EventHandler ListSubItemOnStartChange;
        
        public ListViewEx()
        {
            InitializeComponent();
        }

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int MOUSEWHEEL = 0x020A;
        private const int KEYDOWN = 0x0100;
        private Control pEditControl = null;
        
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (pEditControl != null && (m.Msg == MOUSEWHEEL || m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL))
            {
                // Trap WM_VSCROLL 

                if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL )
                {
                    pEditControl.Visible = false;
                    pEditControl = null;

                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        public ListViewItem AddNewItem(string sText, int imageIndex )
        {
            ComboBox pCombo;
            return AddNewItem_Combo(sText, imageIndex, out pCombo);
        }

        public void SetRowBGColor(int nRow, Color color)
        {
            ListViewItem lvItem = Items[nRow];
            lvItem.BackColor = color;
            for (int i = 0; i < lvItem.SubItems.Count; i++)
            {
                lvItem.SubItems[i].BackColor = color;
            }
        }

        public ListViewItem AddNewItem_Combo(string sText, int imageIndex, out ComboBox pCombo)
        {
            pCombo = null;

            ListViewItem lvItem = Items.Add(sText, imageIndex);
            for (int i = 1; i < Columns.Count; i++)
            {
                ListViewItem.ListViewSubItem lvSubItem = lvItem.SubItems.Add("");
                if (Columns[i].Tag != null)
                {
                    string sType = Columns[i].Tag.GetType().Name;
                    if (sType == "ComboBox")
                    {
                        pCombo = SubItem_SetCombo(lvSubItem, (ComboBox)Columns[i].Tag);
                        pCombo.Tag = new ListViewEx_EventArgs(lvItem, lvSubItem, Items.Count - 1, i);
                        // TODO: Copy props/def items from column ComboBox
//                         pCombo = new ComboBox();
// 
//                         pCombo.Visible = false;
//                         pCombo.Parent = this;
//                         pCombo.FlatStyle = FlatStyle.Flat;
//                         pCombo.Tag = new ListViewEx_EventArgs(lvItem, lvSubItem, Items.Count - 1, i);
//                         pCombo.DropDownStyle = ComboBoxStyle.DropDownList;
//                         pCombo.SelectedIndexChanged += new EventHandler(pCombo_EditDone);
//                         pCombo.DropDownClosed += new EventHandler(pCombo_DropDownClosed);
//                         lvSubItem.Tag = pCombo;
                    }
                }
            }

            return lvItem;
        }

        public ComboBox SubItem_SetCombo(ListViewItem.ListViewSubItem lvSubItem, ComboBox pDefault)
        {
            return SubItem_SetCombo( lvSubItem, pDefault, ComboBoxStyle.DropDownList );
        }
        public ComboBox SubItem_SetCombo(ListViewItem.ListViewSubItem lvSubItem, ComboBox pDefault, ComboBoxStyle cbxStyle)
        {
            // TODO: Copy props/def items from column ComboBox
            ComboBox pCombo = new ComboBox();

            pCombo.Visible = false;
            pCombo.Parent = this;
            pCombo.FlatStyle = FlatStyle.Flat;
            pCombo.DropDownStyle = cbxStyle;
            pCombo.SelectedIndexChanged += new EventHandler(pCombo_EditDone);
            pCombo.DropDownClosed += new EventHandler(pCombo_DropDownClosed);
            if (cbxStyle != ComboBoxStyle.DropDownList)
            {
                pCombo.Leave += new EventHandler(pControl_Leave);
                pCombo.KeyDown += new KeyEventHandler(pControl_KeyDown);
            }
            lvSubItem.Tag = pCombo;

            return pCombo;
        }

        public void SubItem_SetControl(ListViewItem.ListViewSubItem lvSubItem, Control pControl)
        {
            pControl.Visible = false;
            pControl.Parent = this;
            pControl.Leave += new EventHandler(pControl_Leave);
            pControl.KeyDown += new KeyEventHandler(pControl_KeyDown);
            pControl.DoubleClick += new EventHandler(pControl_DoubleClick);
            lvSubItem.Tag = pControl;
        }

        public DateTimePicker SubItem_SetDTPicker(ListViewItem.ListViewSubItem lvSubItem)
        {
            // TODO: Copy props/def items from column ComboBox
            DateTimePicker pPicker = new DateTimePicker();

            pPicker.Visible = false;
            pPicker.Parent = this;
            pPicker.Format = DateTimePickerFormat.Custom;
            pPicker.KeyDown += new KeyEventHandler(pPicker_KeyDown);
            pPicker.DropDown += new EventHandler(pPicker_DropDown);
            pPicker.Leave += new EventHandler(pPicker_Leave);
            lvSubItem.Tag = pPicker;


            return pPicker;
        }

        void pPicker_Leave(object sender, EventArgs e)
        {
            DateTimePicker dtPicker = (DateTimePicker)sender;
            if (dtPicker.CustomFormat == "HH':'mm':'ss")
            {
                dtPicker.Text = String.Format("{0,0:00}:{1,0:00}:{2,0:00}", dtPicker.Value.Hour, dtPicker.Value.Minute, dtPicker.Value.Second);
            }
            ListTextChange(dtPicker);
            dtPicker.Visible = false;
            dtPicker.Parent.Focus();
            pEditControl = null;
        }

        void pPicker_DropDown(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).CustomFormat = @"dd'.'MM'.'yyyy HH':'mm':'ss";
        }

        void pPicker_KeyDown(object sender, KeyEventArgs e)
        {
            DateTimePicker dtPicker = (DateTimePicker)sender;
            if (e.KeyCode == Keys.Return)
            {
                if (dtPicker.CustomFormat == "HH':'mm':'ss")
                {
                    dtPicker.Text = String.Format("{0,0:00}:{1,0:00}:{2,0:00}", dtPicker.Value.Hour, dtPicker.Value.Minute, dtPicker.Value.Second);
                }
                ListTextChange(dtPicker);
                dtPicker.Visible = false;
                dtPicker.Parent.Focus();
                pEditControl = null;
            }
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {

                dtPicker.Format = DateTimePickerFormat.Custom;
                dtPicker.CustomFormat = " ";

                dtPicker.Visible = false;
                dtPicker.Parent.Focus();
                pEditControl = null;
            }
        }

        public int GetClickedColumn(Point ptClick, out Rectangle rcItem )
        {
            // Get column number
            rcItem = new Rectangle();
            if( SelectedItems.Count > 0 && SelectedItems[0].SubItems.Count > 0 )
            {
                Rectangle rcBounds = SelectedItems[0].SubItems[0].Bounds;
                if( SelectedItems[0].SubItems.Count > 1 )
                    rcBounds.Width = SelectedItems[0].SubItems[1].Bounds.Left;

                if( rcBounds.Contains( ptClick ) )
                {
                    rcItem = rcBounds;
                    return 0;
                }

                for( int i = 1; i < SelectedItems[0].SubItems.Count; i++ )
                {
                    if (SelectedItems[0].SubItems[i].Bounds.Contains(ptClick))
                    {
                        rcItem = SelectedItems[0].SubItems[i].Bounds;
                        return i;
                    }
                }
            }

            return -1;
        }
        public void EndEdit()
        {
            if (pEditControl != null)
            {
                pEditControl.Visible = false;
                if (pEditControl != null && pEditControl.Parent != null)
                    pEditControl.Parent.Focus();
                pEditControl = null;
            }
        }
        public bool BeginEdit( int nRow, int nCol )
        {
            if (nRow < 0 || nRow >= Items.Count ||
                nCol < 0 || nCol >= Items[nRow].SubItems.Count )
                return false;

            ListViewItem lvItem = Items[nRow];

            EnsureVisible(nRow);

            Rectangle rcBounds = lvItem.SubItems[nCol].Bounds;
            if (nCol == 0 && lvItem.SubItems.Count > 1 )
            {
                // Special fix for first column -> all item width returned
                rcBounds.Width = lvItem.SubItems[1].Bounds.Left - 1;
            }

            ListViewEx_EventArgs pArg = new ListViewEx_EventArgs(lvItem, lvItem.SubItems[nCol], nRow, nCol);

            // Event for cancel
            {
                EventHandler handler = this.ListSubItemOnStartChange;
                if (handler != null)
                {
                    handler(this, pArg);
                    if (pArg.Cancel)
                        return false;
                }
            }

            // Check object type
//             if (Columns[nCol].Tag != null && Columns[nCol].Tag.GetType().Name == "ComboBox")
//             {
//                 try
//                 {
//                     ComboBox pCombo = (ComboBox)lvItem.SubItems[nCol].Tag;
// 
//                     if (pCombo.Items.Count > 1)
//                     {
//                         pCombo.Bounds = rcBounds;
//                         pCombo.Visible = true;
//                        // pCombo.Focus(); // Some flickering in ListView if Focused() TODO: Fix
//                         pCombo.DroppedDown = true;
//                     }
// 
//                     pEditControl = pCombo;
//                 }
//                 catch (System.Exception) { }
//             }
//             else 
            {
                try
                {
                    Control pControl = null;
                    if (lvItem.SubItems[nCol].Tag != null)
                    {
                        try
                        {
                            pControl = (Control)lvItem.SubItems[nCol].Tag;
                        }
                        catch (System.Exception) { }
                    }

                    if (pControl == null && Columns[nCol].Tag != null )
                        pControl = (Control)Columns[nCol].Tag;

                    if (pControl == null || !pControl.Enabled )
                        return false;

                    if (pControl.Tag == null && pControl.GetType().Name != "DateTimePicker")
                    {
                        pControl.Leave += new EventHandler(pControl_Leave);
                        pControl.KeyDown += new KeyEventHandler(pControl_KeyDown);
                        pControl.DoubleClick += new EventHandler(pControl_DoubleClick);
                    }

                    pControl.Parent = this;
                    pControl.Bounds = rcBounds;
                    if (pControl.GetType().Name != "DateTimePicker")
                    {
                        pControl.Text = lvItem.SubItems[nCol].Text;
                    }

                    if (pControl.Tag != null )
                    {
                        if (pControl.Tag.GetType().Name != "ListViewEx_EventArgs")
                            pArg.Tag = pControl.Tag;
                        else
                            pArg.Tag = ((ListViewEx_EventArgs)pControl.Tag).Tag;
                    }
                    pControl.Tag = pArg;
                    pControl.Visible = true;
                    if (pControl.GetType().Name == "ComboBox")
                    {
                        ((ComboBox)pControl).DroppedDown = true;
                    }
                    else
                    {
                        pControl.Focus();
                    }

                    pEditControl = pControl;
                }
                catch (System.Exception ex) { }
            }

            return true;
        }

        
        private bool OnListClick(Point ptLocation)
        {
            Rectangle rcBounds;
            int nCol = GetClickedColumn(ptLocation, out rcBounds);
            if (nCol >= 0 && nCol < Columns.Count && 
                (Columns[nCol].Tag != null || SelectedItems[0].SubItems[nCol].Tag != null) )
            {
                return BeginEdit( SelectedIndices[0], nCol);
            }

            return false;
        }

        // List events
        private void ListViewEx_MouseClick(object sender, MouseEventArgs e)
        {
            OnListClick(e.Location);
        }

        private void ListViewEx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnListClick(e.Location);
        }



        // Items events
        void pCombo_EditDone(object sender, EventArgs e)
        {
            ComboBox pCombo = (ComboBox)sender;
            ListViewEx_EventArgs evArg = (ListViewEx_EventArgs)pCombo.Tag;
            if (evArg != null)
            {
                evArg.strPrevValue = evArg.lvSubItem.Text;
                evArg.lvSubItem.Text = pCombo.Text;
                // For handler
                EventHandler handler = this.ListSubItemChanged;
                if (handler != null)
                {
                    handler(this, evArg);
                    if (evArg.Cancel)
                    {
                        evArg.lvSubItem.Text = evArg.strPrevValue;
                    }
                }

                pCombo.Visible = false;
                pCombo.Parent.Focus();
                pEditControl = null;
            }
        }

        void pCombo_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox pCombo = (ComboBox)sender;
            if (pCombo.DropDownStyle != ComboBoxStyle.DropDown)
            {
                pCombo.Visible = false;
                pCombo.Parent.Focus();
                pEditControl = null;
            }
        }

        void pControl_DoubleClick(object sender, EventArgs e)
        {
            Control pControl = (Control)sender;
            if (pControl.Tag != null)
            {
                // e.g. Browse for file
                try
                {
                    ListViewEx_EventArgs pArg = (ListViewEx_EventArgs)pControl.Tag;
                    FileDialog pDialog = (FileDialog)pArg.Tag;
                    if (pDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (pDialog.FileName != null)
                        {
                            pControl.Text = pDialog.FileName;
                            pControl_Leave(sender, e);
                        }
                    }
                }
                catch (System.Exception) { }
            }
        }

        void pControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Escape)
            {
                Control pText = (Control)sender;
                if (e.KeyCode == Keys.Return)
                {
                    ListTextChange(pText);
                }

                //pText.Text = "";
                pText.Visible = false;
                pText.Parent.Focus();
                pEditControl = null;
            }
        }

        void pControl_Leave(object sender, EventArgs e)
        {
            Control pText = (Control)sender;
            if (pText.Text != "")
            {
                ListTextChange(pText);
            }
            pText.Visible = false;
            pText.Parent.Focus();
            pEditControl = null;
        }

        void ListNumChange(NumericUpDown pNumeric)
        {
            ListViewEx_EventArgs evArg = (ListViewEx_EventArgs)pNumeric.Tag;
            evArg.strPrevValue = evArg.lvSubItem.Text;
            evArg.lvSubItem.Text = pNumeric.Value.ToString();

            // For handler
            EventHandler handler = this.ListSubItemChanged;
            if (handler != null)
            {
                handler(this, evArg);
                if (evArg.Cancel)
                {
                    evArg.lvSubItem.Text = evArg.strPrevValue;
                }
            }
        }

        private void ListTextChange(Control pText)
        {
            ListViewEx_EventArgs evArg = (ListViewEx_EventArgs)pText.Tag;
            if (evArg.lvSubItem.Text != pText.Text)
            {
                evArg.strPrevValue = evArg.lvSubItem.Text;
                evArg.lvSubItem.Text = pText.Text;

                // For handler
                EventHandler handler = this.ListSubItemChanged;
                if (handler != null)
                {
                    handler(this, evArg);
                    if (evArg.Cancel)
                    {
                        evArg.lvSubItem.Text = evArg.strPrevValue;
                    }
                }
            }
        }
    }

    public class ListViewEx_EventArgs : CancelEventArgs
    {
        public ListViewItem lvItem;
        public ListViewItem.ListViewSubItem lvSubItem;
        public int nSubItem;
        public int nItem;
        public Object Tag;
        public string strPrevValue;

        public ListViewEx_EventArgs(ListViewItem _lvItem, ListViewItem.ListViewSubItem _lvSubItem, int _nItem, int _nSubItem)
        {
            lvItem = _lvItem;
            lvSubItem = _lvSubItem;
            nItem = _nItem;
            nSubItem = _nSubItem;
        }
    }
}

