using PianoMelody.Models;
using PianoMelody.Web.Contracts;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ResourceViewModel : IMapFrom<Resources>
    {
        public string Name { get; set; }
    }
}