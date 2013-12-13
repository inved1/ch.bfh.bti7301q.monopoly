using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable] 
    public class cActionGiveUp:IAction
    {
        const string ACTION_NAME = "Spiel beenden";
        private cGame game = null;

        public cActionGiveUp(cGame game)
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
    }
}
