namespace PianoMelody.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using OrangeJetpack.Localization;

    using Helpers;
    using Models.BindingModels;
    using Models.ViewModels;

    using PianoMelody.Helpers;
    using PianoMelody.Models;

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
                                                 .OrderBy(r => r.Position)
                                                 .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                 .Take(pager.PageSize)
                                                 .ProjectTo<ReferenceViewModel>()
                                                 .Localize(this.CurrentCulture, r => r.Title, r => r.Content);
            model.References = references;
            return View(model);
        }

        public ActionResult Create(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string returnUrl, ReferenceBindingModel referenceBindingModel)
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

            return Redirect(returnUrl);
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var currentReference = this.Data.References.Find(id);
            if (currentReference == null)
            {
                return Redirect(returnUrl);
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
        public ActionResult Edit(int id, string returnUrl, ReferenceBindingModel referenceBindingModel)
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

            return Redirect(returnUrl);
        }

        public ActionResult Delete(int id, string returnUrl)
        {
            var deleteReference = this.Data.References.GetAll().ProjectTo<ReferenceViewModel>()
                                                               .FirstOrDefault(r => r.Id == id)
                                                               .Localize(this.CurrentCulture, r => r.Title, r => r.Content);
            if (deleteReference == null)
            {
                return Redirect(returnUrl);
            }

            return View(deleteReference);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string returnUrl, ReferenceViewModel referenceViewModel)
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

            this.RePosition();

            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Up(int id, string returnUrl)
        {
            var up = this.Data.References.Find(id);
            if (up != null)
            {
                var down = this.Data.References.GetAll().FirstOrDefault(p => p.Position == up.Position - 1);
                if (down != null)
                {
                    int temp = up.Position;
                    up.Position = down.Position;
                    down.Position = temp;

                    this.Data.SaveChanges();
                }
            }

            return this.Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Down(int id, string returnUrl)
        {
            var down = this.Data.References.Find(id);
            if (down != null)
            {
                var up = this.Data.References.GetAll().FirstOrDefault(p => p.Position == down.Position + 1);
                if (up != null)
                {
                    int temp = up.Position;
                    up.Position = down.Position;
                    down.Position = temp;

                    this.Data.SaveChanges();
                }
            }

            return this.Redirect(returnUrl);
        }

        private void RePosition()
        {
            var references = this.Data.References.GetAll().OrderBy(a => a.Position).ToList();

            for (int i = 0; i < references.Count; i++)
            {
                references[i].Position = i + 1;
            }

            this.Data.SaveChanges();
        }
    }
}
