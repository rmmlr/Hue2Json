using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Hue2Xml
{
    /// <summary>
    /// Enum mit den verfügbaren Parametern
    /// </summary>
    [Flags]
    public enum HueParameterEnum
    {
        //None = 1,
        //[Display(Name = "Leuchtmittel")]
        Lights = 2,
        [Display(Name = "Gruppen")]
        Groups = 4,
        [Display(Name = "Timer")]
        Scheudles = 8,
        [Display(Name = "Szenen")]
        Scenes = 16,
        [Display(Name = "Sensoren")]
        Sensors = 32,
        [Display(Name = "Regeln")]
        Rules = 64,
        [Display(Name = "Konfiguration")]
        Configuration = 128

    }

    public class HueParameter
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
        public HueParameterEnum Value { get; private set; }


        public HueParameter(HueParameterEnum value)
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
        public static string DisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? value.ToString() : attribute.Name;
        }
    }
}
