using System;

namespace CloudCore.Web.Core.Razor.Extensions
{
    public static class WebImageExtensions
    {
        public const int MaxWidth = 48;
        public const int MaxHeight = 48;
        public const int MaxBytes = 1048576;

        public static System.Web.Helpers.WebImage CropToFit(this System.Web.Helpers.WebImage image, int width, int height)
        {
            ValidateImage(image);

            double imageRatio = image.Width / image.Height;
            double thumbRatio = width / height;
            int imgWidth = width;
            int imgHeight = height;
            int cropBottom = 0, cropRight = 0;

            if (imageRatio < thumbRatio)
            {
                imgHeight = (image.Height * width) / image.Width;
            }
            else
            {
                imgWidth = (image.Width * height) / image.Height;
            }

            image.Resize(imgWidth, imgHeight, true, true);

            cropRight = (imgWidth > width) ? imgWidth - width : 0;
            cropBottom = (imgHeight > height) ? imgHeight - height : 0;

            image.Crop(0, 0, cropBottom, cropRight);

            return image;
        }

        private static void ValidateImage(System.Web.Helpers.WebImage image)
        {
            if (image.Width < MaxWidth || image.Height < MaxHeight)
                throw new Exception("The uploaded image must have a width and height larger than 48px.");

            if (image.GetBytes().Length > MaxBytes)
                throw new Exception("The file you are uploading is too large, please upload a file that is 1MB or smaller in size.");
        }
    }
}
