﻿using System;
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

        public mainMenu(Form logIn) {
            InitializeComponent();
            this.login = logIn;
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
    }
}
