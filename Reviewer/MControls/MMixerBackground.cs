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
    public partial class MMixerBackground : UserControl
    {
        public MMixerBackground()
        {
            InitializeComponent();
        }

        IMMixer m_pMixer;

        public Object SetControlledObject(Object pObject)
        {
            Object pOld = (Object)m_pMixer;
            try
            {
                m_pMixer = (IMMixer)pObject;

                UpdateCombo();
            }
            catch (System.Exception) { }

            return pOld;
        }

        // Called if background changed
        public event EventHandler OnBackgroundChanged;

        public void UpdateCombo()
        {
            comboBoxBG.Items.Clear();
            comboBoxBG.Items.Add("<None>");
            comboBoxBG.Items.Add("colorbars-hd");
            comboBoxBG.Items.Add("colorbars-ntsc");
            comboBoxBG.Items.Add("colorbars-pal");
            comboBoxBG.Items.Add("colorbars-75");
            comboBoxBG.Items.Add("colorbars-100");
            comboBoxBG.Items.Add("blue");
            comboBoxBG.Items.Add("black");
            comboBoxBG.Items.Add("white");
            comboBoxBG.Items.Add("transparent");
            comboBoxBG.Items.Add("<Media File>");
            comboBoxBG.Items.Add("<Playlist>");
            comboBoxBG.Items.Add("<Live>");


            string strFile;
            MItem pBGItem;
            m_pMixer.MixerBackgroundGet(out strFile, out pBGItem);

            this.Focus(); // For remove focus from combo
            int nItem = comboBoxBG.FindStringExact(strFile);
            if (nItem >= 0)
            {
                // colorbars, color, etc.
                comboBoxBG.SelectedIndex = nItem;
            }
            else if (strFile == null || strFile == "" )
            {
                // <none>
                comboBoxBG.SelectedIndex = 0;
            }
            else
            {
                // Check item type
                eMItemType eType;
                pBGItem.ItemTypeGet(out eType);
                if (eType == eMItemType.eMPIT_File)
                {
                    comboBoxBG.SelectedIndex = comboBoxBG.Items.Count - 3;
                }
                else if (eType == eMItemType.eMPIT_Playlist)
                {
                    comboBoxBG.SelectedIndex = comboBoxBG.Items.Count - 3;
                }
                else if (eType == eMItemType.eMPIT_Live)
                {
                    comboBoxBG.SelectedIndex = comboBoxBG.Items.Count - 3;
                }
            }
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            string strFile;
            MItem pItem;
            m_pMixer.MixerBackgroundGet(out strFile, out pItem);

            if (pItem == null)
                return;

            eMItemType eType;
            pItem.ItemTypeGet(out eType);
            // Check for Live
            if (eType == eMItemType.eMPIT_File)
            {
                // File
                FormFileName formFile = new FormFileName();
                formFile.m_pFile = (IMFile)pItem;
                formFile.ShowDialog(this);
            }
            else if (eType == eMItemType.eMPIT_Live)
            {
                try
                {
                    // TODO: Make non-modal
                    FormLive formLive = new FormLive();
                    formLive.m_pDevice = (IMDevice)pItem;
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
                    formPlaylist.m_pPlaylist = (IMPlaylist)pItem;
                    formPlaylist.ShowDialog(this);
                }
                catch (System.Exception) { }
            }
        }

        private void comboBoxBG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBG.Focused)
            {
                MItem pNewItem;
                if (comboBoxBG.SelectedIndex == 0)
                {
                    m_pMixer.MixerBackgroundSet(null, "", "", out pNewItem, 0);
                    buttonConfig.Enabled = false;
                }
                else if (comboBoxBG.SelectedIndex < comboBoxBG.Items.Count - 3)
                {
                    m_pMixer.MixerBackgroundSet(null, comboBoxBG.Text, "", out pNewItem, 0);
                    buttonConfig.Enabled = true;
                }
                else if (comboBoxBG.SelectedIndex == comboBoxBG.Items.Count - 3)
                {
                    // File
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        m_pMixer.MixerBackgroundSet(null, fileDialog.FileName, "", out pNewItem, 0);

                        buttonConfig.Enabled = true;
                    }
                    else
                    {
                        UpdateCombo();
                    }
                }
                else if (comboBoxBG.SelectedIndex == comboBoxBG.Items.Count - 2)
                {
                    // Mixer
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.Multiselect = true;
                    if (fileDialog.ShowDialog() == DialogResult.OK && fileDialog.FileNames.Length > 0)
                    {
                        // Add file (as playlist)
                        MItem pPlaylist;
                        m_pMixer.MixerBackgroundSet(null, fileDialog.FileNames[0], "playlist", out pPlaylist, 0);

                        // Add other files to this playlist
                        for (int i = 1; i < fileDialog.FileNames.Length; i++)
                        {
                            MItem pFile;
                            int nIndex = -1;
                            ((IMPlaylist)pPlaylist).PlaylistAdd(null, fileDialog.FileNames[i], "", ref nIndex, out pFile);
                        }

                        buttonConfig.Enabled = true;
                    }
                    else
                    {
                        UpdateCombo();
                    }
                }
                else if (comboBoxBG.SelectedIndex == comboBoxBG.Items.Count - 1)
                {
                    // Add file (as playlist)
                    MItem pLive;
                    m_pMixer.MixerBackgroundSet(null, "my_live_bg", "live", out pLive, 0);

                    // TODO: Make non-modal
                    FormLive formLive = new FormLive();
                    formLive.m_pDevice = (IMDevice)pLive;
                    formLive.ShowDialog(this);

                    buttonConfig.Enabled = true;
                }

            }
        }


    }
}
