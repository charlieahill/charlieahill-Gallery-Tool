using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace charlieahill_Gallery_Tool
{
    class php
    {
        private StringBuilder stringBuilder;

        public string[] fixedData;

        public php()
        {
            //Intialise all string builders
            stringBuilder= new StringBuilder();
            
            //read in and split readIn --> FixedData
            string readIn = Properties.Resources.php;
            // reference https://msdn.microsoft.com/en-us/library/tabh47cf(v=vs.110).aspx
            System.Diagnostics.Debug.WriteLine("Loaded file php");
            string[] splitString = new string[] {"***"};
            fixedData = readIn.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            System.Diagnostics.Debug.WriteLine("Split to " + fixedData.Count() + " entries");
        }

        /// <summary>Calculates the entire output file for the php file</summary>
        /// <param name="Options">Current web formatting related options</param>
        internal void CalculateOutputFile(options Options)
        {
            stringBuilder.Append(fixedData[0]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[1]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[2]);
            stringBuilder.Append(Options.Keywords);
            stringBuilder.Append(fixedData[3]);
            stringBuilder.Append(Options.PhpFileName);
            stringBuilder.Append(fixedData[4]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[5]);
            stringBuilder.Append(Options.Title);
            stringBuilder.Append(fixedData[6]);
            stringBuilder.Append(Options.KeyImage);
            stringBuilder.Append(fixedData[7]);
            stringBuilder.Append(Options.TxtFileName);
            stringBuilder.Append(fixedData[8]);
        }

        /// <summary>Convert string builder to output string</summary>
        /// <returns>String to be output</returns>
        internal string String()
        {
            return stringBuilder.ToString();
        }
    }
}
