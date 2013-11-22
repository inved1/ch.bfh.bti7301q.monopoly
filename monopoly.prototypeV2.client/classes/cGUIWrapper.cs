﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.client.interfaces;

namespace monopoly.prototypeV2.client.classes
{
    class cGUIWrapper
    {
        private IctrlSquare myGUICtrl;
        private monopoly.prototypeV2.logic.interfaces.ISquare mySquare;

        public cGUIWrapper(IctrlSquare oGUIctrl, monopoly.prototypeV2.logic.interfaces.ISquare oSquare)
        {
            this.myGUICtrl = oGUIctrl;
            this.mySquare = oSquare;
        }

        public  IctrlSquare GUICtrl
        {
            get { return this.myGUICtrl; }
        }

        public monopoly.prototypeV2.logic.interfaces.ISquare oSquare
        {
            get { return this.mySquare; }
        }
        
    }
}
