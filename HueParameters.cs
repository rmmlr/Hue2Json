using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Q42.HueApi;
using Q42.HueApi.Models;
using Q42.HueApi.Models.Groups;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    /// <summary>
    /// Klasse zur Aufnahme aller Hue-Parameter
    /// </summary>
    [Serializable]
    public class HueParameters
    {
        #region Member


        #endregion Member

        #region Properties
        /// <summary>
        /// Erstellungsdatum
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Anzahl der im Netzwerk gefundenen Hue Bridges
        /// </summary>
        public int? BridgesCount { get; set; }

        /// <summary>
        /// Sammler für Leuchtmittel
        /// </summary>
        public List<Light> Lights { get; set; }

        /// <summary>
        /// Sammler für Gruppen
        /// </summary>
        public List<Group> Groups { get; set; }

        /// <summary>
        /// Sammler für Timer
        /// </summary>
        public List<Schedule> Schedules { get; set; }

        /// <summary>
        /// Sammler für Szenen
        /// </summary>
        public List<Scene> Scenes { get; set; }

        /// <summary>
        /// Sammler für Senosren
        /// </summary>
        public List<Sensor> Sensors { get; set; }

        /// <summary>
        /// Sammler für Regeln
        /// </summary>
        public List<Rule> Rules { get; set; }

        /// <summary>
        /// Konfigurations-Parameter
        /// </summary>
        public BridgeConfig Configuration { get; set; }

        /// <summary>
        /// Speicherplatzverfügbarkeit
        /// </summary>
        public BridgeCapabilities Capability { get; set; }

        /// <summary>
        /// Sammler für Resource Links
        /// </summary>
        public List<ResourceLink> ResourceLinks { get; set; }

        /// <summary>
        /// Userliste
        /// </summary>
        public List<WhiteList> WhiteList { get; set; }

        /// <summary>
        /// Tabelle mit Hashs der Usernames
        /// key: Hash; value: anonymer Name
        /// </summary>
        [JsonIgnore]
        public Hashtable Users { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Initialisierung aller Properties
        /// </summary>
        public HueParameters()
        {
            CreationDate = DateTime.Now;
            Lights = new List<Light>();
            Groups = new List<Group>();
            Schedules = new List<Schedule>();
            Scenes = new List<Scene>();
            Sensors = new List<Sensor>();
            Rules = new List<Rule>();
            ResourceLinks = new List<ResourceLink>();
            WhiteList = new List< WhiteList>();
            Users = new Hashtable();
        }

        /// <summary>
        /// Initialisierung aller Properties
        /// </summary>
        /// <param name="bridgesCount">Anzahl der im Netzwerk gefundenen Hue Bridges</param>
        public HueParameters(int? bridgesCount) : this()
        {
            BridgesCount = bridgesCount;
        }

        #endregion Constructor

        #region Services

        public MemoryStream ToJson()
        {
            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);

            sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented, new StringEnumConverter()));
            sw.Flush();
            sw.Close();
            stream.Close();

            return stream;
        }

        /// <summary>
        /// Anonymisieren der in den Parametern enthaltenen Serien-Nummern
        /// </summary>
        public void AnonymizeSerials()
        {
            if (Lights?.Count > 0)
                foreach (var light in Lights)
                {
                    light.UniqueId = null;
                    light.LuminaireUniqueId = null;
                }

            if (Sensors?.Count > 0)
                foreach (var sensor in Sensors)
                    sensor.UniqueId = null;

            if (Configuration != null)
            {
                Configuration.BridgeId = null;
                Configuration.Gateway = null;
                Configuration.IpAddress = null;
                Configuration.MacAddress = null;
                Configuration.NetMask = null;
                Configuration.ReplacesBridgeId = null;
                Configuration.StarterKitId = null;
                Configuration.ZigbeeChannel = 0;
            }
        }

        public void AnonymizeNames()
        {
            if (Lights?.Count > 0)
                foreach (var light in Lights)
                    light.Name = "Light " + light.Id;

            if (Groups?.Count > 0)
                foreach (var group in Groups)
                    group.Name = "Group " + group.Id;

            if (Schedules?.Count > 0)
                foreach (var schedule in Schedules)
                    schedule.Name = "Schedule " + schedule.Id;

            if (Scenes?.Count > 0)
                foreach (var scene in Scenes)
                    scene.Name = "Scene " + scene.Id;

            if (Sensors?.Count > 0)
                foreach (var sensor in Sensors)
                    sensor.Name = "Sensor " + sensor.Id;

            if (Rules?.Count > 0)
                foreach (var rule in Rules)
                    rule.Name = "Rule " + rule.Id;

            if (ResourceLinks?.Count > 0)
                foreach (var link in ResourceLinks)
                {
                    link.Name = "Link " + link.Id;
                    link.Description = "";
                }

            if (Configuration != null)
                Configuration.Name = "Hue-Bridge 1";

            if (WhiteList?.Count > 0)
                for (int i = 0; i < WhiteList.Count; i++)
                {
                    if (WhiteList[i].Name.Contains('#'))
                        WhiteList[i].Name = WhiteList[i].Name.Split('#')[0] + "#User" + i;
                }
        }

        /// <summary>
        /// Parameter für Leuchtmittel nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeLights()
        {
            return Lights?.Count > 0;
        }

        /// <summary>
        /// Parameter für Gruppen nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeGroups()
        {
            return Groups?.Count > 0;
        }

        /// <summary>
        /// Parameter für Timer nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeSchedules()
        {
            return Schedules?.Count > 0;
        }

        /// <summary>
        /// Parameter für Szenen nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeScenes()
        {
            return Scenes?.Count > 0;
        }

        /// <summary>
        /// Parameter für Sensoren nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeSensors()
        {
            return Sensors?.Count > 0;
        }

        /// <summary>
        /// Parameter für Regeln nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeRules()
        {
            return Rules?.Count > 0;
        }

        /// <summary>
        /// Konfiguration nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeConfiguration()
        {
            return Configuration != null;
        }

        /// <summary>
        /// Speicherverfügbarkeit nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeCapability()
        {
            return Capability != null;
        }

        /// <summary>
        /// ResourceLinks nur Serialisieren wenn vorhanden
        /// </summary>
        /// <returns>true: Parameter vorhanden; false: keine Parameter vorhanden</returns>
        public bool ShouldSerializeResourceLinks()
        {
            return ResourceLinks?.Count > 0;
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
