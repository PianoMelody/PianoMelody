namespace PianoMelody.Web.Models.ViewModels
{
    using Contracts;
    using PianoMelody.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}