using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charlieahill_Gallery_Tool
{
    class index
    {
        private StringBuilder stringBuilder;

        public string[] fixedData;

        public index()
        {
            //Intialise all string builders
            stringBuilder= new StringBuilder();
            
            //read in and split readIn --> FixedData
            string readIn = Properties.Resources.index;
            // reference https://msdn.microsoft.com/en-us/library/tabh47cf(v=vs.110).aspx
            System.Diagnostics.Debug.WriteLine("Loaded file index");
            string[] splitString = new string[] {"***"};
            fixedData = readIn.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine("Split to " + fixedData.Count() + " entries");
        }

        /// <summary>Calculates the entire output file for the php file</summary>
        /// <param name="Options">Current web formatting related options</param>
        internal void CalculateOutputFile(options Options, ObservableCollection<ImageContainer> images)
        {
            stringBuilder.Append(fixedData[0]);
            stringBuilder.Append(Options.PhpFileName);
            stringBuilder.Append(fixedData[1]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[2]);
            stringBuilder.Append(Options.GalleryDate);
            stringBuilder.Append(fixedData[3]);

            List<ImageContainer> indexImages = DetermineIndexImages(images, 4);
            for(int i = 0; i < indexImages.Count(); i++)
            {
                stringBuilder.Append(fixedData[4]);
                stringBuilder.Append(Options.GalleryName);
                stringBuilder.Append(fixedData[5]);
                stringBuilder.Append(indexImages[i].TabImageFilename);
                stringBuilder.Append(fixedData[6]);
            }

            stringBuilder.Append(fixedData[7]);
        }
            
        /// <summary>Determines the key images to show, favouring the first x user selected images, then dragging from the start of the gallery as necessary</summary>
        /// <param name="images">The images to select from</param>
        /// <param name="numberToShow">The number of images to show</param>
        /// <returns>The images that are to be used as key images</returns>
        private List<ImageContainer> DetermineIndexImages(ObservableCollection<ImageContainer> images, int numberToShow)
        {
            List<ImageContainer> indexImages = new List<ImageContainer>();

            //Return empty list if no images given
            if(images.Count() < 1)
                return indexImages;

            //otherwise take the first up to x images marked as key images by the user
            foreach(ImageContainer image in images)
            {
                if(image.Indexable)
                    indexImages.Add(image);

                if(indexImages.Count == numberToShow)
                    return indexImages;
            }

            //if less available than required, dump the first x number
            foreach(ImageContainer image in images)
            {
                if(!image.Indexable)
                    indexImages.Add(image);

                if(indexImages.Count == numberToShow)
                    return indexImages;
            }

            return indexImages;
        }

        /// <summary>Convert string builder to output string</summary>
        /// <returns>String to be output</returns>
        internal string String()
        {
            return Properties.Resources.indexBlurb + Environment.NewLine + Environment.NewLine + stringBuilder.ToString();
        }

        /// <summary>Convert string builder to output string</summary>
        /// <returns>String to be output</returns>
        internal string StringNoBlurb()
        {
            return stringBuilder.ToString();
        }
    }
}