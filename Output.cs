using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charlieahill_Gallery_Tool
{
    class output
    {
        //output string builders
        private php _PHP;
        /// <summary>Contains the string builder for the PHP file to be output</summary>
        public php PHP
        {
            get { return _PHP; }
        }

        private gallery _GALLERY;
        /// <summary>Contains the string builder for the PHP file to be output</summary>
        public gallery GALLERY
        {
            get { return _GALLERY; }
        }

        private index _INDEX;
        /// <summary>Contains the string builder for the PHP file to be output</summary>
        public index INDEX
        {
            get { return _INDEX; }
        }

        private txt _TXT;
        /// <summary>Contains the string builder for the PHP file to be output</summary>
        public txt TXT
        {
            get { return _TXT; }
        }

        public output(options Options)
        {
            //Intialise all parts
            _PHP = new php();
            _TXT = new txt(Options);
            _INDEX = new index();
            _GALLERY = new gallery();
        }

        /// <summary>Start building the strings up</summary>
        public void InitialiseStringBuilders(options Options)
        {
            _PHP = new php();
            _TXT = new txt(Options);
            _INDEX = new index();
            _GALLERY = new gallery();
        }

        /// <summary>Determines all relevant text based files up to the point where the images are required</summary>
        /// <param name="Options">Current web formatting related options</param>
        internal void PrepareAllFiles(options Options)
        {
            //php complete
            PHP.CalculateOutputFile(Options);
            //start txt
            TXT.StartOutputFile(Options);
            //start gallery file
            GALLERY.CalculateOutputFile(Options);
        }

        /// <summary>Output all files to hdd</summary>
        internal void OutputAllFiles(options Options, string outputPath)
        {
            string filename = outputPath + "\\" + Options.PhpFileName;
            System.Diagnostics.Debug.WriteLine("Writing to php file at " + filename);
            File.WriteAllText(filename, PHP.String());

            filename = outputPath + "\\" + Options.TxtFileName;
            System.Diagnostics.Debug.WriteLine("Writing to txt file at " + filename);
            File.WriteAllText(filename, TXT.String());

            //Create ZIP of content - https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.zipfile?view=net-7.0
            ZipFile.CreateFromDirectory(filename, $"{filename}\\upload.zip");

            filename = outputPath + "\\readme_index.txt";
            System.Diagnostics.Debug.WriteLine("Writing to index file at " + filename);
            File.WriteAllText(filename, INDEX.String());

            filename = outputPath + "\\readme_gallery.txt";
            System.Diagnostics.Debug.WriteLine("Writing to gallery file at " + filename);
            File.WriteAllText(filename, GALLERY.String());
        }
    }
}
