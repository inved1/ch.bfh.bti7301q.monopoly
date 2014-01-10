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

        public enum cardType
        {
            Actioncard = 1,
            Communitycard = 2
        }


        public cCardDeck(cardType t)
        {
            this.myCards = new List<ICard>();
            myType  = t;
            initCards();
        }

        private void initCards()
        {
            if (this.myType == cardType.Actioncard)
            {

                //tst blubb

                Dictionary<String, int> dic = new Dictionary<string, int>();
                dic.Add("singel", 100);

                this.myCards.Add(new cActionCard("Advance to Go (Collect $200)", dic));
                this.myCards.Add(new cActionCard("Bank error in your favor – collect $75", dic));
                this.myCards.Add(new cActionCard("Doctor's fees – Pay $50", dic));
                this.myCards.Add(new cActionCard("Get out of jail free – this card may be kept until needed, or sold", dic));
                this.myCards.Add(new cActionCard("Go to jail – go directly to jail – Do not pass Go, do not collect $200", dic));
                this.myCards.Add(new cActionCard("It is your birthday Collect $10 from each player", dic));
                this.myCards.Add(new cActionCard("Grand Opera Night – collect $50 from every player for opening night seats", dic));
                this.myCards.Add(new cActionCard("Income Tax refund – collect $20", dic));
                this.myCards.Add(new cActionCard("Life Insurance Matures – collect $100", dic));
                this.myCards.Add(new cActionCard("Pay Hospital Fees of $100", dic));
                this.myCards.Add(new cActionCard("Pay School Fees of $50", dic));
                this.myCards.Add(new cActionCard("Receive $25 Consultancy Fee", dic));

            }
            if (this.myType == cardType.Communitycard)
            {
                Dictionary<String, int> dic = new Dictionary<string, int>();
                dic.Add("singel", 100);

                this.myCards.Add(new cActionCard("Advance to Go (Collect $200)", dic));
                this.myCards.Add(new cActionCard("Bank error in your favor – collect $75", dic));
                this.myCards.Add(new cActionCard("Doctor's fees – Pay $50", dic));
                this.myCards.Add(new cActionCard("Get out of jail free – this card may be kept until needed, or sold", dic));
                this.myCards.Add(new cActionCard("Go to jail – go directly to jail – Do not pass Go, do not collect $200", dic));
                this.myCards.Add(new cActionCard("It is your birthday Collect $10 from each player", dic));
                this.myCards.Add(new cActionCard("Grand Opera Night – collect $50 from every player for opening night seats", dic));
                this.myCards.Add(new cActionCard("Income Tax refund – collect $20", dic));
                this.myCards.Add(new cActionCard("Life Insurance Matures – collect $100", dic));
                this.myCards.Add(new cActionCard("Pay Hospital Fees of $100", dic));
                this.myCards.Add(new cActionCard("Pay School Fees of $50", dic));
                this.myCards.Add(new cActionCard("Receive $25 Consultancy Fee", dic));
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
            }
            this.myCards.Remove(t);
            return this.myCards.First();
        }



    }
}
