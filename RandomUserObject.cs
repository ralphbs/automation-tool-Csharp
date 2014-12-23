using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirdExercise {
    public class RandomUserObject {
        #region Variables

        public string Username;

        public DateTime JoinDate, ExitDate;

        #endregion

        #region Methods

        public RandomUserObject(string randomUsername, DateTime randomJoinDate, DateTime randomExitDate) {
            Username = randomUsername;
            JoinDate = randomJoinDate;
            ExitDate = randomExitDate;
        }

        #endregion
    }
}
