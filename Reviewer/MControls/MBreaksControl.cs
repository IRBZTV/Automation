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
    public partial class MBreaksControl : UserControl
    {
        public IMBreaks m_pBreaks;

        public MBreaksControl()
        {
            InitializeComponent();

            // Set numeruic boxes for time
//             NumericUpDown pNumTime = new NumericUpDown();
//             pNumTime.Minimum = -10000;
//             pNumTime.Maximum = 10000;
//             pNumTime.DecimalPlaces = 3;
            listViewFiles.Columns[0].Tag = new TextBox();

            // For edit command
            listViewFiles.Columns[1].Tag = new TextBox();

            // Set Edit boxes for In/Out
//             NumericUpDown pNumInOut = new NumericUpDown();
//             pNumInOut.Minimum = 0;
//             pNumInOut.Maximum = 10000;
//             pNumInOut.DecimalPlaces = 3;
            listViewFiles.Columns[2].Tag = new TextBox();
            listViewFiles.Columns[3].Tag = new TextBox();
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
                MItem pItem = (MItem)listViewFiles.Items[i].Tag;
                // Not necessary, but for not keep reference in memory
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
            }

            listViewFiles.Items.Clear();
        }

        public void UpdateList(bool _bKeepSelection)
        {
            try
            {
                IMFile pSelFile = null;
                if (listViewFiles.SelectedItems.Count > 0)
                    pSelFile = (IMFile)listViewFiles.SelectedItems[0].Tag;

                //listViewFiles.Items.Clear();
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
                    MItem pFileObj;
                    m_pBreaks.BreaksGetByIndex(i, out dblTime, out strPathOrCommand, out pFileObj);

                    if (pFileObj != null)
                    {
                        // Get type
                        eMItemType eItemType;
                        pFileObj.ItemTypeGet(out eItemType);
                        int nImage = eItemType == eMItemType.eMPIT_Playlist ? 2 :
                            eItemType == eMItemType.eMPIT_Live ? 1 :
                            eItemType == eMItemType.eMPIT_Command ? 3 : 0;

                        if (eItemType != eMItemType.eMPIT_Command)
                        {
                            string strFile = strPathOrCommand.Substring(strPathOrCommand.LastIndexOf('\\') + 1);

                            int nIdxFake;
                            M_VID_PROPS vidProps;
                            M_AUD_PROPS audProps;
                            string strFormat;
                            ((IMFormat)pFileObj).FormatVideoGet(eMFormatType.eMFT_Input, out vidProps, out nIdxFake, out strFormat);
                            ((IMFormat)pFileObj).FormatAudioGet(eMFormatType.eMFT_Input, out audProps, out nIdxFake, out strFormat);

                            double dblIn = 0;
                            double dblOut = 0;
                            double dblFileDuration = 0;
                            pFileObj.FileInOutGet(out dblIn, out dblOut, out dblFileDuration);



                            eMState eState;
                            double dblTimeState;
                            pFileObj.FileStateGet(out eState, out dblTimeState);

                            ListViewItem lvItem = listViewFiles.Items.Add( MHelpers.PosToString(dblTime), nImage);
                            lvItem.SubItems.Add(strFile);

                            lvItem.SubItems.Add(MHelpers.PosToString(dblIn));
                            lvItem.SubItems.Add(MHelpers.PosToString(dblOut));
                            lvItem.SubItems.Add(MHelpers.PosToString(dblFileDuration));

//                             lvItem.SubItems.Add(dblIn.ToString("0.000"));
//                             lvItem.SubItems.Add(dblOut.ToString("0.000"));
//                             lvItem.SubItems.Add(dblFileDuration.ToString("0.000"));
                            lvItem.SubItems.Add(MHelpers.ToString(vidProps) + " " + MHelpers.ToString(audProps));
                            lvItem.SubItems.Add(strPathOrCommand);
                            lvItem.Tag = pFileObj;
                        }
                        else
                        {
                            string strParam;
                            Object pTarget;
                            pFileObj.ItemCommandGet(out strPathOrCommand, out strParam, out pTarget );
                            ListViewItem lvItem = listViewFiles.Items.Add(MHelpers.PosToString(dblTime), nImage);
                            lvItem.SubItems.Add(strPathOrCommand);
                            lvItem.SubItems.Add(strParam);
                            lvItem.Tag = pFileObj;
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
                this.OnBreaksChanged(listViewFiles, EventArgs.Empty );

            UpdateList(true);
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
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                AddFile(fileDialog.FileName, "");
            }
        }
        private void buttonAddList_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                AddFile(fileDialog.FileName, "playlist");
            }
        }

        private void buttonAddCommand_Click(object sender, EventArgs e)
        {
            listViewFiles.Items.Add("0.000", 3).SubItems.Add("<New Command>");
            listViewFiles.BeginEdit(listViewFiles.Items.Count - 1, 1);

            //UpdateList(true);
        }

        private void buttonAddLive_Click(object sender, EventArgs e)
        {
            // TODO: Unique name

            IMFile pFileFake = new MFile();
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
                    this.OnBreaksChanged(listViewFiles, e);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                m_pBreaks.BreaksRemoveByIndex(listViewFiles.SelectedIndices[0], 0);

                UpdateList(true);

                // Notify about breaks changing
                if (this.OnBreaksChanged != null)
                    this.OnBreaksChanged(listViewFiles, e);
            }
        }


        private void listViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                if (listViewFiles.SelectedItems[0].SubItems[1].Bounds.Contains(e.Location))
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
                    else if (listViewFiles.SelectedItems[0].ImageIndex == 3)
                    {
                        try
                        {
                            IMItem pPlaylistItem = (IMItem)listViewFiles.SelectedItems[0].Tag;

                            // TODO: Make non-modal
                            FormCommand formCommand = new FormCommand();
                            formCommand.m_pPlaylistItem = pPlaylistItem;
                            formCommand.ShowDialog(this);
                        }
                        catch (System.Exception) { }
                    }
                }
                //

                UpdateList(true);

                // Notify about breaks changing
                if (this.OnBreaksChanged != null)
                    this.OnBreaksChanged(listViewFiles, e);
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

            if (lvArg.nSubItem == 2 || lvArg.nSubItem == 3)
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
                        pItem.ItemCommandSet(lvItem.SubItems[1].Text, lvItem.SubItems[2].Text, null );
                    }
                    else
                    {
                        // Get new In/Out
                        double dblIn = MHelpers.ParsePos(lvItem.SubItems[2].Text);
                        double dblOut = MHelpers.ParsePos(lvItem.SubItems[3].Text);

                        // Set new in-out
                        pItem.FileInOutSet(dblIn, dblOut);
                    }
                   
                    UpdateList(true);

                    // Notify about breaks changing
                    if (this.OnBreaksChanged != null)
                        this.OnBreaksChanged(listViewFiles, e);
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
                        this.OnBreaksChanged(listViewFiles, e);
                }
                catch (System.Exception) { }
            }
            else if (lvArg.nSubItem == 1)
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
                        pItem.ItemCommandSet(lvArg.lvItem.SubItems[1].Text, lvArg.lvItem.SubItems[2].Text, null);
                    }

                    UpdateList(true);

                    // Notify about breaks changing
                    if (this.OnBreaksChanged != null)
                        this.OnBreaksChanged(listViewFiles, e);
                }
                catch (System.Exception) { }
            }
        }

        private void listViewFiles_ListSubItemOnStartChange(object sender, EventArgs e)
        {
            ListViewEx_EventArgs lvArg = (ListViewEx_EventArgs)e;
            if (lvArg.nSubItem == 1) // Only command can be edited
            {
                if (lvArg.lvItem.Tag != null) // If null -> the New command, can be edit
                {
                    // Check for command
                    MItem pItem = (MItem)lvArg.lvItem.Tag;
                    eMItemType eItemType;
                    pItem.ItemTypeGet(out eItemType);
                    if (eItemType != eMItemType.eMPIT_Command)
                    {
                        lvArg.Cancel = true;
                    }
                }
            }
        }

        
    }
}
