using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cActionLogin : IAction
    {
        private String playerName;

        public String PlayerName
        {
            get { return this.playerName; }
            set { this.playerName = value; }
        }

        public void runAction()
        {

        }

        public string Name
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
