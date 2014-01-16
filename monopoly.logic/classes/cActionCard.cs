using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.logic.interfaces;

namespace monopoly.logic.classes 
{
    [Serializable]
    class cActionCard : ICard
    {

        private String myText;
        private string myValue;
        private String myCommand;

        public cActionCard(String text, string value,String command)
        {
            this.myText = text;
            this.myValue = value;
            this.myCommand = command;

        }



        public string Command
        {
            get { return this.myCommand; }
        }

        public string Value
        {
            get { return this.myValue; }
        }


        public string Text
        {
            get { return this.myText; }
        }
    }
}
