using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable ]
    class cCommunityCard : ICard

    {


        private String myText;
        private string myValue;
        private String myCommand;


        public cCommunityCard(String text, string value,String command)
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
