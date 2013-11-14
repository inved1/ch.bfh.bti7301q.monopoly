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
        private List<ISquare> squares;

        public cGameBoard()
        {
            this.squares = new List<ISquare>();
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
            this.squares.Add(new StartSquare());
            this.squares.Add(new ReqularSquare("Lachnerstrasse"));
            this.squares.Add(new CommunitySquare("Gemeindefeld"));
            this.squares.Add(new ReqularSquare("Lameystrasse"));
            this.squares.Add(new TaxSquare("Spende an die Gemeinde"));
            this.squares.Add(new TrainStationSquare("Rheinau Bahnhof"));
            this.squares.Add(new ReqularSquare("Tullastrasse"));
            this.squares.Add(new ActionSquare("Aktionsfeld"));
            this.squares.Add(new ReqularSquare("Elisabethstrasse"));
            this.squares.Add(new ReqularSquare("Rathenaustrasse"));
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
