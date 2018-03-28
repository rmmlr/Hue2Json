using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    /// <summary>
    /// Option zur Auswahl der zu anonymisierenden Daten
    /// </summary>
    public enum AnonymizeOptions
    {
        /// <summary>
        /// IDs und Sereinnummern
        /// </summary>
        Serials = 2,
        /// <summary>
        /// Namen und Beschreibungen
        /// </summary>
        Names = 4
    }
}
