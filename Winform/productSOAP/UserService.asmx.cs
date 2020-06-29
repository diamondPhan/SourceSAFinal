using productSOAP;
using productSOAP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace productSOAP
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Customer> GetAll()
        {
            List<Customer> Customers = new UserDAO().SelectAll();
            return Customers;
        }
        [WebMethod]
        public List<Customer> Search(String keyword)
        {
            List<Customer> Customers = new UserDAO().SelectByName(keyword);
            return Customers;
        }
        [WebMethod]
        public bool AddNew(Customer c)
        {
            bool result = new UserDAO().Insert(c);
            return result;
        }
        [WebMethod]
        public bool Update(Customer c)
        {
            bool result = new UserDAO().Update(c);
            return result;
        }
        [WebMethod]
        public Customer GetByID(int id)
        {
            Customer c = new UserDAO().SelectByID(id);
            return c;
        }
        [WebMethod]
        public Customer DeleteByID(int id)
        {
            Customer c = new UserDAO().Delete(id);
            return c;
        }
    }
}
