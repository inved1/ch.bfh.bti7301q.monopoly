using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.client.interfaces;

namespace monopoly.client.classes
{
    class cGUIWrapper
    {
        private IctrlSquare myGUICtrl;
        private monopoly.logic.interfaces.ISquare mySquare;

        public cGUIWrapper(IctrlSquare oGUIctrl, monopoly.logic.interfaces.ISquare oSquare)
        {
            this.myGUICtrl = oGUIctrl;
            this.mySquare = oSquare;
        }

        public  IctrlSquare GUICtrl
        {
            get { return this.myGUICtrl; }
        }

        public monopoly.logic.interfaces.ISquare oSquare
        {
            get { return this.mySquare; }
        }
        
    }
}
