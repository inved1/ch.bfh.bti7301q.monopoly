using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic.classes
{
    public class cAvatar
    {
        int myPosition;
        public int position
        {
            get
            {
                return this.myPosition;
            }
            set
            {
                this.myPosition = value;
            }
        }
        public cAvatar() { }
    }
}
