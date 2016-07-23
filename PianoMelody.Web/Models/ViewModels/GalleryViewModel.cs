using OrangeJetpack.Localization;
using PianoMelody.Helpers;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System;
using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class GalleryViewModel : IMapFrom<Multimedia>, ILocalizable
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Localized]
        public string Content { get; set; }

        public string Url { get; set; }
    }

    public class GalleryWithPager
    {
        public IEnumerable<GalleryViewModel> Gallery { get; set; }

        public Pager Pager { get; set; }
    }
}