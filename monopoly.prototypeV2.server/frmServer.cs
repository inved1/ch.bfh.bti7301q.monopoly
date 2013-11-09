using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using monopoly.prototypeV2.logic;
using monopoly.prototypeV2.logic.classes;
using monopoly.prototypeV2.logic.interfaces;


namespace monopoly.prototypeV2.server
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
            
            // create game

            //init();
        }

        private void init()
        {
            TcpChannel channel = new TcpChannel(Convert.ToInt32(this.txtPort.Text ));
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(monopoly.prototypeV2.logic.classes.cGame), "sharedGame", WellKnownObjectMode.Singleton);

            this.txtInfo.Text+="Server started";


           
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /*[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmServer());
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            init();
        }
    }
}
