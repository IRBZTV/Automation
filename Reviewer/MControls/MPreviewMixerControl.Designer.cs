namespace MControls
{
    partial class MPreviewControlMixer
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
            this.checkBoxVisualEdit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panelPreview
            // 
            this.panelPreview.Size = new System.Drawing.Size(602, 354);
            
            // 
            // checkBoxVisualEdit
            // 
            this.checkBoxVisualEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxVisualEdit.AutoSize = true;
            this.checkBoxVisualEdit.Checked = true;
            this.checkBoxVisualEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVisualEdit.Location = new System.Drawing.Point(488, 363);
            this.checkBoxVisualEdit.Name = "checkBoxVisualEdit";
            this.checkBoxVisualEdit.Size = new System.Drawing.Size(109, 17);
            this.checkBoxVisualEdit.TabIndex = 65;
            this.checkBoxVisualEdit.Text = "Visual Scene Edit";
            this.checkBoxVisualEdit.UseVisualStyleBackColor = true;
            // 
            // MPreviewControlMixer
            // 
            this.Controls.Add(this.checkBoxVisualEdit);
            this.Name = "MPreviewControlMixer";
            this.Size = new System.Drawing.Size(603, 386);
            this.OnPreviewMouseDown += new System.EventHandler(this.MPreviewControlMixer_OnPreviewMouseDown);
            this.OnPreviewMouseMove += new System.EventHandler(this.MPreviewControlMixer_OnPreviewMouseMove);
            
            this.OnPreviewMouseUp += new System.EventHandler(this.MPreviewControlMixer_OnPreviewMouseUp);
            this.SizeChanged += new System.EventHandler(this.MPreviewControlMixer_SizeChanged);
            this.Controls.SetChildIndex(this.checkBoxAR, 0);
            this.Controls.SetChildIndex(this.checkBoxVisualEdit, 0);
            this.Controls.SetChildIndex(this.panelPreview, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxVisualEdit;

    }
}
