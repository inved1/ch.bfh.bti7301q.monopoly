using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;


namespace monopoly.prototypeV2.logic.classes
{
    [Serializable] 
    public class cActionRoll: IAction 
    {
        const string ACTION_NAME = "Würfeln"; 
        string myName;
        int myValue;
        public string Name
        {
            get
            {
                return this.myName;
            }
            set
            {
                this.myName = value;
            }
        }

        public  int val
        {
            get
            {
                return myValue;
            }
        }

        public void runAction()
        {
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 6);
            int dice2 = rnd.Next(1, 6);
            this.myValue = dice1 + dice2;
        }



        public void runAction(bool yes)
        {
            throw new NotImplementedException();
        }

        public cPlayer owner
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
