using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Sa_finalproject.Models
{
    public class UserManager
    {
        public bool checkUserName(string username)
        {
            Model1 db = new Model1();
            List<Customer> user_finded = (from nd in db.Customers where nd.UserName == username select nd).ToList();
            if (user_finded.Count == 1)
            {
                return false;
            }
            else { return true; }
        }
        public bool checkEmail(string email)
        {
            Model1 db = new Model1();
            List<Customer> email_finded = (from em in db.Customers where em.Email == email select em).ToList();
            if (email_finded.Count >= 1)
            {
                return false;
            }
            else { return true; }
        }
        public bool checkLogin(string username, string password)
        {
            Model1 db = new Model1();

            SHA256 md5 = new SHA256CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes);

            List<Customer> login_finded = (from log in db.Customers where log.UserName == username && log.Password == password select log).ToList();
            if (login_finded.Count == 1)
            {
                return false;
            }
            else { return true; }
        }
    }
}