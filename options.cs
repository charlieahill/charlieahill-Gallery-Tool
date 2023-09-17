using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace charlieahill_Gallery_Tool
{
    public partial class options : Form
    {
        public options()
        {
            System.Diagnostics.Debug.WriteLine("Loaded options.cs");
            InitializeComponent();
            txtOutputPath.Text = outputPath;
        }

        /******************************VARS***********************/
        #region VARIABLES
        #region output Path
        private string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public string OutputPath
        {
            get { return outputPath; }
        }

        private int galNumber = 0;
        /// <summary>The gallery number when uploaded to the internet site</summary>
        public int GalNumber
        {
            get { return galNumber; }
            set
            {
                galNumber = value;
                RecalcFileNames();
            }
        }

        private bool agExport = false;
        /// <summary>Marks the export as for the agricultural site and adds "/ag/" to the export path</summary>
        public bool AgExport
        {
            get { return agExport; }
            set
            {
                agExport = value;
            }
        }


        private string title = "";
        /// <summary>Returns the gallery title</summary>
        public string Title
        {
            get { return title; }
        }

        private string galleryDescription = "";
        /// <summary>Returns the gallery title</summary>
        public string GalleryDescription
        {
            get { return galleryDescription; }
        }
        
        private string galleryDate = "";
        /// <summary>Returns the gallery date</summary>
        public string GalleryDate
        {
            get { return galleryDate; }
        }

        private string keywords = "";
        /// <summary>Returns the gallery keywords</summary>
        public string Keywords
        {
            get { return keywords; }
        }

        private string phpFileName = "gal000.php";
        /// <summary>Returns the php filename</summary>
        public string PhpFileName
        {
            get { return phpFileName; }
            set { phpFileName = value; }
        }

        private string txtFileName = "gal000.txt";
        /// <summary>Returns the php filename</summary>
        public string TxtFileName
        {
            get { return txtFileName; }
            set { txtFileName = value; }
        }

        private int keyImageIndex = 0;
        /// <summary>Stores the index number of the currently selected key image within the gallery</summary>
        public int KeyImageIndex
        {
            get { return keyImageIndex; }
            set { keyImageIndex = value; }
        }

        private string keyImage = "gal000.jpg";
        /// <summary>Returns the key image filename (e.g. gal001.jpg</summary>
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        private string galleryName = "gal000";
        /// <summary>Returns the gallery name (e.g. gal000)</summary>
        public string GalleryName
        {
            get { return galleryName; }
            set { galleryName = value; }
        }
        #endregion

        #region Downloadable Images
        private bool downloadableImage = true;
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public bool DowloadableImage
        {
            get { return downloadableImage; }
        }

        private string downloadableSuffix = "full";
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public string DownloadableSuffix
        {
            get { return downloadableSuffix; }
        }

        /// <summary>Private tab pages</summary>
        private TabPage tabPageDownload;
        #endregion

        #region tab Images
        private string tabSuffix = "tab";
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public string TabSuffix
        {
            get { return tabSuffix; }
        }

        private bool tabImage = true;
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public bool TabImage
        {
            get { return tabImage; }
        }

        private ResizingParams tabImageResizingParams = new ResizingParams(ResizingParams.ResizeModeEnum.cropToFit, ResizingParams.MARModeEnum.scaleToWidth, ResizingParams.CropModeEnum.cropScaleToWidth, 0, 0, 220, 0, 0, 124);
        /// <summary>Parameters that determine how the image resizing is performed</summary>
        public ResizingParams TabImageResizingParams
        {
            get { return tabImageResizingParams; }
        }
        #endregion

        #region main Images
        private string mainSuffix = "";
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public string MainSuffix
        {
            get { return mainSuffix; }
        }

        private bool mainImage = true;
        /// <summary>Boolean option set to generate a downloadable image in the output file</summary>
        public bool MainImage
        {
            get { return mainImage; }
        }

        private string youTubeLink = string.Empty;
        /// <summary>YouTube video link if one is available</summary>
        public string YouTubeLink
        {
            get { return youTubeLink; }
            set { youTubeLink = value; }
        }


        private ResizingParams mainImageResizingParams = new ResizingParams(ResizingParams.ResizeModeEnum.maintainAspect, ResizingParams.MARModeEnum.scaleToWidth, ResizingParams.CropModeEnum.cropScaleToHeight, 1660, 0, 0, 0, 0, 0);
        /// <summary>Parameters that determine how the image resizing is performed</summary>
        public ResizingParams MainImageResizingParams
        {
            get { return mainImageResizingParams; }
        }
        #endregion
        #endregion

        private ObservableCollection<ImageContainer> images;

        /***********************USER SELECTIONS**********************/
        #region USER_SELECTIONS
        #region generalFormOptions
        /// <summary>Prevent the form from closing, so as to keep data in memory</summary>
        private void options_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hides the current form
            this.Hide();

            //Cancels the close event
            e.Cancel = true;
        }
        #endregion

        #region OutputUserOptions
        /// <summary>Allow the user to select the output file path</summary>
        private void btnOutputSelect_Click(object sender, EventArgs e)
        {
            if(fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            txtOutputPath.Text = fbd.SelectedPath;
        }

        /// <summary>Overwrites existing output path with output path from clipboard</summary>
        private void btnPaste_Click(object sender, EventArgs e)
        {
            txtOutputPath.Text = Clipboard.GetText();
        }

        /// <summary>Update output directory path to reflect change</summary>
        private void txtOutputPathChanged_TextChanged(object sender, EventArgs e)
        {
            outputPath = txtOutputPath.Text;
            Debug("New output path set as " + outputPath);
            if(Directory.Exists(outputPath))
                Debug("output directory OK");
            else
                Debug("output directory NOK");
        }

        /// <summary>User changes the current gallery number</summary>
        private void numGalNumber_ValueChanged(object sender, EventArgs e)
        {
            GalNumber = (int)numGalNumber.Value;
        }

        /// <summary>User changes the output title text</summary>
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            title = txtTitle.Text;
        }

        /// <summary>User changes the description text</summary>
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            galleryDescription = txtDescription.Text;
        }

        /// <summary>User changes the gallery date</summary>
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            galleryDate = txtDate.Text;
        }

        /// <summary>User changes the keywords assigned to the gallery</summary>
        private void txtKeywords_TextChanged(object sender, EventArgs e)
        {
            keywords = txtKeywords.Text;
        }

        private void chkDownload_CheckedChanged(object sender, EventArgs e)
        {
            downloadableImage = chkDownload.Checked;
            Debug("chkDownload changed to chkDownload: " + chkDownload.Checked);
            ShowHideTab("tabDownload", chkDownload.Checked);
        }

        private void chkTab_CheckedChanged(object sender, EventArgs e)
        {
            tabImage = chkTab.Checked;
            Debug("tabImage changed to tabImage: " + chkTab.Checked);
            ShowHideTab("tabTab", chkTab.Checked);
        }

        private void chkMain_CheckedChanged(object sender, EventArgs e)
        {
            mainImage = chkTab.Checked;
            Debug("mainImage changed to mainImage: " + chkMain.Checked);
            ShowHideTab("tabMain", chkMain.Checked);
        }
        #endregion

        #region DownloadImagesUserOptions
        /// <summary>User changes the downloadable suffix text</summary>
        private void txtDownloadableSuffix_TextChanged(object sender, EventArgs e)
        {
            downloadableSuffix = txtDownloadableSuffix.Text;
        }
        #endregion

        #region TabImagesUserOptions
        /// <summary>User changes the tab image suffix text</summary>
        private void txtTabSuffix_TextChanged(object sender, EventArgs e)
        {
            tabSuffix = txtTabSuffix.Text;
        }

        /// <summary>Crop to Fit Radio Button Changes Checkedness</summary>
        private void radTabCropToFit_CheckedChanged(object sender, EventArgs e)
        {            
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                tabImageResizingParams.ResizeMode = ResizingParams.ResizeModeEnum.cropToFit;

                //Update GUI
                EnableTabNumericBoxes();
            }
        }

        /// <summary>Maintain Aspect Radio Button Changes Checkedness</summary>
        private void radTabMaintainAspect_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                tabImageResizingParams.ResizeMode = ResizingParams.ResizeModeEnum.maintainAspect;

                //Update GUI
                EnableTabNumericBoxes();
            }
        }

        /// <summary>MAR: Scale to width Button Changes Checkedness</summary>
        private void radTabMaintainWidth_CheckedChanged(object sender, EventArgs e)
        {
            //Update Resize Params
            if(((RadioButton)sender).Checked)
                tabImageResizingParams.MarMode = ResizingParams.MARModeEnum.scaleToWidth;

            //Update GUI
            EnableTabNumericBoxes();
        }

        /// <summary>MAR: Scale to height Button Changes Checkedness</summary>
        private void radTabMaintainHeight_CheckedChanged(object sender, EventArgs e)
        {
            
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                tabImageResizingParams.MarMode = ResizingParams.MARModeEnum.scaleToHeight;

                //Update GUI
                EnableTabNumericBoxes();
            }
        }

        /// <summary>MAR Width: Maintain Width value changes</summary>
        private void numTabMaintainWidth_ValueChanged(object sender, EventArgs e)
        {
            tabImageResizingParams.MarWidth = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>MAR Height: Maintain height value changes</summary>
        private void numTabMaintainHeight_ValueChanged(object sender, EventArgs e)
        {
            tabImageResizingParams.MarHeight = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop: Scale to width Button Changes Checkedness</summary>
        private void radTabScaleWidth_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                tabImageResizingParams.CropScalingMode = ResizingParams.CropModeEnum.cropScaleToWidth;

                //Update GUI
                EnableTabNumericBoxes();
            }
        }

        /// <summary>Crop: Scale to height Button Changes Checkedness</summary>
        private void radTabScaleHeight_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                tabImageResizingParams.CropScalingMode = ResizingParams.CropModeEnum.cropScaleToHeight;

                //Update GUI
                EnableTabNumericBoxes();
            }
        }

        /// <summary>Crop Width: scale to width value changes</summary>
        private void numTabScaleWidth_ValueChanged(object sender, EventArgs e)
        {
            tabImageResizingParams.CropScalingWidth = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop Height: scale to Height value changes</summary>
        private void numTabScaleHeight_ValueChanged(object sender, EventArgs e)
        {
            tabImageResizingParams.CropScalingHeight = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop Width: trim to Height value changes</summary>
        private void numTabTrimtoHeight_ValueChanged(object sender, EventArgs e)
        {
            tabImageResizingParams.CropTrimHeight = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop Height: trim to width value changes</summary>
        private void numTabTrimtoWidth_ValueChanged(object sender, EventArgs e)
        {
            tabImageResizingParams.CropTrimWidth = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Enable and disable numeric boxes depending on current logic</summary>
        private void EnableTabNumericBoxes()
        {
            //Disable all numeric up downs
            numTabScaleHeight.Enabled = false;
            numTabTrimtoWidth.Enabled = false;
            numTabScaleWidth.Enabled = false;
            numTabTrimtoHeight.Enabled = false;
            numTabMaintainHeight.Enabled = false;
            numTabMaintainWidth.Enabled = false;

            //Disable all radio buttons
            radTabMaintainHeight.Enabled = false;
            radTabMaintainWidth.Enabled = false;
            radTabScaleHeight.Enabled = false;
            radTabScaleWidth.Enabled = false;
            
            Debug("1/4: Enable numeric boxes routine:");
            Debug("2/4: Processing mode: " + tabImageResizingParams.ResizeMode.ToString());
            Debug("3/4: MAR Settings: " + tabImageResizingParams.MarMode.ToString());
            Debug("4/4: Crop Settings: " + tabImageResizingParams.CropScalingMode.ToString());

            //MAR
            if(tabImageResizingParams.ResizeMode == ResizingParams.ResizeModeEnum.maintainAspect)
            {
                //Enable radio buttons
                radTabMaintainHeight.Enabled = true;
                radTabMaintainWidth.Enabled = true;

                //Width
                if(tabImageResizingParams.MarMode == ResizingParams.MARModeEnum.scaleToWidth)
                    numTabMaintainWidth.Enabled = true;
                //Height
                if(tabImageResizingParams.MarMode == ResizingParams.MARModeEnum.scaleToHeight)
                    numTabMaintainHeight.Enabled = true;
            }
            //Crop
            if(tabImageResizingParams.ResizeMode == ResizingParams.ResizeModeEnum.cropToFit)
            {
                //Enable radio buttons
                radTabScaleHeight.Enabled = true;
                radTabScaleWidth.Enabled = true;

                //Width
                if(tabImageResizingParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToWidth)
                {
                    numTabScaleWidth.Enabled = true;
                    numTabTrimtoHeight.Enabled = true;
                }
                //Crop to Height
                if(tabImageResizingParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToHeight)
                {
                    numTabScaleHeight.Enabled = true;
                    numTabTrimtoWidth.Enabled = true;
                }
            }
        }
        #endregion

        #region MainImageUserOptions
        /// <summary>User changes the tab image suffix text</summary>
        private void txtMainSuffix_TextChanged(object sender, EventArgs e)
        {
            mainSuffix = txtMainSuffix.Text;
        }

        /// <summary>Crop to Fit Radio Button Changes Checkedness</summary>
        private void radMainCropToFit_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                mainImageResizingParams.ResizeMode = ResizingParams.ResizeModeEnum.cropToFit;

                //Update GUI
                EnableMainNumericBoxes();
            }
        }

        /// <summary>Maintain Aspect Radio Button Changes Checkedness</summary>
        private void radMainMaintainAspect_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                mainImageResizingParams.ResizeMode = ResizingParams.ResizeModeEnum.maintainAspect;

                //Update GUI
                EnableMainNumericBoxes();
            }
        }

        /// <summary>MAR: Scale to width Button Changes Checkedness</summary>
        private void radMainMaintainWidth_CheckedChanged(object sender, EventArgs e)
        {
            //Update Resize Params
            if(((RadioButton)sender).Checked)
                mainImageResizingParams.MarMode = ResizingParams.MARModeEnum.scaleToWidth;

            //Update GUI
            EnableMainNumericBoxes();
        }

        /// <summary>MAR: Scale to height Button Changes Checkedness</summary>
        private void radMainMaintainHeight_CheckedChanged(object sender, EventArgs e)
        {

            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                mainImageResizingParams.MarMode = ResizingParams.MARModeEnum.scaleToHeight;

                //Update GUI
                EnableMainNumericBoxes();
            }
        }

        /// <summary>MAR Width: Maintain Width value changes</summary>
        private void numMainMaintainWidth_ValueChanged(object sender, EventArgs e)
        {
            mainImageResizingParams.MarWidth = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>MAR Height: Maintain height value changes</summary>
        private void numMainMaintainHeight_ValueChanged(object sender, EventArgs e)
        {
            mainImageResizingParams.MarHeight = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop: Scale to width Button Changes Checkedness</summary>
        private void radMainScaleWidth_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                mainImageResizingParams.CropScalingMode = ResizingParams.CropModeEnum.cropScaleToWidth;

                //Update GUI
                EnableMainNumericBoxes();
            }
        }

        /// <summary>Crop: Scale to height Button Changes Checkedness</summary>
        private void radMainScaleHeight_CheckedChanged(object sender, EventArgs e)
        {
            if(((RadioButton)sender).Checked)
            {
                //Update Resize Params
                mainImageResizingParams.CropScalingMode = ResizingParams.CropModeEnum.cropScaleToHeight;

                //Update GUI
                EnableMainNumericBoxes();
            }
        }

        /// <summary>Crop Width: scale to width value changes</summary>
        private void mainTabScaleWidth_ValueChanged(object sender, EventArgs e)
        {
            mainImageResizingParams.CropScalingWidth = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop Height: scale to Height value changes</summary>
        private void numMainScaleHeight_ValueChanged(object sender, EventArgs e)
        {
            mainImageResizingParams.CropScalingHeight = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop Width: trim to Height value changes</summary>
        private void numMainTrimtoHeight_ValueChanged(object sender, EventArgs e)
        {
            mainImageResizingParams.CropTrimHeight = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Crop Height: trim to width value changes</summary>
        private void numMainTrimtoWidth_ValueChanged(object sender, EventArgs e)
        {
            mainImageResizingParams.CropTrimWidth = (int)((NumericUpDown)sender).Value;
        }

        /// <summary>Enable and disable numeric boxes depending on current logic</summary>
        private void EnableMainNumericBoxes()
        {
            //Disable all numeric up downs
            numMainScaleHeight.Enabled = false;
            numMainTrimtoWidth.Enabled = false;
            numMainScaleWidth.Enabled = false;
            numMainTrimtoHeight.Enabled = false;
            numMainMaintainHeight.Enabled = false;
            numMainMaintainWidth.Enabled = false;

            //Disable all radio buttons
            radMainMaintainHeight.Enabled = false;
            radMainMaintainWidth.Enabled = false;
            radMainScaleHeight.Enabled = false;
            radMainScaleWidth.Enabled = false;

            Debug("1/4: Enable numeric boxes routine (main image):");
            Debug("2/4: Processing mode: " + mainImageResizingParams.ResizeMode.ToString());
            Debug("3/4: MAR Settings: " + mainImageResizingParams.MarMode.ToString());
            Debug("4/4: Crop Settings: " + mainImageResizingParams.CropScalingMode.ToString());

            //MAR
            if(mainImageResizingParams.ResizeMode == ResizingParams.ResizeModeEnum.maintainAspect)
            {
                //Enable radio buttons
                radMainMaintainHeight.Enabled = true;
                radMainMaintainWidth.Enabled = true;

                //Width
                if(mainImageResizingParams.MarMode == ResizingParams.MARModeEnum.scaleToWidth)
                    numMainMaintainWidth.Enabled = true;
                //Height
                if(mainImageResizingParams.MarMode == ResizingParams.MARModeEnum.scaleToHeight)
                    numMainMaintainHeight.Enabled = true;
            }
            //Crop
            if(mainImageResizingParams.ResizeMode == ResizingParams.ResizeModeEnum.cropToFit)
            {
                //Enable radio buttons
                radMainScaleHeight.Enabled = true;
                radMainScaleWidth.Enabled = true;

                //Width
                if(mainImageResizingParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToWidth)
                {
                    numMainScaleWidth.Enabled = true;
                    numMainTrimtoHeight.Enabled = true;
                }
                //Crop to Height
                if(mainImageResizingParams.CropScalingMode == ResizingParams.CropModeEnum.cropScaleToHeight)
                {
                    numMainScaleHeight.Enabled = true;
                    numMainTrimtoWidth.Enabled = true;
                }
            }
        }
        #endregion
        #endregion

        /************************USEFUL STUFF**********************/
        #region USEFUL_STUFF
        /// <summary>output text to the debug screen</summary>
        /// <param name="debugText">Text to shown in the Visual Studio debug window</param>
        private void Debug(string debugText)
        {
            System.Diagnostics.Debug.WriteLine(debugText);
        }

        /// <summary>Show / hide tabs as necessary</summary>
        /// <param name="tabName">The tab name to hide or show as necessary</param>
        /// <param name="isVisible">Should that tab be visible?</param>
        void ShowHideTab(string tabName, bool isVisible)
        {
            //show or hide relevant tab
            if(isVisible)
            {
                optionsTabs.TabPages.Add(tabPageDownload);
            }
            else
            {
                int previousIndex = optionsTabs.SelectedIndex;

                int tabIndex = optionsTabs.TabPages.IndexOfKey(tabName);
                optionsTabs.SelectedIndex = tabIndex;

                tabPageDownload = optionsTabs.SelectedTab;
                optionsTabs.TabPages.RemoveAt(tabIndex);

                optionsTabs.SelectedIndex = previousIndex;
            }
        }

        /// <summary>Returns a string format of a number, padded to three spaces with leading zeroes</summary>
        /// <param name="number">The number to re-format</param>
        /// <returns>Three digit (or more if necessary) string version of "number"</returns>
        private string ThreeDigit(int number)
        {
            if(number < 0)
                return "err";
            if(number < 10)
                return "00" + number.ToString();
            if(number < 100)
                return "0" + number.ToString();

            return number.ToString();
        }
#endregion

        #region Recalcs
        /// <summary>File name recalculation as a result of gallery number being changed</summary>
        private void RecalcFileNames()
        {
            Debug("Re-calculating file names...");
            GalleryName = "gal" + ThreeDigit(GalNumber);
            PhpFileName = GalleryName + ".php";
            TxtFileName = GalleryName + ".txt";
            KeyImage = GalleryName + ".jpg";
            Debug("Re-calculation complete.");
        }
        #endregion

        private void chkAgSite_CheckedChanged(object sender, EventArgs e)
        {
            AgExport = chkAgSite.Checked;
        }

        private void YouTubeTextBox_TextChanged(object sender, EventArgs e)
        {
            youTubeLink = YouTubeTextBox.Text;
        }
    }
}
