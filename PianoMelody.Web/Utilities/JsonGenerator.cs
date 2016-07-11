using Newtonsoft.Json;
using System.Collections.Generic;

namespace PianoMelody.Web.Utilities
{
    public static class JsonGenerator
    {
        public static string Serialize(string enValue, string ruValue, string bgValue)
        {
            return JsonConvert.SerializeObject
                (
                    new List<object>
                    {
                        new { k = "en", v = enValue },
                        new { k = "ru", v = ruValue },
                        new { k = "bg", v = bgValue }
                    }
                );
        }
    }
}