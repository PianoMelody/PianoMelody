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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufacturerBindingModel manufacturerBindingModel)
        {
            try
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
                    UrlAddress = manufacturerBindingModel.UrlAddress,
                    Multimedia = multimedia
                };

                this.Data.Manufacturers.Add(manufacturer);
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
            var currentManufacturer = this.Data.Manufacturers.Find(id);
            if (currentManufacturer == null)
            {
                return this.RedirectToAction("Index");
            }

            var nameLocs = JsonHelper.Deserialize(currentManufacturer.Name);

            var editManufacturer = new ManufacturerBindingModel()
            {
                EnName = nameLocs[0].v,
                RuName = nameLocs[1].v,
                BgName = nameLocs[2].v,
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
        public ActionResult Edit(int id, ManufacturerBindingModel manufacturerBindingModel)
        {
            try
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
                currentManufacturer.UrlAddress = manufacturerBindingModel.UrlAddress;

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
            var deleteManufacturer = this.Data.Manufacturers.GetAll().ProjectTo<ManufacturerViewModel>()
                                                                     .FirstOrDefault(m => m.Id == id)
                                                                     .Localize(this.CurrentCulture, m => m.Name);
            if (deleteManufacturer == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteManufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ManufacturerViewModel manufacturerViewModel)
        {
            try
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

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
