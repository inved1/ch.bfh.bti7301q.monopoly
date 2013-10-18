using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototype.logic.interfaces;

namespace monopoly.prototype.logic.classes
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
    }
}
