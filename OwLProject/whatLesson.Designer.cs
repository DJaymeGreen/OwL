namespace OwLProject {
    partial class whatLesson {
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
            this.whatLessonDropdown = new System.Windows.Forms.ComboBox();
            this.whatLessonViewLessonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "What Lesson?";
            // 
            // whatLessonDropdown
            // 
            this.whatLessonDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whatLessonDropdown.FormattingEnabled = true;
            this.whatLessonDropdown.Location = new System.Drawing.Point(34, 98);
            this.whatLessonDropdown.Name = "whatLessonDropdown";
            this.whatLessonDropdown.Size = new System.Drawing.Size(232, 28);
            this.whatLessonDropdown.TabIndex = 1;
            // 
            // whatLessonViewLessonButton
            // 
            this.whatLessonViewLessonButton.AutoSize = true;
            this.whatLessonViewLessonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whatLessonViewLessonButton.Location = new System.Drawing.Point(74, 186);
            this.whatLessonViewLessonButton.Name = "whatLessonViewLessonButton";
            this.whatLessonViewLessonButton.Size = new System.Drawing.Size(128, 30);
            this.whatLessonViewLessonButton.TabIndex = 2;
            this.whatLessonViewLessonButton.Text = "View Lesson";
            this.whatLessonViewLessonButton.UseVisualStyleBackColor = true;
            this.whatLessonViewLessonButton.Click += new System.EventHandler(this.whatLessonViewLessonButton_Click);
            // 
            // whatLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 264);
            this.Controls.Add(this.whatLessonViewLessonButton);
            this.Controls.Add(this.whatLessonDropdown);
            this.Controls.Add(this.label1);
            this.Name = "whatLesson";
            this.Text = "whatLesson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox whatLessonDropdown;
        private System.Windows.Forms.Button whatLessonViewLessonButton;
    }
}