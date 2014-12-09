namespace MControls
{
    partial class FormPlaylist
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mPlaylistControl1 = new MControls.MPlaylistList();
            this.SuspendLayout();
            // 
            // mPlaylistControl1
            // 
            this.mPlaylistControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mPlaylistControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPlaylistControl1.Location = new System.Drawing.Point(1, 1);
            this.mPlaylistControl1.Name = "mPlaylistControl1";
            this.mPlaylistControl1.Size = new System.Drawing.Size(456, 306);
            this.mPlaylistControl1.TabIndex = 0;
            // 
            // FormPlaylist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 309);
            this.Controls.Add(this.mPlaylistControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormPlaylist";
            this.Text = "MPlaylist Config";
            this.Load += new System.EventHandler(this.FormPlaylist_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPlaylist_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MPlaylistList mPlaylistControl1;
    }
}