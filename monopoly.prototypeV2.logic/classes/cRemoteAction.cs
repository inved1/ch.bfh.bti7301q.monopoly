using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes
{
    public class cRemoteAction: MarshalByRefObject
    {

        public cRemoteAction() { }

        public void setObject(List<IAction> lst)
        {
            Cache.getInstance().setObject = lst;
        }
    }
}
