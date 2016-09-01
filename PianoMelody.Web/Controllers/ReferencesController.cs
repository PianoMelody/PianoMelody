using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System;
using PianoMelody.Web.Helpers;
using PianoMelody.Helpers;

namespace PianoMelody.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReferencesController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new ReferencesWithPager();
            var pager = new Pager(this.Data.References.GetAll().Count(), page);
            model.Pager = pager;

            var references = this.Data.References.GetAll()
                                                 .OrderByDescending(r => r.Created)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize)
                                                 .ProjectTo<ReferenceViewModel>()
                                                 .Localize(this.CurrentCulture, r => r.Title, r => r.Content);
            model.References = references;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReferenceBindingModel referenceBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var multimedia = MultimediaHelper.CreateSingle(this.Server, referenceBindingModel.Multimedia, this.GetBaseUrl());
                if (multimedia != null)
                {
                    this.Data.Multimedia.Add(multimedia);
                }

                var reference = new Reference()
                {
                    Created = DateTime.Now,
                    Title = JsonHelper.Serialize(referenceBindingModel.EnTitle, referenceBindingModel.RuTitle, referenceBindingModel.BgTitle),
                    Content = JsonHelper.Serialize(referenceBindingModel.EnContent, referenceBindingModel.RuContent, referenceBindingModel.BgContent),
                    Multimedia = multimedia
                };

                this.Data.References.Add(reference);

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
            var currentReference = this.Data.References.Find(id);
            if (currentReference == null)
            {
                return this.RedirectToAction("Index");
            }

            var titleLocs = JsonHelper.Deserialize(currentReference.Title);
            var contentLocs = JsonHelper.Deserialize(currentReference.Content);

            var editReference = new ReferenceBindingModel()
            {
                EnTitle = titleLocs[0].v,
                RuTitle = titleLocs[1].v,
                BgTitle = titleLocs[2].v,
                EnContent = contentLocs[0].v,
                RuContent = contentLocs[1].v,
                BgContent = contentLocs[2].v
            };

            if (currentReference.Multimedia != null)
            {
                editReference.Url = currentReference.Multimedia.Url;
            }

            return View(editReference);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReferenceBindingModel referenceBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentReference = this.Data.References.Find(id);
                if (currentReference == null)
                {
                    return this.View();
                }

                if (referenceBindingModel.Multimedia != null)
                {
                    if (currentReference.Multimedia != null)
                    {
                        MultimediaHelper.DeleteSingle(this.Server, currentReference.Multimedia);
                        this.Data.Multimedia.Delete(currentReference.Multimedia);
                    }

                    currentReference.Multimedia = MultimediaHelper.CreateSingle(this.Server, referenceBindingModel.Multimedia, this.GetBaseUrl());
                }

                currentReference.Title = JsonHelper.Serialize(referenceBindingModel.EnTitle, referenceBindingModel.RuTitle, referenceBindingModel.BgTitle);
                currentReference.Content = JsonHelper.Serialize(referenceBindingModel.EnContent, referenceBindingModel.RuContent, referenceBindingModel.BgContent);

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
            var deleteReference = this.Data.References.GetAll().ProjectTo<ReferenceViewModel>()
                                                               .FirstOrDefault(r => r.Id == id)
                                                               .Localize(this.CurrentCulture, r => r.Title, r => r.Content);
            if (deleteReference == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteReference);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ReferenceViewModel referenceViewModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentReference = this.Data.References.Find(id);
                if (currentReference == null)
                {
                    return this.View();
                }

                if (currentReference.Multimedia != null)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentReference.Multimedia);
                    this.Data.Multimedia.Delete(currentReference.Multimedia);
                }

                this.Data.References.Delete(currentReference);

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
