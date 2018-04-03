using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Remapping
{
    public class IdPair
    {
        #region Member


        #endregion Member

        #region Properties
        /// <summary>
        /// Gerätetyp
        /// </summary>
        public DeviceCategory Category { get; set; }

        /// <summary>
        /// Von der Bridge vergebene ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Hardware-ID
        /// </summary>
        public string UniqueId { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for IdPair
        /// </summary>
        public IdPair()
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
