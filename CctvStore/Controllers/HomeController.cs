using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CctvStore.Models;
using System.Net;

namespace CctvStore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
           

            return View();
        }
        public ActionResult Press()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ListCatProd()
        {
            var Listcatalog = db.Catalogs.ToList();
            var ListCatagory = db.Categories.ToList();
            var ListSubCatagory = db.SubCategories.ToList();
            ViewBag.Listcatalog = Listcatalog;
            ViewBag.ListCatagory = ListCatagory;
            ViewBag.ListSubCatagory = ListSubCatagory;
            ViewBag.Title = "Home Page";
            return PartialView();
        }
        public ActionResult About()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult ContactUs()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        public ActionResult OnlineSupport(string searchString)
        {
            if (searchString == "CompatibilityTab")
            {
                ViewBag.DownloadType = "Compatibility Tab";
                ViewBag.Title = "Download Compatibility Tab";

                return View(db.Support.Where(x => x.FileType.ToString().Equals("5")).ToList());
            }
           else if (searchString == "Firmware")
            {
                ViewBag.DownloadType = "Firmware";
                ViewBag.Title = "Download Firmware";

                return View(db.Support.Where(x => x.FileType.ToString().Equals("2")).ToList());
            }
            else if (searchString == "SDKandTool")
            {
                ViewBag.DownloadType = "SDK & Tool";
                ViewBag.Title = "Download SDK & Tool";

                return View(db.Support.Where(x => x.FileType.ToString().Equals("3")).ToList());
            }
            else if (searchString == "FAQDocument")
            {
                ViewBag.DownloadType = " FAQ Document";
                ViewBag.Title = "Download FAQ Document";

                return View(db.Support.Where(x => x.FileType.ToString().Equals("4")).ToList());
            }
            else
            {
                ViewBag.Title = "Download Software";
                ViewBag.DownloadType = "Software";
                return View(db.Support.Where(x => x.FileType.ToString().Equals("1")).ToList());
            }

          
        }

        public ActionResult FAQList()
        {
            ViewBag.Title = "FAQ";
            return View(db.FAQ.ToList());
            //return View();
        }

        // GET: FAQs/Details/5
        public ActionResult FAQDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQ fAQ = db.FAQ.Find(id);
            if (fAQ == null)
            {
                return HttpNotFound();
            }
            return View(fAQ);
        }
        public ActionResult Admin()
        {
            ViewBag.Title = "Admin Page";

            return View();
        }
        public ActionResult HomeSpecification()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Server.MapPath("~/images" + file.FileName);
                file.SaveAs(path);
                ViewBag.path = path;
            }
            else
            {
                ViewBag.path = "NO file recieved";
            }
            return View();
        }
    }
}
