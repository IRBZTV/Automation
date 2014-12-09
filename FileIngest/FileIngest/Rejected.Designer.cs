namespace FileIngest
{
    partial class Rejected
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rejected));
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReplyUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnReplyComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.RichTextBox();
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSendReviewer = new DevExpress.XtraEditors.SimpleButton();
            this.btnDownload = new DevExpress.XtraEditors.SimpleButton();
            this.btnReplaceVideo = new DevExpress.XtraEditors.SimpleButton();
            this.btnPlay = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.dgvComments);
            this.groupBox8.Location = new System.Drawing.Point(9, 216);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1003, 242);
            this.groupBox8.TabIndex = 182;
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
            this.ReplyUser,
            this.Id});
            this.dgvComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComments.Location = new System.Drawing.Point(3, 17);
            this.dgvComments.MultiSelect = false;
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.ReadOnly = true;
            this.dgvComments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvComments.RowHeadersVisible = false;
            this.dgvComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComments.Size = new System.Drawing.Size(997, 222);
            this.dgvComments.TabIndex = 1;
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
            // Id
            // 
            this.Id.HeaderText = "id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnReplyComment);
            this.groupBox7.Controls.Add(this.txtComment);
            this.groupBox7.Location = new System.Drawing.Point(9, 459);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1000, 100);
            this.groupBox7.TabIndex = 181;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Reply Comment";
            // 
            // btnReplyComment
            // 
            this.btnReplyComment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnReplyComment.Location = new System.Drawing.Point(7, 32);
            this.btnReplyComment.Name = "btnReplyComment";
            this.btnReplyComment.Size = new System.Drawing.Size(90, 46);
            this.btnReplyComment.TabIndex = 1;
            this.btnReplyComment.Text = "Reply";
            this.btnReplyComment.UseVisualStyleBackColor = true;
            this.btnReplyComment.Click += new System.EventHandler(this.btnReplyComment_Click);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(103, 12);
            this.txtComment.Name = "txtComment";
            this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComment.Size = new System.Drawing.Size(891, 82);
            this.txtComment.TabIndex = 0;
            this.txtComment.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dgvList);
            this.groupBox5.Location = new System.Drawing.Point(9, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1006, 145);
            this.groupBox5.TabIndex = 180;
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
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1000, 125);
            this.dgvList.TabIndex = 0;
            this.dgvList.Click += new System.EventHandler(this.dgvList_Click);
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
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Minimized = true;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOfficeEx;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1027, 27);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnSendReviewer
            // 
            this.btnSendReviewer.Image = ((System.Drawing.Image)(resources.GetObject("btnSendReviewer.Image")));
            this.btnSendReviewer.Location = new System.Drawing.Point(9, 33);
            this.btnSendReviewer.Name = "btnSendReviewer";
            this.btnSendReviewer.Size = new System.Drawing.Size(133, 29);
            this.btnSendReviewer.TabIndex = 184;
            this.btnSendReviewer.Text = "بازگشت به بازبینی";
            this.btnSendReviewer.Click += new System.EventHandler(this.btnSendReviewer_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.Location = new System.Drawing.Point(148, 33);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(133, 29);
            this.btnDownload.TabIndex = 186;
            this.btnDownload.Text = "دانلود فایل";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnReplaceVideo
            // 
            this.btnReplaceVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnReplaceVideo.Image")));
            this.btnReplaceVideo.Location = new System.Drawing.Point(287, 33);
            this.btnReplaceVideo.Name = "btnReplaceVideo";
            this.btnReplaceVideo.Size = new System.Drawing.Size(133, 29);
            this.btnReplaceVideo.TabIndex = 188;
            this.btnReplaceVideo.Text = "جایگزینی فایل";
            this.btnReplaceVideo.Click += new System.EventHandler(this.btnReplaceVideo_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(426, 33);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(133, 29);
            this.btnPlay.TabIndex = 190;
            this.btnPlay.Text = "پخش فایل";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Rejected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 571);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnReplaceVideo);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnSendReviewer);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rejected";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejected";
            this.Load += new System.EventHandler(this.Rejected_Load);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnReplyComment;
        private System.Windows.Forms.RichTextBox txtComment;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvList;
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
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReplyUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private DevExpress.XtraEditors.SimpleButton btnSendReviewer;
        private DevExpress.XtraEditors.SimpleButton btnDownload;
        private DevExpress.XtraEditors.SimpleButton btnReplaceVideo;
        private DevExpress.XtraEditors.SimpleButton btnPlay;
    }
}