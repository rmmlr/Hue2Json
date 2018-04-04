using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Remapping
{
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
        /// IDs der Philips Hue Bridge
        /// </summary>
        public IdPair Bridge { get; set; }

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
        /// Empty constructor for RemappingInfo
        /// Alle Objekte initialisiert
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
            var result = new RemappingInfo();

            foreach (var l in backup.Lights)
                result.Lights.Add(new IdPair(l.UniqueId, l.Id, current.Lights.FirstOrDefault(x => x.UniqueId == l.UniqueId)?.Id));

            foreach (var s in backup.Sensors)
                result.Sensors.Add(new IdPair(s.UniqueId, s.Id, current.Sensors.FirstOrDefault(x => x.UniqueId == s.UniqueId)?.Id));

            return result;
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
