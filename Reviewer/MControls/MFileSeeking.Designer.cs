namespace MControls
{
    partial class MFileSeeking
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
            this.components = new System.ComponentModel.Container();
            this.labelPos = new System.Windows.Forms.Label();
            this.trackBarSeek = new System.Windows.Forms.TrackBar();
            this.timerPos = new System.Windows.Forms.Timer(this.components);
            this.labelPosBase = new System.Windows.Forms.Label();
            this.labelInOut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPos
            // 
            this.labelPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.labelPos.ForeColor = System.Drawing.Color.Lime;
            this.labelPos.Location = new System.Drawing.Point(11, 25);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(480, 5);
            this.labelPos.TabIndex = 87;
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.AutoSize = false;
            this.trackBarSeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarSeek.LargeChange = 10;
            this.trackBarSeek.Location = new System.Drawing.Point(0, 0);
            this.trackBarSeek.Maximum = 1000;
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(491, 36);
            this.trackBarSeek.TabIndex = 86;
            this.trackBarSeek.TickFrequency = 50;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            this.trackBarSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSeek_MouseDown);
            // 
            // timerPos
            // 
            this.timerPos.Enabled = true;
            this.timerPos.Tick += new System.EventHandler(this.timerPos_Tick);
            // 
            // labelPosBase
            // 
            this.labelPosBase.BackColor = System.Drawing.Color.White;
            this.labelPosBase.ForeColor = System.Drawing.Color.Lime;
            this.labelPosBase.Location = new System.Drawing.Point(8, 25);
            this.labelPosBase.Name = "labelPosBase";
            this.labelPosBase.Size = new System.Drawing.Size(483, 10);
            this.labelPosBase.TabIndex = 90;
            // 
            // labelInOut
            // 
            this.labelInOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.labelInOut.ForeColor = System.Drawing.Color.Lime;
            this.labelInOut.Location = new System.Drawing.Point(11, 30);
            this.labelInOut.Name = "labelInOut";
            this.labelInOut.Size = new System.Drawing.Size(480, 5);
            this.labelInOut.TabIndex = 91;
            // 
            // MFileSeeking
            // 
            this.Controls.Add(this.labelInOut);
            this.Controls.Add(this.labelPos);
            this.Controls.Add(this.labelPosBase);
            this.Controls.Add(this.trackBarSeek);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MFileSeeking";
            this.Size = new System.Drawing.Size(491, 36);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Timer timerPos;
        private System.Windows.Forms.Label labelPosBase;
        private System.Windows.Forms.Label labelInOut;
    }
}
