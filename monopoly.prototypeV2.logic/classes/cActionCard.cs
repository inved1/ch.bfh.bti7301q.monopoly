using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes 
{
    [Serializable]
    class cActionCard : ICard
    {

        private String myText;
        private Dictionary<String,int> myValue;

        public cActionCard(String text, Dictionary<String,int> value)
        {
            this.myText = text;
            this.myValue = value;

        }

        public void playAction()
        {
            throw new NotImplementedException();
        }
    }
}
