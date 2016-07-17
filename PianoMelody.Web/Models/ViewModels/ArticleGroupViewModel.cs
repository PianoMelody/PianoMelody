using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ArticleGroupViewModel : IMapFrom<ArticleGroup>, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Name { get; set; }
    }
}