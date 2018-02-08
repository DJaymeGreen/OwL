namespace OwLProject {
    partial class newUser {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newUserUsername = new System.Windows.Forms.TextBox();
            this.newUserPassword = new System.Windows.Forms.TextBox();
            this.newUserConfirmPassword = new System.Windows.Forms.TextBox();
            this.newUserRegisterButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.newUserEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password:";
            // 
            // newUserUsername
            // 
            this.newUserUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserUsername.Location = new System.Drawing.Point(233, 48);
            this.newUserUsername.Name = "newUserUsername";
            this.newUserUsername.Size = new System.Drawing.Size(153, 26);
            this.newUserUsername.TabIndex = 3;
            // 
            // newUserPassword
            // 
            this.newUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserPassword.Location = new System.Drawing.Point(233, 106);
            this.newUserPassword.Name = "newUserPassword";
            this.newUserPassword.Size = new System.Drawing.Size(153, 26);
            this.newUserPassword.TabIndex = 4;
            this.newUserPassword.UseSystemPasswordChar = true;
            // 
            // newUserConfirmPassword
            // 
            this.newUserConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserConfirmPassword.Location = new System.Drawing.Point(233, 167);
            this.newUserConfirmPassword.Name = "newUserConfirmPassword";
            this.newUserConfirmPassword.Size = new System.Drawing.Size(153, 26);
            this.newUserConfirmPassword.TabIndex = 5;
            this.newUserConfirmPassword.UseSystemPasswordChar = true;
            // 
            // newUserRegisterButton
            // 
            this.newUserRegisterButton.AutoSize = true;
            this.newUserRegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserRegisterButton.Location = new System.Drawing.Point(187, 298);
            this.newUserRegisterButton.Name = "newUserRegisterButton";
            this.newUserRegisterButton.Size = new System.Drawing.Size(79, 30);
            this.newUserRegisterButton.TabIndex = 6;
            this.newUserRegisterButton.Text = "Register";
            this.newUserRegisterButton.UseVisualStyleBackColor = true;
            this.newUserRegisterButton.Click += new System.EventHandler(this.newUserRegisterButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email (Optional):";
            // 
            // newUserEmail
            // 
            this.newUserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserEmail.Location = new System.Drawing.Point(233, 223);
            this.newUserEmail.Name = "newUserEmail";
            this.newUserEmail.Size = new System.Drawing.Size(153, 26);
            this.newUserEmail.TabIndex = 8;
            // 
            // newUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 340);
            this.Controls.Add(this.newUserEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.newUserRegisterButton);
            this.Controls.Add(this.newUserConfirmPassword);
            this.Controls.Add(this.newUserPassword);
            this.Controls.Add(this.newUserUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "newUser";
            this.Text = "newUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newUserUsername;
        private System.Windows.Forms.TextBox newUserPassword;
        private System.Windows.Forms.TextBox newUserConfirmPassword;
        private System.Windows.Forms.Button newUserRegisterButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newUserEmail;
    }
}