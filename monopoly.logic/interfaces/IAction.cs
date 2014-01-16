using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.logic.classes;

namespace monopoly.logic.interfaces
{
    public interface IAction
    {
        string getName();
        void runAction();
    }
}
