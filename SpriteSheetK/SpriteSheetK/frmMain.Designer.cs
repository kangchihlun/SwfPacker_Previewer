namespace SpriteSheetEditor
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.paMergeFill = new System.Windows.Forms.Panel();
            this.pbSheet = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMergeRowCnt = new System.Windows.Forms.TextBox();
            this.cboMergeCurrentRow = new System.Windows.Forms.ComboBox();
            this.btnClearAllMerge = new System.Windows.Forms.Button();
            this.imgList16px = new System.Windows.Forms.ImageList(this.components);
            this.chkAutoSortLstImages = new System.Windows.Forms.CheckBox();
            this.btnDelImage = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboExt = new System.Windows.Forms.ComboBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFrameHeight = new System.Windows.Forms.TextBox();
            this.txtFrameWidth = new System.Windows.Forms.TextBox();
            this.txtFrameCnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstImages = new System.Windows.Forms.ListBox();
            this.btnOpenFiles = new System.Windows.Forms.Button();
            this.tpFlashIt = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnFlashItSaveAs = new System.Windows.Forms.Button();
            this.chkKeepAS = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.paPreviewFill = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkUseMask = new System.Windows.Forms.CheckBox();
            this.ShowMokujin = new System.Windows.Forms.CheckBox();
            this.btnViseColor = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.spnTestScale = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spnPivotY = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.spnPivotX = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenAnimDef = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.spnFrameCnt = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.spnPlayBackSpeed = new System.Windows.Forms.NumericUpDown();
            this.spnFrameHeight = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.spnFrameWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.spnPicIdx = new System.Windows.Forms.NumericUpDown();
            this.spriteTextureControl = new SpriteSheetEditor.SpriteTexControl();
            this.pbPreviewAnimation = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.paSplitFill = new System.Windows.Forms.Panel();
            this.pbSplit = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSplitReplaceColor = new System.Windows.Forms.Button();
            this.btnSaveSplitAs = new System.Windows.Forms.Button();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.pgSplit = new System.Windows.Forms.PropertyGrid();
            this.tpTilePreview = new System.Windows.Forms.TabPage();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.patsRight = new System.Windows.Forms.Panel();
            this.patsImage = new System.Windows.Forms.Panel();
            this.patsLeft = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pgTP = new System.Windows.Forms.PropertyGrid();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btntpFill = new System.Windows.Forms.Button();
            this.btntpHelp = new System.Windows.Forms.Button();
            this.cbotpLayer = new System.Windows.Forms.ComboBox();
            this.btntpReset = new System.Windows.Forms.Button();
            this.btntpSaveAs = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.timPreview = new System.Windows.Forms.Timer(this.components);
            this.timFPS = new System.Windows.Forms.Timer(this.components);
            this.ss1 = new System.Windows.Forms.StatusStrip();
            this.tslbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.paMergeFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSheet)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpFlashIt.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.paPreviewFill.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTestScale)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnPivotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPivotX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrameCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPlayBackSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrameHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrameWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPicIdx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewAnimation)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.paSplitFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSplit)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tpTilePreview.SuspendLayout();
            this.patsRight.SuspendLayout();
            this.patsLeft.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.ss1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofd1
            // 
            this.ofd1.FileName = "openFileDialog1";
            this.ofd1.Multiselect = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpFlashIt);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1016, 417);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Click += new System.EventHandler(this.onPreviewClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitter2);
            this.tabPage1.Controls.Add(this.paMergeFill);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1008, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Merge";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(157, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 385);
            this.splitter2.TabIndex = 10;
            this.splitter2.TabStop = false;
            // 
            // paMergeFill
            // 
            this.paMergeFill.AllowDrop = true;
            this.paMergeFill.AutoScroll = true;
            this.paMergeFill.Controls.Add(this.pbSheet);
            this.paMergeFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paMergeFill.Location = new System.Drawing.Point(157, 3);
            this.paMergeFill.Name = "paMergeFill";
            this.paMergeFill.Size = new System.Drawing.Size(848, 385);
            this.paMergeFill.TabIndex = 9;
            this.paMergeFill.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstImages_DragDrop);
            this.paMergeFill.DragEnter += new System.Windows.Forms.DragEventHandler(this.Generic_DragEnter);
            // 
            // pbSheet
            // 
            this.pbSheet.BackColor = System.Drawing.Color.Transparent;
            this.pbSheet.Location = new System.Drawing.Point(20, 16);
            this.pbSheet.Name = "pbSheet";
            this.pbSheet.Size = new System.Drawing.Size(256, 236);
            this.pbSheet.TabIndex = 0;
            this.pbSheet.TabStop = false;
            this.pbSheet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_SetCoordinates);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtMergeRowCnt);
            this.panel1.Controls.Add(this.cboMergeCurrentRow);
            this.panel1.Controls.Add(this.btnClearAllMerge);
            this.panel1.Controls.Add(this.chkAutoSortLstImages);
            this.panel1.Controls.Add(this.btnDelImage);
            this.panel1.Controls.Add(this.btnMoveDown);
            this.panel1.Controls.Add(this.btnMoveUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboExt);
            this.panel1.Controls.Add(this.btnSaveAs);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFrameHeight);
            this.panel1.Controls.Add(this.txtFrameWidth);
            this.panel1.Controls.Add(this.txtFrameCnt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lstImages);
            this.panel1.Controls.Add(this.btnOpenFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 385);
            this.panel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Row Count";
            // 
            // txtMergeRowCnt
            // 
            this.txtMergeRowCnt.Location = new System.Drawing.Point(77, 239);
            this.txtMergeRowCnt.Name = "txtMergeRowCnt";
            this.txtMergeRowCnt.Size = new System.Drawing.Size(42, 22);
            this.txtMergeRowCnt.TabIndex = 14;
            this.txtMergeRowCnt.Text = "1";
            this.txtMergeRowCnt.TextChanged += new System.EventHandler(this.txtMergeRowCnt_TextChanged);
            // 
            // cboMergeCurrentRow
            // 
            this.cboMergeCurrentRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMergeCurrentRow.FormattingEnabled = true;
            this.cboMergeCurrentRow.Items.AddRange(new object[] {
            "0"});
            this.cboMergeCurrentRow.Location = new System.Drawing.Point(7, 211);
            this.cboMergeCurrentRow.Name = "cboMergeCurrentRow";
            this.cboMergeCurrentRow.Size = new System.Drawing.Size(121, 20);
            this.cboMergeCurrentRow.TabIndex = 12;
            this.cboMergeCurrentRow.SelectedIndexChanged += new System.EventHandler(this.cboMergeCurrentRow_SelectedIndexChanged);
            // 
            // btnClearAllMerge
            // 
            this.btnClearAllMerge.ImageKey = "redCross16px.png";
            this.btnClearAllMerge.ImageList = this.imgList16px;
            this.btnClearAllMerge.Location = new System.Drawing.Point(130, 181);
            this.btnClearAllMerge.Name = "btnClearAllMerge";
            this.btnClearAllMerge.Size = new System.Drawing.Size(24, 22);
            this.btnClearAllMerge.TabIndex = 11;
            this.btnClearAllMerge.UseVisualStyleBackColor = true;
            this.btnClearAllMerge.Click += new System.EventHandler(this.btnClearAllMerge_Click);
            // 
            // imgList16px
            // 
            this.imgList16px.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList16px.ImageStream")));
            this.imgList16px.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList16px.Images.SetKeyName(0, "arrowBlueDown_48px.png");
            this.imgList16px.Images.SetKeyName(1, "arrowBlueUp_48px.png");
            this.imgList16px.Images.SetKeyName(2, "redCross16px.png");
            // 
            // chkAutoSortLstImages
            // 
            this.chkAutoSortLstImages.AutoSize = true;
            this.chkAutoSortLstImages.Checked = true;
            this.chkAutoSortLstImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoSortLstImages.Location = new System.Drawing.Point(109, 263);
            this.chkAutoSortLstImages.Name = "chkAutoSortLstImages";
            this.chkAutoSortLstImages.Size = new System.Drawing.Size(43, 16);
            this.chkAutoSortLstImages.TabIndex = 10;
            this.chkAutoSortLstImages.Text = "Sort";
            this.chkAutoSortLstImages.UseVisualStyleBackColor = true;
            this.chkAutoSortLstImages.CheckedChanged += new System.EventHandler(this.chkAutoSortLstImages_CheckedChanged);
            // 
            // btnDelImage
            // 
            this.btnDelImage.ImageKey = "redCross16px.png";
            this.btnDelImage.ImageList = this.imgList16px;
            this.btnDelImage.Location = new System.Drawing.Point(130, 153);
            this.btnDelImage.Name = "btnDelImage";
            this.btnDelImage.Size = new System.Drawing.Size(24, 22);
            this.btnDelImage.TabIndex = 7;
            this.btnDelImage.UseVisualStyleBackColor = true;
            this.btnDelImage.Click += new System.EventHandler(this.btnDelImage_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.ImageKey = "arrowBlueDown_48px.png";
            this.btnMoveDown.ImageList = this.imgList16px;
            this.btnMoveDown.Location = new System.Drawing.Point(130, 126);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(24, 22);
            this.btnMoveDown.TabIndex = 6;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.ImageKey = "arrowBlueUp_48px.png";
            this.btnMoveUp.ImageList = this.imgList16px;
            this.btnMoveUp.Location = new System.Drawing.Point(130, 99);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(24, 22);
            this.btnMoveUp.TabIndex = 5;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Frame Size";
            // 
            // cboExt
            // 
            this.cboExt.FormattingEnabled = true;
            this.cboExt.Items.AddRange(new object[] {
            "PNG",
            "BMP",
            "JPEG"});
            this.cboExt.Location = new System.Drawing.Point(12, 359);
            this.cboExt.Name = "cboExt";
            this.cboExt.Size = new System.Drawing.Size(121, 20);
            this.cboExt.TabIndex = 1;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(77, 332);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 21);
            this.btnSaveAs.TabIndex = 8;
            this.btnSaveAs.Text = "Save as...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 332);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 21);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "X";
            // 
            // txtFrameHeight
            // 
            this.txtFrameHeight.Location = new System.Drawing.Point(77, 284);
            this.txtFrameHeight.Name = "txtFrameHeight";
            this.txtFrameHeight.Size = new System.Drawing.Size(42, 22);
            this.txtFrameHeight.TabIndex = 2;
            this.txtFrameHeight.Text = "64";
            this.txtFrameHeight.TextChanged += new System.EventHandler(this.Merge_TextChanged);
            // 
            // txtFrameWidth
            // 
            this.txtFrameWidth.Location = new System.Drawing.Point(14, 284);
            this.txtFrameWidth.Name = "txtFrameWidth";
            this.txtFrameWidth.Size = new System.Drawing.Size(42, 22);
            this.txtFrameWidth.TabIndex = 1;
            this.txtFrameWidth.Text = "64";
            this.txtFrameWidth.TextChanged += new System.EventHandler(this.Merge_TextChanged);
            // 
            // txtFrameCnt
            // 
            this.txtFrameCnt.Location = new System.Drawing.Point(77, 308);
            this.txtFrameCnt.Name = "txtFrameCnt";
            this.txtFrameCnt.Size = new System.Drawing.Size(42, 22);
            this.txtFrameCnt.TabIndex = 3;
            this.txtFrameCnt.Text = "8";
            this.txtFrameCnt.TextChanged += new System.EventHandler(this.Merge_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Frame Count";
            // 
            // lstImages
            // 
            this.lstImages.AllowDrop = true;
            this.lstImages.FormattingEnabled = true;
            this.lstImages.HorizontalScrollbar = true;
            this.lstImages.ItemHeight = 12;
            this.lstImages.Location = new System.Drawing.Point(7, 30);
            this.lstImages.Name = "lstImages";
            this.lstImages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstImages.Size = new System.Drawing.Size(121, 184);
            this.lstImages.TabIndex = 9;
            this.lstImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstImages_DragDrop);
            this.lstImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstImages_DragEnter);
            // 
            // btnOpenFiles
            // 
            this.btnOpenFiles.Location = new System.Drawing.Point(3, 3);
            this.btnOpenFiles.Name = "btnOpenFiles";
            this.btnOpenFiles.Size = new System.Drawing.Size(75, 21);
            this.btnOpenFiles.TabIndex = 0;
            this.btnOpenFiles.Text = "Open File(s)";
            this.btnOpenFiles.UseVisualStyleBackColor = true;
            this.btnOpenFiles.Click += new System.EventHandler(this.btnOpenFiles_Click);
            // 
            // tpFlashIt
            // 
            this.tpFlashIt.Controls.Add(this.panel10);
            this.tpFlashIt.Location = new System.Drawing.Point(4, 22);
            this.tpFlashIt.Name = "tpFlashIt";
            this.tpFlashIt.Size = new System.Drawing.Size(1008, 391);
            this.tpFlashIt.TabIndex = 5;
            this.tpFlashIt.Text = "Flash It";
            this.tpFlashIt.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btnFlashItSaveAs);
            this.panel10.Controls.Add(this.chkKeepAS);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1008, 391);
            this.panel10.TabIndex = 0;
            // 
            // btnFlashItSaveAs
            // 
            this.btnFlashItSaveAs.Location = new System.Drawing.Point(8, 23);
            this.btnFlashItSaveAs.Name = "btnFlashItSaveAs";
            this.btnFlashItSaveAs.Size = new System.Drawing.Size(110, 21);
            this.btnFlashItSaveAs.TabIndex = 1;
            this.btnFlashItSaveAs.Text = "Save As...";
            this.btnFlashItSaveAs.UseVisualStyleBackColor = true;
            this.btnFlashItSaveAs.Click += new System.EventHandler(this.btnFlashItSaveAs_Click);
            // 
            // chkKeepAS
            // 
            this.chkKeepAS.AutoSize = true;
            this.chkKeepAS.Location = new System.Drawing.Point(8, 62);
            this.chkKeepAS.Name = "chkKeepAS";
            this.chkKeepAS.Size = new System.Drawing.Size(65, 16);
            this.chkKeepAS.TabIndex = 1;
            this.chkKeepAS.Text = "Keep AS";
            this.chkKeepAS.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.paPreviewFill);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1008, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Preview";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // paPreviewFill
            // 
            this.paPreviewFill.AllowDrop = true;
            this.paPreviewFill.AutoScroll = true;
            this.paPreviewFill.BackColor = System.Drawing.Color.White;
            this.paPreviewFill.Controls.Add(this.panel2);
            this.paPreviewFill.Controls.Add(this.spriteTextureControl);
            this.paPreviewFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paPreviewFill.Location = new System.Drawing.Point(3, 3);
            this.paPreviewFill.Name = "paPreviewFill";
            this.paPreviewFill.Size = new System.Drawing.Size(1002, 385);
            this.paPreviewFill.TabIndex = 19;
            this.paPreviewFill.Paint += new System.Windows.Forms.PaintEventHandler(this.paPreviewFill_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.chkUseMask);
            this.panel2.Controls.Add(this.ShowMokujin);
            this.panel2.Controls.Add(this.btnViseColor);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.spnTestScale);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.spnFrameCnt);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.spnPlayBackSpeed);
            this.panel2.Controls.Add(this.spnFrameHeight);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.spnFrameWidth);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.spnPicIdx);
            this.panel2.Location = new System.Drawing.Point(43, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 353);
            this.panel2.TabIndex = 24;
            // 
            // chkUseMask
            // 
            this.chkUseMask.AutoSize = true;
            this.chkUseMask.Checked = true;
            this.chkUseMask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseMask.Location = new System.Drawing.Point(121, 17);
            this.chkUseMask.Name = "chkUseMask";
            this.chkUseMask.Size = new System.Drawing.Size(72, 16);
            this.chkUseMask.TabIndex = 37;
            this.chkUseMask.Text = "啟用遮罩";
            this.chkUseMask.UseVisualStyleBackColor = true;
            // 
            // ShowMokujin
            // 
            this.ShowMokujin.AutoSize = true;
            this.ShowMokujin.Checked = true;
            this.ShowMokujin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowMokujin.Location = new System.Drawing.Point(224, 90);
            this.ShowMokujin.Name = "ShowMokujin";
            this.ShowMokujin.Size = new System.Drawing.Size(84, 16);
            this.ShowMokujin.TabIndex = 36;
            this.ShowMokujin.Text = "顯示木人樁";
            this.ShowMokujin.UseVisualStyleBackColor = true;
            this.ShowMokujin.CheckedChanged += new System.EventHandler(this.ShowMokujin_CheckedChanged);
            // 
            // btnViseColor
            // 
            this.btnViseColor.Location = new System.Drawing.Point(242, 53);
            this.btnViseColor.Name = "btnViseColor";
            this.btnViseColor.Size = new System.Drawing.Size(54, 31);
            this.btnViseColor.TabIndex = 35;
            this.btnViseColor.Text = "副套色";
            this.btnViseColor.UseVisualStyleBackColor = true;
            this.btnViseColor.Click += new System.EventHandler(this.btnViseColor_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(144, 33);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(33, 22);
            this.numericUpDown1.TabIndex = 34;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 31);
            this.button1.TabIndex = 32;
            this.button1.Text = "主套色";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SetColor_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 12);
            this.label13.TabIndex = 31;
            this.label13.Text = "TestScale";
            // 
            // spnTestScale
            // 
            this.spnTestScale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spnTestScale.DecimalPlaces = 4;
            this.spnTestScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.spnTestScale.Location = new System.Drawing.Point(27, 248);
            this.spnTestScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spnTestScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spnTestScale.Name = "spnTestScale";
            this.spnTestScale.Size = new System.Drawing.Size(81, 22);
            this.spnTestScale.TabIndex = 30;
            this.spnTestScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnTestScale.ValueChanged += new System.EventHandler(this.spnTestScale_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spnPivotY);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.spnPivotX);
            this.groupBox2.Location = new System.Drawing.Point(121, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 158);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pivot";
            // 
            // spnPivotY
            // 
            this.spnPivotY.Location = new System.Drawing.Point(39, 99);
            this.spnPivotY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spnPivotY.Name = "spnPivotY";
            this.spnPivotY.Size = new System.Drawing.Size(81, 22);
            this.spnPivotY.TabIndex = 32;
            this.spnPivotY.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.spnPivotY.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "X";
            // 
            // spnPivotX
            // 
            this.spnPivotX.Location = new System.Drawing.Point(39, 53);
            this.spnPivotX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spnPivotX.Name = "spnPivotX";
            this.spnPivotX.Size = new System.Drawing.Size(81, 22);
            this.spnPivotX.TabIndex = 30;
            this.spnPivotX.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.spnPivotX.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenAnimDef);
            this.groupBox1.Location = new System.Drawing.Point(15, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 60);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // btnGenAnimDef
            // 
            this.btnGenAnimDef.Location = new System.Drawing.Point(78, 23);
            this.btnGenAnimDef.Name = "btnGenAnimDef";
            this.btnGenAnimDef.Size = new System.Drawing.Size(125, 21);
            this.btnGenAnimDef.TabIndex = 17;
            this.btnGenAnimDef.Text = "Generate Anim Def";
            this.btnGenAnimDef.UseVisualStyleBackColor = true;
            this.btnGenAnimDef.Click += new System.EventHandler(this.btnGenAnimDef_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "TotalFrameCnt";
            // 
            // spnFrameCnt
            // 
            this.spnFrameCnt.Location = new System.Drawing.Point(25, 195);
            this.spnFrameCnt.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spnFrameCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnFrameCnt.Name = "spnFrameCnt";
            this.spnFrameCnt.Size = new System.Drawing.Size(81, 22);
            this.spnFrameCnt.TabIndex = 26;
            this.spnFrameCnt.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.spnFrameCnt.ValueChanged += new System.EventHandler(this.spnFrameCnt_ValueChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "Playback Speed";
            // 
            // spnPlayBackSpeed
            // 
            this.spnPlayBackSpeed.Location = new System.Drawing.Point(25, 142);
            this.spnPlayBackSpeed.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.spnPlayBackSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnPlayBackSpeed.Name = "spnPlayBackSpeed";
            this.spnPlayBackSpeed.Size = new System.Drawing.Size(81, 22);
            this.spnPlayBackSpeed.TabIndex = 24;
            this.spnPlayBackSpeed.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spnPlayBackSpeed.ValueChanged += new System.EventHandler(this.spnPlayBackSpeed_ValueChanged);
            // 
            // spnFrameHeight
            // 
            this.spnFrameHeight.Location = new System.Drawing.Point(121, 86);
            this.spnFrameHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spnFrameHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spnFrameHeight.Name = "spnFrameHeight";
            this.spnFrameHeight.Size = new System.Drawing.Size(81, 22);
            this.spnFrameHeight.TabIndex = 23;
            this.spnFrameHeight.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.spnFrameHeight.ValueChanged += new System.EventHandler(this.spnFrameHeight_ValueChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "Frame Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "Frame Width";
            // 
            // spnFrameWidth
            // 
            this.spnFrameWidth.Location = new System.Drawing.Point(25, 86);
            this.spnFrameWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spnFrameWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spnFrameWidth.Name = "spnFrameWidth";
            this.spnFrameWidth.Size = new System.Drawing.Size(81, 22);
            this.spnFrameWidth.TabIndex = 20;
            this.spnFrameWidth.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.spnFrameWidth.ValueChanged += new System.EventHandler(this.spnFrameWidth_ValueChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "Pic Index";
            // 
            // spnPicIdx
            // 
            this.spnPicIdx.Location = new System.Drawing.Point(25, 33);
            this.spnPicIdx.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnPicIdx.Name = "spnPicIdx";
            this.spnPicIdx.Size = new System.Drawing.Size(33, 22);
            this.spnPicIdx.TabIndex = 18;
            this.spnPicIdx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnPicIdx.ValueChanged += new System.EventHandler(this.spnPicIdx_ValueChanged_1);
            // 
            // spriteTextureControl
            // 
            this.spriteTextureControl.Location = new System.Drawing.Point(391, 0);
            this.spriteTextureControl.Name = "spriteTextureControl";
            this.spriteTextureControl.Size = new System.Drawing.Size(500, 380);
            this.spriteTextureControl.TabIndex = 0;
            this.spriteTextureControl.Text = "spriteTextureControl";
            // 
            // pbPreviewAnimation
            // 
            this.pbPreviewAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreviewAnimation.BackColor = System.Drawing.Color.White;
            this.pbPreviewAnimation.Location = new System.Drawing.Point(504, 63);
            this.pbPreviewAnimation.Name = "pbPreviewAnimation";
            this.pbPreviewAnimation.Size = new System.Drawing.Size(256, 256);
            this.pbPreviewAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewAnimation.TabIndex = 16;
            this.pbPreviewAnimation.TabStop = false;
            this.pbPreviewAnimation.Click += new System.EventHandler(this.pbPreviewAnimation_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitter3);
            this.tabPage2.Controls.Add(this.paSplitFill);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1008, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Split";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(203, 3);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 385);
            this.splitter3.TabIndex = 2;
            this.splitter3.TabStop = false;
            // 
            // paSplitFill
            // 
            this.paSplitFill.AllowDrop = true;
            this.paSplitFill.AutoScroll = true;
            this.paSplitFill.Controls.Add(this.pbSplit);
            this.paSplitFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paSplitFill.Location = new System.Drawing.Point(203, 3);
            this.paSplitFill.Name = "paSplitFill";
            this.paSplitFill.Size = new System.Drawing.Size(802, 385);
            this.paSplitFill.TabIndex = 1;
            this.paSplitFill.DragDrop += new System.Windows.Forms.DragEventHandler(this.paSplitFill_DragDrop);
            this.paSplitFill.DragEnter += new System.Windows.Forms.DragEventHandler(this.Generic_DragEnter);
            // 
            // pbSplit
            // 
            this.pbSplit.BackColor = System.Drawing.Color.Transparent;
            this.pbSplit.Location = new System.Drawing.Point(20, 11);
            this.pbSplit.Name = "pbSplit";
            this.pbSplit.Size = new System.Drawing.Size(100, 46);
            this.pbSplit.TabIndex = 0;
            this.pbSplit.TabStop = false;
            this.pbSplit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbSplit_MouseClick);
            this.pbSplit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_SetCoordinates);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.splitter4);
            this.panel4.Controls.Add(this.pgSplit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 385);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSplitReplaceColor);
            this.panel6.Controls.Add(this.btnSaveSplitAs);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 24);
            this.panel6.TabIndex = 2;
            // 
            // btnSplitReplaceColor
            // 
            this.btnSplitReplaceColor.Location = new System.Drawing.Point(0, 0);
            this.btnSplitReplaceColor.Name = "btnSplitReplaceColor";
            this.btnSplitReplaceColor.Size = new System.Drawing.Size(75, 23);
            this.btnSplitReplaceColor.TabIndex = 0;
            // 
            // btnSaveSplitAs
            // 
            this.btnSaveSplitAs.Location = new System.Drawing.Point(5, 3);
            this.btnSaveSplitAs.Name = "btnSaveSplitAs";
            this.btnSaveSplitAs.Size = new System.Drawing.Size(75, 21);
            this.btnSaveSplitAs.TabIndex = 0;
            this.btnSaveSplitAs.Text = "Save as...";
            this.btnSaveSplitAs.UseVisualStyleBackColor = true;
            this.btnSaveSplitAs.Click += new System.EventHandler(this.btnSaveSplitAs_Click);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter4.Location = new System.Drawing.Point(0, 24);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(200, 3);
            this.splitter4.TabIndex = 1;
            this.splitter4.TabStop = false;
            // 
            // pgSplit
            // 
            this.pgSplit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgSplit.Location = new System.Drawing.Point(0, 27);
            this.pgSplit.Name = "pgSplit";
            this.pgSplit.Size = new System.Drawing.Size(200, 358);
            this.pgSplit.TabIndex = 0;
            // 
            // tpTilePreview
            // 
            this.tpTilePreview.Controls.Add(this.splitter5);
            this.tpTilePreview.Controls.Add(this.patsRight);
            this.tpTilePreview.Controls.Add(this.patsLeft);
            this.tpTilePreview.Location = new System.Drawing.Point(4, 22);
            this.tpTilePreview.Name = "tpTilePreview";
            this.tpTilePreview.Size = new System.Drawing.Size(1008, 391);
            this.tpTilePreview.TabIndex = 4;
            this.tpTilePreview.Text = "Tiling Test";
            this.tpTilePreview.UseVisualStyleBackColor = true;
            // 
            // splitter5
            // 
            this.splitter5.Location = new System.Drawing.Point(200, 0);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(3, 391);
            this.splitter5.TabIndex = 2;
            this.splitter5.TabStop = false;
            // 
            // patsRight
            // 
            this.patsRight.AutoScroll = true;
            this.patsRight.Controls.Add(this.patsImage);
            this.patsRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patsRight.Location = new System.Drawing.Point(200, 0);
            this.patsRight.Name = "patsRight";
            this.patsRight.Size = new System.Drawing.Size(808, 391);
            this.patsRight.TabIndex = 1;
            // 
            // patsImage
            // 
            this.patsImage.AllowDrop = true;
            this.patsImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.patsImage.Location = new System.Drawing.Point(0, 0);
            this.patsImage.Name = "patsImage";
            this.patsImage.Size = new System.Drawing.Size(305, 230);
            this.patsImage.TabIndex = 1;
            this.patsImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.patsImage_DragDrop);
            this.patsImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.Generic_DragEnter);
            this.patsImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.patsImage_MouseDown);
            this.patsImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_SetCoordinates);
            // 
            // patsLeft
            // 
            this.patsLeft.Controls.Add(this.panel8);
            this.patsLeft.Controls.Add(this.splitter6);
            this.patsLeft.Controls.Add(this.panel7);
            this.patsLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.patsLeft.Location = new System.Drawing.Point(0, 0);
            this.patsLeft.Name = "patsLeft";
            this.patsLeft.Size = new System.Drawing.Size(200, 391);
            this.patsLeft.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pgTP);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 86);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 305);
            this.panel8.TabIndex = 0;
            // 
            // pgTP
            // 
            this.pgTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgTP.Location = new System.Drawing.Point(0, 0);
            this.pgTP.Name = "pgTP";
            this.pgTP.Size = new System.Drawing.Size(200, 305);
            this.pgTP.TabIndex = 0;
            // 
            // splitter6
            // 
            this.splitter6.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter6.Location = new System.Drawing.Point(0, 83);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(200, 3);
            this.splitter6.TabIndex = 1;
            this.splitter6.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btntpFill);
            this.panel7.Controls.Add(this.btntpHelp);
            this.panel7.Controls.Add(this.cbotpLayer);
            this.panel7.Controls.Add(this.btntpReset);
            this.panel7.Controls.Add(this.btntpSaveAs);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 83);
            this.panel7.TabIndex = 0;
            // 
            // btntpFill
            // 
            this.btntpFill.Location = new System.Drawing.Point(59, 3);
            this.btntpFill.Name = "btntpFill";
            this.btntpFill.Size = new System.Drawing.Size(44, 21);
            this.btntpFill.TabIndex = 2;
            this.btntpFill.Text = "Fill";
            this.btntpFill.UseVisualStyleBackColor = true;
            this.btntpFill.Click += new System.EventHandler(this.btntpFill_Click);
            // 
            // btntpHelp
            // 
            this.btntpHelp.Location = new System.Drawing.Point(8, 3);
            this.btntpHelp.Name = "btntpHelp";
            this.btntpHelp.Size = new System.Drawing.Size(45, 21);
            this.btntpHelp.TabIndex = 2;
            this.btntpHelp.Text = "Help";
            this.btntpHelp.UseVisualStyleBackColor = true;
            this.btntpHelp.Click += new System.EventHandler(this.btntpHelp_Click);
            // 
            // cbotpLayer
            // 
            this.cbotpLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotpLayer.FormattingEnabled = true;
            this.cbotpLayer.Items.AddRange(new object[] {
            "Layer 0",
            "Layer 1",
            "Layer 2",
            "Layer 3",
            "Layer 4"});
            this.cbotpLayer.Location = new System.Drawing.Point(8, 56);
            this.cbotpLayer.Name = "cbotpLayer";
            this.cbotpLayer.Size = new System.Drawing.Size(186, 20);
            this.cbotpLayer.TabIndex = 1;
            // 
            // btntpReset
            // 
            this.btntpReset.Location = new System.Drawing.Point(109, 3);
            this.btntpReset.Name = "btntpReset";
            this.btntpReset.Size = new System.Drawing.Size(85, 21);
            this.btntpReset.TabIndex = 1;
            this.btntpReset.Text = "Reset";
            this.btntpReset.UseVisualStyleBackColor = true;
            this.btntpReset.Click += new System.EventHandler(this.btntpReset_Click);
            // 
            // btntpSaveAs
            // 
            this.btntpSaveAs.Location = new System.Drawing.Point(8, 30);
            this.btntpSaveAs.Name = "btntpSaveAs";
            this.btntpSaveAs.Size = new System.Drawing.Size(186, 21);
            this.btntpSaveAs.TabIndex = 0;
            this.btntpSaveAs.Text = "Save as...";
            this.btntpSaveAs.UseVisualStyleBackColor = true;
            this.btntpSaveAs.Click += new System.EventHandler(this.btntpSaveAs_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rtbAbout);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1008, 391);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtbAbout
            // 
            this.rtbAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAbout.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAbout.Location = new System.Drawing.Point(3, 3);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.Size = new System.Drawing.Size(1002, 385);
            this.rtbAbout.TabIndex = 1;
            this.rtbAbout.Text = "ERROR: Failed to load ReadMe.txt";
            // 
            // ss1
            // 
            this.ss1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbl1});
            this.ss1.Location = new System.Drawing.Point(0, 1);
            this.ss1.Name = "ss1";
            this.ss1.Size = new System.Drawing.Size(1016, 22);
            this.ss1.TabIndex = 7;
            this.ss1.Text = "statusStrip1";
            // 
            // tslbl1
            // 
            this.tslbl1.Name = "tslbl1";
            this.tslbl1.Size = new System.Drawing.Size(38, 17);
            this.tslbl1.Text = "tslbl1";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.ss1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 417);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1016, 23);
            this.panel9.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 440);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "= MK = Sprite Sheet Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.paMergeFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSheet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpFlashIt.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.paPreviewFill.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnTestScale)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnPivotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPivotX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnFrameCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPlayBackSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrameHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrameWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPicIdx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewAnimation)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.paSplitFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSplit)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tpTilePreview.ResumeLayout(false);
            this.patsRight.ResumeLayout(false);
            this.patsLeft.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ss1.ResumeLayout(false);
            this.ss1.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.SaveFileDialog sfd1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboExt;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFrameHeight;
        private System.Windows.Forms.TextBox txtFrameWidth;
        private System.Windows.Forms.TextBox txtFrameCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstImages;
        private System.Windows.Forms.Button btnOpenFiles;
        private System.Windows.Forms.PictureBox pbSheet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timPreview;
        private System.Windows.Forms.Timer timFPS;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel paMergeFill;
        private System.Windows.Forms.Button btnDelImage;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel paSplitFill;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PropertyGrid pgSplit;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.PictureBox pbSplit;
        private System.Windows.Forms.Button btnSaveSplitAs;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ImageList imgList16px;
        private System.Windows.Forms.RichTextBox rtbAbout;
        private System.Windows.Forms.CheckBox chkAutoSortLstImages;
        private System.Windows.Forms.Button btnClearAllMerge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMergeRowCnt;
        private System.Windows.Forms.ComboBox cboMergeCurrentRow;
        private System.Windows.Forms.TabPage tpTilePreview;
        private System.Windows.Forms.Splitter splitter5;
        private System.Windows.Forms.Panel patsRight;
        private System.Windows.Forms.Panel patsLeft;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PropertyGrid pgTP;
        private System.Windows.Forms.Splitter splitter6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btntpSaveAs;
        private System.Windows.Forms.Button btntpReset;
        private System.Windows.Forms.ComboBox cbotpLayer;
        private System.Windows.Forms.Panel patsImage;
        private System.Windows.Forms.Button btntpHelp;
        private System.Windows.Forms.Button btntpFill;
        private System.Windows.Forms.StatusStrip ss1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ToolStripStatusLabel tslbl1;
        private System.Windows.Forms.Button btnSplitReplaceColor;
        private System.Windows.Forms.TabPage tpFlashIt;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnFlashItSaveAs;
        private System.Windows.Forms.CheckBox chkKeepAS;
        private System.Windows.Forms.Panel paPreviewFill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown spnFrameCnt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown spnPlayBackSpeed;
        private System.Windows.Forms.NumericUpDown spnFrameHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown spnFrameWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown spnPicIdx;
        private System.Windows.Forms.Button btnGenAnimDef;
        private System.Windows.Forms.PictureBox pbPreviewAnimation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown spnPivotY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown spnPivotX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown spnTestScale;
        private System.Windows.Forms.Button button1;
        //XNA Frame
        private SpriteTexControl spriteTextureControl;
        private System.Windows.Forms.CheckBox ShowMokujin;
        private System.Windows.Forms.Button btnViseColor;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox chkUseMask;
    }
}

