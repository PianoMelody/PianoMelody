namespace PianoMelody.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using PianoMelody.I18N;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword")]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword")]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}