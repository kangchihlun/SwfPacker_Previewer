using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows;
//using DefaultProperties;
//using System.Windows.Controls;

namespace SpriteSheetEditor
{

    public partial class frmMain : Form
    {
        #region Members
        public Bitmap bm = null;
        //PreviewProperty PP;
        SplitProperty SP;
        TilePreviewProperty TPP;
        //Thread PreviewThread;
        private BackgroundWorker bw = new BackgroundWorker();

        List<MergeRow> MergeRows = new List<MergeRow>() { new MergeRow(0) };
        int MergeLastSelRow = 0;
        //private bool bMousePivoting = false; // 滑鼠按壓下去可設定Pivot位置
        public Color shiftedColor = Color.FromArgb(50,200,200,200); //偏色的顏色,設定ㄧ下初始化
        public Color shiftedColorVice = Color.FromArgb(50, 200, 200, 200); //副套色的顏色,設定ㄧ下初始化
        private string swfFilePath=null;//是否build過swf,有值才會輸出正確的swfpath
        #endregion

        #region Form
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Statusstrip
            tslbl1.Text = string.Empty;
            //tslbl2.Text = string.Empty;
            CheckForIllegalCrossThreadCalls = false; //跨執行緒修改ui簡單解
            ToolTip tp = new ToolTip();
            
            
            // Folders
            if (!Directory.Exists(Global.PREVIEW_FOLDER))
                Directory.CreateDirectory(Global.PREVIEW_FOLDER);

            // Merge
            cboMergeCurrentRow.SelectedIndex = cboExt.SelectedIndex = 0;
            btnMoveDown.Enabled = btnMoveUp.Enabled = !chkAutoSortLstImages.Checked;
            lstImages.Sorted = chkAutoSortLstImages.Checked;
            tp.SetToolTip(txtMergeRowCnt, "The number of rows in the spritesheet.");
            tp.SetToolTip(txtFrameCnt, "The number of frames per row in the spritesheet.");
            tp.SetToolTip(btnDelImage, "Remove selected frame from the list.");
            tp.SetToolTip(btnClearAllMerge, "Remove all frames from all rows from the list.");
            tp.SetToolTip(chkAutoSortLstImages, "When checked: sorts the images in the merge list by name. Uncheck me to enable the sort buttons.");

            // Split
            SP = new SplitProperty(ref pbSplit);
            pgSplit.SelectedObject = SP;

            // Preview animation
            // 原本的動態圖更新
            //PP = new PreviewProperty(ref pbPreviewAnimation);
            ////pgPreview.SelectedObject = PP;
            //PreviewThread = new Thread(() => { PP.Run(); });
            //PreviewThread.Start();

            // 現在改成交由SpriteTexControl去更新
            //PreviewThread = new Thread(() => { this.spriteTextureControl.update(); });
            //PreviewThread.Start();
            //


            //設定軸心顯示
            //this.pivot.Parent = this.pbPreviewAnimation;
            //this.pivot.Parent = this.spriteTextureControl;
            //this.pivot.Location = new System.Drawing.Point(56,120);
            //Bitmap bm = new Bitmap(@"Plus_numeric.png");
            ////bm.MakeTransparent(Color.FromArgb(255, 255, 255));
            //this.pivot.Image = bm;
            
            
            //背景圖
            Bitmap bg = new Bitmap(@"Scene.png");
            paPreviewFill.BackgroundImage = bg;
            
            // TPP
            TPP = new TilePreviewProperty(ref patsImage, ref cbotpLayer);
            pgTP.SelectedObject = TPP;
            cbotpLayer.SelectedIndex = 0;
            tp.SetToolTip(btntpFill, "Fills the selected layer with the selected image. Note that it fills acording to the image size and it will disregard the grid size.");
            tp.SetToolTip(btntpReset, "Resets all layers (to transparent).");
            tp.SetToolTip(cbotpLayer, "Set the active layer.");

            // Flash it
            //cboFlashItStep.SelectedIndex = 4;

            // About
            try
            {
                rtbAbout.Text = System.IO.File.ReadAllText("ReadMe.txt");
            }
            catch { }

            // Title
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //Text = string.Format("Napoleon's Sprite Sheet Editor (version {0})", version);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //PreviewThread.Abort();

            if (bm != null)
                bm.Dispose();
            SP.Dispose();
            //this.Close();
            //PP.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        #endregion

