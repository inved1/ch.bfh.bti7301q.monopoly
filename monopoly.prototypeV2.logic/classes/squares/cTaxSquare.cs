using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cTaxSquare:ISquare
    {
        private string myName = "";
        private string myColor = "grey"; // default
        private int myTax = 0;
        private cPlayer myOwner;

        public cTaxSquare(string name, string color, int tax)
        {
            this.myName = name;
            this.myColor = color;
            this.myTax = tax;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }

        public cPlayer Owner
        {
            get { return null; }
            set { myOwner = value; }
        }


        public String colorStreet
        {
            get { return this.myColor; }
            set { this.myColor = value; }
        }

        public String ctrlName
        { get { return this.myName; } }


        public int Tax
        {
            get { return this.myTax; }
            set { this.myTax = value; } 
        }
    }
}
