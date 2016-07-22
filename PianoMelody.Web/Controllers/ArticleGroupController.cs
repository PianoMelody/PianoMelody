using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Helpers;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PianoMelody.Web.Controllers
{
    public class ArticleGroupController : BaseController
    {
        public ActionResult Index()
        {
            var articleGroups = this.Data.ArticleGroups.GetAll().ProjectTo<ArticleGroupViewModel>()
                                                                .Localize(this.CurrentCulture, ag => ag.Name);

            return View(articleGroups);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleGroupBindingModel articleGroupBindingModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.View();
                }

                var articleGroup = new ArticleGroup()
                {
                    Name = JsonHelper.Serialize(articleGroupBindingModel.EnName, articleGroupBindingModel.RuName, articleGroupBindingModel.BgName)
                };

                this.Data.ArticleGroups.Add(articleGroup);
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
            var currentArticleGroup = this.Data.ArticleGroups.Find(id);
            if (currentArticleGroup == null)
            {
                return this.RedirectToAction("Index");
            }

            var nameLocs = JsonHelper.Deserialize(currentArticleGroup.Name);

            var editArticleGroup = new ArticleGroupBindingModel()
            {
                EnName = nameLocs[0].v,
                RuName = nameLocs[1].v,
                BgName = nameLocs[2].v
            };

            return View(editArticleGroup);
        }

        [HttpPost]
        public ActionResult Edit(int id, ArticleGroupBindingModel articleGroupBindingModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.View();
                }

                var articleGroup = this.Data.ArticleGroups.Find(id);
                if (articleGroup == null)
                {
                    return this.View();
                }

                articleGroup.Name = JsonHelper.Serialize(articleGroupBindingModel.EnName, articleGroupBindingModel.RuName, articleGroupBindingModel.BgName);
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
            var deleteArticleGroup = this.Data.ArticleGroups.GetAll().ProjectTo<ArticleGroupViewModel>()
                                                                     .FirstOrDefault(ag => ag.Id == id)
                                                                     .Localize(this.CurrentCulture, ag => ag.Name);
            if (deleteArticleGroup == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteArticleGroup);
        }

        [HttpPost]
        public ActionResult Delete(int id, ArticleGroupViewModel articleGroupViewModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentArticleGroup = this.Data.ArticleGroups.Find(id);
                if (currentArticleGroup == null)
                {
                    return this.View();
                }

                this.Data.ArticleGroups.Delete(currentArticleGroup);
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
