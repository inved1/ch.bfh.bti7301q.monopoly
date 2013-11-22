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
        private static cGameBoard myInstance;
        private Dictionary<int,ISquare>  mySquares;
        private Dictionary<String, cCardDeck> myCardDecks;
        private Dictionary<String, cStreet> myStreets;

        public cGameBoard()
        {
            this.mySquares = new Dictionary<int,ISquare>();
            initSquares();
            initCardDecks();
            initStreets();

        }

        private void initCardDecks()
        {
        }

        private void initStreets()
        {

        }

        public static cGameBoard getInstance()
        {
            if (myInstance == null)
            {
                myInstance = new cGameBoard();
            }
            return myInstance;
        }

        private void initSquares()
        {
            this.mySquares.Add(1,new cStartSquare("Start","grey"));
            this.mySquares.Add(2,new cReqularSquare("Chur Kornplatz","purple"));
            this.mySquares.Add(3, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(4,new cReqularSquare("Schaffhausen Vorderegasse","purple"));
            this.mySquares.Add(5, new cTaxSquare("Einkommenssteuer", "grey"));
            this.mySquares.Add(6, new cTrainStationSquare("Vereinigte Privatbahnen Union", "grey"));
            this.mySquares.Add(7,new cReqularSquare("Aarau Rathausplatz","lightblue"));
            this.mySquares.Add(8, new cActionSquare("Chance", "grey"));
            this.mySquares.Add(9, new cReqularSquare("Neuenburg Place", "lightblue"));
            this.mySquares.Add(10, new cReqularSquare("Thun Hauptgasse", "lightblue"));
            this.mySquares.Add(11, new cPrisonVisitorSquare("Gefägniss Besuch", "grey"));
            this.mySquares.Add(12,new cPrisonSquare ("Gefängniss","orange"));
            this.mySquares.Add(13,new cReqularSquare("Basel Steinenvorstadt","violett"));
            this.mySquares.Add(14, new cWaterPowerSquare("Elektrizitätswerke", "grey"));
            this.mySquares.Add(15, new cReqularSquare("Solothurn Hauptgasse", "violett"));
            this.mySquares.Add(16, new cReqularSquare("Lugano via Nassa", "violett"));
            this.mySquares.Add(17, new cTrainStationSquare("Vereinigte Bergbahnen AG", "grey"));
            this.mySquares.Add(18,new cReqularSquare("Biel Nidaugasse","orange"));
            this.mySquares.Add(19, new cActionSquare("Kanzlei", "grey"));
            this.mySquares.Add(20, new cReqularSquare("Freiburg Bahnhofstrasse", "orange"));
            this.mySquares.Add(21, new cReqularSquare("La Chaux-de-Fonds Avenue Robert", "orange"));
            this.mySquares.Add(22, new cFreeParkSquare("Freier Parkplatz", "grey"));
            this.mySquares.Add(23,new cReqularSquare("Winterthur Bahnhofplatz","red"));
            this.mySquares.Add(24, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(25, new cReqularSquare("St. Gallen Marktplatz", "red"));
            this.mySquares.Add(26, new cReqularSquare("Bern Bundesplatz", "red"));
            this.mySquares.Add(27, new cTrainStationSquare("Überlandbahnen", "grey"));
            this.mySquares.Add(28,new cReqularSquare("Luzern Weggisgasse","yellow"));
            this.mySquares.Add(29, new cReqularSquare("Zürich Rennweg", "yellow"));
            this.mySquares.Add(30, new cWaterPowerSquare("Wasserwerke", "grey"));
            this.mySquares.Add(31, new cReqularSquare("Lausanne Rue de Bourg", "yellow"));
            this.mySquares.Add(32, new cGoToPrisonSquare("Ins Gefängniss", "grey"));
            this.mySquares.Add(33,new cReqularSquare("Basel Freie Strasse","green"));
            this.mySquares.Add(34, new cReqularSquare("Genf Rue de la Croix-d'or", "green"));
            this.mySquares.Add(35, new cCommunitySquare("Kanzlei", "grey"));
            this.mySquares.Add(36, new cReqularSquare("Bern Spitalgasse", "green"));
            this.mySquares.Add(37, new cTrainStationSquare("Vereinigte Schwebebahnen AG", "grey"));
            this.mySquares.Add(38, new cCommunitySquare("Chance", "grey"));
            this.mySquares.Add(39,new cReqularSquare("Lausanne Place","blue"));
            this.mySquares.Add(40, new cPayTaxesSquare("Nachsteuer zahlen", "grey"));
            this.mySquares.Add(41, new cReqularSquare("Zürich Paradeplatz", "blue"));
            
        }

        public Dictionary<int, ISquare> getSquares()
        {
            return this.mySquares;
        }

        public ISquare getSpecificSquare(int pos)
        {
            return this.mySquares[pos];
        }

        public void refreshPlayerPositions()
        {

        }
    }
}
