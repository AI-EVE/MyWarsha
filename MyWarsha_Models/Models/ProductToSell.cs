using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public bool IsReturned { get; set; } = false;
        
        public string? Note { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;
        public int ServiceId { get; set; }
    }
}