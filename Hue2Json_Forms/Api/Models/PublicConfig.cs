using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Api.Models
{
    /// <summary>
    /// Öffentliche Konfiguration der Philips Hue Bridge
    /// </summary>
    public class PublicConfig
    {
        #region Member


        #endregion Member

        #region Properties
        /// <summary>
        /// Name der Philips Hue Bridge
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DataStoreVersion { get; set; }

        /// <summary>
        /// Software-Version der Philips Hue Bridge
        /// </summary>
        public string SwVersion { get; set; }

        /// <summary>
        /// Hue API Version der Philips Hue Bridge
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// MAC-Adresse der Philips Hue Bridge
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// Eindeutige Hardware-ID der Philips Hue Bridge
        /// </summary>
        public string BridgeId { get; set; }

        /// <summary>
        /// Fabrikneu
        /// </summary>
        public bool FactoryNew { get; set; }

        /// <summary>
        /// Imitierte Bridge ID
        /// </summary>
        public string ReplacesBridgeId { get; set; }

        /// <summary>
        /// Modell ID der Philips Hue Bridge
        /// </summary>
        public string ModelId { get; set; }

        /// <summary>
        /// Starter Kit ID
        /// </summary>
        public string StarterKitId { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for PublicConfig
        /// </summary>
        public PublicConfig()
        {

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
