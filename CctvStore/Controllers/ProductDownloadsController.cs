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
    public class ProductDownloadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductDownloads
        public ActionResult Index(int? ProductId)
        {
            ViewBag.PID = ProductId;
            var productDownloads = db.ProductDownloads.Where(p => p.ProductId.ToString().Contains(ProductId.ToString()));
            return View(productDownloads);
        }
      
        // GET: ProductDownloads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDownloads productDownloads = db.ProductDownloads.Find(id);
            if (productDownloads == null)
            {
                return HttpNotFound();
            }
            return View(productDownloads);
        }

        // GET: ProductDownloads/Create
        public ActionResult Create(int ProductId)
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Model");
            return View();
        }

        // POST: ProductDownloads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileName,FileUrl,ProductId")] ProductDownloads productDownloads, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string filename = RenameUploadFile(upload);
                    upload.SaveAs(Server.MapPath("~/Content/Products/PDF/" + filename));
                    productDownloads.FileUrl = filename;
                }
                catch
                {
                    ViewBag.msg = "Error while uploading the files.";
                }
                db.ProductDownloads.Add(productDownloads);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "productDownloads", new { @ProductId = productDownloads.ProductId });
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Model", productDownloads.ProductId);
            return View(productDownloads);
        }


        //Rename File name
        public string RenameUploadFile(HttpPostedFileBase file, Int32 counter = 0)
        {
            var fileName = Path.GetFileName(file.FileName);

            string prepend = "BostonUs_";
            string finalFileName = prepend + ((counter).ToString()) + "_" + fileName;
            if (System.IO.File.Exists
                (HttpContext.Request.MapPath("~/Content/Products/PDF/" + finalFileName)))
            {
                //file exists => add country try again
                return RenameUploadFile(file, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return finalFileName;
        }
        // GET: ProductDownloads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDownloads productDownloads = db.ProductDownloads.Find(id);
            if (productDownloads == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Model", productDownloads.ProductId);
            return View(productDownloads);
        }

        // POST: ProductDownloads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductDownloadId,FileName,FileUrl,ProductId")] ProductDownloads productDownloads)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDownloads).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Model", productDownloads.ProductId);
            return View(productDownloads);
        }

        // GET: ProductDownloads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDownloads productDownloads = db.ProductDownloads.Find(id);
            if (productDownloads == null)
            {
                return HttpNotFound();
            }
            return View(productDownloads);
        }

        // POST: ProductDownloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDownloads productDownloads = db.ProductDownloads.Find(id);
            db.ProductDownloads.Remove(productDownloads);
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
