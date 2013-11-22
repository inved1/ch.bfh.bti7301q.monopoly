﻿using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.squares
{
    [Serializable]
    class cTrainStationSquare:ISquare
    {
        private string myName = "";
        private string myColor = "grey"; // default

        public cTrainStationSquare(string name,string color)
        {
            this.myName = name;
            this.myColor = color;
        }

        public void playAction()
        {
            throw new NotImplementedException();
        }

        public String colorStreet
        {
            get { return this.myColor; }
            set { this.myColor = value; }
        }


        public String ctrlName
        { get { return this.myName; } }
    }
}
