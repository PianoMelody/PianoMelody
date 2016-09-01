using System.Collections.Generic;

namespace PianoMelody.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public CarouselViewModel[] Carousel { get; set; }

        public IEnumerable<ManufacturerViewModel> Manufacturers { get; set; }
    }
}