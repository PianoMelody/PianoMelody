using OrangeJetpack.Localization;
using PianoMelody.Helpers;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System;
using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ReferenceViewModel : IMapFrom<Reference>, ILocalizable
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Localized]
        public string Title { get; set; }

        [Localized]
        public string Content { get; set; }

        public Multimedia Multimedia { get; set; }
    }

    public class ReferencesWithPager
    {
        public IEnumerable<ReferenceViewModel> References { get; set; }

        public Pager Pager { get; set; }
    }
}