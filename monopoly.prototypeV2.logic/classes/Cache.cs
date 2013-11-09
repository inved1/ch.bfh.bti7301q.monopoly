using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.interfaces;

namespace monopoly.prototypeV2.logic.classes
{
    public class Cache
    {
        private static Cache myCache;
        public static IObserverAction myObserver;

        private Cache()
        {
        }


        public static Cache getInstance()
        {
            if (myCache == null)
            {
                myCache = new Cache();
            }
            return myCache;
        }


        public static void Attach(IObserverAction obs)
        {
            myObserver = obs;
        }

        public List<IAction> setObject
        {
            set
            {
                myObserver.notify(value);
            }
        }
    }
}
