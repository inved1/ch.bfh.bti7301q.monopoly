﻿using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class ReqularSquare : ISquare
    {
        private string name = "";
        private cPlayer owner = null;
        private int priceHouse = 0;
        private int priceHotel = 0;
        private int rent = 0;

        public ReqularSquare(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
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
