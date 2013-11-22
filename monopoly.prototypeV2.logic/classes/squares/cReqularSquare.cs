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
        private string myName = "";
        private cPlayer owner = null;
        private int priceHouse = 0;
        private int priceHotel = 0;
        private int rent = 0;
        private string myColor = "grey"; // default
        
        String getName()
        {
            return this.myName;
        }

        public cReqularSquare(string name, String color)
        {
            this.myName = name;
            this.myColor = color;
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
            get { return this.owner; }
            set { this.owner = value; }
        }

        public int PriceHouse
        {
            get { return priceHouse; }
            set { this.priceHouse = value; }
        }

        public int PriceHotel
        {
            get { return priceHotel; }
            set { this.priceHotel = value; }
        }

        public int Rent
        {
            get { return rent; }
            set { this.rent = value; }
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }
    }
}
