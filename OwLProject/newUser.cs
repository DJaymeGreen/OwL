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

namespace OwLProject {
    public partial class newUser : Form {

        database db;
        public newUser() {
            InitializeComponent();
            db = new database();
        }

        /**
         * Registers the new user into the system.
         * Needs to check if all (except email) fields are filled and 
         * that the passwords match each other 
         * */
        private void newUserRegisterButton_Click(object sender, EventArgs e) {
            if(newUserUsername.Text.Length < 1) {
                MessageBox.Show("You need a username to register!");
            }
            else if(newUserPassword.Text.Length < 1) {
                MessageBox.Show("You need a password to register!");
            }
            else if(newUserConfirmPassword.Text.Length < 1) {
                MessageBox.Show("You need to confirm your password to register!");
            }
            else if (!newUserPassword.Text.Equals(newUserConfirmPassword.Text)) {
                MessageBox.Show("Your password and confirm password need to be identical!");
            }
            else {
                //Check if username is in the database
                if (db.checkUniqueUsername(newUserUsername.Text)) {
                    // Add user to the database
                    HashAlgorithm hash = new SHA256Managed();
                    byte[] passHash = hash.ComputeHash(Encoding.UTF8.GetBytes(newUserPassword.Text));
                    String password = Convert.ToBase64String(passHash);
                    if (db.registerUser(newUserUsername.Text, password, newUserEmail.Text, 1, 1, 1)) {
                        MessageBox.Show("Successfully registered!");
                        this.Close();
                    }
                }
                else {
                    MessageBox.Show("Your Username is already taken. Please try a new Username");
                }
            }
        }
    }
}
