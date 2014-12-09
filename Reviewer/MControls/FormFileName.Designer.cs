namespace MControls
{
    partial class FormFileName
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mFileNameControl1 = new MControls.MFileName();
            this.mPropsControl1 = new MControls.MPropsControl();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Path:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.label1.Location = new System.Drawing.Point(5, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "File Properties:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mFileNameControl1
            // 
            this.mFileNameControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mFileNameControl1.Location = new System.Drawing.Point(5, 26);
            this.mFileNameControl1.Name = "mFileNameControl1";
            this.mFileNameControl1.Size = new System.Drawing.Size(409, 87);
            this.mFileNameControl1.TabIndex = 2;
            // 
            // mPropsControl1
            // 
            this.mPropsControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mPropsControl1.Columns = 2;
            this.mPropsControl1.Location = new System.Drawing.Point(5, 136);
            this.mPropsControl1.Name = "mPropsControl1";
            this.mPropsControl1.Simple = false;
            this.mPropsControl1.Size = new System.Drawing.Size(409, 277);
            this.mPropsControl1.TabIndex = 1;
            // 
            // FormFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mFileNameControl1);
            this.Controls.Add(this.mPropsControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFileName";
            this.Text = "MFile Config";
            this.Load += new System.EventHandler(this.FileNameForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFileName_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MPropsControl mPropsControl1;
        private MFileName mFileNameControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}