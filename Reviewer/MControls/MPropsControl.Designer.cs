namespace MControls
{
    partial class MPropsControl
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
            this.comboBoxParent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNodeValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxShowNested = new System.Windows.Forms.CheckBox();
            this.listViewProps = new MControls.ListViewEx();
            this.SuspendLayout();
            // 
            // comboBoxParent
            // 
            this.comboBoxParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParent.FormattingEnabled = true;
            this.comboBoxParent.Location = new System.Drawing.Point(68, 0);
            this.comboBoxParent.Name = "comboBoxParent";
            this.comboBoxParent.Size = new System.Drawing.Size(179, 21);
            this.comboBoxParent.TabIndex = 2;
            this.comboBoxParent.SelectedIndexChanged += new System.EventHandler(this.comboBoxParent_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parent node:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxNodeValue
            // 
            this.textBoxNodeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNodeValue.Location = new System.Drawing.Point(68, 24);
            this.textBoxNodeValue.Multiline = true;
            this.textBoxNodeValue.Name = "textBoxNodeValue";
            this.textBoxNodeValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNodeValue.Size = new System.Drawing.Size(272, 39);
            this.textBoxNodeValue.TabIndex = 4;
            this.textBoxNodeValue.WordWrap = false;
            this.textBoxNodeValue.Leave += new System.EventHandler(this.textBoxNodeValue_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Node value:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxShowNested
            // 
            this.checkBoxShowNested.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowNested.AutoSize = true;
            this.checkBoxShowNested.Checked = true;
            this.checkBoxShowNested.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowNested.Location = new System.Drawing.Point(253, 4);
            this.checkBoxShowNested.Name = "checkBoxShowNested";
            this.checkBoxShowNested.Size = new System.Drawing.Size(90, 17);
            this.checkBoxShowNested.TabIndex = 6;
            this.checkBoxShowNested.Text = "Show Nested";
            this.checkBoxShowNested.UseVisualStyleBackColor = true;
            this.checkBoxShowNested.CheckedChanged += new System.EventHandler(this.checkBoxShowNested_CheckedChanged);
            // 
            // listViewProps
            // 
            this.listViewProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProps.FullRowSelect = true;
            this.listViewProps.GridLines = true;
            this.listViewProps.Location = new System.Drawing.Point(0, 66);
            this.listViewProps.Name = "listViewProps";
            this.listViewProps.Size = new System.Drawing.Size(340, 87);
            this.listViewProps.TabIndex = 0;
            this.listViewProps.UseCompatibleStateImageBehavior = false;
            this.listViewProps.View = System.Windows.Forms.View.Details;
            this.listViewProps.ListSubItemOnStartChange += new System.EventHandler(this.listViewProps_ListSubItemOnStartChange);
            this.listViewProps.Resize += new System.EventHandler(this.listViewProps_Resize);
            this.listViewProps.ListSubItemChanged += new System.EventHandler(this.listViewProps_ListSubItemChanged);
            // 
            // MPropsControl
            // 
            this.Controls.Add(this.listViewProps);
            this.Controls.Add(this.checkBoxShowNested);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNodeValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxParent);
            this.Name = "MPropsControl";
            this.Size = new System.Drawing.Size(340, 153);
            this.Load += new System.EventHandler(this.MPropsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListViewEx listViewProps;
        private System.Windows.Forms.ComboBox comboBoxParent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNodeValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxShowNested;

    }
}
