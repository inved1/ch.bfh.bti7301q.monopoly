using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.client.interfaces;
using monopoly.prototypeV2.logic.classes; 

namespace monopoly.prototypeV2.client.ctrl
{
    public partial class ctrlStartSquare : UserControl, IctrlSquare
    {
        #region "vars"
        private String myName;
        private List<cAvatar> myAvatars = null;
        private List<Point> myActiveListPositionsAvatars = null;
        private static List<Point> myListAvatarsHorizontal;
        private static List<Point> myListAvatarsVertical;
        #endregion

        #region "constructor"

        public ctrlStartSquare()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.ctrl_paint);

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
            get { return this.myName; }
            set { this.myName = value; }
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
        #endregion



        public void addAvatar(PictureBox avatar, cAvatar cAva)
        {
            this.myAvatars.Add(cAva);
            avatar.Location = this.myActiveListPositionsAvatars[this.myAvatars.Count];
            this.Controls.Add(avatar);

        }

        public void clearAvatars()
        {
            this.myAvatars.Clear();

        }

        public System.Windows.Forms.Orientation orientation
        {
            get { return System.Windows.Forms.Orientation.Horizontal; }
            set
            {

                this.myActiveListPositionsAvatars = (value == Orientation.Horizontal) ? myListAvatarsHorizontal : myListAvatarsVertical;

            }
        }
    }
}
