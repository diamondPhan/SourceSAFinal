using productSOAP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace productSOAP
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Product> GetAll()
        {
            List<Product> Products = new ProductDAO().SelectAll();
            return Products;
        }
        [WebMethod]
        public List<Product> Search(String keyword)
        {
            List<Product> Products = new ProductDAO().SelectByName(keyword);
            return Products;
        }
        [WebMethod]
        public bool AddNew(Product c)
        {
            bool result = new ProductDAO().Insert(c);
            return result;
        }
        [WebMethod]
        public bool Update(Product c)
        {
            bool result = new ProductDAO().Update(c);
            return result;
        }
        [WebMethod]
        public Product GetByID(int id)
        {
            Product c = new ProductDAO().SelectByID(id);
            return c;
        }
        [WebMethod]
        public Product DeleteByID(int id)
        {
            Product c = new ProductDAO().Delete(id);
            return c;
        }
    }
}
