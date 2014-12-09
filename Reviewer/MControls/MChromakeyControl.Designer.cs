namespace MControls
{
	partial class MChromaKeyControl
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
			this.comboBack = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.comboScale = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.numericKeys = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxDetectType = new System.Windows.Forms.ComboBox();
			this.buttonDetect = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.checkBoxShowBlocks = new System.Windows.Forms.CheckBox();
			this.checkBoxInstatntApply = new System.Windows.Forms.CheckBox();
			this.mCollapsibleGroupBox1 = new MControls.MCollapsibleGroupBox();
			this.buttonRedo = new System.Windows.Forms.Button();
			this.buttonUndo = new System.Windows.Forms.Button();
			this.checkBoxExcludePts = new System.Windows.Forms.CheckBox();
			this.checkBoxIncludePts = new System.Windows.Forms.CheckBox();
			this.groupBoxTransparency = new System.Windows.Forms.GroupBox();
			this.mNumericSliderMaxTransparent = new MControls.MNumericSliderAdjust();
			this.mNumericSliderMinTransparent = new MControls.MNumericSliderAdjust();
			this.groupBoxExclude = new System.Windows.Forms.GroupBox();
			this.mNumericSliderExclTransp = new MControls.MNumericSliderAdjust();
			this.mNumericSliderExclPower = new MControls.MNumericSliderAdjust();
			this.groupBoxPower = new System.Windows.Forms.GroupBox();
			this.mNumericSliderPowerG = new MControls.MNumericSliderAdjust();
			this.mNumericSliderPowerR = new MControls.MNumericSliderAdjust();
			this.mNumericSliderPowerB = new MControls.MNumericSliderAdjust();
			this.groupBoxColors = new System.Windows.Forms.GroupBox();
			this.mNumericSliderColAlpha = new MControls.MNumericSliderAdjust();
			this.mNumericSliderColLuma = new MControls.MNumericSliderAdjust();
			this.mNumericSliderColPower = new MControls.MNumericSliderAdjust();
			this.mNumericSliderColRange = new MControls.MNumericSliderAdjust();
			this.mNumericSliderColChroma = new MControls.MNumericSliderAdjust();
			this.mImageBoxPreview = new MControls.MImageBox();
			this.mNumericSliderSmooth = new MControls.MNumericSliderAdjust();
			this.mNumericSliderColor = new MControls.MNumericSliderAdjust();
			this.mNumericSliderTranspar = new MControls.MNumericSliderAdjust();
			this.mNumericSliderPower = new MControls.MNumericSliderAdjust();
			((System.ComponentModel.ISupportInitialize)(this.numericKeys)).BeginInit();
			this.mCollapsibleGroupBox1.SuspendLayout();
			this.groupBoxTransparency.SuspendLayout();
			this.groupBoxExclude.SuspendLayout();
			this.groupBoxPower.SuspendLayout();
			this.groupBoxColors.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBack
			// 
			this.comboBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBack.FormattingEnabled = true;
			this.comboBack.Location = new System.Drawing.Point(249, 659);
			this.comboBack.Margin = new System.Windows.Forms.Padding(4);
			this.comboBack.Name = "comboBack";
			this.comboBack.Size = new System.Drawing.Size(248, 21);
			this.comboBack.TabIndex = 64;
			this.comboBack.Visible = false;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(165, 663);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 13);
			this.label9.TabIndex = 63;
			this.label9.Text = "Background:";
			this.label9.Visible = false;
			// 
			// comboScale
			// 
			this.comboScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.comboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboScale.FormattingEnabled = true;
			this.comboScale.Items.AddRange(new object[] {
            "<Fit>",
            "x 1.5",
            "x 2",
            "x 2.5",
            "x 3",
            "x 3.5",
            "x 4",
            "x 4.5",
            "x 5"});
			this.comboScale.Location = new System.Drawing.Point(54, 659);
			this.comboScale.Margin = new System.Windows.Forms.Padding(4);
			this.comboScale.Name = "comboScale";
			this.comboScale.Size = new System.Drawing.Size(77, 21);
			this.comboScale.TabIndex = 62;
			this.comboScale.SelectedIndexChanged += new System.EventHandler(this.comboScale_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 663);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 61;
			this.label8.Text = "Scale:";
			// 
			// numericKeys
			// 
			this.numericKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericKeys.Location = new System.Drawing.Point(1137, 9);
			this.numericKeys.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.numericKeys.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericKeys.Name = "numericKeys";
			this.numericKeys.Size = new System.Drawing.Size(47, 20);
			this.numericKeys.TabIndex = 79;
			this.numericKeys.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1107, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(25, 13);
			this.label1.TabIndex = 78;
			this.label1.Text = "Key";
			// 
			// comboBoxDetectType
			// 
			this.comboBoxDetectType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDetectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDetectType.FormattingEnabled = true;
			this.comboBoxDetectType.Items.AddRange(new object[] {
            "Auto",
            "RGB",
            "HLS",
            "YUV"});
			this.comboBoxDetectType.Location = new System.Drawing.Point(882, 9);
			this.comboBoxDetectType.Name = "comboBoxDetectType";
			this.comboBoxDetectType.Size = new System.Drawing.Size(85, 21);
			this.comboBoxDetectType.TabIndex = 77;
			// 
			// buttonDetect
			// 
			this.buttonDetect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDetect.Location = new System.Drawing.Point(799, 7);
			this.buttonDetect.Name = "buttonDetect";
			this.buttonDetect.Size = new System.Drawing.Size(77, 25);
			this.buttonDetect.TabIndex = 76;
			this.buttonDetect.Text = "Auto Detect";
			this.buttonDetect.UseVisualStyleBackColor = true;
			this.buttonDetect.Click += new System.EventHandler(this.buttonDetect_Click);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(945, 657);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(152, 25);
			this.buttonApply.TabIndex = 84;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReset.Location = new System.Drawing.Point(1110, 657);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(77, 25);
			this.buttonReset.TabIndex = 90;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// checkBoxShowBlocks
			// 
			this.checkBoxShowBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxShowBlocks.AutoSize = true;
			this.checkBoxShowBlocks.Location = new System.Drawing.Point(1000, 11);
			this.checkBoxShowBlocks.Name = "checkBoxShowBlocks";
			this.checkBoxShowBlocks.Size = new System.Drawing.Size(87, 17);
			this.checkBoxShowBlocks.TabIndex = 91;
			this.checkBoxShowBlocks.Text = "Show blocks";
			this.checkBoxShowBlocks.UseVisualStyleBackColor = true;
			// 
			// checkBoxInstatntApply
			// 
			this.checkBoxInstatntApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxInstatntApply.AutoSize = true;
			this.checkBoxInstatntApply.Location = new System.Drawing.Point(846, 661);
			this.checkBoxInstatntApply.Name = "checkBoxInstatntApply";
			this.checkBoxInstatntApply.Size = new System.Drawing.Size(93, 17);
			this.checkBoxInstatntApply.TabIndex = 92;
			this.checkBoxInstatntApply.Text = "Apply instantly";
			this.checkBoxInstatntApply.UseVisualStyleBackColor = true;
			// 
			// mCollapsibleGroupBox1
			// 
			this.mCollapsibleGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mCollapsibleGroupBox1.Controls.Add(this.buttonRedo);
			this.mCollapsibleGroupBox1.Controls.Add(this.buttonUndo);
			this.mCollapsibleGroupBox1.Controls.Add(this.checkBoxExcludePts);
			this.mCollapsibleGroupBox1.Controls.Add(this.checkBoxIncludePts);
			this.mCollapsibleGroupBox1.Controls.Add(this.groupBoxTransparency);
			this.mCollapsibleGroupBox1.Controls.Add(this.groupBoxExclude);
			this.mCollapsibleGroupBox1.Controls.Add(this.groupBoxPower);
			this.mCollapsibleGroupBox1.Controls.Add(this.groupBoxColors);
			this.mCollapsibleGroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.mCollapsibleGroupBox1.Location = new System.Drawing.Point(799, 162);
			this.mCollapsibleGroupBox1.Name = "mCollapsibleGroupBox1";
			this.mCollapsibleGroupBox1.Size = new System.Drawing.Size(388, 489);
			this.mCollapsibleGroupBox1.TabIndex = 89;
			this.mCollapsibleGroupBox1.TabStop = false;
			this.mCollapsibleGroupBox1.Text = "Advanced settings";
			this.mCollapsibleGroupBox1.SizeChanged += new System.EventHandler(this.mCollapsibleGroupBox1_SizeChanged);
			// 
			// buttonRedo
			// 
			this.buttonRedo.Location = new System.Drawing.Point(304, 19);
			this.buttonRedo.Name = "buttonRedo";
			this.buttonRedo.Size = new System.Drawing.Size(77, 23);
			this.buttonRedo.TabIndex = 94;
			this.buttonRedo.Text = "Redo";
			this.buttonRedo.UseVisualStyleBackColor = true;
			this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
			// 
			// buttonUndo
			// 
			this.buttonUndo.Location = new System.Drawing.Point(221, 19);
			this.buttonUndo.Name = "buttonUndo";
			this.buttonUndo.Size = new System.Drawing.Size(77, 23);
			this.buttonUndo.TabIndex = 93;
			this.buttonUndo.Text = "Undo";
			this.buttonUndo.UseVisualStyleBackColor = true;
			this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
			// 
			// checkBoxExcludePts
			// 
			this.checkBoxExcludePts.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBoxExcludePts.AutoSize = true;
			this.checkBoxExcludePts.Location = new System.Drawing.Point(96, 20);
			this.checkBoxExcludePts.Name = "checkBoxExcludePts";
			this.checkBoxExcludePts.Size = new System.Drawing.Size(85, 23);
			this.checkBoxExcludePts.TabIndex = 92;
			this.checkBoxExcludePts.Text = "Exclude Mode";
			this.checkBoxExcludePts.UseVisualStyleBackColor = true;
			this.checkBoxExcludePts.CheckedChanged += new System.EventHandler(this.checkBoxExcludePts_CheckedChanged);
			// 
			// checkBoxIncludePts
			// 
			this.checkBoxIncludePts.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkBoxIncludePts.AutoSize = true;
			this.checkBoxIncludePts.Checked = true;
			this.checkBoxIncludePts.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxIncludePts.Location = new System.Drawing.Point(8, 20);
			this.checkBoxIncludePts.Name = "checkBoxIncludePts";
			this.checkBoxIncludePts.Size = new System.Drawing.Size(82, 23);
			this.checkBoxIncludePts.TabIndex = 91;
			this.checkBoxIncludePts.Text = "Include Mode";
			this.checkBoxIncludePts.UseVisualStyleBackColor = true;
			this.checkBoxIncludePts.CheckedChanged += new System.EventHandler(this.checkBoxIncludePts_CheckedChanged);
			// 
			// groupBoxTransparency
			// 
			this.groupBoxTransparency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxTransparency.Controls.Add(this.mNumericSliderMaxTransparent);
			this.groupBoxTransparency.Controls.Add(this.mNumericSliderMinTransparent);
			this.groupBoxTransparency.Location = new System.Drawing.Point(8, 50);
			this.groupBoxTransparency.Name = "groupBoxTransparency";
			this.groupBoxTransparency.Size = new System.Drawing.Size(373, 77);
			this.groupBoxTransparency.TabIndex = 87;
			this.groupBoxTransparency.TabStop = false;
			this.groupBoxTransparency.Text = "Transparency";
			// 
			// mNumericSliderMaxTransparent
			// 
			this.mNumericSliderMaxTransparent.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_MaxTransparent;
			this.mNumericSliderMaxTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderMaxTransparent.dblIncrement = 0.01;
			this.mNumericSliderMaxTransparent.dblMaximumValue = 1;
			this.mNumericSliderMaxTransparent.dblMinimumValue = -1;
			this.mNumericSliderMaxTransparent.dblValue = 0;
			this.mNumericSliderMaxTransparent.Location = new System.Drawing.Point(4, 40);
			this.mNumericSliderMaxTransparent.Name = "mNumericSliderMaxTransparent";
			this.mNumericSliderMaxTransparent.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderMaxTransparent.strCaption = "Maximum";
			this.mNumericSliderMaxTransparent.TabIndex = 85;
			this.mNumericSliderMaxTransparent.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderMinTransparent
			// 
			this.mNumericSliderMinTransparent.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_MinTransparent;
			this.mNumericSliderMinTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderMinTransparent.dblIncrement = 0.01;
			this.mNumericSliderMinTransparent.dblMaximumValue = 1;
			this.mNumericSliderMinTransparent.dblMinimumValue = -1;
			this.mNumericSliderMinTransparent.dblValue = 0;
			this.mNumericSliderMinTransparent.Location = new System.Drawing.Point(4, 13);
			this.mNumericSliderMinTransparent.Name = "mNumericSliderMinTransparent";
			this.mNumericSliderMinTransparent.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderMinTransparent.strCaption = "Minimum";
			this.mNumericSliderMinTransparent.TabIndex = 84;
			this.mNumericSliderMinTransparent.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// groupBoxExclude
			// 
			this.groupBoxExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxExclude.Controls.Add(this.mNumericSliderExclTransp);
			this.groupBoxExclude.Controls.Add(this.mNumericSliderExclPower);
			this.groupBoxExclude.Location = new System.Drawing.Point(8, 131);
			this.groupBoxExclude.Name = "groupBoxExclude";
			this.groupBoxExclude.Size = new System.Drawing.Size(373, 77);
			this.groupBoxExclude.TabIndex = 88;
			this.groupBoxExclude.TabStop = false;
			this.groupBoxExclude.Text = "Exclude";
			// 
			// mNumericSliderExclTransp
			// 
			this.mNumericSliderExclTransp.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_ExcludeTransparent;
			this.mNumericSliderExclTransp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderExclTransp.dblIncrement = 0.01;
			this.mNumericSliderExclTransp.dblMaximumValue = 1;
			this.mNumericSliderExclTransp.dblMinimumValue = -1;
			this.mNumericSliderExclTransp.dblValue = 0;
			this.mNumericSliderExclTransp.Location = new System.Drawing.Point(4, 40);
			this.mNumericSliderExclTransp.Name = "mNumericSliderExclTransp";
			this.mNumericSliderExclTransp.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderExclTransp.strCaption = "Transparency";
			this.mNumericSliderExclTransp.TabIndex = 85;
			this.mNumericSliderExclTransp.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderExclPower
			// 
			this.mNumericSliderExclPower.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_ExcludePower;
			this.mNumericSliderExclPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderExclPower.dblIncrement = 0.01;
			this.mNumericSliderExclPower.dblMaximumValue = 1;
			this.mNumericSliderExclPower.dblMinimumValue = -1;
			this.mNumericSliderExclPower.dblValue = 0;
			this.mNumericSliderExclPower.Location = new System.Drawing.Point(4, 13);
			this.mNumericSliderExclPower.Name = "mNumericSliderExclPower";
			this.mNumericSliderExclPower.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderExclPower.strCaption = "Power";
			this.mNumericSliderExclPower.TabIndex = 84;
			this.mNumericSliderExclPower.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// groupBoxPower
			// 
			this.groupBoxPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxPower.Controls.Add(this.mNumericSliderPowerG);
			this.groupBoxPower.Controls.Add(this.mNumericSliderPowerR);
			this.groupBoxPower.Controls.Add(this.mNumericSliderPowerB);
			this.groupBoxPower.Location = new System.Drawing.Point(8, 211);
			this.groupBoxPower.Name = "groupBoxPower";
			this.groupBoxPower.Size = new System.Drawing.Size(373, 104);
			this.groupBoxPower.TabIndex = 85;
			this.groupBoxPower.TabStop = false;
			this.groupBoxPower.Text = "Power";
			// 
			// mNumericSliderPowerG
			// 
			this.mNumericSliderPowerG.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Power_G_L_U;
			this.mNumericSliderPowerG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderPowerG.dblIncrement = 0.01;
			this.mNumericSliderPowerG.dblMaximumValue = 1;
			this.mNumericSliderPowerG.dblMinimumValue = -1;
			this.mNumericSliderPowerG.dblValue = 0;
			this.mNumericSliderPowerG.Location = new System.Drawing.Point(4, 40);
			this.mNumericSliderPowerG.Name = "mNumericSliderPowerG";
			this.mNumericSliderPowerG.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderPowerG.strCaption = "G / L / U";
			this.mNumericSliderPowerG.TabIndex = 85;
			this.mNumericSliderPowerG.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderPowerR
			// 
			this.mNumericSliderPowerR.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Power_R_H_Y;
			this.mNumericSliderPowerR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderPowerR.dblIncrement = 0.01;
			this.mNumericSliderPowerR.dblMaximumValue = 1;
			this.mNumericSliderPowerR.dblMinimumValue = -1;
			this.mNumericSliderPowerR.dblValue = 0;
			this.mNumericSliderPowerR.Location = new System.Drawing.Point(4, 13);
			this.mNumericSliderPowerR.Name = "mNumericSliderPowerR";
			this.mNumericSliderPowerR.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderPowerR.strCaption = "R / H / Y";
			this.mNumericSliderPowerR.TabIndex = 84;
			this.mNumericSliderPowerR.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderPowerB
			// 
			this.mNumericSliderPowerB.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Power_B_S_V;
			this.mNumericSliderPowerB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderPowerB.dblIncrement = 0.01;
			this.mNumericSliderPowerB.dblMaximumValue = 1;
			this.mNumericSliderPowerB.dblMinimumValue = -1;
			this.mNumericSliderPowerB.dblValue = 0;
			this.mNumericSliderPowerB.Location = new System.Drawing.Point(4, 68);
			this.mNumericSliderPowerB.Name = "mNumericSliderPowerB";
			this.mNumericSliderPowerB.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderPowerB.strCaption = "B / S / V";
			this.mNumericSliderPowerB.TabIndex = 86;
			this.mNumericSliderPowerB.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// groupBoxColors
			// 
			this.groupBoxColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxColors.Controls.Add(this.mNumericSliderColAlpha);
			this.groupBoxColors.Controls.Add(this.mNumericSliderColLuma);
			this.groupBoxColors.Controls.Add(this.mNumericSliderColPower);
			this.groupBoxColors.Controls.Add(this.mNumericSliderColRange);
			this.groupBoxColors.Controls.Add(this.mNumericSliderColChroma);
			this.groupBoxColors.Location = new System.Drawing.Point(8, 319);
			this.groupBoxColors.Name = "groupBoxColors";
			this.groupBoxColors.Size = new System.Drawing.Size(373, 161);
			this.groupBoxColors.TabIndex = 86;
			this.groupBoxColors.TabStop = false;
			this.groupBoxColors.Text = "Colors";
			// 
			// mNumericSliderColAlpha
			// 
			this.mNumericSliderColAlpha.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Colors_Alpha;
			this.mNumericSliderColAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderColAlpha.dblIncrement = 0.01;
			this.mNumericSliderColAlpha.dblMaximumValue = 1;
			this.mNumericSliderColAlpha.dblMinimumValue = -1;
			this.mNumericSliderColAlpha.dblValue = 0;
			this.mNumericSliderColAlpha.Location = new System.Drawing.Point(5, 124);
			this.mNumericSliderColAlpha.Name = "mNumericSliderColAlpha";
			this.mNumericSliderColAlpha.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderColAlpha.strCaption = "Alpha";
			this.mNumericSliderColAlpha.TabIndex = 88;
			this.mNumericSliderColAlpha.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderColLuma
			// 
			this.mNumericSliderColLuma.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Colors_Luma;
			this.mNumericSliderColLuma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderColLuma.dblIncrement = 0.01;
			this.mNumericSliderColLuma.dblMaximumValue = 1;
			this.mNumericSliderColLuma.dblMinimumValue = -1;
			this.mNumericSliderColLuma.dblValue = 0;
			this.mNumericSliderColLuma.Location = new System.Drawing.Point(5, 96);
			this.mNumericSliderColLuma.Name = "mNumericSliderColLuma";
			this.mNumericSliderColLuma.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderColLuma.strCaption = "Luma";
			this.mNumericSliderColLuma.TabIndex = 87;
			this.mNumericSliderColLuma.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderColPower
			// 
			this.mNumericSliderColPower.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Colors_Power;
			this.mNumericSliderColPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderColPower.dblIncrement = 0.01;
			this.mNumericSliderColPower.dblMaximumValue = 1;
			this.mNumericSliderColPower.dblMinimumValue = -1;
			this.mNumericSliderColPower.dblValue = 0;
			this.mNumericSliderColPower.Location = new System.Drawing.Point(4, 40);
			this.mNumericSliderColPower.Name = "mNumericSliderColPower";
			this.mNumericSliderColPower.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderColPower.strCaption = "Power";
			this.mNumericSliderColPower.TabIndex = 85;
			this.mNumericSliderColPower.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderColRange
			// 
			this.mNumericSliderColRange.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Colors_Range;
			this.mNumericSliderColRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderColRange.dblIncrement = 0.01;
			this.mNumericSliderColRange.dblMaximumValue = 1;
			this.mNumericSliderColRange.dblMinimumValue = 0;
			this.mNumericSliderColRange.dblValue = 0;
			this.mNumericSliderColRange.Location = new System.Drawing.Point(4, 13);
			this.mNumericSliderColRange.Name = "mNumericSliderColRange";
			this.mNumericSliderColRange.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderColRange.strCaption = "Range";
			this.mNumericSliderColRange.TabIndex = 84;
			this.mNumericSliderColRange.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderColChroma
			// 
			this.mNumericSliderColChroma.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Colors_Chroma;
			this.mNumericSliderColChroma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderColChroma.dblIncrement = 0.01;
			this.mNumericSliderColChroma.dblMaximumValue = 1;
			this.mNumericSliderColChroma.dblMinimumValue = -1;
			this.mNumericSliderColChroma.dblValue = 0;
			this.mNumericSliderColChroma.Location = new System.Drawing.Point(4, 68);
			this.mNumericSliderColChroma.Name = "mNumericSliderColChroma";
			this.mNumericSliderColChroma.Size = new System.Drawing.Size(363, 34);
			this.mNumericSliderColChroma.strCaption = "Chroma";
			this.mNumericSliderColChroma.TabIndex = 86;
			this.mNumericSliderColChroma.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mImageBoxPreview
			// 
			this.mImageBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mImageBoxPreview.AutoCenter = false;
			this.mImageBoxPreview.AutoScroll = true;
			this.mImageBoxPreview.AutoSize = false;
			this.mImageBoxPreview.BackColor = System.Drawing.SystemColors.Control;
			this.mImageBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.mImageBoxPreview.GridCellSize = 0;
			this.mImageBoxPreview.GridColor = System.Drawing.Color.Empty;
			this.mImageBoxPreview.GridColorAlternate = System.Drawing.Color.Empty;
			this.mImageBoxPreview.GridDisplayMode = MControls.ImageBoxGridDisplayMode.None;
			this.mImageBoxPreview.Location = new System.Drawing.Point(11, 9);
			this.mImageBoxPreview.Name = "mImageBoxPreview";
			this.mImageBoxPreview.Size = new System.Drawing.Size(776, 642);
			this.mImageBoxPreview.TabIndex = 63;
			this.mImageBoxPreview.ZoomIncrement = 5;
			this.mImageBoxPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mImageBoxPreview_MouseUp);
			this.mImageBoxPreview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.mImageBoxPreview_Scroll);
			this.mImageBoxPreview.MouseEnter += new System.EventHandler(this.mImageBoxPreview_MouseEnter);
			// 
			// mNumericSliderSmooth
			// 
			this.mNumericSliderSmooth.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Smooth;
			this.mNumericSliderSmooth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderSmooth.dblIncrement = 0.01;
			this.mNumericSliderSmooth.dblMaximumValue = 1;
			this.mNumericSliderSmooth.dblMinimumValue = 0;
			this.mNumericSliderSmooth.dblValue = 0;
			this.mNumericSliderSmooth.Location = new System.Drawing.Point(799, 123);
			this.mNumericSliderSmooth.Name = "mNumericSliderSmooth";
			this.mNumericSliderSmooth.Size = new System.Drawing.Size(388, 37);
			this.mNumericSliderSmooth.strCaption = "Smooth";
			this.mNumericSliderSmooth.TabIndex = 83;
			this.mNumericSliderSmooth.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderColor
			// 
			this.mNumericSliderColor.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Colors;
			this.mNumericSliderColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderColor.dblIncrement = 0.01;
			this.mNumericSliderColor.dblMaximumValue = 1;
			this.mNumericSliderColor.dblMinimumValue = 0;
			this.mNumericSliderColor.dblValue = 0;
			this.mNumericSliderColor.Location = new System.Drawing.Point(799, 94);
			this.mNumericSliderColor.Name = "mNumericSliderColor";
			this.mNumericSliderColor.Size = new System.Drawing.Size(388, 37);
			this.mNumericSliderColor.strCaption = "Color";
			this.mNumericSliderColor.TabIndex = 82;
			this.mNumericSliderColor.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderTranspar
			// 
			this.mNumericSliderTranspar.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Transparent;
			this.mNumericSliderTranspar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderTranspar.dblIncrement = 0.01;
			this.mNumericSliderTranspar.dblMaximumValue = 1;
			this.mNumericSliderTranspar.dblMinimumValue = 0;
			this.mNumericSliderTranspar.dblValue = 0;
			this.mNumericSliderTranspar.Location = new System.Drawing.Point(799, 66);
			this.mNumericSliderTranspar.Name = "mNumericSliderTranspar";
			this.mNumericSliderTranspar.Size = new System.Drawing.Size(388, 37);
			this.mNumericSliderTranspar.strCaption = "Transparent";
			this.mNumericSliderTranspar.TabIndex = 81;
			this.mNumericSliderTranspar.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// mNumericSliderPower
			// 
			this.mNumericSliderPower.AdjustType = MCHROMAKEYLib.eCK_Adjust.eCKA_Power;
			this.mNumericSliderPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mNumericSliderPower.dblIncrement = 0.01;
			this.mNumericSliderPower.dblMaximumValue = 1;
			this.mNumericSliderPower.dblMinimumValue = -1;
			this.mNumericSliderPower.dblValue = 0;
			this.mNumericSliderPower.Location = new System.Drawing.Point(799, 38);
			this.mNumericSliderPower.Name = "mNumericSliderPower";
			this.mNumericSliderPower.Size = new System.Drawing.Size(388, 37);
			this.mNumericSliderPower.strCaption = "Power";
			this.mNumericSliderPower.TabIndex = 80;
			this.mNumericSliderPower.DblValueChanged += new System.EventHandler(this.SliderControl_DblValueChanged);
			// 
			// MChromaKeyControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkBoxInstatntApply);
			this.Controls.Add(this.checkBoxShowBlocks);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.mCollapsibleGroupBox1);
			this.Controls.Add(this.mImageBoxPreview);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.mNumericSliderSmooth);
			this.Controls.Add(this.mNumericSliderColor);
			this.Controls.Add(this.mNumericSliderTranspar);
			this.Controls.Add(this.mNumericSliderPower);
			this.Controls.Add(this.numericKeys);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxDetectType);
			this.Controls.Add(this.buttonDetect);
			this.Controls.Add(this.comboBack);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.comboScale);
			this.Controls.Add(this.label8);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "MChromaKeyControl";
			this.Size = new System.Drawing.Size(1200, 688);
			((System.ComponentModel.ISupportInitialize)(this.numericKeys)).EndInit();
			this.mCollapsibleGroupBox1.ResumeLayout(false);
			this.mCollapsibleGroupBox1.PerformLayout();
			this.groupBoxTransparency.ResumeLayout(false);
			this.groupBoxExclude.ResumeLayout(false);
			this.groupBoxPower.ResumeLayout(false);
			this.groupBoxColors.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBack;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboScale;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown numericKeys;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxDetectType;
		private System.Windows.Forms.Button buttonDetect;
		private MNumericSliderAdjust mNumericSliderPower;
		private MNumericSliderAdjust mNumericSliderTranspar;
		private MNumericSliderAdjust mNumericSliderColor;
		private MNumericSliderAdjust mNumericSliderSmooth;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.GroupBox groupBoxPower;
		private MNumericSliderAdjust mNumericSliderPowerB;
		private MNumericSliderAdjust mNumericSliderPowerG;
		private MNumericSliderAdjust mNumericSliderPowerR;
		private MImageBox mImageBoxPreview;
		private System.Windows.Forms.GroupBox groupBoxColors;
		private MNumericSliderAdjust mNumericSliderColAlpha;
		private MNumericSliderAdjust mNumericSliderColLuma;
		private MNumericSliderAdjust mNumericSliderColPower;
		private MNumericSliderAdjust mNumericSliderColRange;
		private MNumericSliderAdjust mNumericSliderColChroma;
		private System.Windows.Forms.GroupBox groupBoxTransparency;
		private MNumericSliderAdjust mNumericSliderMaxTransparent;
		private MNumericSliderAdjust mNumericSliderMinTransparent;
		private System.Windows.Forms.GroupBox groupBoxExclude;
		private MNumericSliderAdjust mNumericSliderExclTransp;
		private MNumericSliderAdjust mNumericSliderExclPower;
		private MCollapsibleGroupBox mCollapsibleGroupBox1;
		private System.Windows.Forms.CheckBox checkBoxIncludePts;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.CheckBox checkBoxExcludePts;
		private System.Windows.Forms.Button buttonRedo;
		private System.Windows.Forms.Button buttonUndo;
		private System.Windows.Forms.CheckBox checkBoxShowBlocks;
		private System.Windows.Forms.CheckBox checkBoxInstatntApply;
	}
}
