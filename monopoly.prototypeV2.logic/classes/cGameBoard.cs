﻿using monopoly.prototypeV2.logic.classes.squares;
using monopoly.prototypeV2.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cGameBoard
    {

        #region "vars"
        private static cGameBoard myInstance;
        private Dictionary<int,ISquare>  mySquares;
        private Dictionary<cCardDeck.cardType, cCardDeck> myCardDecks;
        private Dictionary<String, cStreet> myStreets;
        private cConfig myConfig;
        private List<cRegularSquare> myRegularSquares; //easy access 

        #endregion


        #region "constructor/singelton"
        private cGameBoard()
        {
            this.myConfig = cConfig.getInstance;

            initStreets();
            
            initSquares();
            initCardDecks();
            
            

        }

        public static cGameBoard getInstance()
        {
            if (myInstance == null)
            {
                myInstance = new cGameBoard();
            }
            return myInstance;
        }
        #endregion

        #region "functions"
        private void initCardDecks()
        {
            this.myCardDecks = new Dictionary<cCardDeck.cardType, cCardDeck>();
            this.myCardDecks.Add(cCardDeck.cardType.Actioncard, new cCardDeck(cCardDeck.cardType.Actioncard));
            this.myCardDecks.Add(cCardDeck.cardType.Communitycard, new cCardDeck(cCardDeck.cardType.Communitycard));

        }

        private void initStreets()
        {
            this.myStreets = new Dictionary<string, cStreet>();
            foreach(KeyValuePair<String, List<int>> entry in this.myConfig.Streets)
            {
                this.myStreets.Add(entry.Key, new cStreet(entry.Key, entry.Value));
            }
         
        }



        private void initSquares()
        {
            this.mySquares = new Dictionary<int, ISquare>();
            this.myRegularSquares = new List<cRegularSquare>();
       
            foreach (KeyValuePair<string, Dictionary<String, String>> entry in this.myConfig.RegularSquares)
            {
                //ugly workaround so far
                Dictionary<int, int> d = new Dictionary<int, int>();
                foreach (KeyValuePair<string, string> e2 in entry.Value)
                {
                    if (e2.Key == "0" || e2.Key == "1" || e2.Key == "2" || e2.Key == "3" || e2.Key == "4" || e2.Key == "5")
                    {
                        d.Add(Convert.ToInt32(e2.Key), Convert.ToInt32(e2.Value));
                    }
                }
                this.mySquares.Add(Convert.ToInt32(entry.Value["id"]),
                                    new cRegularSquare(entry.Value["Name"],
                                                        entry.Value["Color"],
                                                        Convert.ToInt32(entry.Value["cost"]),
                                                        Convert.ToInt32(entry.Value["priceHouse"]),
                                                        Convert.ToInt32(entry.Value["priceHotel"]),
                                                        Convert.ToInt32(entry.Value["deposit"]),
                                                        d));
                
            }
            this.mySquares.Add(0, new cStartSquare("Start", "grey"));
            this.mySquares.Add(2, new cCommunitySquare("Kanzlei", "grey"));
            foreach(KeyValuePair<String,Dictionary<string,string>> entry in this.myConfig.TaxSquares)
            {
                if (entry.Key == "1")
                {
                    
                    this.mySquares.Add(4, new cTaxSquare(entry.Value["Name"], entry.Value["Color"], Convert.ToInt32(entry.Value["cost"])));
                }
                if (entry.Key == "2")
                {
                    this.mySquares.Add(38, new cPayTaxesSquare(entry.Value["Name"], entry.Value["Color"],  Convert.ToInt32(entry.Value["cost"])));
                }
            }
            

            // read from config here !!! todo
            this.mySquares.Add(5, new cTrainStationSquare("Vereinigte Privatbahnen Union", "grey"));
            this.mySquares.Add(7, new cActionSquare("Chance", "grey"));
            this.mySquares.Add(10, new cPrisonVisitorSquare("Gefägniss Besuch", "grey"));
            //prison new 99 - for testing
            this.mySquares.Add(99, new cPrisonSquare("Gefängniss", "orange"));
            this.mySquares.Add(12, new cWaterPowerSquare("Elektrizitätswerke", "grey"));
            this.mySquares.Add(15, new cTrainStationSquare("Vereinigte Bergbahnen AG", "grey"));
            this.mySquares.Add(17, new cActionSquare("Kanzlei", "grey"));
            this.mySquares.Add(20, new cFreeParkSquare("Freier Parkplatz", "grey"));
            this.mySquares.Add(22, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(25, new cTrainStationSquare("Überlandbahnen", "grey"));
            this.mySquares.Add(28, new cWaterPowerSquare("Wasserwerke", "grey"));
            this.mySquares.Add(30, new cGoToPrisonSquare("Ins Gefängniss", "grey"));
            this.mySquares.Add(33, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(35, new cTrainStationSquare("Vereinigte Schwebebahnen AG", "grey"));
            this.mySquares.Add(36, new cCommunitySquare("Chance", "grey"));
           



            foreach (KeyValuePair<int, ISquare> entry in this.mySquares)
            {
                if (entry.Value.GetType() == typeof(cRegularSquare))
                {
                    this.myRegularSquares .Add((cRegularSquare)entry.Value);
                }
            }

        }

        public Dictionary<int, ISquare> getSquares()
        {
            return this.mySquares;
        }

        public List<cRegularSquare> getRegularSquares()
        {
            return this.myRegularSquares;
        }

        public ISquare getSpecificSquare(int pos)
        {
            return this.mySquares[pos];
        }

        public Dictionary<cCardDeck.cardType, cCardDeck> getCardDecks()
        {
            return this.myCardDecks;
        }

        public cCardDeck getSpecificCardDeck(cCardDeck.cardType type)
        {
            return this.myCardDecks[type];
        }

        public void refreshPlayerPositions()
        {

        }
        #endregion
    }
}
