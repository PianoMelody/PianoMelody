using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System;
using PianoMelody.Web.Helpers;
using PianoMelody.Models.Enumetations;
using PianoMelody.Web.Extensions;

namespace PianoMelody.Web.Controllers
{
    public class GalleryController : BaseController
    {
        public ActionResult Index()
        {
            var gallery = this.Data.Multimedia.GetAll().Where(g => g.Type == MultimediaType.GalleryElement)
                                                       .OrderByDescending(g => g.Created)
                                                       .ProjectTo<GalleryViewModel>()
                                                       .Localize(this.CurrentCulture, g => g.Content);
            return View(gallery);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryBindingModel galleryBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var content = JsonHelper.Serialize(galleryBindingModel.EnContent, galleryBindingModel.RuContent, galleryBindingModel.BgContent);

                var multimedia = MultimediaHelper.CreateSingle
                    (
                        this.Server, 
                        galleryBindingModel.Multimedia, 
                        this.GetBaseUrl(), 
                        MultimediaType.GalleryElement,
                        content
                    );

                if (multimedia == null)
                {
                    this.AddNotification("Image cannot be empty", NotificationType.ERROR);
                    return this.View();
                }

                this.Data.Multimedia.Add(multimedia);
                this.Data.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var currentGalleryElement = this.Data.Multimedia.Find(id);
            if (currentGalleryElement == null)
            {
                return this.RedirectToAction("Index");
            }

            var contentLocs = JsonHelper.Deserialize(currentGalleryElement.Content);

            var editGalleryElement = new GalleryBindingModel()
            {
                EnContent = contentLocs[0].v,
                RuContent = contentLocs[1].v,
                BgContent = contentLocs[2].v,
                Url = currentGalleryElement.Url
            };

            return View(editGalleryElement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GalleryBindingModel galleryBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentGalleryElement = this.Data.Multimedia.Find(id);
                if (currentGalleryElement == null)
                {
                    return this.View();
                }

                currentGalleryElement.Content = JsonHelper.Serialize(galleryBindingModel.EnContent, galleryBindingModel.RuContent, galleryBindingModel.BgContent);

                if (galleryBindingModel.Multimedia != null)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentGalleryElement);

                    var multimedia = MultimediaHelper.CreateSingle
                        (
                            this.Server,
                            galleryBindingModel.Multimedia,
                            this.GetBaseUrl(),
                            MultimediaType.GalleryElement,
                            currentGalleryElement.Content
                        );

                    currentGalleryElement.Url = multimedia.Url;
                }

                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var deleteGalleryElement = this.Data.Multimedia.GetAll().ProjectTo<GalleryViewModel>()
                                                                    .FirstOrDefault(g => g.Id == id)
                                                                    .Localize(this.CurrentCulture, n => n.Content);
            if (deleteGalleryElement == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteGalleryElement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, GalleryViewModel galleryViewModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentGalleryElement = this.Data.Multimedia.Find(id);
                if (currentGalleryElement == null)
                {
                    return this.View();
                }

                MultimediaHelper.DeleteSingle(this.Server, currentGalleryElement);
                this.Data.Multimedia.Delete(currentGalleryElement);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
