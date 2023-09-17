using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace charlieahill_Gallery_Tool
{
    public partial class Form1 : Form
    {
        /// <summary>Calls the form</summary>
        public Form1()
        {
            InitializeComponent();
            resizer = new Resizer();
        }

        options Options;
        ObservableCollection<ImageContainer> Images;
        string[] files;
        Resizer resizer;
        int displayedImage;
        output Output;

        /// <summary>Load subsidary info on form load</summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            Options = new options();
            Output = new output(Options);
            //Initialise Images
            Images = new ObservableCollection<ImageContainer>();
        }

        /// <summary>User clicks select image tool strip icon</summary>
        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            files = openFileDialog1.FileNames;

            //Load image from file
            foreach(string filename in files)
                //Images.Add(new ImageContainer((Bitmap)Image.FromFile(filename), ""));
                Images.Add(new ImageContainer(System.Drawing.Image.FromFile(filename), ""));
                
            displayedImage = 0;
            pictureBox1.Image = Images[displayedImage].Img;
            IndexIdentifierLabel.Text = $"{displayedImage + 1}/{Images.Count}";

            ShowAllImagesInListView();
            UpdateStatusMarkersKeyAndPreviewImages();
        }

        private void ShowAllImagesInListView() 
        {
            imagesListView.LargeImageList = null;

            imagesListView.Items.Clear();

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(128, 96);
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            int counter = 0;

            foreach (ImageContainer img in Images)
            {
                imageList.Images.Add(img.Img);
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = counter.ToString();
                listViewItem.ImageIndex = counter;
                imagesListView.Items.Add(listViewItem);
                counter++;
            }
            Clipboard.SetImage(imageList.Images[0]);
            
            imagesListView.LargeImageList = imageList;
            imagesListView.View = View.LargeIcon;
            IndexIdentifierLabel.Text = $"{displayedImage + 1}/{Images.Count}";
        }

        /// <summary>User clicks generate output tool strip icon</summary>
        private void generateOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Options.ShowDialog() != DialogResult.OK)
                return;

            string folderPath = Options.OutputPath;
            int imageNumber = 0;

            //Check outputPath is OK
            if(!Directory.Exists(Options.OutputPath))
            {
                Debug("output directory is not valid: " + Options.OutputPath, true);
                return;
            }

            //If the gallery directory currently exists, delete it
            folderPath += "\\" + Options.GalleryName;
            if(Directory.Exists(folderPath))
                Directory.Delete(folderPath, true);

            Directory.CreateDirectory(folderPath);

            //Check Images is OK
            if(Images == null)
            {
                Debug("Image is not valid / has not been selected", true);
                return;
            }

            //Start building internet page
            Output.InitialiseStringBuilders(Options);
            Output.PrepareAllFiles(Options);

            foreach(ImageContainer workingImage in Images)
            {
                string imageName = "imag" + ThreeDigit(imageNumber);
                string outputDirectory = folderPath + "\\gal" + ThreeDigit(Options.GalNumber);
                Directory.CreateDirectory(outputDirectory);
                string outputPath = outputDirectory + "\\";
                Debug("Outputting files " + outputPath);
                Debug("Testing: DownloadableImage " + Options.DowloadableImage.ToString());

                //output downloadable image
                if(Options.DowloadableImage)
                {
                    Debug("Outputting downloadable image " + outputPath);
                    workingImage.DownloadImageFilename = imageName + Options.DownloadableSuffix + ".jpg";
                    workingImage.Img.Save(outputPath + workingImage.DownloadImageFilename, ImageFormat.Jpeg);
                }

                //output tab image
                if(Options.TabImage)
                {
                    Debug("Outputting tab image " + outputPath);
                    System.Drawing.Image tabImage = resizer.Resize(workingImage.Img, Options.TabImageResizingParams);
                    workingImage.TabImageFilename = imageName + Options.TabSuffix + ".jpg";
                    tabImage.Save(outputPath + workingImage.TabImageFilename, ImageFormat.Jpeg);
                    //Output gallery key if relevant
                    if(Options.KeyImageIndex == Images.IndexOf(workingImage))
                        tabImage.Save(folderPath + "\\" + Options.KeyImage);
                    tabImage.Dispose();
                }

                //output main image
                if(Options.MainImage)
                {
                    Debug("Outputting main image " + outputPath);
                    System.Drawing.Image mainImage = resizer.Resize(workingImage.Img, Options.MainImageResizingParams);
                    workingImage.MainImageFilename = imageName + Options.MainSuffix + ".jpg";
                    mainImage.Save(outputPath + workingImage.MainImageFilename, ImageFormat.Jpeg);
                    mainImage.Dispose();
                }

                //Update files
                Output.TXT.AddImageToOutputFile(Options, workingImage);

                Debug("Completed image " + imageNumber);
                imageNumber++;
            }

            Output.TXT.CompleteOutputFile();
            Output.INDEX.CalculateOutputFile(Options, Images);

            Output.OutputAllFiles(Options, folderPath);

            Debug("Complete", false);

            UploadScreen completedScreen = new UploadScreen(folderPath, Output.GALLERY.StringNoBlurb(), Output.INDEX.StringNoBlurb());
            completedScreen.Show();
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

        /// <summary>output text to the debug screen</summary>
        /// <param name="debugText">Text to shown in the Visual Studio debug window</param>
        private void Debug(string debugText, bool messageBox = false)
        {
            System.Diagnostics.Debug.WriteLine(debugText);
            if(messageBox)
                MessageBox.Show(debugText);
        }

        /// <summary>Text to caption image changes</summary>
        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            Images[displayedImage].Caption = txtCaption.Text;
        }

        /// <summary>User changes if the image should be displayed as a preview image</summary>
        /*private void chcIndexable_CheckedChanged(object sender, EventArgs e)
        {
            Images[displayedImage].Indexable = ((CheckBox)sender).Checked;
        }*/

        /// <summary>Sets currently shown image as key image for entire gallery</summary>
        private void setKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options.KeyImageIndex = displayedImage;
            Debug("Key image set to " + Options.KeyImageIndex);
        }

        /// <summary>User requests the version history</summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Images.Count() == 0)
                return;

            displayedImage++;

            if (displayedImage == Images.Count())
                displayedImage = 0;

            pictureBox1.Image = Images[displayedImage].Img;

            txtCaption.Text = Images[displayedImage].Caption;
            IndexIdentifierLabel.Text = $"{displayedImage + 1}/{Images.Count}";
            UpdateStatusMarkersKeyAndPreviewImages();
        }

        private void UpdateStatusMarkersKeyAndPreviewImages()
        {
            if(Options.KeyImageIndex == displayedImage) 
                KeyImageButton.BackColor = Color.Green;
            else
                KeyImageButton.BackColor = Color.White;

            int counter = 0;
            foreach (ImageContainer image in Images)
            {
                if (image.Indexable)
                    counter++;
            }

            PreviewImageButton1.Text = counter.ToString();

            if (Images[displayedImage].Indexable)
            {
                PreviewImageButton1.ForeColor = Color.White;
                if (counter < 4) PreviewImageButton1.BackColor = Color.Blue;
                if (counter == 4) PreviewImageButton1.BackColor = Color.Green;
                if (counter > 4) PreviewImageButton1.BackColor = Color.Red;
            }
            else
            {
                PreviewImageButton1.BackColor = Color.White;
                PreviewImageButton1.ForeColor = Color.Black;
                if(counter == 4) PreviewImageButton1.ForeColor = Color.Green;
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (Images.Count() == 0)
                return;
            
            displayedImage--;

            if (displayedImage == -1)
                displayedImage = Images.Count() - 1;

            pictureBox1.Image = Images[displayedImage].Img;

            txtCaption.Text = Images[displayedImage].Caption;
            IndexIdentifierLabel.Text = $"{displayedImage + 1}/{Images.Count}";
            UpdateStatusMarkersKeyAndPreviewImages();
        }

        private void imagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(imagesListView.SelectedItems.Count == 0) return;

            int indexFromSelection = imagesListView.SelectedIndices[0];

            if (Images.Count() == 0)
                return;

            displayedImage = indexFromSelection;

            if (displayedImage == Images.Count())
                displayedImage = 0;

            pictureBox1.Image = Images[displayedImage].Img;

            txtCaption.Text = Images[displayedImage].Caption;
            IndexIdentifierLabel.Text = $"{displayedImage + 1}/{Images.Count}";
            UpdateStatusMarkersKeyAndPreviewImages();
        }

        private void IncreaseOrderButton_Click(object sender, EventArgs e)
        {
            if (imagesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the item you wish to move up the order in the list before proceeding.");
                return;
            }

            int selectedIndex = imagesListView.SelectedIndices[0];

            if(selectedIndex == 0 ) return;

            Images.Move(selectedIndex, selectedIndex-1);
            displayedImage--;
            ShowAllImagesInListView();
        }

        private void RemoveImageButton_Click(object sender, EventArgs e)
        {
            if (imagesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the item you wish to move up the order in the list before proceeding.");
                return;
            }

            int selectedIndex = imagesListView.SelectedIndices[0];

            Images.RemoveAt(selectedIndex);
            ShowAllImagesInListView();
        }

        private void decreaseOrderButton_Click(object sender, EventArgs e)
        {
            if (imagesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the item you wish to move up the order in the list before proceeding.");
                return;
            }

            int selectedIndex = imagesListView.SelectedIndices[0];

            if (selectedIndex == imagesListView.Items.Count - 1) return;

            Images.Move(selectedIndex, selectedIndex + 1);
            displayedImage++;
            ShowAllImagesInListView();
        }

        private void KeyImageButton_Click(object sender, EventArgs e)
        {
            Options.KeyImageIndex = displayedImage;
            UpdateStatusMarkersKeyAndPreviewImages();
        }

        private void PreviewImageButton1_Click(object sender, EventArgs e)
        {
            Images[displayedImage].Indexable = !Images[displayedImage].Indexable;
            UpdateStatusMarkersKeyAndPreviewImages();
        }
    }
}