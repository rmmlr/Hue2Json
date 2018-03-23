using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Rca.Hue2Xml
{
    public class Controller : INotifyPropertyChanged
    {
        #region Member

        private HueParameters m_Parameters;

        #endregion Member

        #region Properties
        /// <summary>
        /// Hue Parameter
        /// </summary>
        public HueParameters Parameters
        {
            get { return m_Parameters; }
            set { m_Parameters = value; }
        }


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

        /// <summary>
        /// Parameter auslesen
        /// </summary>
        /// <param name="paras">Auswahl der zu lesenden Parameter</param>
        /// <returns>true: Parameter erfolgreich gelesen; false: Lesen fehlgeschlagen</returns>
        public bool ReadParameters(HueParameterEnum paras)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serialisieren der aktuellen Parameter
        /// </summary>
        /// <param name="path">Pfad zur Datei</param>
        /// <returns>true: Erfolgreich serialisiert; false: Serialisierung fehlgeschlagen</returns>
        public bool SaveParameterFile(string path)
        {
            try
            {
                var xs = new XmlSerializer(typeof(HueParameters));
                var fs = new FileStream(path, FileMode.CreateNew);

                xs.Serialize(fs, Parameters);
                fs.Flush();
                fs.Close();
            }
            catch (Exception)
            {
                //TODO: Fehler ausgeben
                return false;
            }

            return true;
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
