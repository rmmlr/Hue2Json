using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rca.Hue2Json.Logging
{
    public class Logger
    {

        const int COLUMNWITH_LEVEL = 14;
        const int COLUMNWITH_MESSAGE = 128;

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
            LogMessageEvent?.Invoke(message, level);

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

            string levelHeader = "Level".PadRight(COLUMNWITH_LEVEL, ' ');
            string messageHeader = "Message".PadRight(COLUMNWITH_MESSAGE, ' ');
            var levelSep = new string('-', COLUMNWITH_LEVEL);
            var messageSep = new string('-', COLUMNWITH_MESSAGE);

            logStream = new StreamWriter(filename);
            logStream.WriteLine("# Hue2Json LogFile");
            logStream.WriteLine("");
            logStream.WriteLine("Version: " + Application.ProductVersion);
            logStream.WriteLine("");
            logStream.WriteLine("| TimeStamp    | {0} | {1} |", levelHeader, messageHeader);
            logStream.WriteLine("| ------------ | {0} | {1} |", levelSep, messageSep);

            logStream.Flush();
        }

        static void appendLogMessage(string message, LogLevel level)
        {
            if (logStream == null)
                generateNewLogfile();

            string levelStr = level.ToString().PadRight(COLUMNWITH_LEVEL, ' ');
            message = message.PadRight(COLUMNWITH_MESSAGE, ' ');

            logStream.WriteLine("| {0:H:mm:ss.fff} | {1} | {2} |", DateTime.Now, levelStr, message);
            logStream.Flush();
        }

        #endregion Internal services

        #region Events
        public delegate void LogMessageEventHandler(string message, LogLevel level);
        public static event LogMessageEventHandler LogMessageEvent;

        #endregion Events
    }
}
