using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class MPlaylistList : UserControl
    {
        IMPlaylist m_pPlaylist;

        public MPlaylistList()
        {
            InitializeComponent();

            // For edit command
            listViewFiles.Columns[2].Tag = new TextBox();

            // Set edit boxes for In/Out
            listViewFiles.Columns[3].Tag = new TextBox(); //pNumInOut;
            listViewFiles.Columns[4].Tag = new TextBox(); //pNumInOut;

            // Set edit box for Time
            //listViewFiles.Columns[1].Tag = new DateTimePicker();

        }


        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pPlaylist;
            try
            {
                m_pPlaylist = (IMPlaylist)pObject;

                UpdateList( false );

                ((MPlaylist)m_pPlaylist).OnEvent += new IMEvents_OnEventEventHandler(MPlaylistControl_OnEvent);
            }
            catch (System.Exception) { }

            return pOld;
        }

        // Called if user change playlist selection
        public event EventHandler OnPlaylistSelChanged;

        // Called if playlist changed (files,added, removed, rearanged, etc.) 
        public event EventHandler OnPlaylistChanged;

        public MItem SelectedItem
        {
            get
            {
                if (listViewFiles.SelectedItems.Count > 0)
                    return (MItem)listViewFiles.SelectedItems[0].Tag;

                return null;
            }
        }
   
        void MPlaylistControl_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            UpdateListState();
        }

        public void SelectFile(IMFile pFile)
        {
            for (int i = 0; i < listViewFiles.Items.Count; i++)
            {
                if (pFile.Equals(listViewFiles.Items[i].Tag))
                {
                    listViewFiles.Items[i].Selected = true;
                    listViewFiles.EnsureVisible(i);
                }
                else
                {
                    listViewFiles.Items[i].Selected = false;
                }
            }
        }

        void ClearList()
        {
            for (int i = 0; i < listViewFiles.Items.Count; i++)
            {
                if (listViewFiles.Items[i].Tag != null)
                {
                    MItem pItem = (MItem)listViewFiles.Items[i].Tag;
                    // Not necessary, but for not keep reference in memory
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                }
            }

            listViewFiles.Items.Clear();

            GC.Collect();
        }

        public void UpdateList(bool _bKeepSelection)
        {
            try
            {
                IMFile pSelFile = null;
                if (listViewFiles.SelectedItems.Count > 0)
                    pSelFile = (IMFile)listViewFiles.SelectedItems[0].Tag;

                ClearList();

                int nFiles = 0;
                double dblDuration = 0;
                m_pPlaylist.PlaylistGetCount(out nFiles, out dblDuration);
                for (int i = 0; i < nFiles; i++)
                {
                    double dblPos;
                    string strPathOrCommand;
                    MItem pItem;
                    m_pPlaylist.PlaylistGetByIndex(i, out dblPos, out strPathOrCommand, out pItem);

                    // Check type
                    eMItemType eItemType;
                    pItem.ItemTypeGet(out eItemType);
                    int nImage = eItemType == eMItemType.eMPIT_Playlist ? 2 : 
                        eItemType == eMItemType.eMPIT_Live ? 1 : 
                        eItemType == eMItemType.eMPIT_Command ? 3 : 0;

                    M_DATETIME mTimeStart;
                    M_DATETIME mTimeStop;
                    eMStartType eStartType;
                    pItem.ItemTimesGet(out mTimeStart, out mTimeStop, out eStartType);

                    if (eItemType != eMItemType.eMPIT_Command)
                    {
                        string strFile = strPathOrCommand.Substring(strPathOrCommand.LastIndexOf('\\') + 1);

                        int nIdxFake;
                        M_VID_PROPS vidProps;
                        M_AUD_PROPS audProps;
                        string strFormat;
                        ((IMFormat)pItem).FormatVideoGet(eMFormatType.eMFT_Input, out vidProps, out nIdxFake, out strFormat);
                        ((IMFormat)pItem).FormatAudioGet(eMFormatType.eMFT_Input, out audProps, out nIdxFake, out strFormat);

                        double dblIn = 0, dblOut = 0, dblFileDuration = 0;
                        pItem.FileInOutGet(out dblIn, out dblOut, out dblFileDuration);

                        eMState eState;
                        double dblTime = 0;
                        pItem.FileStateGet(out eState, out dblTime);

                        ListViewItem lvItem = listViewFiles.Items.Add(MHelpers.PosToString(dblPos, 0), nImage);

                        ListViewItem.ListViewSubItem lvTimeSubitem = lvItem.SubItems.Add(MHelpers.ToString(mTimeStart));
                        DateTimePicker dtPicker = listViewFiles.SubItem_SetDTPicker(lvTimeSubitem);
                        if (mTimeStart.nYear > dtPicker.MinDate.Year)
                        {
                            dtPicker.CustomFormat = @"dd'.'MM'.'yyyy HH':'mm':'ss";
                        }
                        else
                        {
                            dtPicker.CustomFormat = @"HH':'mm':'ss";
                        }

                        lvItem.UseItemStyleForSubItems = false;
                        if (eStartType == eMStartType.eMST_Off)
                        {
                            //lvTimeSubitem.Font = new System.Drawing.Font(lvItem.Font, FontStyle.Italic);
                            lvTimeSubitem.Font = lvItem.Font;
                            lvTimeSubitem.ForeColor = Color.DarkGray;
                        }
                        else if (eStartType == eMStartType.eMST_Auto)
                        {
                            lvTimeSubitem.Font = lvItem.Font;
                            lvTimeSubitem.ForeColor = Color.Black;
                        }
                        else if (eStartType == eMStartType.eMST_Specified)
                        {
                            lvTimeSubitem.Font = new System.Drawing.Font(lvItem.Font, FontStyle.Bold);
                            lvTimeSubitem.ForeColor = Color.Black;
                        }
                        lvItem.SubItems.Add(strFile);
                        lvItem.SubItems.Add(MHelpers.PosToString(dblIn));
                        lvItem.SubItems.Add(MHelpers.PosToString(dblOut));
                        lvItem.SubItems.Add(MHelpers.PosToString(dblFileDuration));
                        lvItem.SubItems.Add(eState.ToString());
                        lvItem.SubItems.Add(MHelpers.ToString(vidProps) + " " + MHelpers.ToString(audProps));
                        lvItem.SubItems.Add(strPathOrCommand);
                       
                        lvItem.Tag = pItem;
                    }
                    else
                    {
                        string strParam;
                        Object pTarget;
                        pItem.ItemCommandGet(out strPathOrCommand, out strParam, out pTarget);

                        ListViewItem lvItem = listViewFiles.Items.Add(MHelpers.PosToString(dblPos), nImage);
                        ListViewItem.ListViewSubItem lvTimeSubitem = lvItem.SubItems.Add(MHelpers.ToString(mTimeStart));

                        lvItem.UseItemStyleForSubItems = false;
                        if (eStartType == eMStartType.eMST_Off)
                        {
                            //lvTimeSubitem.Font = new System.Drawing.Font(lvItem.Font, FontStyle.Italic);
                            lvTimeSubitem.Font = lvItem.Font;
                            lvTimeSubitem.ForeColor = Color.Gray;
                        }
                        else if (eStartType == eMStartType.eMST_Auto)
                        {
                            lvTimeSubitem.Font = lvItem.Font;
                            lvTimeSubitem.ForeColor = Color.Black;
                        }
                        else if (eStartType == eMStartType.eMST_Specified)
                        {
                            lvTimeSubitem.Font = new System.Drawing.Font(lvItem.Font, FontStyle.Bold);
                            lvTimeSubitem.ForeColor = Color.Black;
                        }

                        lvItem.SubItems.Add(strPathOrCommand);
                        lvItem.SubItems.Add(strParam);
                        lvItem.Tag = pItem;
                    }

                    listViewFiles.Columns[0].Width = -2;
                    //listViewFiles.Columns[1].Width = -2;
                    //listViewFiles.Columns[2].Width = -2;
                    listViewFiles.Columns[3].Width = -2;
                    listViewFiles.Columns[4].Width = -2;
                    listViewFiles.Columns[5].Width = -2;
                    listViewFiles.Columns[6].Width = -2;
                    listViewFiles.Columns[7].Width = -2;

                }

                if (pSelFile != null)
                    SelectFile(pSelFile);

                UpdateListState();
            }
            catch (System.Exception ex) { }
        }

        void UpdateListState()
        {
            try
            {
                double dblPos;
                string sCurrent;
                MItem pCurrent;
                m_pPlaylist.PlaylistGetByIndex(-1, out dblPos, out sCurrent, out pCurrent);

                MItem pNext;
                m_pPlaylist.PlaylistGetByIndex(-2, out dblPos, out sCurrent, out pNext);

                for (int i = 0; i < listViewFiles.Items.Count; i++)
                {
                    try
                    {
                        MItem pItem = (MItem)listViewFiles.Items[i].Tag;

                        eMItemType eType;
                        pItem.ItemTypeGet(out eType);
                        if (eType != eMItemType.eMPIT_Command)
                        {
                            eMState eState;
                            double dblTime;
                            pItem.FileStateGet(out eState, out dblTime);

                            listViewFiles.Items[i].SubItems[6].Text = eState.ToString();
                        }
//                         else
//                         {
//                             listViewFiles.Items[i].SubItems[6].Text = "";
//                         }

                        if (pCurrent == pItem)
                            listViewFiles.SetRowBGColor(i, Color.LightSkyBlue);// Color.FromArgb(150, 200, 255);
                        else if (pNext == pItem)
                            listViewFiles.SetRowBGColor(i, Color.FromArgb(222, 232, 254));
                        else
                            listViewFiles.SetRowBGColor(i, Color.White);
                    }
                    catch (System.Exception ex)
                    {
                        listViewFiles.Items[i].SubItems[6].Text = ex.ToString();
                    }
                }

            }
            catch (System.Exception)
            {
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                MItem pFile = null;
                Cursor prev = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < fileDialog.FileNames.Length; i++)
                {
                    int nIndex = -1;
                    m_pPlaylist.PlaylistAdd(null, fileDialog.FileNames[i], "", ref nIndex, out pFile);
                }
                this.Cursor = prev;
                UpdateList(true);

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(fileDialog.FileNames.Length > 1 ? null : pFile, e);

                Marshal.ReleaseComObject(pFile);
                GC.Collect();
            }
        }

        private void buttonAddList_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.FileNames.Length > 0 )
            {
                Cursor prev = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                // Add file (as playlist)
                int nIndex = -1;
                MItem pPlaylist;
                m_pPlaylist.PlaylistAdd(null, fileDialog.FileNames[0], "playlist", ref nIndex, out pPlaylist);

                // Add other files to this playlist
                for (int i = 1; i < fileDialog.FileNames.Length; i++)
                {
                    nIndex = -1;
                    MItem pFile;
                    ((IMPlaylist)pPlaylist).PlaylistAdd(null, fileDialog.FileNames[i], "", ref nIndex, out pFile);

                    Marshal.ReleaseComObject(pFile);
                }
                
                this.Cursor = prev;
                UpdateList(true);

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(pPlaylist, e);

                Marshal.ReleaseComObject(pPlaylist);
                GC.Collect();
            }
        }

        private void buttonAddLive_Click(object sender, EventArgs e)
        {
            int nIndex = -1;
            MItem pLive;
            
            m_pPlaylist.PlaylistAdd( null, "my_live", "live", ref nIndex, out pLive);
            UpdateList(true);

            // Notify about playlist changing
            if (this.OnPlaylistChanged != null)
                this.OnPlaylistChanged(pLive, e);

            Marshal.ReleaseComObject(pLive);
            GC.Collect();
        }

        private void buttonAddRef_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                int nIndex = -1;
                IMFile pFile = (IMFile)listViewFiles.SelectedItems[0].Tag;

                string strPath, strProps, strInfo;
                pFile.FileNameGet(out strPath);

                // TODO: Unique ID
                MItem pNewItem;
                m_pPlaylist.PlaylistAdd(pFile, strPath + ":ref", "", ref nIndex, out pNewItem);

                UpdateList(true);

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(pNewItem, e);

                Marshal.ReleaseComObject(pNewItem);
                GC.Collect();
            }
        }

        private void buttonAddCommand_Click(object sender, EventArgs e)
        {
            ListViewItem lvItem = listViewFiles.Items.Add("", 3);
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("<New Command>");
            lvItem.SubItems.Add(""); // For param, if not added -> can't edit
            listViewFiles.BeginEdit(listViewFiles.Items.Count - 1, 2);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0 )
            {
                if (listViewFiles.SelectedItems[0].Tag != null )
                {
                    MItem pItem = (MItem)listViewFiles.SelectedItems[0].Tag;

                    m_pPlaylist.PlaylistRemove(pItem);

                    // Not necessary, but for not keep reference in memory
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);

                    int nNewSelIndex = listViewFiles.Items.Count > listViewFiles.SelectedIndices[0] + 1 ?
                        listViewFiles.SelectedIndices[0] : listViewFiles.SelectedIndices[0] > 0 ? listViewFiles.SelectedIndices[0] - 1 : 0;

                    UpdateList(false);
                    if (nNewSelIndex >= 0 && listViewFiles.Items.Count > 0)
                    {
                        SelectFile((IMFile)listViewFiles.Items[nNewSelIndex].Tag);
                    }

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(null, e);
                }
                else
                {
                    // This is could be the new item for command: <New Command> (this item NOT have link ro real playlist item yet)
                    listViewFiles.Items.Remove(listViewFiles.SelectedItems[0]);
                }

                GC.Collect();
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                try
                {
                    m_pPlaylist.PlaylistReorder(listViewFiles.SelectedIndices[0], -1);
                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(null, e);
                }
                catch (System.Exception) { }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                try
                {
                    m_pPlaylist.PlaylistReorder(listViewFiles.SelectedIndices[0], 1);
                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(null, e);
                }
                catch (System.Exception) { }
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0 && listViewFiles.SelectedItems[0].Tag != null )
            {
                MItem pItem = (MItem)listViewFiles.SelectedItems[0].Tag;
                eMItemType eType;
                pItem.ItemTypeGet(out eType);

                // The commands can't be used as references
                buttonAddRef.Enabled = (eType != eMItemType.eMPIT_Command);
            }
            else
            {
                buttonAddRef.Enabled = false;
            }

            buttonRemove.Enabled = listViewFiles.SelectedItems.Count > 0;

            // For handler
            if (this.OnPlaylistSelChanged != null)
                this.OnPlaylistSelChanged(listViewFiles, e);
        }

        private void listViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0 && listViewFiles.SelectedItems[0].Tag != null )
            {

                Rectangle rcItem;
                int nCol = listViewFiles.GetClickedColumn(e.Location, out rcItem );
                if (nCol == 2)
                {
                    IMItem pItem = (IMItem)listViewFiles.SelectedItems[0].Tag; ;
                    eMItemType eType;
                    pItem.ItemTypeGet(out eType);
                    // Check for Live
                    if (eType == eMItemType.eMPIT_File)
                    {
                        // File
                        FormFileName formFile = new FormFileName();
                        formFile.m_pFile = (IMFile)listViewFiles.SelectedItems[0].Tag;
                        formFile.ShowDialog(this);
                    }
                    else if (eType == eMItemType.eMPIT_Live)
                    {
                        try
                        {
                            // TODO: Make non-modal
                            FormLive formLive = new FormLive();
                            formLive.m_pDevice = (IMDevice)listViewFiles.SelectedItems[0].Tag;
                            formLive.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                    else if (eType == eMItemType.eMPIT_Playlist)
                    {
                        try
                        {
                            // TODO: Make non-modal
                            FormPlaylist formPlaylist = new FormPlaylist();
                            formPlaylist.m_pPlaylist = (IMPlaylist)listViewFiles.SelectedItems[0].Tag;
                            formPlaylist.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                    else if (eType == eMItemType.eMPIT_Command)
                    {
                        try
                        {
                            // TODO: Make non-modal
                            FormCommand formCommand = new FormCommand();
                            formCommand.m_pPlaylistItem = pItem;
                            formCommand.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                }
                else
                {
                    // Check for command 
                    int nCurrent = listViewFiles.SelectedIndices[0];
                    m_pPlaylist.PlaylistPosSet( nCurrent, 0, 0);
                } 

                UpdateList(true);
            }
        }

        // For edit in/out

        private void listViewFiles_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;

            if (lvArg.nSubItem == 3 || lvArg.nSubItem == 4)
            {
                try
                {
                    ListViewItem lvItem = lvArg.lvItem;
                    MItem pItem = (MItem)lvItem.Tag;
                    eMItemType eItemType;
                    pItem.ItemTypeGet(out eItemType);
                    if (eItemType == eMItemType.eMPIT_Command)
                    {
                        // Update command
                        pItem.ItemCommandSet(lvItem.SubItems[2].Text, lvItem.SubItems[3].Text, null);
                    }
                    else
                    {
                        // Get new In/Out
                        double dblIn = MHelpers.ParsePos(lvItem.SubItems[3].Text);
                        double dblOut = MHelpers.ParsePos(lvItem.SubItems[4].Text);

                        // Set new in-out
                        pItem.FileInOutSet(dblIn, dblOut);
                    }
                    

                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(pItem, e);
                }
                catch (System.Exception) { }
            }
            else if (lvArg.nSubItem == 1)
            {
                try
                {
                    // Get new time
                    ListViewItem lvItem = lvArg.lvItem;
                    string strTime = lvItem.SubItems[1].Text;
                    
                    // Set new in-out
                    M_DATETIME mTime = new M_DATETIME();
                    MItem pFile = (MItem)lvItem.Tag;
                    if (strTime == " ")
                    {
                        // Disable start time
                        pFile.ItemStartTimeSet(ref mTime, eMStartType.eMST_Off);
                    }
                    else if (strTime == "a" || strTime == "auto")
                    {
                        // Disable start time
                        pFile.ItemStartTimeSet(ref mTime, eMStartType.eMST_Auto);
                    }
                    else 
                    {
                        // String to time
                        mTime = MHelpers.ParseDateTime(strTime);
                        pFile.ItemStartTimeSet(ref mTime, eMStartType.eMST_Specified);
                    }
                        

                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(pFile, e);
                }
                catch (System.Exception) { }
            }
            else if (lvArg.nSubItem == 2)
            {
                // New command
                try
                {
                    MItem pItem = null; 
                    if (lvArg.lvItem.Tag == null)
                    {
                        // New command
                        int nIndex = -1;
                        m_pPlaylist.PlaylistCommandAdd(lvArg.lvSubItem.Text, "", null, ref nIndex, out pItem);
                    }
                    else
                    {
                        // Update command
                        pItem = (MItem)lvArg.lvItem.Tag; 
                        pItem.ItemCommandSet(lvArg.lvItem.SubItems[2].Text, lvArg.lvItem.SubItems[3].Text, null);
                    }

                    UpdateList(true);

                    // Notify about breaks changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(pItem, e);

                }
                catch (System.Exception) { }
            }
        }

        private void listViewFiles_ListSubItemOnStartChange(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;
            if (lvArg.nSubItem == 2) // Only command can be edited
            {
                if (lvArg.lvItem.Tag != null) // If null -> the New command, can be edit
                {
                    // Check for command
                    lvArg.Cancel = true;
                }
            }
        }

        //
        private void listViewFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listViewFiles.DoDragDrop(listViewFiles.SelectedItems, DragDropEffects.Move);

        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            int len = e.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    //The data from the drag source is moved to the target.	
                    e.Effect = DragDropEffects.Move;
                }
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Files are dropped to playlist
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats()[0].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
            {
                //Return if the items are not selected in the ListView control.
                if (listViewFiles.SelectedItems.Count == 0)
                {
                    return;
                }
                //Returns the location of the mouse pointer in the ListView control.
                Point cp = listViewFiles.PointToClient(new Point(e.X, e.Y));
                //Obtain the item that is located at the specified location of the mouse pointer.
                ListViewItem dragToItem = listViewFiles.GetItemAt(cp.X, cp.Y);
                if (dragToItem == null)
                {
                    return;
                }
                //Obtain the index of the item at the mouse pointer.
                int dragIndex = dragToItem.Index;
                ListViewItem[] sel = new ListViewItem[listViewFiles.SelectedItems.Count];
                for (int i = 0; i <= listViewFiles.SelectedItems.Count - 1; i++)
                {
                    sel[i] = listViewFiles.SelectedItems[i];
                }
                for (int i = 0; i < sel.GetLength(0); i++)
                {
                    //Obtain the ListViewItem to be dragged to the target location.
                    ListViewItem dragItem = sel[i];
                    int itemIndex = dragIndex;
                    if (itemIndex == dragItem.Index)
                    {
                        return;
                    }
                    if (dragItem.Index < itemIndex)
                        itemIndex++;
                    else
                        itemIndex = dragIndex + i;

                    //Reorder MPlaylist accordingly
                    m_pPlaylist.PlaylistReorder(dragItem.Index, dragIndex - dragItem.Index);

                    //Insert the item at the mouse pointer.
                    ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                    listViewFiles.Items.Insert(itemIndex, insertItem);
                    //Removes the item from the initial location while 
                    //the item is moved to the new location.
                    listViewFiles.Items.Remove(dragItem);
                    //Update list
                    UpdateList(true);
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //Get dropped filenames
                string[] arrStrFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                MItem pFile = null;
                Cursor prev = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < arrStrFiles.Length; i++)
                {
                    int nIndex = -1;
                    m_pPlaylist.PlaylistAdd(null, arrStrFiles[i], "", ref nIndex, out pFile);
                }
                this.Cursor = prev;
                UpdateList(true);

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(arrStrFiles.Length > 1 ? null : pFile, e);
            }
        }

        private void buttonAddURL_Click(object sender, EventArgs e)
        {
            FormAddURL add = new FormAddURL();
            DialogResult result = add.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    MItem pFile;
                    int nIndex = -1;
                    m_pPlaylist.PlaylistAdd(null, add.url, "", ref nIndex, out pFile);
                    UpdateList(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Bad stream", "Add URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

    }
}
