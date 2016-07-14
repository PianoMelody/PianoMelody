namespace PianoMelody.Web.Controllers
{
    using System.Web.Mvc;

    using Extensions;
    using I18N;
    using Models.ViewModels;

    [Authorize]
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index()
        {
            return this.View();
        }

        // POST: Language/EditAll
        [HttpPost]
        public ActionResult EditAll()
        {
            return this.RedirectToAction("Index");
        }

        // GET: Language/AddLabel
        public ActionResult AddLabel()
        {
            return this.View();
        }

        // POST: Language/AddLabel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLabel(LabelViewModel lvm)
        {
            if (!this.ModelState.IsValid)
            {
                this.AddNotification("Invalid label model", NotificationType.ERROR);
                return this.View();
            }

            this.Data.Resources.Add(new PianoMelody.Models.Resources { Culture = "en", Name = lvm.Name, Value = lvm.EnValue });
            this.Data.Resources.Add(new PianoMelody.Models.Resources { Culture = "ru", Name = lvm.Name, Value = lvm.RuValue });
            this.Data.Resources.Add(new PianoMelody.Models.Resources { Culture = "bg", Name = lvm.Name, Value = lvm.BgValue });

            this.Data.SaveChanges();

            this.AddNotification(Resources._LabelCreated, NotificationType.SUCCESS);
            return this.RedirectToAction("AddLabel");
        }
    }
}