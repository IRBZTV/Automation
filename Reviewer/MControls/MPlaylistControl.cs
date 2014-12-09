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
    public partial class MPlaylistControl : UserControl
    {
        IMPlaylist m_pPlaylist;

        public MPlaylistControl()
        {
            InitializeComponent();

            // Set numeric boxes for In/Out
            NumericUpDown pNumInOut = new NumericUpDown();
            pNumInOut.Maximum = 10000;
            pNumInOut.DecimalPlaces = 3;
            listViewFiles.Columns[4].Tag = new TextBox(); //pNumInOut;
            listViewFiles.Columns[5].Tag = new TextBox(); //pNumInOut;

            // Set text box for Time
            TextBox pTime = new TextBox();
            listViewFiles.Columns[1].Tag = pTime;
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

        // Called if playlist changed (files,added, removed, reaaranged, etc.)
        public event EventHandler OnPlaylistChanged;

        void MPlaylistControl_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            UpdateListState();
        }

        public void AddFile(string strPath, string sProps)
        {
            int nIndex = -1;
            MItem pFile;
            m_pPlaylist.PlaylistAdd(null, strPath, sProps, ref nIndex, out pFile);
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
                MItem pItem = (MItem)listViewFiles.Items[i].Tag;
                // Not necessary, but for not keep reference in memory
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
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
                    string strPath;
                    MItem pFileObj;
                    m_pPlaylist.PlaylistGetByIndex(i, out dblPos, out strPath, out pFileObj);

                    string strFile = strPath.Substring(strPath.LastIndexOf('\\') + 1);

                    int nIdxFake;
                    M_VID_PROPS vidProps;
                    M_AUD_PROPS audProps;
                    string strFormat;
                    ((IMFormat)pFileObj).FormatVideoGet(eMFormatType.eMFT_Input, out vidProps, out nIdxFake, out strFormat);
                    ((IMFormat)pFileObj).FormatAudioGet(eMFormatType.eMFT_Input, out audProps, out nIdxFake, out strFormat);

                    double dblIn = 0, dblOut = 0, dblFileDuration = 0;
                    pFileObj.FileInOutGet(out dblIn, out dblOut, out dblFileDuration);

                    // Check type
                    eMItemType eItemType;
                    pFileObj.ItemTypeGet(out eItemType);
                    int nImage = eItemType == eMItemType.eMPIT_Playlist ? 2 : 
                        eItemType == eMItemType.eMPIT_Live ? 1 : 
                        eItemType == eMItemType.eMPIT_Command ? 3 : 0;
                    
                    eMState eState;
                    double dblTime = 0;
                    pFileObj.FileStateGet(out eState, out dblTime);

                    M_DATETIME mTimeStart;
                    M_DATETIME mTimeStop;
                    eMStartType eStartType;
                    pFileObj.ItemTimesGet(out mTimeStart, out mTimeStop, out eStartType);

                    ListViewItem lvItem = listViewFiles.Items.Add(MHelpers.PosToString(dblPos, 0), nImage);
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
                    lvItem.SubItems.Add(strFile);
                    lvItem.SubItems.Add(eState.ToString());
//                     lvItem.SubItems.Add(dblIn.ToString("0.000"));
//                     lvItem.SubItems.Add(dblOut.ToString("0.000"));

                    lvItem.SubItems.Add(MHelpers.PosToString(dblIn));
                    lvItem.SubItems.Add(MHelpers.PosToString(dblOut));
                    lvItem.SubItems.Add(MHelpers.PosToString(dblFileDuration));

                    lvItem.SubItems.Add(MHelpers.ToString(vidProps) + " " + MHelpers.ToString(audProps));
                    lvItem.SubItems.Add(strPath);
                    lvItem.Tag = pFileObj;

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
            catch (System.Exception) { }
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
                        IMFile pFileObj = (IMFile)listViewFiles.Items[i].Tag;

                        eMState eState;
                        double dblTime;
                        pFileObj.FileStateGet(out eState, out dblTime );

                        listViewFiles.Items[i].SubItems[3].Text = eState.ToString();

                        if (pCurrent == pFileObj)
                            listViewFiles.SetRowBGColor(i, Color.LightSkyBlue);// Color.FromArgb(150, 200, 255);
                        else if (pNext == pFileObj)
                            listViewFiles.SetRowBGColor(i, Color.FromArgb(222, 232, 254));
                        else
                            listViewFiles.SetRowBGColor(i, Color.White);
                    }
                    catch (System.Exception ex)
                    {
                        listViewFiles.Items[i].SubItems[3].Text = ex.ToString();
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
                Cursor prev = this.Cursor;
                this.Cursor = Cursors.WaitCursor;
                for (int i = 0; i < fileDialog.FileNames.Length; i++)
                {
                    AddFile(fileDialog.FileNames[i], "");
                }
                this.Cursor = prev;
                UpdateList(true);

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(listViewFiles, e);
            }
        }

        private void buttonAddList_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor prev = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                if (fileDialog.FileNames.Length > 0 )
                {
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
                    }
                }

                this.Cursor = prev;
                UpdateList(true);

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(listViewFiles, e);
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
                this.OnPlaylistChanged(listViewFiles, e);
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
                    this.OnPlaylistChanged(listViewFiles, e);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                MItem pItem = (MItem)listViewFiles.SelectedItems[0].Tag;

                m_pPlaylist.PlaylistRemove(pItem);

                // Not necessary, but for not keep reference in memory
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);

                int nNewSelIndex = listViewFiles.Items.Count > listViewFiles.SelectedIndices[0] + 1 ? 
                    listViewFiles.SelectedIndices[0] : listViewFiles.SelectedIndices[0] > 0 ? listViewFiles.SelectedIndices[0] - 1 : 0;

                UpdateList(false);
                if (nNewSelIndex >= 0 && listViewFiles.Items.Count > 0 )
                {
                    SelectFile((IMFile)listViewFiles.Items[nNewSelIndex].Tag);
                }

                // Notify about playlist changing
                if (this.OnPlaylistChanged != null)
                    this.OnPlaylistChanged(listViewFiles, e);
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
                        this.OnPlaylistChanged(listViewFiles, e);
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
                        this.OnPlaylistChanged(listViewFiles, e);
                }
                catch (System.Exception) { }
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddRef.Enabled = listViewFiles.SelectedItems.Count > 0;
            buttonRemove.Enabled = listViewFiles.SelectedItems.Count > 0;

            // For handler
            if (this.OnPlaylistSelChanged != null)
                this.OnPlaylistSelChanged(listViewFiles, e);
        }

        private void listViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {

                Rectangle rcItem;
                int nCol = listViewFiles.GetClickedColumn(e.Location, out rcItem );
                if (nCol == 2)
                {
                    // Check for Live
                    if (listViewFiles.SelectedItems[0].ImageIndex == 0)
                    {
                        // File
                        FormFileName formFile = new FormFileName();
                        formFile.m_pFile = (IMFile)listViewFiles.SelectedItems[0].Tag;
                        formFile.ShowDialog(this);
                    }
                    else if (listViewFiles.SelectedItems[0].ImageIndex == 1)
                    {
                        try
                        {
                            IMDevice pDevice = (IMDevice)listViewFiles.SelectedItems[0].Tag;

                            // TODO: Make non-modal
                            FormLive formLive = new FormLive();
                            formLive.m_pDevice = pDevice;
                            formLive.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                    else if (listViewFiles.SelectedItems[0].ImageIndex == 2)
                    {
                        try
                        {
                            IMPlaylist pPlaylist = (IMPlaylist)listViewFiles.SelectedItems[0].Tag;

                            // TODO: Make non-modal
                            FormPlaylist formPlaylist = new FormPlaylist();
                            formPlaylist.m_pPlaylist = pPlaylist;
                            formPlaylist.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                }
                else
                {
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

            if (lvArg.nSubItem == 4 || lvArg.nSubItem == 5)
            {
                try
                {
                    // Get new In/Out
                    ListViewItem lvItem = lvArg.lvItem;
                    double dblIn = MHelpers.ParsePos(lvItem.SubItems[4].Text);
                    double dblOut = MHelpers.ParsePos(lvItem.SubItems[5].Text);

                    // Set new in-out
                    IMFile pFile = (IMFile)lvItem.Tag;
                    pFile.FileInOutSet(dblIn, dblOut);

                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(listViewFiles, e);
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
                    if (strTime == "")
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
                        mTime = MHelpers.ParseTime(strTime);
                        pFile.ItemStartTimeSet(ref mTime, eMStartType.eMST_Specified);
                    }
                        

                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnPlaylistChanged != null)
                        this.OnPlaylistChanged(listViewFiles, e);
                }
                catch (System.Exception) { }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "MPlaylist Files (*.mpl, *.xml)|*.mpl;*.xml;*.mlp";
            fileDialog.DefaultExt = ".xml";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ((IMPersist)m_pPlaylist).PersistSaveToFile("", fileDialog.FileName, "");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "MPlaylist Files (*.mpl, *.xml)|*.mpl;*.xml;*.mlp";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ((IMPersist)m_pPlaylist).PersistLoad("", fileDialog.FileName, "");

                UpdateList(false);
            }
        }

        

    }
}
