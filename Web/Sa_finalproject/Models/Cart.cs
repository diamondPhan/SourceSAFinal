using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sa_finalproject.Models
{
    public class Cart
    {
        
            public string Hinh { get; set; }
            public int SanPhamID { get; set; }
            public string TenSanPham { get; set; }
            public int DonGia { get; set; }
            public int SoLuong { get; set; }
            public int ThanhTien { get { return SoLuong * DonGia; } }
            //public int countItem()
            //{
            //    int count = 0;
            //    count = SanPhamID;
            //    return count;
            //}
        
    }
}