namespace PianoMelody.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using OrangeJetpack.Localization;

    using Extensions;
    using Helpers;
    using I18N;
    using Models.BindingModels;
    using Models.ViewModels;

    using PianoMelody.Models.Enumetations;

    [Authorize(Roles = "Admin")]
    public class CarouselController : BaseController
    {
        public ActionResult Index()
        {
            var carousel = this.Data.Multimedia.GetAll()
                                               .Where(g => g.Type == MultimediaType.CarouselElement)
                                               .ProjectTo<CarouselViewModel>()
                                               .Localize(this.CurrentCulture, g => g.Content);
            return View(carousel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarouselBindingModel carouselBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (this.Data.Multimedia.GetAll().Count(c => c.Type == MultimediaType.CarouselElement) >= 5)
            {
                return this.RedirectToAction("Index");
            }

            var content = JsonHelper.Serialize(carouselBindingModel.EnContent, carouselBindingModel.RuContent, carouselBindingModel.BgContent);

            var multimedia = MultimediaHelper.CreateSingle
                (
                    this.Server,
                    carouselBindingModel.Multimedia,
                    this.GetBaseUrl(),
                    MultimediaType.CarouselElement,
                    content
                );

            if (multimedia == null)
            {
                this.AddNotification(Resources._ErrSelectMultimedia, NotificationType.ERROR);
                return this.View();
            }

            this.Data.Multimedia.Add(multimedia);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var currentCarouselElement = this.Data.Multimedia.Find(id);
            if (currentCarouselElement == null)
            {
                return this.RedirectToAction("Index");
            }

            var contentLocs = JsonHelper.Deserialize(currentCarouselElement.Content);

            var editCarouselElement = new CarouselBindingModel()
            {
                EnContent = contentLocs[0].v,
                RuContent = contentLocs[1].v,
                BgContent = contentLocs[2].v,
                Url = currentCarouselElement.Url
            };

            return View(editCarouselElement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarouselBindingModel carouselBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentCarouselElement = this.Data.Multimedia.Find(id);
            if (currentCarouselElement == null)
            {
                return this.View();
            }

            currentCarouselElement.Content = JsonHelper.Serialize(carouselBindingModel.EnContent, carouselBindingModel.RuContent, carouselBindingModel.BgContent);

            if (carouselBindingModel.Multimedia != null)
            {
                MultimediaHelper.DeleteSingle(this.Server, currentCarouselElement);

                var multimedia = MultimediaHelper.CreateSingle
                    (
                        this.Server,
                        carouselBindingModel.Multimedia,
                        this.GetBaseUrl(),
                        MultimediaType.CarouselElement,
                        currentCarouselElement.Content
                    );

                currentCarouselElement.Url = multimedia.Url;
            }

            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
