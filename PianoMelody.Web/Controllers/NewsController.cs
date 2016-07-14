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
        public ActionResult Index()
        {
            var model = this.Data.News.GetAll().ProjectTo<NewsViewModel>()
                                               .ToList()
                                               .Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var currentNews = this.Data.News.GetAll().FirstOrDefault(n => n.Id == id);
            if (currentNews == null)
            {
                this.AddNotification("Cannot find news", NotificationType.ERROR);
                return this.RedirectToAction("Index");
            }

            var titleLocs = JsonHelper.Deserialize(currentNews.Title);
            var contentLocs = JsonHelper.Deserialize(currentNews.Content);

            var editModel = new NewsBindingModel()
            {
                EnTitle = titleLocs[0].v,
                RuTitle = titleLocs[1].v,
                BgTitle = titleLocs[2].v,
                EnContent = contentLocs[0].v,
                RuContent = contentLocs[1].v,
                BgContent = contentLocs[2].v,
                Url = currentNews.Multimedia.Url
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewsBindingModel newsBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentNews = this.Data.News.GetAll().FirstOrDefault(n => n.Id == id);
                if (currentNews == null)
                {
                    this.AddNotification("Cannot find news", NotificationType.ERROR);
                    return this.View();
                }

                MultimediaHelper.DeleteSingle(this.Server, currentNews.Multimedia);
                this.Data.Multimedia.Delete(currentNews.Multimedia);

                currentNews.Multimedia = MultimediaHelper.CreateSingle(this.Server, newsBindingModel.Multimedia, this.GetBaseUrl());
                currentNews.Title = JsonHelper.Serialize(newsBindingModel.EnTitle, newsBindingModel.RuTitle, newsBindingModel.BgTitle);
                currentNews.Content = JsonHelper.Serialize(newsBindingModel.EnContent, newsBindingModel.RuContent, newsBindingModel.BgContent);

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
            var deleteModel = this.Data.News.GetAll().ProjectTo<NewsViewModel>()
                                                     .FirstOrDefault(n => n.Id == id)
                                                     .Localize(this.CurrentCulture, i => i.Title, i => i.Content);
            if (deleteModel == null)
            {
                this.AddNotification("Cannot find news", NotificationType.ERROR);
                return this.RedirectToAction("Index");
            }

            return View(deleteModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NewsViewModel collection)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentNews = this.Data.News.GetAll().FirstOrDefault(n => n.Id == id);
                if (currentNews == null)
                {
                    this.AddNotification("Cannot find news", NotificationType.ERROR);
                    return this.View();
                }

                MultimediaHelper.DeleteSingle(this.Server, currentNews.Multimedia);

                this.Data.Multimedia.Delete(currentNews.Multimedia);
                this.Data.News.Delete(currentNews);

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
