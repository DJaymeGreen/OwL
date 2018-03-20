using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OwLProject {
    public partial class addProblem : Form {

        /**
         * The struct that holds each "choice" for MC
         * */
        public struct MCStruct {
            private String choice;
            private Boolean correct;
            private String feedback;
            public String Choice {
                get {
                    return choice;
                }
                set {
                    choice = value;
                }
            }
            public Boolean Correct {
                get {
                    return correct;
                }
                set {
                    correct = value;
                }
            }
            public String Feedback {
                get {
                    return feedback;
                }
                set {
                    feedback = value;
                }
            }
        }


        database db;
        //ComponentCollection multipleChoiceComponentsCC;
        List<Control> multipleChoiceComponents;
        List<Control> chartFillInComponents;
        List<Control> dropDownComponents;
        public addProblem() {
            InitializeComponent();

            // Fill the lesson title dropdown
            db = new database();
            foreach (String title in db.getAllLessonTitles()) {
                addProblemLessonTitle.Items.Add(title);
            }

            multipleChoiceComponents = new List<Control>();
            multipleChoiceComponents.Add(addProblemMCChoiceLabel);
            multipleChoiceComponents.Add(addProblemMCCorrectLabel);
            multipleChoiceComponents.Add(addProblemMCFeedbackLabel);
            multipleChoiceComponents.Add(addProblemMCChoice1);
            multipleChoiceComponents.Add(addProblemMCChoice1CB);
            multipleChoiceComponents.Add(addProblemMCChoice1Feedback);
            multipleChoiceComponents.Add(addProblemMCChoice2);
            multipleChoiceComponents.Add(addProblemMCChoice2CB);
            multipleChoiceComponents.Add(addProblemMCChoice2Feedback);
            multipleChoiceComponents.Add(addProblemMCChoice3);
            multipleChoiceComponents.Add(addProblemMCChoice3CB);
            multipleChoiceComponents.Add(addProblemMCChoice3Feedback);
            multipleChoiceComponents.Add(addProblemMCChoice4);
            multipleChoiceComponents.Add(addProblemMCChoice4CB);
            multipleChoiceComponents.Add(addProblemMCChoice4Feedback);
            multipleChoiceComponents.Add(addProblemMCChoice5);
            multipleChoiceComponents.Add(addProblemMCChoice5CB);
            multipleChoiceComponents.Add(addProblemMCChoice5Feedback);
            multipleChoiceComponents.Add(addProblemMCChoice6);
            multipleChoiceComponents.Add(addProblemMCChoice6CB);
            multipleChoiceComponents.Add(addProblemMCChoice6Feedback);
            //multipleChoiceComponentsCC = new ComponentCollection(multipleChoiceComponents);

            chartFillInComponents = new List<Control>();
            chartFillInComponents.Add(addProblemChartAnswer);
            chartFillInComponents.Add(addProblemChartAnswerLabel);
            chartFillInComponents.Add(addProblemChartGiven);
            chartFillInComponents.Add(addProblemChartGivenLabel);

            dropDownComponents = new List<Control>();
            dropDownComponents.Add(addProblemMCChoiceLabel);
            dropDownComponents.Add(addProblemMCCorrectLabel);
            dropDownComponents.Add(addProblemMCFeedbackLabel);
            dropDownComponents.Add(addProblemMCChoice1);
            dropDownComponents.Add(addProblemMCChoice1CB);
            dropDownComponents.Add(addProblemMCChoice1Feedback);
            dropDownComponents.Add(addProblemMCChoice2);
            dropDownComponents.Add(addProblemMCChoice2CB);
            dropDownComponents.Add(addProblemMCChoice2Feedback);
            dropDownComponents.Add(addProblemMCChoice3);
            dropDownComponents.Add(addProblemMCChoice3CB);
            dropDownComponents.Add(addProblemMCChoice3Feedback);
            dropDownComponents.Add(addProblemMCChoice4);
            dropDownComponents.Add(addProblemMCChoice4CB);
            dropDownComponents.Add(addProblemMCChoice4Feedback);
            dropDownComponents.Add(addProblemMCChoice5);
            dropDownComponents.Add(addProblemMCChoice5CB);
            dropDownComponents.Add(addProblemMCChoice5Feedback);
            dropDownComponents.Add(addProblemMCChoice6);
            dropDownComponents.Add(addProblemMCChoice6CB);
            dropDownComponents.Add(addProblemMCChoice6Feedback);
        }

        /*
         * When the user clicks the Multiple Choice checkbox
         * All other checkboxes need to be unchecked
         * Their stuff hide, and our stuff show
         * */
        private void addProblemMCCheck_CheckedChanged(object sender, EventArgs e) {
            //Just was checked. Show all in multipleChoiceComponents, uncheck others
            if (addProblemMCCheck.Checked) {
                foreach (Control c in multipleChoiceComponents) {
                    c.Visible = true;
                }
                //Uncheck the rest
                addProblemChartCheck.Checked = false;
                addProblemDropdownCheck.Checked = false;
            }
            else {
                if (addProblemChartCheck.Checked || (!addProblemMCCheck.Checked && !addProblemDropdownCheck.Checked)) {
                    foreach (Control c in multipleChoiceComponents) {
                        c.Visible = false;
                    }
                }
            }
        }

        /**
         * When the user clicks the Chart Check checkbox
         * All other checkboxes need to be unchecked
         * Their stuff hide, and our stuff show
         * */
        private void addProblemChartCheck_CheckedChanged(object sender, EventArgs e) {
            if (addProblemChartCheck.Checked) {
                foreach (Control c in chartFillInComponents) {
                    c.Visible = true;
                }
                //Uncheck the rest
                addProblemMCCheck.Checked = false;
                addProblemDropdownCheck.Checked = false;
            }
            else {
                foreach (Control c in chartFillInComponents) {
                    c.Visible = false;
                }
            }
        }


        /**
         * When the user clicks the Chart Check checkbox
         * All other checkboxes need to be unchecked
         * Their stuff hide, and our stuff show
         * */
        private void addProblemDropdownCheck_CheckedChanged(object sender, EventArgs e) {
            if (addProblemDropdownCheck.Checked) {
                foreach (Control c in dropDownComponents) {
                    c.Visible = true;
                }
                //Uncheck the rest
                addProblemMCCheck.Checked = false;
                addProblemChartCheck.Checked = false;
            }
            else {
                if (addProblemChartCheck.Checked || (!addProblemMCCheck.Checked && !addProblemDropdownCheck.Checked)) {
                    foreach (Control c in dropDownComponents) {
                        c.Visible = false;
                    }
                }

            }
        }

        /**
         * Creates and returns a MC Struct with the given parameters
         * */
        private MCStruct makeMCStruct(String choice, Boolean correct, String feedback) {
            MCStruct mc = new MCStruct();
            mc.Choice = choice;
            mc.Correct = correct;
            mc.Feedback = feedback;
            return mc;
        }

        /**
         * Gets all of the choices associated with MC and returns a
         * struct with all the MC choices in a struct.
         * If the return is empty, there was an mistake somewhere by
         * the user (none filled or mismatch of one filled or not)
         * */
        private List<MCStruct> getMCChoices() {
            List<MCStruct> mcChoices = new List<MCStruct>();
            //MC1
            if ((addProblemMCChoice1.Text == "") != (addProblemMCChoice1Feedback.Text == "")) {
                return new List<MCStruct>();
            }
            else if (addProblemMCChoice1.Text.Length > 0) {
                mcChoices.Add(makeMCStruct(addProblemMCChoice1.Text, addProblemMCChoice1CB.Checked, addProblemMCChoice1Feedback.Text));
            }
            //MC2
            if ((addProblemMCChoice2.Text == "") != (addProblemMCChoice2Feedback.Text == "")) {
                return new List<MCStruct>();
            }
            else if (addProblemMCChoice2.Text.Length > 0) {
                mcChoices.Add(makeMCStruct(addProblemMCChoice2.Text, addProblemMCChoice2CB.Checked, addProblemMCChoice2Feedback.Text));
            }
            //MC3
            if ((addProblemMCChoice3.Text == "") != (addProblemMCChoice3Feedback.Text == "")) {
                return new List<MCStruct>();
            }
            else if (addProblemMCChoice3.Text.Length > 0) {
                mcChoices.Add(makeMCStruct(addProblemMCChoice3.Text, addProblemMCChoice3CB.Checked, addProblemMCChoice3Feedback.Text));
            }
            //MC4
            if ((addProblemMCChoice4.Text == "") != (addProblemMCChoice4Feedback.Text == "")) {
                return new List<MCStruct>();
            }
            else if (addProblemMCChoice4.Text.Length > 0) {
                mcChoices.Add(makeMCStruct(addProblemMCChoice4.Text, addProblemMCChoice4CB.Checked, addProblemMCChoice4Feedback.Text));
            }
            //MC5
            if ((addProblemMCChoice5.Text == "") != (addProblemMCChoice5Feedback.Text == "")) {
                return new List<MCStruct>();
            }
            else if (addProblemMCChoice5.Text.Length > 0) {
                mcChoices.Add(makeMCStruct(addProblemMCChoice5.Text, addProblemMCChoice5CB.Checked, addProblemMCChoice5Feedback.Text));
            }
            //MC6
            if ((addProblemMCChoice6.Text == "") != (addProblemMCChoice6Feedback.Text == "")) {
                return new List<MCStruct>();
            }
            else if (addProblemMCChoice6.Text.Length > 0) {
                mcChoices.Add(makeMCStruct(addProblemMCChoice6.Text, addProblemMCChoice6CB.Checked, addProblemMCChoice6Feedback.Text));
            }
            return mcChoices;
        }

        /**
         * Gets the choices from the chart and adds them to a MCStruct which will
         * be put into the database 
         * If it returns an empty List, then an error occurred
         * */
        private List<MCStruct> getChartChoices() {
            List<MCStruct> chartChoice = new List<MCStruct>();
            String given = "";
            String answer = "";

            foreach(DataGridViewRow row in addProblemChartGiven.Rows) {
                for(int i = 0; i < row.Cells.Count; ++i) {
                    given += (row.Cells[i].Value + ",").ToString();
                }
            }

            //Create struct for Given
            chartChoice.Add(makeMCStruct(given, false, ""));

            foreach (DataGridViewRow row in addProblemChartAnswer.Rows) {
                for (int i = 0; i < row.Cells.Count; ++i) {
                    answer += (row.Cells[i].Value + ",").ToString();
                }
            }

            //Create struct for Answer
            chartChoice.Add(makeMCStruct(answer, true, ""));

            //HOW TO CONVERT BACK INTO A LIST OF STRINGS!!
            //List<String> splittingGiven = given.Split(',').ToList<String>();

            return chartChoice;
        }

        /**
         * Add the problem and choice to the database...
         * */
        private void addProblemChoiceToDB(List<MCStruct> choices) {
            int newPID = db.getProblemCount()+1;
            int type = (addProblemMCCheck.Checked) ? 1 : (addProblemChartCheck.Checked) ? 2 : 3;
            db.addProblemToDB(newPID, type, (int)addProblemDifficulty.Value, addProblemQuestion.Text, addProblemTitle.Text);
            db.connectLessonProblem(db.getLidFromTitle(addProblemLessonTitle.Text), newPID);

            int CID;
            //Add this to choices
            foreach (MCStruct choice in choices) {
                CID = db.getChoiceCount()+1;
                db.addChoice(CID, choice.Choice, choice.Correct, choice.Feedback);
                db.connectProblemChoice(newPID, CID);

                //MessageBox.Show("Is it equal: " + choice.Choice.Equals(db.getChoiceContent(CID)));
            }
            MessageBox.Show("Successfully added question!");
            this.Close();
        }

        /**
         * When the Save Button is clicked. Make sure the stuff is filled correctly.
         * Then convert all data into something that can be given to the database
         * Add Problem once, then Add Choice depending the number of filled stuff
         * as well as Add Problem/Choice and Add Lesson/Problem
         * */
        private void addProblemSaveButton_Click(object sender, EventArgs e) {
            //Make sure all required stuff is valid
            if(addProblemLessonTitle.Text == "") {
                MessageBox.Show("No Given Lesson!");
            }
            else if (!db.getAllLessonTitles().Contains(addProblemLessonTitle.Text)) {
                MessageBox.Show("That Lesson doesn't exist!");
            }
            else if(addProblemDifficulty.Value > 5 || addProblemDifficulty.Value < 0) {
                MessageBox.Show("The difficulty must be between 0 and 5");
            }
            else if (addProblemTitle.Text == "") {
                MessageBox.Show("No Problem Title given!");
            }
            else if (addProblemQuestion.Text == "") {
                MessageBox.Show("No Problem given!");
            }
            // Valid Problem Given
            else {
                //Multiple Choice...
                if (addProblemMCCheck.Checked) {
                    List<MCStruct> mc = getMCChoices();
                    if(mc.Count < 1) {
                        MessageBox.Show("Invalid Choices. Make sure both Choice and Feedback are specifed");
                    }
                    //Need to add to database...
                    addProblemChoiceToDB(mc);
                }
                //Chart Fill-In...
                else if (addProblemChartCheck.Checked) {
                    List<MCStruct> chartChoices = getChartChoices();
                    if (chartChoices.Count < 1) {
                        MessageBox.Show("Invalid Choices. Make sure both Choice and Feedback are specifed");
                    }
                    //Need to add to database
                    addProblemChoiceToDB(chartChoices);
                }
                //Dropdown...
                else if (addProblemDropdownCheck.Checked) {
                    List<MCStruct> drop = getMCChoices();
                    if (drop.Count < 1) {
                        MessageBox.Show("Invalid Choices. Make sure both Choice and Feedback are specifed");
                    }
                    addProblemChoiceToDB(drop);
                }
                // Nothing is Checked :(
                else {
                    MessageBox.Show("Problem is not Specified");
                }
            }
        }
    }
}
