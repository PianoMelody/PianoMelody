using PianoMelody.I18N;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PianoMelody.Web.Models.BindingModels
{
    public class ServiceBindingModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [Display(Name = "_EnName", ResourceType = typeof(Resources))]
        public string EnName { get; set; }

        [Display(Name = "_RuName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string RuName { get; set; }

        [Display(Name = "_BgName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string BgName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_EnDescription", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string EnDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_RuDescription", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string RuDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "_BgDescription", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string BgDescription { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources))]
        public decimal? Price { get; set; }

        [Display(Name = "_Photo", ResourceType = typeof(Resources))]
        public HttpPostedFileBase Multimedia { get; set; }

        public string Url { get; set; }
    }
}