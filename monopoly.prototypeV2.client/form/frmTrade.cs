﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.logic.interfaces;
using monopoly.prototypeV2.logic.classes;

namespace monopoly.prototypeV2.client
{
    public partial class frmTrade : Form
    {
        private cGame myGame;
        public frmTrade()
        {
            InitializeComponent();
            //this.CenterToParent();
        }

        public void addControl(Button btn)
        {
            this.flp.Controls.Add(btn);
            btn.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        public cGame game
        {
            set { this.myGame = value; }
            get { return this.myGame; }
        }
        public void clearControls()
        {
            this.flp.Controls.Clear();
        }

        /*public void notify(List<IAction> lst)
        {
            foreach (IAction o in lst)
            {
                ctrlGenericAction c = new ctrlGenericAction();
                c.Tag = o;
                this.flp.Controls.Add(c);
            }
        }*/
    }
}