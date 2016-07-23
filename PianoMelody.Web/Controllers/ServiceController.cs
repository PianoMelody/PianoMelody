using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using System;
using PianoMelody.Web.Helpers;
using PianoMelody.Helpers;

namespace PianoMelody.Web.Controllers
{
    public class ServiceController : BaseController
    {
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
                                             .OrderBy(s => s.Id)
                                             .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                             .Take(pager.PageSize)
                                             .ProjectTo<ServiceViewModel>()
                                             .Localize(this.CurrentCulture, s => s.Name, s => s.Description);
            model.Services = services;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceBindingModel serviceBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var service = new Service()
                {
                    Name = JsonHelper.Serialize(serviceBindingModel.EnName, serviceBindingModel.RuName, serviceBindingModel.BgName),
                    Description = JsonHelper.Serialize(serviceBindingModel.EnDescription, serviceBindingModel.RuDescription, serviceBindingModel.BgDescription),
                    Price = serviceBindingModel.Price
                };

                this.Data.Services.Add(service);

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
            var currentService = this.Data.Services.Find(id);
            if (currentService == null)
            {
                return this.RedirectToAction("Index");
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

            return View(editService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceBindingModel serviceBindingModel)
        {
            try
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

                currentService.Name = JsonHelper.Serialize(serviceBindingModel.EnName, serviceBindingModel.RuName, serviceBindingModel.BgName);
                currentService.Description = JsonHelper.Serialize(serviceBindingModel.EnDescription, serviceBindingModel.RuDescription, serviceBindingModel.BgDescription);
                currentService.Price = serviceBindingModel.Price;

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
            var deleteService = this.Data.Services.GetAll().ProjectTo<ServiceViewModel>()
                                                           .FirstOrDefault(s => s.Id == id)
                                                           .Localize(this.CurrentCulture, s => s.Name, s => s.Description);
            if (deleteService == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServiceViewModel serviceViewModel)
        {
            try
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

                this.Data.Services.Delete(currentService);
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
