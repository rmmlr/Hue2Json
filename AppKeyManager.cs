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

        #endregion Member

        #region Properties
        /// <summary>
        /// Personal app key
        /// Returns null, when app key is not available
        /// </summary>
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
            if (File.Exists(APPKEY_FILENAME))
                loadAppKey();
        }

        #endregion Constructor

        #region Services


        #endregion Services

        #region Internal services
        /// <summary>
        /// Safe the app key to file
        /// </summary>
        /// <param name="appKey"></param>
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
