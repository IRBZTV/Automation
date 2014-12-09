namespace MControls
{
    partial class MFileNameControl
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
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.buttonSetInOut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericOut = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericIn = new System.Windows.Forms.NumericUpDown();
            this.buttonSetName = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonBreak = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.numericLen = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProps = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLen)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Location = new System.Drawing.Point(0, 0);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(381, 20);
            this.textBoxPath.TabIndex = 75;
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLoop.Location = new System.Drawing.Point(1, 68);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size(50, 17);
            this.checkBoxLoop.TabIndex = 83;
            this.checkBoxLoop.Text = "Loop";
            this.checkBoxLoop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            this.checkBoxLoop.CheckedChanged += new System.EventHandler(this.checkBoxLoop_CheckedChanged);
            // 
            // buttonSetInOut
            // 
            this.buttonSetInOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetInOut.Location = new System.Drawing.Point(325, 65);
            this.buttonSetInOut.Name = "buttonSetInOut";
            this.buttonSetInOut.Size = new System.Drawing.Size(85, 21);
            this.buttonSetInOut.TabIndex = 82;
            this.buttonSetInOut.Text = "Set In/Out";
            this.buttonSetInOut.UseVisualStyleBackColor = true;
            this.buttonSetInOut.Click += new System.EventHandler(this.buttonSetInOut_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Out:";
            // 
            // numericOut
            // 
            this.numericOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericOut.DecimalPlaces = 2;
            this.numericOut.Location = new System.Drawing.Point(174, 66);
            this.numericOut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericOut.Name = "numericOut";
            this.numericOut.Size = new System.Drawing.Size(58, 20);
            this.numericOut.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "In:";
            // 
            // numericIn
            // 
            this.numericIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericIn.DecimalPlaces = 2;
            this.numericIn.Location = new System.Drawing.Point(84, 66);
            this.numericIn.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericIn.Name = "numericIn";
            this.numericIn.Size = new System.Drawing.Size(59, 20);
            this.numericIn.TabIndex = 78;
            // 
            // buttonSetName
            // 
            this.buttonSetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetName.Location = new System.Drawing.Point(58, 42);
            this.buttonSetName.Name = "buttonSetName";
            this.buttonSetName.Size = new System.Drawing.Size(85, 21);
            this.buttonSetName.TabIndex = 77;
            this.buttonSetName.Text = "Change";
            this.buttonSetName.UseVisualStyleBackColor = true;
            this.buttonSetName.Click += new System.EventHandler(this.buttonSetName_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(383, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(27, 20);
            this.buttonBrowse.TabIndex = 76;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonBreak
            // 
            this.buttonBreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBreak.Location = new System.Drawing.Point(147, 42);
            this.buttonBreak.Name = "buttonBreak";
            this.buttonBreak.Size = new System.Drawing.Size(85, 21);
            this.buttonBreak.TabIndex = 86;
            this.buttonBreak.Text = "Break";
            this.buttonBreak.UseVisualStyleBackColor = true;
            this.buttonBreak.Click += new System.EventHandler(this.buttonBreak_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(236, 42);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(85, 21);
            this.buttonNext.TabIndex = 87;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonReplace
            // 
            this.buttonReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReplace.Location = new System.Drawing.Point(325, 42);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(85, 21);
            this.buttonReplace.TabIndex = 88;
            this.buttonReplace.Text = "Replace";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // numericLen
            // 
            this.numericLen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericLen.DecimalPlaces = 2;
            this.numericLen.Enabled = false;
            this.numericLen.Location = new System.Drawing.Point(262, 66);
            this.numericLen.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericLen.Name = "numericLen";
            this.numericLen.ReadOnly = true;
            this.numericLen.Size = new System.Drawing.Size(59, 20);
            this.numericLen.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "Len:";
            // 
            // textBoxProps
            // 
            this.textBoxProps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProps.ForeColor = System.Drawing.Color.DarkGray;
            this.textBoxProps.Location = new System.Drawing.Point(0, 21);
            this.textBoxProps.Name = "textBoxProps";
            this.textBoxProps.Size = new System.Drawing.Size(408, 20);
            this.textBoxProps.TabIndex = 91;
            this.textBoxProps.Text = "<new file properties here>";
            this.textBoxProps.Leave += new System.EventHandler(this.textBoxProps_Leave);
            this.textBoxProps.Enter += new System.EventHandler(this.textBoxProps_Enter);
            // 
            // MFileNameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxProps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericLen);
            this.Controls.Add(this.numericIn);
            this.Controls.Add(this.numericOut);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBreak);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.checkBoxLoop);
            this.Controls.Add(this.buttonSetInOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSetName);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "MFileNameControl";
            this.Size = new System.Drawing.Size(410, 87);
            ((System.ComponentModel.ISupportInitialize)(this.numericOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.Button buttonSetInOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericIn;
        private System.Windows.Forms.Button buttonSetName;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonBreak;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.NumericUpDown numericLen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProps;

    }
}
