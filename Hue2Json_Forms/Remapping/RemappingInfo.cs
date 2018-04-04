using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Remapping
{
    /// <summary>
    /// Sammler mit neuen (current) und alten (backup) IDs
    /// </summary>
    public class RemappingInfo
    {
        #region Member


        #endregion Member

        #region Properties
        /// <summary>
        /// Erstellungsdatum
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Hardware-ID der Philips Hue Bridge aus Backup
        /// </summary>
        public string BridgeBackupUniqueId { get; set; }

        /// <summary>
        /// Hardware-ID der Philips Hue Bridge aus aktueller Konfiguration
        /// </summary>
        public string BridgeCurrentUniqueId { get; set; }

        /// <summary>
        /// IDs der Leuchtmittel
        /// </summary>
        public List<IdPair> Lights { get; set; }

        /// <summary>
        /// IDs von Sensoren und Schaltern
        /// </summary>
        public List<IdPair> Sensors { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Leerer KonstruKtor für RemappingInfo
        /// Alle Objekte werden initialisiert
        /// </summary>
        public RemappingInfo()
        {
            CreationDate = DateTime.Now;
            Lights = new List<IdPair>();
            Sensors = new List<IdPair>();
        }

        #endregion Constructor

        #region Services

        public static RemappingInfo Create(HueParameters backup, HueParameters current)
        {
            var result = new RemappingInfo
            {
                BridgeBackupUniqueId = backup.Configuration.BridgeId,
                BridgeCurrentUniqueId = current.Configuration.BridgeId
            };

            foreach (var l in backup.Lights)
                result.Lights.Add(new IdPair(l.UniqueId, l.Id, current.Lights.FirstOrDefault(x => String.Equals(x.UniqueId, l.UniqueId, StringComparison.InvariantCultureIgnoreCase))?.Id));

            foreach (var s in backup.Sensors)
                result.Sensors.Add(new IdPair(s.UniqueId, s.Id, current.Sensors.FirstOrDefault(x => String.Equals(x.UniqueId, s.UniqueId, StringComparison.InvariantCultureIgnoreCase))?.Id));

            return result;
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
