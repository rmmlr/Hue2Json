using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Rca.Hue2Xml
{
    public class Controller : INotifyPropertyChanged
    {
        #region Member


        #endregion Member

        #region Properties


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
        /// <summary>
        /// Sucht im Netzwerk nach Bridges
        /// </summary>
        /// <returns>IP Ardessen der gefunden Bridges</returns>
        public string[] SearchBridges()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verbindung zu einer bekannten Bridge herstellen
        /// </summary>
        /// <param name="ip">IP Adresse der zu verbindenden Bridge</param>
        /// <returns>true: Erfolgreich verbunden; false: Verbindungsaufbau fehlgeschlagen</returns>
        public bool ConnectBridge(string ip)
        {
            throw new NotImplementedException();
        }

        //TODO: Methode zum Anonymisieren individueller Namen von Räumen, Gruppen, Leuchtmitteln, Regeln, etc.
        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events

        #region INotifyPropertyChanged Member
        /// <summary>
        /// Helpmethod, to call the <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propName">Name of changed property</param>
        protected void PropChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        /// <summary>
        /// Updated property values available
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
