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
using monopoly.prototypeV2.logic.classes.squares ;
using monopoly.prototypeV2.client.classes;
using monopoly.prototypeV2.client.Properties;
using monopoly.prototypeV2.client.ctrl; 
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Diagnostics;
using System.Resources;
using System.Runtime.Remoting;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using monopoly.prototypeV2.logic.classes.actions;
using System.Drawing.Drawing2D;

namespace monopoly.prototypeV2.client.form
{
    [Serializable ]
    public partial class frmClientGame_V02 : Form, IObserverGUI
    {



        private String myIP = "";
        private String myPort = "";
        private String myAvatar = "";
        private String myPlayerName = "";
        private cGame myGame;
        private cPlayer myPlayer;
        private Dictionary<int, classes.cGUIWrapper> mySquares;
        private List<Point> myTPCardLocations;
        private List<IRealEstate> myRealEstates;

        public frmClientGame_V02(String ip, String Port)
        {
            InitializeComponent();

            this.myIP = ip;
            this.myPort = Port;
            init();
        }

        public frmClientGame_V02(string IPandPort)
        {
            InitializeComponent();

            this.myIP = IPandPort.Substring(0, IPandPort.IndexOf(":"));
            this.myPort = IPandPort.Substring(IPandPort.IndexOf(":"), IPandPort.Length);
            init();
        }

        public frmClientGame_V02(string IPandPort, String playerName, String Avatar)
        {
            InitializeComponent();

            this.myIP = IPandPort.Substring(0, IPandPort.IndexOf(":"));
            this.myPort = IPandPort.Replace(this.myIP, "").Replace(":", "");
            this.myAvatar = Avatar;
            this.myPlayerName = playerName;
            this.mySquares = new Dictionary<int, cGUIWrapper>();


            init();
        }


        private ISquare getSpecificSquare(int pos)
        {
            return this.myGame.getSpecificSquare(pos);
        }

