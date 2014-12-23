using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;

namespace ThirdExercise {
    #region Enum

    public enum QueryMode {
        ExecuteScalar = 0,
        ExecuteReader = 1,
        ExecuteNonQuery = 2,
        ExecuteDataReader = 3
    }

    #endregion
    
    public class UsersBackEnd {
        #region Variables
        
        public static string ConnectionParameter = "";

        #endregion
        
        #region Establish Database Connection

             public static SqlConnection GetSqlConnection() {
            SqlConnection sqlConnection = new SqlConnection(ConnectionParameter);
            try {
                sqlConnection.Open();
            } catch (Exception ex) {
                MessageBox.Show("Connection Failed!", ex.Message);
            }
            return sqlConnection;
        }

             public static SqlConnection GetSqlConnection(string connectionParameter) {
            SqlConnection sqlConnection = new SqlConnection(connectionParameter);
            try {
                sqlConnection.Open();
            } catch (Exception ex) {
                MessageBox.Show("Connection Failed!", ex.Message);
            }
            return sqlConnection;
        }

        #endregion
   
        #region Methods
        
        public static void InsertUsers(List<UserObject> parsedUsers) {
            foreach (UserObject userObject in parsedUsers) {
                InsertIndividualUser(userObject);
            }
        }

        private static void InsertIndividualUser(UserObject userObject) {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@Username", userObject.username);
            cmd.Parameters.AddWithValue("@Password", userObject.password);
            cmd.Parameters.AddWithValue("@Email", userObject.email);
            int userId = Convert.ToInt32(ExecuteQuery("Users_InsertUserInfo", QueryMode.ExecuteScalar, cmd,true));
            userObject.Id = userId;
            InsertUserDetails(userId, userObject.userDetails);
        }

        private static void InsertUserDetails(int userId, List<UserDetail> userDetails) {
            foreach (UserDetail userDetail in userDetails) {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@Type", (int)userDetail.userDetailType);
                command.Parameters.AddWithValue("@userId", userId);
                int userDetailsId = Convert.ToInt32(ExecuteQuery("Users_InsertDetails", QueryMode.ExecuteScalar, command, true));
                InsertIndividualUserDetail(userDetailsId, userDetail.UserDetailParameters);
            }
        }

        private static void InsertIndividualUserDetail(int userDetailsId, List<DetailParameter> detailParameter) {
            foreach (DetailParameter eachDetailParameter in detailParameter) {
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@userDetailsId", userDetailsId);
                command.Parameters.AddWithValue("@Name", eachDetailParameter.Name);
                command.Parameters.AddWithValue("@Value", eachDetailParameter.Value);
                int userDetailID = Convert.ToInt32(ExecuteQuery("Users_InsertDetail", QueryMode.ExecuteScalar, command, true));
            }
        }

       private static object GetObjectFromReader(SqlDataReader reader) {
            //object result = null;
            List<object[]> objectsList = new List<object[]>();
            while (reader.Read()) {
                object[] readerResults = new object[reader.FieldCount];
                reader.GetValues(readerResults);
                objectsList.Add(readerResults);
            }
            return objectsList;
        }

        private static object ExecuteQuery(string procedureName, QueryMode mode, SqlCommand command, bool isStoredProcedure) {
            object result = null;
            SqlConnection conn = GetSqlConnection();
            command.Connection = conn;
            if (isStoredProcedure) {
                command.CommandType = CommandType.StoredProcedure;
            }
            command.CommandText = procedureName;
            
            try {
                switch (mode) {
                    // typically used when your query returns a single value
                    case QueryMode.ExecuteScalar:
                        result = command.ExecuteScalar();
                        break;
                    // typically used for any result set with multiple rows/columns e.g: Select
                    case QueryMode.ExecuteReader:
                        SqlDataReader reader = command.ExecuteReader();
                        result = GetObjectFromReader(reader);
                        break;
                    // typically used for SQL statements without results e.g: Update, Insert, Delete
                    case QueryMode.ExecuteNonQuery:
                        result = command.ExecuteNonQuery();
                        break;
                    case QueryMode.ExecuteDataReader:
                        result = FillDataSet(command);
                        break;
                }
            } catch (Exception ex) {
                MessageBox.Show("Exception is" + ex);
            } finally {
                if (conn != null) {
                    conn.Close();
                }
            }

            return result;
        }

        private static DataSet FillDataSet(SqlCommand command) {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet resultsDataSet = new DataSet();
            try {
                sqlDataAdapter.Fill(resultsDataSet);
            } catch (SqlException ex) {
                MessageBox.Show("Please enter a valid SQL query." + ex.Message);
            } catch (InvalidOperationException ex) {
                MessageBox.Show("Please enter a valid SQL query." + ex.Message);
            }
            return resultsDataSet;
        }

        #endregion

    }
}
