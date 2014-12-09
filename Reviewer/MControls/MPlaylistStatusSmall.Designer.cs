namespace MControls
{
    partial class MPlaylistStatusSmall
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
            this.labelNext = new MControls.LabelEx();
            this.labelCurrent = new MControls.LabelEx();
            this.labelPlaylist = new MControls.LabelEx();
            this.SuspendLayout();
            // 
            // labelNext
            // 
            this.labelNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.labelNext.BackColorGrad = System.Drawing.Color.Gainsboro;
            this.labelNext.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNext.FontEx = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNext.ForeColor = System.Drawing.Color.White;
            this.labelNext.ForeColorGrad = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.labelNext.Location = new System.Drawing.Point(21, 67);
            this.labelNext.Name = "labelNext";
            this.labelNext.Size = new System.Drawing.Size(419, 16);
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
            this.labelCurrent.BackColorGrad = System.Drawing.Color.Gainsboro;
            this.labelCurrent.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrent.FontEx = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.labelCurrent.ForeColor = System.Drawing.Color.White;
            this.labelCurrent.ForeColorGrad = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.labelCurrent.Location = new System.Drawing.Point(10, 26);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(440, 62);
            this.labelCurrent.TabIndex = 100;
            this.labelCurrent.Tag = 0.5;
            this.labelCurrent.Text = "Playing: ";
            this.labelCurrent.TextEx = "00:00:00 / 00:00:00";
            this.labelCurrent.TextExPos = new System.Drawing.Point(0, 14);
            // 
            // labelPlaylist
            // 
            this.labelPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlaylist.BackColor = System.Drawing.Color.Green;
            this.labelPlaylist.BackColorGrad = System.Drawing.Color.Gainsboro;
            this.labelPlaylist.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.labelPlaylist.FontEx = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlaylist.ForeColor = System.Drawing.Color.White;
            this.labelPlaylist.ForeColorGrad = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(212)))));
            this.labelPlaylist.Location = new System.Drawing.Point(0, 0);
            this.labelPlaylist.Name = "labelPlaylist";
            this.labelPlaylist.Size = new System.Drawing.Size(440, 76);
            this.labelPlaylist.TabIndex = 102;
            this.labelPlaylist.Tag = 0.5;
            this.labelPlaylist.Text = "Playlist: 00:00:00 / 00:00:00";
            this.labelPlaylist.TextEx = "";
            this.labelPlaylist.TextExPos = new System.Drawing.Point(0, 0);
            // 
            // MPlaylistStatusSmall
            // 
            this.Controls.Add(this.labelNext);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelPlaylist);
            this.Name = "MPlaylistStatusSmall";
            this.Size = new System.Drawing.Size(450, 88);
            this.ResumeLayout(false);

        }

        #endregion

        private LabelEx labelNext;
        private LabelEx labelCurrent;
        private LabelEx labelPlaylist;
    }
}
