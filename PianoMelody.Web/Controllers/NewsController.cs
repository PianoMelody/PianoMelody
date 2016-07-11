using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.BindingModels;
using PianoMelody.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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

                var enTitle = new KeyValue() { k = "en", v = newsBindingModel.EnTitle };
                var ruTitle = new KeyValue() { k = "ru", v = newsBindingModel.RuTitle };
                var bgTitle = new KeyValue() { k = "bg", v = newsBindingModel.BgTitle };

                var title = new List<KeyValue> { enTitle, ruTitle, bgTitle };

                var jsonTitle = JsonConvert.SerializeObject(title);

                var enContent = new KeyValue() { k = "en", v = newsBindingModel.EnContent };
                var ruContent = new KeyValue() { k = "ru", v = newsBindingModel.RuContent };
                var bgContent = new KeyValue() { k = "bg", v = newsBindingModel.BgContent };

                var content = new List<KeyValue> { enContent, ruContent, bgContent };

                var jsonContent = JsonConvert.SerializeObject(content);

                var multimedia = this.Data.Multimedia.GetAll().FirstOrDefault();

                var news = new News()
                {
                    Title = jsonTitle,
                    Content = jsonContent,
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
