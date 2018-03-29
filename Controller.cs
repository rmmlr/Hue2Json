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
        const string APP_NAME = "Hue2Json";

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

        /// <summary>
        /// Testmode aktiv
        /// </summary>
        public bool DevMode { get; set; }

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
                //TODO: MsgBox: LinkButton drücken
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// Parameter auslesen
        /// </summary>
        /// <param name="selGroups">Auswahl der zu lesenden Parameter</param>
        public async void ReadParameters(HueParameterGroupEnum selGroups, AnonymizeOptions[] options = null)
        {
            int? bridgesCount = null;
            if (LocatedBridges?.Count > 0)
                bridgesCount = LocatedBridges.Count;

            var paras = new HueParameters(bridgesCount);

            if (selGroups.HasFlag(HueParameterGroupEnum.Scenes | HueParameterGroupEnum.Rules | HueParameterGroupEnum.ResourceLinks | HueParameterGroupEnum.WhiteList))
            {
                var whiteList = (await m_HueClient.GetBridgeAsync()).WhiteList.ToList();

                for (int i = 0; i < whiteList.Count; i++)
                {
                    string name = "User " + (i + 1);
                    paras.Users.Add(whiteList[i].Id.GetHashCode(), name);
                    whiteList[i].Id = name;
                }
                
                if (selGroups.HasFlag(HueParameterGroupEnum.WhiteList))
                    paras.WhiteList = whiteList;
            }

            if (selGroups.HasFlag(HueParameterGroupEnum.Lights))
                paras.Lights = (await m_HueClient.GetLightsAsync()).ToList();

            if (selGroups.HasFlag(HueParameterGroupEnum.Groups))
                paras.Groups = (await m_HueClient.GetGroupsAsync()).ToList();

            if (selGroups.HasFlag(HueParameterGroupEnum.Schedules))
                paras.Schedules = (await m_HueClient.GetSchedulesAsync()).ToList();

            if (selGroups.HasFlag(HueParameterGroupEnum.Scenes))
            {
                paras.Scenes = (await m_HueClient.GetScenesAsync()).ToList();

                foreach (var scene in paras.Scenes)
                {
                    if (paras.Users.ContainsKey(scene.Owner.GetHashCode()))
                        scene.Owner = paras.Users[scene.Owner.GetHashCode()].ToString();
                    else
                        scene.Owner = "Deleted user!";
                }
            }

            if (selGroups.HasFlag(HueParameterGroupEnum.Sensors))
                paras.Sensors = (await m_HueClient.GetSensorsAsync()).ToList();

            if (selGroups.HasFlag(HueParameterGroupEnum.Rules))
            {
                paras.Rules = (await m_HueClient.GetRulesAsync()).ToList();

                foreach (var rule in paras.Rules)
                {
                    if (paras.Users.ContainsKey(rule.Owner.GetHashCode()))
                        rule.Owner = paras.Users[rule.Owner.GetHashCode()].ToString();
                    else
                        rule.Owner = "Deleted user!";
                }
            }

            if (selGroups.HasFlag(HueParameterGroupEnum.Configuration))
            {
                var conf = (await m_HueClient.GetBridgeAsync()).Config;
                if (conf.WhiteList?.Count > 0)
                {
                    conf.WhiteList.Clear();
                    conf.WhiteList = null;
                }
                paras.Configuration = conf;
            }

            if (selGroups.HasFlag(HueParameterGroupEnum.Capability))
            {
                var conf = await m_HueClient.GetCapabilitiesAsync();
                conf.Timezones = null; //Muss nicht serialisiert werden

                paras.Capability = conf;
            }

            if (selGroups.HasFlag(HueParameterGroupEnum.ResourceLinks))
            {
                paras.ResourceLinks = (await m_HueClient.GetResourceLinksAsync()).ToList();

                foreach (var link in paras.ResourceLinks)
                {
                    if (paras.Users.ContainsKey(link.Owner.GetHashCode()))
                        link.Owner = paras.Users[link.Owner.GetHashCode()].ToString();
                    else
                        link.Owner = "Deleted user!";
                }
            }
            

            if (options?.Length > 0)
            {
                if (options.Any(x => x == AnonymizeOptions.Serials))
                    paras.AnonymizeSerials();
                if (options.Any(x => x == AnonymizeOptions.Names))
                    paras.AnonymizeNames();
            }

            Parameters = paras;
        }

        /// <summary>
        /// Serialisieren der aktuellen Parameter
        /// </summary>
        /// <param name="path">Pfad zur Datei</param>
        public void SaveParameterFile(string path)
        {
            var fs = new FileStream(path, FileMode.Create);

            Parameters.ToJson().WriteTo(fs);

            fs.Flush();
            fs.Close();
        }

        public void LoadParameterFile(string path)
        {
            Parameters = HueParameters.FromJson(path);
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
