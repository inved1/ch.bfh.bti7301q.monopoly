using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    public class cGame : MarshalByRefObject
    {
        private cGameBoard gameBoard;
        private List<IObserverGUI> observerGuis;
        private List<cPlayer> players;
        private List<IAction> actions;
        private IObserverGUI curGui;
        private cPlayer curPlayer;
        private int counter = 0;

        public cGame()
        {
            this.gameBoard = new cGameBoard();
            this.observerGuis = new List<IObserverGUI>();
            this.players = new List<cPlayer>();
            this.actions = new List<IAction>();

            initGame();
        }

        public void initGame()
        {
            cPlayer player;
            /*for (int i = 0; i < 4; i++)
            {
                player = new cPlayer("Player" + this.Players.Count + 1, "ship", 0);
                this.players.Add(player);
            }*/
        }

        public cGameBoard GameBoard
        {
            get{return this.gameBoard;}
        }

        public cPlayer CurPlayer
        {
            get { return this.curPlayer; }
        }

        public void attach(IObserverGUI observerGui)
        {
            this.observerGuis.Add(observerGui);
            //curGui = observerGui;
        }

        public void addPlayer(cPlayer player)
        {
            players.Add(player);
            //curPlayer = player;
            notifyGuis();
            //notifyCurPlayer();
        }

        public List<cPlayer> Players
        {
            get { return players; }
        }

        public void createActions()
        {
            actions.Add(new cActionRoll(this));
            actions.Add(new cActionGiveUp(this));
        }

        public List<IAction> Actions
        {
            get { return actions; }
        }

        public void moveCurPlayer(int value)
        {
            curPlayer.CurPos += value;
            notifyGuis();
        }

        public void notifyGuis()
        {
            foreach (IObserverGUI obs in this.observerGuis)
            {
                obs.updateAll();
            }
        }

        public void notifyCurPlayer()
        {
            createActions();
            curGui.updateActions();
        }

    }
}
