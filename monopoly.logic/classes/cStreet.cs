using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes
{
    [Serializable]
    public class cStreet
    {
        private String myName;
        private List<int> myOwnedSquares;
        public cStreet(String name, List<int> ownedSquares)
        {
            this.myName = name;
            this.myOwnedSquares = ownedSquares;
        }

        public String getName()
        {
            return myName;
        }

        public List<int> getOwnedSquares()
        {
            return this.myOwnedSquares;
        }
    }
}
