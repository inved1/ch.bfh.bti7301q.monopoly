using monopoly.client;
using monopoly.client.form;
using monopoly.logic.classes;
using monopoly.logic.classes.actions;
using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace monopoly.tester
{
    public partial class GameTest : Form
    {
        private cGame game;
        public GameTest()
        {
            game = new cGame();
            InitializeComponent();
            init();
        }

        public void init()
        {
            cPlayer player;
            player = new cPlayer("Player1", "hat", 0);
            player.addMoney(10000);
            this.game.addPlayer(player, null);

            player = new cPlayer("Player2", "ship", 0);
            player.addMoney(10000);
            this.game.addPlayer(player, null);

            player = new cPlayer("Player3", "dog", 0);
            player.addMoney(10000);
            this.game.addPlayer(player, null);
            this.game.CurPlayer = this.game.PlayerObservers.Keys.First();

            btnRoll.Tag = new cActionRoll(this.game);
            btnRoll.Click += new EventHandler(runAction);
            
            //btnBuySquare.Tag = new cActionBuySquare(this.game);
            btnBuySquare.Click += new EventHandler(runAction);

            btnEndTurn.Tag = new cActionEndTurn(this.game);
            btnEndTurn.Click += new EventHandler(runAction);

            //btnGiveUp.Tag = new cActionGiveUp(this.game);
            //btnGiveUp.Click += new EventHandler(runAction);

            this.game.GameStatus = cGame.eGameStatus.DetermineStartPlayer;
        }

        public void runAction(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            IAction action = (IAction)btn.Tag;
            action.runAction();
        }
    }
}
