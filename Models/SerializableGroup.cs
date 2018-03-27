using Q42.HueApi.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Models
{
    public class SerializableGroup : Group
    {
        #region Member


        #endregion Member

        #region Properties

        public new Dictionary<string, LightLocation> Locations { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for SerializableGroup
        /// </summary>
        public SerializableGroup()
        {

        }

        public SerializableGroup(Group data)
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
