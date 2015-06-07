namespace Conductor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbDayAfter = new System.Windows.Forms.PictureBox();
            this.pbDayBefore = new System.Windows.Forms.PictureBox();
            this.lblDayTitle = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFileStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblReviewer = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileDuration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSessionNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFileId = new System.Windows.Forms.TextBox();
            this.txtSessionNo = new System.Windows.Forms.TextBox();
            this.cmbProg = new System.Windows.Forms.ComboBox();
            this.cmbProgKind = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbPlayVideo = new System.Windows.Forms.PictureBox();
            this.pbDublicate = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDayAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDayBefore)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDublicate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvItems);
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(996, 399);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "لیست برنامه ها";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(3, 20);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(990, 376);
            this.dgvItems.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ردیف";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "نوع برنامه";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "عنوان برنامه";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "عنوان قسمت";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "شماره قسمت";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "زمان شروع";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "مدت";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "زمان پایان";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "توضیحات";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "منتخب";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ثابت";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbDayAfter);
            this.groupBox2.Controls.Add(this.pbDayBefore);
            this.groupBox2.Controls.Add(this.lblDayTitle);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Location = new System.Drawing.Point(712, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(296, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تاریخ";
            // 
            // pbDayAfter
            // 
            this.pbDayAfter.Image = global::Conductor.Properties.Resources.go_left;
            this.pbDayAfter.Location = new System.Drawing.Point(93, 20);
            this.pbDayAfter.Name = "pbDayAfter";
            this.pbDayAfter.Size = new System.Drawing.Size(30, 30);
            this.pbDayAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDayAfter.TabIndex = 4;
            this.pbDayAfter.TabStop = false;
            // 
            // pbDayBefore
            // 
            this.pbDayBefore.Image = global::Conductor.Properties.Resources.go_right;
            this.pbDayBefore.Location = new System.Drawing.Point(257, 20);
            this.pbDayBefore.Name = "pbDayBefore";
            this.pbDayBefore.Size = new System.Drawing.Size(30, 30);
            this.pbDayBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDayBefore.TabIndex = 3;
            this.pbDayBefore.TabStop = false;
            // 
            // lblDayTitle
            // 
            this.lblDayTitle.AutoSize = true;
            this.lblDayTitle.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDayTitle.ForeColor = System.Drawing.Color.Green;
            this.lblDayTitle.Location = new System.Drawing.Point(6, 15);
            this.lblDayTitle.Name = "lblDayTitle";
            this.lblDayTitle.Size = new System.Drawing.Size(99, 47);
            this.lblDayTitle.TabIndex = 2;
            this.lblDayTitle.Text = "یکشنبه";
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDate.Location = new System.Drawing.Point(129, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(122, 55);
            this.txtDate.TabIndex = 0;
            this.txtDate.Text = "1393/09/02";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFileStatus);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblReviewer);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtFileDuration);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmbSessionNumber);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.txtFileId);
            this.groupBox3.Controls.Add(this.txtSessionNo);
            this.groupBox3.Controls.Add(this.cmbProg);
            this.groupBox3.Controls.Add(this.cmbProgKind);
            this.groupBox3.Location = new System.Drawing.Point(15, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(691, 192);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ورود اطلاعات";
            // 
            // lblFileStatus
            // 
            this.lblFileStatus.AutoSize = true;
            this.lblFileStatus.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFileStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFileStatus.Location = new System.Drawing.Point(364, 155);
            this.lblFileStatus.Name = "lblFileStatus";
            this.lblFileStatus.Size = new System.Drawing.Size(176, 32);
            this.lblFileStatus.TabIndex = 18;
            this.lblFileStatus.Text = "وضعیت فایل در سیستم";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(612, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "بازبین:";
            // 
            // lblReviewer
            // 
            this.lblReviewer.AutoSize = true;
            this.lblReviewer.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblReviewer.ForeColor = System.Drawing.Color.Green;
            this.lblReviewer.Location = new System.Drawing.Point(527, 149);
            this.lblReviewer.Name = "lblReviewer";
            this.lblReviewer.Size = new System.Drawing.Size(103, 32);
            this.lblReviewer.TabIndex = 16;
            this.lblReviewer.Text = "آقای محمدی";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "مدت:";
            // 
            // txtFileDuration
            // 
            this.txtFileDuration.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFileDuration.Location = new System.Drawing.Point(364, 108);
            this.txtFileDuration.Name = "txtFileDuration";
            this.txtFileDuration.Size = new System.Drawing.Size(76, 44);
            this.txtFileDuration.TabIndex = 14;
            this.txtFileDuration.Text = "00:00:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(612, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "شماره فایل:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "شماره:";
            // 
            // cmbSessionNumber
            // 
            this.cmbSessionNumber.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbSessionNumber.FormattingEnabled = true;
            this.cmbSessionNumber.Location = new System.Drawing.Point(142, 64);
            this.cmbSessionNumber.Name = "cmbSessionNumber";
            this.cmbSessionNumber.Size = new System.Drawing.Size(464, 45);
            this.cmbSessionNumber.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(612, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "قسمت:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "برنامه:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(612, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "نوع برنامه:";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("B Nazanin", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDescription.Location = new System.Drawing.Point(6, 108);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(352, 78);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Text = "توضیحات";
            // 
            // txtFileId
            // 
            this.txtFileId.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFileId.Location = new System.Drawing.Point(487, 108);
            this.txtFileId.Name = "txtFileId";
            this.txtFileId.Size = new System.Drawing.Size(119, 44);
            this.txtFileId.TabIndex = 6;
            this.txtFileId.Text = "6512376";
            // 
            // txtSessionNo
            // 
            this.txtSessionNo.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSessionNo.Location = new System.Drawing.Point(6, 65);
            this.txtSessionNo.Name = "txtSessionNo";
            this.txtSessionNo.Size = new System.Drawing.Size(72, 44);
            this.txtSessionNo.TabIndex = 5;
            this.txtSessionNo.Text = "475";
            // 
            // cmbProg
            // 
            this.cmbProg.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbProg.FormattingEnabled = true;
            this.cmbProg.Location = new System.Drawing.Point(6, 20);
            this.cmbProg.Name = "cmbProg";
            this.cmbProg.Size = new System.Drawing.Size(390, 45);
            this.cmbProg.TabIndex = 1;
            // 
            // cmbProgKind
            // 
            this.cmbProgKind.Font = new System.Drawing.Font("B Nazanin", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbProgKind.FormattingEnabled = true;
            this.cmbProgKind.Location = new System.Drawing.Point(465, 20);
            this.cmbProgKind.Name = "cmbProgKind";
            this.cmbProgKind.Size = new System.Drawing.Size(141, 45);
            this.cmbProgKind.TabIndex = 0;
            this.cmbProgKind.SelectedIndexChanged += new System.EventHandler(this.cmbProgKind_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbPlayVideo);
            this.groupBox4.Controls.Add(this.pbDublicate);
            this.groupBox4.Controls.Add(this.pbDelete);
            this.groupBox4.Controls.Add(this.pbSend);
            this.groupBox4.Controls.Add(this.pbPrint);
            this.groupBox4.Location = new System.Drawing.Point(712, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(296, 120);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "تاریخ";
            // 
            // pbPlayVideo
            // 
            this.pbPlayVideo.Image = global::Conductor.Properties.Resources.player_play;
            this.pbPlayVideo.Location = new System.Drawing.Point(247, 20);
            this.pbPlayVideo.Name = "pbPlayVideo";
            this.pbPlayVideo.Size = new System.Drawing.Size(40, 40);
            this.pbPlayVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayVideo.TabIndex = 7;
            this.pbPlayVideo.TabStop = false;
            // 
            // pbDublicate
            // 
            this.pbDublicate.Image = global::Conductor.Properties.Resources.Duplicate;
            this.pbDublicate.Location = new System.Drawing.Point(190, 20);
            this.pbDublicate.Name = "pbDublicate";
            this.pbDublicate.Size = new System.Drawing.Size(40, 40);
            this.pbDublicate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDublicate.TabIndex = 6;
            this.pbDublicate.TabStop = false;
            // 
            // pbDelete
            // 
            this.pbDelete.Image = global::Conductor.Properties.Resources.deletered;
            this.pbDelete.Location = new System.Drawing.Point(129, 20);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(40, 40);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 5;
            this.pbDelete.TabStop = false;
            // 
            // pbSend
            // 
            this.pbSend.Image = global::Conductor.Properties.Resources.copy;
            this.pbSend.Location = new System.Drawing.Point(73, 20);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(40, 40);
            this.pbSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSend.TabIndex = 4;
            this.pbSend.TabStop = false;
            // 
            // pbPrint
            // 
            this.pbPrint.Image = global::Conductor.Properties.Resources.printer;
            this.pbPrint.Location = new System.Drawing.Point(15, 20);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(40, 40);
            this.pbPrint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPrint.TabIndex = 3;
            this.pbPrint.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 621);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "Form1";
            this.Text = "کنداکتور";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDayAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDayBefore)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDublicate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.PictureBox pbDayAfter;
        private System.Windows.Forms.PictureBox pbDayBefore;
        private System.Windows.Forms.Label lblDayTitle;
        private System.Windows.Forms.ComboBox cmbProgKind;
        private System.Windows.Forms.ComboBox cmbProg;
        private System.Windows.Forms.TextBox txtSessionNo;
        private System.Windows.Forms.TextBox txtFileId;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbSessionNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblReviewer;
        private System.Windows.Forms.Label lblFileStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbPrint;
        private System.Windows.Forms.PictureBox pbPlayVideo;
        private System.Windows.Forms.PictureBox pbDublicate;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.PictureBox pbSend;
    }
}

