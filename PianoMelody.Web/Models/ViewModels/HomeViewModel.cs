using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public CarouselViewModel[] Carousel { get; set; }

        public ProductViewModel[] PromoProducts { get; set; }

        public NewsViewModel[] LastNews { get; set; }

        public ReferenceViewModel[] RandomReferences { get; set; }

        public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }

    }
}