        private void init()
        {
            //attentione !!!!
#if DEBUG
            // TcpChannel tcpChannel = new TcpChannel(0);
            // ChannelServices.RegisterChannel(tcpChannel, false);
#else
            BinaryServerFormatterSinkProvider serverSinkProvider = new BinaryServerFormatterSinkProvider();
            serverSinkProvider.TypeFilterLevel = TypeFilterLevel.Full;

            BinaryClientFormatterSinkProvider clientSinkProvider = new BinaryClientFormatterSinkProvider();
            Hashtable channelProperties = new Hashtable();
            channelProperties["port"] = 0;
            TcpChannel tcpChannel = new TcpChannel(channelProperties, clientSinkProvider, serverSinkProvider);
            ChannelServices.RegisterChannel(tcpChannel, false);
#endif


            //RemotingConfiguration.RegisterActivatedClientType(typeof(cGame), String.Format("tcp://{0}:{1}/SharedGame", this.myIP, this.myPort));
            this.myGame = (cGame)System.Activator.GetObject(typeof(cGame), String.Format("tcp://{0}:{1}/SharedGame", this.myIP, this.myPort));
            //this.myGame = new cGame();
            this.myPlayer = new cPlayer(this.myPlayerName, this.myAvatar, 0);
            this.myGame.addPlayer(this.myPlayer, this);

            if (this.myGame.PlayerObservers.Count > 1)
            {
                this.button1.Visible = false;
            }

            this.myTPCardLocations = new List<Point>();
            this.myRealEstates = new List<IRealEstate>();

            for(int i= 0; i<=26;i++){
                myTPCardLocations.Add(new Point((i*200)+2, 2));
                

            }


            this.mySquares.Add(0, new cGUIWrapper(this.ctrlStart, getSpecificSquare(0)));
            this.mySquares.Add(1, new cGUIWrapper(this.ctrlRegularSquare1, getSpecificSquare(1)));
            this.mySquares.Add(2, new cGUIWrapper(this.ctrlCommunitySquare1, getSpecificSquare(2)));
            this.mySquares.Add(3, new cGUIWrapper(this.ctrlRegularSquare2, getSpecificSquare(3)));
            this.mySquares.Add(4, new cGUIWrapper(this.ctrlTaxSquare1, getSpecificSquare(4)));
            this.mySquares.Add(5, new cGUIWrapper(this.ctrlTrainStationSquare1, getSpecificSquare(5)));
            this.mySquares.Add(6, new cGUIWrapper(this.ctrlRegularSquare3, getSpecificSquare(6)));
            this.mySquares.Add(7, new cGUIWrapper(this.ctrlActionSquare1, getSpecificSquare(7)));
            this.mySquares.Add(8, new cGUIWrapper(this.ctrlRegularSquare4, getSpecificSquare(8)));
            this.mySquares.Add(9, new cGUIWrapper(this.ctrlRegularSquare5, getSpecificSquare(9)));
            this.mySquares.Add(99, new cGUIWrapper(this.ctrlPrisonSquare1, getSpecificSquare(99)));
            this.mySquares.Add(10, new cGUIWrapper(this.ctrlPrisonVisitorSquare1, getSpecificSquare(10)));
            this.mySquares.Add(11, new cGUIWrapper(this.ctrlRegularSquare6, getSpecificSquare(11)));
            this.mySquares.Add(12, new cGUIWrapper(this.ctrlWaterPowerSquare1, getSpecificSquare(12)));
            this.mySquares.Add(13, new cGUIWrapper(this.ctrlRegularSquare7, getSpecificSquare(13)));
            this.mySquares.Add(14, new cGUIWrapper(this.ctrlRegularSquare8, getSpecificSquare(14)));
            this.mySquares.Add(15, new cGUIWrapper(this.ctrlTrainStationSquare2, getSpecificSquare(15)));
            this.mySquares.Add(16, new cGUIWrapper(this.ctrlRegularSquare9, getSpecificSquare(16)));
            this.mySquares.Add(17, new cGUIWrapper(this.ctrlCommunitySquare2, getSpecificSquare(17)));
            this.mySquares.Add(18, new cGUIWrapper(this.ctrlRegularSquare10, getSpecificSquare(18)));
            this.mySquares.Add(19, new cGUIWrapper(this.ctrlRegularSquare11, getSpecificSquare(19)));
            this.mySquares.Add(20, new cGUIWrapper(this.ctrlFreeParkSquare1, getSpecificSquare(20)));
            this.mySquares.Add(21, new cGUIWrapper(this.ctrlRegularSquare12, getSpecificSquare(21)));
            this.mySquares.Add(22, new cGUIWrapper(this.ctrlActionSquare2, getSpecificSquare(22)));
            this.mySquares.Add(23, new cGUIWrapper(this.ctrlRegularSquare13, getSpecificSquare(23)));
            this.mySquares.Add(24, new cGUIWrapper(this.ctrlRegularSquare14, getSpecificSquare(24)));
            this.mySquares.Add(25, new cGUIWrapper(this.ctrlTrainStationSquare3, getSpecificSquare(25)));
            this.mySquares.Add(26, new cGUIWrapper(this.ctrlRegularSquare15, getSpecificSquare(26)));
            this.mySquares.Add(27, new cGUIWrapper(this.ctrlRegularSquare16, getSpecificSquare(27)));
            this.mySquares.Add(28, new cGUIWrapper(this.ctrlWaterPowerSquare2, getSpecificSquare(28)));
            this.mySquares.Add(29, new cGUIWrapper(this.ctrlRegularSquare17, getSpecificSquare(29)));
            this.mySquares.Add(30, new cGUIWrapper(this.ctrlGoToPrison1, getSpecificSquare(30)));
            this.mySquares.Add(31, new cGUIWrapper(this.ctrlRegularSquare18, getSpecificSquare(31)));
            this.mySquares.Add(32, new cGUIWrapper(this.ctrlRegularSquare19, getSpecificSquare(32)));
            this.mySquares.Add(33, new cGUIWrapper(this.ctrlCommunitySquare3, getSpecificSquare(33)));
            this.mySquares.Add(34, new cGUIWrapper(this.ctrlRegularSquare20, getSpecificSquare(34)));
            this.mySquares.Add(35, new cGUIWrapper(this.ctrlTrainStationSquare4, getSpecificSquare(35)));
            this.mySquares.Add(36, new cGUIWrapper(this.ctrlActionSquare3, getSpecificSquare(36)));
            this.mySquares.Add(37, new cGUIWrapper(this.ctrlRegularSquare21, getSpecificSquare(37)));
            this.mySquares.Add(38, new cGUIWrapper(this.ctrlTaxSquare2, getSpecificSquare(38)));
            this.mySquares.Add(39, new cGUIWrapper(this.ctrlRegularSquare22, getSpecificSquare(39)));

            foreach (KeyValuePair<int, cGUIWrapper> entry in this.mySquares)
            {
                //set streetname on gui
                entry.Value.GUICtrl.ctrlTopName = entry.Value.oSquare.ctrlName;


                //set color on streets
                if (entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlRegularSquare))
                {
                    ctrl.ctrlRegularSquare o = (ctrl.ctrlRegularSquare)entry.Value.GUICtrl;
                    o.StreetColor = entry.Value.oSquare.colorStreet;
                    o.BorderStyle = BorderStyle.FixedSingle;

                }
                else if (entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlStartSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlActionSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlFreeParkSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlGoToPrisonSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlPrisonSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlPrisonVisitorSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlTaxSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlTrainStationSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlWaterPowerSquare) ||
                        entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlCommunitySquare))
                {
                    UserControl o = (UserControl)entry.Value.GUICtrl;

                    o.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    Debug.Print(entry.Value.GUICtrl.ToString());
                    Debug.Print(entry.Key.ToString());

                }

