using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cReqularSquare : ISquare
    {
        #region "vars"
        private string myName = "";
        private cPlayer myOwner = null;

        private int myPriceHouse = 0;
        private int myPriceHotel = 0;
        private int myCurrentRent = 0;
        private int myCountCurrentHouses = 0;
        private int myCountCurrentHotels = 0;
        private int myDeposit = 0;
        private int myCost = 0;
        private Dictionary<int, int> myRents;
        private string myColor = "grey"; // default

        #endregion 


        #region "constructors"
        public cReqularSquare(string name, String color,int cost,int priceHouse,int priceHotel,int deposit,Dictionary<int,int> rents )
        {
            this.myName = name;
            this.myColor = color;
            this.myCost = cost;
            this.myPriceHouse = priceHouse;
            this.myPriceHotel = priceHotel;
            this.myDeposit = deposit;
            this.myRents = rents;
        }
        #endregion


        #region "properties"
        public String colorStreet
        {
            get { return this.myColor; }
            set { this.myColor = value; }
        }

        public int Houses
        {
            get { return this.myCountCurrentHouses; }
            set
            {
                if ((this.myCountCurrentHouses + value) >= 4)
                {
                    this.myCountCurrentHouses += value;
                    this.CurrentRent = this.myRents[this.myCountCurrentHouses];
                }
                else
                {
                    throw new Exception("Es ist nicht möglich, mehr als 4 Häuser auf einem Feld zu haben");
                }
            }
        }

        public int Hotels
        {
            get { return this.myCountCurrentHotels; }
            set
            {
                if ((this.myCountCurrentHotels + value) < 2)
                {
                    this.myCountCurrentHotels += value;
                    this.CurrentRent = this.myRents[5];
                }
                else
                {
                    throw new Exception("Es ist nicht möglich, mehr als ein Hotel auf einem Feld zu haben");
                }
            }
        }

        public String ctrlName
        { get { return this.myName; } }

        
        public cPlayer Owner
        {
            get { return this.myOwner; }
            set { this.myOwner = value; }
        }

        public int PriceHouse
        {
            get { return this.myPriceHouse; }
            set { this.myPriceHouse = value; }
        }

        public int PriceHotel
        {
            get { return this.myPriceHotel; }
            set { this.myPriceHotel = value; }
        }

        public int CurrentRent
        {
            get { return this.myCurrentRent; }
            set { this.myCurrentRent = value; }
        }

        public Dictionary<int, int> Rents
        {
            get { return this.myRents; }
            set { this.myRents = value; }
        }
        #endregion

        #region "functions"

        
        public void playAction()
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
