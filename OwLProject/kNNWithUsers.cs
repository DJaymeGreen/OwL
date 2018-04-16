using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwLProject {
    class kNNWithUsers {
        database db;
        String thisUser;
        int LID;

        public kNNWithUsers(String thisUser, int LID) {
            db = new database();
            this.thisUser = thisUser;
            this.LID = LID;
        }

        /**
         * Gets the Euclidean Distance between thisUser and another user.
         * Based on user Rating and numberOfAttempts
         * */
        private float getEuclideanDistance(String otherUser, int problemID) {
            //Splitting up for debugging....
            //int myUserRating = db.getUserRatingByUser(thisUser, problemID);
            //int theirUserRating = db.getUserRatingByUser(otherUser, problemID);
            //int myNumberOfAttempts = db.getNumberOfAttempts(thisUser, problemID);
            //int theirNumberOfAttempts = db.getNumberOfAttempts(otherUser, problemID);
            float euclideanDist = (float)Math.Pow((db.getUserRatingByUser(thisUser,problemID) - db.getUserRatingByUser(otherUser,problemID)),2);
            euclideanDist += (float)Math.Pow((db.getNumberOfAttempts(thisUser, problemID) - db.getNumberOfAttempts(otherUser, problemID)), 2);
            return ((float)Math.Sqrt(euclideanDist));
        }

        /**
         * Searches through all the users and maps each user with a score
         * based on how much we share the same opinion.
         * Returns a Dictionary with {user, similarity}. 
         * Lower similarlity means more agreeable
         * */
        private Dictionary<String,float> findUserAgreementDifference() {
            Dictionary<String, float> agreementDifference = new Dictionary<string, float>();
            Dictionary<String, int> numOfSameProblems = new Dictionary<string, int>();
            foreach(String user in db.getAllUsers()) {
                if (user.Equals(thisUser)) {
                    continue;
                }
                agreementDifference[user] = 0;
                numOfSameProblems[user] = 0;
            }

            //Sum all problems together
            foreach(int problemITook in db.getAllPIDThatUserCompleted(thisUser)) {
                foreach(String user in db.getAllUsersThatCompletedProblem(problemITook)) {
                    if (user.Equals(thisUser)) {
                        continue;
                    }
                    agreementDifference[user] += getEuclideanDistance(user, problemITook);
                    numOfSameProblems[user] += 1;
                }
            }

            //Average the agreements
            foreach (String user in numOfSameProblems.Keys) {
                if(numOfSameProblems[user] > 0) {
                    agreementDifference[user] /= numOfSameProblems[user];
                }
                else {
                    agreementDifference[user] = 2.5f;
                }
            }
            return agreementDifference;
        }

        /**
         * Find the users that I agree with the most. The user with the minimum value in the 
         * given dictionary should be returned in order.
         * */
        private List<String> findMostAgreeableUser(Dictionary<String,float> agreementDifference) {
            String mostAgreeableUser = "";
            float minAgree = float.MaxValue;
            List<String> rankedUsers = new List<String>();
            while(agreementDifference.Count > 0) {
                foreach(String key in agreementDifference.Keys) {
                    if(minAgree > agreementDifference[key]) {
                        mostAgreeableUser = key;
                        minAgree = agreementDifference[key];
                    }
                }
                rankedUsers.Add(mostAgreeableUser);
                agreementDifference.Remove(mostAgreeableUser);
                minAgree = float.MaxValue;
            }
            return rankedUsers;
        }

        /**
         * Finds the problems that I haven't done and ranks them based on the users
         * I agreed with average rating
         * */
        private List<int> findBestProblemNotCompletedByMe(List<String> mostAgreeableUser) {
            Dictionary<int, float> problemRating = new Dictionary<int, float>();
            Dictionary<int, int> numOfPeopleDidProblem = new Dictionary<int, int>();

            List<int> problemsTakenAlready = db.getAllPIDThatUserCompletedInLesson(thisUser,LID);

            int numberOfUsersToConsider = (mostAgreeableUser.Count < 10)? 1 : mostAgreeableUser.Count / 10;
            for (int numUsersAgreeing = 0; numUsersAgreeing < numberOfUsersToConsider; ++numUsersAgreeing) {
                //Get the list of all problems user has taken that thisUser has not
                List<int> problemsTakenByOtherUser = db.getAllPIDThatUserCompletedInLesson(mostAgreeableUser[numUsersAgreeing], LID);
                foreach (int probTaken in problemsTakenAlready) {
                    if (problemsTakenByOtherUser.Contains(probTaken)) {
                        problemsTakenByOtherUser.Remove(probTaken);
                    }
                }

                //Update dictionary of rating
                foreach (int prob in problemsTakenByOtherUser) {
                    if (problemRating.ContainsKey(prob)) {
                        problemRating[prob] += db.getUserRatingByUser(mostAgreeableUser[numUsersAgreeing], prob);
                        numOfPeopleDidProblem[prob]++;
                    }
                    else {
                        problemRating[prob] = db.getUserRatingByUser(mostAgreeableUser[numUsersAgreeing], prob);
                        numOfPeopleDidProblem[prob] = 1;
                    }
                }
            }
            //Find the true rating by dividing rating by num of people who did it
            foreach(int key in numOfPeopleDidProblem.Keys) {
                problemRating[key] /= numOfPeopleDidProblem[key];
            }
            //Fill in for problems not in the list with 2.5 (middle rating)
            List<int> allPID = db.getAllProblemPID(LID);
            foreach(int prob in allPID) {
                if (!problemRating.ContainsKey(prob)) {
                    problemRating[prob] = 2.5f;
                }
            }

            //Rank all problems with highest user rating
            List<int> rankedProblems = new List<int>();
            int highestRanked = 0;
            float highestUserRating = float.MinValue;
            while (problemRating.Count > 0) {
                foreach (int prob in problemRating.Keys) {
                    if (problemRating[prob] > highestUserRating) {
                        highestUserRating = problemRating[prob];
                        highestRanked = prob;
                    }
                }
                if (!problemsTakenAlready.Contains(highestRanked)) {
                    rankedProblems.Add(highestRanked);
                }
                problemRating.Remove(highestRanked);
                highestUserRating = float.MinValue;
            }

            return rankedProblems;
        }

        /**
         * Finds the best problems based on finding the other User's with
         * the most agreement with regarding userRating. Then, finds the
         * problem with the highest user rating that the other user's liked
         * */
        public List<int> findBestProblemsBasedOnUsers() {
            List<int> rankedPID = new List<int>();

            Dictionary<String, float> userAgreementDifference = findUserAgreementDifference();

            List<String> mostAgreeableUser = findMostAgreeableUser(userAgreementDifference);

            List<int> rankedProblems = findBestProblemNotCompletedByMe(mostAgreeableUser);

            return rankedProblems;
        }
    }
}
