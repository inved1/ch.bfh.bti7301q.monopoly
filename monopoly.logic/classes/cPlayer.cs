using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes
{
    [Serializable]
    public class cPlayer : IComparable
    {
        private string name = "";
        private cAvatar avatar = null;
        private int amount = 0;
        private int curPos = 1;
        private int rolledDoubles = 0;
        private int rolledInitDots = 0;
        private bool isInPrison;
        private int countPrisonFreeCards = 0;
        private bool myCanBuild;
        private bool myCanTrade;
        //used for waterpowersquares
        private int myLastDice1;
        private int myLastDice2;

        public cPlayer(string name, string avatorToken, int curPos)
        {
            this.name = name;
            this.curPos = curPos;
            this.avatar = new cAvatar(avatorToken);
            this.amount = Convert.ToInt32( cConfig.getInstance.Game["GameStartMoney"]);
            this.isInPrison = false;
            this.myCanBuild = false;
            this.myCanTrade = true;
            this.myLastDice1 = 0;
            this.myLastDice2 = 0;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int lastDice1
        {
            get { return this.myLastDice1; }
            set { this.myLastDice1 = value; }
        }
        public int lastDice2
        {
            get { return this.myLastDice2; }
            set { this.myLastDice2 = value; }
        }
        
        public bool inPrison
        {
            get { return this.isInPrison; }
            set { this.isInPrison = value; }
        }

        public int PrisonFreeCards
        {
            get { return this.countPrisonFreeCards; }
            set { this.countPrisonFreeCards = value; }
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

        public int RolledInitDots
        {
            get { return this.rolledInitDots; }
            set { this.rolledInitDots = value; }
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

        public bool canBuild
        {
            get { return this.myCanBuild ; }
            set { this.myCanBuild = value; }
        }

        public bool canTrade
        {

            get { return this.myCanTrade; }
        }
        public int CompareTo(object otherPlayer)
        {
            if (this.Name == ((cPlayer)otherPlayer).Name)
            {
                return this.Name.CompareTo(((cPlayer)otherPlayer).Name);
            }
            else
            {
                return ((cPlayer)otherPlayer).Name.CompareTo(this.Name);
            }
     
        }
    }
}
