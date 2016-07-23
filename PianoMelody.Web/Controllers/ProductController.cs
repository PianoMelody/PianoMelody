using AutoMapper.QueryableExtensions;
using OrangeJetpack.Localization;
using PianoMelody.Models;
using PianoMelody.Web.Models.BindingModels;
using PianoMelody.Web.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;
using PianoMelody.Web.Helpers;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using PianoMelody.Helpers;

namespace PianoMelody.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Index(int? group, int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index");
            }

            var model = new ProductsWithPager();
            IEnumerable<ProductViewModel> products = null;

            if (group != null)
            {
                var pager = new Pager(this.Data.Products.GetAll().Where(a => a.ArtilceGroup.Id == group).Count(), page);
                model.Pager = pager;

                products = this.Data.Products.GetAll()
                                             .Where(a => a.ArtilceGroup.Id == group)
                                             .OrderBy(a => a.Position)
                                             .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                             .Take(pager.PageSize)
                                             .ProjectTo<ProductViewModel>()
                                             .Localize(this.CurrentCulture, a => a.Name, a => a.Description, a => a.ArticleGroupName, a => a.ManufacturerName);
            }
            else
            {
                var pager = new Pager(this.Data.Products.GetAll().Count(), page);
                model.Pager = pager;

                products = this.Data.Products.GetAll()
                                             .OrderBy(a => a.Position)
                                             .Skip((pager.CurrentPage - 1) * pager.PageSize)
                                             .Take(pager.PageSize)
                                             .ProjectTo<ProductViewModel>()
                                             .Localize(this.CurrentCulture, a => a.Name, a => a.Description, a => a.ArticleGroupName, a => a.ManufacturerName);
            }

            model.Products = products;

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var articleGroups = this.Data.ArticleGroups.GetAll().ProjectTo<ArticleGroupViewModel>()
                                                                .Localize(this.CurrentCulture, ag => ag.Name);

            return this.View(articleGroups);
        }

        public ActionResult Create()
        {
            this.LoadDropdownLists();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductBindingModel productBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.LoadDropdownLists();
                    return this.View();
                }

                var product = new Product()
                {
                    Position = this.Data.Products.GetAll().Count() + 1,
                    Name = JsonHelper.Serialize(productBindingModel.EnName, productBindingModel.RuName, productBindingModel.BgName),
                    Description = JsonHelper.Serialize(productBindingModel.EnDescription, productBindingModel.RuDescription, productBindingModel.BgDescription),
                    Price = productBindingModel.Price,
                    IsNew = productBindingModel.IsNew,
                    ArticleGroupId = productBindingModel.ArticleGroupId,
                    ManufacturerId = productBindingModel.ManufacturerId
                };

                this.Data.Products.Add(product);

                var multimedias = MultimediaHelper.CreateMultiple(this.Server, productBindingModel.Multimedias, this.GetBaseUrl());
                foreach (var multimedia in multimedias)
                {
                    multimedia.ProductId = product.Id;
                    this.Data.Multimedia.Add(multimedia);
                }

                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.LoadDropdownLists();
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var currentProduct = this.Data.Products.Find(id);
            if (currentProduct == null)
            {
                return this.RedirectToAction("Index");
            }

            var nameLocs = JsonHelper.Deserialize(currentProduct.Name);
            var descriptionLocs = JsonHelper.Deserialize(currentProduct.Description);

            var editProduct = new ProductBindingModel()
            {
                EnName = nameLocs[0].v,
                RuName = nameLocs[1].v,
                BgName = nameLocs[2].v,
                EnDescription = descriptionLocs[0].v,
                RuDescription = descriptionLocs[1].v,
                BgDescription = descriptionLocs[2].v,
                Price = currentProduct.Price,
                IsNew = currentProduct.IsNew,
                ArticleGroupId = currentProduct.ArticleGroupId,
                ManufacturerId = currentProduct.ManufacturerId,
            };

            this.LoadDropdownLists();
            return View(editProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductBindingModel productBindingModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.LoadDropdownLists();
                    return this.View();
                }

                var currentProduct = this.Data.Products.Find(id);
                if (currentProduct == null)
                {
                    this.LoadDropdownLists();
                    return this.View();
                }

                currentProduct.Name = JsonHelper.Serialize(productBindingModel.EnName, productBindingModel.RuName, productBindingModel.BgName);
                currentProduct.Description = JsonHelper.Serialize(productBindingModel.EnDescription, productBindingModel.RuDescription, productBindingModel.BgDescription);
                currentProduct.Price = productBindingModel.Price;
                currentProduct.IsNew = productBindingModel.IsNew;
                currentProduct.ArticleGroupId = productBindingModel.ArticleGroupId;
                currentProduct.ManufacturerId = productBindingModel.ManufacturerId;

                if (productBindingModel.Multimedias != null && productBindingModel.Multimedias.ElementAt(0) != null)
                {
                    // Delete old multimedias if any
                    if (currentProduct.Multimedias.Count > 0)
                    {
                        MultimediaHelper.DeleteMultiple(this.Server, currentProduct.Multimedias);
                        foreach (var multimedia in currentProduct.Multimedias.ToList())
                        {
                            this.Data.Multimedia.Delete(multimedia);
                        }
                    }

                    // Create new multimedias
                    var multimedias = MultimediaHelper.CreateMultiple(this.Server, productBindingModel.Multimedias, this.GetBaseUrl());
                    foreach (var multimedia in multimedias)
                    {
                        multimedia.ProductId = currentProduct.Id;
                        this.Data.Multimedia.Add(multimedia);
                    }
                }

                this.Data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.LoadDropdownLists();
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var deleteProduct = this.Data.Products.GetAll().ProjectTo<ProductViewModel>()
                                                           .FirstOrDefault(s => s.Id == id)
                                                           .Localize(this.CurrentCulture, s => s.Name, s => s.Description);
            if (deleteProduct == null)
            {
                return this.RedirectToAction("Index");
            }

            return View(deleteProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductViewModel productViewModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var currentProduct = this.Data.Products.Find(id);
                if (currentProduct == null)
                {
                    return this.View();
                }

                if (currentProduct.Multimedias.Count > 0)
                {
                    MultimediaHelper.DeleteMultiple(this.Server, currentProduct.Multimedias);
                    foreach (var multimadia in currentProduct.Multimedias.ToList())
                    {
                        this.Data.Multimedia.Delete(multimadia);
                    }
                }

                this.Data.Products.Delete(currentProduct);
                this.Data.SaveChanges();

                this.RePositionProducts();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Up(int id)
        {
            var upProduct = this.Data.Products.Find(id);
            if (upProduct != null)
            {
                var downProduct = this.Data.Products.GetAll().FirstOrDefault(p => p.Position == upProduct.Position - 1);
                if (downProduct != null)
                {
                    int temp = upProduct.Position;
                    upProduct.Position = downProduct.Position;
                    downProduct.Position = temp;

                    this.Data.SaveChanges();
                }
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Down(int id)
        {
            var downProduct = this.Data.Products.Find(id);
            if (downProduct != null)
            {
                var upProduct = this.Data.Products.GetAll().FirstOrDefault(p => p.Position == downProduct.Position + 1);
                if (upProduct != null)
                {
                    int temp = upProduct.Position;
                    upProduct.Position = downProduct.Position;
                    downProduct.Position = temp;

                    this.Data.SaveChanges();
                }
            }

            return this.RedirectToAction("Index");
        }

        private void RePositionProducts()
        {
            var products = this.Data.Products.GetAll().OrderBy(a => a.Position).ToList();

            for (int i = 0; i < products.Count; i++)
            {
                products[i].Position = i + 1;
            }

            this.Data.SaveChanges();
        }

        /// <summary>
        /// Load ArticleGroups and Manufacturers for dropdown lists
        /// </summary>
        private void LoadDropdownLists()
        {
            ViewBag.ArticleGroups = this.Data.ArticleGroups.GetAll()
                                                           .ProjectTo<ArticleGroupViewModel>()
                                                           .Localize(this.CurrentCulture, ag => ag.Name)
                                                           .Select(ag => new SelectListItem
                                                           {
                                                               Text = ag.Name,
                                                               Value = ag.Id.ToString()
                                                           })
                                                           .ToList();

            ViewBag.Manufacturers = this.Data.Manufacturers.GetAll()
                                                           .ProjectTo<ManufacturerViewModel>()
                                                           .Localize(this.CurrentCulture, m => m.Name)
                                                           .Select(m => new SelectListItem
                                                           {
                                                               Text = m.Name,
                                                               Value = m.Id.ToString()
                                                           })
                                                           .ToList();
        }
    }
}
