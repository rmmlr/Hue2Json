using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Remapping
{
    /// <summary>
    /// Allgemeiner Fehler innerhalb des ID Remappings
    /// </summary>
    public class RemappingException : Exception
    {
        public RemappingException()
        {
        }

        public RemappingException(string message) : base(message)
        {
        }

        public RemappingException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Leere ID-Map, keine Mapping-Information verfügbar
    /// </summary>
    public class EmptyIdMapException : RemappingException
    {
        public EmptyIdMapException()
        {
        }

        public EmptyIdMapException(string message) : base(message)
        {
        }

        public EmptyIdMapException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Keine Backup-ID verfügbar
    /// </summary>
    public class BackupIdNotFoundException : RemappingException
    {
        public BackupIdNotFoundException()
        {
        }

        public BackupIdNotFoundException(string message) : base(message)
        {
        }

        public BackupIdNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    /// <summary>
    /// Keine Current-ID verfügbar
    /// </summary>
    public class CurrentIdNotFoundException : RemappingException
    {
        public CurrentIdNotFoundException()
        {
        }

        public CurrentIdNotFoundException(string message) : base(message)
        {
        }

        public CurrentIdNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
