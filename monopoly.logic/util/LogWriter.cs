﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using monopoly.logic.classes;

namespace monopoly.logic.util
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
                    myConfig = cConfig.getInstance;

                    if (myConfig.Logger["LoggerDirectory"] == "Desktop")
                    {
                        myLogDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    }
                    else
                    {
                        myLogDir = myConfig.Logger["LoggerDirectory"];
                    }
                    myLogFile = String.Format("{0}_{1}_{2}.txt", myConfig.Logger["LoggerFilename"] ,DateTime.Now.ToString("ddMMyyyy"),new Random().Next(0,9999));

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

                if (!System.IO.File.Exists(sFullFilename))
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(sFullFilename))
                    {
                        sw.WriteLine(String.Format("{0} | {1} | {2}", l.LogDate, l.LogTime, l.Msg));
                    }
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText (sFullFilename))
                    {
                        sw.WriteLine(String.Format("{0} | {1} | {2}", l.LogDate, l.LogTime, l.Msg));
                    }
                }
                
            }
        }



    }
}
