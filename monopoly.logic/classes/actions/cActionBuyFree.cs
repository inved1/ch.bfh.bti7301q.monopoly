using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.actions
{
    [Serializable]
    public class cActionBuyFree : IAction
    {
        const string ACTION_NAME = "Aus dem Gefängniss freikaufen";
        private cGame game;

        public cActionBuyFree(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        {
            this.game.playerBuysFree();
        }
    }
}
