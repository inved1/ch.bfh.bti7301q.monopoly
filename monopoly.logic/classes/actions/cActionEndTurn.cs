﻿using monopoly.logic.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic.classes.actions
{
    [Serializable]
    public class cActionEndTurn : IAction
    {
        const string ACTION_NAME = "Zug beenden";
        private cGame game;

        public cActionEndTurn(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        {
            this.game.playerEndsTurn();
        }
    }
}
