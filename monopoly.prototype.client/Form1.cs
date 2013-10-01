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

namespace monopoly.prototype.client
{
    public partial class Form1 : Form
    {
        myRemoteAction remoteAction;

        
        public Form1()
        {
            InitializeComponent();

            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel );


            remoteAction = (myRemoteAction)Activator.GetObject(typeof(myRemoteAction), "tcp://localhost:8080/test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monopoly.prototype.logic.dummyAction a = new monopoly.prototype.logic.dummyAction();
            a.val1 = "Dani";
            a.val2 = 42;
 

            remoteAction.setObject(a);
        }
    }
}
