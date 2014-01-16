using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.squares
{
    [Serializable]
    class cStartSquare : ISquare
    {
        private string myName;
        private string myColor = "grey"; // default
        private cPlayer myOwner;

        public cStartSquare(String name, String color)
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

        public String ctrlName
        { get { return this.myName; } }



        public void playAction()
        {
            throw new NotImplementedException();
        }


      
    }
}
