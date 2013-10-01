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
        private String myVal1;
        private int myVal2;
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

        public dummyAction() { }


    }
}
