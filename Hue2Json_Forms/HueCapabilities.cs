using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    public class HueCapabilities
    {
        #region Member


        #endregion Member

        #region Properties
        public RulesCapability RulesInUse { get; set; }
        public RulesCapability RulesAvailable { get; set; }

        public double MeanConditions
        {
            get
            {
                return (double)RulesInUse.Conditions / (double)RulesInUse.Count;
            }
        }

        public double MeanActions
        {
            get
            {
                return (double)RulesInUse.Actions / (double)RulesInUse.Count;
            }
        }

        public RulesCapability RulesInUsePercent
        {
            get
            {
                updatePercentValues();
                return m_RulesInUsePercent;
            }
        }
        private RulesCapability m_RulesInUsePercent;
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for HueCapabilities
        /// </summary>
        public HueCapabilities()
        {
            RulesInUse = new RulesCapability();
            RulesAvailable = new RulesCapability();
        }

        #endregion Constructor

        #region Services


        #endregion Services

        #region Internal services

        private void updatePercentValues()
        {
            m_RulesInUsePercent = new RulesCapability();
            m_RulesInUsePercent.Actions = RulesInUse.Actions * 100.0 / RulesAvailable.Actions;
            m_RulesInUsePercent.Conditions = RulesInUse.Conditions * 100.0 / RulesAvailable.Conditions;
            m_RulesInUsePercent.Count = RulesInUse.Count * 100.0 / RulesAvailable.Count;
        }
        #endregion Internal services

        #region Events


        #endregion Events


    }

    public class RulesCapability
    {
        public double Count { get; set; }

        public double Actions { get; set; }

        public double Conditions { get; set; }
    }
}
