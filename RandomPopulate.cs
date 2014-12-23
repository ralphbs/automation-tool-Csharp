using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace ThirdExercise {
    class RandomPopulate {
        #region Enum

        public enum DateRanges {
            JoinedBefore = 0,
            JoinedBetween = 1,
            JoinedAfter = 2,
            ExitedBefore = 3
        }

        #endregion

        #region Variables

        static DateTime MIN_DATE = new DateTime(1975, 1, 1);
        static DateTime MAX_DATE = new DateTime(2015, 1, 1);
        private static Random random = new Random((int)DateTime.Now.Ticks);
		 
	#endregion

        #region Methods
        public static DateTime RandomGenerator(int MAX_NUM, DateRanges ranges) {
            Random random = new Random((int)DateTime.Now.Ticks);
            DateTime dateObject = new DateTime();
            switch (ranges) {
                case DateRanges.JoinedBefore:
                    //dateObject = GenerateJoinedBeforeList();
                    break;
                case DateRanges.JoinedBetween:
                    dateObject = GenerateJoinedBetweenList();
                    break;
                case DateRanges.JoinedAfter:
                    dateObject = GenerateJoinedAfterList();
                    break;
                case DateRanges.ExitedBefore:
                    dateObject = GenerateExitedBeforeList();
                    break;
            }
            return dateObject;
        }
       
        private static RandomUserObject GenerateRandomUserObject(DateTime joinDate, DateTime exitDate) {
            RandomUserObject userObject = null;
            if (joinDate == null && exitDate == null) {
                userObject = new RandomUserObject(
                        RandomUsernameGenerator(50),
                        GetCustomizedDate(new DateTime(1975, 1, 1), new DateTime(1990, 1, 1)),
                        GetCustomizedDate(new DateTime(1995, 1, 1), new DateTime(2015, 1, 1)));
            } else if (exitDate == null) {
                userObject = new RandomUserObject(
                            RandomUsernameGenerator(50),
                            joinDate,
                            GetCustomizedDate(new DateTime(1995, 1, 1), new DateTime(2015, 1, 1)));
            } else {
                userObject = new RandomUserObject(
                        RandomUsernameGenerator(50),
                        joinDate,
                        exitDate);
            }
            return userObject;
        }
        
        private static string RandomUsernameGenerator(int size) {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++) {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
       
        private static DateTime GetCustomizedDate(DateTime StartDate, DateTime EndDate) {
            Random gen = new Random((int)DateTime.Now.Ticks);
            int range = (EndDate - StartDate).Days;
            return StartDate.AddDays(gen.Next(range));
        }

        public static List<string> StringResults(int MAX_SIZE) {
            List<string> Usernames = new List<string>();
            for (int i = 0; Usernames.Count() <= MAX_SIZE; i++) {
                string randomUsername = RandomUsernameGenerator(50);
                if (!Usernames.Contains(randomUsername)) {
                    Usernames.Add(randomUsername);
                }
            }
            return Usernames;
        }

        public static List<DateTime> DateResults(int MAX_SIZE, DateRanges dateRange) {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; dates.Count() <= MAX_SIZE; i++) {
                DateTime randomDate = RandomGenerator(50, dateRange);
                if (!dates.Contains(randomDate)) {
                    dates.Add(randomDate);
                }
            }
            return dates;
        }

        public static DateTime GenerateJoinedBeforeList(int Max_Num) {
            DateTime dateJoinedBefore = new DateTime();
            DateTime endDate = new DateTime(2014, 1, 1);
            DateTime startDate = new DateTime(1985, 1, 1);
            dateJoinedBefore = GetCustomizedDate(startDate, endDate);
            return dateJoinedBefore;
        }

        public static DateTime GenerateJoinedBetweenList() {
            DateTime dateJoinedBetween = new DateTime();
            DateTime startDate = new DateTime(2013, 5, 1);
            DateTime endDate = new DateTime(2013, 12, 25);
            dateJoinedBetween = GetCustomizedDate(startDate, endDate);
            return dateJoinedBetween;
        }

        public static DateTime GenerateJoinedAfterList() {
            DateTime dateJoinedAfter = new DateTime();
            DateTime startDate = new DateTime(2014, 6, 6);
            DateTime endDate = new DateTime(DateTime.Now.Ticks);
            dateJoinedAfter = GetCustomizedDate(startDate, endDate);
            return dateJoinedAfter;
        }

        public static DateTime GenerateExitedBeforeList() {
            DateTime dateExitedBefore = new DateTime();
            DateTime endDate = new DateTime(2014, 5, 20);
            DateTime startDate = new DateTime(1985, 1, 1);
            dateExitedBefore = (GetCustomizedDate(startDate, endDate));
            return dateExitedBefore;
        }

        public static object executeQuery(string procedureName, SqlCommand command, string ConnectionParameter) {
            object result = null;
            SqlConnection conn = new SqlConnection(ConnectionParameter);
            conn = UsersBackEnd.GetSqlConnection();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procedureName;
            result = command.ExecuteScalar();
            return result;
        }

        public static void PopulateDB() {
            InsertSeniorUsers(20);
            InsertUserBeforeDate(20);
            InsertUserJoinedBetweenDate(20);
            InsertUserJoinedAfterDate(20);
            InsertUserExitedBeforeDate(20);
        }

        private static void InsertSeniorUsers(int usersNumber) {
            int insertedUsers = 0;
            for (int i = 0; insertedUsers <= usersNumber; i++) {
                DateTime joinDate = GetCustomizedDate(MIN_DATE, MAX_DATE);
                DateTime exitDate = GetCustomizedDate(MIN_DATE, MAX_DATE);
                TimeSpan dateDifference = exitDate - joinDate;
                if (exitDate > joinDate && (dateDifference.Days >= (356 * 3))) {//senior
                    RandomUserObject randomObject = GenerateRandomUserObject(joinDate, exitDate);
                    SqlCommand command = new SqlCommand();
                    command.Parameters.AddWithValue("@JoinDate", randomObject.JoinDate);
                    command.Parameters.AddWithValue("@ExitDate", randomObject.ExitDate);
                    command.Parameters.AddWithValue("@Username", randomObject.Username);
                    var result = executeQuery("CompanySystemUsers_PopulateDatabase", command, UsersBackEnd.ConnectionParameter);
                    insertedUsers++;
                }
            }
        }

        private static void InsertUserBeforeDate(int usersNumber) {
            int insertedUsers = 0;
            DateTime upperBound = new DateTime(2014, 1, 1);
            DateTime lowerBound = new DateTime(1950, 1, 1);
            for (int i = 0; insertedUsers <= usersNumber; i++) {
                DateTime joinedDate = GetCustomizedDate(lowerBound, upperBound);
                DateTime exitedDate = GetCustomizedDate(upperBound, DateTime.Now);
                insertedUsers = InsertUserObject(insertedUsers, joinedDate, exitedDate);
            }
        }

        private static int InsertUserObject(int insertedUsers, DateTime joinedDate, DateTime exitedDate) {
            RandomUserObject randomObject = GenerateRandomUserObject(joinedDate, exitedDate);
            SqlCommand command = new SqlCommand();
            command.Parameters.AddWithValue("@JoinDate", randomObject.JoinDate);
            command.Parameters.AddWithValue("@ExitDate", randomObject.ExitDate);
            command.Parameters.AddWithValue("@Username", randomObject.Username);
            var result = executeQuery("CompanySystemUsers_PopulateDatabase", command, UsersBackEnd.ConnectionParameter);
            insertedUsers++;
            return insertedUsers;
        }

        private static void InsertUserJoinedBetweenDate(int usersNumber) {
            int insertedUsers = 0;
            for (int i = 0; insertedUsers <= usersNumber; i++) {
                DateTime joinDate = GetCustomizedDate(new DateTime(2013, 1, 5), new DateTime(2013, 12, 25));
                DateTime exitDate = GetCustomizedDate(new DateTime(2013, 1, 5), new DateTime(2013, 12, 25));
                if (exitDate > joinDate) {
                    insertedUsers = InsertUserObject(insertedUsers, joinDate, exitDate);
                }
            }
        }

        private static void InsertUserJoinedAfterDate(int usersNumber) {
            int insertedUsers = 0;
            for (int i = 0; insertedUsers <= usersNumber; i++) {
                DateTime MIN_CUSTOMIZED_JOINEDAFTER = new DateTime(2014, 6, 6);
                DateTime joinDate = GetCustomizedDate(MIN_CUSTOMIZED_JOINEDAFTER, MAX_DATE);
                DateTime exitDate = GetCustomizedDate(MIN_CUSTOMIZED_JOINEDAFTER, MAX_DATE);
                if (exitDate > joinDate) {
                    insertedUsers = InsertUserObject(insertedUsers, joinDate, exitDate);
                }
            }
        }

        private static void InsertUserExitedBeforeDate(int usersNumber) {
            int insertedUsers = 0;
            for (int i = 0; insertedUsers <= usersNumber; i++) {
                DateTime joinDate = GetCustomizedDate(MIN_DATE, new DateTime(2014, 5, 20));
                DateTime exitDate = GetCustomizedDate(MIN_DATE, new DateTime(2014, 5, 20));
                if (exitDate > joinDate) {
                    insertedUsers = InsertUserObject(insertedUsers, joinDate, exitDate);
                }
            }
        }

        #endregion
    }
}


