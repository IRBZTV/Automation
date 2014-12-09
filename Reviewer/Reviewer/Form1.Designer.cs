namespace Reviewer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PnlPreview = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mAudioMeter1 = new MControls.MAudioMeter();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LblCurrentRemainTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblCurrentTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblDurationTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mFileSeeking1 = new MControls.MFileSeeking();
            this.TimerUi = new System.Windows.Forms.Timer(this.components);
            this.PbPlayPause = new System.Windows.Forms.PictureBox();
            this.CmbDevice = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ChkTimeCode = new System.Windows.Forms.CheckBox();
            this.ChkArea = new System.Windows.Forms.CheckBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Programs_Kind_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Programs_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Media_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Media_Session_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Media_Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Review_Datetime_Insert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Media_Datetime_Insert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Review_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Media_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnInsertComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPass = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPlayPause)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PnlPreview);
            this.groupBox1.Location = new System.Drawing.Point(10, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 387);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Video";
            // 
            // PnlPreview
            // 
            this.PnlPreview.BackColor = System.Drawing.Color.Black;
            this.PnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPreview.Location = new System.Drawing.Point(3, 16);
            this.PnlPreview.Name = "PnlPreview";
            this.PnlPreview.Size = new System.Drawing.Size(431, 368);
            this.PnlPreview.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mAudioMeter1);
            this.groupBox2.Location = new System.Drawing.Point(453, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 384);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio";
            // 
            // mAudioMeter1
            // 
            this.mAudioMeter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.mAudioMeter1.BackColorHi = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.mAudioMeter1.ColorGainSlider = System.Drawing.Color.Red;
            this.mAudioMeter1.ColorLevelBack = System.Drawing.Color.DarkGray;
            this.mAudioMeter1.ColorLevelHi = System.Drawing.Color.Red;
            this.mAudioMeter1.ColorLevelLo = System.Drawing.Color.DarkBlue;
            this.mAudioMeter1.ColorLevelMid = System.Drawing.Color.Blue;
            this.mAudioMeter1.ColorLevelOrg = System.Drawing.Color.LightGray;
            this.mAudioMeter1.ColorOutline = System.Drawing.Color.Black;
            this.mAudioMeter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mAudioMeter1.Location = new System.Drawing.Point(3, 16);
            this.mAudioMeter1.Name = "mAudioMeter1";
            this.mAudioMeter1.Size = new System.Drawing.Size(129, 365);
            this.mAudioMeter1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LblCurrentRemainTime);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.LblCurrentTime);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.LblDurationTime);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox6.Location = new System.Drawing.Point(10, 34);
            this.groupBox6.MinimumSize = new System.Drawing.Size(200, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(597, 87);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Times";
            // 
            // LblCurrentRemainTime
            // 
            this.LblCurrentRemainTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.LblCurrentRemainTime.Font = new System.Drawing.Font("Digital-7", 25F);
            this.LblCurrentRemainTime.ForeColor = System.Drawing.Color.Red;
            this.LblCurrentRemainTime.Location = new System.Drawing.Point(398, 29);
            this.LblCurrentRemainTime.Name = "LblCurrentRemainTime";
            this.LblCurrentRemainTime.Size = new System.Drawing.Size(190, 50);
            this.LblCurrentRemainTime.TabIndex = 25;
            this.LblCurrentRemainTime.Text = "00:00:00:00";
            this.LblCurrentRemainTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(398, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Current Remaining";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCurrentTime
            // 
            this.LblCurrentTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.LblCurrentTime.Font = new System.Drawing.Font("Digital-7", 25F);
            this.LblCurrentTime.ForeColor = System.Drawing.Color.Lime;
            this.LblCurrentTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblCurrentTime.Location = new System.Drawing.Point(202, 29);
            this.LblCurrentTime.Name = "LblCurrentTime";
            this.LblCurrentTime.Size = new System.Drawing.Size(190, 50);
            this.LblCurrentTime.TabIndex = 23;
            this.LblCurrentTime.Text = "00:00:00:00";
            this.LblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(202, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Current";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDurationTime
            // 
            this.LblDurationTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(20)))), ((int)(((byte)(0)))));
            this.LblDurationTime.Font = new System.Drawing.Font("Digital-7", 25F);
            this.LblDurationTime.ForeColor = System.Drawing.Color.Lime;
            this.LblDurationTime.Location = new System.Drawing.Point(6, 29);
            this.LblDurationTime.Name = "LblDurationTime";
            this.LblDurationTime.Size = new System.Drawing.Size(190, 50);
            this.LblDurationTime.TabIndex = 21;
            this.LblDurationTime.Text = "00:00:00:00";
            this.LblDurationTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Duration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mFileSeeking1);
            this.groupBox3.Location = new System.Drawing.Point(10, 518);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 58);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seek";
            // 
            // mFileSeeking1
            // 
            this.mFileSeeking1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mFileSeeking1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mFileSeeking1.Location = new System.Drawing.Point(3, 16);
            this.mFileSeeking1.Name = "mFileSeeking1";
            this.mFileSeeking1.Size = new System.Drawing.Size(490, 39);
            this.mFileSeeking1.TabIndex = 0;
            // 
            // TimerUi
            // 
            this.TimerUi.Enabled = true;
            this.TimerUi.Tick += new System.EventHandler(this.TimerUi_Tick);
            // 
            // PbPlayPause
            // 
            this.PbPlayPause.BackColor = System.Drawing.Color.Transparent;
            this.PbPlayPause.Image = global::Reviewer.Properties.Resources.play;
            this.PbPlayPause.Location = new System.Drawing.Point(518, 532);
            this.PbPlayPause.Name = "PbPlayPause";
            this.PbPlayPause.Size = new System.Drawing.Size(70, 70);
            this.PbPlayPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbPlayPause.TabIndex = 6;
            this.PbPlayPause.TabStop = false;
            this.PbPlayPause.Click += new System.EventHandler(this.PbPlayPause_Click);
            // 
            // CmbDevice
            // 
            this.CmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.CmbDevice.FormattingEnabled = true;
            this.CmbDevice.Location = new System.Drawing.Point(12, 6);
            this.CmbDevice.Name = "CmbDevice";
            this.CmbDevice.Size = new System.Drawing.Size(194, 24);
            this.CmbDevice.TabIndex = 11;
            this.CmbDevice.SelectedIndexChanged += new System.EventHandler(this.CmbDevice_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton7);
            this.groupBox4.Controls.Add(this.radioButton8);
            this.groupBox4.Controls.Add(this.radioButton9);
            this.groupBox4.Controls.Add(this.radioButton10);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Controls.Add(this.radioButton5);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(10, 577);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(495, 40);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Play Speed";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton7.Location = new System.Drawing.Point(156, 14);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(44, 17);
            this.radioButton7.TabIndex = 9;
            this.radioButton7.Text = "-2X";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton8.Location = new System.Drawing.Point(106, 14);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(44, 17);
            this.radioButton8.TabIndex = 8;
            this.radioButton8.Text = "-4X";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton9.Location = new System.Drawing.Point(57, 14);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(44, 17);
            this.radioButton9.TabIndex = 7;
            this.radioButton9.Text = "-8X";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton10.Location = new System.Drawing.Point(3, 14);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(51, 17);
            this.radioButton10.TabIndex = 6;
            this.radioButton10.Text = "-16X";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton6.Location = new System.Drawing.Point(443, 14);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(47, 17);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "16X";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton5.Location = new System.Drawing.Point(398, 14);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(40, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "8X";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton4.Location = new System.Drawing.Point(208, 14);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(51, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "0.2X";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton3.Location = new System.Drawing.Point(357, 14);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(40, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "4X";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton2.Location = new System.Drawing.Point(309, 14);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(40, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "2X";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.radioButton1.ForeColor = System.Drawing.Color.Green;
            this.radioButton1.Location = new System.Drawing.Point(263, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(40, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1X";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ChkTimeCode
            // 
            this.ChkTimeCode.AutoSize = true;
            this.ChkTimeCode.Checked = true;
            this.ChkTimeCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTimeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ChkTimeCode.Location = new System.Drawing.Point(273, 10);
            this.ChkTimeCode.Name = "ChkTimeCode";
            this.ChkTimeCode.Size = new System.Drawing.Size(53, 17);
            this.ChkTimeCode.TabIndex = 12;
            this.ChkTimeCode.Text = "Time";
            this.ChkTimeCode.UseVisualStyleBackColor = true;
            this.ChkTimeCode.CheckedChanged += new System.EventHandler(this.ChkTimeCode_CheckedChanged);
            // 
            // ChkArea
            // 
            this.ChkArea.AutoSize = true;
            this.ChkArea.Checked = true;
            this.ChkArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ChkArea.Location = new System.Drawing.Point(215, 10);
            this.ChkArea.Name = "ChkArea";
            this.ChkArea.Size = new System.Drawing.Size(52, 17);
            this.ChkArea.TabIndex = 14;
            this.ChkArea.Text = "Area";
            this.ChkArea.UseVisualStyleBackColor = true;
            this.ChkArea.CheckedChanged += new System.EventHandler(this.ChkArea_CheckedChanged);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(589, 124);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(18, 384);
            this.trackBarVolume.TabIndex = 175;
            this.trackBarVolume.TickFrequency = 10;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dgvList);
            this.groupBox5.Location = new System.Drawing.Point(619, 34);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(376, 257);
            this.groupBox5.TabIndex = 176;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "List";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Programs_Kind_Title,
            this.Programs_Title,
            this.Media_Title,
            this.Media_Session_Number,
            this.Media_Duration,
            this.Review_Datetime_Insert,
            this.Media_Datetime_Insert,
            this.Review_Id,
            this.FilePath,
            this.Media_Id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 16);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(370, 238);
            this.dgvList.TabIndex = 0;
            this.dgvList.Click += new System.EventHandler(this.dgvList_Click);
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            // 
            // Programs_Kind_Title
            // 
            this.Programs_Kind_Title.HeaderText = "نوع برنامه";
            this.Programs_Kind_Title.Name = "Programs_Kind_Title";
            this.Programs_Kind_Title.ReadOnly = true;
            // 
            // Programs_Title
            // 
            this.Programs_Title.HeaderText = "عنوان برنامه";
            this.Programs_Title.Name = "Programs_Title";
            this.Programs_Title.ReadOnly = true;
            // 
            // Media_Title
            // 
            this.Media_Title.HeaderText = "عنوان فایل";
            this.Media_Title.Name = "Media_Title";
            this.Media_Title.ReadOnly = true;
            // 
            // Media_Session_Number
            // 
            this.Media_Session_Number.HeaderText = "قسمت";
            this.Media_Session_Number.Name = "Media_Session_Number";
            this.Media_Session_Number.ReadOnly = true;
            // 
            // Media_Duration
            // 
            this.Media_Duration.HeaderText = "مدت";
            this.Media_Duration.Name = "Media_Duration";
            this.Media_Duration.ReadOnly = true;
            // 
            // Review_Datetime_Insert
            // 
            this.Review_Datetime_Insert.HeaderText = "ارسال بازبینی";
            this.Review_Datetime_Insert.Name = "Review_Datetime_Insert";
            this.Review_Datetime_Insert.ReadOnly = true;
            // 
            // Media_Datetime_Insert
            // 
            this.Media_Datetime_Insert.HeaderText = "زمان آپلود";
            this.Media_Datetime_Insert.Name = "Media_Datetime_Insert";
            this.Media_Datetime_Insert.ReadOnly = true;
            // 
            // Review_Id
            // 
            this.Review_Id.HeaderText = "بازبینی";
            this.Review_Id.Name = "Review_Id";
            this.Review_Id.ReadOnly = true;
            this.Review_Id.Visible = false;
            // 
            // FilePath
            // 
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // Media_Id
            // 
            this.Media_Id.HeaderText = "Media_Id";
            this.Media_Id.Name = "Media_Id";
            this.Media_Id.ReadOnly = true;
            this.Media_Id.Visible = false;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Location = new System.Drawing.Point(917, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 177;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnInsertComment);
            this.groupBox7.Controls.Add(this.txtComment);
            this.groupBox7.Location = new System.Drawing.Point(619, 297);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(373, 72);
            this.groupBox7.TabIndex = 178;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Comment";
            // 
            // btnInsertComment
            // 
            this.btnInsertComment.Location = new System.Drawing.Point(7, 16);
            this.btnInsertComment.Name = "btnInsertComment";
            this.btnInsertComment.Size = new System.Drawing.Size(41, 46);
            this.btnInsertComment.TabIndex = 1;
            this.btnInsertComment.Text = "+";
            this.btnInsertComment.UseVisualStyleBackColor = true;
            this.btnInsertComment.Click += new System.EventHandler(this.btnInsertComment_Click);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(54, 12);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(313, 54);
            this.txtComment.TabIndex = 0;
            this.txtComment.Text = "";
            this.toolTip1.SetToolTip(this.txtComment, "ثبت شرح  ایراد برای زمان انتخاب شده");
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.dgvComments);
            this.groupBox8.Location = new System.Drawing.Point(622, 375);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(373, 242);
            this.groupBox8.TabIndex = 179;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Comment";
            // 
            // dgvComments
            // 
            this.dgvComments.AllowUserToAddRows = false;
            this.dgvComments.AllowUserToDeleteRows = false;
            this.dgvComments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3,
            this.TimeCode,
            this.ReplyText,
            this.ReplyTime,
            this.ReplyUser});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComments.Location = new System.Drawing.Point(3, 16);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvComments.RowHeadersVisible = false;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.Size = new System.Drawing.Size(367, 223);
            this.dgvComments.TabIndex = 1;
            this.dgvComments.DoubleClick += new System.EventHandler(this.dgvComments_DoubleClick);
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Location = new System.Drawing.Point(756, 4);
            this.btnPass.Name = "btnPass";
            this.btnPass.Size = new System.Drawing.Size(75, 23);
            this.btnPass.TabIndex = 180;
            this.btnPass.Text = "Pass";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.Location = new System.Drawing.Point(837, 4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 181;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "بازبینی نشده",
            "تایید شده",
            "رد شده"});
            this.cmbStatus.Location = new System.Drawing.Point(619, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(84, 28);
            this.cmbStatus.TabIndex = 182;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "متن";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "تایم کد";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "فرستنده";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "زمان ثبت";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // TimeCode
            // 
            this.TimeCode.HeaderText = "TimeCode";
            this.TimeCode.Name = "TimeCode";
            this.TimeCode.ReadOnly = true;
            this.TimeCode.Visible = false;
            // 
            // ReplyText
            // 
            this.ReplyText.HeaderText = "پاسخ";
            this.ReplyText.Name = "ReplyText";
            this.ReplyText.ReadOnly = true;
            // 
            // ReplyTime
            // 
            this.ReplyTime.HeaderText = "زمان پاسخ";
            this.ReplyTime.Name = "ReplyTime";
            this.ReplyTime.ReadOnly = true;
            // 
            // ReplyUser
            // 
            this.ReplyUser.HeaderText = "پاسخ دهنده";
            this.ReplyUser.Name = "ReplyUser";
            this.ReplyUser.ReadOnly = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 646);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnPass);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.ChkArea);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ChkTimeCode);
            this.Controls.Add(this.CmbDevice);
            this.Controls.Add(this.PbPlayPause);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reviewer V1.7  2014-08-04";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbPlayPause)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label LblCurrentRemainTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblCurrentTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblDurationTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PnlPreview;
        private System.Windows.Forms.GroupBox groupBox3;
        private MControls.MFileSeeking mFileSeeking1;
        private System.Windows.Forms.Timer TimerUi;
        private System.Windows.Forms.PictureBox PbPlayPause;
        private System.Windows.Forms.ComboBox CmbDevice;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.CheckBox ChkTimeCode;
        private System.Windows.Forms.CheckBox ChkArea;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private MControls.MAudioMeter mAudioMeter1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Programs_Kind_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Programs_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Media_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Media_Session_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Media_Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Review_Datetime_Insert;
        private System.Windows.Forms.DataGridViewTextBoxColumn Media_Datetime_Insert;
        private System.Windows.Forms.DataGridViewTextBoxColumn Review_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Media_Id;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.Button btnInsertComment;
        private System.Windows.Forms.RichTextBox txtComment;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPass;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyUser;
    }
}

