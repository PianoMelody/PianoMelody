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

        public ActionResult Create(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string returnUrl, NewsBindingModel newsBindingModel)
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

            return Redirect(returnUrl);
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var currentNews = this.Data.News.Find(id);
            if (currentNews == null)
            {
                return Redirect(returnUrl);
            }

            var titleLocs = JsonHelper.Deserialize(currentNews.Title);
            var contentLocs = JsonHelper.Deserialize(currentNews.Content);

            var editNews = new NewsBindingModel()
            {
                Created = currentNews.Created,
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
        public ActionResult Edit(int id, string returnUrl, NewsBindingModel newsBindingModel)
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

            currentNews.Created = newsBindingModel.Created;
            currentNews.Title = JsonHelper.Serialize(newsBindingModel.EnTitle, newsBindingModel.RuTitle, newsBindingModel.BgTitle);
            currentNews.Content = JsonHelper.Serialize(newsBindingModel.EnContent, newsBindingModel.RuContent, newsBindingModel.BgContent);

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Delete(int id, string returnUrl)
        {
            var deleteNews = this.Data.News.GetAll().ProjectTo<NewsViewModel>()
                                                    .FirstOrDefault(n => n.Id == id)
                                                    .Localize(this.CurrentCulture, n => n.Title, n => n.Content);
            if (deleteNews == null)
            {
                return Redirect(returnUrl);
            }

            return View(deleteNews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string returnUrl, NewsViewModel newsViewModel)
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

            return Redirect(returnUrl);
        }
    }
}
