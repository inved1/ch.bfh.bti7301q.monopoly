using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class TaxSquare:ISquare
    {
        private string name = "";

        public TaxSquare(string name)
        {
            this.name = name;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }
    }
}
