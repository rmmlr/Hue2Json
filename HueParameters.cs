using Q42.HueApi;
using Q42.HueApi.Models;
using Q42.HueApi.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Xml
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

        public List<Light> Lights { get; set; }

        //public List<Group> Groups { get; set; }

        public List<Schedule> Schedules { get; set; }

        public List<Scene> Scenes { get; set; }

        public List<Sensor> Sensors { get; set; }

        public List<Rule> Rules { get; set; }

        public BridgeConfig Configuration { get; set; }

        public BridgeCapabilities Capability { get; set; }

        public List<ResourceLink> ResourceLinks { get; set; }


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for HueParameters
        /// </summary>
        public HueParameters()
        {
            CreationDate = DateTime.Now;
            Lights = new List<Light>();
            //Groups = new List<Group>();
            Schedules = new List<Schedule>();
            Scenes = new List<Scene>();
            Sensors = new List<Sensor>();
            Rules = new List<Rule>();
            ResourceLinks = new List<ResourceLink>();
        }

        #endregion Constructor

        #region Services


        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
