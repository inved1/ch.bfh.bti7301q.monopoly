using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myClassLibServer
{
    public class ServerClassValue
    {
    }

    public class HelloServer : MarshalByRefObject
    {
        public void HelloMethod(ForwardMe o)
        {
            o.CallMe();
        }


    }

    [Serializable]
    public class ForwardMe
    {

        public  void CallMe()
        {   
 	        Console.WriteLine("CallMe was executed in: " + Process.GetCurrentProcess().ProcessName.ToString());

        }
    }
}
