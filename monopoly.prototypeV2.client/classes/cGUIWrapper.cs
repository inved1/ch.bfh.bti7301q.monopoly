using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.client.classes
{
    class cGUIWrapper
    {
        private System.Windows.Forms.Control myGUICtrl;
        private monopoly.prototypeV2.logic.interfaces.ISquare mySquare;

        public cGUIWrapper(System.Windows.Forms.Control oGUIctrl, monopoly.prototypeV2.logic.interfaces.ISquare oSquare)
        {
            this.myGUICtrl = oGUIctrl;
            this.mySquare = oSquare;
        }

        public System.Windows.Forms.Control GUICtrl
        {
            get { return this.myGUICtrl; }
        }

        public monopoly.prototypeV2.logic.interfaces.ISquare oSquare
        {
            get { return this.mySquare; }
        }
        
    }
}
