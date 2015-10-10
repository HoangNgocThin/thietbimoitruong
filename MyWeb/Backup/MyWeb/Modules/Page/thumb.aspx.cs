using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyWeb.Modules.Page
{
    public partial class thumb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Image = Request.QueryString["image"];
            if (Image == null)
            {
                this.ErrorResult();
                return;
            }
            string sWidth = Request["width"];
            string sHeight = Request["height"];
            int Size = 130; //Default size image
            int Width = 0;
            int Height = 0;
            if (sWidth != null)
            {
                Width = Convert.ToInt32(sWidth) > 0 ? Convert.ToInt32(sWidth) : Width;
            }
            if (sHeight != null)
            {
                Height = Convert.ToInt32(sHeight) > 0 ? Convert.ToInt32(sHeight) : Height;
            }
            if (Width == 0 && Height == 0)
            {
                Width = Size;
                Height = Size;
            }
            string Path = Server.MapPath(Request.ApplicationPath) + "\\" + Image;
            Bitmap bmp = CreateThumbnail(Path, Width, Height);
            if (bmp == null)
            {
                this.ErrorResult();
                return;
            }
            
            // Put user code to initialize the page here
            Response.ContentType = "image/jpeg";
            bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
        }

        private void ErrorResult()
        {
            Bitmap bmp = CreateTextImage("No thumbnail");
            Response.ContentType = "image/jpeg";
            bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();

            //Response.Clear();
            //Response.Write("Error from source input");
            //Response.End();
        }

        private Bitmap CreateTextImage(string sImageText)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);
            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial", 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Height;

            // Create the bmpImage again with the correct size for the text and font.
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            objGraphics.Clear(Color.White);
            objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            objGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            objGraphics.DrawString(sImageText, objFont, new SolidBrush(Color.Red), 0, 0);
            objGraphics.Flush();
            return (objBmpImage);
        }

        /// Creates a resized bitmap from an existing image on disk.
        /// Call Dispose on the returned Bitmap object
        /// Bitmap or null
        public static Bitmap CreateThumbnail(string lcFilename, int lnWidth, int lnHeight)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                ImageFormat loFormat = loBMP.RawFormat;
                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;
                //*** If the image is smaller than a thumbnail just return it
                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;
                if (lnHeight == 0 || loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);
                loBMP.Dispose();
            }
            catch
            {
                return null;
            }
            return bmpOut;
        }
    }
}