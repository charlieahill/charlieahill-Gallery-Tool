using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charlieahill_Gallery_Tool
{
    public class ImageContainer
    {
        /// <summary>Creates a new instance of the image class containing image, caption and other auxilliary data</summary>
        /// <param name="in_img">Image to be ouput</param>
        /// <param name="in_caption">Text to be displayed beneath the image</param>
        public ImageContainer(Image in_img, string in_caption, bool indexable = false)
        {
            img = in_img;
            caption = in_caption;
        }

        private Image img;
        /// <summary>Stores the original image to be output</summary>
        public Image Img
        {
            get { return img; }
        }

        private string caption;
        /// <summary>Caption for the image</summary>
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        private string mainImageFilename;
        /// <summary>Caption for the image</summary>
        public string MainImageFilename
        {
            get { return mainImageFilename; }
            set { mainImageFilename = value; }
        }

        private string tabImageFilename;
        /// <summary>Caption for the image</summary>
        public string TabImageFilename
        {
            get { return tabImageFilename; }
            set { tabImageFilename = value; }
        }

        private string downloadImageFilename;
        /// <summary>Caption for the image</summary>
        public string DownloadImageFilename
        {
            get { return downloadImageFilename; }
            set { downloadImageFilename = value; }
        }

        private bool indexable;
        /// <summary>Marks the image as to be shown on the index page of the website - i.e. preview image</summary>
        public bool Indexable
        {
            get { return indexable; }
            set { indexable = value; }
        }

    }
}
