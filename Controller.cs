using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.Hue2Json
{
    public class Controller : INotifyPropertyChanged
    {
        #region Constants
        const string APP_NAME = "Hue2Xml";

        #endregion

        #region Member
        AppKeyManager m_AppKeyManager;
        ILocalHueClient m_HueClient;

        HueParameters m_Parameters;

        #endregion Member

        #region Properties
        /// <summary>
        /// Gefundene Bridges
        /// </summary>
        public List<LocatedBridge> LocatedBridges { get; set; }

        /// <summary>
        /// Hue Parameter
        /// </summary>
        public HueParameters Parameters
        {
            get { return m_Parameters; }
            set { m_Parameters = value; }
        }


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for Controller
        /// </summary>
        public Controller()
        {
            LocatedBridges = new List<LocatedBridge>();
            m_AppKeyManager = new AppKeyManager();
        }

        #endregion Constructor

        #region Services
        /// <summary>
        /// Sucht im Netzwerk nach Bridges
        /// </summary>
        /// <returns>IP Ardessen der gefunden Bridges</returns>
        public async Task<string[]> ScanBridges()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            var bridgeIPs = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));

            foreach (LocatedBridge bridge in bridgeIPs)
                LocatedBridges.Add(bridge);

            return LocatedBridges.Select(x => x.IpAddress).ToArray();
        }

        /// <summary>
        /// Verbindung zu einer bekannten Bridge herstellen
        /// </summary>
        /// <param name="bridgeIp">IP Adresse der zu verbindenden Bridge</param>
        /// <returns>true: Erfolgreich verbunden; false: Verbindungsaufbau fehlgeschlagen</returns>
        public async Task<bool> ConnectBridge(string bridgeIp)
        {
            try
            {
                m_HueClient = new LocalHueClient(bridgeIp);

                var appKey = m_AppKeyManager.AppKey;
                if (String.IsNullOrEmpty(appKey))
                {
                    appKey = await m_HueClient.RegisterAsync(APP_NAME, Environment.MachineName);
                    m_AppKeyManager.AppKey = appKey;
                }
                m_HueClient.Initialize(appKey);

                //return await m_Client.GetBridgeAsync();
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Parameter auslesen
        /// </summary>
        /// <param name="paras">Auswahl der zu lesenden Parameter</param>
        /// <returns>true: Parameter erfolgreich gelesen; false: Lesen fehlgeschlagen</returns>
        public async Task<bool> ReadParameters(HueParameterGroupEnum paras)
        {
            try
            {
                Parameters = new HueParameters();

                if (paras.HasFlag(HueParameterGroupEnum.Lights))
                    Parameters.Lights = (await m_HueClient.GetLightsAsync()).ToList();

                if (paras.HasFlag(HueParameterGroupEnum.Groups))
                    Parameters.Groups = (await m_HueClient.GetGroupsAsync()).ToList();

                if (paras.HasFlag(HueParameterGroupEnum.Schedules))
                    Parameters.Schedules = (await m_HueClient.GetSchedulesAsync()).ToList();

                if (paras.HasFlag(HueParameterGroupEnum.Scenes))
                    Parameters.Scenes = (await m_HueClient.GetScenesAsync()).ToList();

                if (paras.HasFlag(HueParameterGroupEnum.Sensors))
                    Parameters.Sensors = (await m_HueClient.GetSensorsAsync()).ToList();

                if (paras.HasFlag(HueParameterGroupEnum.Rules))
                    Parameters.Rules = (await m_HueClient.GetRulesAsync()).ToList();

                if (paras.HasFlag(HueParameterGroupEnum.Configuration))
                    Parameters.Configuration = (await m_HueClient.GetBridgeAsync()).Config;

                if (paras.HasFlag(HueParameterGroupEnum.Capability))
                    Parameters.Capability = await m_HueClient.GetCapabilitiesAsync();

                if (paras.HasFlag(HueParameterGroupEnum.ResourceLinks))
                    Parameters.ResourceLinks = (await m_HueClient.GetResourceLinksAsync()).ToList();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Serialisieren der aktuellen Parameter
        /// </summary>
        /// <param name="path">Pfad zur Datei</param>
        /// <returns>true: Erfolgreich serialisiert; false: Serialisierung fehlgeschlagen</returns>
        public bool SaveParameterFile(string path)
        {
            try
            {
                var xs = new XmlSerializer(typeof(HueParameters));
                var fs = new FileStream(path, FileMode.CreateNew);

                xs.Serialize(fs, Parameters);
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                //TODO: Fehler ausgeben
                throw ex;
                return false;
            }

            return true;
        }

        //TODO: Methode zum Anonymisieren individueller Namen von Räumen, Gruppen, Leuchtmitteln, Regeln, etc.
        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events

        #region INotifyPropertyChanged Member
        /// <summary>
        /// Helpmethod, to call the <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propName">Name of changed property</param>
        protected void PropChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /// <summary>
        /// Updated property values available
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
