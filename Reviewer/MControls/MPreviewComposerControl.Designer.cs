namespace MControls
{
    partial class MPreviewComposerControl
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
			this.labelVisualEditElement = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// panelPreview
			// 
			this.panelPreview.Size = new System.Drawing.Size(643, 354);
			this.panelPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseMove);
			this.panelPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseDown);
			this.panelPreview.MouseHover += new System.EventHandler(this.panelPreview_MouseHover);
			this.panelPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPreview_MouseUp);
			// 
			// labelVisualEditElement
			// 
			this.labelVisualEditElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labelVisualEditElement.BackColor = System.Drawing.Color.Red;
			this.labelVisualEditElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelVisualEditElement.ForeColor = System.Drawing.Color.White;
			this.labelVisualEditElement.Location = new System.Drawing.Point(478, 332);
			this.labelVisualEditElement.Name = "labelVisualEditElement";
			this.labelVisualEditElement.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelVisualEditElement.Size = new System.Drawing.Size(161, 16);
			this.labelVisualEditElement.TabIndex = 66;
			this.labelVisualEditElement.Text = "    Visual edit:";
			this.labelVisualEditElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MPreviewComposerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelVisualEditElement);
			this.Name = "MPreviewComposerControl";
			this.Size = new System.Drawing.Size(644, 386);
			this.Controls.SetChildIndex(this.checkBoxAR, 0);
			this.Controls.SetChildIndex(this.checkBoxFullScreen, 0);
			this.Controls.SetChildIndex(this.panelPreview, 0);
			this.Controls.SetChildIndex(this.labelVisualEditElement, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label labelVisualEditElement;




	}
}
