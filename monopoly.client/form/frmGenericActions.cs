﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.logic.interfaces;
using monopoly.logic.classes;

namespace monopoly.client
{
    public partial class frmGenericActions : Form
    {
        public frmGenericActions()
        {
            InitializeComponent();
            //this.CenterToParent();
        }

        public void addControl(Button btn)
        {
            this.flp.Controls.Add(btn);
            btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn.Select();
        }

        public void clearControls()
        {
            this.flp.Controls.Clear();
        }

        private void frmGenericActions_Shown(object sender, EventArgs e)
        {
            this.flp.Controls[0].Select();
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
