using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cGoToPrisonSquare :ISquare
    {

        private string myName = "";

        public cGoToPrisonSquare(string name)
        {
            this.myName = name;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }
    }
}
