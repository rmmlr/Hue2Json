using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json.Api
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StartupModeAttribute : Attribute
    {
        #region Member


        #endregion Member

        #region Properties
        public string Name { get; set; }

        public string Description { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for StartupModeAttribute
        /// </summary>
        public StartupModeAttribute()
        {

        }

        #endregion Constructor

        #region Services
        public StartupModeAttribute(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
