namespace MControls
{
    partial class MFormatControl
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
            this.comboBoxAudio = new System.Windows.Forms.ComboBox();
            this.comboBoxVideo = new System.Windows.Forms.ComboBox();
            this.labelAudio = new System.Windows.Forms.Label();
            this.labelVideo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAudio
            // 
            this.comboBoxAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudio.FormattingEnabled = true;
            this.comboBoxAudio.Location = new System.Drawing.Point(40, 23);
            this.comboBoxAudio.Name = "comboBoxAudio";
            this.comboBoxAudio.Size = new System.Drawing.Size(266, 21);
            this.comboBoxAudio.TabIndex = 7;
            this.comboBoxAudio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudio_SelectedIndexChanged);
            // 
            // comboBoxVideo
            // 
            this.comboBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxVideo.FormattingEnabled = true;
            this.comboBoxVideo.Location = new System.Drawing.Point(40, 0);
            this.comboBoxVideo.Name = "comboBoxVideo";
            this.comboBoxVideo.Size = new System.Drawing.Size(266, 21);
            this.comboBoxVideo.TabIndex = 6;
            this.comboBoxVideo.SelectedIndexChanged += new System.EventHandler(this.comboBoxVideo_SelectedIndexChanged);
            // 
            // labelAudio
            // 
            this.labelAudio.Location = new System.Drawing.Point(3, 25);
            this.labelAudio.Name = "labelAudio";
            this.labelAudio.Size = new System.Drawing.Size(42, 13);
            this.labelAudio.TabIndex = 5;
            this.labelAudio.Text = "Audio:";
            // 
            // labelVideo
            // 
            this.labelVideo.Location = new System.Drawing.Point(3, 3);
            this.labelVideo.Name = "labelVideo";
            this.labelVideo.Size = new System.Drawing.Size(42, 13);
            this.labelVideo.TabIndex = 4;
            this.labelVideo.Text = "Video:";
            // 
            // MFormatControl
            // 
            this.Controls.Add(this.comboBoxAudio);
            this.Controls.Add(this.comboBoxVideo);
            this.Controls.Add(this.labelAudio);
            this.Controls.Add(this.labelVideo);
            this.Name = "MFormatControl";
            this.Size = new System.Drawing.Size(307, 44);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBoxAudio;
        public System.Windows.Forms.ComboBox comboBoxVideo;
        private System.Windows.Forms.Label labelAudio;
        private System.Windows.Forms.Label labelVideo;
    }
}
