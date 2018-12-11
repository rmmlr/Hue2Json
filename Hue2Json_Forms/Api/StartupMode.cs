using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Api
{
    public enum StartupMode
    {
        [StartupMode("Safety")]
        Safety,
        [StartupMode("Stromausfall")]
        Powerfail,
        [StartupMode("Letzter An-Zustand")]
        LastOnState,
        [StartupMode("Benutzerdefiniert")]
        Custom,
        [StartupMode("Nicht Unterstützt")]
        NotSupported
    }
}
