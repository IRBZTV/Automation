using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class MBreaksList : UserControl
    {
        public IMBreaks m_pBreaks;

        public MBreaksList()
        {
            InitializeComponent();

            // Set numeruic boxes for time
//             NumericUpDown pNumTime = new NumericUpDown();
//             pNumTime.Minimum = -10000;
//             pNumTime.Maximum = 10000;
//             pNumTime.DecimalPlaces = 3;
            listViewFiles.Columns[0].Tag = new TextBox();

            // For edit command
            listViewFiles.Columns[2].Tag = new TextBox();

            // Set Edit boxes for In/Out
//             NumericUpDown pNumInOut = new NumericUpDown();
//             pNumInOut.Minimum = 0;
//             pNumInOut.Maximum = 10000;
//             pNumInOut.DecimalPlaces = 3;
            listViewFiles.Columns[3].Tag = new TextBox();
            listViewFiles.Columns[4].Tag = new TextBox();
        }

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pBreaks;
            try
            {
                m_pBreaks = (IMBreaks)pObject;

                UpdateList(false);
            }
            catch (System.Exception) { }

            return pOld;
        }

        // Called if user change breaks list selection
        public event EventHandler OnBreaksSelChanged;

        // Called if breaks changed (files,added, removed, rearanged, etc.)
        public event EventHandler OnBreaksChanged;

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
                
                if (m_pBreaks == null)
                    return;

                int nFiles = 0;
                double dblDuration = 0;
                m_pBreaks.BreaksGetCount(out nFiles, out dblDuration);
                for (int i = 0; i < nFiles; i++)
                {
                    double dblTime = 0;
                    string strPathOrCommand;
                    MItem pItem;
                    m_pBreaks.BreaksGetByIndex(i, out dblTime, out strPathOrCommand, out pItem);

                    if (pItem != null)
                    {
                        // Get type
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

                            double dblIn = 0;
                            double dblOut = 0;
                            double dblFileDuration = 0;
                            pItem.FileInOutGet(out dblIn, out dblOut, out dblFileDuration);

                            eMState eState;
                            double dblTimeState;
                            pItem.FileStateGet(out eState, out dblTimeState);

                            ListViewItem lvItem = listViewFiles.Items.Add( MHelpers.PosToString(dblTime), nImage);
                            lvItem.UseItemStyleForSubItems = false;
                            lvItem.SubItems.Add(MHelpers.ToString(mTimeStart)).ForeColor = Color.DarkGray;
                            lvItem.SubItems.Add(strFile);
                            lvItem.SubItems.Add(MHelpers.PosToString(dblIn));
                            lvItem.SubItems.Add(MHelpers.PosToString(dblOut));
                            lvItem.SubItems.Add(MHelpers.PosToString(dblFileDuration));
                            lvItem.SubItems.Add(MHelpers.ToString(vidProps) + " " + MHelpers.ToString(audProps));
                            lvItem.SubItems.Add(strPathOrCommand);
                            lvItem.Tag = pItem;
                        }
                        else
                        {
                            string strParam;
                            Object pTarget;
                            pItem.ItemCommandGet(out strPathOrCommand, out strParam, out pTarget );


                            ListViewItem lvItem = listViewFiles.Items.Add(MHelpers.PosToString(dblTime), nImage);
                            lvItem.UseItemStyleForSubItems = false;
                            lvItem.SubItems.Add(MHelpers.ToString(mTimeStart)).ForeColor = Color.DarkGray;
                            lvItem.SubItems.Add(strPathOrCommand);
                            lvItem.SubItems.Add(strParam);
                            lvItem.Tag = pItem;
                        }
                    }
                    else
                    {

                    }

                    
                    listViewFiles.Columns[0].Width = -2;
