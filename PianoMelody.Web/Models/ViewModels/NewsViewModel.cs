using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System;

namespace PianoMelody.Web.Models.ViewModels
{
    public class NewsViewModel : IMapFrom<News>, ILocalizable
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Localized]
        public string Title { get; set; }

        [Localized]
        public string Content { get; set; }

        public Multimedia Multimedia { get; set; }
    }
}