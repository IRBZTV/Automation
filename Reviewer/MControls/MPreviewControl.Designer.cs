namespace MControls
{
    partial class MPreviewControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.checkBoxAudio = new System.Windows.Forms.CheckBox();
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.checkBoxAR = new System.Windows.Forms.CheckBox();
            this.checkBoxFullScreen = new System.Windows.Forms.CheckBox();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(113, 358);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(145, 26);
            this.trackBarVolume.TabIndex = 60;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            this.trackBarVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarVolume_MouseDown);
            // 
            // checkBoxAudio
            // 
            this.checkBoxAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAudio.AutoSize = true;
            this.checkBoxAudio.Location = new System.Drawing.Point(59, 363);
            this.checkBoxAudio.Name = "checkBoxAudio";
            this.checkBoxAudio.Size = new System.Drawing.Size(53, 17);
            this.checkBoxAudio.TabIndex = 59;
            this.checkBoxAudio.Text = "Audio";
            this.checkBoxAudio.UseVisualStyleBackColor = true;
            this.checkBoxAudio.CheckedChanged += new System.EventHandler(this.checkBoxAudio_CheckedChanged);
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.Checked = true;
            this.checkBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVideo.Location = new System.Drawing.Point(3, 363);
            this.checkBoxVideo.Name = "checkBoxVideo";
            this.checkBoxVideo.Size = new System.Drawing.Size(53, 17);
            this.checkBoxVideo.TabIndex = 58;
            this.checkBoxVideo.Text = "Video";
            this.checkBoxVideo.UseVisualStyleBackColor = true;
            this.checkBoxVideo.CheckedChanged += new System.EventHandler(this.checkBoxVideo_CheckedChanged);
            // 
            // checkBoxAR
            // 
            this.checkBoxAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAR.AutoSize = true;
            this.checkBoxAR.Location = new System.Drawing.Point(259, 363);
            this.checkBoxAR.Name = "checkBoxAR";
            this.checkBoxAR.Size = new System.Drawing.Size(41, 17);
            this.checkBoxAR.TabIndex = 61;
            this.checkBoxAR.Text = "AR";
            this.checkBoxAR.UseVisualStyleBackColor = true;
            this.checkBoxAR.CheckedChanged += new System.EventHandler(this.checkBoxAR_CheckedChanged);
            // 
            // checkBoxFullScreen
            // 
            this.checkBoxFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxFullScreen.AutoSize = true;
            this.checkBoxFullScreen.Location = new System.Drawing.Point(306, 363);
            this.checkBoxFullScreen.Name = "checkBoxFullScreen";
            this.checkBoxFullScreen.Size = new System.Drawing.Size(79, 17);
            this.checkBoxFullScreen.TabIndex = 63;
            this.checkBoxFullScreen.Text = "Full Screen";
            this.checkBoxFullScreen.UseVisualStyleBackColor = true;
            this.checkBoxFullScreen.CheckedChanged += new System.EventHandler(this.checkBoxFullScreen_CheckedChanged);
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Location = new System.Drawing.Point(0, 0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(492, 354);
            this.panelPreview.TabIndex = 64;
            this.panelPreview.MouseLeave += new System.EventHandler(this.panelPreview_MouseLeave);
            this.panelPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseMove);
            this.panelPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseDown);
            this.panelPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseUp);
            this.panelPreview.SizeChanged += new System.EventHandler(this.panelPreview_SizeChanged);
            // 
            // checkBoxDeinterlace
            // 
            this.checkBoxDeinterlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDeinterlace.AutoSize = true;
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(389, 363);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(80, 17);
            this.checkBoxDeinterlace.TabIndex = 65;
            this.checkBoxDeinterlace.Text = "Deinterlace";
            this.checkBoxDeinterlace.UseVisualStyleBackColor = true;
            this.checkBoxDeinterlace.CheckedChanged += new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
            // 
            // MPreviewControl
            // 
            this.Controls.Add(this.checkBoxDeinterlace);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.checkBoxAudio);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.checkBoxFullScreen);
            this.Controls.Add(this.checkBoxAR);
            this.Controls.Add(this.checkBoxVideo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MPreviewControl";
            this.Size = new System.Drawing.Size(493, 386);
            this.Resize += new System.EventHandler(this.MPreviewControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.CheckBox checkBoxAudio;
        private System.Windows.Forms.CheckBox checkBoxVideo;
        public System.Windows.Forms.Panel panelPreview;
        protected System.Windows.Forms.CheckBox checkBoxAR;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        protected System.Windows.Forms.CheckBox checkBoxFullScreen;
    }
}
