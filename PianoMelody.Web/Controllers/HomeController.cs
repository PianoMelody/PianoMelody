namespace PianoMelody.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using SimpleMvcSitemap;
    using System.Linq;
    using PianoMelody.Models.Enumetations;
    using Models.ViewModels;
    using AutoMapper.QueryableExtensions;
    using OrangeJetpack.Localization;

    public class HomeController : BaseController
    {
        // GET /Home
        [HttpGet]
        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.Carousel = this.Data.Multimedia.GetAll()
                                                         .Where(m => m.Type == MultimediaType.CarouselElement)
                                                         .ProjectTo<CarouselViewModel>()
                                                         .Localize(this.CurrentCulture, c => c.Content)
                                                         .ToArray();

            return this.View(homeViewModel);
        }

        // GET /About
        [HttpGet]
        public ActionResult About()
        {
            return this.View();
        }

        // GET /About
        [HttpGet]
        public ActionResult Contact()
        {
            return this.View();
        }

        // GET /Sitemap
        public ActionResult Sitemap()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
                {
                    new SitemapNode(this.Url.Action("Index", "Home"))
                        {
                            ChangeFrequency = ChangeFrequency.Weekly,
                            LastModificationDate = DateTime.UtcNow,
                            Priority = 1.0m
                        },
                };

            return new SitemapProvider().CreateSitemap(this.HttpContext, nodes);
        }
    }
}