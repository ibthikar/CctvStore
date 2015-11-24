using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CctvStore.Models;
using System.IO;

namespace CctvStore.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Catalog).Include(p => p.Category).Include(p => p.SubCategory);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatalogId = new SelectList(db.Catalogs, "CatalogId", "CatalogName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Model,ProductName,Description,UrlProductImage,SubCategoryId,CategoryId,CatalogId")] Product product, HttpPostedFileBase upload)
        {
          
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    try
                    {     
                        string filename = RenameUploadFile(upload);                     
                        upload.SaveAs(Server.MapPath("~/Content/Products/Images/" + filename));
                        product.UrlProductImage = filename;
                    }
                    catch
                    {
                        ViewBag.msg = "Error while uploading the files.";
                    }
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatalogId = new SelectList(db.Catalogs, "CatalogId", "CatalogName", product.CatalogId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            return View(product);
        }


        //Rename File name
        public string RenameUploadFile(HttpPostedFileBase file, Int32 counter = 0)
        {
            var fileName = Path.GetFileName(file.FileName);

            string prepend = "BostonUs_";
            string finalFileName = prepend + ((counter).ToString()) + "_" + fileName;
            if (System.IO.File.Exists
                (HttpContext.Request.MapPath("~/Content/Products/Images/" + finalFileName)))
            {
                //file exists => add country try again
                return RenameUploadFile(file, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return finalFileName;
        }



        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatalogId = new SelectList(db.Catalogs, "CatalogId", "CatalogName", product.CatalogId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Model,ProductName,Description,UrlProductImage,SubCategoryId,CategoryId,CatalogId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatalogId = new SelectList(db.Catalogs, "CatalogId", "CatalogName", product.CatalogId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.SubCategoryId = new SelectList(db.SubCategories, "SubCategoryId", "SubCategoryName", product.SubCategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
