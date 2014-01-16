using monopoly.prototypeV2.logic.classes.squares;
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
        public Dictionary<int,ISquare>  mySquares;
        private Dictionary<cCardDeck.cardType, cCardDeck> myCardDecks;
        private Dictionary<String, cStreet> myStreets;
        private cConfig myConfig;
        private List<cRegularSquare> myRegularSquares; //easy access 
        private List<cTrainStationSquare> myTrainStationSquares; // easy access
        private List<cWaterPowerSquare> myWaterPowerSquares; // and again, easy access

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
            this.myTrainStationSquares = new List<cTrainStationSquare>();
            this.myWaterPowerSquares = new List<cWaterPowerSquare>();
       
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
            foreach(KeyValuePair<String,Dictionary<string,string>> entry in this.myConfig.TaxSquares)
            {
                this.mySquares.Add(Convert.ToInt32(entry.Key), new cTaxSquare(entry.Value["Name"], entry.Value["Color"], Convert.ToInt32(entry.Value["cost"])));
            }
            

            foreach (KeyValuePair <string,Dictionary<string,string>> entry in this.myConfig.TrainSquares)
            {
                Dictionary<int, int> d = new Dictionary<int, int>();
                foreach (KeyValuePair<string, string> e2 in entry.Value)
                {
                    if (e2.Key == "1" || e2.Key == "2" || e2.Key == "3" || e2.Key == "4" || e2.Key == "5")
                    {
                        d.Add(Convert.ToInt32(e2.Key), Convert.ToInt32(e2.Value));
                    }
                }
                this.mySquares.Add(Convert.ToInt32(entry.Value["id"]), new cTrainStationSquare(entry.Value["Name"],
                                                                    entry.Value["Color"], Convert.ToInt32(entry.Value["cost"]), d));

            }
            

            
            foreach(KeyValuePair<string,Dictionary<string,string>> entry in this.myConfig.WaterPowerSquares  )
            {
                Dictionary<int, int> d = new Dictionary<int, int>();
                foreach (KeyValuePair<string, string> e2 in entry.Value)
                {
                    if (e2.Key == "1" || e2.Key == "2")
                    {
                        d.Add(Convert.ToInt32(e2.Key), Convert.ToInt32(e2.Value));
                    }
                }
                this.mySquares.Add(Convert.ToInt32(entry.Value["id"]), new cWaterPowerSquare(entry.Value["Name"],
                                                                    entry.Value["Color"], Convert.ToInt32(entry.Value["cost"]), d ));
            }

            this.mySquares.Add(0, new cStartSquare("Start", "grey"));
            this.mySquares.Add(2, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(7, new cActionSquare("Chance", "grey"));
            this.mySquares.Add(10, new cPrisonVisitorSquare("Gefägniss Besuch", "grey"));
            this.mySquares.Add(17, new cActionSquare("Kanzlei", "grey"));
            this.mySquares.Add(20, new cFreeParkSquare("Freier Parkplatz", "grey"));
            this.mySquares.Add(22, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(30, new cGoToPrisonSquare("Ins Gefängniss", "grey"));
            this.mySquares.Add(33, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(36, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(99, new cPrisonSquare("Gefängniss", "orange"));



            foreach (KeyValuePair<int, ISquare> entry in this.mySquares)
            {
                if (entry.Value.GetType() == typeof(cRegularSquare))
                {
                    this.myRegularSquares .Add((cRegularSquare)entry.Value);
                }
                else if (entry.Value.GetType() == typeof(cWaterPowerSquare))
                {
                    this.myWaterPowerSquares.Add((cWaterPowerSquare)entry.Value);
                }
                else if (entry.Value.GetType() == typeof(cTrainStationSquare))
                {
                    this.myTrainStationSquares.Add((cTrainStationSquare)entry.Value);
                }
            }

        }

        public Dictionary<String, cStreet> getStreets()
        {
            return this.myStreets;
        }

        public Dictionary<int, ISquare> getSquares()
        {
            return this.mySquares;
        }

        public List<cRegularSquare> getRegularSquares()
        {
            return this.myRegularSquares;
        }

        public List<cRegularSquare > getRegularSquaresByPlayer(cPlayer player )
        {
            List<cRegularSquare> l = new List<cRegularSquare>();
            foreach(cRegularSquare entry in this.myRegularSquares )
            {
                if (entry.Owner != null)
                {
                    if (entry.Owner.Name == player.Name) l.Add(entry);
                }
            }
            List<cRegularSquare> sorted = l.OrderBy(o => o.colorStreet).ToList();
            return sorted;
        }
        public List<cTrainStationSquare> getTrainStationSquaresByPlayer(cPlayer player)
        {
            List<cTrainStationSquare> l = new List<cTrainStationSquare>();
            foreach (cTrainStationSquare  entry in this.myTrainStationSquares)
            {
                if (entry.Owner != null)
                {
                    if (entry.Owner.Name == player.Name) l.Add(entry);
                }
            }
            List<cTrainStationSquare> sorted = l.OrderBy(o => o.colorStreet).ToList();
            return sorted;
        }

        public List<cWaterPowerSquare > getWaterPowerSquaresByPlayer(cPlayer player)
        {
            List<cWaterPowerSquare> l = new List<cWaterPowerSquare>();
            foreach (cWaterPowerSquare entry in this.myWaterPowerSquares)
            {
                if (entry.Owner != null)
                {
                    if (entry.Owner.Name == player.Name) l.Add(entry);
                }
            }
            List<cWaterPowerSquare> sorted = l.OrderBy(o => o.colorStreet).ToList();
            return sorted;
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


        #endregion
    }
}
