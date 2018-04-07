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
            this.viewLessonQuestionTitle = new System.Windows.Forms.Label();
            this.viewLessonQuestionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.viewLessonMCContent1 = new System.Windows.Forms.Label();
            this.viewLessonMCContent2 = new System.Windows.Forms.Label();
            this.viewLessonMCContent3 = new System.Windows.Forms.Label();
            this.viewLessonMCContent4 = new System.Windows.Forms.Label();
            this.viewLessonMCContent5 = new System.Windows.Forms.Label();
            this.viewLessonMCContent6 = new System.Windows.Forms.Label();
            this.viewLessonMCCB1 = new System.Windows.Forms.CheckBox();
            this.viewLessonMCCB2 = new System.Windows.Forms.CheckBox();
            this.viewLessonMCCB3 = new System.Windows.Forms.CheckBox();
            this.viewLessonMCCB4 = new System.Windows.Forms.CheckBox();
            this.viewLessonMCCB5 = new System.Windows.Forms.CheckBox();
            this.viewLessonMCCB6 = new System.Windows.Forms.CheckBox();
            this.viewLessonChart = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewLessonChartResetToGivenButton = new System.Windows.Forms.Button();
            this.viewLessonDropdown = new System.Windows.Forms.ComboBox();
            this.viewLessonFeedbackLabel = new System.Windows.Forms.Label();
            this.viewLessonFeedback = new System.Windows.Forms.Label();
            this.viewLessonSkipQuestionButton = new System.Windows.Forms.Button();
            this.viewLessonYourRatingLabel = new System.Windows.Forms.Label();
            this.viewLessonYourRating = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonYourRating)).BeginInit();
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
            this.viewLessonContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.viewLessonMedia.Location = new System.Drawing.Point(349, 121);
            this.viewLessonMedia.Name = "viewLessonMedia";
            this.viewLessonMedia.Size = new System.Drawing.Size(261, 223);
            this.viewLessonMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.viewLessonMedia.TabIndex = 3;
            this.viewLessonMedia.TabStop = false;
            // 
            // viewLessonMediaDescription
            // 
            this.viewLessonMediaDescription.Location = new System.Drawing.Point(349, 363);
            this.viewLessonMediaDescription.Multiline = true;
            this.viewLessonMediaDescription.Name = "viewLessonMediaDescription";
            this.viewLessonMediaDescription.ReadOnly = true;
            this.viewLessonMediaDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.viewLessonMediaDescription.Size = new System.Drawing.Size(261, 107);
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
            // viewLessonQuestionTitle
            // 
            this.viewLessonQuestionTitle.AutoSize = true;
            this.viewLessonQuestionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonQuestionTitle.Location = new System.Drawing.Point(645, 24);
            this.viewLessonQuestionTitle.Name = "viewLessonQuestionTitle";
            this.viewLessonQuestionTitle.Size = new System.Drawing.Size(184, 20);
            this.viewLessonQuestionTitle.TabIndex = 7;
            this.viewLessonQuestionTitle.Text = "viewLessonQuestionTitle";
            // 
            // viewLessonQuestionLabel
            // 
            this.viewLessonQuestionLabel.AutoSize = true;
            this.viewLessonQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonQuestionLabel.Location = new System.Drawing.Point(645, 71);
            this.viewLessonQuestionLabel.MaximumSize = new System.Drawing.Size(550, 50);
            this.viewLessonQuestionLabel.Name = "viewLessonQuestionLabel";
            this.viewLessonQuestionLabel.Size = new System.Drawing.Size(51, 20);
            this.viewLessonQuestionLabel.TabIndex = 8;
            this.viewLessonQuestionLabel.Text = "label1";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(911, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // viewLessonMCContent1
            // 
            this.viewLessonMCContent1.AutoSize = true;
            this.viewLessonMCContent1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCContent1.Location = new System.Drawing.Point(652, 182);
            this.viewLessonMCContent1.MaximumSize = new System.Drawing.Size(450, 20);
            this.viewLessonMCContent1.Name = "viewLessonMCContent1";
            this.viewLessonMCContent1.Size = new System.Drawing.Size(51, 20);
            this.viewLessonMCContent1.TabIndex = 10;
            this.viewLessonMCContent1.Text = "label1";
            this.viewLessonMCContent1.Visible = false;
            // 
            // viewLessonMCContent2
            // 
            this.viewLessonMCContent2.AutoSize = true;
            this.viewLessonMCContent2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCContent2.Location = new System.Drawing.Point(652, 232);
            this.viewLessonMCContent2.MaximumSize = new System.Drawing.Size(450, 20);
            this.viewLessonMCContent2.Name = "viewLessonMCContent2";
            this.viewLessonMCContent2.Size = new System.Drawing.Size(51, 20);
            this.viewLessonMCContent2.TabIndex = 11;
            this.viewLessonMCContent2.Text = "label1";
            this.viewLessonMCContent2.Visible = false;
            // 
            // viewLessonMCContent3
            // 
            this.viewLessonMCContent3.AutoSize = true;
            this.viewLessonMCContent3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCContent3.Location = new System.Drawing.Point(652, 283);
            this.viewLessonMCContent3.MaximumSize = new System.Drawing.Size(450, 20);
            this.viewLessonMCContent3.Name = "viewLessonMCContent3";
            this.viewLessonMCContent3.Size = new System.Drawing.Size(51, 20);
            this.viewLessonMCContent3.TabIndex = 12;
            this.viewLessonMCContent3.Text = "label1";
            this.viewLessonMCContent3.Visible = false;
            // 
            // viewLessonMCContent4
            // 
            this.viewLessonMCContent4.AutoSize = true;
            this.viewLessonMCContent4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCContent4.Location = new System.Drawing.Point(652, 339);
            this.viewLessonMCContent4.MaximumSize = new System.Drawing.Size(450, 20);
            this.viewLessonMCContent4.Name = "viewLessonMCContent4";
            this.viewLessonMCContent4.Size = new System.Drawing.Size(51, 20);
            this.viewLessonMCContent4.TabIndex = 13;
            this.viewLessonMCContent4.Text = "label1";
            this.viewLessonMCContent4.Visible = false;
            // 
            // viewLessonMCContent5
            // 
            this.viewLessonMCContent5.AutoSize = true;
            this.viewLessonMCContent5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCContent5.Location = new System.Drawing.Point(652, 388);
            this.viewLessonMCContent5.MaximumSize = new System.Drawing.Size(450, 20);
            this.viewLessonMCContent5.Name = "viewLessonMCContent5";
            this.viewLessonMCContent5.Size = new System.Drawing.Size(51, 20);
            this.viewLessonMCContent5.TabIndex = 14;
            this.viewLessonMCContent5.Text = "label1";
            this.viewLessonMCContent5.Visible = false;
            // 
            // viewLessonMCContent6
            // 
            this.viewLessonMCContent6.AutoSize = true;
            this.viewLessonMCContent6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCContent6.Location = new System.Drawing.Point(652, 440);
            this.viewLessonMCContent6.MaximumSize = new System.Drawing.Size(450, 20);
            this.viewLessonMCContent6.Name = "viewLessonMCContent6";
            this.viewLessonMCContent6.Size = new System.Drawing.Size(51, 20);
            this.viewLessonMCContent6.TabIndex = 15;
            this.viewLessonMCContent6.Text = "label1";
            this.viewLessonMCContent6.Visible = false;
            // 
            // viewLessonMCCB1
            // 
            this.viewLessonMCCB1.AutoSize = true;
            this.viewLessonMCCB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCCB1.Location = new System.Drawing.Point(1190, 186);
            this.viewLessonMCCB1.Name = "viewLessonMCCB1";
            this.viewLessonMCCB1.Size = new System.Drawing.Size(15, 14);
            this.viewLessonMCCB1.TabIndex = 16;
            this.viewLessonMCCB1.UseVisualStyleBackColor = true;
            this.viewLessonMCCB1.Visible = false;
            // 
            // viewLessonMCCB2
            // 
            this.viewLessonMCCB2.AutoSize = true;
            this.viewLessonMCCB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCCB2.Location = new System.Drawing.Point(1190, 232);
            this.viewLessonMCCB2.Name = "viewLessonMCCB2";
            this.viewLessonMCCB2.Size = new System.Drawing.Size(15, 14);
            this.viewLessonMCCB2.TabIndex = 17;
            this.viewLessonMCCB2.UseVisualStyleBackColor = true;
            this.viewLessonMCCB2.Visible = false;
            // 
            // viewLessonMCCB3
            // 
            this.viewLessonMCCB3.AutoSize = true;
            this.viewLessonMCCB3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCCB3.Location = new System.Drawing.Point(1190, 287);
            this.viewLessonMCCB3.Name = "viewLessonMCCB3";
            this.viewLessonMCCB3.Size = new System.Drawing.Size(15, 14);
            this.viewLessonMCCB3.TabIndex = 18;
            this.viewLessonMCCB3.UseVisualStyleBackColor = true;
            this.viewLessonMCCB3.Visible = false;
            // 
            // viewLessonMCCB4
            // 
            this.viewLessonMCCB4.AutoSize = true;
            this.viewLessonMCCB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCCB4.Location = new System.Drawing.Point(1190, 343);
            this.viewLessonMCCB4.Name = "viewLessonMCCB4";
            this.viewLessonMCCB4.Size = new System.Drawing.Size(15, 14);
            this.viewLessonMCCB4.TabIndex = 19;
            this.viewLessonMCCB4.UseVisualStyleBackColor = true;
            this.viewLessonMCCB4.Visible = false;
            // 
            // viewLessonMCCB5
            // 
            this.viewLessonMCCB5.AutoSize = true;
            this.viewLessonMCCB5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCCB5.Location = new System.Drawing.Point(1190, 394);
            this.viewLessonMCCB5.Name = "viewLessonMCCB5";
            this.viewLessonMCCB5.Size = new System.Drawing.Size(15, 14);
            this.viewLessonMCCB5.TabIndex = 20;
            this.viewLessonMCCB5.UseVisualStyleBackColor = true;
            this.viewLessonMCCB5.Visible = false;
            // 
            // viewLessonMCCB6
            // 
            this.viewLessonMCCB6.AutoSize = true;
            this.viewLessonMCCB6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonMCCB6.Location = new System.Drawing.Point(1190, 444);
            this.viewLessonMCCB6.Name = "viewLessonMCCB6";
            this.viewLessonMCCB6.Size = new System.Drawing.Size(15, 14);
            this.viewLessonMCCB6.TabIndex = 21;
            this.viewLessonMCCB6.UseVisualStyleBackColor = true;
            this.viewLessonMCCB6.Visible = false;
            // 
            // viewLessonChart
            // 
            this.viewLessonChart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewLessonChart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.viewLessonChart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.viewLessonChart.Location = new System.Drawing.Point(649, 183);
            this.viewLessonChart.Name = "viewLessonChart";
            this.viewLessonChart.Size = new System.Drawing.Size(569, 238);
            this.viewLessonChart.TabIndex = 22;
            this.viewLessonChart.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            // 
            // viewLessonChartResetToGivenButton
            // 
            this.viewLessonChartResetToGivenButton.AutoSize = true;
            this.viewLessonChartResetToGivenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonChartResetToGivenButton.Location = new System.Drawing.Point(963, 440);
            this.viewLessonChartResetToGivenButton.Name = "viewLessonChartResetToGivenButton";
            this.viewLessonChartResetToGivenButton.Size = new System.Drawing.Size(129, 30);
            this.viewLessonChartResetToGivenButton.TabIndex = 23;
            this.viewLessonChartResetToGivenButton.Text = "Reset To Given";
            this.viewLessonChartResetToGivenButton.UseVisualStyleBackColor = true;
            this.viewLessonChartResetToGivenButton.Visible = false;
            this.viewLessonChartResetToGivenButton.Click += new System.EventHandler(this.viewLessonChartResetToGivenButton_Click);
            // 
            // viewLessonDropdown
            // 
            this.viewLessonDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonDropdown.FormattingEnabled = true;
            this.viewLessonDropdown.Location = new System.Drawing.Point(656, 255);
            this.viewLessonDropdown.Name = "viewLessonDropdown";
            this.viewLessonDropdown.Size = new System.Drawing.Size(259, 28);
            this.viewLessonDropdown.TabIndex = 24;
            this.viewLessonDropdown.Visible = false;
            // 
            // viewLessonFeedbackLabel
            // 
            this.viewLessonFeedbackLabel.AutoSize = true;
            this.viewLessonFeedbackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonFeedbackLabel.Location = new System.Drawing.Point(649, 517);
            this.viewLessonFeedbackLabel.Name = "viewLessonFeedbackLabel";
            this.viewLessonFeedbackLabel.Size = new System.Drawing.Size(84, 20);
            this.viewLessonFeedbackLabel.TabIndex = 25;
            this.viewLessonFeedbackLabel.Text = "Feedback:";
            // 
            // viewLessonFeedback
            // 
            this.viewLessonFeedback.AutoSize = true;
            this.viewLessonFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonFeedback.Location = new System.Drawing.Point(765, 517);
            this.viewLessonFeedback.Name = "viewLessonFeedback";
            this.viewLessonFeedback.Size = new System.Drawing.Size(51, 20);
            this.viewLessonFeedback.TabIndex = 26;
            this.viewLessonFeedback.Text = "label1";
            // 
            // viewLessonSkipQuestionButton
            // 
            this.viewLessonSkipQuestionButton.AutoSize = true;
            this.viewLessonSkipQuestionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonSkipQuestionButton.Location = new System.Drawing.Point(1140, 598);
            this.viewLessonSkipQuestionButton.Name = "viewLessonSkipQuestionButton";
            this.viewLessonSkipQuestionButton.Size = new System.Drawing.Size(118, 30);
            this.viewLessonSkipQuestionButton.TabIndex = 27;
            this.viewLessonSkipQuestionButton.Text = "Skip Question";
            this.viewLessonSkipQuestionButton.UseVisualStyleBackColor = true;
            this.viewLessonSkipQuestionButton.Click += new System.EventHandler(this.viewLessonSkipQuestionButton_Click);
            // 
            // viewLessonYourRatingLabel
            // 
            this.viewLessonYourRatingLabel.AutoSize = true;
            this.viewLessonYourRatingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonYourRatingLabel.Location = new System.Drawing.Point(645, 570);
            this.viewLessonYourRatingLabel.Name = "viewLessonYourRatingLabel";
            this.viewLessonYourRatingLabel.Size = new System.Drawing.Size(98, 20);
            this.viewLessonYourRatingLabel.TabIndex = 28;
            this.viewLessonYourRatingLabel.Text = "Your Rating:";
            // 
            // viewLessonYourRating
            // 
            this.viewLessonYourRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLessonYourRating.Location = new System.Drawing.Point(649, 601);
            this.viewLessonYourRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.viewLessonYourRating.Name = "viewLessonYourRating";
            this.viewLessonYourRating.Size = new System.Drawing.Size(120, 26);
            this.viewLessonYourRating.TabIndex = 29;
            // 
            // viewLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 640);
            this.Controls.Add(this.viewLessonYourRating);
            this.Controls.Add(this.viewLessonYourRatingLabel);
            this.Controls.Add(this.viewLessonSkipQuestionButton);
            this.Controls.Add(this.viewLessonFeedback);
            this.Controls.Add(this.viewLessonFeedbackLabel);
            this.Controls.Add(this.viewLessonDropdown);
            this.Controls.Add(this.viewLessonChartResetToGivenButton);
            this.Controls.Add(this.viewLessonChart);
            this.Controls.Add(this.viewLessonMCCB6);
            this.Controls.Add(this.viewLessonMCCB5);
            this.Controls.Add(this.viewLessonMCCB4);
            this.Controls.Add(this.viewLessonMCCB3);
            this.Controls.Add(this.viewLessonMCCB2);
            this.Controls.Add(this.viewLessonMCCB1);
            this.Controls.Add(this.viewLessonMCContent6);
            this.Controls.Add(this.viewLessonMCContent5);
            this.Controls.Add(this.viewLessonMCContent4);
            this.Controls.Add(this.viewLessonMCContent3);
            this.Controls.Add(this.viewLessonMCContent2);
            this.Controls.Add(this.viewLessonMCContent1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewLessonQuestionLabel);
            this.Controls.Add(this.viewLessonQuestionTitle);
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
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLessonYourRating)).EndInit();
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
        private System.Windows.Forms.Label viewLessonQuestionTitle;
        private System.Windows.Forms.Label viewLessonQuestionLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label viewLessonMCContent1;
        private System.Windows.Forms.Label viewLessonMCContent2;
        private System.Windows.Forms.Label viewLessonMCContent3;
        private System.Windows.Forms.Label viewLessonMCContent4;
        private System.Windows.Forms.Label viewLessonMCContent5;
        private System.Windows.Forms.Label viewLessonMCContent6;
        private System.Windows.Forms.CheckBox viewLessonMCCB1;
        private System.Windows.Forms.CheckBox viewLessonMCCB2;
        private System.Windows.Forms.CheckBox viewLessonMCCB3;
        private System.Windows.Forms.CheckBox viewLessonMCCB4;
        private System.Windows.Forms.CheckBox viewLessonMCCB5;
        private System.Windows.Forms.CheckBox viewLessonMCCB6;
        private System.Windows.Forms.DataGridView viewLessonChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button viewLessonChartResetToGivenButton;
        private System.Windows.Forms.ComboBox viewLessonDropdown;
        private System.Windows.Forms.Label viewLessonFeedbackLabel;
        private System.Windows.Forms.Label viewLessonFeedback;
        private System.Windows.Forms.Button viewLessonSkipQuestionButton;
        private System.Windows.Forms.Label viewLessonYourRatingLabel;
        private System.Windows.Forms.NumericUpDown viewLessonYourRating;
    }
}