//                     listViewFiles.Columns[2].Width = -2;
//                     listViewFiles.Columns[3].Width = -2;
                    listViewFiles.Columns[4].Width = -2;
                    listViewFiles.Columns[5].Width = -2;
                    listViewFiles.Columns[6].Width = -2;

                }

                if (pSelFile != null)
                    SelectFile(pSelFile);
            }
            catch (System.Exception) { }
        }

        public void AddFile(string strPath, string sProps)
        {
            MItem pFile;
            m_pBreaks.BreaksAdd(0, null, strPath, sProps, out pFile);

            // Notify about breaks changing
            if (this.OnBreaksChanged != null)
                this.OnBreaksChanged(m_pBreaks, EventArgs.Empty );

            UpdateList(true);

            Marshal.ReleaseComObject(pFile);
            GC.Collect();
        }

        int ListIndex(ListViewItem pItem)
        {
            for (int i = 0; i < listViewFiles.Items.Count; i++)
            {
                if (pItem.Equals(listViewFiles.Items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // TODO: Extenstions
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                AddFile(fileDialog.FileName, "");
            }
        }
        private void buttonAddList_Click(object sender, EventArgs e)
        {
            // TODO: Extenstions
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.FileNames.Length > 0)
            {
                // Add file (as playlist)
                MItem pPlaylist;
                m_pBreaks.BreaksAdd(0, null, fileDialog.FileNames[0], "playlist", out pPlaylist);

                // Add other files to this playlist
                for (int i = 1; i < fileDialog.FileNames.Length; i++)
                {
                    MItem pFile;
                    int nIndex = -1;
                    ((IMPlaylist)pPlaylist).PlaylistAdd(null, fileDialog.FileNames[i], "", ref nIndex, out pFile);

                    Marshal.ReleaseComObject(pFile);
                    GC.Collect();
                }


                // Notify about breaks changing
                if (this.OnBreaksChanged != null)
                    this.OnBreaksChanged(m_pBreaks, EventArgs.Empty);

                UpdateList(true);

                Marshal.ReleaseComObject(pPlaylist);
                GC.Collect();
            }
        }

        private void buttonAddCommand_Click(object sender, EventArgs e)
        {
            ListViewItem lvItem = listViewFiles.Items.Add("0.000", 3);
            lvItem.SubItems.Add("");
            lvItem.SubItems.Add("<New Command>");
            lvItem.SubItems.Add(""); // For param, if not added -> can't edit
            listViewFiles.BeginEdit(listViewFiles.Items.Count - 1, 2);

            //UpdateList(true);
        }

        private void buttonAddLive_Click(object sender, EventArgs e)
        {
            // TODO: Unique name
            AddFile("my_live", "live");
            UpdateList(true);
        }

        private void buttonAddRef_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                IMFile pFile = (IMFile)listViewFiles.SelectedItems[0].Tag;

                string strPath, strProps, strInfo;
                pFile.FileNameGet(out strPath);

                // TODO: Unique name
                MItem pNew;
                m_pBreaks.BreaksAdd(0, pFile, strPath + ":ref", "", out pNew);

                UpdateList(true);

                // Notify about breaks changing
                if (this.OnBreaksChanged != null)
                    this.OnBreaksChanged(m_pBreaks, e);

                Marshal.ReleaseComObject(pNew);
                GC.Collect();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewFiles.SelectedIndices.Count > 0)
                {
                    if (listViewFiles.SelectedItems[0].Tag != null)
                    {
                        m_pBreaks.BreaksRemove((MItem)listViewFiles.SelectedItems[0].Tag);

                        UpdateList(true);

                        // Notify about breaks changing
                        if (this.OnBreaksChanged != null)
                            this.OnBreaksChanged(m_pBreaks, e);
                    }
                    else
                    {
                        listViewFiles.Items.Remove(listViewFiles.SelectedItems[0]);
                    }
                }
            }
            catch {}
        }


        private void listViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                if (listViewFiles.SelectedItems[0].Tag != null )
                {
                    MItem pItem = (MItem)listViewFiles.SelectedItems[0].Tag;

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
                            IMDevice pDevice = (IMDevice)pItem;

                            // TODO: Make non-modal
                            FormLive formLive = new FormLive();
                            formLive.m_pDevice = pDevice;
                            formLive.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                    else if (eType == eMItemType.eMPIT_Playlist)
                    {
                        try
                        {
                            IMPlaylist pPlaylist = (IMPlaylist)pItem;

                            // TODO: Make non-modal
                            FormPlaylist formPlaylist = new FormPlaylist();
                            formPlaylist.m_pPlaylist = pPlaylist;
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
                //

                UpdateList(true);

                // Notify about breaks changing
                if (this.OnBreaksChanged != null)
                    this.OnBreaksChanged(m_pBreaks, e);
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddRef.Enabled = listViewFiles.SelectedItems.Count > 0;
            buttonRemove.Enabled = listViewFiles.SelectedItems.Count > 0;

            // For handler
            if (this.OnBreaksSelChanged != null)
                this.OnBreaksSelChanged(listViewFiles, e);
        }

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
                        pItem.ItemCommandSet(lvItem.SubItems[2].Text, lvItem.SubItems[3].Text, null );
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

                    // Notify about breaks changing
                    if (this.OnBreaksChanged != null)
                        this.OnBreaksChanged(m_pBreaks, e);
                }
                catch (System.Exception) { }
            }
            else if (lvArg.nSubItem == 0)
            {
                try
                {
                    // Update Time
                    double dblTime = MHelpers.ParsePos(lvArg.lvSubItem.Text);

                    // Set new start time
                    m_pBreaks.BreaksTimeSet(lvArg.nItem, dblTime);

                    UpdateList(true);

                    // Notify about breaks changing
                    if (this.OnBreaksChanged != null)
                        this.OnBreaksChanged(m_pBreaks, e);
                }
                catch (System.Exception) { }
            }
            else if (lvArg.nSubItem == 2)
            {
                // New command
                try
                {
                    if (lvArg.lvItem.Tag == null)
                    {
                        // New command
                        MItem pNewItem;
                        m_pBreaks.BreaksCommandAdd(0, lvArg.lvSubItem.Text, "", null, out pNewItem);
                    }
                    else
                    {
                        // Update command
                        MItem pItem = (MItem)lvArg.lvItem.Tag;
                        pItem.ItemCommandSet(lvArg.lvItem.SubItems[2].Text, lvArg.lvItem.SubItems[3].Text, null);
                    }

                    UpdateList(true);

                    // Notify about breaks changing
                    if (this.OnBreaksChanged != null)
                        this.OnBreaksChanged(m_pBreaks, e);
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
                    lvArg.Cancel = true;
                    // Check for command
//                     MItem pItem = (MItem)lvArg.lvItem.Tag;
//                     eMItemType eItemType;
//                     pItem.ItemTypeGet(out eItemType);
//                     if (eItemType != eMItemType.eMPIT_Command)
//                     {
//                         lvArg.Cancel = true;
//                     }
                }
            }
        }

        
    }
}
