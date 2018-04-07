using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwLProject {
    public partial class whatLesson : Form {

        database db;
        String username;

        public whatLesson(String username) {
            InitializeComponent();
            db = new database();
            this.username = username;
            //Add all the titles to the Dropdown
            foreach (String title in db.getAllLessonTitles()) {
                whatLessonDropdown.Items.Add(title);
            }
        }

        //Go to the Lesson that was specified in the DropDown
        private void whatLessonViewLessonButton_Click(object sender, EventArgs e) {
            if(whatLessonDropdown.Text.Length < 1) {
                MessageBox.Show("No Lesson Specified!");
            }
            else if (whatLessonDropdown.Text.Length > 0 && !db.checkIfLessonTitleExists(whatLessonDropdown.Text)) {
                MessageBox.Show("That Lesson doesn't exist!");
            }
            else {
                //Launch View Lesson Page...
                viewLesson viewLess = new viewLesson(whatLessonDropdown.Text,username);
                viewLess.Show();
            }
        }
    }
}
