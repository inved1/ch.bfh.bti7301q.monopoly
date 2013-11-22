﻿using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cStartSquare : ISquare
    {
        private string myName;
        private string myColor = "grey"; // default

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


        public String ctrlName
        { get { return this.myName; } }



        public void playAction()
        {
            throw new NotImplementedException();
        }


      
    }
}
