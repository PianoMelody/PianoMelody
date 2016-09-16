namespace PianoMelody.Web.Controllers
{
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
    public class ArticleGroupController : BaseController
    {
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new ArticleGroupsWithPager();
            var pager = new Pager(this.Data.ArticleGroups.GetAll().Count(), page);
            model.Pager = pager;

            var articleGroups = this.Data.ArticleGroups.GetAll()
                                                       .OrderBy(ag => ag.Id)
                                                       .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                       .Take(pager.PageSize)
                                                       .ProjectTo<ArticleGroupViewModel>()
                                                       .Localize(this.CurrentCulture, ag => ag.Name);
            model.ArticleGroups = articleGroups;
            return View(model);
        }

        public ActionResult Create(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string returnUrl, ArticleGroupBindingModel articleGroupBindingModel)
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

            return Redirect(returnUrl);
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var currentArticleGroup = this.Data.ArticleGroups.Find(id);
            if (currentArticleGroup == null)
            {
                return Redirect(returnUrl);
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
        public ActionResult Edit(int id, string returnUrl, ArticleGroupBindingModel articleGroupBindingModel)
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

            return Redirect(returnUrl);
        }

        public ActionResult Delete(int id, string returnUrl)
        {
            var deleteArticleGroup = this.Data.ArticleGroups.GetAll().ProjectTo<ArticleGroupViewModel>()
                                                                     .FirstOrDefault(ag => ag.Id == id)
                                                                     .Localize(this.CurrentCulture, ag => ag.Name);
            if (deleteArticleGroup == null)
            {
                return Redirect(returnUrl);
            }

            return View(deleteArticleGroup);
        }

        [HttpPost]
        public ActionResult Delete(int id, string returnUrl, ArticleGroupViewModel articleGroupViewModel)
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

            return Redirect(returnUrl);
        }
    }
}
