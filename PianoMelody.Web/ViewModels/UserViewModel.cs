namespace PianoMelody.Web.ViewModels
{

    using PianoMelody.Models;
    using PianoMelody.Web.Contracts;

    public class UserViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}