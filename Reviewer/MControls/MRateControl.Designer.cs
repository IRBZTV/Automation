namespace MControls
{
    partial class MRateControl
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
            this.buttonRev05 = new System.Windows.Forms.Button();
            this.buttonRev2 = new System.Windows.Forms.Button();
            this.buttonFwd05 = new System.Windows.Forms.Button();
            this.buttonFwd20 = new System.Windows.Forms.Button();
            this.buttonRev = new System.Windows.Forms.Button();
            this.buttonFwd = new System.Windows.Forms.Button();
            this.trackBarRate = new System.Windows.Forms.TrackBar();
            this.buttonFwd10 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelRate = new System.Windows.Forms.Label();
            this.buttonRev10 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRev05
            // 
            this.buttonRev05.Location = new System.Drawing.Point(176, 54);
            this.buttonRev05.Name = "buttonRev05";
            this.buttonRev05.Size = new System.Drawing.Size(51, 23);
            this.buttonRev05.TabIndex = 31;
            this.buttonRev05.Text = "x -0.5";
            this.buttonRev05.UseVisualStyleBackColor = true;
            this.buttonRev05.Click += new System.EventHandler(this.buttonRev05_Click);
            // 
            // buttonRev2
            // 
            this.buttonRev2.Location = new System.Drawing.Point(68, 54);
            this.buttonRev2.Name = "buttonRev2";
            this.buttonRev2.Size = new System.Drawing.Size(51, 23);
            this.buttonRev2.TabIndex = 30;
            this.buttonRev2.Text = "x -2.0";
            this.buttonRev2.UseVisualStyleBackColor = true;
            this.buttonRev2.Click += new System.EventHandler(this.buttonRev2_Click);
            // 
            // buttonFwd05
            // 
            this.buttonFwd05.Location = new System.Drawing.Point(248, 54);
            this.buttonFwd05.Name = "buttonFwd05";
            this.buttonFwd05.Size = new System.Drawing.Size(51, 23);
            this.buttonFwd05.TabIndex = 29;
            this.buttonFwd05.Text = "x 0.5";
            this.buttonFwd05.UseVisualStyleBackColor = true;
            this.buttonFwd05.Click += new System.EventHandler(this.buttonFwd05_Click);
            // 
            // buttonFwd20
            // 
            this.buttonFwd20.Location = new System.Drawing.Point(358, 54);
            this.buttonFwd20.Name = "buttonFwd20";
            this.buttonFwd20.Size = new System.Drawing.Size(51, 23);
            this.buttonFwd20.TabIndex = 28;
            this.buttonFwd20.Text = "x 2.0";
            this.buttonFwd20.UseVisualStyleBackColor = true;
            this.buttonFwd20.Click += new System.EventHandler(this.buttonFwd20_Click);
            // 
            // buttonRev
            // 
            this.buttonRev.Location = new System.Drawing.Point(122, 54);
            this.buttonRev.Name = "buttonRev";
            this.buttonRev.Size = new System.Drawing.Size(51, 23);
            this.buttonRev.TabIndex = 27;
            this.buttonRev.Text = "x -1.0";
            this.buttonRev.UseVisualStyleBackColor = true;
            this.buttonRev.Click += new System.EventHandler(this.buttonRev_Click);
            // 
            // buttonFwd
            // 
            this.buttonFwd.Location = new System.Drawing.Point(303, 54);
            this.buttonFwd.Name = "buttonFwd";
            this.buttonFwd.Size = new System.Drawing.Size(51, 23);
            this.buttonFwd.TabIndex = 26;
            this.buttonFwd.Text = "x 1.0";
            this.buttonFwd.UseVisualStyleBackColor = true;
            this.buttonFwd.Click += new System.EventHandler(this.buttonFwd_Click);
            // 
            // trackBarRate
            // 
            this.trackBarRate.Location = new System.Drawing.Point(1, 3);
            this.trackBarRate.Maximum = 500;
            this.trackBarRate.Minimum = -500;
            this.trackBarRate.Name = "trackBarRate";
            this.trackBarRate.Size = new System.Drawing.Size(471, 45);
            this.trackBarRate.SmallChange = 10;
            this.trackBarRate.TabIndex = 25;
            this.trackBarRate.TickFrequency = 50;
            this.trackBarRate.Value = 100;
            this.trackBarRate.Scroll += new System.EventHandler(this.trackBarRate_Scroll);
            this.trackBarRate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarRate_MouseDown);
            // 
            // buttonFwd10
            // 
            this.buttonFwd10.Location = new System.Drawing.Point(413, 54);
            this.buttonFwd10.Name = "buttonFwd10";
            this.buttonFwd10.Size = new System.Drawing.Size(51, 23);
            this.buttonFwd10.TabIndex = 32;
            this.buttonFwd10.Text = "x 10.0";
            this.buttonFwd10.UseVisualStyleBackColor = true;
            this.buttonFwd10.Click += new System.EventHandler(this.buttonFwd10_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 15);
            this.label4.TabIndex = 90;
            this.label4.Text = "REW";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRate
            // 
            this.labelRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.labelRate.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRate.ForeColor = System.Drawing.Color.White;
            this.labelRate.Location = new System.Drawing.Point(191, 35);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(93, 15);
            this.labelRate.TabIndex = 89;
            this.labelRate.Text = "100%";
            this.labelRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRev10
            // 
            this.buttonRev10.Location = new System.Drawing.Point(14, 54);
            this.buttonRev10.Name = "buttonRev10";
            this.buttonRev10.Size = new System.Drawing.Size(51, 23);
            this.buttonRev10.TabIndex = 91;
            this.buttonRev10.Text = "x -10.0";
            this.buttonRev10.UseVisualStyleBackColor = true;
            this.buttonRev10.Click += new System.EventHandler(this.buttonRev10_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(284, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 92;
            this.label2.Text = "FWD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MRateControl
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRev10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.buttonFwd10);
            this.Controls.Add(this.buttonRev05);
            this.Controls.Add(this.buttonRev2);
            this.Controls.Add(this.buttonFwd05);
            this.Controls.Add(this.buttonFwd20);
            this.Controls.Add(this.buttonRev);
            this.Controls.Add(this.buttonFwd);
            this.Controls.Add(this.trackBarRate);
            this.Name = "MRateControl";
            this.Size = new System.Drawing.Size(472, 76);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRev05;
        private System.Windows.Forms.Button buttonRev2;
        private System.Windows.Forms.Button buttonFwd05;
        private System.Windows.Forms.Button buttonFwd20;
        private System.Windows.Forms.Button buttonRev;
        private System.Windows.Forms.Button buttonFwd;
        private System.Windows.Forms.TrackBar trackBarRate;
        private System.Windows.Forms.Button buttonFwd10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.Button buttonRev10;
        private System.Windows.Forms.Label label2;
    }
}
