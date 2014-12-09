namespace FileIngest
{
    partial class VideoSender
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblConvertPercent = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblConvertSpeed = new System.Windows.Forms.Label();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lblSourceFile = new System.Windows.Forms.Label();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.lblDestinationFile = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblConvertPercent);
            this.groupControl1.Controls.Add(this.progressBar1);
            this.groupControl1.Location = new System.Drawing.Point(4, 102);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(296, 53);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Progross";
            // 
            // lblConvertPercent
            // 
            this.lblConvertPercent.AutoSize = true;
            this.lblConvertPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConvertPercent.ForeColor = System.Drawing.Color.Gray;
            this.lblConvertPercent.Location = new System.Drawing.Point(131, 28);
            this.lblConvertPercent.Name = "lblConvertPercent";
            this.lblConvertPercent.Size = new System.Drawing.Size(38, 13);
            this.lblConvertPercent.TabIndex = 1;
            this.lblConvertPercent.Text = "0.0 %";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(2, 21);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(292, 30);
            this.progressBar1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.richTextBox1);
            this.groupControl2.Location = new System.Drawing.Point(4, 159);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(439, 111);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Log";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.Location = new System.Drawing.Point(2, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(435, 88);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lblConvertSpeed);
            this.groupControl3.Location = new System.Drawing.Point(306, 102);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(135, 53);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Convert Speed";
            // 
            // lblConvertSpeed
            // 
            this.lblConvertSpeed.AutoSize = true;
            this.lblConvertSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblConvertSpeed.ForeColor = System.Drawing.Color.Green;
            this.lblConvertSpeed.Location = new System.Drawing.Point(42, 28);
            this.lblConvertSpeed.Name = "lblConvertSpeed";
            this.lblConvertSpeed.Size = new System.Drawing.Size(46, 17);
            this.lblConvertSpeed.TabIndex = 0;
            this.lblConvertSpeed.Text = "0.0 X";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.lblSourceFile);
            this.groupControl4.Location = new System.Drawing.Point(4, 6);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(437, 45);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "Source File:";
            // 
            // lblSourceFile
            // 
            this.lblSourceFile.AutoSize = true;
            this.lblSourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSourceFile.ForeColor = System.Drawing.Color.Navy;
            this.lblSourceFile.Location = new System.Drawing.Point(7, 26);
            this.lblSourceFile.Name = "lblSourceFile";
            this.lblSourceFile.Size = new System.Drawing.Size(47, 13);
            this.lblSourceFile.TabIndex = 1;
            this.lblSourceFile.Text = "Source";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.lblDestinationFile);
            this.groupControl5.Location = new System.Drawing.Point(4, 57);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(437, 39);
            this.groupControl5.TabIndex = 3;
            this.groupControl5.Text = "Destination File:";
            // 
            // lblDestinationFile
            // 
            this.lblDestinationFile.AutoSize = true;
            this.lblDestinationFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDestinationFile.ForeColor = System.Drawing.Color.Maroon;
            this.lblDestinationFile.Location = new System.Drawing.Point(5, 21);
            this.lblDestinationFile.Name = "lblDestinationFile";
            this.lblDestinationFile.Size = new System.Drawing.Size(95, 13);
            this.lblDestinationFile.TabIndex = 2;
            this.lblDestinationFile.Text = "Destination File";
            // 
            // VideoSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(446, 275);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoSender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoSender";
            this.Load += new System.EventHandler(this.VideoSender_Load);
            this.Shown += new System.EventHandler(this.VideoSender_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.Label lblConvertSpeed;
        private System.Windows.Forms.Label lblSourceFile;
        private System.Windows.Forms.Label lblDestinationFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblConvertPercent;
    }
}