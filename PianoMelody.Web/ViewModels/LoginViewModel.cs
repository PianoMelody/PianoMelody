namespace PianoMelody.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using PianoMelody.I18N;

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}