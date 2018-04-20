using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json
{
    public class Logger
    {
        #region Member
        static StreamWriter logStream;

        #endregion Member

        #region Properties


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for Logger
        /// </summary>
        public Logger()
        {

        }

        #endregion Constructor

        #region Services

        public static void WriteToLog(string message, LogLevel level = LogLevel.Info)
        {
            LogMessageEvent?.Invoke(message);

            appendLogMessage(message, level);
        }

        #endregion Services

        #region Internal services
        static void generateNewLogfile(string path = null)
        {
            if (path != null)
                throw new NotImplementedException();

            string filename = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log";

            if (File.Exists(filename))
                filename = filename.Insert(15, "_1"); //Maximal 2 Log-Files je Sekunde

            logStream = new StreamWriter(filename);

            logStream.WriteLine("# Hue2Json LogFile");
            logStream.WriteLine("");
            logStream.WriteLine("Version: " + Application.ProductVersion);
            logStream.WriteLine("");
            logStream.WriteLine("| TimeStamp | Level | Message |");
            logStream.WriteLine("| --------- | ----- | ------- |");

            logStream.Flush();
        }

        static void appendLogMessage(string message, LogLevel level)
        {
            if (logStream == null)
                generateNewLogfile();

            logStream.WriteLine("| {0:H:mm:ss.fff} | {1} | {2} |", DateTime.Now, level, message);
            logStream.Flush();
        }

        #endregion Internal services

        #region Events
        public delegate void LogMessageEventHandler(string str);
        public static event LogMessageEventHandler LogMessageEvent;

        #endregion Events
    }
}
