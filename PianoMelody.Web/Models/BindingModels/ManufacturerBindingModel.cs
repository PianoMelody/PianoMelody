using PianoMelody.I18N;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PianoMelody.Web.Models.BindingModels
{
    public class ManufacturerBindingModel
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

        [Display(Name = "_UrlAddress", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string UrlAddress { get; set; }

        [Display(Name = "_Photo", ResourceType = typeof(Resources))]
        public HttpPostedFileBase Multimedia { get; set; }

        public string Url { get; set; }
    }
}