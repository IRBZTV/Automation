namespace MControls
{
    partial class FormInputElementContent
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxDemo = new System.Windows.Forms.CheckBox();
            this.panelCellFace = new System.Windows.Forms.Panel();
            this.numeric1 = new System.Windows.Forms.NumericUpDown();
            this.labelName = new System.Windows.Forms.Label();
            this.numeric2 = new System.Windows.Forms.NumericUpDown();
            this.numeric3 = new System.Windows.Forms.NumericUpDown();
            this.panelCellFace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(8, 29);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(797, 289);
            this.textBox.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(649, 324);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(730, 324);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Content";
            // 
            // checkBoxDemo
            // 
            this.checkBoxDemo.AutoSize = true;
            this.checkBoxDemo.Checked = true;
            this.checkBoxDemo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDemo.Location = new System.Drawing.Point(67, 5);
            this.checkBoxDemo.Name = "checkBoxDemo";
            this.checkBoxDemo.Size = new System.Drawing.Size(57, 17);
            this.checkBoxDemo.TabIndex = 11;
            this.checkBoxDemo.Text = "Demo ";
            this.checkBoxDemo.UseVisualStyleBackColor = true;
            this.checkBoxDemo.CheckedChanged += new System.EventHandler(this.checkBoxDemo_CheckedChanged);
            // 
            // panelCellFace
            // 
            this.panelCellFace.Controls.Add(this.numeric3);
            this.panelCellFace.Controls.Add(this.numeric2);
            this.panelCellFace.Controls.Add(this.numeric1);
            this.panelCellFace.Controls.Add(this.labelName);
            this.panelCellFace.Location = new System.Drawing.Point(136, 1);
            this.panelCellFace.Name = "panelCellFace";
            this.panelCellFace.Size = new System.Drawing.Size(169, 25);
            this.panelCellFace.TabIndex = 13;
            this.panelCellFace.Visible = false;
            // 
            // numeric1
            // 
            this.numeric1.Location = new System.Drawing.Point(37, 2);
            this.numeric1.Name = "numeric1";
            this.numeric1.Size = new System.Drawing.Size(38, 20);
            this.numeric1.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(23, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "cell";
            // 
            // numeric2
            // 
            this.numeric2.Location = new System.Drawing.Point(81, 3);
            this.numeric2.Name = "numeric2";
            this.numeric2.Size = new System.Drawing.Size(38, 20);
            this.numeric2.TabIndex = 2;
            // 
            // numeric3
            // 
            this.numeric3.Location = new System.Drawing.Point(125, 2);
            this.numeric3.Name = "numeric3";
            this.numeric3.Size = new System.Drawing.Size(38, 20);
            this.numeric3.TabIndex = 3;
            // 
            // FormInputElementContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 353);
            this.Controls.Add(this.panelCellFace);
            this.Controls.Add(this.checkBoxDemo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBox);
            this.Name = "FormInputElementContent";
            this.ShowIcon = false;
            this.Text = "Input content";
            this.Load += new System.EventHandler(this.FormInputElementContent_Load);
            this.panelCellFace.ResumeLayout(false);
            this.panelCellFace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxDemo;
        private System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Panel panelCellFace;
        public System.Windows.Forms.NumericUpDown numeric3;
        public System.Windows.Forms.NumericUpDown numeric2;
        public System.Windows.Forms.NumericUpDown numeric1;
    }
}