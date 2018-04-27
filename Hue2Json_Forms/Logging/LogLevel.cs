using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Logging
{
    public enum LogLevel
    {
        /// <summary>
        /// Kritischer Fehler welcher zum Programm-Absturz führt
        /// </summary>
        CriticalError = -3,
        /// <summary>
        /// Allgemeiner Fehler
        /// </summary>
        Error = -2,
        /// <summary>
        /// Warnung
        /// </summary>
        Warning = -1,
        /// <summary>
        /// Information
        /// </summary>
        Info = 0,
        /// <summary>
        /// Anzeigemeldung
        /// </summary>
        DisplayMessage = 1,
        /// <summary>
        /// Restore Info
        /// </summary>
        RestoreInfo = 2,
        /// <summary>
        /// Simulationsbetrieb
        /// </summary>
        Simulation = 10,
    }
}
