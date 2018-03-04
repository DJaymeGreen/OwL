using System;
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
    public partial class viewLesson : Form {

        List<mediaStruct> mediaInLesson;
        int currentShownImageIndex;
        database db;

        public viewLesson(String lessonTitle) {
            db = new database();
            InitializeComponent();
            int LID = db.getLidFromTitle(lessonTitle);
            //Generate all of the right shown stuff
            viewLessonTitleLabel.Text = lessonTitle;
            viewLessonContent.Text = db.getLessonContent(LID);
            mediaInLesson = db.getAllMediaForLesson(LID);
            currentShownImageIndex = 0;

            //No Images for the Lesson...
            if (mediaInLesson.Count < 1) {
                viewLessonImageTitleLable.Hide();
                viewLessonMedia.Hide();
                viewLessonMediaDescription.Hide();
                viewLessonNextMedia.Hide();
                viewLessonPreviousMedia.Hide();
            }
            else {
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                viewLessonMedia.Image = Image.FromStream(ms);
                viewLessonImageTitleLable.Text = mediaInLesson[currentShownImageIndex].Title;
                viewLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }

            //InitializeComponent();
        }

        /**
         * Cycle to the Previous Image, Title, and Description
         * */
        private void viewLessonPreviousMedia_Click(object sender, EventArgs e) {
            if (mediaInLesson.Count > 1) {
                //Save the current image stuff
                if (0 > currentShownImageIndex - 1) {
                    currentShownImageIndex = mediaInLesson.Count - 1;
                }
                else {
                    currentShownImageIndex -= 1;
                }
                //Show that image
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                viewLessonMedia.Image = Image.FromStream(ms);
                viewLessonImageTitleLable.Text = mediaInLesson[currentShownImageIndex].Title;
                viewLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }
        }

        /**
         * Goes to the next (+1) of the media
         * */
        private void viewLessonNextMedia_Click(object sender, EventArgs e) {
            if (mediaInLesson.Count > 1) {
                if (mediaInLesson.Count == currentShownImageIndex + 1) {
                    currentShownImageIndex = 0;
                }
                else {
                    currentShownImageIndex += 1;
                }
                //Show that image, description, title
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                viewLessonMedia.Image = Image.FromStream(ms);
                viewLessonImageTitleLable.Text = mediaInLesson[currentShownImageIndex].Title;
                viewLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }
        }
    }
}
