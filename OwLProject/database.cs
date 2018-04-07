using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwLProject {
   
    class database {
        String connectionString = "Data Source=masterprojectdb.ckvsbmp9znkr.us-east-2.rds.amazonaws.com,1433;Initial Catalog=owlDb;User ID=admin;Password=Yorktown11";
        //SqlConnection db = new SqlConnection("Data Source=masterprojectdb.ckvsbmp9znkr.us-east-2.rds.amazonaws.com,1433;Initial Catalog=owlDb;User ID=admin;Password=Yorktown11");

        /**
         * Checks if the given username and password exist in the table
         * */
        public Boolean checkUserInDB(String username, String password) {
            using(SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM allUsers " +
                "WHERE username = @username " +
                "AND password = @password");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();
                
                return (count != 0);
            }
        }

        /**
         * Checks if the given username is already in the database
         * */
        public Boolean checkUniqueUsername(String username) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM allUsers " +
                "WHERE username = @username");
                cmd.Parameters.AddWithValue("@username", username);
                
                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count == 0);
            }
        }

        /**
         * Gets all of the Lessons IDs from the Lessons Table
         * */
        public ArrayList getAllLessonsIds() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT LID FROM Lesson");

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();

                ArrayList allLessonIds = new ArrayList();
                while (dr.Read()) {
                    allLessonIds.Add(Convert.ToString(dr[0]));
                }

                return (allLessonIds);
            }
        }

        /**
         * Register a new user into the allUsers table. Also, add the user to the userLesson
         * table with all the lessons corresponding.
         * */
        public Boolean registerUser(String username, String password, String email, int other, int visual, int audio) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO allUsers " +
                    "(username,password,email,joinDate,LTOther,LTVisual,LTAudio,isAdmin) VALUES " +
                    "(@username,@password,@email,@joinDate,@LTOther,@LTVisual,@LTAudio, @isAdmin)");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@joinDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@LTOther", other);
                cmd.Parameters.AddWithValue("@LTVisual", visual);
                cmd.Parameters.AddWithValue("@LTAudio", audio);
                cmd.Parameters.AddWithValue("@isAdmin", false);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
                if (colsAffected == 0) {
                    return false;
                }
            }
            // Add the lessons for the User
            foreach (String lesson in getAllLessonsIds()) {
                using (SqlConnection db = new SqlConnection(connectionString)) {
                    db.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO UserLesson " +
                        "(username,LID,isComplete) VALUES " +
                        "(@username,@LID,@isComplete)");
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@LID", lesson);
                    cmd.Parameters.AddWithValue("@isComplete", false);

                    cmd.Connection = db;
                    int colsAffected = cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        /**
         * Gets all of the unique lesson titles into an arraylist and returns
         * */
        public ArrayList getAllLessonTitles() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT title FROM Lesson");

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();

                ArrayList allLessonTitles = new ArrayList();
                while (dr.Read()) {
                    allLessonTitles.Add(Convert.ToString(dr[0]));
                }

                return (allLessonTitles);
            }
        }

        /**
         * Gets all of the media associated with the given LID
         * */
        public ArrayList getAllMedia(int LID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT media FROM MediaLesson " +
                    "WHERE LID = @lid");
                cmd.Parameters.AddWithValue("@lid",LID);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();

                ArrayList allMedia = new ArrayList();
                while (dr.Read()) {
                    allMedia.Add((byte[])dr[0]);
                }

                return (allMedia);
            }
        }

        /**
         * Gets the number of Lessons in the Lesson Table
         * */
        public int getAllLessonsCount() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Lesson");

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Gets the number of Media in the Media Table
         * */
        public int getAllMediaCount() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM MediaLesson");

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Checks if the lesson exists given the title
         * */
        public Boolean checkIfLessonTitleExists(String title) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Lesson " +
                "WHERE title = @title");
                cmd.Parameters.AddWithValue("@title", title);

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count != 0);
            }
        }

        /**
         * Gets the LID from the given title in Lesson
         * */
        public int getLidFromTitle(String title) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT LID FROM Lesson " +
                    "WHERE title = @title");
                cmd.Parameters.AddWithValue("@title", title);

                cmd.Connection = db;
                Int32 LID = (Int32)cmd.ExecuteScalar();

                return (LID);
            }
        }

        /**
         * Returns all of the Users in the database by Username
         * */
        public ArrayList getAllUsers() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT username FROM allUsers");

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();

                ArrayList allUsernames = new ArrayList();
                while (dr.Read()) {
                    allUsernames.Add(Convert.ToString(dr[0]));
                }

                return (allUsernames);
            }
        }

        /**
         * Create a new Lesson with the given data
         * */
        public Boolean addLesson(int LID, String title, int prereq, int difficulty, Boolean markedTypo, int contentV, int contentA, int contentO, String content) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();
                //int? hadPrereq = (prereq == 0) ? null : prereq;
                SqlCommand cmd = new SqlCommand("INSERT INTO Lesson " +
                    "(LID,title,preReq,difficulty,markedTypo,userRating,contentV,contentA,contentO,content) VALUES " +
                    "(@LID,@title,@preReq,@difficulty,@markedTypo,@userRating,@contentV,@contentA,@contentO,@content)");
                cmd.Parameters.AddWithValue("@LID", LID);
                cmd.Parameters.AddWithValue("@title", title);
                if (prereq == 0) {
                    cmd.Parameters.AddWithValue("@preReq", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@preReq", prereq);
                }
                cmd.Parameters.AddWithValue("@difficulty", difficulty);
                cmd.Parameters.AddWithValue("@markedTypo", markedTypo);
                cmd.Parameters.AddWithValue("@userRating", 5);
                cmd.Parameters.AddWithValue("@contentV", contentV);
                cmd.Parameters.AddWithValue("@contentA", contentA);
                cmd.Parameters.AddWithValue("@contentO", contentO);
                cmd.Parameters.AddWithValue("@content", content);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
                if (colsAffected == 0) {
                    return false;
                }
                //return true;
            }

            // Give all Users the Lesson
            foreach (String user in getAllUsers()) {
                using (SqlConnection db = new SqlConnection(connectionString)) {
                    db.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO UserLesson " +
                        "(username,LID,isComplete) VALUES " +
                        "(@username,@LID,@isComplete)");
                    cmd.Parameters.AddWithValue("@username", user);
                    cmd.Parameters.AddWithValue("@LID", LID);
                    cmd.Parameters.AddWithValue("@isComplete", false);

                    cmd.Connection = db;
                    int colsAffected = cmd.ExecuteNonQuery();
                }
            }
            return true;
            //return true;

        }

        /**
         * Gets the Lesson's Title with the given LID
         * */
        public String getLessonTitle(int LID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT title FROM Lesson " +
                    "WHERE LID = @LID");
                cmd.Parameters.AddWithValue("@LID", LID);

                cmd.Connection = db;
                String content = (String)cmd.ExecuteScalar();

                return (content);
            }
        }

        /**
         * Grabs the Content of the given Lesson
         * */
        public String getLessonContent(int LID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT content FROM Lesson " +
                    "WHERE LID = @LID");
                cmd.Parameters.AddWithValue("@LID", LID);

                cmd.Connection = db;
                String content = (String)cmd.ExecuteScalar();

                return (content);
            }
        }

        /**
         * Gets all of the media for a given LID
         * */
        public List<mediaStruct> getAllMediaForLesson(int LID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT media,title,description FROM MediaLesson " +
                    "WHERE LID = @LID");
                cmd.Parameters.AddWithValue("@LID",LID);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();

                List<mediaStruct> allMedia = new List<mediaStruct>();
                while (dr.Read()) {
                    mediaStruct image = new mediaStruct();
                    image.Media = (byte[])dr[0];
                    image.Title = (Convert.ToString(dr[1]));
                    image.Description = (Convert.ToString(dr[1]));
                    //allMedia.Add(Convert.ToString(dr[0]));
                    allMedia.Add(image);
                }

                return (allMedia);
            }
        }

        // Add the given Media to the MediaLesson db returning True if successful
        public Boolean addMediaLesson(int LID, byte[] media, String title, String description) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO MediaLesson " +
                    "(MID,LID,media,title,description) VALUES " +
                    "(@MID,@LID,@media,@title,@description)");
                cmd.Parameters.AddWithValue("@MID", getAllMediaCount()+1);
                cmd.Parameters.AddWithValue("@LID", LID);
                cmd.Parameters.AddWithValue("@media", media);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }
        
            return true;
        }

        /**
         * Gets the number of all of the Problem
         * */
        public int getProblemCount() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Problem");

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Gets the total number of Choices 
         * */
        public int getChoiceCount() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Choice");

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Add the given problem to the database
         * */
        public bool addProblemToDB(int PID, int type, int difficulty, String question, String title) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Problem " +
                    "(PID,type,difficulty,question,title,markedBug,userRating,userDifficulty) VALUES " +
                    "(@PID,@type,@difficulty,@question,@title,@markedBug,@userRating,@userDifficulty)");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@difficulty", difficulty);
                cmd.Parameters.AddWithValue("@question", question);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@markedBug", false);
                cmd.Parameters.AddWithValue("@userRating", 5);
                cmd.Parameters.AddWithValue("@userDifficulty", 0);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }

            return true;
        }

        /**
         * Adds the given Choice to the database
         * */
        public bool addChoice(int CID, String content, Boolean isSolution, String feedback) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Choice " +
                    "(CID,content,isSolution,feedback) VALUES " +
                    "(@CID,@content,@isSolution,@feedback)");
                cmd.Parameters.AddWithValue("@CID", CID);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@isSolution", isSolution);
                cmd.Parameters.AddWithValue("@feedback", feedback);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }

            return true;
        }

        /**
         * Adds the given PID and CID to the ProblemChoice table
         * */
        public bool connectProblemChoice(int PID, int CID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO ProblemChoice " +
                    "(PID,CID) VALUES " +
                    "(@PID,@CID)");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@CID", CID);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }

            return true;
        }

        /**
         * Connect the Lesson and Problem together
         * */
        public bool connectLessonProblem(int LID, int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO LessonProblem " +
                    "(LID,PID) VALUES " +
                    "(@LID,@PID)");
                cmd.Parameters.AddWithValue("@LID", LID);
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }

            return true;
        }

        /**
         * Get all of the PID that are associated with the LID
         * */
        public List<int> getAllProblemPID(int LID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT PID FROM LessonProblem " +
                    "WHERE LID = @LID");
                cmd.Parameters.AddWithValue("@LID", LID);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();
                List<int> allPID = new List<int>();
                if (dr.HasRows) {
                    while (dr.Read()) {
                        allPID.Add((int)dr[0]);
                    }
                }
                return (allPID);
            }
        }

        /**
         * Gets all of the CID associated with the PID
         * */
        public List<int> getAllChoicesCID(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT CID FROM ProblemChoice " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();
                List<int> allCID = new List<int>();
                if (dr.HasRows) {
                    while (dr.Read()) {
                        allCID.Add((int)dr[0]);
                    }
                }
                return (allCID);
            }
        }

        /**
         * Gets the type for the given Problem
         * */
        public int getProblemType(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT type FROM Problem " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                int type = (int)cmd.ExecuteScalar();

                return (type);
            }
        }


        /**
         * Gets the difficulty for the given Problem
         * */
        public int getProblemDifficulty(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT difficulty FROM Problem " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                int difficulty = (int)cmd.ExecuteScalar();

                return (difficulty);
            }
        }

        /**
         * Gets the question for the given Problem
         * */
        public String getProblemQuestion(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT question FROM Problem " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                String question = (String)cmd.ExecuteScalar();

                return (question);
            }
        }

        /**
         * Gets the title for the given Problem
         * */
        public String getProblemTitle(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT title FROM Problem " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                String title = (String)cmd.ExecuteScalar();

                return (title);
            }
        }

        /**
         * Gets the content for the given Choice
         * */
        public String getChoiceContent(int CID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT content FROM Choice " +
                    "WHERE CID = @CID");
                cmd.Parameters.AddWithValue("@CID", CID);

                cmd.Connection = db;
                String content = (String)cmd.ExecuteScalar();

                return (content);
            }
        }

        /**
         * Gets the isSolution for the given Choice
         * */
        public bool getChoiceisSolution(int CID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT isSolution FROM Choice " +
                    "WHERE CID = @CID");
                cmd.Parameters.AddWithValue("@CID", CID);

                cmd.Connection = db;
                bool isSolution = (bool)cmd.ExecuteScalar();

                return (isSolution);
            }
        }

        /**
         * Gets the feedback for the given Choice
         * */
        public String getChoiceFeedback(int CID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT feedback FROM Choice " +
                    "WHERE CID = @CID");
                cmd.Parameters.AddWithValue("@CID", CID);

                cmd.Connection = db;
                String isSolution = (String)cmd.ExecuteScalar();

                return (isSolution);
            }
        }

        /**
         * Get the number of items in the History table.
         * Mostly to determine the next HID to make
         * */
        public int getHistoryCount() {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM History");

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Add the given information to the History table
         * */
        public Boolean addToHistory(int HID, String input, int PID, int LID, Boolean isCorrect, int userRating) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO History " +
                    "(HID,input,PID,LID,isCorrect,userRating) VALUES " +
                    "(@HID,@input,@PID,@LID,@isCorrect,@userRating)");
                cmd.Parameters.AddWithValue("@HID", HID);
                cmd.Parameters.AddWithValue("@input", input);
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@LID", LID);
                cmd.Parameters.AddWithValue("@isCorrect", isCorrect);
                cmd.Parameters.AddWithValue("@userRating", userRating);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }

            return true;
        }

        /**
         * Connect a username and a HID together. This should be done for every
         * addition to the History table.
         * */
        public Boolean addToUserHistory(int HID,String username) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO UserHistory " +
                    "(HID,username) VALUES " +
                    "(@HID,@username)");
                cmd.Parameters.AddWithValue("@HID", HID);
                cmd.Parameters.AddWithValue("@username", username);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }

            return true;
        }

        /**
         * Look at the History table for the given user and lesson and get the number
         * of correct problems that the user has done
         * */
        public int getNumberofQuestionsCorrectForLesson(int LID, String username) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                //Need a table join...
                SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT h.PID) FROM " + 
                    "History AS h, UserHistory as uh, User as u " +
                    "WHERE h.HID = uh.HID AND " +
                    "uh.username = @username AND " +
                    "h.LID = @LID AND " +
                    "h.isCorrect = @true");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@LID", LID);
                cmd.Parameters.AddWithValue("@true", true);

                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Gets the content associated with the Solution of the problem.
         * */
        public List<String> getSolutionContent(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                //Need a table join...
                SqlCommand cmd = new SqlCommand("SELECT C.content FROM " +
                    "Choice AS c, ProblemChoice as pc, Problem as p " +
                    "WHERE @PID = pc.PID AND " +
                    "pc.CID = c.CID AND " +
                    "c.isSolution = @true");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@true", true);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();
                List<String> solutionContent = new List<String>();
                if (dr.HasRows) {
                    while (dr.Read()) {
                        solutionContent.Add((String)dr[0]);
                    }
                }
                return (solutionContent);
            }
        }

        /**
         * Gets the CID given the PID and content. Should only return a single int
         * of either the CID or -1 (if no CID associated with it)
         * */
        public int getCIDFromContent(int PID, String content) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                //Need a table join...
                SqlCommand cmd = new SqlCommand("SELECT C.CID FROM " +
                    "Choice AS c, ProblemChoice as pc " +
                    "WHERE @PID = pc.PID AND " +
                    "pc.CID = c.CID AND " +
                    "c.content = @content");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@content", content);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();
                int solutionContent = -1;
                if (dr.HasRows) {
                    while (dr.Read()) {
                        solutionContent = ((int)dr[0]);
                    }
                }
                return (solutionContent);
            }
        }

        /**
         * Given a PID, it returns the LID associated with it
         * */
        public int getLIDFromPID(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT LID FROM LessonProblem " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);

                cmd.Connection = db;
                Int32 LID = (Int32)cmd.ExecuteScalar();

                return (LID);
            }
        }

        /**
         * Changes the User's Complete Lesson to True 
         * */
        public Boolean updateUserCompleteLesson(int LID, String username) {
            using(SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("UPDATE UserLesson " +
                    "SET isComplete = @true " +
                    "WHERE username = @username AND " +
                    "LID = @LID");
                cmd.Parameters.AddWithValue("@true", true);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@LID", LID);

                cmd.Connection = db;
                int colsAffected = cmd.ExecuteNonQuery();
            }
            return true;
        }

        /**
         * Returns if the user is an Admin or not
         * */
        public Boolean isUserAdmin(String username) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT isAdmin FROM allUsers " +
                    "WHERE username = @username");
                cmd.Parameters.AddWithValue("@username", username);

                cmd.Connection = db;
                bool isAdmin = (bool)cmd.ExecuteScalar();

                return (isAdmin);
            }
        }

        /**
         * Gets all of the lessons of the user that are not complete
         * */
        public List<int> getAllNotCompleteLessons(String username) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT LID FROM UserLesson " +
                    "WHERE username = @username AND " +
                    "isComplete = @false");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@false", false);

                cmd.Connection = db;
                SqlDataReader dr = cmd.ExecuteReader();
                List<int> allLID = new List<int>();
                if (dr.HasRows) {
                    while (dr.Read()) {
                        allLID.Add((int)dr[0]);
                    }
                }
                return (allLID);
            }
        }

        /**
         * Gets the Pre-req of the given Lesson. Returns -1 if the Pre-req is Null
         * */
        public int getPreReq(int LID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT preReq FROM Lesson " +
                "WHERE LID = @LID");
                cmd.Parameters.AddWithValue("@LID", LID);

                cmd.Connection = db;
                Object count = cmd.ExecuteScalar();

                int preReq = (count.Equals(DBNull.Value)) ? -1 : (Int32)count;

                return (preReq);
            }
        }

        /**
         * Gets whether the username and the LID have their pre-req complete
         * */
        public Boolean getPreReqComplete(int LID, String username) {
            int LIDofPreReq = getPreReq(LID);
            if (LIDofPreReq == -1) {
                return true;
            }

            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT isComplete FROM UserLesson " +
                "WHERE username = @username " +
                "AND LID = @LID");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@LID", LIDofPreReq);

                cmd.Connection = db;
                Boolean isComplete = (Boolean)cmd.ExecuteScalar();

                return (isComplete);
            }
        }

        /**
         * Gets all of the Lessons that are not completed but who's pre-req is 
         * complete from the user
         * @param       username            The user to get the lessons for
         * @return      List<int>           All the LID's that are 
         * */
        public List<int> getAllUnlockedNotCompleteLessons(String username) {
            List<int> allNonCompleteLessons = getAllNotCompleteLessons(username);
            List<int> allUnlockedNotCompleteLessons = new List<int>();
            foreach(int lesson in allNonCompleteLessons) {
                if (getPreReqComplete(lesson, username)) {
                    allUnlockedNotCompleteLessons.Add(lesson);
                }
            }
            return allUnlockedNotCompleteLessons;
        }

        /**
         * Gets the amount of user's that have completed the given problem
         * and answered it correctly
         * */
        public int getAllHistoryIsCorrect(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM History " +
                    "WHERE PID = @PID AND " +
                    "isCorrect = @true");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@true", true);
                cmd.Connection = db;
                Int32 count = (Int32)cmd.ExecuteScalar();

                return (count);
            }
        }

        /**
         * Gets the sum of all User Ratings of a given problem given that the
         * history was correct
         * */
        public int getSumOfHistoryUserRating(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                SqlCommand cmd = new SqlCommand("SELECT SUM(userRating) FROM History " +
                    "WHERE PID = @PID AND " +
                    "isCorrect = @true");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Parameters.AddWithValue("@true", true);
                cmd.Connection = db;
                Int32 sum = (Int32)cmd.ExecuteScalar();

                return (sum);
            }
        }

        /**
         * Updates the User Rating of the given problem by looking at 
         * what user's that got it right stated
         * */
        public Boolean updateProblemUserRating(int PID) {
            using (SqlConnection db = new SqlConnection(connectionString)) {
                db.Open();

                float sumOfRatings = getSumOfHistoryUserRating(PID);
                float numOfRatings = getAllHistoryIsCorrect(PID);
                int newUserRating = (int)Math.Round(sumOfRatings / numOfRatings);

                SqlCommand cmd = new SqlCommand("UPDATE userRating = @newUserRating " +
                    "FROM Problem " +
                    "WHERE PID = @PID");
                cmd.Parameters.AddWithValue("@PID", PID);
                cmd.Connection = db;
                cmd.ExecuteNonQuery();
                //Int32 sum = (Int32)cmd.ExecuteScalar();

                return (true);
            }
        }
    }
}
