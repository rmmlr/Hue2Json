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
        [Display(Name = "Leuchtmittel")]
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

    
    public class DisplayAttribute : Attribute
    {
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    }

    public static class DisplayExtensions
    {
        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DisplayAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? value.ToString() : attribute.Name;
        }
    }
}
