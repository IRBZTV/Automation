using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MControls
{
    public partial class FormPlaylist : Form
    {
        public IMPlaylist   m_pPlaylist;
        public FormPlaylist()
        {
            InitializeComponent();
        }

        private void FormPlaylist_Load(object sender, EventArgs e)
        {
            mPlaylistControl1.SetControlledObject(m_pPlaylist);
            // Disable add command & add list for sub-playlists
            mPlaylistControl1.buttonAddCommand.Enabled = false;
            mPlaylistControl1.buttonAddList.Enabled = false;
        }

        private void FormPlaylist_FormClosing(object sender, FormClosingEventArgs e)
        {
            mPlaylistControl1.SetControlledObject(null);
        }
    }
}