using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.actions
{
    [Serializable]
    public class cActionGoToPrison : IAction
    {
        const string ACTION_NAME = "Ab ins Gefängniss";
        private cGame game;

        public cActionGoToPrison(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        {
            this.game.playerGoesToPrison();
        }
    }
}
