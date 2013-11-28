using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cTrainStationSquare:ISquare
    {
        private string myName = "";
        private string myColor = "grey"; // default
        private cPlayer myOwner = null;
        private int myCost = 0;

        public cTrainStationSquare(string name,string color)
        {
            this.myName = name;
            this.myColor = color;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }

        public String colorStreet
        {
            get { return this.myColor; }
            set { this.myColor = value; }
        }


        public String ctrlName
        { get { return this.myName; } }

        public cPlayer Owner
        {
            get { return this.myOwner; }
            set { this.myOwner = value; }
        }

        public int Cost
        {
            get { return this.myCost; }
            set { this.myCost = value; }
        }
    }
}
