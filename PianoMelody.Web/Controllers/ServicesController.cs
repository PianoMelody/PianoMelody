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
    public class ServicesController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new ServicesWithPager();
            var pager = new Pager(this.Data.Services.GetAll().Count(), page);
            model.Pager = pager;

            var services = this.Data.Services.GetAll()
                                             .OrderBy(s => s.Position)
                                             .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                             .Take(pager.PageSize)
                                             .ProjectTo<ServiceViewModel>()
                                             .Localize(this.CurrentCulture, s => s.Name, s => s.Description);
            model.Services = services;
            return View(model);
        }

        public ActionResult Create(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string returnUrl, ServiceBindingModel serviceBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var multimedia = MultimediaHelper.CreateSingle(this.Server, serviceBindingModel.Multimedia, this.GetBaseUrl());
            if (multimedia != null)
            {
                this.Data.Multimedia.Add(multimedia);
            }

            var service = new Service()
            {
                Name = JsonHelper.Serialize(serviceBindingModel.EnName, serviceBindingModel.RuName, serviceBindingModel.BgName),
                Description = JsonHelper.Serialize(serviceBindingModel.EnDescription, serviceBindingModel.RuDescription, serviceBindingModel.BgDescription),
                Price = serviceBindingModel.Price,
                Multimedia = multimedia
            };

            this.Data.Services.Add(service);

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Edit(int id, string returnUrl)
        {
            var currentService = this.Data.Services.Find(id);
            if (currentService == null)
            {
                return Redirect(returnUrl);
            }

            var nameLocs = JsonHelper.Deserialize(currentService.Name);
            var descriptionLocs = JsonHelper.Deserialize(currentService.Description);

            var editService = new ServiceBindingModel()
            {
                EnName = nameLocs[0].v,
                RuName = nameLocs[1].v,
                BgName = nameLocs[2].v,
                EnDescription = descriptionLocs[0].v,
                RuDescription = descriptionLocs[1].v,
                BgDescription = descriptionLocs[2].v,
                Price = currentService.Price
            };

            if (currentService.Multimedia != null)
            {
                editService.Url = currentService.Multimedia.Url;
            }

            return View(editService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string returnUrl, ServiceBindingModel serviceBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentService = this.Data.Services.Find(id);
            if (currentService == null)
            {
                return this.View();
            }

            if (serviceBindingModel.Multimedia != null)
            {
                if (currentService.Multimedia != null)
                {
                    MultimediaHelper.DeleteSingle(this.Server, currentService.Multimedia);
                    this.Data.Multimedia.Delete(currentService.Multimedia);
                }

                currentService.Multimedia = MultimediaHelper.CreateSingle(this.Server, serviceBindingModel.Multimedia, this.GetBaseUrl());
            }

            currentService.Name = JsonHelper.Serialize(serviceBindingModel.EnName, serviceBindingModel.RuName, serviceBindingModel.BgName);
            currentService.Description = JsonHelper.Serialize(serviceBindingModel.EnDescription, serviceBindingModel.RuDescription, serviceBindingModel.BgDescription);
            currentService.Price = serviceBindingModel.Price;

            this.Data.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult Delete(int id, string returnUrl)
        {
            var deleteService = this.Data.Services.GetAll().ProjectTo<ServiceViewModel>()
                                                           .FirstOrDefault(s => s.Id == id)
                                                           .Localize(this.CurrentCulture, s => s.Name, s => s.Description);
            if (deleteService == null)
            {
                return Redirect(returnUrl);
            }

            return View(deleteService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string returnUrl, ServiceViewModel serviceViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentService = this.Data.Services.Find(id);
            if (currentService == null)
            {
                return this.View();
            }

            if (currentService.Multimedia != null)
            {
                MultimediaHelper.DeleteSingle(this.Server, currentService.Multimedia);
                this.Data.Multimedia.Delete(currentService.Multimedia);
            }

            this.Data.Services.Delete(currentService);
            this.Data.SaveChanges();

            this.RePosition();

            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Up(int id, string returnUrl)
        {
            var up = this.Data.Services.Find(id);
            if (up != null)
            {
                var down = this.Data.Services.GetAll().FirstOrDefault(p => p.Position == up.Position - 1);
                if (down != null)
                {
                    int temp = up.Position;
                    up.Position = down.Position;
                    down.Position = temp;

                    this.Data.SaveChanges();
                }
            }

            return this.Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Down(int id, string returnUrl)
        {
            var down = this.Data.Services.Find(id);
            if (down != null)
            {
                var up = this.Data.Services.GetAll().FirstOrDefault(p => p.Position == down.Position + 1);
                if (up != null)
                {
                    int temp = up.Position;
                    up.Position = down.Position;
                    down.Position = temp;

                    this.Data.SaveChanges();
                }
            }

            return this.Redirect(returnUrl);
        }

        private void RePosition()
        {
            var services = this.Data.Services.GetAll().OrderBy(a => a.Position).ToList();

            for (int i = 0; i < services.Count; i++)
            {
                services[i].Position = i + 1;
            }

            this.Data.SaveChanges();
        }
    }
}
