using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Rca.Hue2Json.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    /// <summary>
    /// Verwaltet die generierten AppKeys
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class AppKeyManager
    {
        #region Constants
        const string APPKEY_FILENAME = "AppAuth";
        #endregion

        #region Member
        [JsonProperty(PropertyName = "Keys")]
        Dictionary<string, string> m_Keys;

        #endregion Member

        #region Properties

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Konstruiert ein neues PersonalAppKey Objekt
        /// </summary>
        [JsonConstructor]
        public AppKeyManager()
        {
            m_Keys = new Dictionary<string, string>();
        }


        /// <summary>
        /// Konstruiert ein neues PersonalAppKey Objekt
        /// </summary>
        /// <param name="restore">ggf. gespeicherte Daten deserialisieren</param>
        public AppKeyManager(bool restore) : this()
        {
            if (restore && File.Exists(APPKEY_FILENAME))
                fromBson();
        }

        #endregion Constructor

        #region Services
        /// <summary>
        /// Nimmt einen neuen Key auf 
        /// </summary>
        /// <param name="bridgeId">ID der Bridge</param>
        /// <param name="key">AppKey</param>
        /// <param name="replaceKey">Vorhandenen Eintrag überschreiben</param>
        /// <exception cref="ArgumentException">Key zur angegebenen Bridge schon vorhanden</exception>
        public void AddKey(string bridgeId, string key, bool replaceKey = false)
        {
            var id = cleanBridgeId(bridgeId);

            if (replaceKey && m_Keys.ContainsKey(id))
                m_Keys.Remove(id);

            m_Keys.Add(id, key);

            toBson();
        }

        /// <summary>
        /// Gibt den AppKey zur angegebenen Bridge zurück
        /// </summary>
        /// <param name="bridgeId">ID der Bridge</param>
        /// <returns>AppKey</returns>
        /// <exception cref="KeyNotFoundException">Kein AppKey zur angegebenen ID verfügbar</exception>
        public string GetKey(string bridgeId) => m_Keys[cleanBridgeId(bridgeId)];

        /// <summary>
        /// Versucht den AppKey zur angegebenen Bridge zurückzugeben
        /// </summary>
        /// <param name="bridgeId">ID der Bridge</param>
        /// <param name="key">AppKey</param>
        /// <returns>AppKey gefunden</returns>
        public bool TryGetKey(string bridgeId, out string key) => m_Keys.TryGetValue(cleanBridgeId(bridgeId), out key);

        #endregion Services

        #region Internal services
        string cleanBridgeId(string bridgeId)
        {
            if (string.IsNullOrWhiteSpace(bridgeId))
                throw new ArgumentException("Ungültiger AppKey, Key darf nicht leer sein");

            return bridgeId.Trim().ToLower();
        }

        /// <summary>
        /// Serialisieren
        /// </summary>
        void toBson()
        {
            using (var fs = new FileStream(APPKEY_FILENAME, FileMode.Create))
            using (var writer = new BsonDataWriter(fs))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>
        /// Deserialisieren
        /// </summary>
        private void fromBson()
        {
            if (!File.Exists(APPKEY_FILENAME))
                throw new FileNotFoundException("AppKey Datei nicht gefunden");
            
            using (var fs = new FileStream(APPKEY_FILENAME, FileMode.Open))
            using (var reader = new BsonDataReader(fs))
            {
                JsonSerializer serializer = new JsonSerializer();
                var man = serializer.Deserialize<AppKeyManager>(reader);
                m_Keys = man.m_Keys;
            }

            if (m_Keys.Count == 1)
                Logger.WriteToLog("AppKey eingelesen");
            else if (m_Keys.Count > 1)
                Logger.WriteToLog("AppKeys (" + m_Keys.Count + ") eingelesen");
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
