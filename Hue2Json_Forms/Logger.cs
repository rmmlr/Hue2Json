using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    public class Logger
    {
        #region Member


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

        public static void WriteToLog(string message)
        {
            LogMessageEvent?.Invoke(message);
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events
        public delegate void LogMessageEventHandler(string str);
        public static event LogMessageEventHandler LogMessageEvent;

        #endregion Events
    }
}
