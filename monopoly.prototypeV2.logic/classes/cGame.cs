using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    public class cGame : MarshalByRefObject
    {

        private int counter = 0;
        public cGame() { }


        public String helloWorld()
        {
            this.counter += 1;
            return "Hello World, " + counter.ToString ();
            
        }


    }
}
