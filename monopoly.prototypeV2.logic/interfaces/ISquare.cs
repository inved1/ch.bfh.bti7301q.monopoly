using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.interfaces
{
    public interface ISquare
    {
        String ctrlName { get; }

        String colorStreet { get; set; }


        void playAction();
    }
}
