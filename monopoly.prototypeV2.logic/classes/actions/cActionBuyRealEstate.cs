using monopoly.prototypeV2.logic.classes.squares;
using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.actions
{
    [Serializable]
    public class cActionBuyRealEstate : IAction
    {
        const string ACTION_NAME = "Immobilie kaufen";
        private cGame game = null;

        public cActionBuyRealEstate(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        { 
            
        }

        public void runBuyRealEstate(int squareNr) 
        {
            this.game.playerBuysRealEstate(squareNr);
        }
    }
}
