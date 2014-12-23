using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Web;
using System.Net;

namespace ThirdExercise {
    public partial class Form1 : Form {
        #region Constructor

        public Form1() {
            InitializeComponent();
        }

        #endregion

        #region Variables
        XDocument doc = null;
        List<XElement> SELECTED_USERS = null;
        #endregion

        #region Loading and validating the XML file

        private bool IsValidToLoadFile(string inputFilePath) {
            if (!File.Exists(inputFilePath)) {
                MessageBox.Show("Input File does not exist!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void btnBrowse_Click(object sender, EventArgs e) {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                txtInputFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e) {
            try {
                string inputFilePath = txtInputFile.Text.Trim();
                if (IsValidToLoadFile(inputFilePath)) {
                    doc = XDocument.Load(inputFilePath);
                    MessageBox.Show("The file is a valid XML file");
                }
            } catch (IOException) {
                MessageBox.Show("Please enter a valid XML file.");
            } catch (XmlException) {
                MessageBox.Show("Please enter a valid XML file.");
            } catch (ArgumentException) {
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e) {
            try {
                if (IsValidToLoadFile(txtInputFile.Text.Trim())) {
                    this.dgvResults2.SelectedIndex = 2;
                    StoreXmlAsString();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        private void btnPopulateDatabase_Click(object sender, EventArgs e) {
            try {
                UsersBackEnd.ConnectionParameter = txtDbConnection.Text.Trim();
                RandomPopulate.PopulateDB();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        private void StoreXmlAsString() {
            List<UserObject> usersList = GetUsersList();
            foreach (UserObject user in usersList) {
                string userText = user.GetTextRepresentation();
                txtDisplayResults.AppendText(userText);
            }
        }

        private void btnDgv_Click_1(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 1;
            PopulateDGVFromDatabase();
        }

        private void btnOuputFile_Click(object sender, EventArgs e) {
            CreateExcelWorkSheetFromDataGridView();
        }

        private void ExecuteCustomUserQuery(string QueryMode) {

            switch (QueryMode) {
                case "ExecuteDataReader":
                    this.dgvResults2.SelectedIndex = 0;
                    string sqlQuery = txtQueryEntry.Text.Trim();
                    DataSet ds = FillDataSet(sqlQuery, UsersBackEnd.GetSqlConnection(txtDbConnection.Text.Trim()));
                    if (ds != null) {
                        dgvQueryResults.DataSource = ds.Tables[0];
                    }
                    break;
                case "ExecuteScalar":
                    sqlQuery = txtQueryEntry.Text.Trim();
                    object dataDisplay = SqlQueryScalar(sqlQuery, UsersBackEnd.GetSqlConnection(txtDbConnection.Text.Trim()));
                    if (dataDisplay != null) {
                        txtDisplayResults.Text = dataDisplay.ToString();
                        DisplayResults(dataDisplay.ToString());
                    }
                    break;
                case "ExecuteReader":
                    this.dgvResults2.SelectedIndex = 0;
                    sqlQuery = txtQueryEntry.Text.Trim();
                    ds = FillDataSet(sqlQuery, UsersBackEnd.GetSqlConnection(txtDbConnection.Text.Trim()));
                    if (ds != null) {
                        dgvQueryResults.DataSource = ds.Tables[0];
                    }
                    break;
                case "ExecuteNonQuery":
                    sqlQuery = txtQueryEntry.Text.Trim() + " SELECT SCOPE_IDENTITY()";
                    dataDisplay = SqlQueryScalar(sqlQuery, UsersBackEnd.GetSqlConnection(txtDbConnection.Text.Trim()));
                    if (dataDisplay != null) {
                        txtDisplayResults.Text = dataDisplay.ToString();
                        DisplayResults(dataDisplay.ToString());
                    }
                    break;
            }
        }

        private object SqlQueryScalar(string sqlQuery, SqlConnection conn) {
            SqlCommand command = new SqlCommand(sqlQuery);            
            command.Connection = conn;
            object result = null;
            try {
                result = command.ExecuteScalar();
            } catch (SqlException ex) {
                MessageBox.Show("Please enter a valid SQL query." + ex.Message);
            } catch (InvalidOperationException ex) {
                MessageBox.Show("Please enter a valid SQL query." + ex.Message);
            }
            return result;
        }

        private void btnExecuteQuery_Click(object sender, EventArgs e) {
            try {
                if (cboQueryTypes.SelectedValue.ToString() == "ExecuteDataReader") {
                    ExecuteCustomUserQuery("ExecuteDataReader");
                } else if (cboQueryTypes.SelectedValue.ToString() == "ExecuteScalar") {
                    ExecuteCustomUserQuery("ExecuteScalar");
                } else if (cboQueryTypes.SelectedValue.ToString() == "ExecuteReader") {
                    ExecuteCustomUserQuery("ExecuteReader");
                } else if (cboQueryTypes.SelectedValue.ToString() == "ExecuteNonQuery") {
                    ExecuteCustomUserQuery("ExecuteNonQuery");
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            cboQueryTypes.DataSource = Enum.GetValues(typeof(QueryMode));
        }

        private void btnGetRedHeads_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string listofRedHeads = XmlParserRedHair();
                DisplayResults(listofRedHeads);
            }
        }

        private void btnGetShorterThan190_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string UsersShorterThan190 = XmlShorterThan190();
                DisplayResults(UsersShorterThan190);
            }
        }

        private void btnGetWeightBetween_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string UsersWeighingBtw55and100 = XmlWeighingBetween55and100();
                DisplayResults(UsersWeighingBtw55and100);
            }
        }

        private void btnGetEmployedUsers_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string UsersEmployed = XmlUserIsEmployed();
                DisplayResults(UsersEmployed);
            }
        }

        private void btnGetUnemployedUsers_Click(object sender, EventArgs e) {
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                this.dgvResults2.SelectedIndex = 2;
                string UsersUnemployed = XmlUserIsUnemployed();
                DisplayResults(UsersUnemployed);
            }
        }

        private void btnGetMostPaidUser_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string userName = "";
                int salary = -1;
                XmlMostPaidUser(out userName, out salary);
                DisplayResults("Most Paid User: \n" + userName + "\n\n");
            }
        }

