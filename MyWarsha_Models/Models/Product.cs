using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWarsha_Models.Models
{
    public class Product
    {
        [Key]
        public string Name { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Brand{ get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public string Description { get; set; } = null!;
        public int UnitsSold { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal ListPrice { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public List<CarInfo> CarInfos { get; set; } = [];
        public List<ProductImage> ProductImages { get; set; } = [];
    }
}