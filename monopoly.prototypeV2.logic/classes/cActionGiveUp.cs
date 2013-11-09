using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable] 
    public class cActionGiveUp:IAction
    {
        const string ACTION_NAME = "Zug beenden";
        string myName;
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

        public void runAction()
        {
           
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
