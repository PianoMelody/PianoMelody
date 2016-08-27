using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System.Collections.Generic;
using AutoMapper;
using PianoMelody.Helpers;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ProductViewModel : IMapFrom<Product>, ICustomMappings, ILocalizable
    {
        public int Id { get; set; }

        public int Position { get; set; }

        [Localized]
        public string Name { get; set; }

        [Localized]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromoPrice { get; set; }

        public bool IsNew { get; set; }

        [Localized]
        public string ArticleGroupName { get; set; }

        [Localized]
        public string ManufacturerName { get; set; }

        public ICollection<Multimedia> Multimedias { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                         .ForMember(
                             p => p.ArticleGroupName,
                             opt => opt.MapFrom(p => p.ArtilceGroup.Name))
                         .ForMember(
                             p => p.ManufacturerName,
                             opt => opt.MapFrom(p => p.Manufacturer.Name));
        }
    }

    public class ProductsWithPager
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public Pager Pager { get; set; }
    }
}