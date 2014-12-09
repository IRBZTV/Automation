namespace MControls
{
    partial class MFileControl
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
            this.components = new System.ComponentModel.Container();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.numericRew = new System.Windows.Forms.NumericUpDown();
            this.labelState = new System.Windows.Forms.Label();
            this.timerState = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericRew)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(0, 0);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(72, 21);
            this.buttonPlay.TabIndex = 96;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(146, 0);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(72, 21);
            this.buttonStop.TabIndex = 95;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonRewind
            // 
            this.buttonRewind.Location = new System.Drawing.Point(219, 0);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(72, 21);
            this.buttonRewind.TabIndex = 94;
            this.buttonRewind.Text = "Rewind To";
            this.buttonRewind.UseVisualStyleBackColor = true;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(73, 0);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(72, 21);
            this.buttonPause.TabIndex = 93;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // numericRew
            // 
            this.numericRew.DecimalPlaces = 2;
            this.numericRew.Location = new System.Drawing.Point(293, 1);
            this.numericRew.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericRew.Name = "numericRew";
            this.numericRew.Size = new System.Drawing.Size(59, 20);
            this.numericRew.TabIndex = 91;
            // 
            // labelState
            // 
            this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.labelState.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.ForeColor = System.Drawing.Color.White;
            this.labelState.Location = new System.Drawing.Point(355, 3);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(86, 15);
            this.labelState.TabIndex = 97;
            this.labelState.Text = "eMS_Stopped";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerState
            // 
            this.timerState.Enabled = true;
            this.timerState.Tick += new System.EventHandler(this.timerState_Tick);
            // 
            // MFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonRewind);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.numericRew);
            this.Name = "MFileControl";
            this.Size = new System.Drawing.Size(443, 21);
            ((System.ComponentModel.ISupportInitialize)(this.numericRew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.NumericUpDown numericRew;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Timer timerState;
    }
}
