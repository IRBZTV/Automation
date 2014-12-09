namespace MControls
{
    partial class MLiveControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboPreviewType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericPos = new System.Windows.Forms.NumericUpDown();
            this.trackBarSeek = new System.Windows.Forms.TrackBar();
            this.numericDelayTime = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericDelayQuality = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxDelay = new System.Windows.Forms.CheckBox();
            this.buttonAF = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonVF = new System.Windows.Forms.Button();
            this.buttonV = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.comboBoxAF = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAL = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxAudio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVF = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxVL = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxVideo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerDelay = new System.Windows.Forms.Timer(this.components);
            this.mPropsControl1 = new MControls.MPropsControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.comboPreviewType);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericPos);
            this.panel1.Controls.Add(this.trackBarSeek);
            this.panel1.Controls.Add(this.mPropsControl1);
            this.panel1.Controls.Add(this.numericDelayTime);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.numericDelayQuality);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.checkBoxDelay);
            this.panel1.Controls.Add(this.buttonAF);
            this.panel1.Controls.Add(this.buttonA);
            this.panel1.Controls.Add(this.buttonVF);
            this.panel1.Controls.Add(this.buttonV);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonInit);
            this.panel1.Controls.Add(this.comboBoxAF);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBoxAL);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxAudio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxVF);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxVL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxVideo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 396);
            this.panel1.TabIndex = 178;
            // 
            // comboPreviewType
            // 
            this.comboPreviewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPreviewType.DisplayMember = "Delayed";
            this.comboPreviewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPreviewType.FormattingEnabled = true;
            this.comboPreviewType.Items.AddRange(new object[] {
            "Delayed",
            "Live"});
            this.comboPreviewType.Location = new System.Drawing.Point(230, 369);
            this.comboPreviewType.Name = "comboPreviewType";
            this.comboPreviewType.Size = new System.Drawing.Size(121, 21);
            this.comboPreviewType.TabIndex = 203;
            this.comboPreviewType.SelectedIndexChanged += new System.EventHandler(this.comboPreviewType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 202;
            this.label7.Text = "Preview type";
            // 
            // numericPos
            // 
            this.numericPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericPos.DecimalPlaces = 1;
            this.numericPos.Location = new System.Drawing.Point(297, 229);
            this.numericPos.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericPos.Name = "numericPos";
            this.numericPos.Size = new System.Drawing.Size(54, 20);
            this.numericPos.TabIndex = 201;
            this.numericPos.ValueChanged += new System.EventHandler(this.numericPos_ValueChanged);
            // 
            // trackBarSeek
            // 
            this.trackBarSeek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSeek.AutoSize = false;
            this.trackBarSeek.LargeChange = 10;
            this.trackBarSeek.Location = new System.Drawing.Point(3, 228);
            this.trackBarSeek.Maximum = 0;
            this.trackBarSeek.Minimum = -1000;
            this.trackBarSeek.Name = "trackBarSeek";
            this.trackBarSeek.Size = new System.Drawing.Size(297, 26);
            this.trackBarSeek.TabIndex = 200;
            this.trackBarSeek.TickFrequency = 50;
            this.trackBarSeek.Scroll += new System.EventHandler(this.trackBarSeek_Scroll);
            // 
            // numericDelayTime
            // 
            this.numericDelayTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericDelayTime.DecimalPlaces = 1;
            this.numericDelayTime.Location = new System.Drawing.Point(297, 203);
            this.numericDelayTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericDelayTime.Name = "numericDelayTime";
            this.numericDelayTime.ReadOnly = true;
            this.numericDelayTime.Size = new System.Drawing.Size(54, 20);
            this.numericDelayTime.TabIndex = 198;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 197;
            this.label10.Text = "Buffered (sec):";
            // 
            // numericDelayQuality
            // 
            this.numericDelayQuality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numericDelayQuality.Location = new System.Drawing.Point(157, 203);
            this.numericDelayQuality.Name = "numericDelayQuality";
            this.numericDelayQuality.Size = new System.Drawing.Size(43, 20);
            this.numericDelayQuality.TabIndex = 196;
            this.numericDelayQuality.ValueChanged += new System.EventHandler(this.numericDelayQuality_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(114, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 195;
            this.label9.Text = "Quality:";
            // 
            // checkBoxDelay
            // 
            this.checkBoxDelay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxDelay.AutoSize = true;
            this.checkBoxDelay.Location = new System.Drawing.Point(13, 205);
            this.checkBoxDelay.Name = "checkBoxDelay";
            this.checkBoxDelay.Size = new System.Drawing.Size(94, 17);
            this.checkBoxDelay.TabIndex = 194;
            this.checkBoxDelay.Text = "Delay enabled";
            this.checkBoxDelay.UseVisualStyleBackColor = true;
            this.checkBoxDelay.CheckedChanged += new System.EventHandler(this.checkBoxDelay_CheckedChanged);
            // 
            // buttonAF
            // 
            this.buttonAF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAF.Location = new System.Drawing.Point(276, 146);
            this.buttonAF.Name = "buttonAF";
            this.buttonAF.Size = new System.Drawing.Size(75, 23);
            this.buttonAF.TabIndex = 191;
            this.buttonAF.Text = "Props";
            this.buttonAF.UseVisualStyleBackColor = true;
            this.buttonAF.Click += new System.EventHandler(this.buttonAF_Click);
            // 
            // buttonA
            // 
            this.buttonA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonA.Location = new System.Drawing.Point(276, 94);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(75, 23);
            this.buttonA.TabIndex = 190;
            this.buttonA.Text = "Props";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonA_Click);
            // 
            // buttonVF
            // 
            this.buttonVF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVF.Location = new System.Drawing.Point(276, 61);
            this.buttonVF.Name = "buttonVF";
            this.buttonVF.Size = new System.Drawing.Size(75, 23);
            this.buttonVF.TabIndex = 189;
            this.buttonVF.Text = "Props";
            this.buttonVF.UseVisualStyleBackColor = true;
            this.buttonVF.Click += new System.EventHandler(this.buttonVF_Click);
            // 
            // buttonV
            // 
            this.buttonV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonV.Location = new System.Drawing.Point(276, 7);
            this.buttonV.Name = "buttonV";
            this.buttonV.Size = new System.Drawing.Size(75, 23);
            this.buttonV.TabIndex = 188;
            this.buttonV.Text = "Props";
            this.buttonV.UseVisualStyleBackColor = true;
            this.buttonV.Click += new System.EventHandler(this.buttonV_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClose.Location = new System.Drawing.Point(187, 176);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 23);
            this.buttonClose.TabIndex = 187;
            this.buttonClose.Text = "Close Device";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonInit.Location = new System.Drawing.Point(10, 176);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(164, 23);
            this.buttonInit.TabIndex = 186;
            this.buttonInit.Text = "Init Device";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // comboBoxAF
            // 
            this.comboBoxAF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAF.FormattingEnabled = true;
            this.comboBoxAF.Location = new System.Drawing.Point(50, 147);
            this.comboBoxAF.Name = "comboBoxAF";
            this.comboBoxAF.Size = new System.Drawing.Size(220, 21);
            this.comboBoxAF.TabIndex = 185;
            this.comboBoxAF.SelectedIndexChanged += new System.EventHandler(this.comboBoxAVF_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "Format:";
            // 
            // comboBoxAL
            // 
            this.comboBoxAL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAL.FormattingEnabled = true;
            this.comboBoxAL.Location = new System.Drawing.Point(50, 121);
            this.comboBoxAL.Name = "comboBoxAL";
            this.comboBoxAL.Size = new System.Drawing.Size(220, 21);
            this.comboBoxAL.TabIndex = 183;
            this.comboBoxAL.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 182;
            this.label5.Text = "Line:";
            // 
            // comboBoxAudio
            // 
            this.comboBoxAudio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudio.FormattingEnabled = true;
            this.comboBoxAudio.Location = new System.Drawing.Point(50, 95);
            this.comboBoxAudio.Name = "comboBoxAudio";
            this.comboBoxAudio.Size = new System.Drawing.Size(220, 21);
            this.comboBoxAudio.TabIndex = 181;
            this.comboBoxAudio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 180;
            this.label6.Text = "Audio:";
            // 
            // comboBoxVF
            // 
            this.comboBoxVF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVF.FormattingEnabled = true;
            this.comboBoxVF.Location = new System.Drawing.Point(50, 62);
            this.comboBoxVF.Name = "comboBoxVF";
            this.comboBoxVF.Size = new System.Drawing.Size(220, 21);
            this.comboBoxVF.TabIndex = 179;
            this.comboBoxVF.SelectedIndexChanged += new System.EventHandler(this.comboBoxAVF_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 178;
            this.label3.Text = "Format:";
            // 
            // comboBoxVL
            // 
            this.comboBoxVL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVL.FormattingEnabled = true;
            this.comboBoxVL.Location = new System.Drawing.Point(50, 35);
            this.comboBoxVL.Name = "comboBoxVL";
            this.comboBoxVL.Size = new System.Drawing.Size(220, 21);
            this.comboBoxVL.TabIndex = 177;
            this.comboBoxVL.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 176;
            this.label2.Text = "Line:";
            // 
            // comboBoxVideo
            // 
            this.comboBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideo.FormattingEnabled = true;
            this.comboBoxVideo.Location = new System.Drawing.Point(50, 8);
            this.comboBoxVideo.Name = "comboBoxVideo";
            this.comboBoxVideo.Size = new System.Drawing.Size(220, 21);
            this.comboBoxVideo.TabIndex = 175;
            this.comboBoxVideo.SelectedIndexChanged += new System.EventHandler(this.comboBoxAV_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Video:";
            // 
            // timerDelay
            // 
            this.timerDelay.Interval = 1000;
            this.timerDelay.Tick += new System.EventHandler(this.timerDelay_Tick);
            // 
            // mPropsControl1
            // 
            this.mPropsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mPropsControl1.Columns = 2;
            this.mPropsControl1.Location = new System.Drawing.Point(10, 260);
            this.mPropsControl1.Name = "mPropsControl1";
            this.mPropsControl1.Simple = true;
            this.mPropsControl1.Size = new System.Drawing.Size(341, 103);
            this.mPropsControl1.TabIndex = 199;
            // 
            // MLiveControl
            // 
            this.Controls.Add(this.panel1);
            this.Name = "MLiveControl";
            this.Size = new System.Drawing.Size(367, 404);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelayQuality)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAF;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonVF;
        private System.Windows.Forms.Button buttonV;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.ComboBox comboBoxAF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxAudio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxVF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxVL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxDelay;
        private System.Windows.Forms.NumericUpDown numericDelayQuality;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericDelayTime;
        private System.Windows.Forms.Label label10;
        private MPropsControl mPropsControl1;
        private System.Windows.Forms.NumericUpDown numericPos;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Timer timerDelay;
        private System.Windows.Forms.ComboBox comboPreviewType;
        private System.Windows.Forms.Label label7;
    }
}
