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
    public class cHotel : IRealEstate
    {
        private Image myImage = null;
 
        public cHotel()
        {

            System.Resources.ResourceManager rm = monopoly.prototypeV2.logic.Properties.Resources.ResourceManager;
            this.myImage = (Image)rm.GetObject("monopoly_hotel");
        }

        public System.Drawing.Image getImage()
        {
            return this.myImage;
        }
    }
}
