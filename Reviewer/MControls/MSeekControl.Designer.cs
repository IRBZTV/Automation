namespace MControls
{
    partial class MSeekControl
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
            this.labelPosStr = new System.Windows.Forms.Label();
            this.timerPos = new System.Windows.Forms.Timer(this.components);
            this.checkBoxInOut = new System.Windows.Forms.CheckBox();
            this.labelPosBase = new System.Windows.Forms.Label();
            this.labelInOut = new System.Windows.Forms.Label();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.textBoxRew = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPos
            // 
            this.labelPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.labelPos.ForeColor = System.Drawing.Color.Lime;
            this.labelPos.Location = new System.Drawing.Point(8, 25);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(265, 5);
            this.labelPos.TabIndex = 87;
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSeek.AutoSize = false;
            this.trackBarSeek.LargeChange = 10;
            this.trackBarSeek.Location = new System.Drawing.Point(-5, -2);
            this.trackBarSeek.Maximum = 1000;
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(347, 38);
            this.trackBarSeek.TabIndex = 86;
            this.trackBarSeek.TickFrequency = 50;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            this.trackBarSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSeek_MouseDown);
            // 
            // labelPosStr
            // 
            this.labelPosStr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPosStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.labelPosStr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosStr.ForeColor = System.Drawing.Color.White;
            this.labelPosStr.Location = new System.Drawing.Point(342, 21);
            this.labelPosStr.Name = "labelPosStr";
            this.labelPosStr.Size = new System.Drawing.Size(150, 15);
            this.labelPosStr.TabIndex = 88;
            this.labelPosStr.Text = "00:00:00.000 / 00:00:00.000";
            this.labelPosStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerPos
            // 
            this.timerPos.Enabled = true;
            this.timerPos.Tick += new System.EventHandler(this.timerPos_Tick);
            // 
            // checkBoxInOut
            // 
            this.checkBoxInOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxInOut.AutoSize = true;
            this.checkBoxInOut.Location = new System.Drawing.Point(436, 3);
            this.checkBoxInOut.Name = "checkBoxInOut";
            this.checkBoxInOut.Size = new System.Drawing.Size(57, 17);
            this.checkBoxInOut.TabIndex = 89;
            this.checkBoxInOut.Text = "In/Out";
            this.checkBoxInOut.UseVisualStyleBackColor = true;
            // 
            // labelPosBase
            // 
            this.labelPosBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPosBase.BackColor = System.Drawing.Color.White;
            this.labelPosBase.ForeColor = System.Drawing.Color.Lime;
            this.labelPosBase.Location = new System.Drawing.Point(8, 25);
            this.labelPosBase.Name = "labelPosBase";
            this.labelPosBase.Size = new System.Drawing.Size(321, 10);
            this.labelPosBase.TabIndex = 90;
            // 
            // labelInOut
            // 
            this.labelInOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.labelInOut.ForeColor = System.Drawing.Color.Lime;
            this.labelInOut.Location = new System.Drawing.Point(43, 30);
            this.labelInOut.Name = "labelInOut";
            this.labelInOut.Size = new System.Drawing.Size(265, 5);
            this.labelInOut.TabIndex = 91;
            // 
            // buttonRewind
            // 
            this.buttonRewind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRewind.Location = new System.Drawing.Point(414, -1);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(18, 21);
            this.buttonRewind.TabIndex = 95;
            this.buttonRewind.Text = "<";
            this.buttonRewind.UseVisualStyleBackColor = true;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // textBoxRew
            // 
            this.textBoxRew.AcceptsReturn = true;
            this.textBoxRew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRew.Location = new System.Drawing.Point(341, 0);
            this.textBoxRew.Name = "textBoxRew";
            this.textBoxRew.Size = new System.Drawing.Size(73, 20);
            this.textBoxRew.TabIndex = 96;
            this.textBoxRew.Text = "00:00:00";
            this.textBoxRew.WordWrap = false;
            this.textBoxRew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRew_KeyDown);
            // 
            // MSeekControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxRew);
            this.Controls.Add(this.buttonRewind);
            this.Controls.Add(this.labelInOut);
            this.Controls.Add(this.labelPos);
            this.Controls.Add(this.labelPosBase);
            this.Controls.Add(this.checkBoxInOut);
            this.Controls.Add(this.labelPosStr);
            this.Controls.Add(this.trackBarSeek);
            this.Name = "MSeekControl";
            this.Size = new System.Drawing.Size(491, 36);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Label labelPosStr;
        private System.Windows.Forms.Timer timerPos;
        private System.Windows.Forms.CheckBox checkBoxInOut;
        private System.Windows.Forms.Label labelPosBase;
        private System.Windows.Forms.Label labelInOut;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.TextBox textBoxRew;
    }
}
