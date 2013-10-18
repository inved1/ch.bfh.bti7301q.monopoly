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

namespace monopoly.prototype.client
{
    public partial class FrmClient : Form, IObserver
    {
        private myRemoteAction remoteAction;
        
        public FrmClient()
        {
            InitializeComponent();

            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel );

            remoteAction = (myRemoteAction)Activator.GetObject(typeof(myRemoteAction), "tcp://localhost:8080/remoteAction");
            Game.getInstance().Attach(this);

            login();
        }

        private void login()
        {
            List<IAction> actions = new List<IAction>();
            actions.Add(new cActionLogin());
            remoteAction.setObject(actions);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<IAction> lst = new List<IAction>();
            
            if (chkGiveUp.Checked == true) {
                cActionGiveUp oGiveUp = new cActionGiveUp();
                oGiveUp.Name = "Aufgeben";
                lst.Add(oGiveUp);
             }

            if (chkRoll.Checked == true)
            {
                cActionRoll oRoll = new cActionRoll();
                oRoll.Name = "Würfeln";
                lst.Add(oRoll);
            }           
                

            
            remoteAction.setObject(lst);
            
            
        }

        public void Update(List<IAction> actions)
        {
            foreach (IAction action in actions)
            {
                MessageBox.Show(action.Name);
            }
        }
    }
}
