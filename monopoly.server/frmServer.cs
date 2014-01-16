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
using monopoly.logic;
using monopoly.logic.classes;
using monopoly.logic.interfaces;
using monopoly.logic.util; 
using System.Runtime.Serialization.Formatters;
using System.Collections;


namespace monopoly.server
{
    public partial class frmServer : Form
    {
        private cConfig myConfig;

        public frmServer()
        {
            InitializeComponent();
            this.myConfig = cConfig.getInstance;
        }

        private void init()
        {
            LogWriter w = LogWriter.Instance;
            w.WriteLogQueue("Server started");
            this.txtInfo.AppendText("Server started\n");

            this.txtPort.Text = this.myConfig.Server["ServerPort"];


            BinaryServerFormatterSinkProvider serverSinkProvider = new BinaryServerFormatterSinkProvider();
            serverSinkProvider.TypeFilterLevel = TypeFilterLevel.Full;

            BinaryClientFormatterSinkProvider clientSinkProvider = new BinaryClientFormatterSinkProvider();
            Hashtable channelProperties = new Hashtable();
            channelProperties["port"] = Convert.ToInt32(this.txtPort.Text);

            TcpChannel tcpChannel = new TcpChannel(channelProperties, clientSinkProvider, serverSinkProvider);
            ChannelServices.RegisterChannel(tcpChannel, false);

            RemotingConfiguration.RegisterWellKnownServiceType (typeof(monopoly.logic.classes.cGame), this.myConfig.Server["ServerSharedGameName"],WellKnownObjectMode.Singleton );
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            //TypeFilterLevel = TypeFilterLevel.Full; 
            
            w.WriteLogQueue("Server registered");

             

           
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
            this.button1.Enabled = false;
        }

    }
}
