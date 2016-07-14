using Newtonsoft.Json;
using System.Collections.Generic;

namespace PianoMelody.Web.Helpers
{
    public static class JsonHelper
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

        public static List<LocObject> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<LocObject>>(json);
        }
    }

    public class LocObject
    {
        public string k { get; set; }

        public string v { get; set; }
    }
}