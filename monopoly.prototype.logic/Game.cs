using monopoly.prototype.logic.classes;
using monopoly.prototype.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic
{
    public class Game
    {
        private static Game game;
        private cGameBoard gameBoard;
        private List<IObserver> observers; // clients
        private List<IAction> clientActions;
        private IAction actRoll;
        private IAction actGiveUp;

        protected Game()
        {
            initGame();
        }

        private void initGame()
        {
            this.gameBoard = new cGameBoard();
            this.observers = new List<IObserver>();

            initActions();
        }

        private void initActions()
        {
            this.actRoll = new cActionRoll();
            this.actRoll.Name = "Würfeln";
            this.actGiveUp = new cActionGiveUp();
            this.actGiveUp.Name = "Zug beenden";
        }

        public static Game getInstance()
        {
            if (game == null)
            {
                game = new Game();
            }
            return game;
        }

        public void Attach(IObserver obs)
        {
            observers.Add(obs);
        }

        public void NotifyObserver(IObserver obs)
        {
            obs.Update(clientActions);
        }

        public void NotifyObservers()
        {
            foreach (IObserver obs in observers)
            {
                obs.Update(clientActions);
            }
        }

        public void playAction(List<IAction> actions)
        {
            foreach (IAction action in actions)
            {
                Console.WriteLine(action.GetType());
                if (action.GetType() == typeof(cActionLogin))
                {
                    clientActions = new List<IAction>();
                    clientActions.Add(actRoll);
                    clientActions.Add(actGiveUp);
                    NotifyObservers();
                }
            }
        }
    }
}
