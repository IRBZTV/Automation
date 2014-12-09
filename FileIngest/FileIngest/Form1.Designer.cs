namespace FileIngest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbProgramKinds = new System.Windows.Forms.ComboBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtSessionNumber = new System.Windows.Forms.TextBox();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cmbPrograms = new System.Windows.Forms.ComboBox();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lblVideoFileDuration = new System.Windows.Forms.Label();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.txtDescProg = new System.Windows.Forms.RichTextBox();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSendFile = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPlayVideoFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnChooseFile = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearForm = new DevExpress.XtraBars.BarButtonItem();
            this.btnListReviewRejected = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.txtDescAdver = new System.Windows.Forms.RichTextBox();
            this.ofdImportFile = new System.Windows.Forms.OpenFileDialog();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.lblFileVideoPath = new System.Windows.Forms.Label();
            this.tmrCheckReviewRejected = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbProgramKinds);
            this.groupControl1.Location = new System.Drawing.Point(511, 203);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(165, 72);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "نوع برنامه";
            // 
            // cmbProgramKinds
            // 
            this.cmbProgramKinds.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.cmbProgramKinds.FormattingEnabled = true;
            this.cmbProgramKinds.Location = new System.Drawing.Point(5, 32);
            this.cmbProgramKinds.Name = "cmbProgramKinds";
            this.cmbProgramKinds.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbProgramKinds.Size = new System.Drawing.Size(155, 32);
            this.cmbProgramKinds.TabIndex = 0;
            this.cmbProgramKinds.SelectedIndexChanged += new System.EventHandler(this.cmbProgramKinds_SelectedIndexChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtSessionNumber);
            this.groupControl2.Location = new System.Drawing.Point(123, 203);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(100, 72);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "قسمت";
            // 
            // txtSessionNumber
            // 
            this.txtSessionNumber.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.txtSessionNumber.Location = new System.Drawing.Point(5, 32);
            this.txtSessionNumber.Name = "txtSessionNumber";
            this.txtSessionNumber.Size = new System.Drawing.Size(90, 31);
            this.txtSessionNumber.TabIndex = 0;
            this.txtSessionNumber.Text = "0";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cmbPrograms);
            this.groupControl3.Location = new System.Drawing.Point(229, 203);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(276, 72);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "برنامه";
            // 
            // cmbPrograms
            // 
            this.cmbPrograms.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.cmbPrograms.FormattingEnabled = true;
            this.cmbPrograms.Location = new System.Drawing.Point(5, 32);
            this.cmbPrograms.Name = "cmbPrograms";
            this.cmbPrograms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbPrograms.Size = new System.Drawing.Size(266, 32);
            this.cmbPrograms.TabIndex = 1;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Controls";
            // 
            // groupControl4
            // 
            this.groupControl4.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl4.Controls.Add(this.lblVideoFileDuration);
            this.groupControl4.Location = new System.Drawing.Point(10, 203);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(107, 72);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "مدت ";
            // 
            // lblVideoFileDuration
            // 
            this.lblVideoFileDuration.AutoSize = true;
            this.lblVideoFileDuration.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.lblVideoFileDuration.ForeColor = System.Drawing.Color.Green;
            this.lblVideoFileDuration.Location = new System.Drawing.Point(5, 30);
            this.lblVideoFileDuration.Name = "lblVideoFileDuration";
            this.lblVideoFileDuration.Size = new System.Drawing.Size(54, 26);
            this.lblVideoFileDuration.TabIndex = 0;
            this.lblVideoFileDuration.Text = "00:00:00";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.txtDescProg);
            this.groupControl5.Location = new System.Drawing.Point(10, 347);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(666, 141);
            this.groupControl5.TabIndex = 3;
            this.groupControl5.Text = "توضیحات  برنامه";
            // 
            // txtDescProg
            // 
            this.txtDescProg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescProg.Location = new System.Drawing.Point(2, 21);
            this.txtDescProg.Name = "txtDescProg";
            this.txtDescProg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescProg.Size = new System.Drawing.Size(662, 118);
            this.txtDescProg.TabIndex = 0;
            this.txtDescProg.Text = "";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSendFile,
            this.barButtonItem1,
            this.btnPlayVideoFile,
            this.btnChooseFile,
            this.btnClearForm,
            this.btnListReviewRejected});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(683, 123);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Caption = "ارسال فایل";
            this.btnSendFile.Glyph = global::FileIngest.Properties.Resources.apply_32x32;
            this.btnSendFile.Id = 9;
            this.btnSendFile.LargeWidth = 100;
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSendFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSendFile_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "لیست قسمت ها";
            this.barButtonItem1.Glyph = global::FileIngest.Properties.Resources.contentarrangeinrows_32x32;
            this.barButtonItem1.Id = 11;
            this.barButtonItem1.LargeWidth = 100;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnPlayVideoFile
            // 
            this.btnPlayVideoFile.Caption = "پخش فایل";
            this.btnPlayVideoFile.Glyph = global::FileIngest.Properties.Resources.next_32x32;
            this.btnPlayVideoFile.Id = 12;
            this.btnPlayVideoFile.LargeWidth = 100;
            this.btnPlayVideoFile.Name = "btnPlayVideoFile";
            this.btnPlayVideoFile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPlayVideoFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPlayVideoFile_ItemClick);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Caption = "انتخاب فایل";
            this.btnChooseFile.Glyph = global::FileIngest.Properties.Resources.add_32x32;
            this.btnChooseFile.Id = 13;
            this.btnChooseFile.LargeWidth = 100;
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnChooseFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChooseFile_ItemClick);
            // 
            // btnClearForm
            // 
            this.btnClearForm.Caption = "پاکسازی فرم";
            this.btnClearForm.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClearForm.Glyph")));
            this.btnClearForm.Id = 14;
            this.btnClearForm.LargeWidth = 100;
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnClearForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearForm_ItemClick);
            // 
            // btnListReviewRejected
            // 
            this.btnListReviewRejected.Caption = "0";
            this.btnListReviewRejected.Glyph = ((System.Drawing.Image)(resources.GetObject("btnListReviewRejected.Glyph")));
            this.btnListReviewRejected.Id = 15;
            this.btnListReviewRejected.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnListReviewRejected.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            this.btnListReviewRejected.ItemAppearance.Normal.Options.UseFont = true;
            this.btnListReviewRejected.ItemAppearance.Normal.Options.UseForeColor = true;
            this.btnListReviewRejected.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnListReviewRejected.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnListReviewRejected.LargeWidth = 150;
            this.btnListReviewRejected.Name = "btnListReviewRejected";
            this.btnListReviewRejected.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnListReviewRejected.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListReviewRejected_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ribbonPage2.Appearance.Options.UseBackColor = true;
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "عملیات";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSendFile);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPlayVideoFile);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChooseFile);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnClearForm);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "فایل";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnListReviewRejected);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ویدئو برگشتی از بازبینی";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "ارسال فایل";
            this.barButtonItem2.Glyph = global::FileIngest.Properties.Resources._11111warning;
            this.barButtonItem2.Id = 5;
            this.barButtonItem2.LargeWidth = 100;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "ارسال فایل";
            this.barButtonItem4.Glyph = global::FileIngest.Properties.Resources.apply_32x32;
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "ارسال فایل";
            this.barButtonItem5.Glyph = global::FileIngest.Properties.Resources.apply_32x32;
            this.barButtonItem5.Id = 9;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.txtTitle);
            this.groupControl6.Location = new System.Drawing.Point(10, 281);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(666, 60);
            this.groupControl6.TabIndex = 3;
            this.groupControl6.Text = "عنوان";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.txtTitle.Location = new System.Drawing.Point(5, 24);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.Size = new System.Drawing.Size(654, 31);
            this.txtTitle.TabIndex = 0;
            // 
            // groupControl7
            // 
            this.groupControl7.Controls.Add(this.txtDescAdver);
            this.groupControl7.Location = new System.Drawing.Point(10, 494);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(664, 119);
            this.groupControl7.TabIndex = 4;
            this.groupControl7.Text = "توضیحات بازرگانی";
            // 
            // txtDescAdver
            // 
            this.txtDescAdver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescAdver.Location = new System.Drawing.Point(2, 21);
            this.txtDescAdver.Name = "txtDescAdver";
            this.txtDescAdver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescAdver.Size = new System.Drawing.Size(660, 96);
            this.txtDescAdver.TabIndex = 0;
            this.txtDescAdver.Text = "";
            // 
            // ofdImportFile
            // 
            this.ofdImportFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdImportFile_FileOk);
            // 
            // groupControl8
            // 
            this.groupControl8.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl8.Controls.Add(this.lblFileVideoPath);
            this.groupControl8.Location = new System.Drawing.Point(10, 129);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(666, 68);
            this.groupControl8.TabIndex = 4;
            this.groupControl8.Text = "فایل انتخاب شده";
            // 
            // lblFileVideoPath
            // 
            this.lblFileVideoPath.AutoSize = true;
            this.lblFileVideoPath.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblFileVideoPath.Location = new System.Drawing.Point(7, 37);
            this.lblFileVideoPath.Name = "lblFileVideoPath";
            this.lblFileVideoPath.Size = new System.Drawing.Size(57, 16);
            this.lblFileVideoPath.TabIndex = 0;
            this.lblFileVideoPath.Text = "No File";
            // 
            // tmrCheckReviewRejected
            // 
            this.tmrCheckReviewRejected.Enabled = true;
            this.tmrCheckReviewRejected.Interval = 5000;
            this.tmrCheckReviewRejected.Tick += new System.EventHandler(this.tmrCheckReviewRejected_Tick);
            // 
            // Form1
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 616);
            this.Controls.Add(this.groupControl8);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.groupControl6);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TFile Ingest V1.0 2014-08-20";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            this.groupControl8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.ComboBox cmbProgramKinds;
        private System.Windows.Forms.ComboBox cmbPrograms;
        private System.Windows.Forms.TextBox txtSessionNumber;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.Label lblVideoFileDuration;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.RichTextBox txtDescProg;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.BarButtonItem btnSendFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnPlayVideoFile;
        private DevExpress.XtraBars.BarButtonItem btnChooseFile;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.TextBox txtTitle;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private System.Windows.Forms.RichTextBox txtDescAdver;
        private System.Windows.Forms.OpenFileDialog ofdImportFile;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private System.Windows.Forms.Label lblFileVideoPath;
        private DevExpress.XtraBars.BarButtonItem btnClearForm;
        private DevExpress.XtraBars.BarButtonItem btnListReviewRejected;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.Timer tmrCheckReviewRejected;
    }
}

