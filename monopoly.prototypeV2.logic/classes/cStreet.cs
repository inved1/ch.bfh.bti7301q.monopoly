using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    class cStreet
    {
        private String myName;
        private List<int> myOwnedSquares;
        public cStreet(String name, List<int> ownedSquares)
        {
            this.myName = name;
            this.myOwnedSquares = ownedSquares;
        }


    }
}