        #region Merge
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() != DialogResult.Cancel)
            {
                for (int i = 0; i < ofd1.FileNames.Count(); i++)
                {
                    lstImages.Items.Add(new ImgInfo(ofd1.SafeFileNames[i], ofd1.FileNames[i] ,128,128,8,50 ) );
                    CheckForLstFirstItem();
                }
                RefreshMergeSheet();

                ////更新所有的img到listImages裡面(避免AnimDef 出錯)
                for (int i = 0; i < lstImages.Items.Count; i++)
                {
                    ImgInfo img = (ImgInfo)(lstImages.Items[i]);
                    Bitmap im = Util.LoadBMPNoLock(img.FullPath);
                    //Bitmap ret = ImageUtilities.MultiplyColor((Bitmap)im, shiftedColor);
                    img.color = Color.FromArgb(50, 200, 200, 200);
                    img.Img = im;
                }
            }
        }

        /// <summary>
        /// Call this function after adding one frame to the lstImages.
        /// </summary>
        private void CheckForLstFirstItem()
        {
            if (lstImages.Items.Count == 1)
            {
                ImgInfo info = (ImgInfo)lstImages.Items[0];
                Image img = Util.LoadBMPNoLock(info.FullPath);
                txtFrameWidth.Text = img.Width.ToString();
                txtFrameHeight.Text = img.Height.ToString();
                img.Dispose();
            }
        }

        private void RefreshMergeSheet()
        {
            SaveListBoxToMerge();

            int frameWidth = int.Parse(txtFrameWidth.Text);
            int frameHeight = int.Parse(txtFrameHeight.Text);

            New();
            Graphics g = Graphics.FromImage(bm);
            g.Clear(Color.Transparent);
            for (int rowIdx = 0; rowIdx < int.Parse(txtMergeRowCnt.Text); rowIdx++)
            {
                MergeRow currentMergeRow = MergeRows.Find(m => m.Index == rowIdx);

                for (int i = 0; i < currentMergeRow.ImageInfos.Count; i++)
                {
                    Bitmap frame = new Bitmap(Util.LoadBMPNoLock((currentMergeRow.ImageInfos[i]).FullPath));

                    g.DrawImage(frame, new Rectangle(i * frameWidth, rowIdx * frameHeight, frameWidth, frameHeight));
                    frame.Dispose();
                }
            }

            pbSheet.Size = new System.Drawing.Size(bm.Width, bm.Height);

            // Clean up
            g.Dispose();
        }

        private void New()
        {
            bm = new Bitmap(int.Parse(txtFrameWidth.Text) * int.Parse(txtFrameCnt.Text), int.Parse(txtFrameHeight.Text) * int.Parse(txtMergeRowCnt.Text));
            pbSheet.Image = bm;
            //PP.Image = new Bitmap(int.Parse(txtFrameWidth.Text) * int.Parse(txtFrameCnt.Text), int.Parse(txtFrameHeight.Text) * int.Parse(txtMergeRowCnt.Text));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshMergeSheet();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            ImageFormat imgFormat;
            switch (cboExt.SelectedIndex)
            {
                case 0:
                    imgFormat = ImageFormat.Png;
                    sfd1.Filter = "PNG (*.png)|*.png";
                    break;
                case 1:
                    imgFormat = ImageFormat.Bmp;
                    sfd1.Filter = "BMP (*.bmp)|*.bmp";
                    break;
                case 2:
                    imgFormat = ImageFormat.Jpeg;
                    sfd1.Filter = "JPG (*.jpg)|*.jpg";
                    break;
                default:
                    throw new Exception("case missing");
            }

            if (sfd1.ShowDialog() != DialogResult.Cancel)
                bm.Save(sfd1.FileName, imgFormat);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedIndex > 0)
            {
                object temp = lstImages.SelectedItem;
                int selIdx = lstImages.SelectedIndex;
                lstImages.Items.RemoveAt(lstImages.SelectedIndex);
                lstImages.Items.Insert(selIdx - 1, temp);
                lstImages.SelectedIndex = selIdx - 1;
                RefreshMergeSheet();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedIndex != -1 && lstImages.SelectedIndex < lstImages.Items.Count - 1)
            {
                object temp = lstImages.SelectedItem;
                int selIdx = lstImages.SelectedIndex;
                lstImages.Items.RemoveAt(lstImages.SelectedIndex);
                lstImages.Items.Insert(selIdx + 1, temp);
                lstImages.SelectedIndex = selIdx + 1;
                RefreshMergeSheet();
            }
        }

        private void btnDelImage_Click(object sender, EventArgs e)
        {
            while (lstImages.SelectedItems.Count > 0)
                lstImages.Items.RemoveAt(lstImages.SelectedIndices[0]);
        }

        private void Merge_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (!Util.IsInteger(txb.Text))
            {
                txb.Text = "1";
            }
            else
            {
                if (int.Parse(txb.Text) < 1)
                    txb.Text = "1";
            }

            RefreshMergeSheet();
        }

        #region DragAndDrop merge
        private void lstImages_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            else
                e.Effect = System.Windows.Forms.DragDropEffects.None;
        }

        private void lstImages_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                lstImages.Items.Add(new ImgInfo(Path.GetFileName(s[i]), s[i]  ,128,128,8,50 ));
                CheckForLstFirstItem();
            }

            RefreshMergeSheet();
        }
        #endregion

        private void chkAutoSortLstImages_CheckedChanged(object sender, EventArgs e)
        {
            btnMoveDown.Enabled = btnMoveUp.Enabled = !chkAutoSortLstImages.Checked;
            lstImages.Sorted = chkAutoSortLstImages.Checked;
            RefreshMergeSheet();
        }

        private void btnClearAllMerge_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to clear all merge-images in the currently selected row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lstImages.Items.Clear();
                swfFilePath = null;
                RefreshMergeSheet();
            }
        }

        private void txtMergeRowCnt_TextChanged(object sender, EventArgs e)
        {
            // Input validation
            if (!Util.IsInteger(txtMergeRowCnt.Text) || (int.Parse(txtMergeRowCnt.Text) < 1 && int.Parse(txtMergeRowCnt.Text) > 999))
                txtMergeRowCnt.Text = "1";

            cboMergeCurrentRow.Items.Clear();
            for (int i = 0; i < int.Parse(txtMergeRowCnt.Text); i++)
            {
                cboMergeCurrentRow.Items.Add(i.ToString());
            }
            cboMergeCurrentRow.SelectedIndex = 0;

            // Create missing ones
            while (int.Parse(txtMergeRowCnt.Text) >= MergeRows.Count)
            {
                MergeRow mergeRow = new MergeRow(MergeRows.Count - 1);
                MergeRows.Add(mergeRow);
            }

            RefreshMergeSheet();
        }

        void SaveListBoxToMerge()
        {
            // save
            MergeRow mergeRow = MergeRows.Find(m => m.Index == MergeLastSelRow);
            mergeRow.ImageInfos.Clear();
            foreach (ImgInfo imgInfo in lstImages.Items)
                mergeRow.ImageInfos.Add(imgInfo);
        }

        private void cboMergeCurrentRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newIdx = int.Parse(cboMergeCurrentRow.Text);

            SaveListBoxToMerge();

            // load
            MergeRow mergeRow = MergeRows.Find(m => m.Index == newIdx);
            lstImages.Items.Clear();
            foreach (ImgInfo imgInfo in mergeRow.ImageInfos)
                lstImages.Items.Add(imgInfo);

            MergeLastSelRow = newIdx;
        }

        private void btntpReset_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to reset all layers?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                TPP.Reset();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Split
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnSaveSplitAs_Click(object sender, EventArgs e)
        {
            if (SP.Image != null)
            {
                SaveFileDialog sfdSplit = new SaveFileDialog();
                sfdSplit.Filter = "Png|*.png|JPeg Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|All files (*.*)|*.*";
                if (sfdSplit.ShowDialog() != DialogResult.Cancel)
                    SP.SaveAs(sfdSplit.FileName);
                sfdSplit = null;
            }
            else
                System.Windows.Forms.MessageBox.Show("You must load an image to split first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void paSplitFill_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
            SP.Image = Util.LoadBMPNoLock(s[0]);

            pgSplit.Refresh();
        }

        //private void btnSplitReplaceColor_Click(object sender, EventArgs e)
        //{
        //    frmSelectReplaceColor frmSelectReplaceColor = new SpriteSheetEditor.frmSelectReplaceColor(SP.NewReplaceColor , this);
        //    SP.IsReplacing = frmSelectReplaceColor.ShowDialog() == DialogResult.OK;
        //    if (SP.IsReplacing)
        //        SP.NewReplaceColor = frmSelectReplaceColor.SelectedColor;
        //}

        private void pbSplit_MouseClick(object sender, MouseEventArgs e)
        {
            if (SP.IsReplacing)
            {
                SP.Image.ReplaceColor(Util.GetScreenPixel(Cursor.Position), SP.NewReplaceColor);
                SP.RefreshSplit();
                SP.IsReplacing = false;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Preview
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private void paPreviewFill_DragDrop(object sender, DragEventArgs e)
        //{
        //    string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        //    PP.Image = Util.LoadBMPNoLock(s[0]);

        //    pgPreview.Refresh();
        //}

        private void btnUseMergeForPreview_Click(object sender, EventArgs e)
        {
            if (lstImages.Items.Count > 0)
            {
                // Frame cnt
                //PP.FrameCount = int.Parse(txtFrameCnt.Text) * int.Parse(txtMergeRowCnt.Text);

                // Clear the preview folder
                if (File.Exists(Global.PREVIEW_PATH))
                {
                    // Delete the previous temp file
                    File.Delete(Global.PREVIEW_PATH);
                }
                bm.Save(Global.PREVIEW_PATH, ImageFormat.Png); // Save temp image
                //PP.Image = Util.LoadBMPNoLock(Global.PREVIEW_PATH); // Load temp image

                //// Frame width & height
                //PP.FrameWidth = int.Parse(txtFrameWidth.Text);
                //PP.FrameHeight = int.Parse(txtFrameHeight.Text);

                // Refresh to show the newly set values
               // pgPreview.Refresh();
            }
            else
                System.Windows.Forms.MessageBox.Show("There are no items in the merge-tab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Tiling Test
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btntpSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdTP = new SaveFileDialog();
            sfdTP.Filter = "Png|*.png|JPeg Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (sfdTP.ShowDialog() != DialogResult.Cancel)
                TPP.SaveAs(sfdTP.FileName);
            sfdTP = null;
        }

        private void patsImage_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop, false);
            for (int i = 0; i < s.Length; i++)
            {
                if (Util.IsImage(s[i]))
                {
                    System.Drawing.Point c = patsImage.PointToClient(Cursor.Position);
                    TPP.AddImage(new System.Drawing.Point(c.X + patsImage.HorizontalScroll.Value, c.Y + patsImage.VerticalScroll.Value), Util.LoadBMPNoLock(s[i]));
                }
            }
        }

        private void patsImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (TPP.Image != null)
                {
                    System.Drawing.Point c = patsImage.PointToClient(Cursor.Position);
                    TPP.AddImage(new System.Drawing.Point(c.X + patsImage.HorizontalScroll.Value, c.Y + patsImage.VerticalScroll.Value), TPP.Image);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                System.Drawing.Point c = patsImage.PointToClient(Cursor.Position);
                TPP.DelSection(new System.Drawing.Point(c.X + patsImage.HorizontalScroll.Value, c.Y + patsImage.VerticalScroll.Value));
            }
        }

        private void btntpHelp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Left mouse button: Place image." + Environment.NewLine + "Right mouse button: delete the tile underneath the mouse cursor for the selected layer." + Environment.NewLine + "Drag & Drop of images onto the grid is allowed.");
        }

        private void btntpFill_Click(object sender, EventArgs e)
        {
            if (TPP.Image == null)
                System.Windows.Forms.MessageBox.Show("You must set an image in the property grid first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TPP.FillCurrentLayer(TPP.Image);
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Shared
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void MouseMove_SetCoordinates(object sender, MouseEventArgs e)
        {
            System.Drawing.Point p = ((Control)sender).PointToClient(Cursor.Position);
            tslbl1.Text = string.Format("X:{0} Y:{0}", p.X, p.Y);
        }

        private void Generic_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
                e.Effect = System.Windows.Forms.DragDropEffects.All;
            else
                e.Effect = System.Windows.Forms.DragDropEffects.None;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Flash It
        //public void FlashIt_Refresh()
        //{
            //if (pbFlashItSourceImg.Image != null)
            //{
            //    int stepSize = int.Parse(cboFlashItStep.Text);
            //    int currentStep = 100;
            //    int frameCnt = 100 / stepSize;

            //    // Create the new sheet (empty)
            //    Bitmap newSheet = new Bitmap(frameCnt * pbFlashItSourceImg.Image.Width, pbFlashItSourceImg.Image.Height);

            //    using (var g = Graphics.FromImage(newSheet))
            //    {
            //        // Set the background color
            //        if (chkFlashItTransBG.Checked)
            //            g.Clear(Color.Transparent);
            //        else
            //            g.Clear(paFlashItFillColor.BackColor);

            //        // From opaque -> transparant
            //        for (int x = 0; x < frameCnt; x++)
            //        {
            //            Image temp = new Bitmap(pbFlashItSourceImg.Image);
            //            temp = Util.SetImageOpacity(temp, currentStep);
            //            g.DrawImage(temp, new Point(x * pbFlashItSourceImg.Image.Width, 0));
            //            temp.Dispose();
            //            currentStep -= stepSize;
            //        }
            //    }

                //if (chkFlashItMirror.Checked)
                //{ // And back from transparant -> opaque
                //    Bitmap sheet = new Bitmap(newSheet);
                //    newSheet = new Bitmap(frameCnt * pbFlashItSourceImg.Image.Width * 2 - pbFlashItSourceImg.Image.Width, pbFlashItSourceImg.Image.Height);

                //    using (var g = Graphics.FromImage(newSheet))
                //    {
                //        // Set the background color
                //        if (chkFlashItTransBG.Checked)
                //            g.Clear(Color.Transparent);
                //        else
                //            g.Clear(paFlashItFillColor.BackColor);

                //        // Draw the previous drawing back onto the new sheet
                //        using (var g2 = Graphics.FromImage(newSheet))
                //        {
                //            g2.DrawImage(sheet, Point.Empty);
                //        }

                //        // Get the start location X for the new drawings
                //        int startLocX = sheet.Width - pbFlashItSourceImg.Image.Width;

                //        // Dispose the temporary sheet
                //        sheet.Dispose();

                //        currentStep = stepSize * 2; // skip the first step
                //        for (int x = 1; x < frameCnt; x++)
                //        {
                //            Image temp = new Bitmap(pbFlashItSourceImg.Image);
                //            temp = Util.SetImageOpacity(temp, currentStep);
                //            g.DrawImage(temp, new Point(startLocX + x * pbFlashItSourceImg.Image.Width, 0));
                //            temp.Dispose();
                //            currentStep += stepSize;
                //        }
                //    }
                //}

                // More clean up (is this necessary?)
        //        if (pbFlashItSheet.Image != null)
        //        {
        //            pbFlashItSheet.Image.Dispose();
        //            pbFlashItSheet.Image = null;
        //        }

        //        // Assign the new sheet to the picturebox and refresh it
        //        pbFlashItSheet.Image = newSheet;
        //        pbFlashItSheet.Refresh();

        //        // Set the frame count
        //        lblFlashItFrameCnt.Text = (newSheet.Width / pbFlashItSourceImg.Image.Width).ToString();
        //    }
        //}

        //private void btnFlashItBrowse_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog dialog = Util.CreateOpenFileDialog();

        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        pbFlashItSourceImg.Image = Util.LoadBMPNoLock(dialog.FileName);
        //        FlashIt_Refresh();
        //    }
        //}

        //private void paFlashItFillColor_Click(object sender, EventArgs e)
        //{
        //    ColorDialog dialog = new ColorDialog();
        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        paFlashItFillColor.BackColor = dialog.Color;
        //        FlashIt_Refresh();
        //    }
        //}

        //private void chkFlashItTransBG_CheckedChanged(object sender, EventArgs e)
        //{
        //    lblFlashItBGColor.Visible = paFlashItFillColor.Visible = !chkFlashItTransBG.Checked;
        //    FlashIt_Refresh();
        //}

        //private void chkFlashItMirror_CheckedChanged(object sender, EventArgs e)
        //{
        //    FlashIt_Refresh();
        //}

        //private void cboFlashItStep_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    FlashIt_Refresh();
        //}

        private void btnFlashItSaveAs_Click(object sender, EventArgs e)
        {
            if (lstImages.Items.Count > 0)
            {
                SaveFileDialog dialog = Util.CreateSaveFileSWFDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    List<ImgInfo> AllImgs = new List<ImgInfo>();
                    foreach( ImgInfo img in lstImages.Items)
                        AllImgs.Add( (ImgInfo)img);
                    SwfFile _swfFile = new SwfFile(dialog.FileName, AllImgs, (!chkKeepAS.Checked) );
                    _swfFile.BuildSwf();
                    swfFilePath = dialog.FileName;
                }
            }
            /*
             *          OBSOLETE 
             */
            //if (pbFlashItSourceImg.Image != null)
            //{
            //    SaveFileDialog dialog = Util.CreateSaveFileDialog();
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            string ext = Path.GetExtension(dialog.FileName);
            //            ImageFormat imageFormat;

            //            switch (ext.ToLower())
            //            {
            //                case ".jpg":
            //                    imageFormat = ImageFormat.Jpeg;
            //                    break;
            //                case ".jpeg":
            //                    imageFormat = ImageFormat.Jpeg;
            //                    break;
            //                case ".bmp":
            //                    imageFormat = ImageFormat.Bmp;
            //                    break;
            //                case ".gif":
            //                    imageFormat = ImageFormat.Gif;
            //                    break;
            //                case ".png":
            //                    imageFormat = ImageFormat.Png;
            //                    break;
            //                default:
            //                    MessageBox.Show(string.Format("btnFlashItSaveAs_Click: Unknown extension: {0}", ext), "Save failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //            }

            //            pbFlashItSheet.Image.Save(dialog.FileName, imageFormat);
            //            MessageBox.Show("Save succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.ToString(), "Save failed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("There is nothing to save.", "Nothing to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion

        private void update_PbSize()
        {
            //this.pbPreviewAnimation.Width = (int)(PP.FrameWidth * PP._scale_);
            //this.pbPreviewAnimation.Height = (int)(PP.FrameHeight * PP._scale_);
        }

        private void spnPicIdx_ValueChanged_1(object sender, EventArgs e)
        {
            int PicIdx = (int)spnPicIdx.Value;
            if (lstImages.Items.Count > 0)
            {
                if (PicIdx > lstImages.Items.Count)
                {
                    PicIdx %= lstImages.Items.Count;
                    spnPicIdx.Value = PicIdx;
                }
                if (PicIdx < 1)
                {
                    spnPicIdx.Value = lstImages.Items.Count;
                }
                //ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                //img.Img = Util.LoadBMPNoLock(img.FullPath);
                //PP.Image = img.Img;
                // 讀回color
                ImgInfo img = (ImgInfo)(lstImages.Items[(int)spnPicIdx.Value-1]);
                shiftedColor = img.color;
                setColorShifting(); 



                //更新底下的spinner
                spnFrameWidth.Value = img.FrameWidth;
                spnFrameHeight.Value = img.FrameHeight;
                spnFrameCnt.Value = img.FrameCount;
                spnPlayBackSpeed.Value = (int)img.playbackSpeed;

                spnPivotX.Value = (int)img.Pivot.X;
                spnPivotY.Value = (int)img.Pivot.Y;
                setPivotLocation();
            }
        }

        private void spnFrameWidth_ValueChanged_1(object sender, EventArgs e)
        {
            int _width = (int)spnFrameWidth.Value;
            //PP.FrameWidth = _width;
            //pbPreviewAnimation.Width = (int)(PP.FrameWidth * spnTestScale.Value);
            spriteTextureControl.previewSpriteAP.m_FrameWidth = _width;
            spriteTextureControl.previewSpriteAP.m_DrawRect.Width = _width;

            //存入imgInfo
            int PicIdx = (int)spnPicIdx.Value;
            if (lstImages.Items.Count > 0)
            {
                ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                img.FrameWidth = _width;
            }
            spnPivotX.Maximum = _width;

        }

        private void spnFrameHeight_ValueChanged_1(object sender, EventArgs e)
        {
            int _height = (int)spnFrameHeight.Value;
            //PP.FrameHeight = _height;
            //pbPreviewAnimation.Height = (int)(PP.FrameHeight * spnTestScale.Value);
            spriteTextureControl.previewSpriteAP.m_FrameHeight = _height;
            spriteTextureControl.previewSpriteAP.m_DrawRect.Height = _height;

            //存入imgInfo
            int PicIdx = (int)spnPicIdx.Value;
            if (lstImages.Items.Count > 0)
            {
                ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                img.FrameHeight = _height;
            }
            spnPivotY.Maximum = _height;
        }

        private void spnFrameCnt_ValueChanged_1(object sender, EventArgs e)
        {
            int _frameCnt = (int)spnFrameCnt.Value;
            //PP.FrameCount = _frameCnt;
            spriteTextureControl.previewSpriteAP.m_FrameCount = _frameCnt-1;
            //存入imgInfo
            int PicIdx = (int)spnPicIdx.Value;
            if (lstImages.Items.Count > 0)
            {
                ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                img.FrameCount = _frameCnt;
            }
        }
        private void onPreviewClick(object sender, EventArgs e)
        {
            int _currActivePanelIdx_ = this.tabControl1.SelectedIndex;
            if (_currActivePanelIdx_ == 2)
            {
                spnPivotX.Maximum = 128;
                spnPivotY.Maximum = 128;
               //setPivotLocation();
                //setColorShifting();
                int PicIdx = (int)spnPicIdx.Value;
                if (lstImages.Items.Count > 0)
                {
                    ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                    setColorShifting();
                    //PP.Image = Util.LoadBMPNoLock(img.FullPath);
                }
                //更新pb frame size
                //PP.FrameWidth = (int)spnFrameWidth.Value;
                //pbPreviewAnimation.Width = (int)(PP.FrameWidth * spnTestScale.Value);

                //PP.FrameHeight = (int)spnFrameHeight.Value;
                //pbPreviewAnimation.Height = (int)(PP.FrameHeight * spnTestScale.Value);
                //PP.FrameCount = (int)spnFrameCnt.Value;
            }

        }
        private void paPreviewFill_Paint(object sender, PaintEventArgs e)
        {
            
            base.OnPaint(e);
            //e.Graphics.DrawRectangle(
            //Pens.Gainsboro,//設定顏色
            //e.ClipRectangle.Left,
            //e.ClipRectangle.Top,
            //e.ClipRectangle.Width - 1,
            //e.ClipRectangle.Height - 1);

            ////更新會太重，先拿掉
            ////setColorShifting();
            ////int PicIdx = (int)spnPicIdx.Value;
            ////if (lstImages.Items.Count > 0)
            ////{
            ////    ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
            ////    PP.Image = Util.LoadBMPNoLock(img.FullPath);
            ////}

            //spnPivotX.Maximum = 128;
            //spnPivotY.Maximum = 128;
            //setPivotLocation();

            ////更新pb frame size
            //PP.FrameWidth = (int)spnFrameWidth.Value;
            //pbPreviewAnimation.Width = (int)(PP.FrameWidth * spnTestScale.Value);

            //PP.FrameHeight= (int)spnFrameHeight.Value;
            //pbPreviewAnimation.Height = (int)(PP.FrameHeight * spnTestScale.Value);
            
        }



        private void spnPlayBackSpeed_ValueChanged(object sender, EventArgs e)
        {
            int _playbackSpeed = (int)spnPlayBackSpeed.Value;
            //PP.playbackSpeed = _playbackSpeed;
            spriteTextureControl.setCurPlayRate(_playbackSpeed);
            //存入imgInfo
            int PicIdx = (int)spnPicIdx.Value;
            if (lstImages.Items.Count > 0)
            {
                ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                img.playbackSpeed = _playbackSpeed;
            }
        }

        private void pivot_Click(object sender, EventArgs e)
        {

        }
        //private void onMousePivotModeDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    bMousePivoting = true;
        //}
        //private void onMousePivotModeUp(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    bMousePivoting = false;
        //}
        private void movePivot(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //if (bMousePivoting)
            //{
            //    int __x = e.X;
            //    int __y = e.Y;
            //    int icoWidth = this.pivot.Image.Width / 2;
            //    int icoHeight = this.pivot.Image.Height / 2;
            //    if (__x >= spnFrameWidth.Value * spnTestScale.Value)
            //        __x = (int)(spnFrameWidth.Value * spnTestScale.Value);
            //    if (__x <= 0)
            //        __x = 0;
            //    if (__y >= spnFrameHeight.Value * spnTestScale.Value)
            //        __y = (int)(spnFrameHeight.Value * spnTestScale.Value);
            //    if (__y <= 0)
            //        __y = 0;
            //    if (chkSnap.Checked)
            //    {
            //        //找尋最接近的snap 倍數，視覺上Pivot 要跟著scale跑動
            //        __x = findClosestSnapNum(__x, (int)( snapNthPixel.Value * spnTestScale.Value));
            //        __y = findClosestSnapNum(__y, (int)( snapNthPixel.Value * spnTestScale.Value));
            //    }
            //    this.pivot.Location = new System.Drawing.Point(__x - icoWidth, __y - icoHeight);

            //    //更新回spinner數值
            //    __x  = (int)(((float)__x ) / ((float)spnTestScale.Value));
            //    __y  = (int)(((float)__y) / ((float)spnTestScale.Value));
            //    if (chkSnap.Checked)
            //    {
            //        __x = findClosestSnapNum(__x, (int)(snapNthPixel.Value)); //spinner 顯示的數值要正確的snap
            //        __y = findClosestSnapNum(__y, (int)(snapNthPixel.Value)); //spinner 顯示的數值要正確的snap
            //    }
            //    spnPivotX.Value = __x;
            //    spnPivotY.Value = __y;

            //    //存入imgInfo
            //    int PicIdx = (int)spnPicIdx.Value;
            //    if (lstImages.Items.Count > 0)
            //    {
            //        ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
            //        img.Pivot = new System.Drawing.Point(__x, __y);
            //    }
            //}
        }
        private int findClosestSnapNum(int inputNum, int incrementNum)
        {
            if(inputNum == 0)return 0;
            int _mnt_ = inputNum/incrementNum;
            int remain = inputNum % incrementNum;
            if (remain > (incrementNum / 2))
                _mnt_ += 1;
            return _mnt_ * incrementNum;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            setPivotLocation();
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            setPivotLocation();
        }
        private void setPivotLocation()
        {
            int __x = (int)spnPivotX.Value;
            int __y = (int)spnPivotY.Value;
            //updatePivotVisually();
            spriteTextureControl.setCurPreviewSpPivot(__x, __y);

            //存入imgInfo
            int PicIdx = (int)spnPicIdx.Value;
            if (lstImages.Items.Count > 0)
            {
                ImgInfo img = (ImgInfo)lstImages.Items[PicIdx - 1];
                img.Pivot = new System.Drawing.Point(__x, __y);
            }
        }

        private void spnTestScale_ValueChanged(object sender, EventArgs e)
        {
            //SizeF _size_ = new SizeF((float)spnTestScale.Value,(float)spnTestScale.Value);
            //this.PP._scale_ = (float)spnTestScale.Value;
            spriteTextureControl.previewSpriteAP.m_scale_ = (float)spnTestScale.Value;

            //pbPreviewAnimation.Width = (int)(PP.FrameWidth * spnTestScale.Value);
            //pbPreviewAnimation.Height = (int)(PP.FrameHeight * spnTestScale.Value);
            

            ////更新pb的位置，看起來是對到Pivot
            //int pivMoveRefHor = (int)( (1.0f - (float)spnTestScale.Value ) * (float)spnPivotX.Value);
            //int pivMoveRefVert = (int)((1.0f - (float)spnTestScale.Value ) * (float)spnPivotY.Value);
            //System.Drawing.Point origPos = new System.Drawing.Point(504, 63);
            //int newPosHor = origPos.X + pivMoveRefHor;
            //int newPosVert = origPos.Y + pivMoveRefVert;
            //pbPreviewAnimation.Location = new System.Drawing.Point(newPosHor, newPosVert);
            ////pbPreviewAnimation.Refresh();
            //paPreviewFill.Refresh();

            //updatePivotVisually();
        }
        private void updatePivotVisually()
        { 
            ////更新pivot 視覺上的位置
            //spnPivotX.Maximum = (int)( ((float)spnTestScale.Value )*(float)spnFrameWidth.Value );
            //spnPivotY.Maximum = (int)( ((float)spnTestScale.Value )*(float)spnFrameHeight.Value );
            //新的位置 = 放大縮小後
            //int icoWidth = this.pivot.Image.Width / 2;
            //int icoHeight = this.pivot.Image.Height / 2;
            //int __x = (int)((float)spnPivotX.Value * (float)spnTestScale.Value) ;
            //int __y = (int)((float)spnPivotY.Value * (float)spnTestScale.Value) ;
            //pivot.Location = new System.Drawing.Point(__x - icoWidth, __y - icoHeight);
        }
        private void pbPreviewAnimation_Click(object sender, EventArgs e)
        {

        }
        public void setColorShifting()
        { 
            if (lstImages.Items.Count >0 )
            {
                ImgInfo info = (ImgInfo)lstImages.Items[(int)spnPicIdx.Value-1];
                //Image img = Util.LoadBMPNoLock(info.FullPath);
                //Bitmap ret = ImageUtilities.MultiplyColor((Bitmap)img, shiftedColor);
                //info.Img = ret;
                //PP.Image = info.Img;

                // 讀取當前的ImgInfo 路徑給他
                FileStream PreviewFS = new FileStream(info.FullPath, FileMode.Open);
                spriteTextureControl.setCurPreviewSpTexture(PreviewFS);



                Microsoft.Xna.Framework.Color _co = new Microsoft.Xna.Framework.Color(shiftedColor.R, shiftedColor.G, shiftedColor.B, shiftedColor.A);
                spriteTextureControl.previewSpriteAP.m_MainColorShift = _co;
                spriteTextureControl.setMainColorShifting(_co);
            }
        }
        public void storeColorToImgInfo()
        { 
            ImgInfo info = (ImgInfo)lstImages.Items[(int)spnPicIdx.Value-1];
            info.color = this.shiftedColor;
            info.colorVice = this.shiftedColorVice;
        }
        private void SetColor_Click(object sender, EventArgs e)
        {
            frmSelectReplaceColor _frmSelectReplaceColor = new SpriteSheetEditor.frmSelectReplaceColor(shiftedColor, this , ColorSetMode.ColorSetMode_Main);
            _frmSelectReplaceColor.ShowDialog();
            //SP.IsReplacing = frmSelectReplaceColor.ShowDialog() == DialogResult.OK;
            //if (SP.IsReplacing)
            //    SP.NewReplaceColor = frmSelectReplaceColor.SelectedColor;
        }
        private void btnViseColor_Click(object sender, EventArgs e)
        {
            frmSelectReplaceColor _frmSelectReplaceColor = new SpriteSheetEditor.frmSelectReplaceColor(shiftedColor, this, ColorSetMode.ColorSetMode_Vice);
            _frmSelectReplaceColor.ShowDialog();
        }
        private void btnGenAnimDef_Click(object sender, EventArgs e)
        {
            AnimDefDialog AnimDlg = new AnimDefDialog();
            string strAnimDef = "";
            if (swfFilePath != null)
            { 
                for (int i = 0; i < lstImages.Items.Count; i++)
                {
                    ImgInfo info = (ImgInfo)lstImages.Items[i];
                    string strid = ((info.FileName).Split(new Char[] { '.' }))[0];
                    string strColorA = info.color.A.ToString();
                    string strColorR = info.color.R.ToString();
                    string strColorG = info.color.G.ToString();
                    string strColorB = info.color.B.ToString();
                    strAnimDef += "<animdefine id=\"" + strid + "\" ColorA=\"" + strColorA + "\" ColorR=\"" + strColorR + "\" ColorG=\"" + strColorG + "\" ColorB=\"" + strColorB + "\">";
                    strAnimDef += Environment.NewLine;
                    int swfFilePathidx = swfFilePath.IndexOf("shape");
                    if (swfFilePathidx == -1) swfFilePathidx = 0;
                    string swfFilePathAbbrB = swfFilePath.Substring(swfFilePathidx);
                    string swfFilePathAbbr = swfFilePathAbbrB.Replace('\\', '/');
                    strAnimDef += "\t<act id=\"0\" swfpath=\"" + swfFilePathAbbr + "\" pic_index=\"" + i.ToString() + "\" picwidth=\"" + info.Img.Width.ToString() +"\" picheight=\"" + info.Img.Height.ToString() + "\">";
                    strAnimDef += Environment.NewLine;
                    int _x_ = 0; int _y_ = 0;
                    for(int j = 0;j<info.FrameCount;j++)
                    {
                        string strW = info.FrameWidth.ToString();
                        string strH = info.FrameHeight.ToString();
                        string strT = info.playbackSpeed.ToString();
                        string strPX = info.Pivot.X.ToString();
                        string strPY = info.Pivot.Y.ToString();

                        int curHorIdx = j % (info.Img.Width / info.FrameWidth);
                        _x_ = curHorIdx * info.FrameWidth;
                        _y_ = info.FrameHeight * (j / (info.Img.Width / info.FrameWidth));

                        string strX = _x_.ToString();
                        string strY = _y_.ToString();

                        strAnimDef += "\t<frame x = \"" + strX + "\" y=\"" + strY + "\" w=\"" + strW + "\" h=\"" + strH + "\" t=\"" + strT + "\" xoffset=\"" + strPX+"\" yoffset="+strPY+"\"/>";
                        strAnimDef += Environment.NewLine;
                    }
                    
                    strAnimDef += "\t</act>";
                    strAnimDef += Environment.NewLine;
                    strAnimDef += "</animdefine>";
                    strAnimDef += Environment.NewLine;
                }
                AnimDlg.textBox1.Text = strAnimDef;
                AnimDlg.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("尚未打包swf", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowMokujin_CheckedChanged(object sender, EventArgs e)
        {
            this.spriteTextureControl.bEffectMode = this.ShowMokujin.Checked;
        }

      

    }
}