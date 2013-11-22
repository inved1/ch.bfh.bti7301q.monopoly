using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.logic.classes;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.client.ctrl
{
    

    public partial class ctrlRegularSquare : UserControl
    {
        private String myStreetColor;
        private String myName;


        // if regularsquare is vertical (top and bottom), then use lists "vertical"
        // if regular square is horizontal (left and right), then use lists "horizontal"

        
        private static List<Point> myListRealEstatesHorizontal;
        private static List<Point> myListRealEstatesVertical;
        private static List<Point> myListAvatarsHorizontal;
        private static List<Point> myListAvatarsVertical;

        private List<Point> myActiveListPositionsAvatars = null;
        private List<Point> myActiveListPositionsRealEstates = null;

        private List<cAvatar> myAvatars = null;
        private List<IRealEstate> myRealEstates = null;


        public ctrlRegularSquare()
        {
            InitializeComponent();
            this.Name = "init";
            this.StreetColor = "yellow";
            initPointLists();

            this.myAvatars = new List<cAvatar>();
            this.myRealEstates = new List<IRealEstate>();
        }

        private void initPointLists()
        {
            myListAvatarsHorizontal = new List<Point>();
            myListAvatarsVertical = new List<Point>();
            myListRealEstatesHorizontal = new List<Point>();
            myListRealEstatesVertical = new List<Point>();


            myListAvatarsHorizontal.Add(new Point(2, 2));
            myListAvatarsHorizontal.Add(new Point(24, 2));
            myListAvatarsHorizontal.Add(new Point(46, 2));
            myListAvatarsHorizontal.Add(new Point(2, 24));
            myListAvatarsHorizontal.Add(new Point(24, 24));
            myListAvatarsHorizontal.Add(new Point(46, 24));

            myListRealEstatesHorizontal.Add(new Point(2, 2));
            myListRealEstatesHorizontal.Add(new Point(2, 24));
            myListRealEstatesHorizontal.Add(new Point(2, 46));
            myListRealEstatesHorizontal.Add(new Point(2, 68));

            myListAvatarsVertical.Add(new Point(2, 2));
            myListAvatarsVertical.Add(new Point(24, 2));
            myListAvatarsVertical.Add(new Point(2, 24));
            myListAvatarsVertical.Add(new Point(24, 24));
            myListAvatarsVertical.Add(new Point(2, 46));
            myListAvatarsVertical.Add(new Point(24, 46));

            myListRealEstatesVertical.Add(new Point(2, 2));
            myListRealEstatesVertical.Add(new Point(24, 2));
            myListRealEstatesVertical.Add(new Point(46, 2));
            myListRealEstatesVertical.Add(new Point(68, 2));
        }

        public String StreetColor
        {
            get {return this.myStreetColor;}
            set {
                this.myStreetColor = value;
                this.con.Panel1.BackColor = Color.FromName(value);
                //draw on panel, dont want a label 

                System.Drawing.Graphics form = this.con.Panel1.CreateGraphics();
                System.Drawing.Font oFont = new Font("Arial", 10);
                System.Drawing.SolidBrush oBrush = new SolidBrush(System.Drawing.Color.Black);

                form.DrawString(this.ctrlName , oFont, oBrush, new Point(10, 10));

                oFont.Dispose();
                oBrush.Dispose();
                form.Dispose();

            }
        }


        public String ctrlName
        {
            get { return this.myName;}
            set { this.myName = value; }
        }

        public System.Windows.Forms.Orientation orientation
        {
            get { return this.con.Orientation; }
            set { 
                this.con.Orientation = value;
                this.myActiveListPositionsAvatars = (value == Orientation.Horizontal) ? myListAvatarsHorizontal : myListAvatarsVertical;
                this.myActiveListPositionsRealEstates = (value == Orientation.Horizontal) ? myListRealEstatesHorizontal : myListRealEstatesVertical;                  
            }
        }
        

    }
}
