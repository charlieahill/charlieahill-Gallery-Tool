using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace charlieahill_Gallery_Tool
{
    class txt
    {
        //output string builders
        private StringBuilder stringBuilder;
        /// <summary>Contains the string builder for the PHP file to be output</summary>
        public StringBuilder StringBuilder
        {
            get{return stringBuilder;}
        }

        public string[] fixedData;
        public string[] fixedYTData;

        public txt(options Options)
        {
            //Intialise all string builders
            stringBuilder= new StringBuilder();

            //read in and split readIn --> FixedData
            string readIn;
            if (Options.AgExport)
                readIn = Properties.Resources.txtag;
            else
                readIn = Properties.Resources.txt;
            // reference https://msdn.microsoft.com/en-us/library/tabh47cf(v=vs.110).aspx
            System.Diagnostics.Debug.WriteLine("Loaded file txt");
            string[] splitString = new string[] {"***"};
            fixedData = readIn.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine("Split to " + fixedData.Count() + " entries");

            //readin and split the YouTube section
            string readInYouTube;
            if (Options.YouTubeLink.Trim() == string.Empty) return;
            readInYouTube = Properties.Resources.ytlink;
            System.Diagnostics.Debug.WriteLine("Loaded yt txt");
            string[] splitYTString = new string[] { "###" };
            fixedYTData = readInYouTube.Split(splitYTString, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine("Split to " + fixedData.Count() + " entries");
        }

        /// <summary>Calculates the entire output file for the php file</summary>
        /// <param name="Options">Current web formatting related options</param>
        internal void StartOutputFile(options Options)
        {
            stringBuilder.Append(fixedData[0]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[1]);
            stringBuilder.Append(Options.GalleryDescription);
            stringBuilder.Append(fixedData[2]);
            stringBuilder.Append(Options.PhpFileName);
            stringBuilder.Append(fixedData[3]);
            stringBuilder.Append(Options.PhpFileName);
            stringBuilder.Append(fixedData[4]);
            stringBuilder.Append(fixedYTData[0]);
            stringBuilder.Append(Options.YouTubeLink);
            stringBuilder.Append(fixedYTData[1]);
        }

        internal void AddImageToOutputFile(options Options, ImageContainer image)
        {
            stringBuilder.Append(fixedData[5]);
            stringBuilder.Append(Options.GalleryName);
            stringBuilder.Append(fixedData[6]);
            stringBuilder.Append(image.MainImageFilename);
            stringBuilder.Append(fixedData[7]);
            stringBuilder.Append(Options.GalleryName);
            stringBuilder.Append(fixedData[8]);
            stringBuilder.Append(image.Caption);
            if(image.Caption.Trim() != string.Empty)
                stringBuilder.Append(fixedData[9]);
            else
                stringBuilder.Append(fixedData[9].Replace(" <br>",string.Empty));
            stringBuilder.Append(Options.GalleryName);
            stringBuilder.Append(fixedData[10]);
            stringBuilder.Append(image.DownloadImageFilename);
            stringBuilder.Append(fixedData[11]);
            stringBuilder.Append(image.Img.Width);
            stringBuilder.Append(fixedData[12]);
            stringBuilder.Append(image.Img.Height);
            stringBuilder.Append(fixedData[13]);
            stringBuilder.Append(Options.GalleryName);
            stringBuilder.Append(fixedData[14]);
            stringBuilder.Append(image.TabImageFilename);
            stringBuilder.Append(fixedData[15]);
        }

        /// <summary>Adds the final lines to the output file</summary>
        internal void CompleteOutputFile()
        {
            stringBuilder.Append(fixedData[16]);
        }
            
        /// <summary>Convert string builder to output string</summary>
        /// <returns>String to be output</returns>
        internal string String()
        {
            return stringBuilder.ToString();
        }
    }
}
