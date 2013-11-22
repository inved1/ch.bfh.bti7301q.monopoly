using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;
using System.Drawing;

namespace monopoly.prototypeV2.logic.classes
{

    [Serializable]
    class cHouse : IRealEstate
    {
        private Image myImage = null;
        public   cHouse()
        {

            System.Resources.ResourceManager rm = monopoly.prototypeV2.logic.Properties.Resources.ResourceManager;
            this.myImage = (Image)rm.GetObject("monopoly_house");
        }

        public System.Drawing.Image getImage()
        {
            return this.myImage;
        }
    }
}
