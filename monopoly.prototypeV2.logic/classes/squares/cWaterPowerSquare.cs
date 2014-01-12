using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    public class cWaterPowerSquare : ISquare,IBuyable 
    {
        private string myName = "";
        private string myColor = "grey"; // default
        private cPlayer myOwner = null;
        private int myCost = 0;
        private Dictionary<int, int> myMultiplier;
        public cWaterPowerSquare(string name, string color, int cost,Dictionary<int,int> multiplier)
        {
            this.myName = name;
            this.myColor = color;
            this.myCost = cost;
            this.myMultiplier = multiplier;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }

        public String colorStreet 
        { 
            get {return this.myColor;}
            set { this.myColor = value; }
        }


        public String ctrlName
        { get { return this.myName; } }

        public cPlayer Owner
        {
            get { return this.myOwner; }
            set { this.myOwner = value; }
        }


        public int price
        {
            get { return this.myCost; }
            set { this.myCost = value; }
        }
    }
}
