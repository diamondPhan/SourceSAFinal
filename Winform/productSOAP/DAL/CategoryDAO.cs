using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace productSOAP.DAL
{
    public class CategoryDAO
    {
        static String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        private MyDBDataContext db = new MyDBDataContext(strCon);
        public List<Category> SelectAll()
        {
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
        public Category SelectByID(int id)
        {
            Category category = db.Categories.SingleOrDefault(c => c.ID_LoaiSanPham == id);
            return category;
        }
        public List<Category> SelectByName(String keyword)
        {
            List<Category> categories = db.Categories.Where(c => c.TenLoaiSanPham.Contains(keyword)).ToList();
            return categories;
        }
        public bool Insert(Category newcategory)
        {
            try
            {
                db.Categories.InsertOnSubmit(newcategory);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(Category newcategory)
        {
            Category dbcatecogy = db.Categories.SingleOrDefault(c => c.ID_LoaiSanPham == newcategory.ID_LoaiSanPham);
            if (dbcatecogy != null)
            {
                try
                {
                    dbcatecogy.TenLoaiSanPham = newcategory.TenLoaiSanPham;
                    dbcatecogy.DonViTinh = newcategory.DonViTinh;
                 
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        public Category Delete(int id)
        {
            Category dbcatecogy = db.Categories.SingleOrDefault(c => c.ID_LoaiSanPham == id);
            if (dbcatecogy != null)
            {
                db.Categories.DeleteOnSubmit(dbcatecogy);
                db.SubmitChanges();
                return dbcatecogy;
            }
            return dbcatecogy;
        }
    }
}