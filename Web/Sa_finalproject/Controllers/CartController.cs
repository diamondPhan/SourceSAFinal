using Sa_finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sa_finalproject.Controllers
{
    public class CartController : Controller
    {

        Model1 db = new Model1();
        public const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var giohang = Session[CartSession];
            var listgh = new List<Cart>();

            if (giohang != null)
            {
                listgh = (List<Cart>)giohang;
            }


            return View(listgh);
        }
        public ActionResult AddtoCart(int SPID)
        {

            if (Session[CartSession] == null)
            {
                Session[CartSession] = new List<Cart>();

            }
            List<Cart> listgh = Session[CartSession] as List<Cart>;
            if (listgh.Exists(m => m.SanPhamID == SPID)) // ko co sp nay trong gio hang
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                Cart card = listgh.FirstOrDefault(m => m.SanPhamID == SPID);
                card.SoLuong++;


            }
            else
            {
                Product pro = db.Products.Find(SPID);  // tim sp theo sanPhamID

                Cart newItem = new Cart()
                {
                    SanPhamID = SPID,
                    TenSanPham = pro.ProductName,
                    SoLuong = 1,
                    Hinh = pro.Imange,
                    DonGia = pro.Price

                };  // Tạo ra 1 CartItem mới

                listgh.Add(newItem);  // Thêm CartItem vào giỏ 
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("Index", "Cart", new { proid = SPID });
        }
        public ActionResult Deleted(int SPID)
        {
            List<Cart> giohang = Session[CartSession] as List<Cart>;
            Cart itemXoa = giohang.FirstOrDefault(m => m.SanPhamID == SPID);
            if (itemXoa != null)
                giohang.Remove(itemXoa);
            {
            }
            return RedirectToAction("Index", "Cart");

        }

        public ActionResult Updated(int SPID, int Soluongmoi)
        {
            //int soluong = ["soluong"];
            List<Cart> giohang = Session[CartSession] as List<Cart>;
            Cart itemSua = giohang.FirstOrDefault(m => m.SanPhamID == SPID);
            if (itemSua != null)
            { itemSua.SoLuong = Soluongmoi; }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult HeaderCard()
        {
            var giohang = Session[CartSession];
            var listgh = new List<Cart>();
            if (giohang != null)
            {
                listgh = (List<Cart>)giohang;
            }
            return PartialView(listgh);
        }
        public ActionResult CheckOut()
        {
            var cart = Session[CartSession];
            var listCart = new List<Cart>();
            if (cart != null)
            {
                listCart = (List<Cart>)cart;
            }
            return View(listCart);
        }
        public ActionResult ProcessOrder(FormCollection frc)
        {

            List<Cart> listcart = (List<Cart>)Session[CartSession];
            HoaDon hoadon = new HoaDon()
            {
                TenKhachHang = frc["cusName"],
                DiaChiGiaoHang = frc["cusDiaChi"],
                Ngay = DateTime.Now.AddDays(7),
                TrangThai = "Processing...",
                ThanhPho = frc["cusThanhPho"],
                DatNuoc = frc["cusDatNuoc"],
                Email = frc["cusEmail"],
                Phone = frc["cusPhone"],

            };
            db.HoaDons.Add(hoadon);
            db.SaveChanges();

            foreach (Cart cart in listcart)
            {
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon()
                {
                    ID_HoaDon = hoadon.ID_HoaDon,
                    ID_SanPham = cart.SanPhamID,
                    SoLuongMua = cart.SoLuong,
                    Giaban = cart.DonGia,
                    TongTien = cart.ThanhTien,
                    Name_CT = cart.TenSanPham,

                };
                db.ChiTietHoaDons.Add(chiTietHoaDon);

                db.SaveChanges();
            }
            int IDHD = hoadon.ID_HoaDon;
            Session.Remove(CartSession);
            return RedirectToAction("SuccessOrder", "Cart", new { hdid = IDHD });
        }
        public ActionResult SuccessOrder(int hdid)
        {
            Model1 db = new Model1();
            HoaDon hd = db.HoaDons.Where(m => m.ID_HoaDon == hdid).SingleOrDefault();
            return View(hd);
        }
        [ChildActionOnly]
        public ActionResult listinvoice(int hdid)
        {
            //var giohang = Session[CartSession];
            //var listgh = new List<Cart>();
            //if (giohang != null)
            //{
            //    listgh = (List<Cart>)giohang;
            //}
            //List<Cart> listcart = (List<Cart>)Session[CartSession];
            //Cart listinvoice = listcart.FirstOrDefault(m => m.SanPhamID == hdid);
            Model1 db = new Model1();
            List<ChiTietHoaDon> cthd = (from p in db.ChiTietHoaDons where p.ID_HoaDon == hdid select p).ToList();
            return PartialView(cthd);
        }
    } 
}