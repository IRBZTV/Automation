namespace MControls
{
    partial class MBreaksControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MBreaksControl));
            this.buttonAddRef = new System.Windows.Forms.Button();
            this.buttonAddCommand = new System.Windows.Forms.Button();
            this.buttonAddLive = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddList = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listViewFiles = new MControls.ListViewEx();
            this.columnTime = new System.Windows.Forms.ColumnHeader();
            this.columnFile = new System.Windows.Forms.ColumnHeader();
            this.columnIn = new System.Windows.Forms.ColumnHeader();
            this.columnOut = new System.Windows.Forms.ColumnHeader();
            this.columnLen = new System.Windows.Forms.ColumnHeader();
            this.columnMedia = new System.Windows.Forms.ColumnHeader();
            this.columnPath = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // buttonAddRef
            // 
            this.buttonAddRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddRef.Enabled = false;
            this.buttonAddRef.Location = new System.Drawing.Point(211, 209);
            this.buttonAddRef.Name = "buttonAddRef";
            this.buttonAddRef.Size = new System.Drawing.Size(69, 21);
            this.buttonAddRef.TabIndex = 119;
            this.buttonAddRef.Text = "Add Ref";
            this.buttonAddRef.UseVisualStyleBackColor = true;
            this.buttonAddRef.Click += new System.EventHandler(this.buttonAddRef_Click);
            // 
            // buttonAddCommand
            // 
            this.buttonAddCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAddCommand.Location = new System.Drawing.Point(281, 209);
            this.buttonAddCommand.Name = "buttonAddCommand";
            this.buttonAddCommand.Size = new System.Drawing.Size(90, 21);
            this.buttonAddCommand.TabIndex = 117;
            this.buttonAddCommand.Text = "Add Command";
            this.buttonAddCommand.UseVisualStyleBackColor = true;
            this.buttonAddCommand.Click += new System.EventHandler(this.buttonAddCommand_Click);
            // 
            // buttonAddLive
            // 
            this.buttonAddLive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddLive.Location = new System.Drawing.Point(140, 209);
            this.buttonAddLive.Name = "buttonAddLive";
            this.buttonAddLive.Size = new System.Drawing.Size(69, 21);
            this.buttonAddLive.TabIndex = 118;
            this.buttonAddLive.Text = "Add Live";
            this.buttonAddLive.UseVisualStyleBackColor = true;
            this.buttonAddLive.Click += new System.EventHandler(this.buttonAddLive_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(372, 209);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(69, 21);
            this.buttonRemove.TabIndex = 116;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(0, 209);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(69, 21);
            this.buttonAdd.TabIndex = 115;
            this.buttonAdd.Text = "Add File";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAddList
            // 
            this.buttonAddList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddList.Location = new System.Drawing.Point(70, 209);
            this.buttonAddList.Name = "buttonAddList";
            this.buttonAddList.Size = new System.Drawing.Size(69, 21);
            this.buttonAddList.TabIndex = 120;
            this.buttonAddList.Text = "Add List";
            this.buttonAddList.UseVisualStyleBackColor = true;
            this.buttonAddList.Click += new System.EventHandler(this.buttonAddList_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "133.ico");
            this.imageList1.Images.SetKeyName(1, "46.ico");
            this.imageList1.Images.SetKeyName(2, "62999.ico");
            this.imageList1.Images.SetKeyName(3, "290.ico");
            this.imageList1.Images.SetKeyName(4, "63009.ico");
            this.imageList1.Images.SetKeyName(5, "23.ico");
            this.imageList1.Images.SetKeyName(6, "63011.ico");
            this.imageList1.Images.SetKeyName(7, "72.ico");
            this.imageList1.Images.SetKeyName(8, "131.ico");
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTime,
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
            this.listViewFiles.Size = new System.Drawing.Size(450, 208);
            this.listViewFiles.SmallImageList = this.imageList1;
            this.listViewFiles.TabIndex = 114;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.ListSubItemOnStartChange += new System.EventHandler(this.listViewFiles_ListSubItemOnStartChange);
            this.listViewFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewFiles_MouseDoubleClick);
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            this.listViewFiles.ListSubItemChanged += new System.EventHandler(this.listViewFiles_ListSubItemChanged);
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            // 
            // columnFile
            // 
            this.columnFile.Text = "File / Command";
            this.columnFile.Width = 150;
            // 
            // columnIn
            // 
            this.columnIn.Text = "In / Param";
            this.columnIn.Width = 100;
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
            // MBreaksControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAddList);
            this.Controls.Add(this.buttonAddRef);
            this.Controls.Add(this.buttonAddCommand);
            this.Controls.Add(this.buttonAddLive);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listViewFiles);
            this.Name = "MBreaksControl";
            this.Size = new System.Drawing.Size(450, 230);
            this.ResumeLayout(false);

        }

        #endregion

        private MControls.ListViewEx listViewFiles;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.ColumnHeader columnIn;
        private System.Windows.Forms.ColumnHeader columnOut;
        private System.Windows.Forms.ColumnHeader columnMedia;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.ColumnHeader columnLen;
        private System.Windows.Forms.Button buttonAddRef;
        private System.Windows.Forms.Button buttonAddCommand;
        private System.Windows.Forms.Button buttonAddLive;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddList;
        private System.Windows.Forms.ImageList imageList1;

    }
}
