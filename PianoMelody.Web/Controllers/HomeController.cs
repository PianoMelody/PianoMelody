namespace PianoMelody.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using SimpleMvcSitemap;

    public class HomeController : BaseController
    {
        // GET /Home
        [HttpGet]
        public ActionResult Index()
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