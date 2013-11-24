using monopoly.prototypeV2.logic.classes.actions;
using monopoly.prototypeV2.logic.classes.squares;
using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    public class cGame : MarshalByRefObject
    {
        #region "vars"
        private cGameBoard gameBoard;
        private List<IObserverGUI> observerGuis;
        private List<cPlayer> players;
        private List<IAction> actions;
        private IObserverGUI curGui;
        private cPlayer curPlayer;
        private int counter = 0;
        private cConfig myConfig;
        #endregion

        #region "constructor"
        public cGame()
        {
            this.myConfig = cConfig.getInstance;
            this.gameBoard = cGameBoard.getInstance();
            this.observerGuis = new List<IObserverGUI>();
            this.players = new List<cPlayer>();
            this.actions = new List<IAction>();

            initGame();
        }
        #endregion

        public void initGame()
        {

        }

        public cGameBoard GameBoard
        {
            get { return this.gameBoard; }
        }

        public cPlayer CurPlayer
        {
            get { return this.curPlayer; }
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

        public List<IAction> Actions
        {
            get { return actions; }
        }

        #region "game control functions"
        public void controlGame()
        {
            actions.Clear();
            ISquare curSquare = gameBoard.getSpecificSquare(curPlayer.CurPos);
            if (curSquare.GetType() == typeof(cRegularSquare) ||
                curSquare.GetType() == typeof(cTrainStationSquare) ||
                curSquare.GetType() == typeof(cWaterPowerSquare))
            {
                if (checkSquareAvailability(curSquare))
                {
                    actions.Add(new cActionBuySquare(this));
                }
            }
            else if (curSquare.GetType() == typeof(cCommunitySquare) ||
                     curSquare.GetType() == typeof(cActionSquare))
            {

            }
            else if (curSquare.GetType() == typeof(cTaxSquare))
            {

            }
            actions.Add(new cActionGiveUp(this));
        }

        public void moveCurPlayer(int valueToMove)
        {
            int tmpCurPos = curPlayer.CurPos; //remember for checking if player passed start
            curPlayer.CurPos = ((curPlayer.CurPos + valueToMove) % 41);
            if (checkPlayerPassingStart(tmpCurPos, valueToMove))
            {
                curPlayer.addMoney(9999); // tbd
            }
            notifyGuis();
            controlGame();
        }

        public void playerBuysSquare()
        {
            ISquare curSquare = gameBoard.getSpecificSquare(curPlayer.CurPos);
            try
            {
                curPlayer.spendMoney(Convert.ToInt32(curSquare.GetType().GetProperty("Cost").GetValue(curSquare)));
                curSquare.GetType().GetProperty("Owner").SetValue(curSquare, curPlayer);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void playerEndsTurn()
        {
            curPlayer.RolledDoubles = 0;
            curPlayer = players[players.IndexOf(curPlayer) + 1];
            setDefaultActions();
        }

        public bool checkSquareAvailability(ISquare curSquare)
        {
            if (curSquare.GetType().GetProperty("Owner").GetValue(curSquare) == null)
            {
                return true;
            }
            return false;
        }

        public bool checkPlayerPassingStart(int prevPos, int valueToMove)
        {
            if (((curPlayer.CurPos + valueToMove) % 41) < prevPos)
            {
                return true;
            }
            return false;
        }

        public void setDefaultActions()
        {
            actions.Clear();
            actions.Add(new cActionRoll(this));
            actions.Add(new cActionGiveUp(this));
        }
        #endregion

        #region "observer functions"
        public void attach(IObserverGUI observerGui)
        {
            this.observerGuis.Add(observerGui);
            //curGui = observerGui;
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
            //curGui.updateActions();
        }
        #endregion

    }
}
