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
    public class TilePreviewProperty
    {
        #region Members
        Panel PB;
        ComboBox LayerCBO;
        private Bitmap[] Layers;
        const int DEFAULT_MAP_SIZE = 1024;
        Bitmap Map = new Bitmap(DEFAULT_MAP_SIZE, DEFAULT_MAP_SIZE);
        private Bitmap MapWithGrid = null;
        public readonly Point MapSize = new Point(DEFAULT_MAP_SIZE, DEFAULT_MAP_SIZE);
        #endregion

        #region properties
        private Bitmap m_Image = null;
        [CategoryAttribute("Basic"), DescriptionAttribute("The spritesheet/image")]
        public Bitmap Image
        {
            get { return m_Image; }
            set
            {
                m_Image = value;
            }
        }

        private bool m_ShowGrid = true;
        [CategoryAttribute("Grid"), DescriptionAttribute("Hide or show the grid.")]
        public bool ShowGrid
        {
            get { return m_ShowGrid; }
            set
            {
                m_ShowGrid = value;
                SetImageWithGrid();
            }
        }

        private int m_GridThickness = 1;
        [CategoryAttribute("Grid"), DescriptionAttribute("Grid thickness.")]
        public int GridThickness
        {
            get { return m_GridThickness; }
            set
            {
                if (value > 0 && value <= 32)
                {
                    m_GridThickness = value;
                    SetImageWithGrid();
                }
            }
        }

        private Color m_GridColor = Color.Red;
        [CategoryAttribute("Grid"), DescriptionAttribute("Grid color.")]
        public Color GridColor
        {
            get { return m_GridColor; }
            set
            {
                m_GridColor = value;
                SetImageWithGrid();
            }
        }

        private Point m_GridSize = new Point(32, 32);
        [CategoryAttribute("Grid"), DescriptionAttribute("The Grid's size.")]
        public Point GridSize
        {
            get { return m_GridSize; }
            set
            {
                if (value.X > 0 && value.Y > 0 && value.X < 9999 && value.Y < 9999)
                {
                    m_GridSize = value;
                    SetImageWithGrid();
                }
            }
        }

        private bool m_UseEntireImage = true;
        [CategoryAttribute("Basic"), DescriptionAttribute("Set me to false to use the source rectangle instead.")]
        public bool UseEntireImage
        {
            get { return m_UseEntireImage; }
            set { m_UseEntireImage = value; }
        }

        private Rectangle m_SourceRectangle = new Rectangle(0, 0, 32, 32);
        [CategoryAttribute("Basic"), DescriptionAttribute("The source rectangle.")]
        public Rectangle SourceRectangle
        {
            get { return m_SourceRectangle; }
            set
            {
                if (value.X >= 0 && value.Y >= 0 && value.Width > 0 && value.Height > 0)
                    m_SourceRectangle = value;
            }
        }
        #endregion

        public TilePreviewProperty(ref Panel pb, ref ComboBox cboLayer)
        {
            pb.Size = new Size(DEFAULT_MAP_SIZE, DEFAULT_MAP_SIZE);
            PB = pb;
            SetImageWithGrid();
            LayerCBO = cboLayer;
            Layers = new Bitmap[LayerCBO.Items.Count];
            Reset();
        }

        private void SetImageWithGrid()
        {
            // Copy original
            MapWithGrid = new Bitmap(Map);

            if (ShowGrid)
            {
                // Create graphics
                Graphics g = Graphics.FromImage(MapWithGrid);

                // Create pen
                Pen p = new Pen(GridColor, GridThickness);

                // horizontal lines
                for (int y = GridSize.Y; y < MapWithGrid.Height; y += GridSize.Y)
                    g.DrawLine(p, new Point(0, y), new Point(MapWithGrid.Width, y));
                // vertical lines
                for (int x = GridSize.X; x < MapWithGrid.Width; x += GridSize.X)
                    g.DrawLine(p, new Point(x, 0), new Point(x, MapWithGrid.Height));

                // Cleanup
                g.Dispose();
            }

            // Refresh
            PB.BackgroundImage = MapWithGrid;
            PB.Refresh();
        }

        public void Reset()
        {
            PB.BackgroundImage = Map = new Bitmap(MapSize.X, MapSize.Y);
            SetImageWithGrid();

            // Reset layers
            for (int i = 0; i < LayerCBO.Items.Count; i++)
            {
                if (Layers[i] != null)
                    Layers[i].Dispose();
                Layers[i] = new Bitmap(MapSize.X, MapSize.Y);
            }
        }

        /// <summary>
        /// Recreates the map image from the layers
        /// </summary>
        private void UpdateMap()
        {
            Map = new Bitmap(Map.Width, Map.Height);

            Graphics g = Graphics.FromImage(Map);
            for (int i = 0; i < LayerCBO.Items.Count; i++)
                g.DrawImage(Layers[i], Point.Empty);
            g.Dispose();
        }

        public void SaveAs(string path)
        {
            Map.Save(path, ImageFormat.Png);
        }

        /// <summary>
        /// Only deletes the section on the selected layer.
        /// </summary>
        /// <param name="location"></param>
        public void DelSection(Point location)
        {
            // Snap to grid
            location = location.SnapToTopLeft(GridSize);

            // Set the colors to transparent
            for (int y = location.Y; y < location.Y + GridSize.Y; y++)
            {
                for (int x = location.X; x < location.X + GridSize.X; x++)
                {
                    Layers[LayerCBO.SelectedIndex].SetPixel(x, y, Color.Transparent);
                }
            }

            // Refresh
            UpdateMap();
            SetImageWithGrid();
        }

        public void FillCurrentLayer(Bitmap image)
        {
            int x = 0, y = 0;
            while (y * image.Height < MapSize.Y)
            {
                x = 0;
                while (x * image.Width < MapSize.X)
                {
                    Graphics g = Graphics.FromImage(Layers[LayerCBO.SelectedIndex]);
                    g.DrawImage(image, new Point(x * image.Width, y * image.Height));
                    g.Dispose();
                    x++;
                }
                y++;
            }

            // Refresh
            UpdateMap();
            SetImageWithGrid();
        }

        /// <summary>
        /// Adds the image to the selected layer.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="image"></param>
        public void AddImage(Point location, Bitmap image)
        {
            // Snap to grid
            location = location.SnapToTopLeft(GridSize);

            // Create graphics
            Graphics g = Graphics.FromImage(Layers[LayerCBO.SelectedIndex]);

            // Get/Determine image to draw
            Bitmap imgToDraw;
            if (!UseEntireImage)
                imgToDraw = Util.CopyBitMapRegion(image, SourceRectangle);
            else
                imgToDraw = image;

            // Draw the image
            g.DrawImage(imgToDraw, new Rectangle(location.X, location.Y, imgToDraw.Width, imgToDraw.Height));

            // Cleanup
            g.Dispose();

            // Update Map
            UpdateMap();

            // Refresh/Set grid
            SetImageWithGrid();
        }
    }
}
