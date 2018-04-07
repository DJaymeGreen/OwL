namespace OwLProject {
    partial class mainMenuUser {
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
            this.mainMenuUserHelloLabel = new System.Windows.Forms.Label();
            this.mainMenuUserUsername = new System.Windows.Forms.Label();
            this.mainMenuUserLessonLabel = new System.Windows.Forms.Label();
            this.mainMenuUserDropdown = new System.Windows.Forms.ComboBox();
            this.mainMenuUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenuUserHelloLabel
            // 
            this.mainMenuUserHelloLabel.AutoSize = true;
            this.mainMenuUserHelloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuUserHelloLabel.Location = new System.Drawing.Point(23, 35);
            this.mainMenuUserHelloLabel.Name = "mainMenuUserHelloLabel";
            this.mainMenuUserHelloLabel.Size = new System.Drawing.Size(45, 20);
            this.mainMenuUserHelloLabel.TabIndex = 0;
            this.mainMenuUserHelloLabel.Text = "Hello";
            // 
            // mainMenuUserUsername
            // 
            this.mainMenuUserUsername.AutoSize = true;
            this.mainMenuUserUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuUserUsername.Location = new System.Drawing.Point(84, 35);
            this.mainMenuUserUsername.Name = "mainMenuUserUsername";
            this.mainMenuUserUsername.Size = new System.Drawing.Size(98, 20);
            this.mainMenuUserUsername.TabIndex = 1;
            this.mainMenuUserUsername.Text = "<username>";
            // 
            // mainMenuUserLessonLabel
            // 
            this.mainMenuUserLessonLabel.AutoSize = true;
            this.mainMenuUserLessonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuUserLessonLabel.Location = new System.Drawing.Point(32, 154);
            this.mainMenuUserLessonLabel.Name = "mainMenuUserLessonLabel";
            this.mainMenuUserLessonLabel.Size = new System.Drawing.Size(247, 20);
            this.mainMenuUserLessonLabel.TabIndex = 2;
            this.mainMenuUserLessonLabel.Text = "Lessons That You Can Complete:";
            // 
            // mainMenuUserDropdown
            // 
            this.mainMenuUserDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuUserDropdown.FormattingEnabled = true;
            this.mainMenuUserDropdown.Location = new System.Drawing.Point(36, 207);
            this.mainMenuUserDropdown.Name = "mainMenuUserDropdown";
            this.mainMenuUserDropdown.Size = new System.Drawing.Size(243, 28);
            this.mainMenuUserDropdown.TabIndex = 3;
            // 
            // mainMenuUserButton
            // 
            this.mainMenuUserButton.AutoSize = true;
            this.mainMenuUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuUserButton.Location = new System.Drawing.Point(88, 275);
            this.mainMenuUserButton.Name = "mainMenuUserButton";
            this.mainMenuUserButton.Size = new System.Drawing.Size(120, 30);
            this.mainMenuUserButton.TabIndex = 4;
            this.mainMenuUserButton.Text = "Go To Lesson";
            this.mainMenuUserButton.UseVisualStyleBackColor = true;
            this.mainMenuUserButton.Click += new System.EventHandler(this.mainMenuUserButton_Click);
            // 
            // mainMenuUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 349);
            this.Controls.Add(this.mainMenuUserButton);
            this.Controls.Add(this.mainMenuUserDropdown);
            this.Controls.Add(this.mainMenuUserLessonLabel);
            this.Controls.Add(this.mainMenuUserUsername);
            this.Controls.Add(this.mainMenuUserHelloLabel);
            this.Name = "mainMenuUser";
            this.Text = "mainMenuUser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainMenuUserFormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainMenuUserHelloLabel;
        private System.Windows.Forms.Label mainMenuUserUsername;
        private System.Windows.Forms.Label mainMenuUserLessonLabel;
        private System.Windows.Forms.ComboBox mainMenuUserDropdown;
        private System.Windows.Forms.Button mainMenuUserButton;
    }
}