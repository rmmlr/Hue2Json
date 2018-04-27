using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    public enum BridgeResult
    {
        Error = -1,
        SuccessfulConnected,
        UnauthorizedUser,
        MissingUser,
        LinkButtonNotPressed,
        UserCreated,
        UserAlreadyExists
    }
}
