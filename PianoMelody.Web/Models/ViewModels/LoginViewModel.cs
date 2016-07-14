namespace PianoMelody.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using I18N;

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [Display(Name = "_Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "_Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }
    }
}