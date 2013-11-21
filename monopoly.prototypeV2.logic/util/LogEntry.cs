using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.util
{

    
    public class LogEntry
    {
        //getters setters
        public String Msg { get; set; }
        public String LogTime { get; set; }
        public String LogDate { get; set; }

        public LogEntry(String msg)
        {
            this.Msg = msg;
            this.LogDate = DateTime.Now.ToString("dd.MM.yyyy");
            this.LogTime = DateTime.Now.ToString("hh:mm:ss");
        }
                
    }
}
