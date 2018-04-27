using Q42.HueApi.Models.Bridge;
using Rca.Hue2Json.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    public class BridgeInfo : PublicConfig
    {
        #region Member


        #endregion Member

        #region Properties
        /// <summary>
        /// IP der Hue Bridge
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Aktueller AppKey
        /// </summary>
        public string CurrentAppKey { get; set; }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for BridgeInfo
        /// </summary>
        public BridgeInfo()
        {

        }

        public BridgeInfo(LocatedBridge locatedBridge)
        {
            IpAddress = locatedBridge.IpAddress;
            BridgeId = locatedBridge.BridgeId;
        }

        public BridgeInfo(PublicConfig config)
        {
            Name = config.Name;
            DataStoreVersion = config.DataStoreVersion;
            SwVersion = config.SwVersion;
            ApiVersion = config.ApiVersion;
            Mac = config.Mac;
            BridgeId = config.BridgeId;
            FactoryNew = config.FactoryNew;
            ReplacesBridgeId = config.ReplacesBridgeId;
            ModelId = config.ModelId;
            StarterKitId = config.StarterKitId;
        }


        #endregion Constructor

        #region Services
        public string GetNameString(Settings.BridgeNameDisplay format)
        {
            string name;

            switch (format)
            {
                case Settings.BridgeNameDisplay.IpOnly:
                    name = IpAddress;
                    break;
                case Settings.BridgeNameDisplay.IpAndName:
                    name = String.Format("{0} ({1})", IpAddress, Name);
                    break;
                case Settings.BridgeNameDisplay.IpAndId:
                    name = String.Format("{0} ({1})", IpAddress, BridgeId);
                    break;
                default: //NameAndIp
                    name = String.Format("{0} ({1})", Name, IpAddress);
                    break;
            }

            return name;
        }

        public string GetNameString()
        {
            return GetNameString(Controller.GlobalSettings.BridgeNameDisplay);
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
