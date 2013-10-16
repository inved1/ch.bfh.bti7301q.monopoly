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
    public partial class Form1 : Form , monopoly.prototype.logic.IObserver  
    {
        private myRemoteAction remoteAction;

        private cGameBoard myGameBoard;

        public Form1()
        {
            InitializeComponent();


            this.myGameBoard = new cGameBoard();
            List<cAvatar> lst = new List<monopoly.prototype.logic.classes.cAvatar>();
            lst.Add(new cAvatar());
            this.myGameBoard.lstAvatars = lst;

            remoteAction = new myRemoteAction();

            TcpChannel channel = new TcpChannel(8080);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(myRemoteAction), "test", WellKnownObjectMode.Singleton);
            monopoly.prototype.logic.Cache.Attach(this);


        }





        [STAThread]
        static void Main()
        {
            Application.Run(new Form1 ());
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
                    this.myGameBoard.lstAvatars[0].position += oActionRoll.val;
                    this.textBox1.Text += "position [0] - " + oActionRoll.val.ToString() + "\r\n";
                }

                
            }

        }
    }
}
