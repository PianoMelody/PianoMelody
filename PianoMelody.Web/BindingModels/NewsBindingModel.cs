using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Web.BindingModels
{
    public class NewsBindingModel
    {
        public string EnTitle { get; set; }

        public string RuTitle { get; set; }

        public string BgTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string EnContent { get; set; }

        [DataType(DataType.MultilineText)]
        public string RuContent { get; set; }

        [DataType(DataType.MultilineText)]
        public string BgContent { get; set; }
    }
}