using monopoly.logic.classes.actions;
using monopoly.logic.classes.squares;
using monopoly.logic.interfaces;
using monopoly.logic.util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes
{
    public class cGame : MarshalByRefObject
    {
        #region "vars"
        private cGameBoard gameBoard;
        private List<IAction> actions;
        private Dictionary<cRegularSquare,int > myTradeCards;

        private cPlayer startPlayer;
        private cPlayer curPlayer;
        private cPlayer curTradePlayer;
        private cConfig myConfig;
        private LogWriter logWriter;
        private SortedDictionary<int, string> myChat;
        public SortedDictionary<int, String> myMsgs;
        public int myMsgKey = 1;
        public int myChatKey = 1;
        //private List<cRegularSquare> squaresToBuildOnForCurPlayer;
        private Dictionary<int, ISquare> squaresToBuildOnForCurPlayer;

        // !!! only public for testing !!!
        private SortedList<cPlayer, IObserverGUI> playerObservers;
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
            this.myTradeCards = new Dictionary<cRegularSquare , int>();
            this.logWriter = LogWriter.Instance;
            this.myChat = new SortedDictionary<int, string>();
            this.playerObservers = new SortedList<cPlayer, IObserverGUI>();
            this.squaresToBuildOnForCurPlayer = new Dictionary<int, ISquare>();
            this.myMsgs = new SortedDictionary<int, string>();
        }
        #endregion

        public cGameBoard GameBoard
        {
            get { return this.gameBoard; }
        }

        public void addMsg(String txt)
        {
            addMessage(txt);  
        }


        public void addChatMsg(string name,string txt)
        {
            addChat(name,txt);
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

        public cPlayer CurTradePlayer
        {
            get { return this.curTradePlayer; }
            set { this.curTradePlayer = value; }
        }

        public SortedList<cPlayer, IObserverGUI> PlayerObservers
        {
            get { return this.playerObservers; }
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

        public delegate void updateGUITradeEventHandler(object sender, EventArgs e);
        public event updateGUITradeEventHandler updateGUITradeEvent = delegate { };

        public void addPlayer(cPlayer player, IObserverGUI obs)
        {
            if (this.playerObservers.Keys.Count < 8)
            {

                this.playerObservers.Add(player, obs);

                this.updateGUIEvent += obs.onUpdateGUIEvent;
                this.updateGUIActionEvent += obs.onUpdateGUIActionsEvent;
                this.updateGUITradeEvent += obs.onUpdateGUITradeEvent; 

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

        public List<cRegularSquare> RegularSquaresByPlayer(cPlayer player)
        {
            return gameBoard.getRegularSquaresByPlayer(player);
        }

        public List<cTrainStationSquare> TrainStationSquaresByPlayer(cPlayer player)
        {
            return gameBoard.getTrainStationSquaresByPlayer(player);
        }
        public List<cWaterPowerSquare> WaterPowerSquaresByPlayer(cPlayer player)
        {
            return gameBoard.getWaterPowerSquaresByPlayer(player);
        }

        public List<IAction> Actions
        {
            get { return actions; }
        }

        public  Dictionary<cRegularSquare ,int > TradeCards
        {
            get { return this.myTradeCards; }
            
        }
        public void addTradeCard(cRegularSquare card, int val, cPlayer player )
        {
            this.TradeCards.Add(card,val );
            this.curTradePlayer = player;
        }


        public string strOutput()
        {
            String r = "";
            if (this.myMsgs != null)
            {
                foreach (KeyValuePair<int, string> entry in this.myMsgs)
                {
                    r = r + "->" + entry.Value + System.Environment.NewLine;
                }
            }

            return r;
        }
        public string strChatOutput()
        {
            String r = "";
            if (this.myChat != null)
            {
                foreach (KeyValuePair<int, string> entry in this.myChat)
                {
                    r = r + "->" + entry.Value + System.Environment.NewLine;
                }
            }

            return r;
        }
        public void addMessage(String txt)
        {
            this.myMsgs.Add(this.myMsgKey , txt);
            this.myMsgKey  += 1;
        }

        public void addChat(String name,String txt)
        {
            this.myChat.Add(this.myChatKey, name + ": " + txt);
            this.myChatKey += 1;
        }
        public Dictionary<int, ISquare> SquaresToBuildOnForCurPlayer
        {
            get { return this.squaresToBuildOnForCurPlayer; }
        }



        #region "game control functions"
        public void initGame()
        {
            this.addMessage("Spiel gestartet - alle Spieler würfeln für die Reihenfolge zu bestimmen");

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

        public void startGame()
        {
            this.gameStatus = cGame.eGameStatus.Running;

            this.addMessage("Spiel gestartet");
            ISquare square = gameBoard.getSpecificSquare(1);
            square.GetType().GetProperty("Owner").SetValue(square, curPlayer);
            square = gameBoard.getSpecificSquare(3);
            square.GetType().GetProperty("Owner").SetValue(square, curPlayer);
            square = gameBoard.getSpecificSquare(5);
            square.GetType().GetProperty("Owner").SetValue(square, curPlayer);

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
            this.curPlayer = playerObservers.Keys.ElementAt((playerObservers.IndexOfKey(curPlayer) + 1) % playerObservers.Count);
            this.addMessage("Neuer Spieler ist: " + this.curPlayer.Name);
        }

        public void setActionsAfterMoving()
        {
            actions.Clear();
            myTradeCards.Clear();
            this.curTradePlayer = null;
            cCardDeck cardDeck;
            ISquare curSquare = getCurSquare();
            if (curSquare is IBuyable)
            {
                if (checkSquareAvailability(curSquare))
                {
                    IBuyable obj = (IBuyable)curSquare;
                    actions.Add(new cActionBuySquare(this, obj.price));
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

                actions.Add(new cActionPlayCard(this, card));
                //actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cActionSquare))
            {
                cardDeck = gameBoard.getSpecificCardDeck(cCardDeck.cardType.Actioncard);
                ICard card = cardDeck.getNextCard();

                actions.Add(new cActionPlayCard(this, card));
                //actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cTaxSquare))
            {
                playerPaysTax();
                //actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cStartSquare) ||
                     curSquare.GetType() == typeof(cPrisonVisitorSquare) ||
                     curSquare.GetType() == typeof(cFreeParkSquare))
            {
                actions.Add(new cActionEndTurn(this));
            }
            else if (curSquare.GetType() == typeof(cPrisonSquare))
            {
                //nothing, will never happen (since prison is 99 )
                actions.Add(new cActionEndTurn(this));
            }
            else if (curPlayer.GetType() == typeof(cGoToPrisonSquare))
            {
                actions.Add(new cActionGoToPrison(this));
                actions.Add(new cActionEndTurn(this));
            }
            actions.Add(new cActionGiveUp(this));
            notifyCurPlayer();
        }

        public void setDefaultActions()
        {
            actions.Clear();
            if (curPlayer.inPrison)
            {
                actions.Add(new cActionBuyFree(this));
                if (curPlayer.PrisonFreeCards > 0)
                {
                    actions.Add(new cActionPrisonOutCard(this));
                }
                actions.Add(new cActionRoll(this));
                actions.Add(new cActionGiveUp(this));
            }
            else
            {
                readSquaresToBuildOn();
                actions.Add(new cActionRoll(this));
                actions.Add(new cActionGiveUp(this));
            }
        }

        public void determineStartPlayer(int rolledDots)
        {
            this.addMessage("Bestimme Startspieler, Spieler " + this.curPlayer.Name + " hat " + rolledDots.ToString() + " gewürfelt");
            this.curPlayer.RolledInitDots = rolledDots;
            if (this.startPlayer == null)
            {
                this.startPlayer = this.curPlayer;
            }
            else
            {
                if (this.curPlayer.RolledInitDots > this.startPlayer.RolledInitDots)
                {
                    this.addMessage("Spieler " + this.curPlayer.Name + " hat mehr gewürfelt als " + this.startPlayer.Name + ", neuer Startspieler");
                    this.startPlayer = this.curPlayer;
                }
            }

            if (this.playerObservers.Keys.Last() == this.curPlayer)
            {
                startGame();
            }
            else
            {
                setNextCurPlayer();
                setDefaultActions();
                notifyCurPlayer();
            }
        }

        public void moveCurPlayer(int valueToMove)
        {
            int tmpCurPos = this.curPlayer.CurPos; //remember for checking if player passed start

            this.addMessage("Spieler " + this.curPlayer.Name + " zieht von " +
                                        this.gameBoard.getSpecificSquare(this.curPlayer.CurPos).ctrlName + " auf " +
                                        this.gameBoard.getSpecificSquare(((this.curPlayer.CurPos + valueToMove) % 40)).ctrlName);

            this.curPlayer.CurPos = ((this.curPlayer.CurPos + valueToMove) % 40);

            if (checkPlayerPassingStart(tmpCurPos, valueToMove))
            {
                this.addMessage("Spieler " + this.curPlayer.Name + " hat Start passiert");
                this.curPlayer.addMoney(Convert.ToInt32(cConfig.getInstance.Game["MoneyStart"]));

            }
            if (checkPlayerHitsStart(tmpCurPos, valueToMove))
            {
                this.addMessage("Spieler " + this.curPlayer.Name + " hat Start getroffen");
                curPlayer.addMoney(Convert.ToInt32(cConfig.getInstance.Game["MoneyStart"]) * 2);

            }
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " moved to " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            notifyGuis();

            setActionsAfterMoving();

        }

        public void playerPaysRent()
        {
            ISquare curSquare = getCurSquare();
            cPlayer owner = (cPlayer)curSquare.GetType().GetProperty("Owner").GetValue(curSquare);
            if (owner == this.curPlayer)
            {
                this.addMessage("Spieler " + this.curPlayer.Name + " besitzt dieses Grundstück bereits, keine Miete fällig");
                logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " owns this property - no need to pay rent. " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            }
            else
            {
                int rent = 0;
               
                if (curSquare.GetType() == typeof(cWaterPowerSquare)){
                    //need some multiply here
                    cWaterPowerSquare o = (cWaterPowerSquare)curSquare;
                    rent = o.multiplier[this.gameBoard.getWaterPowerSquaresByPlayer(this.curPlayer).Count] * (this.curPlayer.lastDice1 + this.curPlayer.lastDice2); 
                    this.addMessage("Spieler " + this.curPlayer.Name + " muss bei WasserPowerSquare folgenden Betrag zahlen: "+rent.ToString());
                }
                if (curSquare.GetType() == typeof(cTrainStationSquare))
                {
                    cTrainStationSquare o = (cTrainStationSquare)curSquare;
                    rent = o.Rents[this.gameBoard.getTrainStationSquaresByPlayer(o.Owner).Count]; 
                }

                rent = Convert.ToInt32(curSquare.GetType().GetProperty("CurrentRent").GetValue(curSquare));

                this.addMessage("Spieler " + this.curPlayer.Name + " zahlt Miete [" + rent.ToString() + "] an Spieler " + owner.Name);
                this.curPlayer.spendMoney(rent);
                owner.addMoney(rent);
                logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " paid rent to " + owner.Name + " for " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            }
            notifyGuis();
        }

        public void playerCardAction(ICard card)
        {
            int sum = 0;
            this.addMessage("Spieler " + this.curPlayer.Name + " führt Karte [" + card.Text + "] aus");
            switch (card.Command)
            {
                case "pay":
                    this.curPlayer.spendMoney(Convert.ToInt32(card.Value));
                    setNextCurPlayer();
                    setDefaultActions();
                    notifyCurPlayer();
                    break;
                case "receive":
                    this.curPlayer.addMoney(Convert.ToInt32(card.Value));
                    setNextCurPlayer();
                    setDefaultActions();
                    notifyCurPlayer();
                    break;
                case "prisonfree":
                    this.curPlayer.PrisonFreeCards += 1;
                    break;
                case "movetofield":
                    this.curPlayer.CurPos = Convert.ToInt32(card.Value);
                    setActionsAfterMoving();
                    break;

                case "move":
                    moveCurPlayer(Convert.ToInt32(card.Value));
                    setActionsAfterMoving();
                    break;

                case "gotoprison":
                    playerGoesToPrison();
                    //not needed, is in "Playergoestoprison()
                    // setNextCurPlayer();
                    // setDefaultActions();
                    // notifyCurPlayer();
                    break;

                case "receivefromplayers":
                    sum = 0;
                    foreach (cPlayer p in this.Players)
                    {
                        if (p.Name != this.curPlayer.Name)
                        {
                            p.spendMoney(Convert.ToInt32(card.Value));
                            sum += Convert.ToInt32(card.Value);
                        }
                    }
                    this.curPlayer.addMoney(sum);
                    setNextCurPlayer();
                    setDefaultActions();
                    notifyCurPlayer();
                    break;

                case "payrealestates":
                    sum = 0;
                    int priceHouse = Convert.ToInt32(card.Value.Split(new char[] { ';' })[0]);
                    int priceHotel = Convert.ToInt32(card.Value.Split(new char[] { ';' })[1]);

                    foreach (cRegularSquare c in this.gameBoard.getRegularSquaresByPlayer(this.curPlayer))
                    {
                        sum += c.Houses * priceHouse;
                        sum += c.Hotels * priceHotel;
                    }

                    this.curPlayer.spendMoney(sum);
                    setNextCurPlayer();
                    setDefaultActions();
                    notifyCurPlayer();
                    break;

                case "payplayers":
                    sum = 0;
                    foreach (cPlayer p in this.Players)
                    {
                        if (p.Name != this.curPlayer.Name)
                        {
                            p.addMoney(Convert.ToInt32(card.Value));
                            sum += Convert.ToInt32(card.Value);
                        }
                    }
                    this.curPlayer.spendMoney(sum);
                    setNextCurPlayer();
                    setDefaultActions();
                    notifyCurPlayer();
                    break;
                default:
                    break;

            }


        }

        public void playerPaysTax()
        {
            ISquare curSquare = getCurSquare();

            int tax = Convert.ToInt32(curSquare.GetType().GetProperty("Tax").GetValue(curSquare));
            this.addMessage("Spieler " + this.curPlayer.Name + " zahlt Steuern [" + tax.ToString() + "]");
            curPlayer.spendMoney(tax);
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " paid tax of " + tax);
            notifyGuis();
            setNextCurPlayer();
            setDefaultActions();
            notifyCurPlayer();
        }

        public void playerBuysSquare()
        {
            ISquare curSquare = getCurSquare();
            int cost;
            try
            {
                cost = Convert.ToInt32(curSquare.GetType().GetProperty("price").GetValue(curSquare));
                this.curPlayer.spendMoney(cost);
                curSquare.GetType().GetProperty("Owner").SetValue(curSquare, this.curPlayer);

                this.addMessage("Spieler " + this.curPlayer.Name + " hat " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName + " gekauft");         
                logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " has bought " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
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

        public void playerBuysRealEstate(int squareNr)
        {
            ISquare square = this.gameBoard.getSpecificSquare(squareNr);
            //should always be
            if(square.GetType() == typeof(cRegularSquare ) )
            {
                cRegularSquare o = (cRegularSquare)this.getSpecificSquare(squareNr);
                if (o.Houses <= 3) {
                    o.addHouse(1);
                }
                else if (o.Houses > 3)
                {
                    if (o.Hotels < 1) { o.addHotel(1); }
                }
                //this.gameBoard.mySquares[squareNr] = o; 

            }


            logWriter.WriteLogQueue("Player " + curPlayer.Name + " hat auf dem Grundstück " + square.ctrlName + " eine Immobilie gebaut.");
            this.addMessage("Spieler " + this.curPlayer.Name + " hat auf dem Grundstück " + square.ctrlName + " eine Immobilie gebaut.");

                      
            notifyGuis();
            setDefaultActions();
            notifyCurPlayer();
        }

        public void playerEndsTurn()
        {
            this.curPlayer.RolledDoubles = 0;
            this.addMessage("Spieler " + this.curPlayer.Name + " hat seinen Zug beendet");
            logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " has ended his turn.");
            setNextCurPlayer();
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }
        public void playerUsesPrisonOutCard()
        {
            this.curPlayer.PrisonFreeCards = -1;
            this.curPlayer.inPrison = false;
            this.curPlayer.CurPos = 10; //like prison visitor
            logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " hat sich Freikarte aus Gefäniss gebraucht.");
            this.addMessage("Spieler " + this.curPlayer.Name + " hat sich Freikarte aus Gefäniss gebraucht.");
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }

        public void playerBuysFree()
        {
            this.curPlayer.spendMoney(50);
            this.curPlayer.inPrison = false;
            this.curPlayer.CurPos = 10; //like prison visitor
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " hat sich freigekauft.");
            this.addMessage("Spieler " + this.curPlayer.Name + " hat sich aus dem Gefäniss gekauft.");
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }

        public void playerTrades()
        {
            cPlayer newowner = this.curTradePlayer;
            foreach(KeyValuePair<cRegularSquare,int> entry in this.myTradeCards){
                cPlayer owner = entry.Key.Owner;
                entry.Key.Owner = newowner;
                newowner.spendMoney(entry.Value);
                owner.addMoney(entry.Value);

                //Debug.WriteLine("SPieler "+owner.Name+" hat Objekt "+obj.ctrlName+ " an Spieler"+newOwner.Name +" verkauft");
                logWriter.WriteLogQueue("SPieler " + owner.Name + " hat Objekt " + entry.Key.ctrlName + " an Spieler" + newowner.Name + " verkauft");
                this.addMessage("Spieler " + owner.Name + " hat Objekt " + entry.Key.ctrlName + " an Spieler" + newowner.Name + " verkauft");

            }
            
        }
        public void playerGoesToPrison()
        {
            this.curPlayer.inPrison = true;
            this.curPlayer.CurPos = 99;
            logWriter.WriteLogQueue("Spieler " + this.curPlayer.Name + " ist im Gefängniss gelandet");
            this.addMessage("Spieler " + this.curPlayer.Name + " ist im Gefägniss gelandet");
            notifyGuis();
            setNextCurPlayer();
            setDefaultActions();
            notifyCurPlayer();
        }

        public void playerGivesUp()
        {
            ISquare square;
            cPlayer owner;
            this.addMessage("Spieler " + this.curPlayer.Name + " gibt auf.");
            foreach (KeyValuePair<int, ISquare> pair in gameBoard.getSquares())
            {
                square = pair.Value;
                owner = (cPlayer)square.GetType().GetProperty("Owner").GetValue(square);
                if (owner == this.curPlayer)
                {
                    square.GetType().GetProperty("Owner").SetValue(square, null);
                }
            }
        }

        public bool checkSquareAvailability(ISquare curSquare)
        {
            if (curSquare.GetType().GetProperty("Owner").GetValue(curSquare) == null)
            {
                return true;
            }
            return false;
        }

        public void readSquaresToBuildOn()
        {
            cStreet street;
            ISquare square;
            cPlayer owner;
            Boolean hasFullStreet;
            //List<ISquare> ownedSquares = new List<ISquare>();
            Dictionary<int, ISquare> ownedSquares = new Dictionary<int, ISquare>();

            this.squaresToBuildOnForCurPlayer.Clear();
            foreach (KeyValuePair<String, cStreet> pair in this.gameBoard.getStreets())
            {
                hasFullStreet = true;
                street = pair.Value;
                if (!street.getName().Equals("black"))
                {
                    foreach (int squareNr in street.getOwnedSquares())
                    {
                        square = this.gameBoard.getSpecificSquare(squareNr);
                        owner = (cPlayer)square.GetType().GetProperty("Owner").GetValue(square);

                        if ((owner == null) || (owner != this.curPlayer))
                        {
                            ownedSquares.Clear();
                            hasFullStreet = false;
                            break;
                        }
                        else
                        {
                        //prevent from inserting twice.....
                            if (!ownedSquares.ContainsKey(squareNr))
                            {
                                ownedSquares.Add(squareNr, square);
                            }
                            
                        }
                    }
                    if (hasFullStreet)
                    {
                        curPlayer.canBuild = true;

                        foreach (KeyValuePair<int, ISquare> innerPair in ownedSquares)
                        {
                            this.squaresToBuildOnForCurPlayer.Add(innerPair.Key, innerPair.Value);
                        }
                    }
                }

            }
        }

        public bool checkPlayerPassingStart(int prevPos, int valueToMove)
        {
            //this check runs after moving to the new position
            if ((((prevPos + valueToMove) % 40) < prevPos) && (((prevPos + valueToMove) % 40) != 0))
            {
                return true;
            }
            return false;
        }

        public bool checkPlayerHitsStart(int prevPos, int valueToMove)
        {
            if (((prevPos + valueToMove) % 40) == 0)
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
                if (del.Target != null)
                {
                    updateGUIEventHandler handler = (updateGUIEventHandler)del;
                    handler.BeginInvoke(this, args, null, null);
                    //handler.Invoke(this, args);
                }
            }
        }


        public void FireEventAsynchronousGUITrade()
        {
            EventArgs args = new EventArgs();
            
            Delegate[] delegates = updateGUITradeEvent.GetInvocationList();
            foreach (Delegate del in delegates)
            {
                if (del.Target != null)
                {
                    updateGUITradeEventHandler handler = (updateGUITradeEventHandler)del;
                    handler.BeginInvoke(this, args, null, null);
                }
            }
        }
        public void FireEventAsynchronousGUIAction()
        {


            EventArgs args = new EventArgs();
            // logWriter.WriteLogQueue(" + ");
            Delegate[] delegates = updateGUIActionEvent.GetInvocationList();
            foreach (Delegate del in delegates)
            {
                //logWriter.WriteLogQueue(del.Method.ToString() + " ");
                if (del.Target != null)
                {
                    updateGUIActionEventHandler handler = (updateGUIActionEventHandler)del;
                    handler.BeginInvoke(this, args, null, null);
                    //handler.Invoke(this, args);
                }
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

        public void notifiyTradePlayer()
        {
            FireEventAsynchronousGUITrade(); 
        }
        public void notifyCurPlayer()
        {

            FireEventAsynchronousGUIAction();
            //this.playerObservers[curPlayer].onUpdateGUIActionsEvent(this,new EventArgs() );

        }
        #endregion

    }
}
