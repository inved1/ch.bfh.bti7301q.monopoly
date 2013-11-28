using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;


namespace monopoly.prototypeV2.logic.classes
{
    [Serializable] 
    public class cActionRoll: IAction 
    {
        const string ACTION_NAME = "Würfeln"; 
        private cGame game = null;

        public cActionRoll(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        {
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 6);
            int dice2 = rnd.Next(1, 6);
            int value = dice1 + dice2;
            if (dice1 == dice2)
            {
                if (this.game.CurPlayer.RolledDoubles == 3)
                {
                    this.game.CurPlayer.RolledDoubles = 0;
                    // !!! set correct prison sqare !!!
                    this.game.CurPlayer.CurPos = 0;
                }
                else
                {
                    this.game.CurPlayer.RolledDoubles++;
                }
            }
            this.game.moveCurPlayer(value);
        }
    }
}
