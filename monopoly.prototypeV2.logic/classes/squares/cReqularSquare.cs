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

        public cReqularSquare(string name)
        {
            this.myName = name;
        }

        public string Name
        {
            get { return this.myName; }
            set { this.myName = value; }
        }

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
