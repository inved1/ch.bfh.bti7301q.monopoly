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
        private Dictionary<int,ISquare>  mySquares;
        private Dictionary<String, cCardDeck> myCardDecks;
        private Dictionary<String, cStreet> myStreets;
        private cConfig myConfig;

        #endregion


        #region "constructor/singelton"
        private cGameBoard()
        {
            this.myConfig = cConfig.getInstance();

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
            this.myCardDecks = new Dictionary<string, cCardDeck>();
            this.myCardDecks.Add("Action", new cCardDeck(cCardDeck.cardType.Actioncard));
            this.myCardDecks.Add("Community", new cCardDeck(cCardDeck.cardType.Communitycard));

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

            this.mySquares.Add(1, new cStartSquare("Start", "grey"));
            this.mySquares.Add(2, new cRegularSquare("Chur Kornplatz", "purple"));
            this.mySquares.Add(3, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(4, new cRegularSquare("Schaffhausen Vorderegasse", "purple"));
            this.mySquares.Add(5, new cTaxSquare("Einkommenssteuer", "grey"));
            this.mySquares.Add(6, new cTrainStationSquare("Vereinigte Privatbahnen Union", "grey"));
            this.mySquares.Add(7, new cRegularSquare("Aarau Rathausplatz", "lightblue"));
            this.mySquares.Add(8, new cActionSquare("Chance", "grey"));
            this.mySquares.Add(9, new cRegularSquare("Neuenburg Place", "lightblue"));
            this.mySquares.Add(10, new cRegularSquare("Thun Hauptgasse", "lightblue"));
            this.mySquares.Add(11, new cPrisonVisitorSquare("Gefägniss Besuch", "grey"));
            this.mySquares.Add(12, new cPrisonSquare("Gefängniss", "orange"));
            this.mySquares.Add(13, new cRegularSquare("Basel Steinenvorstadt", "violett"));
            this.mySquares.Add(14, new cWaterPowerSquare("Elektrizitätswerke", "grey"));
            this.mySquares.Add(15, new cRegularSquare("Solothurn Hauptgasse", "violett"));
            this.mySquares.Add(16, new cRegularSquare("Lugano via Nassa", "violett"));
            this.mySquares.Add(17, new cTrainStationSquare("Vereinigte Bergbahnen AG", "grey"));
            this.mySquares.Add(18, new cRegularSquare("Biel Nidaugasse", "orange"));
            this.mySquares.Add(19, new cActionSquare("Kanzlei", "grey"));
            this.mySquares.Add(20, new cRegularSquare("Freiburg Bahnhofstrasse", "orange"));
            this.mySquares.Add(21, new cRegularSquare("La Chaux-de-Fonds Avenue Robert", "orange"));
            this.mySquares.Add(22, new cFreeParkSquare("Freier Parkplatz", "grey"));
            this.mySquares.Add(23, new cRegularSquare("Winterthur Bahnhofplatz", "red"));
            this.mySquares.Add(24, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(25, new cRegularSquare("St. Gallen Marktplatz", "red"));
            this.mySquares.Add(26, new cRegularSquare("Bern Bundesplatz", "red"));
            this.mySquares.Add(27, new cTrainStationSquare("Überlandbahnen", "grey"));
            this.mySquares.Add(28, new cRegularSquare("Luzern Weggisgasse", "yellow"));
            this.mySquares.Add(29, new cRegularSquare("Zürich Rennweg", "yellow"));
            this.mySquares.Add(30, new cWaterPowerSquare("Wasserwerke", "grey"));
            this.mySquares.Add(31, new cRegularSquare("Lausanne Rue de Bourg", "yellow"));
            this.mySquares.Add(32, new cGoToPrisonSquare("Ins Gefängniss", "grey"));
            this.mySquares.Add(33, new cRegularSquare("Basel Freie Strasse", "green"));
            this.mySquares.Add(34, new cRegularSquare("Genf Rue de la Croix-d'or", "green"));
            this.mySquares.Add(35, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(36, new cRegularSquare("Bern Spitalgasse", "green"));
            this.mySquares.Add(37, new cTrainStationSquare("Vereinigte Schwebebahnen AG", "grey"));
            this.mySquares.Add(38, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(39, new cRegularSquare("Lausanne Place", "blue"));
            this.mySquares.Add(40, new cPayTaxesSquare("Nachsteuer zahlen", "grey"));
            this.mySquares.Add(41, new cRegularSquare("Zürich Paradeplatz", "blue"));
            
            //foreach (KeyValuePair<string, Dictionary<String, String>> entry in this.myConfig.RegularSquares)
            //{
            //    //ugly workaround so far
            //    Dictionary<int, int> d = new Dictionary<int, int>();
            //    foreach (KeyValuePair<string, string> e2 in entry.Value)
            //    {
            //        if (e2.Key == "0" || e2.Key == "1" || e2.Key == "2" || e2.Key == "3" || e2.Key == "4" || e2.Key == "5")
            //        {
            //            d.Add(Convert.ToInt32(e2.Key), Convert.ToInt32 (e2.Value));
            //        }
            //    }
            //    this.mySquares.Add(Convert.ToInt32(entry.Value["id"]),
            //                        new cRegularSquare(entry.Value["Name"], 
            //                                            entry.Value["Color"],
            //                                            Convert.ToInt32 (entry.Value["cost"]),
            //                                            Convert.ToInt32 (entry.Value["priceHouse"]),
            //                                            Convert.ToInt32 (entry.Value["priceHotel"]),
            //                                            Convert.ToInt32 (entry.Value["deposit"]),
            //                                            d));
            //}
            //this.mySquares.Add(1,new cStartSquare("Start","grey"));
            //this.mySquares.Add(3, new cCommunitySquare("Kanzlei", "grey"));
            //this.mySquares.Add(5, new cTaxSquare("Einkommenssteuer", "grey"));
            //this.mySquares.Add(6, new cTrainStationSquare("Vereinigte Privatbahnen Union", "grey"));
            //this.mySquares.Add(8, new cActionSquare("Chance", "grey"));
            //this.mySquares.Add(11, new cPrisonVisitorSquare("Gefägniss Besuch", "grey"));
            //this.mySquares.Add(12,new cPrisonSquare ("Gefängniss","orange"));
            //this.mySquares.Add(14, new cWaterPowerSquare("Elektrizitätswerke", "grey"));
            //this.mySquares.Add(17, new cTrainStationSquare("Vereinigte Bergbahnen AG", "grey"));
            //this.mySquares.Add(19, new cActionSquare("Kanzlei", "grey"));
            //this.mySquares.Add(22, new cFreeParkSquare("Freier Parkplatz", "grey"));
            //this.mySquares.Add(24, new cCommunitySquare("Chance", "grey"));
            //this.mySquares.Add(27, new cTrainStationSquare("Überlandbahnen", "grey"));
            //this.mySquares.Add(30, new cWaterPowerSquare("Wasserwerke", "grey"));
            //this.mySquares.Add(32, new cGoToPrisonSquare("Ins Gefängniss", "grey"));
            //this.mySquares.Add(35, new cCommunitySquare("Kanzlei", "grey"));
            //this.mySquares.Add(37, new cTrainStationSquare("Vereinigte Schwebebahnen AG", "grey"));
            //this.mySquares.Add(38, new cCommunitySquare("Chance", "grey"));
            //this.mySquares.Add(40, new cPayTaxesSquare("Nachsteuer zahlen", "grey"));
            
        }

        public Dictionary<int, ISquare> getSquares()
        {
            return this.mySquares;
        }

        public ISquare getSpecificSquare(int pos)
        {
            return this.mySquares[pos];
        }

        public Dictionary<string, cCardDeck> getCardDecks()
        {
            return this.myCardDecks;
        }

        public cCardDeck getSpecificCardDeck(string type)
        {
            return this.myCardDecks[type];
        }

        public void refreshPlayerPositions()
        {

        }
        #endregion
    }
}
