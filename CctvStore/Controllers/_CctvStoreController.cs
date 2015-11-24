using CctvStore.Models;
using CctvStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace CctvStore.Controllers
{
    public class _CctvStoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CctvStore
        [ChildActionOnly]
        public ActionResult SubCategoryMenu()
        {
            var subcategories = db.SubCategories.ToList();
            return PartialView(subcategories);
        }

        //Product Listing Pages
      
        public ActionResult ProductIndex(string SearchCatalog, string SearchCategories)
        {
  

            //var products = db.Products.Include(p => p.SubCategory);
            if (SearchCategories != null)
            {
                var products = db.Products.Where(x => x.Category.CategoryName.Contains(SearchCategories));
                return View(products.ToList());
            }

            else
            {
                var products = db.Products.Include(p => p.SubCategory);
                return View(products.ToList());
            }
            //return View(products.ToList());
        }
        public ActionResult ProductDetails(int ProductID)
        {
            ViewBag.SpecificationDetails = db.Specifications
                    .Include(s => s.Product).Include(s => s.SpAudio)
                    .Include(s => s.SpCamera).Include(s => s.SpGeneral)
                    .Include(s => s.SpHardDisk).Include(s => s.SpImage)
                    .Include(s => s.SpInterface).Include(s => s.SpNetwork)
                    .Include(s => s.SpRecordPlayback).Include(s => s.SpVideo)
                    .Include(s => s.SpVideoAudioInput).Include(s => s.SpVideoAudioOutput)
                    .Where(e => e.ProductId == ProductID).OrderBy(v => v.Product.ProductName);


            Product ProductDetails = db.Products.Find(ProductID);
         
            if (ProductDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = ProductDetails.ProductId;
            return View(ProductDetails);


        }
        public ActionResult ProductSpecifications(int ProductID)
        {
             var Specifications = db.Specifications
                    .Include(s => s.Product).Include(s => s.SpAudio)
                    .Include(s => s.SpCamera).Include(s => s.SpGeneral)
                    .Include(s => s.SpHardDisk).Include(s => s.SpImage)
                    .Include(s => s.SpInterface).Include(s => s.SpNetwork)
                    .Include(s => s.SpRecordPlayback).Include(s => s.SpVideo)
                    .Include(s => s.SpVideoAudioInput).Include(s => s.SpVideoAudioOutput)
                    .Where(e => e.ProductId == ProductID).OrderBy(v => v.Product.ProductName);


            //Product ProductDetails = db.Products.Find(ProductID);

            //if (ProductDetails == null)
            //{
            //    return HttpNotFound();
            //}
            return View(Specifications);


        }
        public ActionResult ProductDownloads(int ProductID)
        {

            var productDownloads = db.ProductDownloads.Where(p => p.ProductId.ToString().Contains(ProductID.ToString()));
            return View(productDownloads);


        }
        public ActionResult ProductAccessories(int ProductID)
        {

            var accessories = db.Accessories.Where(a => a.ProductId.ToString().Contains(ProductID.ToString()));
            return View(accessories.ToList());


        }
        //Specification Page
        public ActionResult SpecificationIndex(int ids)
        {                            
                var specifications = db.Specifications
                    .Include(s => s.Product).Include(s => s.SpAudio)
                    .Include(s => s.SpCamera).Include(s => s.SpGeneral)
                    .Include(s => s.SpHardDisk).Include(s => s.SpImage)
                    .Include(s => s.SpInterface).Include(s => s.SpNetwork)                    
                    .Include(s => s.SpRecordPlayback).Include(s => s.SpVideo)
                    .Include(s => s.SpVideoAudioInput).Include(s => s.SpVideoAudioOutput)
                    .Where(e=>e.ProductId == ids).OrderBy(v => v.Product.ProductName);                       
            return View(specifications);
        }

        // GET: Accessories
        public ActionResult AccessoriesIndex(int idd)
        {
            var accessories = db.Accessories.Include(a => a.Product)
                .Where(r=>r.ProductId == idd).OrderBy(n=>n.Title);
            return View(accessories.ToList());
        }

        public ActionResult ProductList(string Categoriesstring, string SubCategoriesstring, string ProductString)
        {
            var viewmodel = new CatalogCategoryVM();
            var catalog = db.Catalogs.ToList();
            var category = db.Categories.ToList();
            var subcategory = db.SubCategories.ToList();                
            var product = db.Products.ToList();
            viewmodel.Catalogs = catalog;
            viewmodel.Category = category;
            viewmodel.SubCategory = subcategory;
            viewmodel.Product = product;

            if (Categoriesstring != null)
            {
                ViewBag.category = Categoriesstring;
                viewmodel.Category = viewmodel.Catalogs.Where(e => e.CatalogName == Categoriesstring).SingleOrDefault().Categories;
            }

            if (SubCategoriesstring != null)
            {
                ViewBag.subcategory = SubCategoriesstring;
                viewmodel.SubCategory = viewmodel.Category.Where(r => r.CategoryName == SubCategoriesstring).Single().SubCategories;
              
            }

            if(ProductString != null)
            {
                ViewBag.Product = ProductString;
                viewmodel.Product = viewmodel.SubCategory.Where(d => d.SubCategoryName == ProductString).SingleOrDefault().Products;
            }

            return View(viewmodel);
        }

       
       
    }
}