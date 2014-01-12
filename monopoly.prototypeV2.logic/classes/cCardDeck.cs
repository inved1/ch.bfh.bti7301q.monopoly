using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cCardDeck
    {

        private List<ICard> myCards;
        private cardType myType;
        private cConfig myConfig;

        public enum cardType
        {
            Actioncard = 1,
            Communitycard = 2
        }


        public cCardDeck(cardType t)
        {
            this.myCards = new List<ICard>();
            this.myConfig = cConfig.getInstance; 
            myType  = t;
            initCards();
        }

        private void initCards()
        {
            if (this.myType == cardType.Actioncard)
            {
                foreach (KeyValuePair<string, Dictionary<String, String>> entry in this.myConfig.ActionCards)
                {
                    this.myCards.Add(new cActionCard(entry.Value["Text"], entry.Value["Value"], entry.Value["Command"]));
                }


            }
            if (this.myType == cardType.Communitycard)
            {
                
                foreach (KeyValuePair<string, Dictionary<String, String>> entry in this.myConfig.CommunityCards)
                {
                    this.myCards.Add(new cCommunityCard(entry.Value["Text"], entry.Value["Value"], entry.Value["Command"]));
                }

            }
        }

        public cardType CardType
        {
            get { return this.myType; }
        }

        public List<ICard> getCards()
        {
            return this.myCards;
        }

        public ICard getNextCard()
        {
            ICard t = this.myCards.First();
            if (t == null)
            {
                initCards();
                t = this.myCards.First();

            }
            this.myCards.Remove(t);
            return this.myCards.First();
        }



    }
}
