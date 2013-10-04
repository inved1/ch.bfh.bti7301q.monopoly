using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic
{
    [Serializable] 
    public class dummyAction
    {
        public enum ActionType
        {
            Buy = 1,
            Pay = 2,
            Roll = 3
        }

        private String myVal1;
        private int myVal2;
        private ActionType myType;

        public String val1
        {
            get {return this.myVal1;}
            set { this.myVal1 = value; }
        }

        public int val2
        {
            get {return this.myVal2;}
            set { this.myVal2 = value; }
        }

        public ActionType type
        {
            get { return this.myType; }
            set { this.myType = value; }
        }

        public dummyAction() { }


    }
}
