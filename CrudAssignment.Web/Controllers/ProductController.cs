﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudAssignment.Entities.Models;
using CrudAssignment.Service;
using CrudAssignment.Web.Helpers;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace CrudAssignment.Web.Controllers
{
    [RequireHttps]
    [Authorize]
    [NoCache]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService, IUnitOfWorkAsync unitOfWork)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
            _unitOfWork = unitOfWork;
        }

        // GET: Product
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _productService.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.Queryable().ToList(), "Id", "Name");
            ViewBag.SupplierId = new SelectList(_supplierService.Queryable().ToList(), "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Price,DeliveryPeriod,CategoryId,SupplierId,MinimumStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Insert(product);
                await _unitOfWork.SaveChangesAsync();
                TempData.Add("AddedSuccessfully", true);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(await _categoryService.Queryable().ToListAsync(), "Id", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(await _supplierService.Queryable().ToListAsync(), "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _productService.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(await _categoryService.Queryable().ToListAsync(), "Id", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(await _supplierService.Queryable().ToListAsync(), "Id", "Name", product.SupplierId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Price,DeliveryPeriod,CategoryId,SupplierId,MinimumStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ObjectState = ObjectState.Modified;
                _productService.Update(product);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(await _categoryService.Queryable().ToListAsync(), "Id", "Name", product.CategoryId);
            ViewBag.SupplierId = new SelectList(await _supplierService.Queryable().ToListAsync(), "Id", "Name", product.SupplierId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _productService.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            _productService.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<ActionResult> ConfirmDelete(string ids)
        {
            var response = new List<object>();
            try
            {
                foreach (var id in ids.Split(','))
                {
                    var selectedProducts = await _productService.FindAsync(Convert.ToInt32(id));
                    response.Add(new { id = selectedProducts.Id, name = selectedProducts.Name });
                }
            }
            catch (Exception ex)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest), JsonRequestBehavior.AllowGet);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteProducts(string ids)
        {
            if (ids == null)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.BadRequest), JsonRequestBehavior.AllowGet);
            }
            try
            {
                foreach (var id in ids.Split(','))
                {
                    _productService.Delete(Convert.ToInt32(id));
                }
                await _unitOfWork.SaveChangesAsync();
                return Json(new HttpStatusCodeResult(HttpStatusCode.OK), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.ToString()), JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> GetProducts()
        {
            List<object> response = new List<object>();
            var products = await _productService.Queryable().Include(p => p.Category).Include(p => p.Supplier).ToListAsync();
            foreach (var product in products)
            {
                response.Add(new { id = product.Id, name = product.Name, category = product.Category.Name, price = product.Price, deliveryPeriod = product.DeliveryPeriod, minimumStock = product.MinimumStock, supplier = product.Supplier.Name});
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
