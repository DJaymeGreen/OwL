using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwLProject {
    public partial class viewLesson : Form {

        List<mediaStruct> mediaInLesson;
        List<Control> mcComponents;
        List<Control> chartComponents;
        List<Control> dropdownComponents;
        List<int> allPID;
        int LID;
        int currentShownProblemIndex;
        int currentShownImageIndex;
        database db;
        String username;
        mainMenuUser userMM = null;
        int diffComplete = 0;
        Dictionary<int, int> problemClusters;
        int numberOfProblemClusters;
        kNNWithUsers problemDecisionWithUsers;

        public viewLesson(String lessonTitle, String username) {
            db = new database();
            InitializeComponent();
            this.username = username;
            this.LID = db.getLidFromTitle(lessonTitle);
            allPID = db.getAllProblemPID(LID);
            //Generate all of the right shown stuff
            viewLessonTitleLabel.Text = lessonTitle;
            viewLessonContent.Text = db.getLessonContent(LID);
            
            mediaInLesson = db.getAllMediaForLesson(LID);
            currentShownImageIndex = 0;

            //No Images for the Lesson...
            if (mediaInLesson.Count < 1) {
                viewLessonImageTitleLable.Hide();
                viewLessonMedia.Hide();
                viewLessonMediaDescription.Hide();
                viewLessonNextMedia.Hide();
                viewLessonPreviousMedia.Hide();
            }
            else {
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                viewLessonMedia.Image = Image.FromStream(ms);
                viewLessonImageTitleLable.Text = mediaInLesson[currentShownImageIndex].Title;
                viewLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }

            //Establish the problem cluster stuff
            List<List<int>> PIDTypeDifficultyList = db.getPIDTypeDifficultyList();
            List<int> PIDInLesson = new List<int>();
            List<List<int>> typeDifficultyList = new List<List<int>>();
            int index = 0;
            foreach(List<int> item in PIDTypeDifficultyList) {
                PIDInLesson.Add(item[0]);
                typeDifficultyList.Add(new List<int>());
                typeDifficultyList[index].Add(item[1]);
                typeDifficultyList[index].Add(item[2]);
                index++;
            }
            this.problemDecisionWithUsers = new kNNWithUsers(username, LID);
            KMeans kMeansAlgo = new KMeans(typeDifficultyList, PIDInLesson);
            problemClusters = kMeansAlgo.getProblemClusters();

            List<int> seenClusters = new List<int>();
            foreach(int prob in problemClusters.Keys) {
                if (!seenClusters.Contains(problemClusters[prob])) {
                    seenClusters.Add(problemClusters[prob]);
                    numberOfProblemClusters++;
                }
            }
            while(numberOfProblemClusters <= seenClusters.Max()) {
                numberOfProblemClusters++;
            }

            //Establish the connection between the Components and the Lists

            //Deal with showing the problem...
            allPID = db.getAllProblemPID(LID);
            establishAllComponentLists();
            viewLessonFeedbackLabel.Hide();
            viewLessonFeedback.Hide();
            showNextProblem(true);
            //InitializeComponent();
        }

        /**
         * Establish the lists of the components. It will enable me to hide 
         * and show and manipulate the stuff easier
         * */
        private void establishAllComponentLists() {
            //MC Controls
            mcComponents = new List<Control>();
            mcComponents.Add(viewLessonMCContent1);
            mcComponents.Add(viewLessonMCCB1);
            mcComponents.Add(viewLessonMCContent2);
            mcComponents.Add(viewLessonMCCB2);
            mcComponents.Add(viewLessonMCContent3);
            mcComponents.Add(viewLessonMCCB3);
            mcComponents.Add(viewLessonMCContent4);
            mcComponents.Add(viewLessonMCCB4);
            mcComponents.Add(viewLessonMCContent5);
            mcComponents.Add(viewLessonMCCB5);
            mcComponents.Add(viewLessonMCContent6);
            mcComponents.Add(viewLessonMCCB6);

            //Chart Controls
            chartComponents = new List<Control>();
            chartComponents.Add(viewLessonChart);
            chartComponents.Add(viewLessonChartResetToGivenButton);

            //Dropbox Controls
            dropdownComponents = new List<Control>();
            dropdownComponents.Add(viewLessonDropdown);
        }

        /**
         * Gives the viewLesson the mmUser form
         * */
        public void getUserForm(mainMenuUser mmUser) {
            userMM = mmUser;
        }

        /**
         * Does the creation of the MC Struct (with CID, Label, and CB) and returns it
         * */
        private List<mcViewStruct> setUpMC() {
            List<int> CID = db.getAllChoicesCID(allPID[currentShownProblemIndex]);
            List<mcViewStruct> mcChoices = new List<mcViewStruct>();
            List<CheckBox> allCheckBoxes = new List<CheckBox>();
            allCheckBoxes.Add(viewLessonMCCB1);
            allCheckBoxes.Add(viewLessonMCCB2);
            allCheckBoxes.Add(viewLessonMCCB3);
            allCheckBoxes.Add(viewLessonMCCB4);
            allCheckBoxes.Add(viewLessonMCCB5);
            allCheckBoxes.Add(viewLessonMCCB6);

            for (int i = 0; i < 6; ++i) {
                mcViewStruct mc = new mcViewStruct();
                if(CID.Count > i) {
                    mc.CID = CID[i];
                }
                else {
                    mc.CID = -1;
                }

                //Connection of the CB and Content Label
                mc.Content = mcComponents[2 * i];
                mc.Checkbox = mcComponents[(2 * i) + 1];
                mc.CheckboxTF = allCheckBoxes[i];
                mcChoices.Add(mc);
            }
            return mcChoices;
        }

        /**
         * Show on the chart the given config
         * */
        private void showChartGiven(List<int> allCID) {
            String given = ((db.getChoiceisSolution(allCID[0])) ? db.getChoiceContent(allCID[1]) : db.getChoiceContent(allCID[0]));
            List<String> splittingGiven = given.Split(',').ToList<String>();
            int index = 0;
            //foreach (DataGridViewRow row in viewLessonChart.Rows) {
            //for (int i = 0; i < row.Cells.Count; ++i) {
            int splitIndex = 0;
            int amountOfRows = (int)(splittingGiven.Count / 8);
            for(int i = 0; i < amountOfRows-1; ++i) {
                viewLessonChart.Rows.Add();
            }
            for (int r = 0; r < amountOfRows; ++r) {
                for (int c = 0; c < 8; ++c) {
                    viewLessonChart[c,r].Value = splittingGiven[splitIndex];
                    splitIndex++;
                }
                //viewLessonChart.Rows.Add();
            }
                    //row.Cells[i].Value = splittingGiven[index];
                    //++index;
                    //given += (row.Cells[i].Value + "," ?? "NULL,").ToString();
        }

        /**
         * Ranks all of the PID's in this lesson based on likliness that this
         * user's prior questions answered
         * */
        private List<int> rankPIDsBasedOnProblemClusterRating() {
            Dictionary<int, float> clusterRating = new Dictionary<int, float>();
            Dictionary<int, int> numberOfProblemsTakenInCluster = new Dictionary<int, int>();

            for (int clust = 0; clust < numberOfProblemClusters; ++clust) {
                clusterRating[clust] = 0;
                numberOfProblemsTakenInCluster[clust] = 0;
            }

            //Get how much I like a problem cluster
            List<int> allPIDsTaken = db.getAllPIDThatUserCompleted(username);
            foreach (int PID in allPIDsTaken) {
                int cluster = problemClusters[PID];
                numberOfProblemsTakenInCluster[cluster] += 1;
                clusterRating[cluster] += db.getUserRatingByUser(username, PID);
            }

            foreach(int cluster in numberOfProblemsTakenInCluster.Keys) {
                if(numberOfProblemsTakenInCluster[cluster] > 0) {
                    clusterRating[cluster] = (clusterRating[cluster] / numberOfProblemsTakenInCluster[cluster]);
                }
                else {
                    clusterRating[cluster] = (float)2.5;
                }
            }

            //Sort cluster likeness in a list, Favorite to Least Favorite...
            List<int> rankedProblemClusters = new List<int>();
            while (clusterRating.Keys.Count > 0) {
                int favCluster = 0;
                float favClusterRating = 0;
                foreach (int clust in clusterRating.Keys) {
                    if(clusterRating[clust] > favClusterRating) {
                        favClusterRating = clusterRating[clust];
                        favCluster = clust;
                    }
                }
                rankedProblemClusters.Add(favCluster);
                clusterRating.Remove(favCluster);
            }

            //Given all problems I have not taken in Lesson, sort them with highest
            //rated cluster and highest average user rating
            List<int> potentialPID = db.getAllProblemPID(LID);
            List<int> completedProblems = db.getAllPIDThatUserCompletedInLesson(username, LID);
            foreach(int prob in completedProblems) {
                if (potentialPID.Contains(prob)) {
                    potentialPID.Remove(prob);
                }
            }
            List<int> rankedPID = new List<int>();
            //Selection sort, but idc to optimize currently. Should be good because really smalle
            for (int clust = 0; clust < rankedProblemClusters.Count; ++clust) {
                while (true) { // I am still searching for the cluster I was looking for
                    int favProblem = -1;
                    float bestAvgUserRating = -1;
                    foreach(int potentialProb in potentialPID) {
                        if (problemClusters[potentialProb] == rankedProblemClusters[clust]) {
                            if (db.getOverallUserRating(potentialProb) > bestAvgUserRating) {
                                favProblem = potentialProb;
                                bestAvgUserRating = db.getOverallUserRating(potentialProb);
                            }
                        }
                    }
                    if(favProblem != -1) {
                        rankedPID.Add(favProblem);
                        potentialPID.Remove(favProblem);
                    }
                    else {
                        break;
                    }
                }
            }
            return rankedPID;
        }

        /**
         * Combines both the byProblem and byUser rankings into a single rank
         * */
        private List<int> combineBothRankPIDs(List<int> byProblem, List<int> byUser) {
            Dictionary<int, int> rating = new Dictionary<int, int>();
            for(int index = 0; index < byProblem.Count; ++index) {

            }
        }

        /**
         * Shows the next problem in the problem list. Change the appearence of the page
         * based on the type field in the Problem
         * */
        private void showNextProblem(Boolean previouslyCorrect) {
            //Hide prior feedback
            viewLessonFeedback.Hide();
            viewLessonFeedbackLabel.Hide();

            //Go to next problem
            //currentShownProblemIndex += 1;

            if(db.getAllPIDThatUserCompletedInLesson(username,LID).Count < 1 || db.getAllPIDThatUserCompleted(username).Count < 3) {
                Random rnd = new Random();
                currentShownProblemIndex = rnd.Next(0, allPID.Count);
            }
            else if (previouslyCorrect) {
                List<int> rankedPIDOnProblem = rankPIDsBasedOnProblemClusterRating();
                List<int> rankedPIDOnUser = problemDecisionWithUsers.findBestProblemsBasedOnUsers();

                //Combine two lists based on Problem and Users


                //For testing RankedPIDOnProblem...
                allPID = rankedPIDOnUser;
                currentShownProblemIndex = 0;
            }
            else {
                currentShownProblemIndex += 1;
            }
            


            if(currentShownProblemIndex >= allPID.Count) {
                currentShownProblemIndex = 0;
            }

            int type = db.getProblemType(allPID[currentShownProblemIndex]);
            //Things that they share...
            viewLessonQuestionTitle.Text = db.getProblemTitle(allPID[currentShownProblemIndex]);
            viewLessonQuestionLabel.Text = db.getProblemQuestion(allPID[currentShownProblemIndex]);

            //MC
            if(type == 1) {
                //Show MC stuff
                List<mcViewStruct> mcChoices = setUpMC();
                foreach (mcViewStruct mc in mcChoices) {
                    //We have a choice! 
                    if(mc.CID != -1) {
                        mc.Content.Text = db.getChoiceContent(mc.CID);
                        mc.Content.Show();
                        mc.Checkbox.Show();
                    }
                    //No choice (hide all of it)
                    else {
                        mc.Content.Hide();
                        mc.Checkbox.Hide();
                    }
                }

                //Hide both Dropdown and Chart Components
                foreach (Control c in dropdownComponents) {
                    c.Hide();
                }
                foreach(Control c in chartComponents) {
                    c.Hide();
                }
            }
            //Chart
            else if (type == 2) {
                //Hide both MC and Dropdown Components
                foreach(Control c in mcComponents) {
                    c.Hide();
                }
                foreach(Control c in dropdownComponents) {
                    c.Hide();
                }
                //Convert other stuff
                List<int> allCIDForProblem = db.getAllChoicesCID(allPID[currentShownProblemIndex]);
                showChartGiven(allCIDForProblem);
                foreach(Control c in chartComponents) {
                    c.Show();
                }
            }
            //Dropdown
            else {
                //Hide both MC and Chart Components
                foreach(Control c in mcComponents) {
                    c.Hide();
                }
                foreach(Control c in chartComponents) {
                    c.Hide();
                }

                //Add all choices to the Dropdown...
                viewLessonDropdown.Items.Clear();
                List<int> allCIDForProblem = db.getAllChoicesCID(allPID[currentShownProblemIndex]);
                foreach (int CID in allCIDForProblem) {
                    viewLessonDropdown.Items.Add(db.getChoiceContent(CID));
                }
                foreach(Control c in dropdownComponents) {
                    c.Show();
                }
            }
        }

        /**
         * Cycle to the Previous Image, Title, and Description
         * */
        private void viewLessonPreviousMedia_Click(object sender, EventArgs e) {
            if (mediaInLesson.Count > 1) {
                //Save the current image stuff
                if (0 > currentShownImageIndex - 1) {
                    currentShownImageIndex = mediaInLesson.Count - 1;
                }
                else {
                    currentShownImageIndex -= 1;
                }
                //Show that image
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                viewLessonMedia.Image = Image.FromStream(ms);
                viewLessonImageTitleLable.Text = mediaInLesson[currentShownImageIndex].Title;
                viewLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }
        }

        /**
         * Goes to the next (+1) of the media
         * */
        private void viewLessonNextMedia_Click(object sender, EventArgs e) {
            if (mediaInLesson.Count > 1) {
                if (mediaInLesson.Count == currentShownImageIndex + 1) {
                    currentShownImageIndex = 0;
                }
                else {
                    currentShownImageIndex += 1;
                }
                //Show that image, description, title
                MemoryStream ms = new MemoryStream(mediaInLesson[currentShownImageIndex].Media);
                viewLessonMedia.Image = Image.FromStream(ms);
                viewLessonImageTitleLable.Text = mediaInLesson[currentShownImageIndex].Title;
                viewLessonMediaDescription.Text = mediaInLesson[currentShownImageIndex].Description;
            }
        }

        /**
         * When Skip Question is pressed
         * */
        private void viewLessonSkipQuestionButton_Click(object sender, EventArgs e) {
            showNextProblem(false);
        }

        /**
         * Gets the User's Answer's Content
         * */
        private List<String> getUsersContent() {
            List<String> content = new List<String>();
            int type = db.getProblemType(allPID[currentShownProblemIndex]);
            //MC
            if (type == 1) {
                foreach(mcViewStruct mc in setUpMC()) {
                    if(mc.CID != -1 && mc.CheckboxTF.Checked) {
                        content.Add(mc.Content.ToString());
                    }
                }
            }
            //Chart
            else if (type == 2) {
                String given = "";
                foreach (DataGridViewRow row in viewLessonChart.Rows) {
                    for (int i = 0; i < row.Cells.Count; ++i) {
                        given += (row.Cells[i].Value + ",").ToString();
                    }
                }
                content.Add(given);
            }
            //Dropdown
            else {
                content.Add(viewLessonDropdown.Text);
            }
            return content;
        }

        /**
         * Checks if the user was correct given their answer
         * */
        private Boolean isUserCorrect() {
            int type = db.getProblemType(allPID[currentShownProblemIndex]);
            Boolean allCorrect = true;
            // MC Problem
            if(type == 1) {
                foreach(mcViewStruct mc in setUpMC()) {
                    if(mc.CID > -1) {
                        if(mc.CheckboxTF.Checked != db.getChoiceisSolution(mc.CID)) {
                            //Show the proper feedback
                            allCorrect = false;
                            viewLessonFeedback.Text = db.getChoiceFeedback(mc.CID);
                            if(viewLessonFeedback.Text.Length > 0) {
                                viewLessonFeedback.Text = "Sorry incorrect :(";
                            }
                            viewLessonFeedback.Show();
                            viewLessonFeedbackLabel.Show();
                            break;
                        }
                    }
                    
                }
            }
            // Chart Problem
            else if(type == 2) {
                String given = "";
                foreach (DataGridViewRow row in viewLessonChart.Rows) {
                    for (int i = 0; i < row.Cells.Count; ++i) {
                        given += (row.Cells[i].Value + ",").ToString();
                    }
                }
                List<String> solution = db.getSolutionContent(allPID[currentShownProblemIndex]);
                Boolean solutionCorrect = false;
                foreach(String sol in solution) {
                    int smallestList = Math.Min(sol.Length, given.Length);
                    for(int i = 0; i < smallestList; ++i) {
                        if (!given[i].Equals(sol[i])) {
                            solutionCorrect = false;
                            break;
                        }
                        else {
                            solutionCorrect = true;
                        }
                    }
                    if (solutionCorrect) {
                        String larger = (Math.Min(sol.Length, given.Length) == sol.Length) ? given : sol;
                        for (int i = smallestList; i < larger.Length; ++i) {
                            if (!larger[i].Equals(',')) {
                                solutionCorrect = false;
                                break;
                            }
                        }
                    }
                    break;
                }
                if (!solutionCorrect) {
                    viewLessonFeedback.Text = "That's incorrect. Try to correct it or click Reset to Given to start over";
                    viewLessonFeedback.Show();
                    viewLessonFeedbackLabel.Show();
                    allCorrect = false;
                }
            }
            // Dropdown
            else {
                List<String> solutionContent = db.getSolutionContent(allPID[currentShownProblemIndex]);
                Boolean solutionCorrect = false;
                foreach (String solution in solutionContent) {
                    if (solutionContent[0].ToUpper().Equals(viewLessonDropdown.Text.ToUpper())) {
                        solutionCorrect = true;
                        break;
                    }
                }
                
                //MessageBox.Show("The answer: " + solutionContent[0] + " The Dropdown: " + viewLessonDropdown.Text);
                if(!solutionCorrect) {
                    int wrongCID = db.getCIDFromContent(allPID[currentShownProblemIndex], viewLessonDropdown.Text);
                    viewLessonFeedback.Text = (wrongCID == -1) ? "That Choice was not in the given Choices" : (db.getChoiceFeedback(wrongCID).Length > 0) ? db.getChoiceFeedback(wrongCID) : "That's incorrect :(";
                    viewLessonFeedback.Show();
                    viewLessonFeedbackLabel.Show();
                    allCorrect = false;
                }

            }

            //The user got everything right
            return allCorrect;
        }

        /**
         * When the submit button is pressed. Updates the History of the User and then
         * Checks to see if the user was correct and acts accordingly. 
         * If correct and gets > 5 correct it updates isComplete and closes the window
         * (updating the lesson page for the user)
         * If correct and Lessthan 5 correct, it shows the next problem
         * If wrong, it will show feedback
         * */
        private void button1_Click(object sender, EventArgs e) { 
            //Is Correct?
            if(viewLessonYourRating.Value > 5 || viewLessonYourRating.Value < 0) {
                MessageBox.Show("Please have the user rating between 0 and 5");
            }
            else {
                Boolean isCorrect = isUserCorrect();
                if (isCorrect) {
                    diffComplete += db.getProblemDifficulty(allPID[currentShownProblemIndex]);
                    MessageBox.Show("The question was correct!! You have: " + diffComplete.ToString() + " points. You at least 15 points to pass the lesson");
                    
                    //showNextProblem();
                }
                else {
                    MessageBox.Show("Incorrect!");
                }
                //Add to history
            
                List<String> userAnswer = getUsersContent();
                int userRating = (int)viewLessonYourRating.Value;
                foreach(String answer in userAnswer) {
                    int newHID = db.getHistoryCount();
                    db.addToHistory(newHID, answer, allPID[currentShownProblemIndex], db.getLIDFromPID(allPID[currentShownProblemIndex]), isCorrect, userRating);
                    db.addToUserHistory(newHID, username);
                }
                if (isCorrect) {
                    db.updateProblemUserRating(allPID[currentShownProblemIndex]);
                }
                //If correct, check if done with lesson or go to next problem
                //if (db.getNumberofQuestionsCorrectForLesson(db.getLIDFromPID(allPID[currentShownProblemIndex]),username) >= 3) {
                if(diffComplete >= 15) { 
                    db.updateUserCompleteLesson(db.getLIDFromPID(allPID[currentShownProblemIndex]), username);
                    MessageBox.Show("Congratulations! You finished this lesson. You may advance to other lessons.");
                    if(userMM != null) {
                        userMM.updateDropDown();
                    }
                    this.Close();
                }
                else {
                    //currentShownProblemIndex = -1;
                    if (isCorrect) {
                        showNextProblem(true);
                    }
                    
                }
            }
            
        }


        /**
         * Reset the chart to the given state
         * UNABLE TO TEST!!
         * */
        private void viewLessonChartResetToGivenButton_Click(object sender, EventArgs e) {
            List<int> allCIDForProblem = db.getAllChoicesCID(allPID[currentShownProblemIndex]);
            showChartGiven(allCIDForProblem);
        }
    }
}
