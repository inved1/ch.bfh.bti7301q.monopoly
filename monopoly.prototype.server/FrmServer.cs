using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototype.logic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using monopoly.prototype.logic.interfaces;
using monopoly.prototype.logic.classes;


namespace monopoly.prototype.server
{
    public partial class FrmServer : Form //, monopoly.prototype.logic.IObserver  
    {
        //private myRemoteAction remoteAction;

        private Game game; 
        //private cGameBoard myGameBoard;

        public FrmServer()
        {
            InitializeComponent();

            game = Game.getInstance();
            TcpChannel channel = new TcpChannel(9999);
            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(myRemoteAction), "test", WellKnownObjectMode.Singleton);
        }





        [STAThread]
        static void Main()
        {
            Application.Run(new FrmServer ());
        }

        /*from interface */
        public void Notify(List<logic.interfaces.IAction> lst)
        {
            foreach (IAction o in lst)
            {
                this.textBox1.Text += "run Action - " + o.Name.ToString() +"\r\n";
                
                o.runAction();
                if (o.GetType() == typeof(cActionRoll))
                {
                    cActionRoll oActionRoll = (cActionRoll)o;
                    //this.myGameBoard.lstAvatars[0].position += oActionRoll.val;
                    this.textBox1.Text += "position [0] - " + oActionRoll.val.ToString() + "\r\n";
                }

                
            }

        }
    }
}
