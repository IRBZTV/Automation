using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileIngest
{
    public partial class VideoPlayer : Form
    {
        string _VideoFile = "";

        public VideoPlayer(string VideoFile)
        {
            InitializeComponent();
            _VideoFile = VideoFile;
        }

        private void VideoPlayer_Load(object sender, EventArgs e)
        {
            axVLCPlugin21.playlist.items.clear();
            axVLCPlugin21.playlist.add("file:///" + _VideoFile, "dfccdcdcd", null);
            axVLCPlugin21.playlist.playItem(0);
            groupControl1.Text = _VideoFile;
        }
    }
}