                //orientation
                if (entry.Key >= 11 && entry.Key <= 20 || entry.Key >= 31 && entry.Key <= 40)
                {
                    if (entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlRegularSquare)   )
                    {
                        ctrl.ctrlRegularSquare o = (ctrl.ctrlRegularSquare)entry.Value.GUICtrl;
                        o.orientation = Orientation.Vertical;
                    }
                    if(  entry.Value.GUICtrl.GetType() == typeof(ctrl.ctrlTaxSquare))
                    {
                        ctrl.ctrlTaxSquare o = (ctrl.ctrlTaxSquare)entry.Value.GUICtrl;
                        o.orientation = Orientation.Vertical;
                    }
                }

            }



        }

   


        public void runAction(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //frmGenericActions f = (frmGenericActions)btn.Parent.Parent.Parent.Parent  ;
            IAction action = (IAction)btn.Tag;
            action.runAction();
        }

        public void runBuild(object sender, EventArgs e, int squareNr)
        {
            Button btn = (Button)sender;
            cActionBuyRealEstate action = (cActionBuyRealEstate)btn.Tag;
            action.runBuyRealEstate(squareNr);
        }

        public void runTrade(object sender, EventArgs e )
        {
            Button btn = (Button)sender;
            IBuyable  action =(IBuyable )btn.Tag;
            //action.runTrade(); 

        }

        public void showBuild(object sender, EventArgs e)
        {
            frmBuild fBuild = new frmBuild();

            foreach (KeyValuePair<int, ISquare> pair in this.myGame.SquaresToBuildOnForCurPlayer) {
                Button btnSquare = new Button();
                btnSquare.Text = pair.Value.ctrlName;
                btnSquare.AutoSize = true;
                btnSquare.Tag = new cActionBuyRealEstate(this.myGame);
                btnSquare.Click += new EventHandler((s, eArg) => runBuild(s, eArg, pair.Key));
                btnSquare.DialogResult = System.Windows.Forms.DialogResult.OK;
                fBuild.addControl(btnSquare);
            }

            if (fBuild.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fBuild.Hide();
                fBuild.Close();
            }
            fBuild.Dispose();
        }
        public void showTrade(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            frmGenericActions f = (frmGenericActions)btn.Parent.Parent.Parent.Parent;
            //IAction action = (IAction)btn.Tag;
            //action.runAction();
            frmTrade fTrade = new frmTrade();
            fTrade.game = this.myGame;
            fTrade.players = this.myGame.Players;
            fTrade.sellable = this.myGame.RegularSquaresByPlayer(this.myPlayer);


            if (fTrade.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fTrade.Hide();
                fTrade.Close();
            }
            fTrade.Dispose();
        }

        delegate void cbGUI(object sender, EventArgs e); //callback

        delegate void cbGUIAction(object sender, EventArgs e); //callback actions

        delegate void cbGUITrade(object sender, EventArgs e); //callback trade


        public void onUpdateGUITradeEvent(object sender, EventArgs e)
        {
            cGame c = (cGame)sender;
            if (c.CurTradePlayer.Name != this.myPlayer.Name)
            {
                return;
            }

            if (this.InvokeRequired )
            {
                cbGUITrade d = new cbGUITrade(onUpdateGUITradeEvent);
                this.BeginInvoke(d, new object[] { sender, e });

            }
            else
            {
                //show f confirm trade
                frmTradeConfirm f = new frmTradeConfirm();
                foreach (KeyValuePair<IBuyable,int> card in this.myGame.TradeCards)
                {

                    f.Text = "Kaufen ?" + System.Environment.NewLine + card.Key.TradeString + System.Environment.NewLine + card.Value.ToString();  

                    
                }
                f.ShowDialog();

            }
        }


        public void onUpdateGUIActionsEvent(object sender, EventArgs e)
        {
            cGame c = (cGame)sender;
         //doensnt work !
            //if (!c.CurPlayer.Equals(this.myPlayer))
            //{
            //    return;
            //}

            //ugly workaround, since only one name is allowed
            if(c.CurPlayer.Name != this.myPlayer.Name )
            {
                return;
            }

            if (this.InvokeRequired) {
                cbGUIAction d = new cbGUIAction(onUpdateGUIActionsEvent);
                this.BeginInvoke(d, new object[] { sender, e });


            }
            else
            {

                frmGenericActions f = new frmGenericActions();
                foreach (IAction action in this.myGame.Actions)
                {
                    Button btn = new Button();
                    if (action.GetType() == typeof(cActionBuySquare))
                    {
                        cActionBuySquare obj = (cActionBuySquare)action;
                        btn.Text = action.getName() + "\n" + obj.getPrice().ToString();
                    }
                    else
                    {
                        btn.Text = action.getName();
                    }
                    
                    btn.AutoSize = true;
                    btn.Tag = action;
                    btn.Click += new EventHandler(runAction);
                    btn.DialogResult = System.Windows.Forms.DialogResult.OK;
                    f.addControl(btn);
                }

                if (this.myGame.CurPlayer.canBuild)
                {
                    Button bBuild = new Button();
                    bBuild.Text = "Bauen";
                    bBuild.Click += new EventHandler(showBuild);
                    f.addControl(bBuild);
                }

                //if (this.myGame.CurPlayer.canTrade)
                //{
                //    Button bTrade = new Button();
                //    bTrade.Text = "Handeln";
                //    bTrade.Click += new EventHandler(showTrade);
                //    f.addControl(bTrade);
                //}

                //ugly workaround
                Form  fx = Application.OpenForms["frmGenericActions"];
                if (fx == null) { 

                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    f.Hide();
                    f.Close();
                }
                f.Dispose();
                }
            }
        }
        public void onUpdateGUIEvent(object sender, EventArgs e)
        {
            if(tp_players.InvokeRequired )
            {
                cbGUI d = new cbGUI(onUpdateGUIEvent);
                tp_players.BeginInvoke (d, new object[] {sender,e} );
            }
            else
            { 
                tp_players.TabPages.Clear();

                ResourceManager rm;
                Bitmap bmp;
                PictureBox picBoxAvatar;

                foreach (KeyValuePair<int, cGUIWrapper> entry in this.mySquares)
                {
                    entry.Value.GUICtrl.clearAvatars();
                    //not possible at the momn
                    //if (entry.Value.oSquare.GetType() == typeof(cRegularSquare ))
                    //{
                    //    ctrlRegularSquare o = (ctrlRegularSquare)entry.Value.GUICtrl;
                    //    //o.clearRealEstates();
                    //}
                    
                }

                foreach (cPlayer p in this.myGame.Players)
                {

                    if (p.Name == this.myPlayer.Name )
                    {
                        this.txt_myMoney.Text = "Aktueller Kontostand: " + p.Amount.ToString() ;
                    }

                    tp_players.TabPages.Add(p.Name,p.Name );
                    TabPage t = tp_players.TabPages[p.Name]  ;
                    t.AutoScroll = true;
                    t.Tag = myTPCardLocations;
                    


                    rm = Resources.ResourceManager;
                    bmp = (Bitmap)rm.GetObject(p.Avatar.Token);
                    

                    interfaces.IctrlSquare sq = this.mySquares[p.CurPos].GUICtrl;
                    picBoxAvatar = new PictureBox();
                    picBoxAvatar.Image = resizeImage(bmp,new Size(20,20));
                    picBoxAvatar.Size = new Size(picBoxAvatar.Image.Width, picBoxAvatar.Image.Height);
                    
                    sq.addAvatar(picBoxAvatar,p.Avatar );


                    int itmp = 0;
                    foreach (cRegularSquare entry in this.myGame.RegularSquaresByPlayer(p) )
                    {
                        TabPage tp = tp_players.TabPages[entry.Owner.Name];
                        ctrlPlayerInfoCard c = new ctrl.ctrlPlayerInfoCard();
                        c.setTopInfo(entry.ctrlName);
                        c.TopBackColor = entry.colorStreet;
                        c.setBottomInfo(entry.CardInfo);
                        List<Point> pt = (List<Point>)t.Tag;
                        c.Location = pt[itmp];
                        t.Controls.Add(c);
                        itmp += 1;
                    }
                    foreach (cWaterPowerSquare entry in this.myGame.WaterPowerSquaresByPlayer(p))
                    {
                        TabPage tp = tp_players.TabPages[entry.Owner.Name];
                        ctrlPlayerInfoCard c = new ctrl.ctrlPlayerInfoCard();
                        c.setTopInfo(entry.ctrlName);
                        c.TopBackColor = entry.colorStreet;
                        c.setBottomInfo("");
                        List<Point> pt = (List<Point>)t.Tag;
                        c.Location = pt[itmp];
                        t.Controls.Add(c);
                        itmp += 1;
                    }
                    foreach (cTrainStationSquare  entry in this.myGame.TrainStationSquaresByPlayer(p))
                    {
                        TabPage tp = tp_players.TabPages[entry.Owner.Name];
                        ctrlPlayerInfoCard c = new ctrl.ctrlPlayerInfoCard();
                        c.setTopInfo(entry.ctrlName);
                        c.TopBackColor = entry.colorStreet;
                        c.setBottomInfo("");
                        List<Point> pt = (List<Point>)t.Tag;
                        c.Location = pt[itmp];
                        t.Controls.Add(c);
                        itmp += 1;
                    }


                }
                //list used to dont loose the references of objects...
                this.myRealEstates.Clear();
                foreach (cRegularSquare oLogic in this.myGame.RegularSquares)
                {
                    //test
                    if (oLogic.GetType() == typeof(cRegularSquare)) { 
                        
                        //ugly workaround, use some linq, because this.mysquares sucks
                        Int32 j = 0;
                        j = this.mySquares.FirstOrDefault(x=>x.Value.oSquare.ctrlName  == oLogic.ctrlName  ).Key ;
                                         
                        ctrlRegularSquare oGUI = (ctrlRegularSquare)this.mySquares[j].GUICtrl;

                        oGUI.clearRealEstates();
                       
                       
                        for (int i = 0; i < oLogic.Houses; i++)
                        {
                            this.myRealEstates.Add(new cHouse());
                            oGUI.addRealEstate(this.myRealEstates.Last()); 
                        }
                        for (int i = 0; i < oLogic.Hotels ; i++)
                        {
                            this.myRealEstates.Add(new cHotel()); 
                            oGUI.addRealEstate(this.myRealEstates.Last());
                        }
                    }

               }



                this.txt_history.Text = this.myGame.strOutput();
                this.txt_history.SelectionStart = this.txt_history.Text.Length;
                this.txt_history.ScrollToCaret();

                this.txtChat.Text = this.myGame.strChatOutput();
                this.txtChat.SelectionStart = this.txtChat.Text.Length;
                this.txtChat.ScrollToCaret();



            }
        }

        //just some nice looking code
        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
    

        private void frmClientGame_V02_FormClosing(object sender, FormClosingEventArgs e)
        {
            //disconnect observer

            this.myGame.removePlayer(this.myPlayer, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.myGame.initGame();
            this.button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.myGame.addChatMsg(this.myPlayer.Name, this.txt_chatSend.Text);
            this.txt_chatSend.Text = "";
            this.txtChat.Text = this.myGame.strChatOutput ();
            this.txtChat.SelectionStart = this.txtChat.Text.Length;
            this.txtChat.ScrollToCaret();
        }



    }
}
