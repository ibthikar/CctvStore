using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CctvStore.Models; 

namespace CctvStore.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}