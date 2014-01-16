using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.actions
{
    [Serializable]
    public class cActionBuySquare : IAction
    {
        #region "vars"
        const string ACTION_NAME = "Kaufen";
        private cGame game = null;
        private int price = 0;
        #endregion

        public cActionBuySquare(cGame game, int price)
        {
            this.game = game;
            this.price = price;
        }

        public string getName()
        {
            return ACTION_NAME;
        }
        public int getPrice()
        {
            return this.price;
        }

        public void runAction()
        {
            this.game.playerBuysSquare();
        }
    }
}
