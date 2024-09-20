using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWarsha_Models.Models
{
    public class ProductBought
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal BoughtFor { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        public int Count { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        [ForeignKey("RelevantDataToTheBoughtId")]
        public RelevantDataToTheBought RelevantDataToTheBought { get; set; } = null!;
        public int RelevantDataToTheBoughtId { get; set; }
    }
}