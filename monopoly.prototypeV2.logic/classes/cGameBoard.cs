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
        private static cGameBoard instance;
        private Dictionary<int,ISquare>  squares;

        public cGameBoard()
        {
            this.squares = new Dictionary<int,ISquare>();
            initSquares();
        }

        public static cGameBoard getInstance()
        {
            if (instance == null)
            {
                instance = new cGameBoard();
            }
            return instance;
        }

        public void initSquares()
        {
            this.squares.Add(1,new cStartSquare("Start","grey"));
            this.squares.Add(2,new cReqularSquare("Chur Kornplatz","purple"));
            this.squares.Add(3, new cCommunitySquare("Kanzlei", "grey"));
            this.squares.Add(4,new cReqularSquare("Schaffhausen Vorderegasse","purple"));
            this.squares.Add(5, new cTaxSquare("Einkommenssteuer", "grey"));
            this.squares.Add(6, new cTrainStationSquare("Vereinigte Privatbahnen Union", "grey"));
            this.squares.Add(7,new cReqularSquare("Aarau Rathausplatz","lightblue"));
            this.squares.Add(8, new cActionSquare("Chance", "grey"));
            this.squares.Add(9, new cReqularSquare("Neuenburg Place", "lightblue"));
            this.squares.Add(10, new cReqularSquare("Thun Hauptgasse", "lightblue"));
            this.squares.Add(11, new cPrisonVisitorSquare("Gefägniss Besuch", "grey"));
            this.squares.Add(12,new cPrisonSquare ("Gefängniss","orange"));
            this.squares.Add(13,new cReqularSquare("Basel Steinenvorstadt","violett"));
            this.squares.Add(14, new cWaterPowerSquare("Elektrizitätswerke", "grey"));
            this.squares.Add(15, new cReqularSquare("Solothurn Hauptgasse", "violett"));
            this.squares.Add(16, new cReqularSquare("Lugano via Nassa", "violett"));
            this.squares.Add(17, new cTrainStationSquare("Vereinigte Bergbahnen AG", "grey"));
            this.squares.Add(18,new cReqularSquare("Biel Nidaugasse","orange"));
            this.squares.Add(19, new cActionSquare("Kanzlei", "grey"));
            this.squares.Add(20, new cReqularSquare("Freiburg Bahnhofstrasse", "orange"));
            this.squares.Add(21, new cReqularSquare("La Chaux-de-Fonds Avenue Robert", "orange"));
            this.squares.Add(22, new cFreeParkSquare("Freier Parkplatz", "grey"));
            this.squares.Add(23,new cReqularSquare("Winterthur Bahnhofplatz","red"));
            this.squares.Add(24, new cCommunitySquare("Chance", "grey"));
            this.squares.Add(25, new cReqularSquare("St. Gallen Marktplatz", "red"));
            this.squares.Add(26, new cReqularSquare("Bern Bundesplatz", "red"));
            this.squares.Add(27, new cTrainStationSquare("Überlandbahnen", "grey"));
            this.squares.Add(28,new cReqularSquare("Luzern Weggisgasse","yellow"));
            this.squares.Add(29, new cReqularSquare("Zürich Rennweg", "yellow"));
            this.squares.Add(30, new cWaterPowerSquare("Wasserwerke", "grey"));
            this.squares.Add(31, new cReqularSquare("Lausanne Rue de Bourg", "yellow"));
            this.squares.Add(32, new cGoToPrisonSquare("Ins Gefängniss", "grey"));
            this.squares.Add(33,new cReqularSquare("Basel Freie Strasse","green"));
            this.squares.Add(34, new cReqularSquare("Genf Rue de la Croix-d'or", "green"));
            this.squares.Add(35, new cCommunitySquare("Kanzlei", "grey"));
            this.squares.Add(36, new cReqularSquare("Bern Spitalgasse", "green"));
            this.squares.Add(37, new cTrainStationSquare("Vereinigte Schwebebahnen AG", "grey"));
            this.squares.Add(38, new cCommunitySquare("Chance", "grey"));
            this.squares.Add(39,new cReqularSquare("Lausanne Place","blue"));
            this.squares.Add(40, new cPayTaxesSquare("Nachsteuer zahlen", "grey"));
            this.squares.Add(41, new cReqularSquare("Zürich Paradeplatz", "blue"));
            
        }

        public Dictionary<int, ISquare> getSquares()
        {
            return this.squares;
        }

        public ISquare getSpecificSquare(int pos)
        {
            return this.squares[pos];
        }

        public void refreshPlayerPositions()
        {

        }
    }
}
