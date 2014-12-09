namespace MControls
{
    partial class FormLive
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
            this.mPreviewControl1 = new MControls.MPreviewControl();
            this.mLiveControl1 = new MControls.MLiveControl();
            this.SuspendLayout();
            // 
            // mPreviewControl1
            // 
            this.mPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mPreviewControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mPreviewControl1.Location = new System.Drawing.Point(374, 6);
            this.mPreviewControl1.Name = "mPreviewControl1";
            this.mPreviewControl1.Size = new System.Drawing.Size(486, 404);
            this.mPreviewControl1.TabIndex = 1;
            // 
            // mLiveControl1
            // 
            this.mLiveControl1.Location = new System.Drawing.Point(3, 3);
            this.mLiveControl1.Name = "mLiveControl1";
            this.mLiveControl1.Size = new System.Drawing.Size(367, 404);
            this.mLiveControl1.TabIndex = 0;
            // 
            // FormLive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 408);
            this.Controls.Add(this.mPreviewControl1);
            this.Controls.Add(this.mLiveControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormLive";
            this.Text = "MLive Config";
            this.Load += new System.EventHandler(this.FormLive_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLive_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MLiveControl mLiveControl1;
        private MPreviewControl mPreviewControl1;
    }
}