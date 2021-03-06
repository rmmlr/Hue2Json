﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Gibt die neue ID zur übergebenen Backup-ID eines Leuchtmittels zurück
        /// </summary>
        /// <param name="backupId">Backup-ID eines Leuchtmittels</param>
        /// <returns>Neue ID des Leuchtmittels</returns>
        /// <exception cref="RemappingException">Mehrere Einträge zur übergebenen Backup-ID gefunden.</exception>
        /// <exception cref="BackupIdNotFoundException">Keinen Eintrag zur übergebenen Backup-ID gefunden.</exception>
        /// <exception cref="CurrentIdNotFoundException">Keinen Eintrag zur übergebenen Backup-ID gefunden.</exception>
        /// <exception cref="EmptyIdMapException">Keine Mapping-Information verfügbar. ID-Map ist leer.</exception>
        public string GetCurrentLightId(string backupId)
        {
            return getCurrentId(backupId, Lights);
        }

        /// <summary>
        /// Gibt die neue ID zur übergebenen Backup-ID eines Sensors oder Schalters zurück
        /// </summary>
        /// <param name="backupId">Backup-ID eines Sensors oder Schalters</param>
        /// <returns>Neue ID des Sensors oder Schalters</returns>
        /// <exception cref="RemappingException">Mehrere Einträge zur übergebenen Backup-ID gefunden.</exception>
        /// <exception cref="BackupIdNotFoundException">Keinen Eintrag zur übergebenen Backup-ID gefunden.</exception>
        /// <exception cref="CurrentIdNotFoundException">Keinen Eintrag zur übergebenen Backup-ID gefunden.</exception>
        /// <exception cref="EmptyIdMapException">Keine Mapping-Information verfügbar. ID-Map ist leer.</exception>
        public string GetCurrentSensorId(string backupId)
        {
            return getCurrentId(backupId, Sensors);
        }

        public MemoryStream ToJson()
        {
            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);

            sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            sw.Flush();

            return stream;
        }

        public static RemappingInfo FromJson(string path)
        {
            var sr = new StreamReader(path);
            var info = JsonConvert.DeserializeObject<RemappingInfo>(sr.ReadToEnd());

            return info;
        }

        #endregion Services

        #region Internal services
        string getCurrentId(string backupId, List<IdPair> idMap)
        {
            if (idMap?.Count > 0)
            {
                var idCount = idMap.Count(x => x.BackupId == backupId);

                switch (idCount)
                {
                    case 0:
                        throw new BackupIdNotFoundException("Keinen Eintrag zur übergebenen Backup-ID (" + backupId + ") gefunden.");
                    case 1:
                        var id = idMap.First(x => x.BackupId == backupId).CurrentId;
                        if (String.IsNullOrEmpty(id))
                            throw new CurrentIdNotFoundException();
                        else
                            return id;
                    default:
                        throw new RemappingException("Meherere Einträge zur übergebenen Backup-ID (" + backupId + ") gefunden.");
                }
            }
            else
                throw new EmptyIdMapException("Keine Mapping-Information verfügbar. ID-Map ist leer.");
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
