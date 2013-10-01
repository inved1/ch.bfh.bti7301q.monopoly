using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototype.logic
{
    public class Cache
    {
        private static Cache myCache;
        public static IObserver myObserver;

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


        public static void Attach(IObserver obs)
        {
            myObserver = obs;
        }

        public dummyAction setObject
        {
            set
            {
                myObserver.Notify(value);
            }
        }
    }
}
