using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cStartSquare : ISquare
    {
        private string myName;

        public cStartSquare(String name)
        {
            this.myName = name;
        }

        public string Name
        {
            get { return this.myName; }
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }


      
    }
}
