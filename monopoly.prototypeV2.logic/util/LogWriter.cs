using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.prototypeV2.logic.classes;

namespace monopoly.prototypeV2.logic.util
{
    public class LogWriter
    {
        private static LogWriter instance = null;
        private static Queue<LogEntry> myQueue;
        private static String myLogDir ;
        private static String myLogFile;
        private static cConfig myConfig;


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
                    myConfig = cConfig.getInstance();

                    if (myConfig.Logger["LoggerDirectory"] == "Desktop")
                    {
                        myLogDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    }
                    else
                    {
                        myLogDir = myConfig.Logger["LoggerDirectory"];
                    }
                    myLogFile = String.Format("{0}_{1}.txt", myConfig.Logger["LoggerFilename"] ,DateTime.Now.ToString("ddMMyyyy"));

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
