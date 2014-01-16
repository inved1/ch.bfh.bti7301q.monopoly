using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.logic.interfaces;
using System.Drawing;

namespace monopoly.logic.classes
{

    [Serializable]
    public class cHouse : IRealEstate
    {
        private Image myImage = null;
        public   cHouse()
        {

            System.Resources.ResourceManager rm = monopoly.logic.Properties.Resources.ResourceManager;
            this.myImage = (Image)rm.GetObject("monopoly_house");
        }

        public System.Drawing.Image getImage()
        {
            return this.myImage;
        }
    }
}
