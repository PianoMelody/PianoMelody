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
    public class ManufacturerController : BaseController
    {
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new ManufacturersWithPager();
            var pager = new Pager(this.Data.Manufacturers.GetAll().Count(), page);
            model.Pager = pager;

            var manufacturers = this.Data.Manufacturers.GetAll()
                                                       .OrderBy(m => m.Name)
                                                       .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                                       .Take(pager.PageSize)
                                                       .ProjectTo<ManufacturerViewModel>()
                                                       .Localize(this.CurrentCulture, m => m.Name);
            model.Manufacturers = manufacturers;
            return View(model);
        }

        public ActionResult Create(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string returnUrl, ManufacturerBindingModel manufacturerBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var multimedia = MultimediaHelper.CreateSingle(this.Server, manufacturerBindingModel.Multimedia, this.GetBaseUrl());
            if (multimedia != null)
            {
                this.Data.Multimedia.Add(multimedia);
            }

            var manufacturer = new Manufacturer()
            {
                Name = JsonHelper.Serialize(manufacturerBindingModel.EnName, manufacturerBindingModel.RuName, manufacturerBindingModel.BgName),
                AreWeAgent = manufacturerBindingModel.AreWeAgent,
                UrlAddress = manufacturerBindingModel.UrlAddress,
                Multimedia = multimedia
            };

            this.Data.Manufacturers.Add(manufacturer);
            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var currentManufacturer = this.Data.Manufacturers.Find(id);
            if (currentManufacturer == null)
            {
                return Redirect(returnUrl);
            }

            var nameLocs = JsonHelper.Deserialize(currentManufacturer.Name);

            var editManufacturer = new ManufacturerBindingModel()
            {
                EnName = nameLocs[0].v,
                RuName = nameLocs[1].v,
                BgName = nameLocs[2].v,
                AreWeAgent = currentManufacturer.AreWeAgent,
                UrlAddress = currentManufacturer.UrlAddress
            };

            if (currentManufacturer.Multimedia != null)
            {
                editManufacturer.Url = currentManufacturer.Multimedia.Url;
            }

            return View(editManufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string returnUrl, ManufacturerBindingModel manufacturerBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentManufacturer = this.Data.Manufacturers.Find(id);
            if (currentManufacturer == null)
            {
                return this.View();
            }

            if (manufacturerBindingModel.Multimedia != null)
            {
                if (currentManufacturer.Multimedia != null)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentManufacturer.Multimedia);
                    this.Data.Multimedia.Delete(currentManufacturer.Multimedia);
                }

                currentManufacturer.Multimedia = MultimediaHelper.CreateSingle(this.Server, manufacturerBindingModel.Multimedia, this.GetBaseUrl());
            }

            currentManufacturer.Name = JsonHelper.Serialize(manufacturerBindingModel.EnName, manufacturerBindingModel.RuName, manufacturerBindingModel.BgName);
            currentManufacturer.AreWeAgent = manufacturerBindingModel.AreWeAgent;
            currentManufacturer.UrlAddress = manufacturerBindingModel.UrlAddress;

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Delete(int id, string returnUrl)
        {
            var deleteManufacturer = this.Data.Manufacturers.GetAll().ProjectTo<ManufacturerViewModel>()
                                                                     .FirstOrDefault(m => m.Id == id)
                                                                     .Localize(this.CurrentCulture, m => m.Name);
            if (deleteManufacturer == null)
            {
                return Redirect(returnUrl);
            }

            return View(deleteManufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string returnUrl, ManufacturerViewModel manufacturerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentManufacturer = this.Data.Manufacturers.Find(id);
            if (currentManufacturer == null)
            {
                return this.View();
            }

            if (currentManufacturer.Multimedia != null)
            {
                MultimediaHelper.DeleteSingle(this.Server, currentManufacturer.Multimedia);
                this.Data.Multimedia.Delete(currentManufacturer.Multimedia);
            }

            this.Data.Manufacturers.Delete(currentManufacturer);

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }
    }
}
