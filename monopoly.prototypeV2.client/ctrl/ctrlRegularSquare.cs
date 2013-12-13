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
using monopoly.prototypeV2.client.interfaces;

namespace monopoly.prototypeV2.client.ctrl
{
    

    public partial class ctrlRegularSquare : UserControl, IctrlSquare
    {

        #region "vars"
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

        #endregion

        #region "constructor"

        public ctrlRegularSquare()
        {
            InitializeComponent();
            initPointLists();

            this.myAvatars = new List<cAvatar>();
            this.myRealEstates = new List<IRealEstate>();

            this.con.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrl_paint);
            //this.con.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.ctrl_paint);
        }

        #endregion


        private void initPointLists()
        {
            myListAvatarsHorizontal = new List<Point>();
            myListAvatarsVertical = new List<Point>();
            myListRealEstatesHorizontal = new List<Point>();
            myListRealEstatesVertical = new List<Point>();


            myListAvatarsHorizontal.Add(new Point(2, 18));
            myListAvatarsHorizontal.Add(new Point(24, 18));
            myListAvatarsHorizontal.Add(new Point(46, 18));
            myListAvatarsHorizontal.Add(new Point(2, 40));
            myListAvatarsHorizontal.Add(new Point(24, 40));
            myListAvatarsHorizontal.Add(new Point(46, 40));

            myListRealEstatesHorizontal.Add(new Point(2, 2));
            myListRealEstatesHorizontal.Add(new Point(2, 24));
            myListRealEstatesHorizontal.Add(new Point(2, 46));
            myListRealEstatesHorizontal.Add(new Point(2, 68));

            myListAvatarsVertical.Add(new Point(2, 18));
            myListAvatarsVertical.Add(new Point(24, 18));
            myListAvatarsVertical.Add(new Point(2, 40));
            myListAvatarsVertical.Add(new Point(24, 40));
            myListAvatarsVertical.Add(new Point(2, 62));
            myListAvatarsVertical.Add(new Point(24, 62));

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
            }
        }


        private void ctrl_paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString(this.ctrlTopName, new Font("Arial", 8), Brushes.Black, new PointF(2, 2));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //not used anymore            
        }


        public String ctrlTopName
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

        public void addAvatar(PictureBox avatar, cAvatar cAva)
        {
            this.myAvatars.Add(cAva);
            avatar.Location = this.myActiveListPositionsAvatars[this.myAvatars.Count];
            this.con.Panel2.Controls.Add(avatar);

        }

        public void clearAvatars()
        {
            this.myAvatars.Clear();

        }


        public string ctrlBackColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ctrlTopColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ctrlBottomName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
