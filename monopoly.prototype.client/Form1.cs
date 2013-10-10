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
        monopoly.prototype.logic.dummyAction tmpObject;
        
        public Form1()
        {
            InitializeComponent();

            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel );



            remoteAction = (myRemoteAction)Activator.GetObject(typeof(myRemoteAction), "tcp://localhost:8080/test");
            tmpObject = new monopoly.prototype.logic.dummyAction();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monopoly.prototype.logic.dummyAction a = new monopoly.prototype.logic.dummyAction();
            a.val1 = "Dani";
            a.val2 = 42;
            a.type = dummyAction.ActionType.Pay;

            tmpObject = a;
            remoteAction.setObject(a);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += tmpObject.val1 + " " + tmpObject.val2.ToString() + "\r\n";
        }
    }
}
