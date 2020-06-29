using productSOAP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace productSOAP
{
    /// <summary>
    /// Summary description for CategoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategoryService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Category> GetAll()
        {
            List<Category> categories = new CategoryDAO().SelectAll();
            return categories;
        }
        [WebMethod]
        public List<Category> Search(String keyword)
        {
            List<Category> Categoriess = new CategoryDAO().SelectByName(keyword);
            return Categoriess;
        }
        [WebMethod]
        public bool AddNew(Category c)
        {
            bool result = new CategoryDAO().Insert(c);
            return result;
        }
        [WebMethod]
        public bool Update(Category c)
        {
            bool result = new CategoryDAO().Update(c);
            return result;
        }
        [WebMethod]
        public Category GetByID(int id)
        {
            Category c = new CategoryDAO().SelectByID(id);
            return c;
        }
        [WebMethod]
        public Category DeleteByID(int id)
        {
            Category c = new CategoryDAO().Delete(id);
            return c;
        }
    }
}
