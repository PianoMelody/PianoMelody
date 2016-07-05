namespace PianoMelody.Web.ViewModels
{
    using Contracts;
    using Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}