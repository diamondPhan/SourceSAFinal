namespace Sa_finalproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_SanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_HoaDon { get; set; }

        public int? SoLuongMua { get; set; }

        public int? TongTien { get; set; }

        public int? ID_SPCTHD { get; set; }

        [StringLength(50)]
        public string Name_CT { get; set; }

        public int? Giaban { get; set; }
    }
}
