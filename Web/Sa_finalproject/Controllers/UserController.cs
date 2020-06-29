using Sa_finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Sa_finalproject.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            try
            {
                Model1 db = new Model1();
                if (ModelState.IsValid == true)
                {
                    UserManager usermanager = new UserManager();
                    if (usermanager.checkUserName(user.UserName) == true && usermanager.checkEmail(user.Email) == true)
                    {
                        Customer user2 = new Customer();
                        user2.UserName = user.UserName;
                        user2.TenKhachHang = user.TenKhachHang;
                        user2.Password = user.Password;
                        user2.Email = user.Email;
                        user2.SDT = user.SoDienThoai;
                        user2.DiaChi = user.DiaChi;
                        // ma hoa password
                        SHA256 sha256 = new SHA256CryptoServiceProvider();
                        Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(user2.Password);
                        Byte[] encodedBytes = sha256.ComputeHash(originalBytes);
                        user2.Password = BitConverter.ToString(encodedBytes);
                        db.Customers.Add(user2);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Tai khoan hoac email da ton tai";
                    }

                    ViewBag.dangkythanhcong = "đã đăng ký thành công";
                }
            }
            catch (Exception ex)
            {

            }

            return View();

        }
        public ActionResult FailRegister()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            if (ModelState.IsValid)
            {
                string taikhoan = f["TxtTaikhoan"].ToString();
                string matkhau = f["TxtMatkhau"].ToString();
                Model1 db = new Model1();
                SHA256 sha = new SHA256CryptoServiceProvider();
                Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(matkhau);
                Byte[] encodedBytes = sha.ComputeHash(originalBytes);
                matkhau = BitConverter.ToString(encodedBytes);
                var username = db.Customers.Where(u => u.UserName == taikhoan).Select(u => u.UserName).SingleOrDefault();
                //Customer c = db.Customers.SingleOrDefault(x => x.UserName == taikhoan && x.Password == matkhau);
                UserManager userManager = new UserManager();
                if (userManager.checkLogin(taikhoan, matkhau) == true)
                {

                    Session["Logged"] = username;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.thongbao = "Tên tài khoản hoặc mật khẩu sai";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Logged"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}