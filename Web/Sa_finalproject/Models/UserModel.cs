using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sa_finalproject.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password is not correct !")]
        public string ConfirmPassword { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }

        [RegularExpression(@"((09|03|05|07|08)+([0-9]{8}))", ErrorMessage = "Phone Number is invalid!")]
        public string SoDienThoai { get; set; }
        [EmailAddress(ErrorMessage = "Email is invalid")]

        public string Email { get; set; }
    }
}