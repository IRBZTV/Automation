namespace MControls
{
    partial class MPreciseSeek
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
            this.buttonSeek = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.numericPos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericPreroll = new System.Windows.Forms.NumericUpDown();
            this.numericFrames = new System.Windows.Forms.NumericUpDown();
            this.button1FrameFrw = new System.Windows.Forms.Button();
            this.button1FrameRev = new System.Windows.Forms.Button();
            this.labelPos = new System.Windows.Forms.Label();
            this.trackBarScroll = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPreroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScroll)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSeek
            // 
            this.buttonSeek.Location = new System.Drawing.Point(285, 75);
            this.buttonSeek.Name = "buttonSeek";
            this.buttonSeek.Size = new System.Drawing.Size(59, 23);
            this.buttonSeek.TabIndex = 69;
            this.buttonSeek.Text = "Seek";
            this.buttonSeek.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(170, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 68;
            this.label12.Text = "Seek to:";
            // 
            // numericPos
            // 
            this.numericPos.DecimalPlaces = 3;
            this.numericPos.Location = new System.Drawing.Point(217, 77);
            this.numericPos.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericPos.Name = "numericPos";
            this.numericPos.Size = new System.Drawing.Size(65, 20);
            this.numericPos.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Seek preroll:";
            // 
            // numericPreroll
            // 
            this.numericPreroll.DecimalPlaces = 1;
            this.numericPreroll.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericPreroll.Location = new System.Drawing.Point(124, 77);
            this.numericPreroll.Name = "numericPreroll";
            this.numericPreroll.Size = new System.Drawing.Size(41, 20);
            this.numericPreroll.TabIndex = 65;
            this.numericPreroll.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // numericFrames
            // 
            this.numericFrames.Location = new System.Drawing.Point(386, 77);
            this.numericFrames.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericFrames.Name = "numericFrames";
            this.numericFrames.Size = new System.Drawing.Size(36, 20);
            this.numericFrames.TabIndex = 64;
            this.numericFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1FrameFrw
            // 
            this.button1FrameFrw.Location = new System.Drawing.Point(426, 75);
            this.button1FrameFrw.Name = "button1FrameFrw";
            this.button1FrameFrw.Size = new System.Drawing.Size(24, 23);
            this.button1FrameFrw.TabIndex = 63;
            this.button1FrameFrw.Text = ">";
            this.button1FrameFrw.UseVisualStyleBackColor = true;
            // 
            // button1FrameRev
            // 
            this.button1FrameRev.Location = new System.Drawing.Point(357, 75);
            this.button1FrameRev.Name = "button1FrameRev";
            this.button1FrameRev.Size = new System.Drawing.Size(24, 23);
            this.button1FrameRev.TabIndex = 62;
            this.button1FrameRev.Text = "<";
            this.button1FrameRev.UseVisualStyleBackColor = true;
            // 
            // labelPos
            // 
            this.labelPos.BackColor = System.Drawing.Color.Black;
            this.labelPos.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPos.ForeColor = System.Drawing.Color.Lime;
            this.labelPos.Location = new System.Drawing.Point(452, 77);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(186, 19);
            this.labelPos.TabIndex = 61;
            this.labelPos.Text = "00:00:00.000 / 00:00:00.000";
            this.labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBarScroll
            // 
            this.trackBarScroll.LargeChange = 10;
            this.trackBarScroll.Location = new System.Drawing.Point(45, 6);
            this.trackBarScroll.Maximum = 1000;
            this.trackBarScroll.Minimum = -1000;
            this.trackBarScroll.Name = "trackBarScroll";
            this.trackBarScroll.Size = new System.Drawing.Size(710, 45);
            this.trackBarScroll.TabIndex = 70;
            this.trackBarScroll.TickFrequency = 20;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(195, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 16);
            this.label1.TabIndex = 86;
            this.label1.Text = "Pos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(609, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 87;
            this.label2.Text = "FF";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(54, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 16);
            this.label4.TabIndex = 88;
            this.label4.Text = "REW";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MPreciseSeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarScroll);
            this.Controls.Add(this.buttonSeek);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericPreroll);
            this.Controls.Add(this.numericFrames);
            this.Controls.Add(this.button1FrameFrw);
            this.Controls.Add(this.button1FrameRev);
            this.Controls.Add(this.labelPos);
            this.Name = "MPreciseSeek";
            this.Size = new System.Drawing.Size(800, 120);
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPreroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSeek;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericPreroll;
        private System.Windows.Forms.NumericUpDown numericFrames;
        private System.Windows.Forms.Button button1FrameFrw;
        private System.Windows.Forms.Button button1FrameRev;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.TrackBar trackBarScroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}
