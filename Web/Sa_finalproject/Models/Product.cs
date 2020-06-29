namespace Sa_finalproject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int Price { get; set; }

        [StringLength(50)]
        public string Detail { get; set; }

        [StringLength(150)]
        public string Imange { get; set; }

        public int? CategoryByID { get; set; }

        public int? Quanlity { get; set; }

        public int? Sale { get; set; }
    }
}
