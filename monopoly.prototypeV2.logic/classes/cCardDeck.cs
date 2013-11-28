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
                

//this.myCards.Add(new cActionCard("Advance to Go (Collect $200)",  );
//this.myCards.Add(new cActionCard("Bank error in your favor – collect $75",75);
//this.myCards.Add(new cActionCard("Doctor's fees – Pay $50",-50);
//this.myCards.Add(new cActionCard("Get out of jail free – this card may be kept until needed, or sold",0);
//this.myCards.Add(new cActionCard("Go to jail – go directly to jail – Do not pass Go, do not collect $200",0);
//this.myCards.Add(new cActionCard("It is your birthday Collect $10 from each player",10);
//this.myCards.Add(new cActionCard("Grand Opera Night – collect $50 from every player for opening night seats",50);
//this.myCards.Add(new cActionCard("Income Tax refund – collect $20",20);
//this.myCards.Add(new cActionCard("Life Insurance Matures – collect $100",100);
//this.myCards.Add(new cActionCard("Pay Hospital Fees of $100",-100);
//this.myCards.Add(new cActionCard("Pay School Fees of $50",-50);
//this.myCards.Add(new cActionCard("Receive $25 Consultancy Fee",25);
//this.myCards.Add(new cActionCard("You are assessed for street repairs – $40 per house, $115 per hotel"
//this.myCards.Add(new cActionCard("You have won second prize in a beauty contest– collect $10"
//this.myCards.Add(new cActionCard("You inherit $100"
//this.myCards.Add(new cActionCard("From sale of stock you get $50"
//this.myCards.Add(new cActionCard("Holiday Fund matures - Receive $100"
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
