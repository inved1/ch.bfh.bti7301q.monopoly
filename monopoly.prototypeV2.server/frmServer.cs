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
using monopoly.prototypeV2.logic.util; 
using System.Runtime.Serialization.Formatters;
using System.Collections;


namespace monopoly.prototypeV2.server
{
    public partial class frmServer : Form
    {
        private cConfig myConfig;
        private cGame myGame;

        public frmServer()
        {
            InitializeComponent();
            this.myConfig = cConfig.getInstance;
            this.button2.Enabled = false;
        }

        private void init()
        {
            LogWriter w = LogWriter.Instance;
            w.WriteLogQueue("Server started");
            this.txtInfo.AppendText("Server started\n");

            this.txtPort.Text = this.myConfig.Server["ServerPort"];

            BinaryServerFormatterSinkProvider tpfProvider = new BinaryServerFormatterSinkProvider();
            tpfProvider.TypeFilterLevel = TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();
            props["port"] = Convert.ToInt32(this.txtPort.Text);
            TcpChannel tcpChannel = new TcpChannel(props, clientProv, tpfProvider);
            ChannelServices.RegisterChannel(tcpChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(monopoly.prototypeV2.logic.classes.cGame), this.myConfig.Server["ServerSharedGameName"], WellKnownObjectMode.Singleton);

            this.myGame = (cGame)System.Activator.GetObject(typeof(cGame), String.Format("tcp://127.0.0.1:{0}/{1}", this.myConfig.Server["ServerPort"], this.myConfig.Server["ServerSharedGameName"]));
            this.txtInfo.AppendText(String.Format("Connection to 'tcp://127.0.0.1:{0}/{1}' established\n", this.myConfig.Server["ServerPort"], this.myConfig.Server["ServerSharedGameName"]));
            this.txtInfo.AppendText("Please start clients now.");

            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            
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
            this.button2.Enabled = true;
            this.button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
                this.myGame.initGame();
            }
            catch (Exception ex)
            {
                LogWriter.Instance.WriteLogQueue(ex.Message);
                throw new Exception("Monopoly Server Exception", ex);
                               
            }
            
        }
    }
}
