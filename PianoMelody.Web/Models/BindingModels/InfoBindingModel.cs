using PianoMelody.I18N;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PianoMelody.Web.Models.BindingModels
{
    public class InfoBindingModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [Display(Name = "_EnTitle", ResourceType = typeof(Resources))]
        public string EnTitle { get; set; }

        [Display(Name = "_RuTitle", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string RuTitle { get; set; }

        [Display(Name = "_BgTitle", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string BgTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_EnContent", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string EnContent { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_RuContent", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string RuContent { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_BgContent", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string BgContent { get; set; }
        
        [Display(Name = "_Photo", ResourceType = typeof(Resources))]
        public HttpPostedFileBase Multimedia { get; set; }

        public string Url { get; set; }
    }
}