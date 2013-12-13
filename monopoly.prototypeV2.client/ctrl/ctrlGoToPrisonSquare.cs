﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.client.interfaces;

namespace monopoly.prototypeV2.client.ctrl
{
    public partial class ctrlGoToPrisonSquare : UserControl, IctrlSquare
    {
        #region "vars"

        private String myName;
        #endregion

        #region "constructor"

        public ctrlGoToPrisonSquare()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.ctrl_paint);
        }
        #endregion

        #region "events"
        private void ctrl_paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString(this.ctrlTopName, new Font("Arial", 8), Brushes.Black, new PointF(2, 2));
        }

        #endregion


        public String ctrlTopName
        {
            get { return this.myName; }
            set { this.myName = value; }
        }

        #region "properties"
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



        public void addAvatar(PictureBox PBavatar, logic.classes.cAvatar oAvatar)
        {
            //throw new NotImplementedException();
        }

        public void clearAvatars()
        {
            //throw new NotImplementedException();
        }
    }
}