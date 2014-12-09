namespace MControls
{
	partial class MNumericSlider
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
			this.LabelCaption = new System.Windows.Forms.Label();
			this.trackBar = new System.Windows.Forms.TrackBar();
			this.numericUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// LabelCaption
			// 
			this.LabelCaption.Location = new System.Drawing.Point(4, 5);
			this.LabelCaption.Name = "LabelCaption";
			this.LabelCaption.Size = new System.Drawing.Size(86, 13);
			this.LabelCaption.TabIndex = 0;
			this.LabelCaption.Text = "Name";
			this.LabelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// trackBar
			// 
			this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar.AutoSize = false;
			this.trackBar.Location = new System.Drawing.Point(84, 3);
			this.trackBar.Maximum = 100;
			this.trackBar.Name = "trackBar";
			this.trackBar.Size = new System.Drawing.Size(250, 26);
			this.trackBar.TabIndex = 1;
			this.trackBar.TickFrequency = 2;
			this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
			// 
			// numericUpDown
			// 
			this.numericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown.DecimalPlaces = 2;
			this.numericUpDown.Location = new System.Drawing.Point(340, 6);
			this.numericUpDown.Name = "numericUpDown";
			this.numericUpDown.Size = new System.Drawing.Size(45, 20);
			this.numericUpDown.TabIndex = 2;
			this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
			// 
			// MNumericSlider
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.numericUpDown);
			this.Controls.Add(this.trackBar);
			this.Controls.Add(this.LabelCaption);
			this.Name = "MNumericSlider";
			this.Size = new System.Drawing.Size(388, 38);
			((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label LabelCaption;
		private System.Windows.Forms.TrackBar trackBar;
		private System.Windows.Forms.NumericUpDown numericUpDown;
	}
}
