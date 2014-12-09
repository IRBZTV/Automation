namespace MControls
{
    partial class MDelayControl
    {
        /// <summary> 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region autocode

        /// <summary> 
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBoxDelay = new System.Windows.Forms.CheckBox();
            this.numericDelayQuality = new System.Windows.Forms.NumericUpDown();
            this.numericDelayTime = new System.Windows.Forms.NumericUpDown();
            this.numericPos = new System.Windows.Forms.NumericUpDown();
            this.trackBarSeek = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerDelay = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxDelay
            // 
            this.checkBoxDelay.AutoSize = true;
            this.checkBoxDelay.Location = new System.Drawing.Point(3, 5);
            this.checkBoxDelay.Name = "checkBoxDelay";
            this.checkBoxDelay.Size = new System.Drawing.Size(94, 17);
            this.checkBoxDelay.TabIndex = 0;
            this.checkBoxDelay.Text = "Delay enabled";
            this.checkBoxDelay.UseVisualStyleBackColor = true;
            this.checkBoxDelay.CheckedChanged += new System.EventHandler(this.checkBoxDelay_CheckedChanged);
            // 
            // numericDelayQuality
            // 
            this.numericDelayQuality.Location = new System.Drawing.Point(151, 4);
            this.numericDelayQuality.Name = "numericDelayQuality";
            this.numericDelayQuality.Size = new System.Drawing.Size(42, 20);
            this.numericDelayQuality.TabIndex = 1;
            this.numericDelayQuality.ValueChanged += new System.EventHandler(this.numericDelayQuality_ValueChanged);
            // 
            // numericDelayTime
            // 
            this.numericDelayTime.Location = new System.Drawing.Point(281, 5);
            this.numericDelayTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericDelayTime.Name = "numericDelayTime";
            this.numericDelayTime.ReadOnly = true;
            this.numericDelayTime.Size = new System.Drawing.Size(42, 20);
            this.numericDelayTime.TabIndex = 2;
            // 
            // numericPos
            // 
            this.numericPos.Location = new System.Drawing.Point(281, 31);
            this.numericPos.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPos.Name = "numericPos";
            this.numericPos.Size = new System.Drawing.Size(42, 20);
            this.numericPos.TabIndex = 3;
            this.numericPos.ValueChanged += new System.EventHandler(this.numericPos_ValueChanged);
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.AutoSize = false;
            this.trackBarSeek.LargeChange = 10;
            this.trackBarSeek.Location = new System.Drawing.Point(3, 28);
            this.trackBarSeek.Maximum = 0;
            this.trackBarSeek.Minimum = -1000;
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(272, 23);
            this.trackBarSeek.TabIndex = 200;
            this.trackBarSeek.TickFrequency = 50;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quality:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buffered (sec):";
            // 
            // timerDelay
            // 
            this.timerDelay.Interval = 1000;
            this.timerDelay.Tick += new System.EventHandler(this.timerDelay_Tick);
            // 
            // MDelayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarSeek);
            this.Controls.Add(this.numericPos);
            this.Controls.Add(this.numericDelayTime);
            this.Controls.Add(this.numericDelayQuality);
            this.Controls.Add(this.checkBoxDelay);
            this.Name = "MDelayControl";
            this.Size = new System.Drawing.Size(330, 58);
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxDelay;
        private System.Windows.Forms.NumericUpDown numericDelayQuality;
        private System.Windows.Forms.NumericUpDown numericDelayTime;
        private System.Windows.Forms.NumericUpDown numericPos;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerDelay;
    }
}
