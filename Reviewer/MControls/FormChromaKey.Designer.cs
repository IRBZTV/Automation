namespace MControls
{
	partial class FormChromaKey
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
			this.mChromaKey1 = new MControls.MChromaKeyControl();
			this.SuspendLayout();
			// 
			// mChromaKey1
			// 
			this.mChromaKey1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mChromaKey1.Location = new System.Drawing.Point(0, 0);
			this.mChromaKey1.Margin = new System.Windows.Forms.Padding(0);
			this.mChromaKey1.Name = "mChromaKey1";
			this.mChromaKey1.Size = new System.Drawing.Size(1184, 688);
			this.mChromaKey1.TabIndex = 0;
			
			// 
			// FormChromaKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 688);
			this.Controls.Add(this.mChromaKey1);
			this.Name = "FormChromaKey";
			this.Text = "FormChromaKey";
			this.Load += new System.EventHandler(this.FormChromaKey_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private MChromaKeyControl mChromaKey1;
	}
}