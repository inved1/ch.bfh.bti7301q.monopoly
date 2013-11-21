using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.prototypeV2.client.ctrl
{
    public partial class ctrlRegularSquare : UserControl
    {
        private String myStreet;
        private String myName;



        public ctrlRegularSquare()
        {
            InitializeComponent();
        }

        public String Street
        {
            get {return this.myStreet;}
            set {
                this.myStreet = value;
                this.con.Panel1.BackColor = Color.FromName(value);
                //draw on panel, dont want a label 

                System.Drawing.Graphics form = this.con.Panel1.CreateGraphics();
                System.Drawing.Font oFont = new Font("Arial", 10);
                System.Drawing.SolidBrush oBrush = new SolidBrush(System.Drawing.Color.Black);

                form.DrawString(value, oFont, oBrush, new Point(10, 10));

                oFont.Dispose();
                oBrush.Dispose();
                form.Dispose();

            }
        }
        public String Name
        {
            get { return this.myName;}
            set { this.myName = value; }
        }

        

    }
}
