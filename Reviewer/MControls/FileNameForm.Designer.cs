namespace MControls
{
    partial class FileNameForm
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
            this.mFileNameControl1 = new MControls.MFileNameControl();
            this.SuspendLayout();
            // 
            // mFileNameControl1
            // 
            this.mFileNameControl1.Location = new System.Drawing.Point(3, 5);
            this.mFileNameControl1.MaximumSize = new System.Drawing.Size(0, 73);
            this.mFileNameControl1.MinimumSize = new System.Drawing.Size(409, 73);
            this.mFileNameControl1.Name = "mFileNameControl1";
            this.mFileNameControl1.Size = new System.Drawing.Size(409, 73);
            this.mFileNameControl1.TabIndex = 0;
            // 
            // FileNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 82);
            this.Controls.Add(this.mFileNameControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileNameForm";
            this.Text = "FileName";
            this.Load += new System.EventHandler(this.FileNameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MFileNameControl mFileNameControl1;
    }
}