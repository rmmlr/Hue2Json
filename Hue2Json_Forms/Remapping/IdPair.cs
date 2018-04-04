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
        /// Alte von der Bridge vergebene ID, aus Backup
        /// </summary>
        public string BackupId { get; set; }

        /// <summary>
        /// Aktuelle neu von der Bridge vergebene ID
        /// </summary>
        public string CurrentId { get; set; }

        /// <summary>
        /// Eindeutige Hardware-ID
        /// </summary>
        public string UniqueId { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Leerer Konstruktor für IdPair
        /// </summary>
        public IdPair()
        {

        }

        /// <summary>
        /// Erstellt ein neues ID-Pair
        /// </summary>
        /// <param name="uniqueId">Eindeutige Hardware-ID</param>
        /// <param name="backupId">Alte von der Bridge vergebene ID, aus Backup</param>
        /// <param name="currentId">Aktuelle neu von der Bridge vergebene ID</param>
        public IdPair(string uniqueId, string backupId, string currentId)
        {
            UniqueId = uniqueId;
            BackupId = backupId;
            CurrentId = currentId;
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
