using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class StartSquare : ISquare
    {
        private string name = "Start";

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }
    }
}
