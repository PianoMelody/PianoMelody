using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ManufacturerViewModel : IMapFrom<Manufacturer>, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Name { get; set; }

        public string UrlAddress { get; set; }

        public Multimedia Multimedia { get; set; }
    }
}