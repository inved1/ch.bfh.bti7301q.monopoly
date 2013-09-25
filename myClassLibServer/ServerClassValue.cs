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
            Console.WriteLine("value before call: " + o.testValue.ToString());
            o.CallMe();
            Console.WriteLine("value after call: " + o.testValue.ToString());
        }


    }

    [Serializable]
    public class ForwardMe
    {
                
        
        private int myTestVal;
        
        public  ForwardMe()
        {
            this.myTestVal = 0;
        }


        public  void CallMe()
        {   
 	        Console.WriteLine("CallMe was executed in: " + Process.GetCurrentProcess().ProcessName.ToString());

        }
        public int testValue
        {
            get {return this.myTestVal ;}
            set {this.myTestVal = value; }

        }
    }
}
