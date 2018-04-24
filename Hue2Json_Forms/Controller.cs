using Newtonsoft.Json;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using Rca.Hue2Json.Api.Models;
using Rca.Hue2Json.HtmlConverter;
using Rca.Hue2Json.Logging;
using Rca.Hue2Json.Remapping;
using Rca.Hue2Json.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace Rca.Hue2Json
{
    public class Controller : INotifyPropertyChanged
    {
        #region Constants
        const string APP_NAME = "Hue2Json";

        #endregion

        public static ProgramSettings GlobalSettings;

        #region Member
        AppKeyManager m_AppKeyManager;
        ILocalHueClient m_HueClient;

        HueParameters m_Parameters;

        #endregion Member

        #region Properties
        /// <summary>
        /// Gefundene Bridges
        /// </summary>
        public List<BridgeInfo> LocatedBridges { get; set; }

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

        /// <summary>
        /// Bridgesimulation aktiv
        /// </summary>
        public bool SimMode { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for Controller
        /// </summary>
        public Controller(ProgramSettings settings)
        {
            LocatedBridges = new List<BridgeInfo>();
            m_AppKeyManager = new AppKeyManager(true); //BSON deserialisieren

            GlobalSettings = settings;
        }

        #endregion Constructor

        #region Services
        /// <summary>
        /// Sucht im Netzwerk nach Bridges
        /// </summary>
        /// <returns>Gefundene Bridges</returns>
        public async Task<BridgeInfo[]> ScanBridges()
        {
            Logger.WriteToLog("Bridge-Suche gestartet", LogLevel.Info);

            if (SimMode)
            {
                Logger.WriteToLog("Bridge-Simulation", LogLevel.Simulation);
                return new BridgeInfo[1] { new BridgeInfo { Name = "Simulated Bridge", BridgeId = "simulation", IpAddress = "255.255.255.255" } };
            }
            var bridgeInfos = new List<BridgeInfo>();

            IBridgeLocator locator = new HttpBridgeLocator();
            var bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));


            foreach (LocatedBridge bridge in bridges)
            {
                try
                {
                    string json = string.Empty;
                    string url = @"http://" + bridge.IpAddress + "/api/config";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    //request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        json = reader.ReadToEnd();
                    }

                    var info = new BridgeInfo(JsonConvert.DeserializeObject<PublicConfig>(json));
                    info.IpAddress = bridge.IpAddress;

                    Logger.WriteToLog("Gefundene Bridge: " + info.GetNameString(BridgeNameDisplay.IpAndName), LogLevel.Info);

                    bridgeInfos.Add(info);
                }
                catch (Exception)
                {
                    //Ohne weitere Infos fortfahren
                    bridgeInfos.Add(new BridgeInfo(bridge));

                    Logger.WriteToLog("Erweiterete Bridge-Info (description.xml) für Bridge (" + bridge.IpAddress + ") nicht verfügbar", LogLevel.Error);
                }
            }

            return bridgeInfos.ToArray();
        }

        /// <summary>
        /// Verbindung zu einer bekannten Bridge herstellen
        /// </summary>
        /// <param name="bridgeIp">IP Adresse der zu verbindenden Bridge</param>
        /// <returns></returns>
        public BridgeResult ConnectBridge(BridgeInfo bridge)
        {
            if (SimMode)
            {
                Logger.WriteToLog("Bridge-Verbindung wurde simuliert", LogLevel.Simulation);
                return BridgeResult.SuccessfulConnected;
            }
            var appKey = "";

            if (m_AppKeyManager.TryGetKey(bridge.BridgeId, out appKey))
            {
                try
                {
                    m_HueClient = new LocalHueClient(bridge.IpAddress);
                    m_HueClient.Initialize(appKey);

                    return BridgeResult.SuccessfulConnected;
                }
                catch (Exception ex)
                {
                    //TODO: Antwort bei falschen AppKey?
                    if (ex.Message.Contains("Link button not pressed"))
                        return BridgeResult.UnauthorizedUser;
                    else
                        throw ex;
                }
            }
            else
                return BridgeResult.MissingUser;
        }

        /// <summary>
        /// Neuen User auf Bridge anlegen
        /// </summary>
        /// <param name="bridge">Bridge</param>
        /// <returns></returns>
        public async Task<BridgeResult> CreateUser(BridgeInfo bridge)
        {
            if (ConnectBridge(bridge) == BridgeResult.SuccessfulConnected)
            {
                //TODO Muss Client wieder getrennt werden?
                return BridgeResult.UserAlreadyExists;
            }

            try
            {
                m_HueClient = new LocalHueClient(bridge.IpAddress);

                var appKey = await m_HueClient.RegisterAsync(APP_NAME, Environment.MachineName);
                m_AppKeyManager.AddKey(bridge.BridgeId, appKey);
                m_HueClient.Initialize(appKey);

                return BridgeResult.UserCreated;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Link button not pressed"))
                    return BridgeResult.LinkButtonNotPressed;
                else
                    throw ex;
            }
        }

        /// <summary>
        /// Parameter auslesen
        /// </summary>
        /// <param name="selGroups">Auswahl der zu lesenden Parameter</param>
        public async void ReadParameters(HueParameterGroupEnum selGroups, AnonymizeOptions[] options = null)
        {
            if (SimMode)
            {
                Parameters = HueParameters.FromJson(@"F:/dummy_params.json");

                return;
            }

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
        /// Anzeige der Speicherauslastung der aktuell verbundenen Bridge
        /// </summary>
        public async Task<HueCapabilities> ShowCapabilities()
        {
            if (m_HueClient == null)
                throw new ArgumentNullException("Keine Bridge verbunden");

            var rules = await m_HueClient.GetRulesAsync();
            var sensors = await m_HueClient.GetSensorsAsync();
            var lights = await m_HueClient.GetLightsAsync();
            var groups = await m_HueClient.GetGroupsAsync();
            var schedules = await m_HueClient.GetSchedulesAsync();
            var capabilities = await m_HueClient.GetCapabilitiesAsync();


            var hueCapabilities = new HueCapabilities();

            hueCapabilities.Lights.InUse = lights.Count();
            hueCapabilities.Lights.Available = capabilities.Lights.Available + hueCapabilities.Lights.InUse;
            hueCapabilities.Sensors.InUse = sensors.Count(); //TODO: Prüfen ob nur HW Sensoren erfasst werden!
            hueCapabilities.Sensors.Available = capabilities.Sensors.Available + hueCapabilities.Sensors.InUse;
            hueCapabilities.Groups.InUse = groups.Count();
            hueCapabilities.Groups.Available = capabilities.Groups.Available + hueCapabilities.Groups.InUse;
            hueCapabilities.Schedules.InUse = schedules.Count();
            hueCapabilities.Schedules.Available = capabilities.Schedules.Available + hueCapabilities.Schedules.InUse;

            #region Regeln
            hueCapabilities.RulesInUse.Count = rules.Count();
            hueCapabilities.RulesInUse.Actions = rules.Sum(x => x.Actions.Count());
            hueCapabilities.RulesInUse.Conditions = rules.Sum(x => x.Conditions.Count());

            hueCapabilities.RulesAvailable.Count = capabilities.Rules.Available + hueCapabilities.RulesInUse.Count;
            hueCapabilities.RulesAvailable.Actions = capabilities.Rules.Actions.Available + hueCapabilities.RulesInUse.Actions;
            hueCapabilities.RulesAvailable.Conditions = capabilities.Rules.Conditions.Available + hueCapabilities.RulesInUse.Conditions;
            #endregion Regeln

            return hueCapabilities;
        }

        /// <summary>
        /// Übertragen der Parameter auf die Bridge
        /// </summary>
        public void RestoreParameters()
        {
            throw new NotImplementedException();
        }

        public void VisualizeParameters()
        {
            var html = Parameters.Lights[0].ToHtml(HtmlOutputFormat.UnsortetList);
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

        public void LoadSettings(string path = null)
        {

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
