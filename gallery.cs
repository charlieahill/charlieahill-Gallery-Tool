using System;
using System.Linq;
using System.Text;

namespace charlieahill_Gallery_Tool
{
    class gallery
    {
        private StringBuilder stringBuilder;

        public string[] fixedData;

        public gallery()
        {
            //Intialise all string builders
            stringBuilder= new StringBuilder();
            
            //read in and split readIn --> FixedData
            string readIn = Properties.Resources.gallery;
            // reference https://msdn.microsoft.com/en-us/library/tabh47cf(v=vs.110).aspx
            System.Diagnostics.Debug.WriteLine("Loaded file gallery");
            string[] splitString = new string[] {"***"};
            fixedData = readIn.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine("Split to " + fixedData.Count() + " entries");
        }

        /// <summary>Calculates the entire output file for the php file</summary>
        /// <param name="Options">Current web formatting related options</param>
        internal void CalculateOutputFile(options Options)
        {
            stringBuilder.Append(fixedData[0]);
            stringBuilder.Append(Options.PhpFileName);
            stringBuilder.Append(fixedData[1]);
            stringBuilder.Append(Options.KeyImage);
            stringBuilder.Append(fixedData[2]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[3]);
        }

        /// <summary>Convert string builder to output string</summary>
        /// <returns>String to be output</returns>
        internal string String()
        {
            return Properties.Resources.galleryBlurb + Environment.NewLine + Environment.NewLine + stringBuilder.ToString();
        }

        /// <summary>Convert string builder to output string</summary>
        /// <returns>String to be output</returns>
        internal string StringNoBlurb()
        {
            return stringBuilder.ToString();
        }
    }
}
