using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charlieahill_Gallery_Tool
{
    class Resizer
    {
        /// <summary>Resize an image based on given parameters</summary>
        /// <param name="image">Image to be resized</param>
        /// <param name="resizeParams">ResizingParams parameters in the form of the ResizingParams class</param>
        /// <returns>Resized image</returns>
        public Bitmap Resize(Image image, ResizingParams resizeParams)
        {
            //Determie scaling mode
            if(resizeParams.ResizeMode == ResizingParams.ResizeModeEnum.maintainAspect)
            {
                if(resizeParams.MarMode == ResizingParams.MARModeEnum.scaleToWidth)
                    calculateScalingFactorFrom = scaling.width;
                else
                    calculateScalingFactorFrom = scaling.height;
            }
            else
            {
                if(resizeParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToWidth)
                    calculateScalingFactorFrom = scaling.width;
                else
                    calculateScalingFactorFrom = scaling.height;
            }

            Debug("Calculating scaling factor from " + calculateScalingFactorFrom.ToString());

            decimal scalingFactor;

            //Calculate scaling factor
            if(calculateScalingFactorFrom == scaling.width)
                scalingFactor = CalculateScalingFactorFromWidth(image, resizeParams);
            else
                scalingFactor = CalculateScalingFactorFromHeight(image, resizeParams);

            //Calculate output image size
            Size outputSize = new Size((int)(image.Width * scalingFactor), (int)(image.Height * scalingFactor));
            Debug("Outputting image at size " + outputSize.Width + ", " + outputSize.Height);

            //Scale image
            Bitmap scaledImage = new Bitmap(image, outputSize);

            //if resize mode, output image
            if(resizeParams.ResizeMode == ResizingParams.ResizeModeEnum.maintainAspect)
                return scaledImage;


            //now we know we're in crop mode
            //Reset outputSize as fixed values
            if(resizeParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToWidth)
                outputSize = new Size((int)(resizeParams.CropScalingWidth),(int)(resizeParams.CropTrimHeight));
            if(resizeParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToHeight)
                outputSize = new Size((int)(resizeParams.CropTrimWidth), (int)(resizeParams.CropScalingHeight));


            return (Bitmap)CropImage(scaledImage, SetRectangleForCrop(scaledImage, outputSize));
        }

        /// <summary>Sets the rectangle for an image, trimming so as to show central portion of image</summary>
        /// <param name="image">Image to be cropped</param>
        /// <param name="targetSize">Size of image to be cropped to</param>
        /// <returns>Cropping Rectangle</returns>
        private Rectangle SetRectangleForCrop(Bitmap originalSize, Size targetSize)
        {
            Size delta = new Size((originalSize.Width - targetSize.Width), (originalSize.Height - targetSize.Height));
            Rectangle outRect = new Rectangle(delta.Width / 2, delta.Height / 2, targetSize.Width, targetSize.Height);
            Debug("1/5 output params: ");
            Debug("2/5 Start Width: " + outRect.X);
            Debug("3/5 Start Height: " + outRect.Y);
            Debug("4/5 Overall Width: " + outRect.Width);
            Debug("5/5 Overall Height: " + outRect.Height);
            return outRect;
        }

        /// <summary>Crops the central part out of an image for a given rectangle</summary>
        /// <param name="image">Image to be cropped</param>
        /// <param name="centreCropRectangle">Size of the central part of the image to be cut out</param>
        /// <returns>Cropped image</returns>
        //private static Bitmap CropImage(Bitmap image, Rectangle centreCropRectangle)
        //{
        //    //taken from http://stackoverflow.com/questions/734930/how-to-crop-an-image-using-c
        //    Bitmap bmpImage = image.Clone(centreCropRectangle, image.PixelFormat);
        //    return bmpImage;
        //}

        /// <summary>Crops the image</summary>
        /// <param name="image">Image to be cropped</param>
        /// <param name="centreCropRectangle">Rectangle bounding the centre to be cut out</param>
        /// <returns>Cropped image</returns>
        private static Bitmap CropImage(Bitmap image, Rectangle centreCropRectangle)
        {
            //taken from http://stackoverflow.com/questions/734930/how-to-crop-an-image-using-c
            Bitmap imgOut = new Bitmap(centreCropRectangle.Width, centreCropRectangle.Height);
            Rectangle outRect = new Rectangle(0,0,centreCropRectangle.Width, centreCropRectangle.Height);

            using(Graphics g = Graphics.FromImage(imgOut))
            {
                g.DrawImage(image, outRect, centreCropRectangle, GraphicsUnit.Pixel);
            }

            return imgOut;
        }

        /// <summary>Calculate the scaling factor based on width</summary>
        /// <param name="image">The input image</param>
        /// <param name="resizeParams">The expected output parameters</param>
        /// <returns>Scaling factor</returns>
        public decimal CalculateScalingFactorFromWidth(Image image, ResizingParams resizeParams)
        {
            Debug("Imported image width: " + image.Width);

            int targetImageWidth;
            if(resizeParams.ResizeMode == ResizingParams.ResizeModeEnum.maintainAspect)
                targetImageWidth = resizeParams.MarWidth;
            else
                targetImageWidth = resizeParams.CropScalingWidth;

            Debug("Target image width " + targetImageWidth);

            decimal scaleFactor = ((decimal)(targetImageWidth)) / ((decimal)(image.Width));

            Debug("Scaling factor " + scaleFactor);

            return scaleFactor;
        }

        /// <summary>Calculate the scaling factor based on height</summary>
        /// <param name="image">The input image</param>
        /// <param name="resizeParams">The expected output parameters</param>
        /// <returns>Scaling factor</returns>
        public decimal CalculateScalingFactorFromHeight(Image image, ResizingParams resizeParams)
        {
            Debug("Imported image height: " + image.Height);

            int targetImageHeight;
            if(resizeParams.ResizeMode == ResizingParams.ResizeModeEnum.maintainAspect)
                targetImageHeight = resizeParams.MarHeight;
            else
                targetImageHeight = resizeParams.CropScalingHeight;

            Debug("Target image height " + targetImageHeight);

            decimal scaleFactor = ((decimal)(targetImageHeight)) / ((decimal)(image.Height));

            Debug("Scaling factor " + scaleFactor);

            return scaleFactor;
        }

        /// <summary>output text to the debug screen</summary>
        /// <param name="debugText">Text to shown in the Visual Studio debug window</param>
        private void Debug(string debugText)
        {
            System.Diagnostics.Debug.WriteLine(debugText);
        }

        private enum scaling { width, height };

        private scaling calculateScalingFactorFrom;
    }
}
