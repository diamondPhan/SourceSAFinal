using Sa_finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sa_finalproject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ProductDetail(int proid)
        {
            Model1 db = new Model1();
            Product pro = db.Products.Where(p => p.ProductID == proid).SingleOrDefault();
            return View(pro);
        }
        [ChildActionOnly]
        public ActionResult Category()
        {
            Model1 db = new Model1();
            List<Category> catList = db.Categories.ToList();
            return PartialView(catList);
        }

        public ActionResult CatList(int danhMucID)
        {
            Model1 db = new Model1();
            List<Product> danhSachLoaiSanPham = (from p in db.Products where p.CategoryByID == danhMucID select p).ToList();
            return View(danhSachLoaiSanPham);
        }
        [ChildActionOnly]
        public ActionResult SaleProduct()
        {
            Model1 db = new Model1();
            List<Product> saleList = (from s in db.Products where s.Sale == 1 select s).ToList();
            return PartialView(saleList);

        }
    }
}