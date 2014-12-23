namespace ThirdExercise {
    partial class Form1 {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSendQueryResultAsText = new System.Windows.Forms.CheckBox();
            this.cboQueryTypes = new System.Windows.Forms.ComboBox();
            this.btnDgv = new System.Windows.Forms.Button();
            this.btnOuputFile = new System.Windows.Forms.Button();
            this.btnExecuteQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQueryEntry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.btnPopulateDatabase = new System.Windows.Forms.Button();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.txtDbConnection = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgvResults2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvQueryResults = new System.Windows.Forms.DataGridView();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtDisplayResults = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGetRedHeads = new System.Windows.Forms.Button();
            this.btnGetWeightBetween = new System.Windows.Forms.Button();
            this.btnGetEmployedUsers = new System.Windows.Forms.Button();
            this.btnGetUnemployedUsers = new System.Windows.Forms.Button();
            this.btnGetMostPaidUser = new System.Windows.Forms.Button();
            this.btnGetTallestUser = new System.Windows.Forms.Button();
            this.btnGetMissingFinancialDetail = new System.Windows.Forms.Button();
            this.btnGetMissingPhysicalDetail = new System.Windows.Forms.Button();
            this.btnGetUsersWithSimilarAccountNumbers = new System.Windows.Forms.Button();
            this.btnGetUsersOrderedBySalary = new System.Windows.Forms.Button();
            this.btnGetUnemployedReceivingSalaries = new System.Windows.Forms.Button();
            this.btnGetShorterThan190 = new System.Windows.Forms.Button();
            this.cbSendUserParamAsText = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.dgvResults2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResults)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbSendQueryResultAsText);
            this.groupBox1.Controls.Add(this.cboQueryTypes);
            this.groupBox1.Controls.Add(this.btnDgv);
            this.groupBox1.Controls.Add(this.btnOuputFile);
            this.groupBox1.Controls.Add(this.btnExecuteQuery);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtQueryEntry);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDisplay);
            this.groupBox1.Controls.Add(this.btnPopulateDatabase);
            this.groupBox1.Controls.Add(this.btnConnectDB);
            this.groupBox1.Controls.Add(this.txtDbConnection);
            this.groupBox1.Controls.Add(this.btnValidate);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtInputFile);
            this.groupBox1.Controls.Add(this.lblInputFile);
            this.groupBox1.Location = new System.Drawing.Point(151, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 261);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert Data";
            // 
            // cbSendQueryResultAsText
            // 
            this.cbSendQueryResultAsText.AutoSize = true;
            this.cbSendQueryResultAsText.Location = new System.Drawing.Point(512, 233);
            this.cbSendQueryResultAsText.Name = "cbSendQueryResultAsText";
            this.cbSendQueryResultAsText.Size = new System.Drawing.Size(104, 17);
            this.cbSendQueryResultAsText.TabIndex = 22;
            this.cbSendQueryResultAsText.Text = "Export to text file";
            this.cbSendQueryResultAsText.UseVisualStyleBackColor = true;
            // 
            // cboQueryTypes
            // 
            this.cboQueryTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboQueryTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQueryTypes.FormattingEnabled = true;
            this.cboQueryTypes.Location = new System.Drawing.Point(17, 231);
            this.cboQueryTypes.Name = "cboQueryTypes";
            this.cboQueryTypes.Size = new System.Drawing.Size(121, 21);
            this.cboQueryTypes.TabIndex = 12;
            // 
            // btnDgv
            // 
            this.btnDgv.Location = new System.Drawing.Point(587, 70);
            this.btnDgv.Name = "btnDgv";
            this.btnDgv.Size = new System.Drawing.Size(139, 24);
            this.btnDgv.TabIndex = 11;
            this.btnDgv.Text = "Create DataGridView";
            this.btnDgv.UseVisualStyleBackColor = true;
            this.btnDgv.Click += new System.EventHandler(this.btnDgv_Click_1);
            // 
            // btnOuputFile
            // 
            this.btnOuputFile.Location = new System.Drawing.Point(442, 70);
            this.btnOuputFile.Name = "btnOuputFile";
            this.btnOuputFile.Size = new System.Drawing.Size(139, 24);
            this.btnOuputFile.TabIndex = 10;
            this.btnOuputFile.Text = "Create Output File";
            this.btnOuputFile.UseVisualStyleBackColor = true;
            this.btnOuputFile.Click += new System.EventHandler(this.btnOuputFile_Click);
            // 
            // btnExecuteQuery
            // 
            this.btnExecuteQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExecuteQuery.Location = new System.Drawing.Point(307, 231);
            this.btnExecuteQuery.Name = "btnExecuteQuery";
            this.btnExecuteQuery.Size = new System.Drawing.Size(139, 24);
            this.btnExecuteQuery.TabIndex = 9;
            this.btnExecuteQuery.Text = "Execute";
            this.btnExecuteQuery.UseVisualStyleBackColor = true;
            this.btnExecuteQuery.Click += new System.EventHandler(this.btnExecuteQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Query Text:";
            // 
            // txtQueryEntry
            // 
            this.txtQueryEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueryEntry.Location = new System.Drawing.Point(17, 127);
            this.txtQueryEntry.Multiline = true;
            this.txtQueryEntry.Name = "txtQueryEntry";
            this.txtQueryEntry.Size = new System.Drawing.Size(729, 98);
            this.txtQueryEntry.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Conn Param:";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(297, 70);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(139, 24);
            this.btnDisplay.TabIndex = 4;
            this.btnDisplay.Text = "Display Data";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnPopulateDatabase
            // 
            this.btnPopulateDatabase.Location = new System.Drawing.Point(152, 71);
            this.btnPopulateDatabase.Name = "btnPopulateDatabase";
            this.btnPopulateDatabase.Size = new System.Drawing.Size(139, 24);
            this.btnPopulateDatabase.TabIndex = 6;
            this.btnPopulateDatabase.Text = "Populate DB";
            this.btnPopulateDatabase.UseVisualStyleBackColor = true;
            this.btnPopulateDatabase.Click += new System.EventHandler(this.btnPopulateDatabase_Click);
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(7, 70);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(139, 24);
            this.btnConnectDB.TabIndex = 5;
            this.btnConnectDB.Text = "Connect";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // txtDbConnection
            // 
            this.txtDbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDbConnection.Location = new System.Drawing.Point(88, 45);
            this.txtDbConnection.Name = "txtDbConnection";
            this.txtDbConnection.Size = new System.Drawing.Size(513, 20);
            this.txtDbConnection.TabIndex = 4;
            this.txtDbConnection.Text = "user id=databaseAccess;password=databaseAccess123;Server=DRBOUSAMRA\\SQLEXPRESS;da" +
    "tabase=CompanyStorageDB;connection timeout=30";
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(607, 43);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(139, 24);
            this.btnValidate.TabIndex = 3;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(607, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(139, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(88, 19);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(513, 20);
            this.txtInputFile.TabIndex = 1;
            // 
            // lblInputFile
            // 
            this.lblInputFile.AutoSize = true;
            this.lblInputFile.Location = new System.Drawing.Point(13, 19);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(50, 13);
            this.lblInputFile.TabIndex = 0;
            this.lblInputFile.Text = "Input file:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dgvResults2
            // 
            this.dgvResults2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults2.Controls.Add(this.tabPage1);
            this.dgvResults2.Controls.Add(this.tabPage2);
            this.dgvResults2.Controls.Add(this.tabPage3);
            this.dgvResults2.Location = new System.Drawing.Point(151, 279);
            this.dgvResults2.Name = "dgvResults2";
            this.dgvResults2.SelectedIndex = 0;
            this.dgvResults2.Size = new System.Drawing.Size(765, 307);
            this.dgvResults2.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvQueryResults);
            this.tabPage1.Controls.Add(this.txtResults);
            this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Query Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvQueryResults
            // 
            this.dgvQueryResults.AllowUserToAddRows = false;
            this.dgvQueryResults.AllowUserToDeleteRows = false;
            this.dgvQueryResults.AllowUserToResizeColumns = false;
            this.dgvQueryResults.AllowUserToResizeRows = false;
            this.dgvQueryResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQueryResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueryResults.Location = new System.Drawing.Point(3, 3);
            this.dgvQueryResults.Name = "dgvQueryResults";
            this.dgvQueryResults.ReadOnly = true;
            this.dgvQueryResults.Size = new System.Drawing.Size(751, 275);
            this.dgvQueryResults.TabIndex = 3;
            // 
            // txtResults
            // 
            this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResults.Location = new System.Drawing.Point(3, 3);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(751, 275);
            this.txtResults.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvResults);
            this.tabPage2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DataGridView";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeColumns = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResults.Location = new System.Drawing.Point(3, 3);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(751, 275);
            this.dgvResults.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtDisplayResults);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(757, 281);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Display Result";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtDisplayResults
            // 
            this.txtDisplayResults.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtDisplayResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisplayResults.HideSelection = false;
            this.txtDisplayResults.Location = new System.Drawing.Point(3, 3);
            this.txtDisplayResults.Name = "txtDisplayResults";
            this.txtDisplayResults.ReadOnly = true;
            this.txtDisplayResults.Size = new System.Drawing.Size(751, 275);
            this.txtDisplayResults.TabIndex = 0;
            this.txtDisplayResults.Text = "";
            // 
            // btnGetRedHeads
            // 
            this.btnGetRedHeads.Location = new System.Drawing.Point(4, 20);
            this.btnGetRedHeads.Name = "btnGetRedHeads";
            this.btnGetRedHeads.Size = new System.Drawing.Size(141, 24);
            this.btnGetRedHeads.TabIndex = 8;
            this.btnGetRedHeads.Text = "Red Head Users";
            this.btnGetRedHeads.UseVisualStyleBackColor = true;
            this.btnGetRedHeads.Click += new System.EventHandler(this.btnGetRedHeads_Click);
            // 
            // btnGetWeightBetween
            // 
            this.btnGetWeightBetween.Location = new System.Drawing.Point(4, 79);
            this.btnGetWeightBetween.Name = "btnGetWeightBetween";
            this.btnGetWeightBetween.Size = new System.Drawing.Size(141, 24);
            this.btnGetWeightBetween.TabIndex = 9;
            this.btnGetWeightBetween.Text = "Weight btw 55 and 100";
            this.btnGetWeightBetween.UseVisualStyleBackColor = true;
            this.btnGetWeightBetween.Click += new System.EventHandler(this.btnGetWeightBetween_Click);
            // 
            // btnGetEmployedUsers
            // 
            this.btnGetEmployedUsers.Location = new System.Drawing.Point(4, 109);
            this.btnGetEmployedUsers.Name = "btnGetEmployedUsers";
            this.btnGetEmployedUsers.Size = new System.Drawing.Size(141, 24);
            this.btnGetEmployedUsers.TabIndex = 10;
            this.btnGetEmployedUsers.Text = "Employed Users";
            this.btnGetEmployedUsers.UseVisualStyleBackColor = true;
            this.btnGetEmployedUsers.Click += new System.EventHandler(this.btnGetEmployedUsers_Click);
            // 
            // btnGetUnemployedUsers
            // 
            this.btnGetUnemployedUsers.Location = new System.Drawing.Point(4, 139);
            this.btnGetUnemployedUsers.Name = "btnGetUnemployedUsers";
            this.btnGetUnemployedUsers.Size = new System.Drawing.Size(141, 24);
            this.btnGetUnemployedUsers.TabIndex = 11;
            this.btnGetUnemployedUsers.Text = "Unemployed Users";
            this.btnGetUnemployedUsers.UseVisualStyleBackColor = true;
            this.btnGetUnemployedUsers.Click += new System.EventHandler(this.btnGetUnemployedUsers_Click);
            // 
            // btnGetMostPaidUser
            // 
            this.btnGetMostPaidUser.Location = new System.Drawing.Point(4, 169);
            this.btnGetMostPaidUser.Name = "btnGetMostPaidUser";
            this.btnGetMostPaidUser.Size = new System.Drawing.Size(141, 24);
            this.btnGetMostPaidUser.TabIndex = 12;
            this.btnGetMostPaidUser.Text = "Most Paid User";
            this.btnGetMostPaidUser.UseVisualStyleBackColor = true;
            this.btnGetMostPaidUser.Click += new System.EventHandler(this.btnGetMostPaidUser_Click);
            // 
            // btnGetTallestUser
            // 
            this.btnGetTallestUser.Location = new System.Drawing.Point(4, 199);
            this.btnGetTallestUser.Name = "btnGetTallestUser";
            this.btnGetTallestUser.Size = new System.Drawing.Size(141, 24);
            this.btnGetTallestUser.TabIndex = 13;
            this.btnGetTallestUser.Text = "Tallest User";
            this.btnGetTallestUser.UseVisualStyleBackColor = true;
            this.btnGetTallestUser.Click += new System.EventHandler(this.btnGetTallestUser_Click);
            // 
            // btnGetMissingFinancialDetail
            // 
            this.btnGetMissingFinancialDetail.Location = new System.Drawing.Point(4, 229);
            this.btnGetMissingFinancialDetail.Name = "btnGetMissingFinancialDetail";
            this.btnGetMissingFinancialDetail.Size = new System.Drawing.Size(141, 24);
            this.btnGetMissingFinancialDetail.TabIndex = 14;
            this.btnGetMissingFinancialDetail.Text = "Missing Financial Detail";
            this.btnGetMissingFinancialDetail.UseVisualStyleBackColor = true;
            this.btnGetMissingFinancialDetail.Click += new System.EventHandler(this.btnGetMissingFinancialDetail_Click);
            // 
            // btnGetMissingPhysicalDetail
            // 
            this.btnGetMissingPhysicalDetail.Location = new System.Drawing.Point(4, 259);
            this.btnGetMissingPhysicalDetail.Name = "btnGetMissingPhysicalDetail";
            this.btnGetMissingPhysicalDetail.Size = new System.Drawing.Size(141, 24);
            this.btnGetMissingPhysicalDetail.TabIndex = 15;
            this.btnGetMissingPhysicalDetail.Text = "Missing Physical Detail";
            this.btnGetMissingPhysicalDetail.UseVisualStyleBackColor = true;
            this.btnGetMissingPhysicalDetail.Click += new System.EventHandler(this.btnGetMissingPhysicalDetail_Click);
            // 
            // btnGetUsersWithSimilarAccountNumbers
            // 
            this.btnGetUsersWithSimilarAccountNumbers.Location = new System.Drawing.Point(4, 289);
            this.btnGetUsersWithSimilarAccountNumbers.Name = "btnGetUsersWithSimilarAccountNumbers";
            this.btnGetUsersWithSimilarAccountNumbers.Size = new System.Drawing.Size(141, 24);
            this.btnGetUsersWithSimilarAccountNumbers.TabIndex = 16;
            this.btnGetUsersWithSimilarAccountNumbers.Text = "Similar account numbers";
            this.btnGetUsersWithSimilarAccountNumbers.UseVisualStyleBackColor = true;
            this.btnGetUsersWithSimilarAccountNumbers.Click += new System.EventHandler(this.btnGetUsersWithSimilarAccountNumbers_Click);
            // 
            // btnGetUsersOrderedBySalary
            // 
            this.btnGetUsersOrderedBySalary.Location = new System.Drawing.Point(4, 319);
            this.btnGetUsersOrderedBySalary.Name = "btnGetUsersOrderedBySalary";
            this.btnGetUsersOrderedBySalary.Size = new System.Drawing.Size(141, 24);
            this.btnGetUsersOrderedBySalary.TabIndex = 17;
            this.btnGetUsersOrderedBySalary.Text = "Users Ordered by Salary";
            this.btnGetUsersOrderedBySalary.UseVisualStyleBackColor = true;
            this.btnGetUsersOrderedBySalary.Click += new System.EventHandler(this.btnGetUsersOrderedBySalary_Click);
            // 
            // btnGetUnemployedReceivingSalaries
            // 
            this.btnGetUnemployedReceivingSalaries.Location = new System.Drawing.Point(4, 349);
            this.btnGetUnemployedReceivingSalaries.Name = "btnGetUnemployedReceivingSalaries";
            this.btnGetUnemployedReceivingSalaries.Size = new System.Drawing.Size(141, 40);
            this.btnGetUnemployedReceivingSalaries.TabIndex = 18;
            this.btnGetUnemployedReceivingSalaries.Text = "Unemployed, Receiving Salaries";
            this.btnGetUnemployedReceivingSalaries.UseVisualStyleBackColor = true;
            this.btnGetUnemployedReceivingSalaries.Click += new System.EventHandler(this.btnGetUnemployedReceivingSalaries_Click);
            // 
            // btnGetShorterThan190
            // 
            this.btnGetShorterThan190.Location = new System.Drawing.Point(4, 50);
            this.btnGetShorterThan190.Name = "btnGetShorterThan190";
            this.btnGetShorterThan190.Size = new System.Drawing.Size(141, 23);
            this.btnGetShorterThan190.TabIndex = 20;
            this.btnGetShorterThan190.Text = "Shorter Than 190";
            this.btnGetShorterThan190.UseVisualStyleBackColor = true;
            this.btnGetShorterThan190.Click += new System.EventHandler(this.btnGetShorterThan190_Click);
            // 
            // cbSendUserParamAsText
            // 
            this.cbSendUserParamAsText.AutoSize = true;
            this.cbSendUserParamAsText.Location = new System.Drawing.Point(4, 411);
            this.cbSendUserParamAsText.Name = "cbSendUserParamAsText";
            this.cbSendUserParamAsText.Size = new System.Drawing.Size(104, 17);
            this.cbSendUserParamAsText.TabIndex = 21;
            this.cbSendUserParamAsText.Text = "Export to text file";
            this.cbSendUserParamAsText.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 598);
            this.Controls.Add(this.cbSendUserParamAsText);
            this.Controls.Add(this.btnGetShorterThan190);
            this.Controls.Add(this.btnGetUnemployedReceivingSalaries);
            this.Controls.Add(this.btnGetUsersOrderedBySalary);
            this.Controls.Add(this.btnGetUsersWithSimilarAccountNumbers);
            this.Controls.Add(this.btnGetMissingPhysicalDetail);
            this.Controls.Add(this.btnGetMissingFinancialDetail);
            this.Controls.Add(this.btnGetTallestUser);
            this.Controls.Add(this.btnGetMostPaidUser);
            this.Controls.Add(this.btnGetUnemployedUsers);
            this.Controls.Add(this.btnGetEmployedUsers);
            this.Controls.Add(this.btnGetWeightBetween);
            this.Controls.Add(this.btnGetRedHeads);
            this.Controls.Add(this.dgvResults2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dgvResults2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResults)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TextBox txtDbConnection;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Button btnPopulateDatabase;
        private System.Windows.Forms.TabControl dgvResults2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQueryEntry;
        private System.Windows.Forms.Button btnExecuteQuery;
        private System.Windows.Forms.Button btnOuputFile;
        private System.Windows.Forms.Button btnDgv;
        private System.Windows.Forms.ComboBox cboQueryTypes;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dgvQueryResults;
        private System.Windows.Forms.Button btnGetRedHeads;
        private System.Windows.Forms.Button btnGetWeightBetween;
        private System.Windows.Forms.Button btnGetEmployedUsers;
        private System.Windows.Forms.Button btnGetUnemployedUsers;
        private System.Windows.Forms.Button btnGetMostPaidUser;
        private System.Windows.Forms.Button btnGetTallestUser;
        private System.Windows.Forms.Button btnGetMissingFinancialDetail;
        private System.Windows.Forms.Button btnGetMissingPhysicalDetail;
        private System.Windows.Forms.Button btnGetUsersWithSimilarAccountNumbers;
        private System.Windows.Forms.Button btnGetUsersOrderedBySalary;
        private System.Windows.Forms.Button btnGetUnemployedReceivingSalaries;
        private System.Windows.Forms.Button btnGetShorterThan190;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox txtDisplayResults;
        private System.Windows.Forms.CheckBox cbSendQueryResultAsText;
        private System.Windows.Forms.CheckBox cbSendUserParamAsText;
    }
}

