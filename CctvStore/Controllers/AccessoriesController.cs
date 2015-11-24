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
    public class AccessoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accessories
        public ActionResult Index(int? ProductId)
        {
            var accessories = db.Accessories.Where(a => a.ProductId.ToString().Contains(ProductId.ToString()));
            return View(accessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // GET: Accessories/Create
        public ActionResult Create(int? ProductId)
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessoriesId,Title,UrlImageAccessory,ProductId")] Accessories accessories, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string filename = RenameUploadFile(upload);
                    upload.SaveAs(Server.MapPath("~/Content/Products/PDF/" + filename));
                    accessories.UrlImageAccessory = filename;
                }
                catch
                {
                    ViewBag.msg = "Error while uploading the files.";
                }
                
                db.Accessories.Add(accessories);
                db.SaveChanges();
                return RedirectToAction("Index", "Accessories", new { @ProductId = accessories.ProductId });
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", accessories.ProductId);
            return View(accessories);
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
        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", accessories.ProductId);
            return View(accessories);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessoriesId,Title,UrlImageAccessory,ProductId")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", accessories.ProductId);
            return View(accessories);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessories accessories = db.Accessories.Find(id);
            db.Accessories.Remove(accessories);
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
