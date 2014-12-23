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

namespace ThirdExercise {
    public class UserDetail {
       #region Enum

		 public enum DetailType {
            PhysicalDetail = 0,
            FinancialDetail = 1,
            PersonalDetail = 2,
        }

	    #endregion 

       #region Variables

         public List<DetailParameter> UserDetailParameters = new List<DetailParameter>();

         public DetailType userDetailType;

         #endregion

       #region Methods
        public override string ToString() {
            return "User Detail Type: " + Enum.GetName(typeof(DetailType), this.userDetailType);
        }

        internal string GetTextRepresentation2() {
            string userDetailText = "";
            userDetailText =userDetailText+ userDetailType.ToString() + "\r\n";
            foreach (DetailParameter detailParameter in UserDetailParameters) {
                userDetailText =userDetailText + detailParameter.GetTextRepresentation3();
            }
            return userDetailText;
        }
         #endregion
    }

    public class UserObject {   
        #region Getters and Setters

        public string username {
            get;
            set;
        }

        public string password {
            get;
            set;
        }

        public string email {
            get;
            set;
        }

        public List<UserDetail> userDetails {
            get;
            set;
        }

        public int Id {
            get;
            set;
        }

	#endregion

        #region Constructors

         public UserObject(string userName, string Password, string Email, List<UserDetail> UserDetails) {
            username = userName;
            password = Password;
            email = Email;
            userDetails = UserDetails;
        }

         public UserObject(string userName, string Password, string Email) {
            username = userName;
            password = Password;
            email = Email;
        }

         public UserObject() {
        
        }

        #endregion

        #region Methods
          internal string GetTextRepresentation() {
            string userText = "";
            userText = userText + "\nUsername: " + this.username + "\r\nPassword: " + this.password + "\r\nEmail: " + this.email+"\n";
            foreach (UserDetail userDetail in userDetails) {
                userText=userText+ userDetail.GetTextRepresentation2();
            }
            return userText;
        }
        #endregion
      
    }
}
