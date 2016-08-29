namespace PianoMelody.Web.Controllers
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

        // GET /Contact
        [HttpGet]
        public ActionResult Contact()
        {
            return this.View();
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

            this.AddNotification("Enquery sent successfull", NotificationType.SUCCESS);
            return this.RedirectToAction("Contact");
        }
    }
}