using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.logic.interfaces; 

namespace monopoly.logic.classes.squares
{
    [Serializable]
    class cPrisonVisitorSquare : ISquare

    {
        private string myName = "";
        private string myColor = "grey"; // default
        private cPlayer myOwner;

        public cPrisonVisitorSquare(String name, String color)
        {
            this.myName = name;
            this.myColor = color;
        }


        public String colorStreet
        {
            get { return this.myColor; }
            set { this.myColor = value; }
        }

        public cPlayer Owner
        {
            get { return null; }
            set { myOwner = value; }
        }


        public void playAction()
        {
            throw new NotImplementedException();
        }


        public String ctrlName
        { get { return this.myName; } }

    }
}
