namespace OwLProject {
    partial class viewLesson {
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
            this.viewLessonTitleLabel = new System.Windows.Forms.Label();
            this.viewLessonContent = new System.Windows.Forms.TextBox();
            this.viewLessonImageTitleLable = new System.Windows.Forms.Label();
            this.viewLessonMedia = new System.Windows.Forms.PictureBox();
            this.viewLessonMediaDescription = new System.Windows.Forms.TextBox();
            this.viewLessonNextMedia = new System.Windows.Forms.Button();
            this.viewLessonPreviousMedia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // viewLessonTitleLabel
            // 
            this.viewLessonTitleLabel.AutoSize = true;
            this.viewLessonTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonTitleLabel.Location = new System.Drawing.Point(24, 24);
            this.viewLessonTitleLabel.Name = "viewLessonTitleLabel";
            this.viewLessonTitleLabel.Size = new System.Drawing.Size(160, 20);
            this.viewLessonTitleLabel.TabIndex = 0;
            this.viewLessonTitleLabel.Text = "Title of The Content...";
            // 
            // viewLessonContent
            // 
            this.viewLessonContent.Location = new System.Drawing.Point(28, 47);
            this.viewLessonContent.MinimumSize = new System.Drawing.Size(300, 581);
            this.viewLessonContent.Multiline = true;
            this.viewLessonContent.Name = "viewLessonContent";
            this.viewLessonContent.ReadOnly = true;
            this.viewLessonContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.viewLessonContent.Size = new System.Drawing.Size(300, 581);
            this.viewLessonContent.TabIndex = 1;
            // 
            // viewLessonImageTitleLable
            // 
            this.viewLessonImageTitleLable.AutoSize = true;
            this.viewLessonImageTitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonImageTitleLable.Location = new System.Drawing.Point(369, 84);
            this.viewLessonImageTitleLable.Name = "viewLessonImageTitleLable";
            this.viewLessonImageTitleLable.Size = new System.Drawing.Size(87, 20);
            this.viewLessonImageTitleLable.TabIndex = 2;
            this.viewLessonImageTitleLable.Text = "Image Title";
            // 
            // viewLessonMedia
            // 
            this.viewLessonMedia.Location = new System.Drawing.Point(373, 148);
            this.viewLessonMedia.Name = "viewLessonMedia";
            this.viewLessonMedia.Size = new System.Drawing.Size(186, 172);
            this.viewLessonMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.viewLessonMedia.TabIndex = 3;
            this.viewLessonMedia.TabStop = false;
            // 
            // viewLessonMediaDescription
            // 
            this.viewLessonMediaDescription.Location = new System.Drawing.Point(373, 363);
            this.viewLessonMediaDescription.Multiline = true;
            this.viewLessonMediaDescription.Name = "viewLessonMediaDescription";
            this.viewLessonMediaDescription.ReadOnly = true;
            this.viewLessonMediaDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.viewLessonMediaDescription.Size = new System.Drawing.Size(186, 102);
            this.viewLessonMediaDescription.TabIndex = 4;
            // 
            // viewLessonNextMedia
            // 
            this.viewLessonNextMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonNextMedia.Location = new System.Drawing.Point(484, 517);
            this.viewLessonNextMedia.Name = "viewLessonNextMedia";
            this.viewLessonNextMedia.Size = new System.Drawing.Size(75, 33);
            this.viewLessonNextMedia.TabIndex = 5;
            this.viewLessonNextMedia.Text = "Next";
            this.viewLessonNextMedia.UseVisualStyleBackColor = true;
            this.viewLessonNextMedia.Click += new System.EventHandler(this.viewLessonNextMedia_Click);
            // 
            // viewLessonPreviousMedia
            // 
            this.viewLessonPreviousMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonPreviousMedia.Location = new System.Drawing.Point(373, 517);
            this.viewLessonPreviousMedia.Name = "viewLessonPreviousMedia";
            this.viewLessonPreviousMedia.Size = new System.Drawing.Size(89, 33);
            this.viewLessonPreviousMedia.TabIndex = 6;
            this.viewLessonPreviousMedia.Text = "Previous";
            this.viewLessonPreviousMedia.UseVisualStyleBackColor = true;
            this.viewLessonPreviousMedia.Click += new System.EventHandler(this.viewLessonPreviousMedia_Click);
            // 
            // viewLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 640);
            this.Controls.Add(this.viewLessonPreviousMedia);
            this.Controls.Add(this.viewLessonNextMedia);
            this.Controls.Add(this.viewLessonMediaDescription);
            this.Controls.Add(this.viewLessonMedia);
            this.Controls.Add(this.viewLessonImageTitleLable);
            this.Controls.Add(this.viewLessonContent);
            this.Controls.Add(this.viewLessonTitleLabel);
            this.Name = "viewLesson";
            this.Text = "viewLesson";
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonMedia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label viewLessonTitleLabel;
        private System.Windows.Forms.TextBox viewLessonContent;
        private System.Windows.Forms.Label viewLessonImageTitleLable;
        private System.Windows.Forms.PictureBox viewLessonMedia;
        private System.Windows.Forms.TextBox viewLessonMediaDescription;
        private System.Windows.Forms.Button viewLessonNextMedia;
        private System.Windows.Forms.Button viewLessonPreviousMedia;
    }
}