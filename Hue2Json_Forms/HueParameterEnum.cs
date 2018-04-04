using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Json
{
    /// <summary>
    /// Enum mit den verfügbaren Parametern
    /// </summary>
    [Flags]
    public enum HueParameterGroupEnum
    {
        /// <summary>
        /// Leuchtmittel
        /// </summary>
        [Display(Name = "Leuchtmittel")]
        Lights = 2,
        /// <summary>
        /// Gruppen
        /// </summary>
        [Display(Name = "Gruppen")]
        Groups = 4,
        /// <summary>
        /// Timer
        /// </summary>
        [Display(Name = "Timer")]
        Schedules = 8,
        /// <summary>
        /// Szenen
        /// </summary>
        [Display(Name = "Szenen")]
        Scenes = 16,
        /// <summary>
        /// Sensoren
        /// </summary>
        [Display(Name = "Sensoren")]
        Sensors = 32,
        /// <summary>
        /// Regeln
        /// </summary>
        [Display(Name = "Regeln")]
        Rules = 64,
        /// <summary>
        /// Konfiguration
        /// </summary>
        [Display(Name = "Konfiguration")]
        Configuration = 128,
        /// <summary>
        /// Links
        /// </summary>
        [Display(Name = "Links")]
        ResourceLinks = 256,
        /// <summary>
        /// Speicher-Belegung
        /// </summary>
        [Display(Name = "Speicher-Belegung")]
        Capability = 512,
        /// <summary>
        /// Benutzerliste
        /// </summary>
        [Display(Name = "Benutzerliste")]
        WhiteList = 1024
    }

    public class HueParameterGroup
    {
        /// <summary>
        /// Menschenlesbarer Name
        /// </summary>
        public string DisplayName
        {
            get
            {
                return Value.DisplayName();
            }
        }

        /// <summary>
        /// Enum-Wert
        /// </summary>
        public HueParameterGroupEnum Value { get; private set; }


        public HueParameterGroup(HueParameterGroupEnum value)
        {
            Value = value;
        }
    }


    public class DisplayAttribute : Attribute
    {
        /// <summary>
        /// Menschenlesbarer Name
        /// </summary>
        public string Name { get; set; }
    }

    public static class DisplayExtensions
    {
        /// <summary>
        /// Ruft den menschenlesbaren Name ab
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? value.ToString() : attribute.Name;
        }
    }
}
