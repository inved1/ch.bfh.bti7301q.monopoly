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


namespace monopoly.prototype.server
{
    public partial class Form1 : Form , monopoly.prototype.logic.IObserver  
    {
        private myRemoteAction remoteAction;

        public Form1()
        {
            InitializeComponent();

            remoteAction = new myRemoteAction();

            TcpChannel channel = new TcpChannel(8080);

            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(myRemoteAction), "test", WellKnownObjectMode.Singleton);
            monopoly.prototype.logic.Cache.Attach(this);


        }

        /*from interface */
        public void Notify(monopoly.prototype.logic.dummyAction  o)
        {

            textBox1.Text += o.val1 + "\r\n" + o.val2.ToString();
            handleNotify(o);
        }

        private void handleNotify(monopoly.prototype.logic.dummyAction o)
        {
            switch (o.type)
            {
                case dummyAction.ActionType.Buy:
                    o.val2 = o.val2 - 10;
                    break;
                case dummyAction.ActionType.Pay:
                    o.val2 = 0;
                    break;
                case dummyAction.ActionType.Roll:
                    o.val2 = new Random().Next(12);
                    break;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1 ());
        }
    }
}
