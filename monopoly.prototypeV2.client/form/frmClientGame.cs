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
using System.Diagnostics;
using System.IO;
using System.Resources;
using monopoly.prototypeV2.client.Properties;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

namespace monopoly.prototypeV2.client
{
    public partial class frmClientGame : Form, IObserverGUI
    {
        private String myIP = "";
        private String myPort = "";
        private cGame game;
        private cPlayer player;


        public frmClientGame(String ip, String Port)
        {
            InitializeComponent();
            this.myIP = ip;
            this.myPort = Port;
            init();
        }

        public void init()
        {
            this.game = (cGame)System.Activator.GetObject(typeof(cGame), String.Format("tcp://{0}:{1}/SharedGame", this.myIP, this.myPort));
            player = new cPlayer("Player" + this.game.Players.Count + 1, "hat", 0);
            this.game.addPlayer(player, this );
        }

        public void updateAll()
        {
            refreshAvatarPositions();
            updatePlayerList();
        }

        public void updateActions()
        {
            //if (this.game.CurPlayer == this.player)
            //{
                foreach (IAction action in this.game.Actions)
                {
                    Button btn = new Button();
                    btn.Text = action.getName();
                    btn.Tag = action;
                    btn.Click += new EventHandler(runAction);
                    this.pnlAction.Controls.Add(btn);
                }
            //}            
        }

        private void runAction(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            IAction action = (IAction)btn.Tag;
            action.runAction();
        }

        public void updatePlayerList()
        {
            this.lstPlayers.Items.Clear();
            foreach (cPlayer player in this.game.Players)
            {
                this.lstPlayers.Items.Add(player.Name);
            }
        }

        public void refreshAvatarPositions()
        {
            ResourceManager rm;
            Bitmap bmp;
            PictureBox picBoxAvatar;
            //PictureBox box;
            FlowLayoutPanel field;

            foreach (cPlayer player in this.game.Players)
            {
                rm = Resources.ResourceManager;
                bmp = (Bitmap)rm.GetObject(player.Avatar.Token);
                
                field = (FlowLayoutPanel) this.tblLayPnl.Controls["field" + player.CurPos];

                picBoxAvatar = new PictureBox();
                picBoxAvatar.Image = bmp;
                field.Controls.Add(picBoxAvatar);
            }
        }

        public void onUpdateGUIEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
