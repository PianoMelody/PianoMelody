using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System;

namespace PianoMelody.Web.Models.ViewModels
{
    public class CarouselViewModel : IMapFrom<Multimedia>, ILocalizable
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Localized]
        public string Content { get; set; }

        public string Url { get; set; }
    }
}