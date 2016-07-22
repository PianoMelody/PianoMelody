using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Contracts;
using System.Collections.Generic;
using AutoMapper;

namespace PianoMelody.Web.Models.ViewModels
{
    public class ProductViewModel : IMapFrom<Product>, ICustomMappings, ILocalizable
    {
        public int Id { get; set; }

        [Localized]
        public string Name { get; set; }

        [Localized]
        public string Description { get; set; }

        public decimal? Price { get; set; }

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
}