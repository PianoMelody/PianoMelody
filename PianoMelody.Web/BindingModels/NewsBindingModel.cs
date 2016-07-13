using PianoMelody.I18N;
using System.ComponentModel.DataAnnotations;

namespace PianoMelody.Web.BindingModels
{
    public class NewsBindingModel
    {
        [Display(Name = "_EnTitle", ResourceType = typeof(Resources))]
        public string EnTitle { get; set; }

        [Display(Name = "_RuTitle", ResourceType = typeof(Resources))]
        public string RuTitle { get; set; }

        [Display(Name = "_BgTitle", ResourceType = typeof(Resources))]
        public string BgTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_EnContent", ResourceType = typeof(Resources))]
        public string EnContent { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_RuContent", ResourceType = typeof(Resources))]
        public string RuContent { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_BgContent", ResourceType = typeof(Resources))]
        public string BgContent { get; set; }
    }
}