using CctvStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CctvStore.Controllers
{
    public class UploadController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult index()
        {
            var pic = db.Uploads.ToList();
            return View(pic);
        }

        // GET: Upload
        
        public ActionResult ProductImage(Upload img, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string path = HttpContext.Server.MapPath("~/Images" + file.FileName);
                    img.ImagePath = "Bos" + file.FileName;
                }
                db.Uploads.Add(img);
                db.SaveChanges();
                return RedirectToAction("Home", "Index");
            }
                    return View();
        }
    }
}