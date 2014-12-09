namespace MControls
{
    partial class MPlaylistList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPlaylistList));
            this.buttonAddList = new System.Windows.Forms.Button();
            this.buttonAddLive = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddRef = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonAddCommand = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonAddURL = new System.Windows.Forms.Button();
            this.listViewFiles = new MControls.ListViewEx();
            this.columnPos = new System.Windows.Forms.ColumnHeader();
            this.columnTime = new System.Windows.Forms.ColumnHeader();
            this.columnFile = new System.Windows.Forms.ColumnHeader();
            this.columnIn = new System.Windows.Forms.ColumnHeader();
            this.columnOut = new System.Windows.Forms.ColumnHeader();
            this.columnLen = new System.Windows.Forms.ColumnHeader();
            this.columnState = new System.Windows.Forms.ColumnHeader();
            this.columnMedia = new System.Windows.Forms.ColumnHeader();
            this.columnPath = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // buttonAddList
            // 
            this.buttonAddList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddList.Location = new System.Drawing.Point(180, 279);
            this.buttonAddList.Name = "buttonAddList";
            this.buttonAddList.Size = new System.Drawing.Size(57, 21);
            this.buttonAddList.TabIndex = 108;
            this.buttonAddList.Text = "Add List";
            this.buttonAddList.UseVisualStyleBackColor = true;
            this.buttonAddList.Click += new System.EventHandler(this.buttonAddList_Click);
            // 
            // buttonAddLive
            // 
            this.buttonAddLive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddLive.Location = new System.Drawing.Point(122, 279);
            this.buttonAddLive.Name = "buttonAddLive";
            this.buttonAddLive.Size = new System.Drawing.Size(57, 21);
            this.buttonAddLive.TabIndex = 109;
            this.buttonAddLive.Text = "Add Live";
            this.buttonAddLive.UseVisualStyleBackColor = true;
            this.buttonAddLive.Click += new System.EventHandler(this.buttonAddLive_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Enabled = false;
            this.buttonRemove.Location = new System.Drawing.Point(360, 279);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(31, 21);
            this.buttonRemove.TabIndex = 104;
            this.buttonRemove.Text = "Del";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(0, 279);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(54, 21);
            this.buttonAdd.TabIndex = 103;
            this.buttonAdd.Text = "Add File";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAddRef
            // 
            this.buttonAddRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddRef.Enabled = false;
            this.buttonAddRef.Location = new System.Drawing.Point(239, 279);
            this.buttonAddRef.Name = "buttonAddRef";
            this.buttonAddRef.Size = new System.Drawing.Size(57, 21);
            this.buttonAddRef.TabIndex = 112;
            this.buttonAddRef.Text = "Add Ref";
            this.buttonAddRef.UseVisualStyleBackColor = true;
            this.buttonAddRef.Click += new System.EventHandler(this.buttonAddRef_Click);
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
            // buttonAddCommand
            // 
            this.buttonAddCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAddCommand.Location = new System.Drawing.Point(297, 279);
            this.buttonAddCommand.Name = "buttonAddCommand";
            this.buttonAddCommand.Size = new System.Drawing.Size(62, 21);
            this.buttonAddCommand.TabIndex = 118;
            this.buttonAddCommand.Text = "Add Cmd";
            this.buttonAddCommand.UseVisualStyleBackColor = true;
            this.buttonAddCommand.Click += new System.EventHandler(this.buttonAddCommand_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.Image = global::MControls.Properties.Resources.icon_dow;
            this.buttonDown.Location = new System.Drawing.Point(426, 279);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(24, 21);
            this.buttonDown.TabIndex = 106;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.Image = global::MControls.Properties.Resources.icon_up;
            this.buttonUp.Location = new System.Drawing.Point(401, 279);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(24, 21);
            this.buttonUp.TabIndex = 105;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonAddURL
            // 
            this.buttonAddURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddURL.Location = new System.Drawing.Point(56, 279);
            this.buttonAddURL.Name = "buttonAddURL";
            this.buttonAddURL.Size = new System.Drawing.Size(64, 21);
            this.buttonAddURL.TabIndex = 119;
            this.buttonAddURL.Text = "Add URL";
            this.buttonAddURL.UseVisualStyleBackColor = true;
            this.buttonAddURL.Click += new System.EventHandler(this.buttonAddURL_Click);
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPos,
            this.columnTime,
            this.columnFile,
            this.columnIn,
            this.columnOut,
            this.columnLen,
            this.columnState,
            this.columnMedia,
            this.columnPath});
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.GridLines = true;
            this.listViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.LargeImageList = this.imageList1;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.MultiSelect = false;
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(450, 278);
            this.listViewFiles.SmallImageList = this.imageList1;
            this.listViewFiles.TabIndex = 115;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.ListSubItemOnStartChange += new System.EventHandler(this.listViewFiles_ListSubItemOnStartChange);
            this.listViewFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewFiles_MouseDoubleClick);
            this.listViewFiles.SelectedIndexChanged += new System.EventHandler(this.listViewFiles_SelectedIndexChanged);
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragEnter);
            this.listViewFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewFiles_ItemDrag);
            this.listViewFiles.ListSubItemChanged += new System.EventHandler(this.listViewFiles_ListSubItemChanged);
            // 
            // columnPos
            // 
            this.columnPos.Text = "Pos";
            this.columnPos.Width = 55;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Start Time";
            this.columnTime.Width = 140;
            // 
            // columnFile
            // 
            this.columnFile.Text = "File / Command";
            this.columnFile.Width = 150;
            // 
            // columnIn
            // 
            this.columnIn.Text = "In / Param";
            this.columnIn.Width = 70;
            // 
            // columnOut
            // 
            this.columnOut.Text = "Out";
            // 
            // columnLen
            // 
            this.columnLen.Text = "Len";
            // 
            // columnState
            // 
            this.columnState.Text = "State";
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
            // MPlaylistList
            // 
            this.Controls.Add(this.buttonAddURL);
            this.Controls.Add(this.buttonAddCommand);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.buttonAddRef);
            this.Controls.Add(this.buttonAddList);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonAddLive);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MPlaylistList";
            this.Size = new System.Drawing.Size(450, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.ColumnHeader columnIn;
        private System.Windows.Forms.ColumnHeader columnOut;
        private System.Windows.Forms.ColumnHeader columnLen;
        private System.Windows.Forms.ColumnHeader columnMedia;
        private System.Windows.Forms.ColumnHeader columnPath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnState;
        private MControls.ListViewEx listViewFiles;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.ColumnHeader columnPos;
        public System.Windows.Forms.Button buttonAddList;
        public System.Windows.Forms.Button buttonDown;
        public System.Windows.Forms.Button buttonUp;
        public System.Windows.Forms.Button buttonAddLive;
        public System.Windows.Forms.Button buttonRemove;
        public System.Windows.Forms.Button buttonAdd;
        public System.Windows.Forms.Button buttonAddRef;
        public System.Windows.Forms.Button buttonAddCommand;
        private System.Windows.Forms.Button buttonAddURL;
    }
}
