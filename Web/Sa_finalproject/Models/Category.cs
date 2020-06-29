namespace Sa_finalproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int ID_LoaiSanPham { get; set; }

        [StringLength(50)]
        public string TenLoaiSanPham { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }
    }
}
