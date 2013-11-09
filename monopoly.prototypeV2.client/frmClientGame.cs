using System;
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
using System.Diagnostics;

namespace monopoly.prototypeV2.client
{
    public partial class frmClientGame : Form, monopoly.prototypeV2.logic.interfaces.IObserverGUI
    {
        private String myIP = "";
        private String myPort = "";
        private cGame myGame;


        public frmClientGame(String ip, String Port)
        {
            InitializeComponent();
            this.myIP = ip;
            this.myPort = Port;
            init();
        }

        public void init(){
            this.myGame = (cGame)System.Activator.GetObject(typeof(cGame), String.Format("tcp://{0}:{1}/SharedGame", this.myIP, this.myPort));


        }


        public void updateAll()
        {
            throw new NotImplementedException();
        }

        public void setActivePlayer(cRemoteAction oRemote )
        {
            frmGenericActions f = new frmGenericActions(oRemote);
            f.Show();
            //throw new NotImplementedException();


        }

        private void frmClientGame_Shown(object sender, EventArgs e)
        {

        }


    }
}
