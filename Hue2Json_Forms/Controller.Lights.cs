using Q42.HueApi;
using Rca.Hue2Json.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    public partial class Controller
    {
        #region Member


        #endregion Member

        #region Properties
        public BindingList<LightExtended> Lights { get; set; } = new BindingList<LightExtended>();

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for Controller
        /// </summary>
        public Controller()
        {

        }

        #endregion Constructor

        #region Services

        public async void GetLights()
        {
            List<Light> lights = (await m_HueClient.GetLightsAsync()).ToList();


            var caller = new ApiCaller();
            Lights.Clear();

            foreach (var light in lights)
            {
                var lightExtended = new LightExtended(light);

                try
                {
                    var lightJson = caller.HttpGetJson("lights/" + lightExtended.Id);
                    lightExtended.Startup = (StartupMode)Enum.Parse(typeof(StartupMode), lightJson["config"]["startup"]["mode"].ToString(), true);
                }
                catch
                {
                    lightExtended.Startup = StartupMode.NotSupported;
                }
                Lights.Add(lightExtended);
            }
        }
        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
