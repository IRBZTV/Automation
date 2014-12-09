namespace MControls
{
    partial class FormLive2
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
            this.mDeviceControl1 = new MControls.MDeviceControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.mFormatControlOut = new MControls.MFormatControl();
            this.label3 = new System.Windows.Forms.Label();
            this.mFormatControlIn = new MControls.MFormatControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mPreviewControl1 = new MControls.MPreviewControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDeviceControl1
            // 
            this.mDeviceControl1.FullRowSelect = true;
            this.mDeviceControl1.GridLines = true;
            this.mDeviceControl1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.mDeviceControl1.Location = new System.Drawing.Point(3, 20);
            this.mDeviceControl1.Name = "mDeviceControl1";
            this.mDeviceControl1.Size = new System.Drawing.Size(289, 72);
            this.mDeviceControl1.TabIndex = 0;
            this.mDeviceControl1.UseCompatibleStateImageBehavior = false;
            this.mDeviceControl1.View = System.Windows.Forms.View.Details;
            this.mDeviceControl1.MDeviceChanged += new System.EventHandler(this.mDeviceControl1_MDeviceChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonInit);
            this.panel1.Controls.Add(this.mFormatControlOut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.mFormatControlIn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mDeviceControl1);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 266);
            this.panel1.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(217, 233);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.Location = new System.Drawing.Point(136, 233);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(75, 23);
            this.buttonInit.TabIndex = 6;
            this.buttonInit.Text = "Init";
            this.buttonInit.UseVisualStyleBackColor = true;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // mFormatControlOut
            // 
            this.mFormatControlOut.Location = new System.Drawing.Point(6, 183);
            this.mFormatControlOut.MOriginalFormat = false;
            this.mFormatControlOut.MTextFormatDescription = true;
            this.mFormatControlOut.Name = "mFormatControlOut";
            this.mFormatControlOut.Size = new System.Drawing.Size(286, 44);
            this.mFormatControlOut.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output A/V Format";
            // 
            // mFormatControlLive
            // 
            this.mFormatControlIn.Location = new System.Drawing.Point(6, 111);
            this.mFormatControlIn.MOriginalFormat = true;
            this.mFormatControlIn.MTextFormatDescription = true;
            this.mFormatControlIn.Name = "mFormatControlLive";
            this.mFormatControlIn.Size = new System.Drawing.Size(286, 44);
            this.mFormatControlIn.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Device A/V Format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Device";
            // 
            // mPreviewControl1
            // 
            this.mPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mPreviewControl1.Location = new System.Drawing.Point(306, 5);
            this.mPreviewControl1.Name = "mPreviewControl1";
            this.mPreviewControl1.Size = new System.Drawing.Size(426, 275);
            this.mPreviewControl1.TabIndex = 2;
            // 
            // FormLive2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 285);
            this.Controls.Add(this.mPreviewControl1);
            this.Controls.Add(this.panel1);
            this.Name = "FormLive2";
            this.Text = "MLive Config";
            this.Load += new System.EventHandler(this.FormLive2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MDeviceControl mDeviceControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MPreviewControl mPreviewControl1;
        private System.Windows.Forms.Button buttonInit;
        private MFormatControl mFormatControlOut;
        private System.Windows.Forms.Label label3;
        private MFormatControl mFormatControlIn;
        private System.Windows.Forms.Button buttonClose;
    }
}