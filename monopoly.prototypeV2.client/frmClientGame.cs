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
            this.game.attach(this);
            this.game.addPlayer(new cPlayer("Player" + this.game.getPlayers().Count+1, "hat", 0));
        }

        public void updateAll()
        {
            refreshAvatarPositions();
            updatePlayerList();
        }

        public void updateActions()
        {
            foreach (IAction action in this.game.getActions())
            {
                Button btn = new Button();
                btn.Text = action.getName();
                //btn.Click += action.runAction();
                this.pnlAction.Controls.Add(btn);
            }
        }

        public void updatePlayerList()
        {
            this.lstPlayers.Items.Clear();
            foreach (cPlayer player in this.game.getPlayers())
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

            foreach (cPlayer player in this.game.getPlayers())
            {
                rm = Resources.ResourceManager;
                bmp = (Bitmap)rm.GetObject(player.Avatar.Token);
                
                //box = (PictureBox)this.tblLayPnl.Controls["field" + player.CurPos];
                field = (FlowLayoutPanel) this.tblLayPnl.Controls["field" + player.CurPos];
                /*if (box.Image != null)
                {
                    using (Graphics g = Graphics.FromImage(box.Image))
                    {
                        g.DrawImageUnscaled(bmp, 5, 5);
                    }
                }
                else
                {
                    box.Image = bmp;
                }*/
                picBoxAvatar = new PictureBox();
                picBoxAvatar.Image = bmp;
                field.Controls.Add(picBoxAvatar);
            }
        }
    }
}
