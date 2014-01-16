﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.classes;

namespace monopoly.prototypeV2.logic.interfaces
{
    public interface IObserverGUI
    {

        void onUpdateGUIEvent(object sender, EventArgs e);

        void onUpdateGUIActionsEvent(object sender, EventArgs e);

        void onUpdateGUITradeEvent(object sender, EventArgs e);
    }
}
