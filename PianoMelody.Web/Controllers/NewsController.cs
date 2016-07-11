using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.BindingModels;
using PianoMelody.Web.ViewModels;
using System.Linq;
using System.Web.Mvc;
using PianoMelody.Web.Utilities;

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
                    return RedirectToAction("Index");
                }

                var multimedia = this.Data.Multimedia.GetAll().FirstOrDefault();

                var news = new News()
                {
                    Title = JsonGenerator.Serialize(newsBindingModel.EnTitle, newsBindingModel.RuTitle, newsBindingModel.BgTitle),
                    Content = JsonGenerator.Serialize(newsBindingModel.EnContent, newsBindingModel.RuContent, newsBindingModel.BgContent),
                    Multimedia = multimedia
                };

                this.Data.News.Add(news);
                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
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
