using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwLProject
{
    public partial class LogIn : Form
    {
        database db;
        public LogIn()
        {
            InitializeComponent();
            // Just comments to make sure that it commits correctly....
            db = new database();
        }

        /**
         * When the login button is selected. Checks the field for correctness
         * then checks db for whether that user exists or not
         * */
        private void logInButton_Click(object sender, EventArgs e)
        {
            if(logInUsername.Text.Length < 1){
                MessageBox.Show("No Username Specified!");
            }
            else if (logInPassword.Text.Length < 1) {
                MessageBox.Show("No Password Specified!");
            }
            else { // Check for user
                HashAlgorithm hash = new SHA256Managed();
                byte[] passHash = hash.ComputeHash(Encoding.UTF8.GetBytes(logInPassword.Text));
                String password = Convert.ToBase64String(passHash);
                if (db.checkUserInDB(logInUsername.Text, password)) {
                    //MessageBox.Show("Yay, you're in!");
                    mainMenu mm = new mainMenu(this);
                    mm.Show();
                    this.Hide();
                    logInUsername.Text = "";
                    logInPassword.Text = "";
                }
                else {
                    MessageBox.Show("That Username/Password combination is not in the database!");
                }
            }
        }

        private void logInNewUserButton_Click(object sender, EventArgs e) {
            newUser newUserPage = new newUser();
            newUserPage.Show();
        }
    }
}
