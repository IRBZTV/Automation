namespace MControls
{
    partial class FormAttributes
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
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            this.mAttributesList1 = new MControls.MAttributesList();
            this.SuspendLayout();
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHelp.ForeColor = System.Drawing.Color.Black;
            this.textBoxHelp.Location = new System.Drawing.Point(0, 350);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.ReadOnly = true;
            this.textBoxHelp.Size = new System.Drawing.Size(284, 94);
            this.textBoxHelp.TabIndex = 1;
            // 
            // mAttributesList1
            // 
            this.mAttributesList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mAttributesList1.FixedItems = false;
            this.mAttributesList1.FullRowSelect = true;
            this.mAttributesList1.GridLines = true;
            this.mAttributesList1.Location = new System.Drawing.Point(0, 0);
            this.mAttributesList1.Name = "mAttributesList1";
            this.mAttributesList1.Size = new System.Drawing.Size(284, 344);
            this.mAttributesList1.TabIndex = 0;
            this.mAttributesList1.TimeForChange = 2;
            this.mAttributesList1.UseCompatibleStateImageBehavior = false;
            this.mAttributesList1.View = System.Windows.Forms.View.Details;
            this.mAttributesList1.SelectedIndexChanged += new System.EventHandler(this.mAttributesList1_SelectedIndexChanged);
            // 
            // FormAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 444);
            this.Controls.Add(this.textBoxHelp);
            this.Controls.Add(this.mAttributesList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormAttributes";
            this.Text = "FormAttributes";
            this.Load += new System.EventHandler(this.FormAttributes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MAttributesList mAttributesList1;
        private System.Windows.Forms.TextBox textBoxHelp;
    }
}