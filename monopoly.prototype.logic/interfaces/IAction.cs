using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic.interfaces
{
    public interface IAction
    {
        string Name { get; set; }
        void runAction();
    }
}
