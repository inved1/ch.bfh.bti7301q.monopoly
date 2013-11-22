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


namespace monopoly.prototypeV2.client.ctrl
{
    public partial class ctrlPrisonSquare : UserControl, IctrlSquare 
    {
        private String myName;


        public ctrlPrisonSquare()
        {
            InitializeComponent();
        }
        public String ctrlName
        {
            get { return this.myName; }
            set { this.myName = value; }
        }
    }
}
