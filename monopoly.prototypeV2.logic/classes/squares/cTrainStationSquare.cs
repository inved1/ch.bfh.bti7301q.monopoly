using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
   public class cTrainStationSquare:ISquare,IBuyable 
    {
        private string myName = "";
        private string myColor = "grey"; // default
        private cPlayer myOwner = null;
        private int myCost = 0;
        private Dictionary<int, int> myRents;
        //private cGameBoard myGameboard;

        public cTrainStationSquare(string name,string color, int cost ,Dictionary<int,int> rents)
        {
            this.myName = name;
            this.myColor = color;
            this.myCost = cost;
            this.myRents = rents;
            //this.myGameboard = gameboard;
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

        public int price
        {
            get { return this.myCost; }
            set { this.myCost = value; }
        }


        public Dictionary<int, int> Rents
        {
            get { return this.myRents; }
        }
        public int CurrentRent
        {
            //check if my owner has other cards
            

            get {
               // List<cTrainStationSquare> l = this.myGameboard.getTrainStationSquaresByPlayer(this.Owner);
                //return this.myRents[l.Count];
                return 0;
            }
        }


        public string TradeString
        {
            get { return this.ctrlName; }
        }
    }
}
