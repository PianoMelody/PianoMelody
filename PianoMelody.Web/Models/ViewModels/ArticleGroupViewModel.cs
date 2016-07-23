using OrangeJetpack.Localization;
using PianoMelody.Helpers;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ArticleGroupViewModel : IMapFrom<ArticleGroup>, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Name { get; set; }
    }

    public class ArticleGroupsWithPager
    {
        public IEnumerable<ArticleGroupViewModel> ArticleGroups { get; set; }

        public Pager Pager { get; set; }
    }
}