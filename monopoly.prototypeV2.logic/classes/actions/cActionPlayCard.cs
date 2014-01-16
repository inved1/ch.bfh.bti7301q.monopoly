using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.actions
{
    [Serializable]
    public class cActionPlayCard : IAction
    {
        const string ACTION_NAME = "Aktion auf Karte ausführen";
        private cGame game;
        private ICard card;

        public cActionPlayCard(cGame game, ICard card)
        {
            this.game = game;
            this.card = card;
        }

        public string getName()
        {
            return ACTION_NAME + System.Environment.NewLine + this.card.Text ;
        }

        public void runAction()
        {
            this.game.playerCardAction(this.card);
        }
    }
}
