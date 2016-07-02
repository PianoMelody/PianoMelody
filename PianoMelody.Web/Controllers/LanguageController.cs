using PianoMelody.Web.Extensions;
using PianoMelody.Web.ViewModels;
using System.Web.Mvc;

namespace PianoMelody.Web.Controllers
{
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
        public ActionResult AddLabel(LabelViewModel lvm)
        {
            if (!this.ModelState.IsValid)
            {
                this.AddNotification("Invalid label model", NotificationType.ERROR);
                return this.View();
            }

            this.Data.Resources.Add(new Models.Resources { Culture = "bg-bg", Name = lvm.Name, Value = lvm.BgValue });
            this.Data.Resources.Add(new Models.Resources { Culture = "en-us", Name = lvm.Name, Value = lvm.EnValue });
            this.Data.Resources.Add(new Models.Resources { Culture = "ru-ru", Name = lvm.Name, Value = lvm.RuValue });

            this.Data.SaveChanges();

            this.AddNotification("Label created", NotificationType.SUCCESS);
            return this.RedirectToAction("AddLabel");
        }
    }
}