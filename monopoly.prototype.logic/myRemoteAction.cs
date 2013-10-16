using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using monopoly.prototype.logic.interfaces;

namespace monopoly.prototype.logic
{

    public class myRemoteAction : MarshalByRefObject
    {

        public myRemoteAction() { }

        public void setObject(List<IAction>  lst)
        {
            Cache.getInstance().setObject = lst;
        }

    }
}
