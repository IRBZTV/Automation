namespace MControls
{
    partial class ListViewEx
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
            this.SuspendLayout();
            // 
            // ListViewEx
            // 
            this.FullRowSelect = true;
            this.GridLines = true;
            this.View = System.Windows.Forms.View.Details;
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewEx_MouseDoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewEx_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
