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
    public class InfoController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new InfoWithPager();
            var pager = new Pager(this.Data.Informations.GetAll().Count(), page);
            model.Pager = pager;

            var informations = this.Data.Informations.GetAll()
                                                     .OrderBy(i => i.Position)
                                                     .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                     .Take(pager.PageSize)
                                                     .ProjectTo<InfoViewModel>()
                                                     .Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            model.Informations = informations;
            return View(model);
        }

        public ActionResult Create(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string returnUrl, InfoBindingModel infoBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var multimedia = MultimediaHelper.CreateSingle(this.Server, infoBindingModel.Multimedia, this.GetBaseUrl());
            if (multimedia != null)
            {
                this.Data.Multimedia.Add(multimedia);
            }

            var info = new Information()
            {
                Created = DateTime.Now,
                Title = JsonHelper.Serialize(infoBindingModel.EnTitle, infoBindingModel.RuTitle, infoBindingModel.BgTitle),
                Content = JsonHelper.Serialize(infoBindingModel.EnContent, infoBindingModel.RuContent, infoBindingModel.BgContent),
                Multimedia = multimedia
            };

            this.Data.Informations.Add(info);

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var currentInfo = this.Data.Informations.Find(id);
            if (currentInfo == null)
            {
                return Redirect(returnUrl);
            }

            var titleLocs = JsonHelper.Deserialize(currentInfo.Title);
            var contentLocs = JsonHelper.Deserialize(currentInfo.Content);

            var editInfo = new InfoBindingModel()
            {
                EnTitle = titleLocs[0].v,
                RuTitle = titleLocs[1].v,
                BgTitle = titleLocs[2].v,
                EnContent = contentLocs[0].v,
                RuContent = contentLocs[1].v,
                BgContent = contentLocs[2].v
            };

            if (currentInfo.Multimedia != null)
            {
                editInfo.Url = currentInfo.Multimedia.Url;
            }

            return View(editInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string returnUrl, InfoBindingModel infoBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentInfo = this.Data.Informations.Find(id);
            if (currentInfo == null)
            {
                return this.View();
            }

            if (infoBindingModel.Multimedia != null)
            {
                if (currentInfo.Multimedia != null)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentInfo.Multimedia);
                    this.Data.Multimedia.Delete(currentInfo.Multimedia);
                }

                currentInfo.Multimedia = MultimediaHelper.CreateSingle(this.Server, infoBindingModel.Multimedia, this.GetBaseUrl());
            }

            currentInfo.Title = JsonHelper.Serialize(infoBindingModel.EnTitle, infoBindingModel.RuTitle, infoBindingModel.BgTitle);
            currentInfo.Content = JsonHelper.Serialize(infoBindingModel.EnContent, infoBindingModel.RuContent, infoBindingModel.BgContent);

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Delete(int id, string returnUrl)
        {
            var deleteInfo = this.Data.Informations.GetAll().ProjectTo<InfoViewModel>()
                                                            .FirstOrDefault(i => i.Id == id)
                                                            .Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            if (deleteInfo == null)
            {
                return Redirect(returnUrl);
            }

            return View(deleteInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string returnUrl, InfoViewModel infoViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentInfo = this.Data.Informations.Find(id);
            if (currentInfo == null)
            {
                return this.View();
            }

            if (currentInfo.Multimedia != null)
            {
                MultimediaHelper.DeleteSingle(this.Server, currentInfo.Multimedia);
                this.Data.Multimedia.Delete(currentInfo.Multimedia);
            }

            this.Data.Informations.Delete(currentInfo);

            this.Data.SaveChanges();

            this.RePosition();

            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Up(int id, string returnUrl)
        {
            var up = this.Data.Informations.Find(id);
            if (up != null)
            {
                var down = this.Data.Informations.GetAll().FirstOrDefault(p => p.Position == up.Position - 1);
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
            var down = this.Data.Informations.Find(id);
            if (down != null)
            {
                var up = this.Data.Informations.GetAll().FirstOrDefault(p => p.Position == down.Position + 1);
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
            var informations = this.Data.Informations.GetAll().OrderBy(a => a.Position).ToList();

            for (int i = 0; i < informations.Count; i++)
            {
                informations[i].Position = i + 1;
            }

            this.Data.SaveChanges();
        }
    }
}
