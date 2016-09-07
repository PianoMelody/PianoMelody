using OrangeJetpack.Localization;
using PianoMelody.I18N;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PianoMelody.Web.Models.BindingModels
{
    public class ProductBindingModel : ILocalizable
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
        [RegularExpression(@"^\d*(\.|,|(\.\d{1,2})|(,\d{1,2}))?$", ErrorMessage = "Invalid price")]
        public decimal? Price { get; set; }

        [Display(Name = "_PromoPrice", ResourceType = typeof(Resources))]
        [RegularExpression(@"^\d*(\.|,|(\.\d{1,2})|(,\d{1,2}))?$", ErrorMessage = "Invalid price")]
        public decimal? PromoPrice { get; set; }

        [Display(Name = "_IsNew", ResourceType = typeof(Resources))]
        public bool IsNew { get; set; }

        [Display(Name = "_ArticleGroup", ResourceType = typeof(Resources))]
        public int? ArticleGroupId { get; set; }

        [Display(Name = "_Manufacturer", ResourceType = typeof(Resources))]
        public int? ManufacturerId { get; set; }

        [Display(Name = "_Photos", ResourceType = typeof(Resources))]
        public ICollection<HttpPostedFileBase> Multimedias { get; set; }
    }
}