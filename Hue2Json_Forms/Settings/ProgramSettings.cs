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
        #region Member


        #endregion Member

        #region Properties

        public string Version { get; set; }

        public BridgeNameDisplayEnum BridgeNameDisplay { get; set; }

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
        public void ToFile(string path)
        {
            if (!path.EndsWith(".config"))
                throw new ArgumentException("Falsche Dateierweiterung der Einstellungsdatei, die Erweiterung muss *.config sein.");

            try
            {
                if (File.Exists(path))
                    File.Move(path, path.Substring(0, path.Length - 6) + "bak");
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

                var xs = new XmlSerializer(typeof(ProgramSettings));

                xs.Serialize(fs, this);
                fs.Close();
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

            return settings;
        }

        public static ProgramSettings CreateDefault()
        {
            return new ProgramSettings
            {
                Version = typeof(ProgramSettings).Assembly.GetName().Version.ToString(),
                BridgeNameDisplay = BridgeNameDisplayEnum.NameAndIp
            };
        }

        #endregion Services

        #region Internal services


        #endregion Internal services

        #region Events


        #endregion Events
    }
}
