using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class CommunitySquare:ISquare
    {
        private string name = "";

        public CommunitySquare(string name)
        {
            this.name = name;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }

        public void setPosition(int x, int y)
        {
            throw new NotImplementedException();
        }


        public int[] getPosition()
        {
            throw new NotImplementedException();
        }
    }
}
