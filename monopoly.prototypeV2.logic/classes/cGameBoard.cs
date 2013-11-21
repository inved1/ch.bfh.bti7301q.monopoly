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
            this.squares.Add(1,new cStartSquare(                "Start"))
            this.squares.Add(2,new cReqularSquare(              "Chur Kornplatz"))
            this.squares.Add(3,new cCommunitySquare(            "Kanzlei"))
            this.squares.Add(4,new cReqularSquare(              "Schaffhausen Vorderegasse"))
            this.squares.Add(5,new cTaxSquare(                  "Einkommenssteuer"))
            this.squares.Add(6,new cTrainStationSquare(         "Vereinigte Privatbahnen Union"))
            this.squares.Add(7,new cReqularSquare(              "Aarau Rathausplatz"))
            this.squares.Add(8,new cActionSquare(               "Chance"))
            this.squares.Add(9,new cReqularSquare(              "Neuenburg Place"))
            this.squares.Add(10,new cReqularSquare(             "Thun Hauptgasse"))
            this.squares.Add(11,new cPrisonVisitorSquare(       "Gefägniss Besuch"))
            this.squares.Add(12,new cPrisonSquare (             "Gefängniss"))
            this.squares.Add(13,new cReqularSquare(             "Basel Steinenvorstadt"))
            this.squares.Add(14,new cWaterPowerSquare(          "Elektrizitätswerke"))
            this.squares.Add(15,new cReqularSquare(             "Solothurn Hauptgasse"))
            this.squares.Add(16,new cReqularSquare(             "Lugano via Nassa"))
            this.squares.Add(17,new cTrainStationSquare(        "Vereinigte Bergbahnen AG"))
            this.squares.Add(18,new cReqularSquare(             "Biel Nidaugasse"))
            this.squares.Add(19,new cActionSquare(              "Kanzlei"))
            this.squares.Add(10,new cReqularSquare(             "Freiburg Bahnhofstrasse"))
            this.squares.Add(21,new cReqularSquare(             "La Chaux-de-Fonds Avenue Robert"))
            this.squares.Add(22,new cFreeParkSquare(            "Freier Parkplatz"))
            this.squares.Add(23,new cReqularSquare(             "Winterthur Bahnhofplatz"))
            this.squares.Add(24,new cCommunitySquare(           "Chance"))
            this.squares.Add(25,new cReqularSquare(             "St. Gallen Marktplatz"))
            this.squares.Add(26,new cReqularSquare(             "Bern Bundesplatz"))
            this.squares.Add(27,new cTrainStationSquare(        "Überlandbahnen"))
            this.squares.Add(28,new cReqularSquare(             "Luzern Weggisgasse"))
            this.squares.Add(29,new cReqularSquare(             "Zürich Rennweg"))
            this.squares.Add(20,new cWaterPowerSquare(          "Wasserwerke"))
            this.squares.Add(31,new cReqularSquare (            "Lausanne Rue de Bourg"))
            this.squares.Add(32,new cGoToPrisonSquare(          "Ins Gefängniss"))
            this.squares.Add(33,new cReqularSquare(             "Basel Freie Strasse"))
            this.squares.Add(34,new cReqularSquare(             "Genf Rue de la Croix-d'or"))
            this.squares.Add(35,new cCommunitySquare(           "Kanzlei"))
            this.squares.Add(36,new cReqularSquare(             "Bern Spitalgasse"))
            this.squares.Add(37,new cTrainStationSquare(        "Vereinigte Schwebebahnen AG"))
            this.squares.Add(38,new cCommunitySquare(           "Chance"))
            this.squares.Add(39,new cReqularSquare(             "Lausanne Place"))
            this.squares.Add(40,new cPayTaxesSquare (           "Nachsteuer zahlen"))
            this.squares.Add(41,new cReqularSquare(             "Zürich Paradeplatz"))






            "Start"
            "Chur Kornplatz"
            "Kanzlei"
            "Schaffhausen Vorderegasse"
            "Einkommenssteuer"
            "Vereinigte Privatbahnen Union"
            "Aarau Rathausplatz"
            "Chance"
            "Neuenburg Place"
            "Thun Hauptgasse"
            "Gefägniss Besuch"
            "Gefängniss"
            "Basel Steinenvorstadt"
            "Elektrizitätswerke"
            "Solothurn Hauptgasse"
            "Lugano via Nassa"
            "Vereinigte Bergbahnen AG"
            "Biel Nidaugasse"
            "Kanzlei"
            "Freiburg Bahnhofstrasse
            "La Chaux-de-Fonds Avenue Robert"
            "Freier Parkplatz"
            "Winterthur Bahnhofplatz"
            "Chance"
            "St. Gallen Marktplatz"
            "Bern Bundesplatz"
            "Überlandbahnen"
            "Luzern Weggisgasse"
            "Zürich Rennweg"
            "Wasserwerke"
            "Lausanne Rue de Bourg
            "Ins Gefängniss"
            "Basel Freie Strasse"
            "Genf Rue de la Croix-d'or"
            "Kanzlei"
            "Bern Spitalgasse"
            "Vereinigte Schwebebahnen AG"
            "Chance"
            "Lausanne Place"
            "Nachsteuer zahlen"
            "Zürich Paradeplatz"
        }

        public List<ISquare> getSquares()
        {
            return this.squares;
        }

        public void refreshPlayerPositions()
        {

        }
    }
}
