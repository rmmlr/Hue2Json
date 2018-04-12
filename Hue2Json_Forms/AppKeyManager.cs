using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    /// <summary>
    /// Manage the personal app key
    /// </summary>
    public class AppKeyManager
    {
        #region Constants
        const string APPKEY_FILENAME = "PersonalAppKey";
        #endregion

        #region Member
        string m_AppKey;

        Dictionary<string, string> m_Keys;

        #endregion Member

        #region Properties
        /// <summary>
        /// Personal app key
        /// Returns null, when app key is not available
        /// </summary>
        [Obsolete]
        public string AppKey
        {
            get
            {
                if (String.IsNullOrEmpty(m_AppKey))
                    return null;
                else
                    return m_AppKey;
            }
            set
            {
                if (m_AppKey != value)
                {
                    safeAppKey(value);
                }
            }
        }

        /// <summary>
        /// App key is available
        /// </summary>
        public bool IsAvailable { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for PersonalAppKey
        /// </summary>
        public AppKeyManager()
        {
            m_Keys = new Dictionary<string, string>();

            if (File.Exists(APPKEY_FILENAME))
                loadAppKey();
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
        public void AddKey(string bridgeId, string key, bool replaceKey)
        {
            if (replaceKey && m_Keys.ContainsKey(bridgeId.ToLower()))
                m_Keys.Remove(bridgeId.ToLower());

            m_Keys.Add(bridgeId.ToLower(), key);
        }

        /// <summary>
        /// Gibt den AppKey zur angegebenen Bridge zurück
        /// </summary>
        /// <param name="bridgeId">ID der Bridge</param>
        /// <returns>AppKey</returns>
        /// <exception cref="KeyNotFoundException">Kein AppKey zur angegebenen ID verfügbar</exception>
        public string GetKey(string bridgeId)
        {
            return m_Keys[bridgeId.ToLower()];
        }

        /// <summary>
        /// Versucht den AppKey zur angegebenen Bridge zurückzugeben
        /// </summary>
        /// <param name="bridgeId">ID der Bridge</param>
        /// <param name="key">AppKey</param>
        /// <returns>AppKey gefunden</returns>
        public bool TryGetKey(string bridgeId, out string key)
        {
            return m_Keys.TryGetValue(bridgeId.ToLower(), out key);
        }

        #endregion Services

        #region Internal services
        /// <summary>
        /// Safe the app key to file
        /// </summary>
        /// <param name="appKey"></param>
        [Obsolete]
        void safeAppKey(string appKey)
        {
            m_AppKey = appKey;

            if (File.Exists(APPKEY_FILENAME))
                File.Delete(APPKEY_FILENAME);

            var sw = new StreamWriter(APPKEY_FILENAME);
            sw.Write(appKey);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// Load the app key from file
        /// </summary>
        /// <returns>app key</returns>
        [Obsolete]
        string loadAppKey()
        {
            if (!File.Exists(APPKEY_FILENAME))
                throw new FileNotFoundException("No personal app key file found.");

            var sr = new StreamReader(APPKEY_FILENAME);
            string appKey = sr.ReadToEnd();
            sr.Close();

            m_AppKey = appKey.Trim();
            IsAvailable = true;

            return m_AppKey;
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
