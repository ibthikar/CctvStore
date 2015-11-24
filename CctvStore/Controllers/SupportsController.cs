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
    public class SupportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Supports
        public ActionResult Index()
        {
            return View(db.Support.ToList());
        }

        // GET: Supports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Support.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // GET: Supports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DownloadId,Title,FileType,Description,UploadDate,DownloadUrl")] Support support, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    try
                    {
                        string filename = RenameUploadFile(upload);
                        upload.SaveAs(Server.MapPath("~/Content/Products/PDF/" + filename));
                        support.DownloadUrl = filename;
                    }
                    catch
                    {
                        ViewBag.msg = "Error while uploading the files.";
                    }
                }
                db.Support.Add(support);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(support);
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
        // GET: Supports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Support.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // POST: Supports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DownloadId,Title,FileType,Description,UploadDate,DownloadUrl")] Support support)
        {
            if (ModelState.IsValid)
            {
                db.Entry(support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(support);
        }

        // GET: Supports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Support.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // POST: Supports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Support support = db.Support.Find(id);
            db.Support.Remove(support);
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
