using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cAvatar
    {
        private string token = ""; 

        public cAvatar(string token)
        {
            this.token = token;
        }

        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }
    }
}
