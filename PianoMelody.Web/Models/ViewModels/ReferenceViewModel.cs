using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ReferenceViewModel : IMapFrom<Reference>, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Title { get; set; }

        [Localized]
        public string Content { get; set; }

        public Multimedia Multimedia { get; set; }
    }
}