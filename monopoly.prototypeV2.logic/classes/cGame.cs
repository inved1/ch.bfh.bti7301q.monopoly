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
       // private List<IObserverGUI> observerGuis;
        private List<IAction> actions;
        private cPlayer curPlayer;
        private cConfig myConfig;
        private LogWriter logWriter;
        private Dictionary<cPlayer, IObserverGUI> playerObservers;
        #endregion

        #region "constructor"
        public cGame()
        {
            this.myConfig = cConfig.getInstance;
            this.gameBoard = cGameBoard.getInstance();
           // this.observerGuis = new List<IObserverGUI>();
            this.actions = new List<IAction>();
            this.logWriter = LogWriter.Instance;
            this.playerObservers = new Dictionary<cPlayer, IObserverGUI>();
        }
        #endregion

        public cGameBoard GameBoard
        {
            get { return this.gameBoard; }
        }

        public cPlayer CurPlayer
        {
            get { return this.curPlayer; }
            set { this.curPlayer = value; }
        }

        public void addPlayer(cPlayer player, IObserverGUI obs)
        {
            if (this.playerObservers.Keys.Count < 8)
            {
                this.playerObservers.Add(player, obs);

                notifyGuis();
            }
            else
            {
                throw new Exception("Max. 8 Spieler möglich.");
            }
        }

        public List<cPlayer> Players
        {
            get { return this.playerObservers.Keys.ToList(); }
        }

        public List<IAction> Actions
        {
            get { return actions; }
        }

        #region "game control functions"
        public void initGame()
        {
            curPlayer = this.playerObservers.Keys.First();


        }
        public ISquare getSpecificSquare(int pos)
        {
            return this.gameBoard.getSpecificSquare(pos);
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
                ICard card = cardDeck.getNextCard();
                // !!! show card somehow !!!
                actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cActionSquare))
            {
                cardDeck = gameBoard.getSpecificCardDeck(cCardDeck.cardType.Actioncard);
                ICard card = cardDeck.getNextCard();
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
            //notifyCurPlayer();
        }

        public void setDefaultActions()
        {
            actions.Clear();
            actions.Add(new cActionRoll(this));
            actions.Add(new cActionGiveUp(this));
        }

        public void moveCurPlayer(int valueToMove)
        {
            int tmpCurPos = curPlayer.CurPos; //remember for checking if player passed start

            Debug.Write(curPlayer.Name + ", tmpCurPos: " + tmpCurPos);

            curPlayer.CurPos = ((curPlayer.CurPos + valueToMove) % 41);

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
        }

        public void playerEndsTurn()
        {
            curPlayer.RolledDoubles = 0;
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " has ended his turn.");
            Debug.Write("oldPlayer: " + curPlayer.Name);
            // use here dictionary
            
            //curPlayer = this.playerObservers.Keys.ToList()[((players.IndexOf(curPlayer) + 1) % players.Count)];
            Debug.WriteLine(", newPlayer: " + curPlayer.Name);
            setDefaultActions();
            notifyGuis();
            //notifyCurPlayer();
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

        public void notifyGuis()
        {
            foreach (KeyValuePair<cPlayer,IObserverGUI> entry in this.playerObservers )
            {
                entry.Value.updateAll();
            }
        }

        public void notifyCurPlayer()
        {
            this.playerObservers[curPlayer].updateActions();
        }
        #endregion

    }
}
