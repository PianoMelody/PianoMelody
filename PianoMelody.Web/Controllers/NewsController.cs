using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System;
using PianoMelody.Web.Extensions;
using PianoMelody.Web.Helpers;

namespace PianoMelody.Web.Controllers
{
    public class NewsController : BaseController
    {
        // GET: News
        public ActionResult Index()
        {
            var model = this.Data.News.GetAll().ProjectTo<NewsViewModel>().ToList().Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            return View(model);
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(NewsBindingModel newsBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var multimedia = MultimediaHelper.CreateSingle(this.Server, newsBindingModel.Multimedia, this.GetBaseUrl());
                this.Data.Multimedia.Add(multimedia);

                var news = new News()
                {
                    Created = DateTime.Now,
                    Title = JsonHelper.Serialize(newsBindingModel.EnTitle, newsBindingModel.RuTitle, newsBindingModel.BgTitle),
                    Content = JsonHelper.Serialize(newsBindingModel.EnContent, newsBindingModel.RuContent, newsBindingModel.BgContent),
                    Multimedia = multimedia
                };

                this.Data.News.Add(news);

                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification(ex.Message, NotificationType.ERROR);
                return View();
            }
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
