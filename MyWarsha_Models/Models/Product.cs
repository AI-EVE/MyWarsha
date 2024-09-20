using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWarsha_Models.Models
{
    public class Product
    {
        [Key]
        public string Name { get; set; } = null!;
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        public int CategoryId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; } = null!;
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrand { get; set; } = null!;
        public DateOnly DateAdded { get; set; }
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