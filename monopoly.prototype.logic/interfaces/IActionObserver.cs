using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic.interfaces
{
    public interface IActionObserver
    {
        void UpdateActions(List<IAction> lstActions);
    }
}