        private void btnGetMissingFinancialDetail_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string missingFinancialDetail = "";
                XmlUserMissingFinancialDetail(out missingFinancialDetail);               
                DisplayResults("Users with missing Financial Detail: " + missingFinancialDetail + "\n\n");
            }
        }

        private void btnGetTallestUser_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string userName = "";
                int length = -1;
                XmlTallestUser(out userName, out length);
                DisplayResults("Tallest User: \n" + userName + "\n\n");
            }
        }

        private void btnGetMissingPhysicalDetail_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string missingPhysicalDetail = "";
                XmlUserMissingPhysicalDetail(out missingPhysicalDetail);
                DisplayResults("Users with missing Physical Detail: \n" + missingPhysicalDetail + "\n\n");
            }
        }

        private void btnGetUsersWithSimilarAccountNumbers_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string usersWithSimilarAccounts = "";
                XMLUsersWithSimilarAccountNumbers(out usersWithSimilarAccounts);
                DisplayResults(usersWithSimilarAccounts);
            }
        }

        private void btnGetUsersOrderedBySalary_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string exportAsText = "";
                XMLUsersOrderedBySalaries(out exportAsText);
                DisplayResults("Users oreder by descending order or salaries: " + Environment.NewLine + Environment.NewLine + exportAsText);
            }
        }

        private void btnGetUnemployedReceivingSalaries_Click(object sender, EventArgs e) {
            this.dgvResults2.SelectedIndex = 2;
            SelectUsersFromDocument();
            if (SELECTED_USERS != null) {
                string outputSkeleton = "";
                XmlUnEmployedAndPaid(out outputSkeleton);
                DisplayResults(outputSkeleton);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e) {
            SendMail sendingTest = new SendMail();
            sendingTest.sendEmail();
        }

        #endregion

        #region Methods

        #region XML Parsing

        private List<UserObject> GetUsersList() {
            List<UserObject> users = new List<UserObject>();
            if (doc == null) {
                doc = XDocument.Load(txtInputFile.Text.Trim());
            }
            var usersList = from q in doc.Descendants("User")
                            select q;

            foreach (XElement userElement in usersList) {
                UserObject user = GetUserObject(userElement);
                users.Add(user);
            }
            return users;
        }

        private UserObject GetUserObject(XElement userElement) {
            string username = userElement.Element("Username") == null ? "" : userElement.Element("Username").Value;
            string password = userElement.Element("Password") == null ? "" : userElement.Element("Password").Value;
            string email = userElement.Element("Email") == null ? "" : userElement.Element("Email").Value;

            UserObject userObject = new UserObject(username, password, email);
            userObject.userDetails = GetDetails(userElement.Element("Details"));
            return userObject;
        }

        private List<UserDetail> GetDetails(XElement xElement) {
            List<UserDetail> userDetails = new List<UserDetail>();
            foreach (XElement detailElement in xElement.Elements("Detail")) {
                UserDetail detail = GetUserDetail(detailElement);
                userDetails.Add(detail);
            }
            return userDetails;
        }

        private UserDetail GetUserDetail(XElement detailElement) {
            UserDetail detail = new UserDetail();
            string detailType = detailElement.Attribute("Type").Value;
            detail.userDetailType = (UserDetail.DetailType)Enum.Parse(typeof(UserDetail.DetailType), detailType);
            detail.UserDetailParameters = GetDetailParameters(detailElement.Elements("Param"));

            return detail;
        }

        private List<DetailParameter> GetDetailParameters(IEnumerable<XElement> paramElements) {
            List<string> usersWithRedHair = new List<string>();
            List<DetailParameter> detailParams = new List<DetailParameter>();
            foreach (XElement paramElement in paramElements) {
                detailParams.Add(new DetailParameter(paramElement.Attribute("name").Value, paramElement.Attribute("value").Value));
            }
            return detailParams;
        }

        #endregion

        #region Connection to Database

        private void btnConnectDB_Click(object sender, EventArgs e) {
            try {
                string connectionString = txtDbConnection.Text.Trim();
                if (IsValidToTestConnection(connectionString)) {
                    TestConnection(connectionString);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(), ex.Message);
            }
        }

        private void TestConnection(string connectionString) {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try {
                sqlConnection.Open();
            } catch (Exception ex) {

                MessageBox.Show("Connection Failed!", ex.Message);
            } finally {
                if (sqlConnection != null) {
                    sqlConnection.Close();
                }
            }
        }

        private bool IsValidToTestConnection(string connectionString) {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection == null) {
                MessageBox.Show("Error");
                return false;
            }
            return true;
        }

        #endregion

        private string XmlParserRedHair() {
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }

            var result = from redHead in SELECTED_USERS
                         where UserIsRedhead(redHead.Descendants("Param"))
                         select redHead;
            string userElementsWithRedHair = null;
            foreach (XElement userElement in result) {
                userElementsWithRedHair += (userElement.Element("Username").Value) + Environment.NewLine;
            }
            DisplayResults("Red Head Users: \r\n" + userElementsWithRedHair + "\n");
            return "Red Head Users: \r\n" + userElementsWithRedHair + "\n";
        }

        private bool UserIsRedhead(IEnumerable<XElement> paramsList) {
            bool result = false;

            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "HairColor") {
                    if (parameter.Attribute("value").Value == "Red") {
                        return true;
                    }
                }
            }
            return result;
        }

        private string XmlShorterThan190() {
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }

            var result = from shorterThan in SELECTED_USERS
                         where UserIsShorterThan190(shorterThan.Descendants("Param"))
                         select shorterThan;
            string userElementsShorterThan190 = null;
            foreach (XElement userElement in result) {
                userElementsShorterThan190 += (userElement.Element("Username").Value) + Environment.NewLine;
            }
             return "Users shorter than 190: \r\n" + userElementsShorterThan190 + "\n";
        }

        private bool UserIsShorterThan190(IEnumerable<XElement> paramsList) {
            bool result = false;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Length") {
                    if (Int32.Parse(parameter.Attribute("value").Value) < 190) {
                        return true;
                    }
                }
            }
            return result;
        }

        private string XmlUserIsEmployed() {
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            var result = from isEmployed in SELECTED_USERS
                         where UserIsEmployed(isEmployed.Descendants("Param"))
                         select isEmployed;
            string userElementsAreEmployed = null;
            foreach (XElement userElement in result) {
                userElementsAreEmployed += (userElement.Element("Username").Value) + Environment.NewLine;
            }
            DisplayResults("Employed Users: \r\n" + userElementsAreEmployed + "\n");
            return "Employed Users: \r\n" + userElementsAreEmployed + "\n";
        }

        private bool UserIsEmployed(IEnumerable<XElement> paramsList) {
            bool result = false;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Status") {
                    if (parameter.Attribute("value").Value == "Employed" || parameter.Attribute("value").Value == "employed") {
                        return true;
                    }
                }
            }
            return result;
        }

        private string XmlUserIsUnemployed() {
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            var result = from isEmployed in SELECTED_USERS
                         where UserIsUnemployed(isEmployed.Descendants("Param"))
                         select isEmployed;
            string userElementsAreUnEmployed = null;
            foreach (XElement userElement in result) {
                userElementsAreUnEmployed += (userElement.Element("Username").Value) + Environment.NewLine;
            }
            DisplayResults("Unemployed Users: \r\n" + userElementsAreUnEmployed + "\n");
            return "Unemployed Users: \r\n" + userElementsAreUnEmployed + "\n";
        }

        private bool UserIsUnemployed(IEnumerable<XElement> paramsList) {
            bool result = false;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Status") {
                    if (string.Equals(parameter.Attribute("value").Value, "UnEmployed", StringComparison.InvariantCultureIgnoreCase)) {
                        return true;
                    }
                }
            }
            return result;
        }

        private void XmlUserMissingFinancialDetail(out string missingFinancialDetail) {
            missingFinancialDetail = "";
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            foreach (XElement user in SELECTED_USERS) {
                bool exists = false;
                string username = user.Element("Username").Value;
                UserMissingFinancialType(user.Descendants("Detail"), out exists);
                if (!exists) {
                    missingFinancialDetail += Environment.NewLine + username;
                }
            }
        }

        private void UserMissingFinancialType(IEnumerable<XElement> detailList, out bool exists) {
            exists = false;
            foreach (XElement detail in detailList) {
                if (detail.Attribute("Type").Value == "FinancialDetail") {
                    exists = true;
                }
            }
        }

        private void XmlUserMissingPhysicalDetail(out string missingPhysicalDetail) {
            missingPhysicalDetail = "";
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            foreach (XElement user in SELECTED_USERS) {
                bool exists = false;
                string username = user.Element("Username").Value;
                UserMissingPhysicalType(user.Descendants("Detail"), out exists);
                if (!exists) {
                    missingPhysicalDetail += Environment.NewLine + username;
                }
            }
        }

        private void UserMissingPhysicalType(IEnumerable<XElement> detailList, out bool exists) {
            exists = false;
            foreach (XElement detail in detailList) {
                if (detail.Attribute("Type").Value == "PhysicalDetail") {
                    exists = true;
                }
            }
        }

        private void XmlMostPaidUser(out string maxSalaryUsername, out int maxSalary) {
            maxSalary = -1;
            maxSalaryUsername = "";
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            foreach (XElement user in SELECTED_USERS) {
                int userSalary = -1;
                string username = user.Element("Username").Value;
                MostPaidUser(user.Descendants("Param"), out userSalary);
                if (userSalary > maxSalary) {
                    maxSalary = userSalary;
                    maxSalaryUsername = username;
                }
            }
        }

        private void MostPaidUser(IEnumerable<XElement> paramsList, out int salary) {
            salary = -1;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Salary") {
                    if (!string.IsNullOrEmpty(parameter.Attribute("value").Value)) {
                        salary = Int32.Parse(parameter.Attribute("value").Value);
                    }
                }
            }
        }

        private void XmlUnEmployedAndPaid(out string outputSkeleton) {
            outputSkeleton = "List of unemployed users who are receiveing salaries:\n" + Environment.NewLine;
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            foreach (XElement user in SELECTED_USERS) {
                string username = user.Element("Username").Value;
                if (UnEmployedAndPaid(user.Descendants("Param"))) {
                    outputSkeleton = outputSkeleton + username + "\r\n";
                }
            }
            txtDisplayResults.AppendText(outputSkeleton);
        }

        private bool UnEmployedAndPaid(IEnumerable<XElement> paramsList) {
            string salary = "";
            string status = "";
            bool isUserUnEmployedAndPaid = false;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Salary") {
                    salary = parameter.Attribute("value").Value;
                }
                if (parameter.Attribute("name").Value == "Status") {
                    status = parameter.Attribute("value").Value;
                }
                if (!string.IsNullOrEmpty(salary) && string.Equals(status, "unemployed", StringComparison.InvariantCultureIgnoreCase)) {
                    isUserUnEmployedAndPaid = true;
                    return isUserUnEmployedAndPaid;
                }
            }
            return isUserUnEmployedAndPaid;
        }

        private string XmlWeighingBetween55and100() {
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            var result = from userWeights in SELECTED_USERS
                         where UserWeighsBetween55and100(userWeights.Descendants("Param"))
                         select userWeights;
            string userElementsWeighingBetween55and100 = null;
            foreach (XElement userElement in result) {
                userElementsWeighingBetween55and100 += (userElement.Element("Username").Value) + Environment.NewLine;
            }
            DisplayResults("Users weighing between 55 and 100: \r\n" + userElementsWeighingBetween55and100 + "\n");
            return "Users weighing between 55 and 100: \r\n" + userElementsWeighingBetween55and100 + "\n";
        }

        private bool UserWeighsBetween55and100(IEnumerable<XElement> paramsList) {
            bool result = false;
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Weight") {
                    if ((parameter.Attribute("value").Value) != null) {
                        if ((Convert.ToDouble(parameter.Attribute("value").Value) > 55) && (Convert.ToDouble(parameter.Attribute("value").Value) < 100)) {
                            return true;
                        }
                    }
                }
            }
            return result;
        }

        private void XmlTallestUser(out string maxLengthUsername, out int maxLength) {
            maxLength = -1;
            maxLengthUsername = "";
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            foreach (XElement user in SELECTED_USERS) {
                int userLength = -1;
                string username = user.Element("Username").Value;
                TallestUser(user.Descendants("Param"), out userLength);
                if (userLength > maxLength) {
                    maxLength = userLength;
                    maxLengthUsername = username;
                }
            }
        }

        private void TallestUser(IEnumerable<XElement> paramsList, out int length) {
            length = -1;

            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Length") {
                    if (!string.IsNullOrEmpty(parameter.Attribute("value").Value)) {
                        length = Int32.Parse(parameter.Attribute("value").Value);
                    }
                }
            }
        }

        private void XMLUsersWithSimilarAccountNumbers(out string usersWithSimilarAccounts) {

            usersWithSimilarAccounts = "";

            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }
            Dictionary<string, string> similarAccountNumbersDictionary = new Dictionary<string, string>();
            foreach (XElement user in SELECTED_USERS) {
                string username = user.Element("Username").Value;
                similarAccountNumbersDictionary = SimilarAccountNumbers(user.Descendants("Param"), username, similarAccountNumbersDictionary);
            }

            foreach (string key in similarAccountNumbersDictionary.Keys) {              
                usersWithSimilarAccounts = usersWithSimilarAccounts + "Users account numbers starting with " + key + ": \n" + similarAccountNumbersDictionary[key] + "\n\n ";
                usersWithSimilarAccounts = usersWithSimilarAccounts + Environment.NewLine;
            }
        }

        private Dictionary<string, string> SimilarAccountNumbers(IEnumerable<XElement> paramsList, string username, Dictionary<string, string> similarAccountNumbersDictionary) {
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "AccountNumber") {
                    string firstThreeDigits = parameter.Attribute("value").Value.Substring(0, 3);
                    if (similarAccountNumbersDictionary.ContainsKey(firstThreeDigits)) {
                        similarAccountNumbersDictionary[firstThreeDigits] = similarAccountNumbersDictionary[firstThreeDigits] + "\n " + username;
                    } else {
                        similarAccountNumbersDictionary.Add(firstThreeDigits, username);

                    }
                }
            }
            return similarAccountNumbersDictionary;
        }

        private void XMLUsersOrderedBySalaries(out string exportAsText) {
            exportAsText = "";
            if (SELECTED_USERS == null) {
                SelectUsersFromDocument();
            }

            Dictionary<int, string> orderedBySalary = new Dictionary<int, string>();
            foreach (XElement user in SELECTED_USERS) {
                string username = user.Element("Username").Value;
                orderedBySalary = UsersOrderedBySalary(user.Descendants("Param"), username, orderedBySalary);
            }

            var list = orderedBySalary.Keys.ToList();
            var newList = list.OrderByDescending(a => a);

            txtDisplayResults.AppendText("Users ordered by descending order according to salary: \n\n");

            foreach (var key in newList) {
                txtDisplayResults.AppendText(orderedBySalary[key] + ":" + key + "\n");
                exportAsText = exportAsText + orderedBySalary[key] + ":" + key + Environment.NewLine;
            }
            txtDisplayResults.AppendText(Environment.NewLine);
        }

        private Dictionary<int, string> UsersOrderedBySalary(IEnumerable<XElement> paramsList, string username, Dictionary<int, string> orderedBySalary) {
            foreach (XElement parameter in paramsList) {
                if (parameter.Attribute("name").Value == "Salary") {
                    int salary = Int32.Parse(parameter.Attribute("value").Value);
                    if (orderedBySalary.ContainsKey(salary)) {
                        orderedBySalary[salary] = orderedBySalary[salary] + "," + username;
                    } else {
                        orderedBySalary.Add(salary, username);
                    }
                }
            }
            return orderedBySalary;
        }

        private DataSet FillDataSet(string sqlQuery, SqlConnection conn) {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, conn);
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

        private void PopulateDGVFromDatabase() {
            DataSet ds = FillDataSet("SELECT * FROM CompanySystemUsers", UsersBackEnd.GetSqlConnection(txtDbConnection.Text.Trim()));
            dgvResults.DataSource = ds.Tables[0];
            MessageBox.Show("GridViewCreated");
        }

        private void CreateExcelWorkSheetFromDataGridView() {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < dgvResults.Columns.Count + 1; i++) {
                worksheet.Cells[1, i] = dgvResults.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dgvResults.Rows.Count - 1; i++) {
                for (int j = 0; j < dgvResults.Columns.Count; j++) {
                    worksheet.Cells[i + 2, j + 1] = dgvResults.Rows[i].Cells[j].Value.ToString();
                }
            }
            string fileName = String.Empty;
            saveFileDialog1.Filter = "Excel files |*.xls|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                fileName = saveFileDialog1.FileName;

                workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                MessageBox.Show("File successfuly created in: " + fileName);
                app.Quit();
            } else {
                return;
            }
        }

        private void releaseObject(object obj) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            } catch (Exception ex) {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            } finally {
                GC.Collect();
            }
        }

        private void SelectUsersFromDocument() {
            try {
                var xmlStr = File.ReadAllText(txtInputFile.Text.Trim());
                var str = XElement.Parse(xmlStr);
                SELECTED_USERS = str.Descendants("User").ToList();
            } catch (ArgumentException ex) {
                MessageBox.Show("Error is: " + ex.Message);
            }
        }

        private void DisplayResults(string exportAsText) {
            if (cbSendUserParamAsText.Checked || cbSendQueryResultAsText.Checked) {
                System.IO.StreamWriter file = new System.IO.StreamWriter("goodlife.txt");
                file.WriteLine(exportAsText);
                file.Close();
            }
            txtDisplayResults.AppendText(exportAsText);
        }

        #endregion

    }
}
