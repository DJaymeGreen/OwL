using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwLProject {
    public partial class addLesson : Form {

        database db;
        //List<byte[]> imagesInLesson;
        List<mediaStruct> mediaInLesson;
        int currentShownImageIndex;

        /**
         * A Structure that holds all of the Media information. Associates
         * a piece of media with a title and description
         * */
        /*private struct mediaStruct {
            private String mediaTitle;
            private String mediaDescription;
            private byte[] media;
            public String Title {
                get {
                    return mediaTitle;
                }
                set {
                    mediaTitle = value;
                }
            }
            public String Description {
                get {
                    return mediaDescription;
                }
                set {
                    mediaDescription = value;
                }
            }
            public byte[] Media {
                get {
                    return media;
                }
                set {
                    media = value;
                }
            }
        }
        */
        public addLesson() {
            InitializeComponent();
            db = new database();
            foreach (String title in db.getAllLessonTitles()) {
                addLessonPrereq.Items.Add(title);
            }
            //fullImageDescript = new Dictionary<byte[], string>();
            mediaInLesson = new List<mediaStruct>();
            //imageTitlesInLesson = new List<mediaStruct>();
            currentShownImageIndex = -1;
        }

        private void addLessonNewLessonButton_Click(object sender, EventArgs e) {
            addLessonAllLessons.Hide();
            addLessonAudioRating.Show();
            addLessonAudioRatingLabel.Show();
            addLessonContent.Show();
            addLessonContentLabel.Show();
            addLessonDifficulty.Show();
            addLessonDifficultyLabel.Show();
            addLessonLessonTitle.Show();
            addLessonMedia.Show();
            addLessonMediaAddNewButton.Show();
            addLessonMediaDeleteButton.Show();
            addLessonMediaLabel.Show();
            addLessonMediaNextButton.Show();
            addLessonMediaPreviousButton.Show();
            addLessonNewLessonButton.Show();
            addLessonPopulateButton.Hide();
            addLessonPrereq.Show();
            addLessonPreReqLabel.Show();
            addLessonTitleLabel.Show();
            addLessonUpdateButton.Hide();
            addLessonUploadLabel.Show();
            addLessonUploadLessonButton.Show();
            addLessonVisualRating.Show();
            addLessonVisualRatingLabel.Show();
            addLessonMediaTitle.Show();
            addLessonMediaTitleLabel.Show();
            addLessonMediaDescriptionLabel.Show();
            addLessonMediaDescription.Show();

            //Should also wipe all fields to be default
            addLessonAudioRating.Value = 0;
            addLessonContent.Text = "";
            addLessonDifficulty.Value = 0;
            addLessonLessonTitle.Text = "";
            addLessonMedia.InitialImage = null;
            addLessonMedia.Image = null;
            addLessonPrereq.Text = "";
            addLessonVisualRating.Value = 0;
        }

        private void addLessonUpdateButton_Click(object sender, EventArgs e) {
            foreach(String title in db.getAllLessonTitles()) {
                addLessonAllLessons.Items.Add(title);
            }
            addLessonAllLessons.Show();
            addLessonPopulateButton.Show();
            addLessonNewLessonButton.Hide();
        }

        /*
         * Populates all of the fields based on the database. If there is no
         * title associated with the given title, then an error/message box 
         * pops up.
         * */
        private void addLessonPopulateButton_Click(object sender, EventArgs e) {
            if(addLessonAllLessons.Text.Length < 1) {
                MessageBox.Show("No lesson to populate fields!");
            }
            else if (!db.checkIfLessonTitleExists(addLessonAllLessons.Text)) {
                MessageBox.Show("That lesson doesn't exist!");
            }
            else {
                MessageBox.Show("Should populate all the fields...");
            }
        }

        /**
         * Check all the fields to see if valid and adds the lesson to the lesson table.
         * Should also add to the MediaLesson table all of the Media
         * */
        private void addLessonUploadLessonButton_Click(object sender, EventArgs e) {
            if(addLessonLessonTitle.Text.Length < 1) {
                MessageBox.Show("No Title for the Lesson!");
            }
            else if (addLessonPrereq.Text.Length > 0 && !db.checkIfLessonTitleExists(addLessonPrereq.Text)) {
                MessageBox.Show("That Pre-Req doesn't exist!");
            }
            else if(addLessonDifficulty.Value > 5 && addLessonDifficulty.Value < 0) {
                MessageBox.Show("The Difficulty must be between 0 and 5!");
            }
            else if(addLessonVisualRating.Value > 5 && addLessonVisualRating.Value < 0) {
                MessageBox.Show("The Visual Rating must be between 0 and 5!");
            }
            else if(addLessonAudioRating.Value > 5 && addLessonAudioRating.Value < 0) {
                MessageBox.Show("The Audio Rating must be between 0 and 5!");
            }
            else {
                if (addLessonMedia.Image != null) {
                    mediaStruct oldMedia = new mediaStruct();
                    oldMedia.Description = addLessonMediaDescription.Text;
                    oldMedia.Media = mediaInLesson[currentShownImageIndex].Media;
                    oldMedia.Title = addLessonMediaTitle.Text;
                    mediaInLesson.RemoveAt(currentShownImageIndex);
                    mediaInLesson.Insert(currentShownImageIndex, oldMedia);
                    currentShownImageIndex = mediaInLesson.Count - 1;
                }

                int newLID = db.getAllLessonsCount() + 1;
                String title = addLessonLessonTitle.Text;
                int prereq = ((addLessonPrereq.Text.Length == 0) ? 0 : db.getLidFromTitle(addLessonPrereq.Text));
                int difficulty = (int)addLessonDifficulty.Value;
                Boolean markedTypo = false;
                int contentV = (int)addLessonVisualRating.Value;
                int contentA = (int)addLessonAudioRating.Value;
                int contentO = 10 - (contentV + contentA);
                String content = addLessonContent.Text;

                // DO DB CALL TO CREATE!!!!
                db.addLesson(newLID, title, prereq, difficulty, markedTypo, contentV, contentA, contentO, content);

                // DO DB CALL TO CREATE MEDIA-LESSON!!!!
                foreach(mediaStruct image in mediaInLesson) {
                    //DB call to add to Lesson
                    db.addMediaLesson(newLID, image.Media, image.Title, image.Description);
                }

                MessageBox.Show("Successfully added a lesson! Press New Lesson to erase fields");
            }
        }

        /**
         * Add an image to the Lesson by openning up a windows explorer for them to look at
         * */
        private void addLessonMediaAddNewButton_Click(object sender, EventArgs e) {
            String imageLocation = "";

            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png| All files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK) {
                    //This Works!!!
                    imageLocation = dialog.FileName;
                    //addLessonMedia.ImageLocation = imageLocation;
                    
                }
                //Save old image
                if(addLessonMedia.Image != null) {
                    mediaStruct oldMedia = new mediaStruct();
                    oldMedia.Description = addLessonMediaDescription.Text;
                    oldMedia.Media = mediaInLesson[currentShownImageIndex].Media;
                    oldMedia.Title = addLessonMediaTitle.Text;
                    mediaInLesson.RemoveAt(currentShownImageIndex);
                    mediaInLesson.Insert(currentShownImageIndex, oldMedia);
                    currentShownImageIndex = mediaInLesson.Count - 1;
                }
                //Testing to byte[]
                byte[] image = null;
                FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                //Testing byte[] to image
                MemoryStream ms = new MemoryStream(image);
                addLessonMedia.Image = Image.FromStream(ms);

                mediaStruct newMedia = new mediaStruct();
                newMedia.Description = "";
                newMedia.Media = image;
                newMedia.Title = "";
                mediaInLesson.Add(newMedia);
                currentShownImageIndex++;
                
                
                //currentShownImageIndex++;
                //newMedia.Title = addLessonMediaTitle.Text;
                //newMedia.Description = addLessonMediaDescription.Text;
                //mediaInLesson.Add(newMedia);

                //Adjust the look of the page
                addLessonMediaTitle.Enabled = true;
                addLessonMediaDescription.Enabled = true;
                addLessonMediaTitle.Text = "";
                addLessonMediaDescription.Text = "";
            }
            catch (Exception) {
                MessageBox.Show("Error openning up your dialog box");
            }
        }

        /**
         * Forward (+1) through the images uploaded, but not saved currently
         * */
        private void addLessonMediaNextButton_Click(object sender, EventArgs e) {
            if(mediaInLesson.Count > 1) {
                //Save old media's title and description
                //mediaInLesson[currentShownImageIndex].Title = addLessonMediaTitle.Text;
                mediaStruct mediaToAdd = new mediaStruct();
                mediaToAdd.Description = addLessonMediaDescription.Text;
                mediaToAdd.Title = addLessonMediaTitle.Text;
                mediaToAdd.Media = mediaInLesson[currentShownImageIndex].Media;
                mediaInLesson.RemoveAt(currentShownImageIndex);
                mediaInLesson.Insert(currentShownImageIndex, mediaToAdd);

                if(mediaInLesson.Count == currentShownImageIndex + 1) {
                    currentShownImageIndex = 0;
                }
                else {
                    currentShownImageIndex += 1;
                }
                //Show that image, description, title
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                addLessonMedia.Image = Image.FromStream(ms);
                addLessonMediaTitle.Text = mediaInLesson[currentShownImageIndex].Title;
                addLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }
        }

        // Show the image the is -1 in the imagesInLesson list
        private void addLessonMediaPreviousButton_Click(object sender, EventArgs e) {
            if (mediaInLesson.Count > 1) {
                //Save the current image stuff
                mediaStruct mediaToAdd = new mediaStruct();
                mediaToAdd.Description = addLessonMediaDescription.Text;
                mediaToAdd.Title = addLessonMediaTitle.Text;
                mediaToAdd.Media = mediaInLesson[currentShownImageIndex].Media;
                mediaInLesson.RemoveAt(currentShownImageIndex);
                mediaInLesson.Insert(currentShownImageIndex, mediaToAdd);
                if (0 > currentShownImageIndex - 1) {
                    currentShownImageIndex = mediaInLesson.Count-1;
                }
                else {
                    currentShownImageIndex -= 1;
                }
                //Show that image
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                addLessonMedia.Image = Image.FromStream(ms);
                addLessonMediaTitle.Text = mediaInLesson[currentShownImageIndex].Title;
                addLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }


        }

        // "Delete" the image from the list of images
        private void addLessonMediaDeleteButton_Click(object sender, EventArgs e) {
            if(mediaInLesson.Count >= 1) {
                mediaInLesson.RemoveAt(currentShownImageIndex);
                //Adjust currentShownImageIndex
                if (mediaInLesson.Count == 0) {
                    currentShownImageIndex = -1;
                }
                else {
                    currentShownImageIndex -= 1;
                    if(currentShownImageIndex < 0) {
                        currentShownImageIndex = mediaInLesson.Count - 1;
                    }
                }
                //Show the correct image
                if(mediaInLesson.Count == 0) {
                    addLessonMedia.Image = null;
                    addLessonMediaDescription.Text = "";
                    addLessonMediaTitle.Text = "";
                    addLessonMediaDescription.Enabled = false;
                    addLessonMediaTitle.Enabled = false;
                }
                else {
                    MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                    addLessonMedia.Image = Image.FromStream(ms);
                    addLessonMediaTitle.Text = mediaInLesson[currentShownImageIndex].Title;
                    addLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
                }
            }
        }
    }
}
