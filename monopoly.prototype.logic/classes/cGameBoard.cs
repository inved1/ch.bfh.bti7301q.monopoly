using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic.classes
{
    public class cGameBoard
    {
        List<cAvatar> myAvatars;

        public List<cAvatar> lstAvatars
        {
            get
            {
                return this.myAvatars;
            }
            set
            {
                this.myAvatars = value;
            }
        }
        public cGameBoard() {

            this.myAvatars = new List<cAvatar>();
        }

    }
}
