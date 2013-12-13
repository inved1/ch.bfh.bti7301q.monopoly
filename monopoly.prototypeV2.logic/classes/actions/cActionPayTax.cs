﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes.actions
{
    [Serializable]
    public class cActionPayTax
    {
        #region "vars"
        const string ACTION_NAME = "Kaufen";
        private cGame game = null;
        #endregion

        public cActionPayTax(cGame game)
        {
            this.game = game;
        }

        public string getName()
        {
            return ACTION_NAME;
        }

        public void runAction()
        {
            this.game.playerPaysTax();
        }
    }
}