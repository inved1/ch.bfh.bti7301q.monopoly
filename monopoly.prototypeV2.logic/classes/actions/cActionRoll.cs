using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;


namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cActionRoll : IAction
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
            this.game.CurPlayer.lastDice1 = dice1;
            this.game.CurPlayer.lastDice2 = dice2;

            this.game.addMsg("Aktueller Spieler hat [" + dice1.ToString() + "] und [" + dice2.ToString() + "] gewürfelt.");

            if (this.game.GameStatus == cGame.eGameStatus.DetermineStartPlayer)
            {
                this.game.determineStartPlayer(value);
            }
            else if (this.game.GameStatus == cGame.eGameStatus.Running)
            {


                if (this.game.CurPlayer.inPrison)
                {
                    if (dice1 == dice2)
                    {
                        this.game.addMsg("Aktueller Spieler hat Pasch gewürfelt und kommt aus dem Gefängniss raus.");
                        this.game.CurPlayer.RolledDoubles++;
                        this.game.CurPlayer.inPrison = false;
                        this.game.CurPlayer.CurPos = 10;
                        //this.game.moveCurPlayer(value);
                    }

                }
                else
                {

                    if (dice1 == dice2)
                    {
                        
                        this.game.CurPlayer.RolledDoubles++;
                        this.game.addMsg("Aktueller Spieler hat Pasch gewürfelt, [" + this.game.CurPlayer.RolledDoubles.ToString() + "]x Pasch");
                        if (this.game.CurPlayer.RolledDoubles == 3)
                        {
                            this.game.addMsg("Aktueller Spieler hat 3x Pasch gehabt, ab ins Gefängniss");
                            this.game.CurPlayer.RolledDoubles = 0;
                            // !!! set correct prison sqare !!!
                            this.game.CurPlayer.CurPos = 99;
                            this.game.CurPlayer.inPrison = true;
                        }

                    }
                    
                }
                this.game.moveCurPlayer(value);

            }


        }
    }
}
