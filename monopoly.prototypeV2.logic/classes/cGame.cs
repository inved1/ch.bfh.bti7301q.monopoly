using monopoly.prototypeV2.logic.classes.actions;
using monopoly.prototypeV2.logic.classes.squares;
using monopoly.prototypeV2.logic.interfaces;
using monopoly.prototypeV2.logic.util;
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
        private List<IAction> actions;
        private cPlayer startPlayer;
        private cPlayer curPlayer;
        private cConfig myConfig;
        private LogWriter logWriter;

        // !!! only public for testing !!!
        public SortedList<cPlayer, IObserverGUI> playerObservers;
        private eGameStatus gameStatus = 0;
        #endregion




        public enum eGameStatus
        {
            NotStarted = 0,
            DetermineStartPlayer = 1,
            Running = 2
        }

        #region "constructor"
        public cGame()
        {
            this.myConfig = cConfig.getInstance;
            this.gameBoard = cGameBoard.getInstance();

            this.actions = new List<IAction>();
            this.logWriter = LogWriter.Instance;
            this.playerObservers = new SortedList<cPlayer, IObserverGUI>();
        }
        #endregion

        public cGameBoard GameBoard
        {
            get { return this.gameBoard; }
        }

        public cPlayer StartPlayer
        {
            get { return this.startPlayer; }
            set { this.startPlayer = value; }
        }

        public cPlayer CurPlayer
        {
            get { return this.curPlayer; }
            set { this.curPlayer = value; }
        }

        public eGameStatus GameStatus
        {
            get { return this.gameStatus; }
            set { this.gameStatus = value; }
        }

        public delegate void updateGUIEventHandler(object sender, EventArgs e);
        public event updateGUIEventHandler updateGUIEvent = delegate { };

        public delegate void updateGUIActionEventHandler(object sender, EventArgs e);
        public event updateGUIActionEventHandler updateGUIActionEvent = delegate { };

        public void addPlayer(cPlayer player, IObserverGUI obs)
        {
            if (this.playerObservers.Keys.Count < 8)
            {

                this.playerObservers.Add(player, obs);


                this.updateGUIEvent += obs.onUpdateGUIEvent;
                this.updateGUIActionEvent += obs.onUpdateGUIActionsEvent;
                //notifyGuis();
            }
            else
            {
                throw new Exception("Max. 8 Spieler möglich.");
            }
        }

        public void removePlayer(cPlayer player, IObserverGUI obs)
        {
            this.playerObservers.Remove(player);

        }

        public List<cPlayer> Players
        {
            get { return this.playerObservers.Keys.ToList(); }
        }


        public List<cRegularSquare> RegularSquares
        {
            get { return gameBoard.getRegularSquares(); }
        }


        public List<IAction> Actions
        {
            get { return actions; }
        }

        #region "game control functions"
        public void initGame()
        {
            try
            {
                this.gameStatus = cGame.eGameStatus.DetermineStartPlayer;
                notifyGuis();
                if (this.playerObservers.Count < 1)
                {
                    throw new Exception("Keine Players registriert");
                }
                curPlayer = this.playerObservers.Keys.First();
                setDefaultActions();
                notifyCurPlayer();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("catch: curPos: " + curPlayer.CurPos);
                throw ex;
            }

        }

        public void startGame()
        {
            this.gameStatus = cGame.eGameStatus.Running;
            notifyGuis();
            setDefaultActions();
            notifyCurPlayer();


        }

        public ISquare getSpecificSquare(int pos)
        {
            return this.gameBoard.getSpecificSquare(pos);
        }

        public void setNextCurPlayer()
        {
            Debug.Write("oldCurPlayer: " + curPlayer.Name);
            curPlayer = playerObservers.Keys.ElementAt((playerObservers.IndexOfKey(curPlayer) + 1) % playerObservers.Count);
            Debug.Write(", newCurPlayer: " + curPlayer.Name);
        }

        // !!! initialize all actions in config? !!!
        public void setActionsAfterMoving()
        {
            actions.Clear();
            cCardDeck cardDeck;
            ISquare curSquare = getCurSquare();
            if (curSquare.GetType() == typeof(cRegularSquare) ||
                curSquare.GetType() == typeof(cTrainStationSquare) ||
                curSquare.GetType() == typeof(cWaterPowerSquare))
            {
                if (checkSquareAvailability(curSquare))
                {
                    actions.Add(new cActionBuySquare(this));
                }
                else
                {
                    playerPaysRent();
                    actions.Add(new cActionEndTurn(this));
                }
            }
            else if (curSquare.GetType() == typeof(cCommunitySquare))
            {
                cardDeck = gameBoard.getSpecificCardDeck(cCardDeck.cardType.Communitycard);
                //ICard card = cardDeck.getNextCard();
                // !!! show card somehow !!!
                actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cActionSquare))
            {
                cardDeck = gameBoard.getSpecificCardDeck(cCardDeck.cardType.Actioncard);
                //ICard card = cardDeck.getNextCard();
                // !!! show card somehow !!!
                actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cTaxSquare))
            {
                playerPaysTax();
                actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cStartSquare) ||
                     curSquare.GetType() == typeof(cPrisonVisitorSquare) ||
                     curSquare.GetType() == typeof(cFreeParkSquare))
            {
                actions.Add(new cActionEndTurn(this));
            }
            actions.Add(new cActionGiveUp(this));
            notifyCurPlayer();
        }

        public void setDefaultActions()
        {
            actions.Clear();
            actions.Add(new cActionRoll(this));
            actions.Add(new cActionGiveUp(this));
        }

        public void determineStartPlayer(int rolledDots)
        {
            /*if (curPlayer.RolledInitDots != 0)
            {
                startGame();
            }
            else
            {*/
            curPlayer.RolledInitDots = rolledDots;
            if (startPlayer == null)
            {
                Debug.Write("oldStartPlayer: ");
                startPlayer = curPlayer;
                Debug.WriteLine(", newStartPlayer: " + startPlayer.Name);
            }
            else
            {
                Debug.Write("oldStartPlayer: " + startPlayer.Name + ", startPlayer: " + startPlayer.RolledInitDots + ", curPlayer: " + curPlayer.RolledInitDots);
                if (curPlayer.RolledInitDots > startPlayer.RolledInitDots)
                {
                    startPlayer = curPlayer;
                }
                Debug.WriteLine(", newStartPlayer: " + startPlayer.Name);
            }

            if (playerObservers.Keys.Last() == curPlayer)
            {
                startGame();
            }
            else
            {
                setNextCurPlayer();
                setDefaultActions();
                notifyCurPlayer();
            }
            //}
        }

        public void moveCurPlayer(int valueToMove)
        {
            int tmpCurPos = curPlayer.CurPos; //remember for checking if player passed start

            Debug.Write(curPlayer.Name + ", tmpCurPos: " + tmpCurPos);

            curPlayer.CurPos = ((curPlayer.CurPos + valueToMove) % 41) + 1;

            Debug.Write(", curPos: " + curPlayer.CurPos + " (" + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName + ")");

            if (checkPlayerPassingStart(tmpCurPos, valueToMove))
            {
                Debug.Write(", passingStart: true");
                // !!! define amount for passing start !!!
                curPlayer.addMoney(9999);
            }
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " moved to " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            notifyGuis();
            Debug.WriteLine("");
            setActionsAfterMoving();

        }

        public void playerPaysRent()
        {
            ISquare curSquare = getCurSquare();
            int rent = Convert.ToInt32(curSquare.GetType().GetProperty("CurrentRent").GetValue(curSquare));
            cPlayer owner = (cPlayer)curSquare.GetType().GetProperty("Owner").GetValue(curSquare);

            Debug.WriteLine("owner: " + owner.Name);
            Debug.WriteLine("oldAmountCurPlayer: " + curPlayer.Amount + ", oldAmountOwner: " + owner.Amount);
            curPlayer.spendMoney(rent);
            owner.addMoney(rent);
            Debug.WriteLine("newAmountCurPlayer: " + curPlayer.Amount + ", newAmountOwner: " + owner.Amount);
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " paid rent to " + owner.Name + " for " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            notifyGuis();
        }

        public void playerPaysTax()
        {
            ISquare curSquare = getCurSquare();

            // !!! define tax on tax squares !!!
            //int tax = Convert.ToInt32(curSquare.GetType().GetProperty("Tax").GetValue(curSquare));
            int tax = 4000;
            Debug.Write("oldAmount: " + curPlayer.Amount);
            curPlayer.spendMoney(tax);
            Debug.WriteLine(", newAmount: " + curPlayer.Amount);
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " paid tax of " + tax);
            notifyGuis();
        }

        public void playerBuysSquare()
        {
            ISquare curSquare = getCurSquare();
            int cost;
            cPlayer owner; // for debugging
            try
            {
                cost = Convert.ToInt32(curSquare.GetType().GetProperty("Cost").GetValue(curSquare));
                Debug.Write("oldAmount: " + curPlayer.Amount + ", cost: " + cost);
                curPlayer.spendMoney(cost);
                Debug.Write(", newAmount: " + curPlayer.Amount);
                curSquare.GetType().GetProperty("Owner").SetValue(curSquare, curPlayer);
                // player for debugging
                owner = (cPlayer)curSquare.GetType().GetProperty("Owner").GetValue(curSquare);
                Debug.WriteLine(", newOwner: " + owner.Name);
                logWriter.WriteLogQueue("Player " + curPlayer.Name + " has bought " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            notifyGuis();
            setNextCurPlayer();
            setDefaultActions();
            notifyCurPlayer();
        }

        public void playerEndsTurn()
        {
            curPlayer.RolledDoubles = 0;
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " has ended his turn.");
            Debug.Write("oldPlayer: " + curPlayer.Name);
            //curPlayer = this.playerObservers.Keys.ToList()[((players.IndexOf(curPlayer) + 1) % players.Count)];
            setNextCurPlayer();
            Debug.WriteLine(", newPlayer: " + curPlayer.Name);
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }

        public void playerGivesUp()
        {
            ISquare square;
            cPlayer owner;
            foreach (KeyValuePair<int, ISquare> pair in gameBoard.getSquares())
            {
                square = pair.Value;
                // !!!! will lead to an error -> not every square has an owner !!!!
                // not fixed yet
                owner = (cPlayer)square.GetType().GetProperty("Owner").GetValue(square);
                if (owner == curPlayer)
                {
                    square.GetType().GetProperty("Owner").SetValue(square, null);
                }
            }
        }

        public bool checkSquareAvailability(ISquare curSquare)
        {
            Debug.WriteLine(curSquare.GetType().GetProperty("Owner").GetValue(curSquare));
            if (curSquare.GetType().GetProperty("Owner").GetValue(curSquare) == null)
            {
                return true;
            }
            return false;
        }

        public bool checkPlayerPassingStart(int prevPos, int valueToMove)
        {
            //this check runs after moving to the new position
            Debug.WriteLine(", prevPos: " + prevPos + ", valueToMove: " + valueToMove);
            Debug.WriteLine("(" + curPlayer.CurPos + " + " + valueToMove + " % 41 < " + prevPos + ")");
            if (((prevPos + valueToMove) % 41) < prevPos)
            {
                return true;
            }
            return false;
        }

        public ISquare getCurSquare()
        {
            return gameBoard.getSpecificSquare(curPlayer.CurPos);
        }
        #endregion

        #region "observer functions"
        // is not used anymore because of function addplayer (which will pass "this")

        //public void attach(IObserverGUI observerGui)
        //{
        //    this.observerGuis.Add(observerGui);
        //    //curGui = observerGui;
        //}

        public void FireEventAsynchronousGUI()
        {

            EventArgs args = new EventArgs();

            Delegate[] delegates = updateGUIEvent.GetInvocationList();
            foreach (Delegate del in delegates)
            {
                updateGUIEventHandler handler = (updateGUIEventHandler)del;
                handler.BeginInvoke(this, args, null, null);
            }
        }

        public void FireEventAsynchronousGUIAction()
        {


            EventArgs args = new EventArgs();

            Delegate[] delegates = updateGUIActionEvent.GetInvocationList();
            foreach (Delegate del in delegates)
            {

                updateGUIActionEventHandler handler = (updateGUIActionEventHandler)del;
                handler.BeginInvoke(this, args, null, null);
            }
        }
        public void notifyGuis()
        {
            FireEventAsynchronousGUI();
            //foreach (KeyValuePair<cPlayer, IObserverGUI> entry in this.playerObservers)
            //{
            //    entry.Value.updateAll();
            //}
        }

        public void notifyCurPlayer()
        {
            
            //FireEventAsynchronousGUIAction();
            this.playerObservers[curPlayer].onUpdateGUIActionsEvent(this,new EventArgs() );
            
        }
        #endregion

    }
}
