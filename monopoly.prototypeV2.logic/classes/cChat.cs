using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.classes
{
    [Serializable]
    public class cChat
    {
        private static cChat myInstance;
        private static SortedDictionary<int, string> myMsgs;
        private static int myKey;

        private cChat()
        {

        }

        public static cChat getInstance
        {
            get
            {
                if (myInstance == null){
                    myInstance = new cChat();
                    myMsgs = new SortedDictionary<int, string>();
                    myKey = 1;
                }
                return myInstance;
            }
        }

        public void addMessage(String Name, String txt)
        {
            myMsgs.Add(myKey, Name +": "+ txt);
            myKey += 1;
        }

        public string strOutput()
        {
            String r = "";
            if (myMsgs != null)
            {
                foreach (KeyValuePair<int, string> entry in myMsgs)
                {
                    r = r + "->" + entry.Value + System.Environment.NewLine;
                }
            }
            return r;
        }


    }
}
