using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using PianoMelody.Web.Helpers;
using PianoMelody.Models.Enumetations;
using PianoMelody.Web.Extensions;
using System;
using PianoMelody.Models;

namespace PianoMelody.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GalleryController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var gallery = this.Data.Multimedia.GetAll()
                                              .Where(g => g.Type == MultimediaType.PhotoElement || g.Type == MultimediaType.VideoElement)
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

                Multimedia multimedia = null;

                if (galleryBindingModel.Multimedia != null)
                {
                    multimedia = MultimediaHelper.CreateSingle
                    (
                        this.Server,
                        galleryBindingModel.Multimedia,
                        this.GetBaseUrl(),
                        MultimediaType.PhotoElement,
                        content
                    );
                }
                else if (galleryBindingModel.Url != null)
                {
                    multimedia = new Multimedia
                    {
                        Created = DateTime.Now,
                        Type = MultimediaType.VideoElement,
                        Content = content,
                        Url = galleryBindingModel.Url
                    };
                }

                if (multimedia == null)
                {
                    this.AddNotification(I18N.Resources._ErrSelectMultimedia, NotificationType.ERROR);
                    return this.View();
                }

                this.Data.Multimedia.Add(multimedia);
                this.Data.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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
                Type = currentGalleryElement.Type,
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

                if (galleryBindingModel.Type == MultimediaType.PhotoElement)
                {
                    if (galleryBindingModel.Multimedia != null)
                    {
                        MultimediaHelper.DeleteSingle(this.Server, currentGalleryElement);

                        var multimedia = MultimediaHelper.CreateSingle
                            (
                                this.Server,
                                galleryBindingModel.Multimedia,
                                this.GetBaseUrl(),
                                MultimediaType.PhotoElement,
                                currentGalleryElement.Content
                            );

                        currentGalleryElement.Url = multimedia.Url;
                    }
                }
                else if (galleryBindingModel.Type == MultimediaType.VideoElement)
                {
                    currentGalleryElement.Url = galleryBindingModel.Url;
                }

                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
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

                if (currentGalleryElement.Type == MultimediaType.PhotoElement)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentGalleryElement);
                }

                this.Data.Multimedia.Delete(currentGalleryElement);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
