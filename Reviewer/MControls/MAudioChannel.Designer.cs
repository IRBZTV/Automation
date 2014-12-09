namespace MControls
{
    partial class MAudioChannel
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
            this.checkBoxOn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxOn
            // 
            this.checkBoxOn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxOn.AutoSize = true;
            this.checkBoxOn.Checked = true;
            this.checkBoxOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOn.Location = new System.Drawing.Point(1, 286);
            this.checkBoxOn.Name = "checkBoxOn";
            this.checkBoxOn.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOn.TabIndex = 0;
            this.checkBoxOn.UseVisualStyleBackColor = true;
            this.checkBoxOn.Visible = false;
            this.checkBoxOn.CheckedChanged += new System.EventHandler(this.checkBoxOn_CheckedChanged);
            // 
            // MAudioChannel
            // 
            this.Controls.Add(this.checkBoxOn);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.Name = "MAudioChMeter";
            this.Size = new System.Drawing.Size(14, 300);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MAudioCh_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAudioCh_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MAudioCh_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOn;


    }
}
