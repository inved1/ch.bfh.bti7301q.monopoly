using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

namespace monopoly.prototype.logic
{

    public class myRemoteAction : MarshalByRefObject
    {

        public myRemoteAction() { }

        public void setObject(dummyAction o)
        {
            Cache.getInstance().setObject = o;
        }

    }
}
