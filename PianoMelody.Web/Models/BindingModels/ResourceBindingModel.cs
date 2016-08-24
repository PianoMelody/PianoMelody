namespace PianoMelody.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    using I18N;

    public class ResourcesBindingModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string BgValue { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string EnValue { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        public string RuValue { get; set; }
    }
}