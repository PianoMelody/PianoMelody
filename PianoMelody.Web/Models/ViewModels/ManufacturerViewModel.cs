using OrangeJetpack.Localization;
using PianoMelody.Helpers;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ManufacturerViewModel : IMapFrom<Manufacturer>, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Name { get; set; }

        public bool AreWeAgent { get; set; }

        public string UrlAddress { get; set; }

        public Multimedia Multimedia { get; set; }
    }

    public class ManufacturersWithPager
    {
        public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }

        public Pager Pager { get; set; }
    }
}