using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.BaseEntities
{
    public class MultiLanguageField 
    {
        [JsonPropertyName("uz")]
        public string Uz { get; set; }
        [JsonPropertyName("ru")]
        public string Ru { get; set; }
        [JsonPropertyName("en")]
        public string En { get; set; }


        public static implicit operator MultiLanguageField(string text)
        {
            return new MultiLanguageField()
            {
                Uz = text,
                Ru = text,
                En = text,
            };
        }

        public static bool operator ==(MultiLanguageField field, string value)
        {
            return
                field.En.Contains(value, StringComparison.InvariantCultureIgnoreCase)
                ||
                field.Ru.Contains(value, StringComparison.InvariantCultureIgnoreCase)
                ||
                field.Uz.Contains(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool operator !=(MultiLanguageField field, string value)
        {
            return !(field == value);
        }

        public static bool operator >(MultiLanguageField field, string value)
        {
            return false;
        }

        public static bool operator <(MultiLanguageField field, string value)
        {
            return false;
        }

        public static bool operator >=(MultiLanguageField field, string value)
        {
            return false;
        }

        public static bool operator <=(MultiLanguageField field, string value)
        {
            return false;
        }
    }
}
