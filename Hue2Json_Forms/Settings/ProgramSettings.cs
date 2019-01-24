using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;

namespace Rca.Hue2Json.Settings
{
    [Serializable]
    public class ProgramSettings
    {
        #region Constants
        public const string SETTINGS_FILE_NAME = "hue2json";
        public const string SETTINGS_FILE_EXTENSION = ".config";

        #endregion Constants

        #region Member


        #endregion Member

        #region Properties

        public string Version { get; set; }

        [XmlIgnore]
        public string FilePath { get; private set; }

        public BridgeNameDisplay BridgeNameDisplay { get; set; }

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Empty constructor for Settings
        /// </summary>
        public ProgramSettings()
        {

        }

        #endregion Constructor

        #region Services
        /// <summary>
        /// Serialisieren der Objektinstanz, als XML-Datei
        /// </summary>
        /// <param name="path">Dateipfad</param>
        public void ToFile(string path = null)
        {
            if (string.IsNullOrWhiteSpace(path))
                path = SETTINGS_FILE_NAME + SETTINGS_FILE_EXTENSION;

            if (!path.EndsWith(SETTINGS_FILE_EXTENSION))
                throw new ArgumentException("Falsche Dateierweiterung der Einstellungsdatei, die Erweiterung muss " + SETTINGS_FILE_EXTENSION + " sein.");

            try
            {
                if (File.Exists(path))
                {
                    if (File.Exists(path.Substring(0, path.Length - 6) + "bak"))
                        File.Delete(path.Substring(0, path.Length - 6) + "bak");
                    File.Move(path, path.Substring(0, path.Length - 6) + "bak");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Vorhandene Einstellungsdatei kann nicht überschrieben werden.", ex);
            }

            //Neue Einstellungsdatei erzeugen
            using (FileStream fs = File.Create(path))
            {
                //Aktuelle Version eintragen
                Version = typeof(ProgramSettings).Assembly.GetName().Version.ToString();
                FilePath = path;

                var xs = new XmlSerializer(typeof(ProgramSettings));
                xs.Serialize(fs, this);
            }
        }

        /// <summary>
        /// Deserialisieren einer Einstellungsdatei
        /// </summary>
        /// <param name="path">Dateipfad</param>
        /// <returns>ProgramSettings Objekt</returns>
        public static ProgramSettings FromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Die angegebene Einstellungsdatei (" + path + ") konnte nicht gefunden werden.");

            
            var fs = new FileStream(path, FileMode.Open);
            var xs = new XmlSerializer(typeof(ProgramSettings));

            var settings = (ProgramSettings)xs.Deserialize(fs);

            settings.FilePath = path;

            return settings;
        }

        public static ProgramSettings CreateDefault()
        {
            return new ProgramSettings
            {
                Version = typeof(ProgramSettings).Assembly.GetName().Version.ToString(),
                BridgeNameDisplay = BridgeNameDisplay.NameAndIp
            };
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
