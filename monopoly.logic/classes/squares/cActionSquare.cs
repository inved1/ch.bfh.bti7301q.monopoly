using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.squares
{
    [Serializable]
    class cActionSquare:ISquare
    {
        private string myName = "";
        private string myColor = "grey"; // default
        private cPlayer myOwner;

        public cActionSquare(String name, String color)
        {
            this.myName = name;
            this.myColor = color;
        }

        public String ctrlName
        { get { return this.myName; } }

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
    }
}
