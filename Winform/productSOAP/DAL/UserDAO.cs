using productSOAP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace productSOAP.DAL
{
    public class UserDAO
    {
        static String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        private MyDBDataContext db = new MyDBDataContext(strCon);
        public List<Customer> SelectAll()
        {
            List<Customer> Customers = db.Customers.ToList();
            return Customers;
        }
        public Customer SelectByID(int id)
        {
            Customer Customer = db.Customers.SingleOrDefault(c => c.ID_KhachHang == id);
            return Customer;
        }
        public List<Customer> SelectByName(String keyword)
        {
            List<Customer> Customers = db.Customers.Where(c => c.UserName.Contains(keyword)).ToList();
            return Customers;
        }
        public bool Insert(Customer newCustomer)
        {
            try
            {
                db.Customers.InsertOnSubmit(newCustomer);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(Customer newCustomer)
        {
            Customer dbCustomer = db.Customers.SingleOrDefault(c => c.ID_KhachHang == newCustomer.ID_KhachHang);
            if (dbCustomer != null)
            {
                try
                {
                    dbCustomer.UserName = newCustomer.UserName;
                    dbCustomer.Password = newCustomer.Password;
                    dbCustomer.TenKhachHang = newCustomer.TenKhachHang;
                    dbCustomer.DiaChi = newCustomer.DiaChi;
                    dbCustomer.SDT = newCustomer.SDT;
                    dbCustomer.Email = newCustomer.Email;
                    db.SubmitChanges();
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        public Customer Delete(int id)
        {
            Customer dbCustomer = db.Customers.SingleOrDefault(c => c.ID_KhachHang == id);
            if (dbCustomer != null)
            {
                db.Customers.DeleteOnSubmit(dbCustomer);
                db.SubmitChanges();
                return dbCustomer;
            }
            return dbCustomer;
        }
    }
}