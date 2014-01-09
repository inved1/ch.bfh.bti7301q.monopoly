﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cPayTaxesSquare :ISquare
    {

        private string myName = "";
        private string myColor = "grey"; // default
        private int myTax;

        public cPayTaxesSquare(String name,String color, int tax)
        {
            this.myName = name;
            this.myColor = color;
            this.myTax = tax;
        }

        public String colorStreet
        {
            get { return this.myColor; }
            set { this.myColor = value; }
        }
        public String ctrlName
        { get { return this.myName; } }

        public void playAction()
        {
            throw new NotImplementedException();
        }
        public int Tax
        {
            get { return this.myTax; }
            set { this.myTax = value; }
        }
    }
}
