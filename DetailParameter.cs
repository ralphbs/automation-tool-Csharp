using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThirdExercise {
    public class DetailParameter {
        public string Name, Value;

        public DetailParameter() {
        }

  
        public override string ToString() {
            return "" + this.Name + " is " + this.Value + "\r\n";
        }

        public DetailParameter(string name, string value) {
            Name = name;
            Value = value;
        }

        internal string GetTextRepresentation3() {
            
            string detailParamText = this.ToString();            
            return detailParamText;
        }

    }
}
