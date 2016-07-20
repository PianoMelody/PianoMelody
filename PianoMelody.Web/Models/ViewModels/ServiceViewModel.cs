using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ServiceViewModel : IMapFrom<Service>, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Name { get; set; }

        [Localized]
        public string Description { get; set; }

        public decimal? Price { get; set; }
    }
}