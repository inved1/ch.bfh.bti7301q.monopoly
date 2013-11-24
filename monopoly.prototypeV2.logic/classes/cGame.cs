﻿using monopoly.prototypeV2.logic.classes.actions;
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
        private List<IObserverGUI> observerGuis;
        private List<cPlayer> players;
        private List<IAction> actions;
        private cPlayer curPlayer;
        private cConfig myConfig;
        private LogWriter logWriter;
        #endregion

        #region "constructor"
        public cGame()
        {
            this.myConfig = cConfig.getInstance();
            this.gameBoard = cGameBoard.getInstance();
            this.observerGuis = new List<IObserverGUI>();
            this.players = new List<cPlayer>();
            this.actions = new List<IAction>();
            this.logWriter = LogWriter.Instance;
        }
        #endregion

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
            notifyGuis();
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
        public void initGame()
        {
            curPlayer = players[0];
        }

        public void setActionsAfterMoving()
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
                else
                {
                    payRent();
                }
            }
            else if (curSquare.GetType() == typeof(cCommunitySquare) ||
                     curSquare.GetType() == typeof(cActionSquare))
            {

            }
            else if (curSquare.GetType() == typeof(cTaxSquare))
            {

            } else if (curSquare.GetType() == typeof(cStartSquare) ||
                       curSquare.GetType() == typeof(cPrisonVisitorSquare) ||
                       curSquare.GetType() == typeof(cFreeParkSquare)) {
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
            curPlayer.CurPos = ((curPlayer.CurPos + valueToMove) % 41);
            if (checkPlayerPassingStart(tmpCurPos, valueToMove))
            {
                curPlayer.addMoney(9999); // tbd
            }
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " moved to " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            notifyGuis();
            setActionsAfterMoving();
        }

        public void payRent()
        {
            ISquare curSquare = gameBoard.getSpecificSquare(curPlayer.CurPos);
            int rent = Convert.ToInt32(curSquare.GetType().GetProperty("CurrentRent").GetValue(curSquare));
            cPlayer owner = (cPlayer)curSquare.GetType().GetProperty("Owner").GetValue(curSquare);

            curPlayer.spendMoney(rent);
            owner.addMoney(rent);
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " paid rent to " + owner.Name + " for " + gameBoard.getSpecificSquare(curPlayer.CurPos).ctrlName);
            notifyGuis();
        }

        public void playerBuysSquare()
        {
            ISquare curSquare = gameBoard.getSpecificSquare(curPlayer.CurPos);
            try
            {
                curPlayer.spendMoney(Convert.ToInt32(curSquare.GetType().GetProperty("Cost").GetValue(curSquare)));
                curSquare.GetType().GetProperty("Owner").SetValue(curSquare, curPlayer);
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
            curPlayer = players[((players.IndexOf(curPlayer) + 1) % players.Count)];
            setDefaultActions();
            logWriter.WriteLogQueue("Player " + curPlayer.Name + " has ended his turn.");
            notifyGuis();
            //notifyCurPlayer();
        }

        public void playerGivesUp()
        {
            //set owner of the squares to null 
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
