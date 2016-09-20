namespace PianoMelody.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using I18N;

    public class RegistrationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [EmailAddress]
        [Display(Name = "_Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrLenghtValidation",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "_Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "_ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_PasswordValidation")]
        public string ConfirmPassword { get; set; }
    }
}