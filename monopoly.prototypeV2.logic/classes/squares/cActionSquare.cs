using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cActionSquare:ISquare
    {
        private string myName = "";

        public cActionSquare(String name)
        {
            this.myName = name;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }
    }
}
