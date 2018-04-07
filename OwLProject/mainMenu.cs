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
    public partial class mainMenu : Form {

        Form login;
        String username;

        public mainMenu(Form logIn, String username) {
            InitializeComponent();
            this.login = logIn;
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e) {
            addLesson add = new addLesson();
            add.Show();
        }

        /**
         * When this closes, close this page and Show the login page again
         * */
        private void formClose(object sender, FormClosedEventArgs e) {
            login.Show();
        }

        /**
         * Opens up whatLesson page
         * */
        private void button2_Click(object sender, EventArgs e) {
            whatLesson whatLess = new whatLesson(username);
            whatLess.Show();
        }

        // Opens Add Problem Page
        private void mainMenuAddProblem_Click(object sender, EventArgs e) {
            addProblem aP = new addProblem();
            aP.Show();
        }
    }
}
