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
                    "(username,password,email,joinDate,LTOther,LTVisual,LTAudio) VALUES " +
                    "(@username,@password,@email,@joinDate,@LTOther,@LTVisual,@LTAudio)");
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@joinDate", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@LTOther", other);
                cmd.Parameters.AddWithValue("@LTVisual", visual);
                cmd.Parameters.AddWithValue("@LTAudio", audio);

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
    }
}
