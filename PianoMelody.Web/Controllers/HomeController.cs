﻿namespace PianoMelody.Web.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using PianoMelody.Models.Enumetations;
    using Models.ViewModels;
    using AutoMapper.QueryableExtensions;
    using OrangeJetpack.Localization;
    using Models.BindingModels;
    using Helpers;
    using System.Text;
    using Extensions;
    using System.Configuration;
    using I18N;

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

            homeViewModel.PromoProducts = this.Data.Products.GetAll()
                                                            .Where(p => p.PromoPrice != null)
                                                            .OrderBy(p => p.Position)
                                                            .Take(3)
                                                            .ProjectTo<ProductViewModel>()
                                                            .Localize(this.CurrentCulture, p => p.Name, p => p.Description, p => p.ArticleGroupName, p => p.ManufacturerName)
                                                            .ToArray();

            homeViewModel.LastNews = this.Data.News.GetAll()
                                                   .OrderByDescending(n => n.Created)
                                                   .Take(3)
                                                   .ProjectTo<NewsViewModel>()
                                                   .Localize(this.CurrentCulture, n => n.Title, n => n.Content)
                                                   .ToArray();

            homeViewModel.RandomReferences = this.Data.References.GetAll()
                                                                 .OrderByDescending(r => r.Created)
                                                                 .RandomElements(r => r.Multimedia != null, 2)
                                                                 .ProjectTo<ReferenceViewModel>()
                                                                 .Localize(this.CurrentCulture, r => r.Title, r => r.Content)
                                                                 .ToArray();

            homeViewModel.Manufacturers = this.Data.Manufacturers.GetAll()
                                                                 .Where(m => m.Multimedia != null)
                                                                 .ProjectTo<ManufacturerViewModel>()
                                                                 .Localize(this.CurrentCulture, m => m.Name);

            return this.View(homeViewModel);
        }

        // GET /About
        [HttpGet]
        public ActionResult About()
        {
            return this.View();
        }

        // GET /Contact
        [HttpGet]
        public ActionResult Contact(string about)
        {
            if (about != null)
            {
                return this.View(new EmailBindingModel {  Message = string.Format("{0} {1} - ", Resources._AskAbout, about) });
            }

            return this.View();
        }

        // GET /EditAbout
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string html, string returnUrl)
        {
            var htmls = this.Data.Resources.GetAll().Where(r => r.Name == html).ToArray();
            var enAbout = htmls.FirstOrDefault(l => l.Culture == "en");
            var ruAbout = htmls.FirstOrDefault(l => l.Culture == "ru");
            var bgAbout = htmls.FirstOrDefault(l => l.Culture == "bg");

            var rbm = new ResourcesBindingModel()
            {
                Name = html,
                EnValue = enAbout.Value,
                RuValue = ruAbout.Value,
                BgValue = bgAbout.Value
            };

            return this.View(rbm);
        }

        // GET /EditAbout
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(string html, string returnUrl, ResourcesBindingModel rbm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var htmls = this.Data.Resources.GetAll().Where(r => r.Name == html).ToArray();
            var enAbout = htmls.FirstOrDefault(l => l.Culture == "en");
            var ruAbout = htmls.FirstOrDefault(l => l.Culture == "ru");
            var bgAbout = htmls.FirstOrDefault(l => l.Culture == "bg");

            enAbout.Value = rbm.EnValue;
            ruAbout.Value = rbm.RuValue;
            bgAbout.Value = rbm.BgValue;

            this.Data.SaveChanges();

            Resources.Refresh();

            return this.Redirect(returnUrl);
        }

        // GET /SendEmail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(EmailBindingModel ebm)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Contact");
            }

            var emailBody = new StringBuilder();
            if (ebm.Name != null)
            {
                emailBody.AppendFormat("{0}<br />", ebm.Name);
            }

            emailBody.AppendFormat("{0}<br />", ebm.Email);

            if (ebm.Phone != null)
            {
                emailBody.AppendFormat("{0}<br />", ebm.Phone);
            }

            emailBody.AppendFormat("{0}<br />", ebm.Message);

            var email = new EmailHelper();
            email.Recipient = ConfigurationManager.AppSettings["user"];
            email.Subject = "Contact form enquery";
            email.Body = emailBody.ToString();

            //// Mailbox unavailable. The server response was: Access denied - Invalid HELO name (See RFC2821 4.1.1.1)
            //email.Send();

            this.AddNotification("The request is sent successfully", NotificationType.SUCCESS);
            return this.RedirectToAction("Contact");
        }
    }
}