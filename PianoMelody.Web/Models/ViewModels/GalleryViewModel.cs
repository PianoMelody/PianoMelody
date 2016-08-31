using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Models.Enumetations;
using PianoMelody.Web.Contracts;
using System;

namespace PianoMelody.Web.Models.ViewModels
{
    public class GalleryViewModel : IMapFrom<Multimedia>, ILocalizable
    {
        public int Id { get; set; }

        public MultimediaType Type { get; set; }

        public DateTime Created { get; set; }

        [Localized]
        public string Content { get; set; }

        public string Url { get; set; }

        public string DataSize { get; set; }
    }
}