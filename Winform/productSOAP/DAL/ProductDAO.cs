using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace productSOAP.DAL
{
    public class ProductDAO
    {
        static String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        private MyDBDataContext db = new MyDBDataContext(strCon);
        public List<Product> SelectAll()
        {
            List<Product> Products = db.Products.ToList();
            return Products;
        }
        public Product SelectByID(int id)
        {
            Product Product = db.Products.SingleOrDefault(c => c.ProductID == id);
            return Product;
        }
        public List<Product> SelectByName(String keyword)
        {
            List<Product> Products = db.Products.Where(c => c.ProductName.Contains(keyword)).ToList();
            return Products;
        }
        public bool Insert(Product newProduct)
        {
            try
            {
                db.Products.InsertOnSubmit(newProduct);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(Product newProduct)
        {
            Product dbProduct = db.Products.SingleOrDefault(c => c.ProductID == newProduct.ProductID);
            if (dbProduct != null)
            {
                try
                {
                    dbProduct.ProductName = newProduct.ProductName;
                    dbProduct.Detail = newProduct.Detail;
                    dbProduct.Imange = newProduct.Imange;
                    dbProduct.Price = newProduct.Price;
                    dbProduct.CategoryByID = newProduct.CategoryByID;
                    dbProduct.Quanlity = newProduct.Quanlity;
                    dbProduct.Sale = newProduct.Sale;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        public Product Delete(int id)
        {
            Product dbProduct = db.Products.SingleOrDefault(c => c.ProductID == id);
            if (dbProduct != null)
            {
                db.Products.DeleteOnSubmit(dbProduct);
                db.SubmitChanges();
                return dbProduct;
            }
            return dbProduct;
        }
    }
}