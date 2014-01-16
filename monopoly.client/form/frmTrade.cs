using System;
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
using monopoly.logic.classes.squares;

namespace monopoly.client
{
    public partial class frmTrade : Form
    {
        private cGame myGame;
        private List<cPlayer> myPlayers;
        private List<cRegularSquare> myCards;
        public frmTrade()
        {
            InitializeComponent();
            //this.CenterToParent();
        }

        public void addControl(Button btn)
        {
            btn.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


        public cGame game
        {
            set { this.myGame = value; }
            get { return this.myGame; }
        }
  
        public List<cPlayer> players
        {
            set {   this.myPlayers = value; 
                    foreach(cPlayer p in value )
                    {
                        RadioButton rb = new RadioButton();
                        rb.Text = p.Name;
                        rb.Tag = p;
                        this.groupBox1.Controls.Add(rb);
                        
                    }
                
            }
            get { return this.myPlayers; }
        }

        public List<cRegularSquare> sellable
        {
            set { this.myCards = value;
            foreach (cRegularSquare c in value)
            {
                RadioButton rb = new RadioButton();
                rb.Text = c.ctrlName;
                rb.Tag = c;
                this.groupBox2.Controls.Add(rb);
                
                
            }
            }
            get { return this.myCards; }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            var checkbtn1 = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var checkbtn2 = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            this.myGame.addTradeCard((cRegularSquare)checkbtn2.Tag, Convert.ToInt32(this.numericUpDown1.Value), (cPlayer)checkbtn1.Tag);
            this.DialogResult = DialogResult.OK;
            //this.Close();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
