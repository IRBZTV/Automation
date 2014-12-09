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
    public partial class MMixerList : UserControl
    {
        IMMixer m_pMixer;

        public MMixerList()
        {
            InitializeComponent();

            // Set edit boxes for In/Out
            listViewFiles.Columns[2].Tag = new TextBox(); //pNumInOut;
            listViewFiles.Columns[3].Tag = new TextBox(); //pNumInOut;
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMixer;
            try
            {
                m_pMixer = (IMMixer)pObject;

                UpdateList(false);
               
            }
            catch (System.Exception) { }

            return pOld;
        }

        // Called if user change playlist selection
        public event EventHandler OnMixerSelChanged;

        // Called if mixer confog changed (added or removed files, lives etc.)
        public event EventHandler OnMixerChanged;

        public MItem SelectedItem
        {
            get
            {
                if (listViewFiles.SelectedItems.Count > 0)
                    return (MItem)listViewFiles.SelectedItems[0].Tag;

                return null;
            }
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
                m_pMixer.MixerGetCount(out nFiles);
                for (int i = 0; i < nFiles; i++)
                {
                    MItem pItem;
                    string strStreamID;
                    m_pMixer.MixerGetByIndex(i, out strStreamID, out pItem);


                    string strPath;
                    pItem.FileNameGet(out strPath);

                    // Get type
                    eMItemType eItemType;
                    pItem.ItemTypeGet(out eItemType);
                    int nImage = eItemType == eMItemType.eMPIT_Playlist ? 2 :
                        eItemType == eMItemType.eMPIT_Live ? 1 : 0;

                    M_DATETIME mTimeStart;
                    M_DATETIME mTimeStop;
                    eMStartType eStartType;
                    pItem.ItemTimesGet(out mTimeStart, out mTimeStop, out eStartType);

                    if (eItemType != eMItemType.eMPIT_Command)
                    {
                        string strFile = strPath.Substring(strPath.LastIndexOf('\\') + 1);

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

                        ListViewItem lvItem = listViewFiles.Items.Add(strStreamID, nImage);
                        lvItem.SubItems.Add(strFile);
                        lvItem.SubItems.Add(MHelpers.PosToString(dblIn));
                        lvItem.SubItems.Add(MHelpers.PosToString(dblOut));
                        lvItem.SubItems.Add(MHelpers.PosToString(dblFileDuration));
                        lvItem.SubItems.Add(eState.ToString());
                        lvItem.SubItems.Add(MHelpers.ToString(vidProps) + " " + MHelpers.ToString(audProps));
                        lvItem.SubItems.Add(strPath);
                        lvItem.Tag = pItem;
                    }
                    

                    listViewFiles.Columns[0].Width = -2;
                    //listViewFiles.Columns[1].Width = -2;
                    listViewFiles.Columns[2].Width = -2;
                    listViewFiles.Columns[3].Width = -2;
                    listViewFiles.Columns[4].Width = -2;
                    listViewFiles.Columns[5].Width = -2;
                    listViewFiles.Columns[6].Width = -2;
                }

                if (pSelFile != null)
                    SelectFile(pSelFile);
            }
            catch (System.Exception) { }
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
                    m_pMixer.MixerAdd("", null, fileDialog.FileNames[i], "", out pFile, 0);
                }
                this.Cursor = prev;
                UpdateList(true);

                // Notify about mixer changing
                if (this.OnMixerChanged != null)
                    this.OnMixerChanged(fileDialog.FileNames.Length > 1 ? null : pFile, e);

                SelectFile(pFile);
            }
        }

        private void buttonAddList_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.FileNames.Length > 0)
            {
                Cursor prev = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                // Add file (as playlist)
                int nIndex = -1;
                MItem pPlaylist;
                m_pMixer.MixerAdd("", null, fileDialog.FileNames[0], "playlist", out pPlaylist, 0);

                // Add other files to this playlist
                for (int i = 1; i < fileDialog.FileNames.Length; i++)
                {
                    nIndex = -1;
                    MItem pFile;
                    ((IMPlaylist)pPlaylist).PlaylistAdd(null, fileDialog.FileNames[i], "", ref nIndex, out pFile);
                }

                this.Cursor = prev;
                UpdateList(true);

                // Notify about playlist changing
                if (this.OnMixerChanged != null)
                    this.OnMixerChanged(pPlaylist, e);

                SelectFile(pPlaylist);
            }
        }

        private void buttonAddLive_Click(object sender, EventArgs e)
        {
            int nIndex = -1;
            MItem pLive;

            m_pMixer.MixerAdd("", null, "my_live", "live", out pLive, 0);
            UpdateList(true);

            // Notify about playlist changing
            if (this.OnMixerChanged != null)
                this.OnMixerChanged(pLive, e);

            // Show live config


            SelectFile(pLive);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                MItem pItem = (MItem)listViewFiles.SelectedItems[0].Tag;

                m_pMixer.MixerRemove(pItem, 0);

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
                if (this.OnMixerChanged != null)
                    this.OnMixerChanged(null, e);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                try
                {
                    m_pMixer.MixerReorder(listViewFiles.SelectedIndices[0], -1, 0);
                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnMixerChanged != null)
                        this.OnMixerChanged(null, e);
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
                    m_pMixer.MixerReorder(listViewFiles.SelectedIndices[0], 1, 0);
                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnMixerChanged != null)
                        this.OnMixerChanged(null, e);
                }
                catch (System.Exception) { }
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemove.Enabled = listViewFiles.SelectedItems.Count > 0;

            // For handler
            if (this.OnMixerSelChanged != null)
                this.OnMixerSelChanged(listViewFiles, e);
        }

        private void listViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                Rectangle rcItem;
                int nCol = listViewFiles.GetClickedColumn(e.Location, out rcItem);
                if (nCol == 1)
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
                }
                else
                {
                    // Show stream config
                }

                UpdateList(true);
            }
        }

        // For edit in/out

        private void listViewFiles_ListSubItemChanged(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;

            if (lvArg.nSubItem == 2 || lvArg.nSubItem == 3)
            {
                try
                {
                    ListViewItem lvItem = lvArg.lvItem;
                    MItem pItem = (MItem)lvItem.Tag;

                    // Get new In/Out
                    double dblIn = MHelpers.ParsePos(lvItem.SubItems[2].Text);
                    double dblOut = MHelpers.ParsePos(lvItem.SubItems[3].Text);

                    // Set new in-out
                    pItem.FileInOutSet(dblIn, dblOut);
                    

                    UpdateList(true);

                    // Notify about playlist changing
                    if (this.OnMixerChanged != null)
                        this.OnMixerChanged(pItem, e);
                }
                catch (System.Exception) { }
            }
            
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            int k = 0;
        }

       
    }
}
