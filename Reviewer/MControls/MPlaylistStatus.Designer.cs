namespace MControls
{
    partial class MPlaylistStatus
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
            this.pictureBoxNext = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurrent = new System.Windows.Forms.PictureBox();
            this.labelNext = new MControls.LabelEx();
            this.labelCurrent = new MControls.LabelEx();
            this.labelPlaylist = new MControls.LabelEx();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxNext
            // 
            this.pictureBoxNext.BackColor = System.Drawing.Color.Black;
            this.pictureBoxNext.Image = global::MControls.Properties.Resources.VirtualDev;
            this.pictureBoxNext.Location = new System.Drawing.Point(195, 82);
            this.pictureBoxNext.Name = "pictureBoxNext";
            this.pictureBoxNext.Size = new System.Drawing.Size(96, 54);
            this.pictureBoxNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNext.TabIndex = 104;
            this.pictureBoxNext.TabStop = false;
            // 
            // pictureBoxCurrent
            // 
            this.pictureBoxCurrent.BackColor = System.Drawing.Color.Black;
            this.pictureBoxCurrent.Image = global::MControls.Properties.Resources.VirtualDev;
            this.pictureBoxCurrent.Location = new System.Drawing.Point(9, 43);
            this.pictureBoxCurrent.Name = "pictureBoxCurrent";
            this.pictureBoxCurrent.Size = new System.Drawing.Size(176, 99);
            this.pictureBoxCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCurrent.TabIndex = 103;
            this.pictureBoxCurrent.TabStop = false;
            // 
            // labelNext
            // 
            this.labelNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.labelNext.BackColorGrad = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.labelNext.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNext.FontEx = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNext.ForeColor = System.Drawing.Color.White;
            this.labelNext.ForeColorGrad = System.Drawing.Color.Gainsboro;
            this.labelNext.Location = new System.Drawing.Point(191, 65);
            this.labelNext.Name = "labelNext";
            this.labelNext.Size = new System.Drawing.Size(358, 75);
            this.labelNext.TabIndex = 98;
            this.labelNext.Tag = 0.5;
            this.labelNext.Text = "Cued:";
            this.labelNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNext.TextEx = "";
            this.labelNext.TextExPos = new System.Drawing.Point(0, 0);
            // 
            // labelCurrent
            // 
            this.labelCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(92)))), ((int)(((byte)(144)))));
            this.labelCurrent.BackColorGrad = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.labelCurrent.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrent.FontEx = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.labelCurrent.ForeColor = System.Drawing.Color.White;
            this.labelCurrent.ForeColorGrad = System.Drawing.Color.Gainsboro;
            this.labelCurrent.Location = new System.Drawing.Point(5, 26);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(550, 120);
            this.labelCurrent.TabIndex = 100;
            this.labelCurrent.Tag = 0.5;
            this.labelCurrent.Text = "Playing: ";
            this.labelCurrent.TextEx = "00:00:00 / 00:00:00";
            this.labelCurrent.TextExPos = new System.Drawing.Point(183, 13);
            // 
            // labelPlaylist
            // 
            this.labelPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlaylist.BackColor = System.Drawing.Color.Green;
            this.labelPlaylist.BackColorGrad = System.Drawing.Color.DarkSeaGreen;
            this.labelPlaylist.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.labelPlaylist.FontEx = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlaylist.ForeColor = System.Drawing.Color.White;
            this.labelPlaylist.ForeColorGrad = System.Drawing.Color.Gainsboro;
            this.labelPlaylist.Location = new System.Drawing.Point(0, 0);
            this.labelPlaylist.Name = "labelPlaylist";
            this.labelPlaylist.Size = new System.Drawing.Size(560, 151);
            this.labelPlaylist.TabIndex = 102;
            this.labelPlaylist.Tag = 0.5;
            this.labelPlaylist.Text = "Playlist: 00:00:00 / 00:00:00";
            this.labelPlaylist.TextEx = "";
            this.labelPlaylist.TextExPos = new System.Drawing.Point(0, 0);
            // 
            // MPlaylistStatus
            // 
            this.Controls.Add(this.pictureBoxNext);
            this.Controls.Add(this.pictureBoxCurrent);
            this.Controls.Add(this.labelNext);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelPlaylist);
            this.Name = "MPlaylistStatus";
            this.Size = new System.Drawing.Size(560, 159);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LabelEx labelNext;
        private LabelEx labelCurrent;
        private LabelEx labelPlaylist;
        private System.Windows.Forms.PictureBox pictureBoxNext;
        protected System.Windows.Forms.PictureBox pictureBoxCurrent;
    }
}
