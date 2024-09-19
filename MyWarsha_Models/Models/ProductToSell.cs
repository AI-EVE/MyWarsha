using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWarsha_Models.Models
{
    public class ProductToSell
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal SoldFor { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        public int Count { get; set; }

        [ForeignKey("ProductName")]
        public Product Product { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;
        public int ServiceId { get; set; }
    }
}