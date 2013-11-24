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
        private int amount = 0;
        private int curPos = 0;
        private int rolledDoubles = 0;

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

        public int Amount
        {
            get { return this.amount; }
        }

        public int CurPos
        {
            get { return this.curPos; }
            set { this.curPos = value; }
        }

        public int RolledDoubles
        {
            get { return this.rolledDoubles; }
            set { this.rolledDoubles = value; }
        }

        public void addMoney(int value)
        {
            this.amount += value;
        }

        public void spendMoney(int value)
        {
            if ((this.amount - value) >= 0)
            {
                this.amount -= value;
            }
            else
            {
                throw new Exception("Zuwenig Geld vorhanden.");
            }
        }
    }
}
