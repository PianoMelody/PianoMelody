using OrangeJetpack.Localization;
using PianoMelody.Helpers;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ServiceViewModel : IMapFrom<Service>, ILocalizable
    {
        public int Id { get; set; }

        public int Position { get; set; }

        [Localized]
        public string Name { get; set; }

        [Localized]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public Multimedia Multimedia { get; set; }
    }

    public class ServicesWithPager
    {
        public IEnumerable<ServiceViewModel> Services { get; set; }

        public Pager Pager { get; set; }
    }
}