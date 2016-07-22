using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System;
using PianoMelody.Web.Helpers;

namespace PianoMelody.Web.Controllers
{
    public class InfoController : BaseController
    {
        public ActionResult Index()
        {
            var informations = this.Data.Informations.GetAll().ProjectTo<InfoViewModel>()
                                                              .OrderByDescending(i => i.Created)
                                                              .Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            return View(informations);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InfoBindingModel infoBindingModel)
        {
            try
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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var currentInfo = this.Data.Informations.Find(id);
            if (currentInfo == null)
            {
                return this.RedirectToAction("Index");
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
        public ActionResult Edit(int id, InfoBindingModel infoBindingModel)
        {
            try
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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var deleteInfo = this.Data.Informations.GetAll().ProjectTo<InfoViewModel>()
                                                            .FirstOrDefault(i => i.Id == id)
                                                            .Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            if (deleteInfo == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InfoViewModel infoViewModel)
        {
            try
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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
