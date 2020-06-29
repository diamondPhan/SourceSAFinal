using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AccountSOAP
{
    /// <summary>
    /// Summary description for accountService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class accountService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public bool AddAcc(account user)
        {
            bool result = new AccountDAO().AddUser(user);
            return result;
        }
        [WebMethod]
        public bool Login(string username, string password)
        {
            bool result = new AccountDAO().Login(username, password);
            return result;
        }
    }
}
