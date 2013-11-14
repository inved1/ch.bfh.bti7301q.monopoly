using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cPlayer
    {
        private string name = "";
        private cAvatar avatar = null;
        private int curPos = 0;

        public cPlayer(string name, string avatorToken, int curPos)
        {
            this.name = name;
            this.curPos = curPos;
            this.avatar = new cAvatar(avatorToken);
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public cAvatar Avatar
        {
            get { return this.avatar; }
            set { this.avatar = value; }
        }

        public int CurPos
        {
            get { return this.curPos; }
            set { this.curPos = value; }
        }
    }
}
