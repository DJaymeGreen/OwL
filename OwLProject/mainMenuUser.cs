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
    public partial class mainMenuUser : Form {

        Form logIn;
        String username;
        database db;
        public mainMenuUser(Form logIn, String username) {
            InitializeComponent();
            this.logIn = logIn;
            this.username = username;
            this.db = new database();

            //Update name label
            mainMenuUserUsername.Text = username + "!";
            //Update the dropdown
            updateDropDown();
        }

        /**
         * Edits the dropdown to only include the lessons that are unlocked but not 
         * complete for the user
         * */
        public void updateDropDown() {
            List<int> allLIDsToInclude = db.getAllUnlockedNotCompleteLessons(username);
            foreach (int LID in allLIDsToInclude) {
                mainMenuUserDropdown.Items.Add(db.getLessonTitle(LID));
            }
        }


        /**
         * When the Go To Lesson button is pressed
         * */
        private void mainMenuUserButton_Click(object sender, EventArgs e) {
            if (mainMenuUserDropdown.Text.Length < 1) {
                MessageBox.Show("No Lesson Specified!");
            }
            else if (mainMenuUserDropdown.Text.Length > 0 && !db.checkIfLessonTitleExists(mainMenuUserDropdown.Text)) {
                MessageBox.Show("That Lesson doesn't exist!");
            }
            else {
                //Launch View Lesson Page...
                viewLesson viewLess = new viewLesson(mainMenuUserDropdown.Text, username);
                viewLess.getUserForm(this);
                viewLess.Show();
            }
        }

        /**
         * When the form closes, reopen the log in page
         * */
        private void mainMenuUserFormClosed(object sender, FormClosedEventArgs e) {
            this.logIn.Show();
        }
    }
}
