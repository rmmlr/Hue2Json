using Q42.HueApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Api
{
    public class LightExtended : Light
    {
        #region Member


        #endregion Member

        #region Properties
        public StartupMode Startup { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for LightExtended
        /// </summary>
        public LightExtended()
        {

        }

        public LightExtended(Light light)
        {
            Id = light.Id;
            Name = light.Name;
            Type = light.Type;
            SoftwareVersion = light.SoftwareVersion;
            ModelId = light.ModelId;
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
