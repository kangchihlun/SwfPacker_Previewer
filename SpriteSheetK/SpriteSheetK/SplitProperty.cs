using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace SpriteSheetEditor
{
    [DefaultPropertyAttribute("Image")]
    public class SplitProperty : IDisposable
    {
        #region properties
        private Bitmap m_Image = null;
        [CategoryAttribute("Basic"), DescriptionAttribute("The spritesheet.")]
        public Bitmap Image
        {
            get { return m_Image; }
            set
            {
                m_Image = value;
                DrawArea.Width = value.Width;
                DrawArea.Height = value.Height;
                RefreshSplit();
            }
        }

        private Point m_SourceOffset = new Point(0, 0);
        [CategoryAttribute("Basic"), DescriptionAttribute("The SourceRectangle offset.")]
        public Point SourceOffset
        {
            get { return m_SourceOffset; }
            set { m_SourceOffset = value; RefreshSplit(); }
        }

        private Point m_Spacing = new Point(0, 0);
        [CategoryAttribute("Basic"), DescriptionAttribute("The spacing between the frames.")]
        public Point Spacing
        {
            get { return m_Spacing; }
            set
            {
                m_Spacing = value;
                RefreshSplit();
            }
        }

        private int m_FrameWidth;
        [CategoryAttribute("Basic"), DescriptionAttribute("Width of each frame.")]
        public int FrameWidth
        {
            get { return m_FrameWidth; }
            set
            {
                m_FrameWidth = value;
                if (m_FrameWidth < 1)
                    m_FrameWidth = 1;
                RefreshSplit();
            }
        }

        private int m_FrameHeight;
        [CategoryAttribute("Basic"), DescriptionAttribute("Height of each frame.")]
        public int FrameHeight
        {
            get { return m_FrameHeight; }
            set
            {
                m_FrameHeight = value;
                if (m_FrameHeight < 1)
                    m_FrameHeight = 1;
                RefreshSplit();
            }
        }

        private int m_FrameCount = 1;
        [CategoryAttribute("Basic"), DescriptionAttribute("Number of frames.")]
        public int FrameCount
        {
            get { return m_FrameCount; }
            set
            {
                m_FrameCount = value;
                if (m_FrameCount < 1)
                    m_FrameCount = 1;
                RefreshSplit();
            }
        }

        private int m_RowCount = 1;
        [CategoryAttribute("Basic"), DescriptionAttribute("Number of rows.")]
        public int RowCount
        {
            get { return m_RowCount; }
            set
            {
                m_RowCount = value;
                if (m_RowCount < 1)
                    m_RowCount = 1;
                RefreshSplit();
            }
        }

        private bool m_UseRegularNumbering = false;
        [CategoryAttribute("Basic"), DescriptionAttribute("When true: Outputs Split01.png instead of split01_01.png")]
        public bool UseRegularNumbering
        {
            get { return m_UseRegularNumbering; }
            set { m_UseRegularNumbering = value; }
        }

        private ImageFormat m_SaveImageFormat = ImageFormat.Png;
        [CategoryAttribute("Basic"), DescriptionAttribute("The image format to save the image as.")]
        public ImageFormat SaveImageFormat
        {
            get { return m_SaveImageFormat; }
            set { m_SaveImageFormat = value; }
        }

        private PictureBox DrawArea;
        private Bitmap Sheet = null;
        public bool IsReplacing = false;
        public Color NewReplaceColor = Color.White;
        #endregion

        public SplitProperty(ref PictureBox drawArea)
        {
            DrawArea = drawArea;
            FrameWidth = FrameHeight = 64;
        }

        private Rectangle GetSourceRect()
        {
            return new Rectangle(SourceOffset.X, SourceOffset.Y, FrameWidth * FrameCount, FrameHeight * RowCount);
        }

        private Rectangle GetFrameSourceRect(Point frame, Point totalSpacing)
        {
            return new Rectangle(SourceOffset.X + totalSpacing.X + frame.X * FrameWidth, SourceOffset.Y + totalSpacing.Y + frame.Y * FrameHeight, FrameWidth, FrameHeight);
        }

        public void RefreshSplit()
        {
            if (Image != null)
            {
                Sheet = new Bitmap(Image);

                // Initialize graphics
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Sheet);
                Pen pen = new Pen(Color.FromArgb(125, 255, 0, 0));

                for (int x = 0; x < FrameCount; x++)
                {
                    for (int y = 0; y < RowCount; y++)
                    {
                        int spacingX = 0, spacingY = 0;
                        if (x > 0)
                            spacingX = Spacing.X;
                        if (y > 0)
                            spacingY = Spacing.Y;

                        g.DrawRectangle(pen, GetFrameSourceRect(new Point(x, y), new Point(x * spacingX, y * spacingY)));
                    }
                }

                DrawArea.Image = Sheet;

                // Clean up
                g.Dispose();
            }
        }

        public void SaveAs(string path)
        {
            string pathNoExt = Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);

            int xFormat = 2;
            if (FrameCount >= 100 && FrameCount < 1000)
                xFormat = 3;
            else if (FrameCount >= 1000)
                xFormat = 4;

            int yFormat = 2;
            if (RowCount >= 100 && RowCount < 1000)
                yFormat = 3;
            else if (RowCount >= 1000)
                yFormat = 4;

            int regularNrCnt = 0;
            for (int y = 0; y < RowCount; y++)
            {
                for (int x = 0; x < FrameCount; x++)
                {
                    int spacingX = 0, spacingY = 0;
                    if (x > 0)
                        spacingX = Spacing.X;
                    if (y > 0)
                        spacingY = Spacing.Y;

                    Bitmap SaveBm = Util.CopyBitMapRegion(Image, GetFrameSourceRect(new Point(x, y), new Point(x * spacingX, y * spacingY)));
                    if (!UseRegularNumbering)
                    {
                        if (RowCount == 1)
                            SaveBm.Save(string.Format("{0}_{1}{2}", pathNoExt, x.ToString().PadLeft(xFormat, '0'), ext), SaveImageFormat);
                        else
                            SaveBm.Save(string.Format("{0}_{1}_{2}{3}", pathNoExt, x.ToString().PadLeft(xFormat, '0'), y.ToString().PadLeft(yFormat, '0'), ext), SaveImageFormat);
                    }
                    else
                    {
                        SaveBm.Save(string.Format("{0}_{1}{2}", pathNoExt, regularNrCnt.ToString().PadLeft(xFormat, '0'), ext), SaveImageFormat);
                        regularNrCnt++;
                    }
                }
            }
        }

        public void Dispose()
        {
            if (Sheet != null)
                Sheet.Dispose();
        }
    }
}
