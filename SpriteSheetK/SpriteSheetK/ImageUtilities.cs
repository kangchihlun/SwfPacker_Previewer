using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;  

namespace SpriteSheetEditor
{
    public static class ImageUtilities
    {
        /// <summary>  
        /// method for changing the opacity of an image  
        /// </summary>  
        /// <param name="image">image to set opacity on</param>  
        /// <param name="opacity">percentage of opacity</param>  
        /// <returns></returns>  
        public static Bitmap SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                Graphics gfx = Graphics.FromImage(bmp);

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
                gfx.Dispose();
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static Bitmap Resize(Bitmap imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            //Debug.WriteLine("destWidth = " + destWidth.ToString());
            //Debug.WriteLine("destHeight = " + destHeight.ToString());

            Bitmap b = new Bitmap(destWidth, destHeight);
            
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return b;
        }
        public static Bitmap ResizeKang(Bitmap original ,float scale)
        {
            Rectangle section = new Rectangle(0, 0, (int)(original.Width * scale), (int)(original.Height * scale));
            Bitmap bmp = new Bitmap((int)(original.Width * scale), (int)(original.Height * scale));
            Bitmap temp = new Bitmap(original);
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
        public static Bitmap Crop(Bitmap srcBitmap, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height, PixelFormat.Format32bppArgb);
            Bitmap temp = new Bitmap(srcBitmap);
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.Default;
            // Draw the specified section of the source bitmap to the new one
            g.DrawImage(temp, 0, 0, section, GraphicsUnit.Pixel);

            // Clean up
            g.Dispose();
            temp.Dispose();

            // Return the bitmap
            return bmp;
        }

        public static Bitmap GrayscaleConvert(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] 
            {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
            });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        public static Bitmap MultiplyColor(Bitmap original , Color inColor)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Color c;
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;
                    c = original.GetPixel(i, j);
                    float cr = (float)c.R / 255.0f;
                    float cg = (float)c.G / 255.0f;
                    float cb = (float)c.B / 255.0f;
                    
                    //Debug.WriteLine("ca = " + ca.ToString());
                    float incolorW = (float)inColor.A / 255.0f; // 權重
                    float incolorR = (float)inColor.R / 255.0f ;
                    float incolorG = (float)inColor.G / 255.0f ;
                    float incolorB = (float)inColor.B / 255.0f ;




                    nPixelR = (int)(255 * ((incolorR * cr * incolorW) + (cr * (1.0 - incolorW)))) ;
                    nPixelG = (int)(255 * ((incolorG * cg * incolorW) + (cg * (1.0 - incolorW))));
                    nPixelB = (int)(255 * ((incolorB * cb * incolorW) + (cb * (1.0 - incolorW))));

                    nPixelR = Math.Max(nPixelR, 0);
                    nPixelR = Math.Min(255, nPixelR);

                    nPixelG = Math.Max(nPixelG, 0);
                    nPixelG = Math.Min(255, nPixelG);

                    nPixelB = Math.Max(nPixelB, 0);
                    nPixelB = Math.Min(255, nPixelB);


                    newBitmap.SetPixel(i, j, Color.FromArgb(c.A, (byte)nPixelR, (byte)nPixelG, (byte)nPixelB));
                }
            }
            return newBitmap;
        }
    }
}
