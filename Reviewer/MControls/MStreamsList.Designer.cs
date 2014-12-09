namespace MControls
{
    partial class MStreamsList
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
            this.buttonAddList = new System.Windows.Forms.Button();
            this.buttonAddLive = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.numericChangeTime = new System.Windows.Forms.NumericUpDown();
            this.labelSec = new System.Windows.Forms.Label();
            this.trackBarTrans = new System.Windows.Forms.TrackBar();
            this.listViewFiles = new MControls.ListViewEx();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.columnFile = new System.Windows.Forms.ColumnHeader();
            this.columnIn = new System.Windows.Forms.ColumnHeader();
            this.columnOut = new System.Windows.Forms.ColumnHeader();
            this.columnLen = new System.Windows.Forms.ColumnHeader();
            this.columnMedia = new System.Windows.Forms.ColumnHeader();
            this.columnPath = new System.Windows.Forms.ColumnHeader();
            this.buttonAddURL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericChangeTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrans)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddList
            // 
            this.buttonAddList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddList.Location = new System.Drawing.Point(57, 213);
            this.buttonAddList.Name = "buttonAddList";
            this.buttonAddList.Size = new System.Drawing.Size(56, 21);
            this.buttonAddList.TabIndex = 125;
            this.buttonAddList.Text = "Add List";
            this.buttonAddList.UseVisualStyleBackColor = true;
            this.buttonAddList.Click += new System.EventHandler(this.buttonAddList_Click);
            // 
            // buttonAddLive
            // 
            this.buttonAddLive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddLive.Location = new System.Drawing.Point(115, 213);
            this.buttonAddLive.Name = "buttonAddLive";
            this.buttonAddLive.Size = new System.Drawing.Size(58, 21);
            this.buttonAddLive.TabIndex = 124;
            this.buttonAddLive.Text = "Add Live";
            this.buttonAddLive.UseVisualStyleBackColor = true;
            this.buttonAddLive.Click += new System.EventHandler(this.buttonAddLive_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(240, 213);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(39, 21);
            this.buttonRemove.TabIndex = 123;
            this.buttonRemove.Text = "Del";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(0, 213);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(55, 21);
            this.buttonAdd.TabIndex = 122;
            this.buttonAdd.Text = "Add File";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.Image = global::MControls.Properties.Resources.icon_dow;
            this.buttonDown.Location = new System.Drawing.Point(380, 214);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(24, 21);
            this.buttonDown.TabIndex = 127;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.Image = global::MControls.Properties.Resources.icon_up;
            this.buttonUp.Location = new System.Drawing.Point(355, 214);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(24, 21);
            this.buttonUp.TabIndex = 126;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // numericChangeTime
            // 
            this.numericChangeTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericChangeTime.DecimalPlaces = 1;
            this.numericChangeTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericChangeTime.Location = new System.Drawing.Point(283, 215);
            this.numericChangeTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericChangeTime.Name = "numericChangeTime";
            this.numericChangeTime.Size = new System.Drawing.Size(47, 20);
            this.numericChangeTime.TabIndex = 128;
            this.numericChangeTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericChangeTime.Visible = false;
            // 
            // labelSec
            // 
            this.labelSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSec.AutoSize = true;
            this.labelSec.Location = new System.Drawing.Point(330, 218);
            this.labelSec.Name = "labelSec";
            this.labelSec.Size = new System.Drawing.Size(24, 13);
            this.labelSec.TabIndex = 129;
            this.labelSec.Text = "sec";
            this.labelSec.Visible = false;
            // 
            // trackBarTrans
            // 
            this.trackBarTrans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarTrans.AutoSize = false;
            this.trackBarTrans.Enabled = false;
            this.trackBarTrans.Location = new System.Drawing.Point(396, -4);
            this.trackBarTrans.Maximum = 100;
            this.trackBarTrans.Minimum = -1;
            this.trackBarTrans.Name = "trackBarTrans";
            this.trackBarTrans.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarTrans.Size = new System.Drawing.Size(37, 240);
            this.trackBarTrans.TabIndex = 130;
            this.trackBarTrans.TickFrequency = 100;
            this.trackBarTrans.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarTrans.Value = 100;
            this.trackBarTrans.Scroll += new System.EventHandler(this.trackBarTrans_Scroll);
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnFile,
            this.columnIn,
            this.columnOut,
            this.columnLen,
            this.columnMedia,
            this.columnPath});
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.GridLines = true;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.MultiSelect = false;
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(403, 212);
            this.listViewFiles.TabIndex = 121;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewFiles_MouseDoubleClick);
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragEnter);
            this.listViewFiles.ListSubItemChanged += new System.EventHandler(this.listViewFiles_ListSubItemChanged);
            // 
            // columnId
            // 
            this.columnId.Text = "Stream ID";
            // 
            // columnFile
            // 
            this.columnFile.Text = "Name";
            this.columnFile.Width = 150;
            // 
            // columnIn
            // 
            this.columnIn.Text = "In";
            // 
            // columnOut
            // 
            this.columnOut.Text = "Out";
            // 
            // columnLen
            // 
            this.columnLen.Text = "Len";
            // 
            // columnMedia
            // 
            this.columnMedia.Text = "Media";
            this.columnMedia.Width = 120;
            // 
            // columnPath
            // 
            this.columnPath.Text = "Path";
            this.columnPath.Width = 200;
            // 
            // buttonAddURL
            // 
            this.buttonAddURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddURL.Location = new System.Drawing.Point(175, 213);
            this.buttonAddURL.Name = "buttonAddURL";
            this.buttonAddURL.Size = new System.Drawing.Size(64, 21);
            this.buttonAddURL.TabIndex = 131;
            this.buttonAddURL.Text = "Add URL";
            this.buttonAddURL.UseVisualStyleBackColor = true;
            this.buttonAddURL.Click += new System.EventHandler(this.buttonAddURL_Click);
            // 
            // MStreamsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddURL);
            this.Controls.Add(this.numericChangeTime);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonAddList);
            this.Controls.Add(this.buttonAddLive);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.labelSec);
            this.Controls.Add(this.trackBarTrans);
            this.Name = "MStreamsList";
            this.Size = new System.Drawing.Size(428, 235);
            ((System.ComponentModel.ISupportInitialize)(this.numericChangeTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarTrans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddList;
        private System.Windows.Forms.Button buttonAddLive;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private ListViewEx listViewFiles;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.ColumnHeader columnIn;
        private System.Windows.Forms.ColumnHeader columnOut;
        private System.Windows.Forms.ColumnHeader columnLen;
        private System.Windows.Forms.ColumnHeader columnMedia;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.NumericUpDown numericChangeTime;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.TrackBar trackBarTrans;
        private System.Windows.Forms.Button buttonAddURL;
    }
}
