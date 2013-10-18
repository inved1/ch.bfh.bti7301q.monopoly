using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototype.logic.interfaces;

namespace monopoly.prototype.logic
{
    public interface IObserver
    {
        void Update(List<IAction> lst);
    }
}
