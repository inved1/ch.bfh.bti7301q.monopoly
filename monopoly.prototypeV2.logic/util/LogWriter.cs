using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monopoly.prototypeV2.logic.util
{
    public class LogWriter
    {
        private static LogWriter instance = null;
        private static Queue<LogEntry> myQueue;
        private static String myLogDir ;
        private static String myLogFile;


        //singelton

        private LogWriter() { }

        public static LogWriter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance  = new LogWriter();
                    myQueue = new Queue<LogEntry>();

                    myLogDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    myLogFile = String.Format("log_monopoly_{0}.txt", DateTime.Now.ToString("ddMMyyyy"));

                }
                return instance;
            }
        }

        public void WriteLogQueue(String msg)
        {

            //lock
            lock (myQueue)
            {
                LogEntry l = new LogEntry(msg);
                myQueue.Enqueue(l);
            }
            WriteLogFile();

        }

        private void WriteLogFile()
        {
            while (myQueue.Count > 0)
            {
                LogEntry l = myQueue.Dequeue();
                String sFullFilename = System.IO.Path.Combine(myLogDir, "Monopoly_log", myLogFile);
                if  (System.IO.Directory.Exists(System.IO.Path.Combine(myLogDir,"Monopoly_log")) == false)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(myLogDir, "Monopoly_log"));
                }

                using (System.IO.FileStream f = System.IO.File.OpenWrite(sFullFilename))
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(f))
                    {
                        w.WriteLine(String.Format("{0} | {1} | {2}", l.LogDate, l.LogTime, l.Msg));
                    }
                }
            }
        }



    }
}
