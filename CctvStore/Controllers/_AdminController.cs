using CctvStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CctvStore.Controllers
{
    public class _AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: _Admin
        public ActionResult Admin()
        {
            ViewBag.Title = "Admin Page";

            return View();
        }

        public ActionResult HomeSpecification(string product)
        {
            if(product != null)
            {
                ViewBag.productid = product;
              
            }          
            return View();
        }

        public ActionResult ProductList()
        {
            var products = db.Products.Include(p => p.Catalog).Include(p => p.Category).Include(p => p.SubCategory);
            return View(products.ToList());
        }
         
    }
}