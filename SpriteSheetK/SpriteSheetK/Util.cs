using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SpriteSheetEditor
{
    public static class Util
    {
        public static SaveFileDialog CreateSaveFileDialog()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG Files (*.png)|*.png|All image Types|*.bmp;*.jpg;*.jpeg;*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";
            dialog.Title = "Select the save destination";
            return dialog;
        }
        public static SaveFileDialog CreateSaveFileSWFDialog()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SWF Files (*.swf)|*.swf|All files (*.*)|*.*";
            dialog.Title = "Select the save destination";
            return dialog;
        }
        public static OpenFileDialog CreateOpenFileDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All image Types|*.bmp;*.jpg;*.jpeg;*.png|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";
            dialog.Title = "Select the image file";
            return dialog;
        }

        public static OpenFileDialog CreateOpenFileDialogMulti()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All image Types|*.bmp;*.jpg;*.jpeg;*.png|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";
            dialog.Multiselect = true;
            dialog.Title = "Select the image files";
            return dialog;
        }

        /// <summary>
        /// Loads a bitmap from a file but does not lock the file like BitMap.FromFile() does.
        /// </summary>
        /// <returns></returns>
        public static Bitmap LoadBMPNoLock(string path)
        {
            Bitmap result;
            using (var fs = new System.IO.FileStream(path, System.IO.FileMode.Open))
            {
                result = new Bitmap(fs);
            }
            return result;
        }

        /// <summary>
        /// Copies the specified region from the bitmap into a new bitmap
        /// Bug: http://www.eggheadcafe.com/software/aspnet/35046587/object-is-currently-in-use-elsewhere--im-stumped.aspx
        /// </summary>
        /// <param name="srcBitmap"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public static Bitmap CopyBitMapRegion(Bitmap srcBitmap, Rectangle section)
        {
            // Create the new bitmap and associated graphics object
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Bitmap temp = new Bitmap(srcBitmap);
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(temp, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            g.Dispose();
            temp.Dispose();

            // Return the bitmap
            return bmp;
        }

        //public static Bitmap CopyBitMapRegionScaled(Bitmap srcBitmap, Rectangle section)
        //{
        //    float _scale_ = 1.4f;
        //    RectangleF ScaledRect = new RectangleF(section.Location, section.Size);
        //    ScaledRect.Inflate(_scale_ , _scale_);
        //    //先裁切到需要的部分
        //    Bitmap temp = new Bitmap(srcBitmap);
        //    Bitmap bmpCorpped = temp.Clone(section, temp.PixelFormat);
            
        //    //裁切完成，乘上放大倍率
        //    float sourceWidth = bmpCorpped.Width;
        //    float sourceHeight = bmpCorpped.Height;
        //    float destWidth = (sourceWidth * _scale_);
        //    float destHeight = (sourceHeight * _scale_);
        //    Graphics g = Graphics.FromImage(bmpCorpped);
        //    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //    g.DrawImage(bmpCorpped, 0, 0, destWidth, destHeight);
           
        //    // Clean up
        //    g.Dispose();
        //    temp.Dispose();
        //    bmpCorpped.Dispose();

        //    // Return the bitmap
        //    return bmpCorpped;
        //}

        /// <summary>  
        /// method for changing the opacity of an image
        /// Taken from: http://www.codeproject.com/Tips/201129/Change-Opacity-of-Image-in-C
        /// </summary>  
        /// <param name="image">image to set opacity on</param>  
        /// <param name="opacity">percentage of opacity (0-100)</param>  
        /// <returns></returns>  
        public static Image SetImageOpacity(Image image, float opacity)
        {
            opacity = opacity / 100;

            //create a Bitmap the size of the image provided  
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            //create a graphics object from the image  
            using (Graphics gfx = Graphics.FromImage(bmp))
            {

                //create a color matrix object  
                ColorMatrix matrix = new ColorMatrix();

                //set the opacity  
                matrix.Matrix33 = opacity;

                //create image attributes  
                ImageAttributes attributes = new ImageAttributes();

                //set the color(opacity) of the image  
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //now draw the image  
                gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public static bool IsImage(string path)
        {
            try
            {
                Image testImage = Image.FromFile(path);
                testImage.Dispose(); // Release the resource
            }
            catch { return false; }
            return true;
        }

        public static bool IsInteger(string text)
        {
            try
            {
                int.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Point SnapToTopLeft(this Point coordinate, Point gridSize)
        {
            float hSnap = gridSize.X, vSnap = gridSize.Y, originalX = coordinate.X, originalY = coordinate.Y;
            return new Point((int)(Math.Floor(coordinate.X / hSnap) * hSnap), (int)(Math.Floor(coordinate.Y / vSnap) * vSnap));
        }

        public static Color GetScreenPixel(Point location)
        {
            using (var bm = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bm))
                {
                    graphics.CopyFromScreen(location, new Point(0, 0), new Size(1, 1));
                }
                return bm.GetPixel(0, 0);
            }
        }

        public static void ReplaceColor(this Bitmap bm, Color oldColor, Color newColor)
        {
            if (bm == null)
                return;

            for (int x = 0; x < bm.Width; x++)
            {
                for (int y = 0; y < bm.Height; y++)
                {
                    if (bm.GetPixel(x, y).ToArgb() == oldColor.ToArgb()) // ToArgb() is needed as Color.White != ffffff for some reason...
                        bm.SetPixel(x, y, newColor);
                }
            }

        }
    }

}
