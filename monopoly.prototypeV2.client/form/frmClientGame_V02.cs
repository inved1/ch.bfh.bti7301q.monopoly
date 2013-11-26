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
using monopoly.prototypeV2.client.classes;
using monopoly.prototypeV2.client.Properties;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Diagnostics;

namespace monopoly.prototypeV2.client.form
{
    public partial class frmClientGame_V02 : Form, IObserverGUI
    {

        private String myIP = "";
        private String myPort = "";
        private cGame game;
        private cPlayer player;        
        Dictionary<int,classes.cGUIWrapper> mySquares;



        public frmClientGame_V02(String ip, String Port)
        {
            InitializeComponent();

            this.myIP = ip;
            this.myPort = Port;
            init();
        }

        private void init()
        {
            //attentione !!!!
#if DEBUG
           // TcpChannel tcpChannel = new TcpChannel(0);
           // ChannelServices.RegisterChannel(tcpChannel, false);
#else
                        TcpChannel tcpChannel = new TcpChannel(0);
            ChannelServices.RegisterChannel(tcpChannel, false);
#endif
            //TcpChannel tcpChannel = new TcpChannel(0);
            //ChannelServices.RegisterChannel(tcpChannel, false);
            this.game = (cGame)System.Activator.GetObject(typeof(cGame), String.Format("tcp://{0}:{1}/SharedGame", this.myIP, this.myPort));
            this.game.attach(this);
            player = new cPlayer("Player" + this.game.Players.Count + 1, "hat", 0);
            this.game.addPlayer(player);

            //ISquare o2 = this.game.GameBoard.getSpecificSquare(0);

            this.mySquares = new Dictionary<int,classes.cGUIWrapper>();
            //this.mySquares.Add(1, new cGUIWrapper(this.ctrlStart,this.game.GameBoard.getSpecificSquare(1)));
            //this.mySquares.Add(2, new cGUIWrapper(this.ctrlRegularSquare1,this.game.GameBoard.getSpecificSquare(2)));
            //this.mySquares.Add(3, new cGUIWrapper(this.ctrlCommunitySquare1,this.game.GameBoard.getSpecificSquare(3)));
            //this.mySquares.Add(4, new cGUIWrapper(this.ctrlRegularSquare2,this.game.GameBoard.getSpecificSquare(4)));
            //this.mySquares.Add(5, new cGUIWrapper(this.ctrlTaxSquare1 ,this.game.GameBoard.getSpecificSquare(5)));
            //this.mySquares.Add(6, new cGUIWrapper(this.ctrlTrainStationSquare1,this.game.GameBoard.getSpecificSquare(6)));
            //this.mySquares.Add(7, new cGUIWrapper(this.ctrlRegularSquare3,this.game.GameBoard.getSpecificSquare(7)));
            //this.mySquares.Add(8, new cGUIWrapper(this.ctrlActionSquare1,this.game.GameBoard.getSpecificSquare(8)));
            //this.mySquares.Add(9, new cGUIWrapper(this.ctrlRegularSquare4, this.game.GameBoard.getSpecificSquare(9)));
            //this.mySquares.Add(10, new cGUIWrapper(this.ctrlRegularSquare5, this.game.GameBoard.getSpecificSquare(10)));
            //this.mySquares.Add(11, new cGUIWrapper(this.ctrlPrisonSquare1 ,this.game.GameBoard.getSpecificSquare(11)));
            //this.mySquares.Add(12, new cGUIWrapper(this.ctrlPrisonVisitorSquare1,this.game.GameBoard.getSpecificSquare(12)));
            //this.mySquares.Add(13, new cGUIWrapper(this.ctrlRegularSquare6, this.game.GameBoard.getSpecificSquare(13)));
            //this.mySquares.Add(14, new cGUIWrapper(this.ctrlWaterPowerSquare1,this.game.GameBoard.getSpecificSquare(14)));
            //this.mySquares.Add(15, new cGUIWrapper(this.ctrlRegularSquare7, this.game.GameBoard.getSpecificSquare(15)));
            //this.mySquares.Add(16, new cGUIWrapper(this.ctrlRegularSquare8, this.game.GameBoard.getSpecificSquare(16)));
            //this.mySquares.Add(17, new cGUIWrapper(this.ctrlTrainStationSquare2,this.game.GameBoard.getSpecificSquare(17)));
            //this.mySquares.Add(18, new cGUIWrapper(this.ctrlRegularSquare9, this.game.GameBoard.getSpecificSquare(18)));
            //this.mySquares.Add(19, new cGUIWrapper(this.ctrlCommunitySquare2,this.game.GameBoard.getSpecificSquare(19)));
            //this.mySquares.Add(20, new cGUIWrapper(this.ctrlRegularSquare10, this.game.GameBoard.getSpecificSquare(20)));
            //this.mySquares.Add(21, new cGUIWrapper(this.ctrlRegularSquare11, this.game.GameBoard.getSpecificSquare(21)));
            //this.mySquares.Add(22, new cGUIWrapper(this.ctrlFreeParkSquare1,this.game.GameBoard.getSpecificSquare(22)));
            //this.mySquares.Add(23, new cGUIWrapper(this.ctrlRegularSquare12, this.game.GameBoard.getSpecificSquare(23)));
            //this.mySquares.Add(24, new cGUIWrapper(this.ctrlActionSquare2,this.game.GameBoard.getSpecificSquare(24)));
            //this.mySquares.Add(25, new cGUIWrapper(this.ctrlRegularSquare13, this.game.GameBoard.getSpecificSquare(25)));
            //this.mySquares.Add(26, new cGUIWrapper(this.ctrlRegularSquare14, this.game.GameBoard.getSpecificSquare(26)));
            //this.mySquares.Add(27, new cGUIWrapper(this.ctrlTrainStationSquare3,this.game.GameBoard.getSpecificSquare(27)));
            //this.mySquares.Add(28, new cGUIWrapper(this.ctrlRegularSquare15, this.game.GameBoard.getSpecificSquare(28)));
            //this.mySquares.Add(29, new cGUIWrapper(this.ctrlRegularSquare16, this.game.GameBoard.getSpecificSquare(29)));
            //this.mySquares.Add(30, new cGUIWrapper(this.ctrlWaterPowerSquare2,this.game.GameBoard.getSpecificSquare(30)));
            //this.mySquares.Add(31, new cGUIWrapper(this.ctrlRegularSquare17, this.game.GameBoard.getSpecificSquare(31)));
            //this.mySquares.Add(32, new cGUIWrapper(this.ctrlGoToPrison1,this.game.GameBoard.getSpecificSquare(32)));
            //this.mySquares.Add(33, new cGUIWrapper(this.ctrlRegularSquare18, this.game.GameBoard.getSpecificSquare(33)));
            //this.mySquares.Add(34, new cGUIWrapper(this.ctrlRegularSquare19, this.game.GameBoard.getSpecificSquare(34)));
            //this.mySquares.Add(35, new cGUIWrapper(this.ctrlCommunitySquare3,this.game.GameBoard.getSpecificSquare(35)));
            //this.mySquares.Add(36, new cGUIWrapper(this.ctrlRegularSquare20, this.game.GameBoard.getSpecificSquare(36)));
            //this.mySquares.Add(37, new cGUIWrapper(this.ctrlTrainStationSquare4,this.game.GameBoard.getSpecificSquare(37)));
            //this.mySquares.Add(38, new cGUIWrapper(this.ctrlActionSquare3,this.game.GameBoard.getSpecificSquare(38)));
            //this.mySquares.Add(39, new cGUIWrapper(this.ctrlRegularSquare21, this.game.GameBoard.getSpecificSquare(39)));
            //this.mySquares.Add(40, new cGUIWrapper(this.ctrlTaxSquare2,this.game.GameBoard.getSpecificSquare(40)));
            //this.mySquares.Add(41, new cGUIWrapper(this.ctrlRegularSquare22, this.game.GameBoard.getSpecificSquare(41)));

            foreach(KeyValuePair<int, cGUIWrapper> entry in this.mySquares)
            {
                //set streetname on gui
                entry.Value.GUICtrl.ctrlName = entry.Value.oSquare.ctrlName;

                
                //set color on streets
                if (entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlRegularSquare))
                {
                    ctrl.ctrlRegularSquare o = (ctrl.ctrlRegularSquare)entry.Value.GUICtrl;
                    o.StreetColor = entry.Value.oSquare.colorStreet;
                    o.BorderStyle = BorderStyle.FixedSingle;

                }

                if (entry.Key >= 13 && entry.Key <=21 || entry.Key >= 33 && entry.Key <= 41)
                {
                    if (entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlRegularSquare))
                    {
                        ctrl.ctrlRegularSquare o = (ctrl.ctrlRegularSquare)entry.Value.GUICtrl;
                        o.orientation = Orientation.Vertical;
                    }
                }

            }


        }

        public void updateActions()
        {
            //if (this.game.CurPlayer == this.player)
            //{
            foreach (IAction action in this.game.Actions)
            {
                //Button btn = new Button();
                //btn.Text = action.getName();
                //btn.Tag = action;
                //btn.Click += new EventHandler(runAction);
                //this.pnlAction.Controls.Add(btn);
            }
            //}            
        }



        public void updateAll()
        {
        //    refreshAvatarPositions();
            updatePlayerList();
       }

        public void updatePlayerList()
        {
            //this.lstPlayers.Items.Clear();
            foreach (cPlayer player in this.game.Players)
            {
                Debug.WriteLine(String.Format("player_{0}",player.Name));
                this.lstPlayers.Items.Add(player.Name);
            }
        }


    }
}
