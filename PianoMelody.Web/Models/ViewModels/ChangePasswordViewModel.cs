namespace PianoMelody.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using I18N;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [DataType(DataType.Password)]
        [Display(Name = "_CurrentPassword", ResourceType = typeof(Resources))]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrRequired")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_ErrLenghtValidation",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "_NewPassword", ResourceType = typeof(Resources))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "_ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "_PasswordValidation")]
        public string ConfirmPassword { get; set; }
    }
}