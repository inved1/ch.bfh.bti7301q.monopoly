using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace monopoly.logic.classes
{
    [Serializable]
    public class cAvatar
    {
        private string token = "";
        private Image myImage = null;

        public cAvatar(string token)
        {
            this.token = token;

            System.Resources.ResourceManager rm = monopoly.logic.Properties.Resources.ResourceManager;
            this.myImage = (Image)rm.GetObject(token);
            
        }

        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        public Image getImage()
        {
            return this.myImage ;
        }
    }
}
