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
        private cMessage myMessages;
        private cChat  myChat;

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
            this.myMessages = cMessage.getInstance;
            this.myChat = cChat.getInstance;
            this.playerObservers = new SortedList<cPlayer, IObserverGUI>();
        }
        #endregion

        public cGameBoard GameBoard
        {
            get { return this.gameBoard; }
        }

        public cMessage gameMessages
        {
            get { return this.myMessages; }
        }

        public cChat gameChat
        {
            get { return this.myChat; }
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
        public List<cWaterPowerSquare > WaterPowerSquaresByPlayer(cPlayer player)
        {
            return gameBoard.getWaterPowerSquaresByPlayer(player);
        }

        public List<IAction> Actions
        {
            get { return actions; }
        }

        #region "game control functions"
        public void initGame()
        {
            this.myMessages.addMessage("Spiel gestartet - alle Spieler würfeln für die Reihenfolge zu bestimmen");

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

            this.myMessages.addMessage("Spiel gestartet");
            /*ISquare square = gameBoard.getSpecificSquare(1);
            square.GetType().GetProperty("Owner").SetValue(square, curPlayer);
            square = gameBoard.getSpecificSquare(3);
            square.GetType().GetProperty("Owner").SetValue(square, curPlayer);
            square = gameBoard.getSpecificSquare(5);
            square.GetType().GetProperty("Owner").SetValue(square, curPlayer);
            */

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
            //Debug.Write("oldCurPlayer: " + curPlayer.Name);
            this.curPlayer = playerObservers.Keys.ElementAt((playerObservers.IndexOfKey(curPlayer) + 1) % playerObservers.Count);
            //Debug.Write(", newCurPlayer: " + curPlayer.Name);
            this.myMessages.addMessage("Neuer Spieler ist: "+this.curPlayer.Name );
        }

        // !!! initialize all actions in config? !!!
        public void setActionsAfterMoving()
        {
            actions.Clear();
            cCardDeck cardDeck;
            ISquare curSquare = getCurSquare();
            if (curSquare is IBuyable)
            {
                if (checkSquareAvailability(curSquare))
                {
                    IBuyable obj = (IBuyable )curSquare;
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
            else if (curSquare.GetType() == typeof(cPrisonSquare ))
            {
                //nothing, will never happen (since prison is 99 )
                actions.Add(new cActionEndTurn(this));
            }
            else if(curPlayer.GetType() == typeof(cGoToPrisonSquare ))
            {
                actions.Add(new cActionGoToPrison(this));
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
                if (curPlayer.PrisonFreeCards > 0) {
                    actions.Add(new cActionPrisonOutCard(this));
                }
                actions.Add(new cActionRoll(this));
                actions.Add(new cActionGiveUp(this));
            }
            else
            {
                Dictionary<cStreet, Dictionary<ISquare, int>> dic = readSquaresForRealEstate();
                if (dic.Count > 0)
                {
                    Debug.WriteLine("action for buying");
                }
                actions.Add(new cActionRoll(this));
                actions.Add(new cActionGiveUp(this));
            }
        }

        public void determineStartPlayer(int rolledDots)
        {
            this.myMessages.addMessage("Bestimme Startspieler, Spieler "+this.curPlayer.Name +" hat "+rolledDots.ToString() + " gewürfelt");
            this.curPlayer.RolledInitDots = rolledDots;
            if (this.startPlayer == null)
            {
                //Debug.Write("oldStartPlayer: ");
                this.startPlayer = this.curPlayer;
                //Debug.WriteLine(", newStartPlayer: " + this.startPlayer.Name);
            }
            else
            {
                //Debug.Write("oldStartPlayer: " + this.startPlayer.Name + ", startPlayer: " + this.startPlayer.RolledInitDots + ", curPlayer: " + this.curPlayer.RolledInitDots);
                if (this.curPlayer.RolledInitDots > this.startPlayer.RolledInitDots)
                {
                    this.myMessages.addMessage("Spieler "+this.curPlayer.Name+" hat mehr gewürfelt als "+this.startPlayer.Name+", neuer Startspieler"  );
                    this.startPlayer = this.curPlayer;
                }
                //Debug.WriteLine(", newStartPlayer: " + this.startPlayer.Name);
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
            //}
        }

        public void moveCurPlayer(int valueToMove)
        {
            int tmpCurPos = this.curPlayer.CurPos; //remember for checking if player passed start

            //Debug.Write(curPlayer.Name + ", tmpCurPos: " + tmpCurPos);
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " zieht von " + 
                                        this.gameBoard.getSpecificSquare(this.curPlayer.CurPos).ctrlName + " auf " +
                                        this.gameBoard.getSpecificSquare(((this.curPlayer.CurPos + valueToMove) % 40)).ctrlName  );

            //the move
            this.curPlayer.CurPos = ((this.curPlayer.CurPos + valueToMove) % 40);

            //Debug.Write(", curPos: " + curPlayer.CurPos + " (" + gameBoard.getSpecificSquare(this.curPlayer.CurPos).ctrlName + ")");

            if (checkPlayerPassingStart(tmpCurPos, valueToMove))
            {
                //Debug.Write(", passingStart: true");
                this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " hat Start passiert");
                this.curPlayer.addMoney(Convert.ToInt32(cConfig.getInstance.Game["MoneyStart"]));
           
            }
            if (checkPlayerHitsStart(tmpCurPos, valueToMove))
            {
                this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " hat Start getroffen");
                curPlayer.addMoney(Convert.ToInt32(cConfig.getInstance.Game["MoneyStart"])*2);
           
            }
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " moved to " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            notifyGuis();
            
            setActionsAfterMoving();

        }

        public void playerPaysRent()
        {
            ISquare curSquare = getCurSquare();
            //check ifts my square
            cPlayer owner = (cPlayer)curSquare.GetType().GetProperty("Owner").GetValue(curSquare);
            if (owner == this.curPlayer)
            {
                this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " besitzt dieses Grundstück bereits, keine Miete fällig");
                logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " owns this property - no need to pay rent. " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            }
            else
            {
                int rent = Convert.ToInt32(curSquare.GetType().GetProperty("CurrentRent").GetValue(curSquare));


                //Debug.WriteLine("owner: " + owner.Name);
                //Debug.WriteLine("oldAmountCurPlayer: " + curPlayer.Amount + ", oldAmountOwner: " + owner.Amount);
                this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " zahlt Miete [" + rent.ToString() + "] an Spieler " + owner.Name);
                
                curPlayer.spendMoney(rent);
                owner.addMoney(rent);
                //Debug.WriteLine("newAmountCurPlayer: " + curPlayer.Amount + ", newAmountOwner: " + owner.Amount);
                logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " paid rent to " + owner.Name + " for " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            }
           
            notifyGuis();
        }

        public void playerCardAction(ICard card)
        {
            int sum = 0;
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " führt Karte [" + card.Text + "] aus");
            switch(card.Command)
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
                        sum += c.Hotels  * priceHotel;
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
            //Debug.Write("oldAmount: " + curPlayer.Amount);
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " zahlt Steuern [" + tax.ToString() + "]"); 
            curPlayer.spendMoney(tax);
            //Debug.WriteLine(", newAmount: " + curPlayer.Amount);
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
            cPlayer owner; // for debugging
            try
            {
                cost = Convert.ToInt32(curSquare.GetType().GetProperty("price").GetValue(curSquare));
                //Debug.Write("oldAmount: " + curPlayer.Amount + ", cost: " + cost);
                this.curPlayer.spendMoney(cost);
                //Debug.Write(", newAmount: " + curPlayer.Amount);
                curSquare.GetType().GetProperty("Owner").SetValue(curSquare, this.curPlayer);

                this.myMessages.addMessage("Spieler " + this.curPlayer.Name  + " hat " + this.gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName + " gekauft");
                owner = (cPlayer)curSquare.GetType().GetProperty("Owner").GetValue(curSquare);
//                Debug.WriteLine(", newOwner: " + owner.Name);
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

        public void playerEndsTurn()
        {
            curPlayer.RolledDoubles = 0;
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " hat seinen Zug beendet");
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " has ended his turn.");
           // Debug.Write("oldPlayer: " + curPlayer.Name);
            //curPlayer = this.playerObservers.Keys.ToList()[((players.IndexOf(curPlayer) + 1) % players.Count)];
            setNextCurPlayer();
            //Debug.WriteLine(", newPlayer: " + curPlayer.Name);
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }
        public void playerUsesPrisonOutCard()
        {
            curPlayer.PrisonFreeCards = -1;
            curPlayer.inPrison = false;
            //Debug.WriteLine("Spieler hat sich Freikarte aus Gefäniss gebraucht: " + curPlayer.Name);
            logWriter.WriteLogQueue("Player " + this.curPlayer.Name + " hat sich Freikarte aus Gefäniss gebraucht.");
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " hat sich Freikarte aus Gefäniss gebraucht.");
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }

        public void playerBuysFree()
        {
            curPlayer.spendMoney(50);
            curPlayer.inPrison = false;
            //Debug.WriteLine("SPieler hat sich freigekauft: " + curPlayer.Name);
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " hat sich freigekauft.");
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " hat sich aus dem Gefäniss gekauft.");
            setDefaultActions();
            notifyGuis();
            notifyCurPlayer();
        }

        public void playerTrades(ISquare obj, cPlayer owner, cPlayer newOwner, int amount)
        {
            obj.Owner  = newOwner;
            owner.addMoney(amount);
            newOwner.spendMoney(amount);
            //Debug.WriteLine("SPieler "+owner.Name+" hat Objekt "+obj.ctrlName+ " an Spieler"+newOwner.Name +" verkauft");
            logWriter.WriteLogQueue("SPieler " + owner.Name + " hat Objekt " + obj.ctrlName + " an Spieler" + newOwner.Name + " verkauft");
            this.myMessages.addMessage("Spieler " + owner.Name + " hat Objekt " + obj.ctrlName + " an Spieler" + newOwner.Name + " verkauft");
        }
        public void playerGoesToPrison()
        {
            curPlayer.inPrison = true;
            logWriter.WriteLogQueue("Spieler " + this.curPlayer.Name + " ist im Gefängniss gelandet");
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " ist im Gefägniss gelandet");
            notifyGuis();
            setNextCurPlayer();
            setDefaultActions();
            notifyCurPlayer();
        }

        public void playerGivesUp()
        {
            ISquare square;
            cPlayer owner;
            this.myMessages.addMessage("Spieler " + this.curPlayer.Name + " gibt auf.");
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
            //Debug.WriteLine(curSquare.GetType().GetProperty("Owner").GetValue(curSquare));
            
            if (curSquare.GetType().GetProperty("Owner").GetValue(curSquare) == null)
            {
                return true;
            }
            return false;
        }

        public Dictionary<cStreet, Dictionary<ISquare, int>> readSquaresForRealEstate()
        {
            cStreet street;
            ISquare square;
            int priceRealEstate;
            cPlayer owner;
            Boolean hasFullStreet;
            Dictionary<ISquare, int> ownedSquares = new Dictionary<ISquare,int>();

            Dictionary<cStreet, Dictionary<ISquare, int>> squaresForRealEstate = new Dictionary<cStreet, Dictionary<ISquare, int>>();
            foreach (KeyValuePair<String,cStreet> pair in this.gameBoard.getStreets())
            {
                hasFullStreet = true;
                street = pair.Value;
                Debug.WriteLine(street.getName());
                if (!street.getName().Equals("black")) {
                    foreach (int squareNr in street.getOwnedSquares())
                    {
                        square = this.gameBoard.getSpecificSquare(squareNr);
                        //!!!! check if player has to buy house or hotel!
                        priceRealEstate = Convert.ToInt32(square.GetType().GetProperty("PriceHouse").GetValue(square));
                        owner = (cPlayer)square.GetType().GetProperty("Owner").GetValue(square);

                        ownedSquares.Add(square, priceRealEstate);

                        if ((owner == null) || (owner != this.curPlayer))
                        {
                            ownedSquares.Clear();
                            hasFullStreet = false;
                            break;
                        }
                    }
                    if (hasFullStreet)
                    {
                        squaresForRealEstate.Add(street, ownedSquares);
                        Debug.WriteLine(squaresForRealEstate);
                    }
                }
                
            }
            return squaresForRealEstate;
        }

        public bool checkPlayerPassingStart(int prevPos, int valueToMove)
        {
            //this check runs after moving to the new position
           // Debug.WriteLine(", prevPos: " + prevPos + ", valueToMove: " + valueToMove);
           // Debug.WriteLine("(" + curPlayer.CurPos + " + " + valueToMove + " % 41 < " + prevPos + ")");
            if ((((prevPos + valueToMove) % 40) < prevPos) && (((prevPos + valueToMove) % 40) != 0 ))
            {
                return true;
            }
            return false;
        }

        public bool checkPlayerHitsStart(int prevPos, int valueToMove)
        {
            //  Debug.WriteLine(", prevPos: " + prevPos + ", valueToMove: " + valueToMove);
            // Debug.WriteLine("(" + curPlayer.CurPos + " + " + valueToMove + " % 41 < " + prevPos + ")");
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
                if (del.Target != null) { 
                updateGUIEventHandler handler = (updateGUIEventHandler)del;
                handler.BeginInvoke(this, args, null, null);
                //handler.Invoke(this, args);
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
                if (del.Target != null) { 
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

        public void notifyCurPlayer()
        {
            
            FireEventAsynchronousGUIAction();
           //this.playerObservers[curPlayer].onUpdateGUIActionsEvent(this,new EventArgs() );
            
        }
        #endregion

    }
}
