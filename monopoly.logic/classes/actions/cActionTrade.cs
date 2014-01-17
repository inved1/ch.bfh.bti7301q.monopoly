using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.actions
{
    [Serializable]
    public class cActionTrade : IAction
    {
        const string ACTION_NAME = "Handeln";
        private cGame game;

        public cActionTrade(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        {
            //should not be used here
        }
        public void runTrade()
        {
            this.game.playerTrades();
        }
    }
}
