using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.client.interfaces;
using monopoly.logic.classes; 

namespace monopoly.client.ctrl
{
    public partial class ctrlTaxSquare : UserControl, IctrlSquare
    {
        #region "vars"

        private String myTopName;
        private String myBottomName;

        private List<cAvatar> myAvatars = null;
        private List<Point> myActiveListPositionsAvatars = null;
        private static List<Point> myListAvatarsHorizontal;
        private static List<Point> myListAvatarsVertical;
        #endregion

        #region "constructor"

        public ctrlTaxSquare()
        {
            InitializeComponent();
            this.con.Panel1.Paint += new PaintEventHandler(this.ctrl_paint);
            this.myAvatars = new List<cAvatar>();
            myListAvatarsHorizontal = new List<Point>();
            myListAvatarsVertical = new List<Point>();


            myListAvatarsHorizontal.Add(new Point(2, 18));
            myListAvatarsHorizontal.Add(new Point(24, 18));
            myListAvatarsHorizontal.Add(new Point(46, 18));
            myListAvatarsHorizontal.Add(new Point(2, 40));
            myListAvatarsHorizontal.Add(new Point(24, 40));
            myListAvatarsHorizontal.Add(new Point(46, 40));

            myListAvatarsVertical.Add(new Point(2, 18));
            myListAvatarsVertical.Add(new Point(24, 18));
            myListAvatarsVertical.Add(new Point(2, 40));
            myListAvatarsVertical.Add(new Point(24, 40));
            myListAvatarsVertical.Add(new Point(2, 62));
            myListAvatarsVertical.Add(new Point(24, 62));

            this.orientation = System.Windows.Forms.Orientation.Horizontal;
        }

        #endregion

        #region "events"

        private void ctrl_paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString(this.ctrlTopName, new Font("Arial", 8), Brushes.Black, new PointF(2, 2));
        }

        #endregion

        #region "properties"
        public String ctrlTopName
        {
            get { return this.myTopName; }
            set { this.myTopName = value; }
        }


        public string ctrlBackColor
        {
            get
            {
                return this.BackColor.Name; 
                // throw new NotImplementedException();
            }
            set
            {
                this.con.BackColor = Color.FromName(value);
                //throw new NotImplementedException();
            }
        }

        public string ctrlTopColor
        {
            get
            {
                return this.con.Panel1.BackColor.Name;
                //throw new NotImplementedException();
            }
            set
            {
                this.con.Panel1.BackColor = Color.FromName(value);
                //throw new NotImplementedException();
            }
        }

        public string ctrlBottomName
        {
            get            {                return this.myBottomName;                           }
            set            {                this.myBottomName = value;}               
        }
        #endregion


        public void addAvatar(PictureBox avatar, cAvatar cAva)
        {
            this.myAvatars.Add(cAva);
            avatar.Location = this.myActiveListPositionsAvatars[this.myAvatars.Count];
            this.con.Panel2.Controls.Add(avatar);

        }

        public void clearAvatars()
        {
            this.myAvatars.Clear();
            foreach (var pb in this.con.Panel2.Controls.OfType<PictureBox>())
            {
                pb.Dispose();
                this.Refresh();
            }


        }

        public System.Windows.Forms.Orientation orientation
        {
            get { return System.Windows.Forms.Orientation.Horizontal; }
            set
            {
                this.con.Orientation = value;
                this.myActiveListPositionsAvatars = (value == Orientation.Vertical) ? myListAvatarsHorizontal : myListAvatarsVertical;

            }
        }
    }
}
