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
    public class NewsController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new NewsWithPager();
            var pager = new Pager(this.Data.News.GetAll().Count(), page);
            model.Pager = pager;

            var news = this.Data.News.GetAll()
                                     .OrderByDescending(n => n.Created)
                                     .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                     .Take(pager.PageSize)
                                     .ProjectTo<NewsViewModel>()
                                     .Localize(this.CurrentCulture, n => n.Title, n => n.Content);
            model.News = news;
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
                if (multimedia != null)
                {
                    this.Data.Multimedia.Add(multimedia);
                }

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
            var currentNews = this.Data.News.Find(id);
            if (currentNews == null)
            {
                return this.RedirectToAction("Index");
            }

            var titleLocs = JsonHelper.Deserialize(currentNews.Title);
            var contentLocs = JsonHelper.Deserialize(currentNews.Content);

            var editNews = new NewsBindingModel()
            {
                EnTitle = titleLocs[0].v,
                RuTitle = titleLocs[1].v,
                BgTitle = titleLocs[2].v,
                EnContent = contentLocs[0].v,
                RuContent = contentLocs[1].v,
                BgContent = contentLocs[2].v,
            };

            if (currentNews.Multimedia != null)
            {
                editNews.Url = currentNews.Multimedia.Url;
            }

            return View(editNews);
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

                var currentNews = this.Data.News.Find(id);
                if (currentNews == null)
                {
                    return this.View();
                }

                if (newsBindingModel.Multimedia != null)
                {
                    if (currentNews.Multimedia != null)
                    {
                        MultimediaHelper.DeleteSingle(this.Server, currentNews.Multimedia);
                        this.Data.Multimedia.Delete(currentNews.Multimedia);
                    }

                    currentNews.Multimedia = MultimediaHelper.CreateSingle(this.Server, newsBindingModel.Multimedia, this.GetBaseUrl());
                }

                currentNews.Title = JsonHelper.Serialize(newsBindingModel.EnTitle, newsBindingModel.RuTitle, newsBindingModel.BgTitle);
                currentNews.Content = JsonHelper.Serialize(newsBindingModel.EnContent, newsBindingModel.RuContent, newsBindingModel.BgContent);

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
            var deleteNews = this.Data.News.GetAll().ProjectTo<NewsViewModel>()
                                                    .FirstOrDefault(n => n.Id == id)
                                                    .Localize(this.CurrentCulture, n => n.Title, n => n.Content);
            if (deleteNews == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteNews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, NewsViewModel newsViewModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentNews = this.Data.News.Find(id);
                if (currentNews == null)
                {
                    return this.View();
                }

                if (currentNews.Multimedia != null)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentNews.Multimedia);
                    this.Data.Multimedia.Delete(currentNews.Multimedia);
                }

                this.Data.News.Delete(currentNews);

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
