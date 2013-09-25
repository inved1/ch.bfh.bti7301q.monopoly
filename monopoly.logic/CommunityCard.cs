using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.logic
{
    class CommunityCard : ICommunityCard 
    {
        public CommunityCard(string Name, string Actiontext)
        {
            this.Name = Name;
            this.Actiontext = Actiontext;
        }


        public string Name
        {
            get; set;
        }

        public string Actiontext
        {
            get; set;
        }
    }
}
