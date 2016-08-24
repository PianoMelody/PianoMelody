namespace PianoMelody.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Extensions;
    using I18N;
    using Models.BindingModels;
    using Models.ViewModels;

    [Authorize(Roles = "Admin")]
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index()
        {
            Resources.Refresh();

            var resources = this.Data.Resources.GetAll()
                                               .Where(r => !r.Name.StartsWith("_"))
                                               .GroupBy(r => r.Name)
                                               .Select(g => g.FirstOrDefault())
                                               .ProjectTo<ResourceViewModel>();

            return this.View(resources);
        }

        // GET: Language/AddLabel
        public ActionResult AddLabel()
        {
            return this.View();
        }

        // POST: Language/AddLabel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLabel(ResourcesBindingModel rbm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            this.Data.Resources.Add(new PianoMelody.Models.Resources { Culture = "en", Name = rbm.Name, Value = rbm.EnValue });
            this.Data.Resources.Add(new PianoMelody.Models.Resources { Culture = "ru", Name = rbm.Name, Value = rbm.RuValue });
            this.Data.Resources.Add(new PianoMelody.Models.Resources { Culture = "bg", Name = rbm.Name, Value = rbm.BgValue });

            this.Data.SaveChanges();

            this.AddNotification(Resources._LabelCreated, NotificationType.SUCCESS);
            return this.RedirectToAction("AddLabel");
        }

        // Get: Language/Edit
        public ActionResult Edit(string name)
        {
            var labels = this.Data.Resources.GetAll().Where(r => r.Name == name).ToArray();
            var enLabel = labels.FirstOrDefault(l => l.Culture == "en");
            var ruLabel = labels.FirstOrDefault(l => l.Culture == "ru");
            var bgLabel = labels.FirstOrDefault(l => l.Culture == "bg");

            var rbm = new ResourcesBindingModel()
            {
                Name = name,
                EnValue = enLabel.Value,
                RuValue = ruLabel.Value,
                BgValue = bgLabel.Value
            };

            return this.View(rbm);
        }

        // Post: Language/Edit
        [HttpPost]
        public ActionResult Edit(ResourcesBindingModel rbm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var labels = this.Data.Resources.GetAll().Where(r => r.Name == rbm.Name).ToArray();
            var enLabel = labels.FirstOrDefault(l => l.Culture == "en");
            var ruLabel = labels.FirstOrDefault(l => l.Culture == "ru");
            var bgLabel = labels.FirstOrDefault(l => l.Culture == "bg");

            enLabel.Value = rbm.EnValue;
            ruLabel.Value = rbm.RuValue;
            bgLabel.Value = rbm.BgValue;

            this.Data.SaveChanges();

            this.AddNotification(Resources._LabelUpdated, NotificationType.SUCCESS);
            return this.RedirectToAction("Index");
        }
    }
}