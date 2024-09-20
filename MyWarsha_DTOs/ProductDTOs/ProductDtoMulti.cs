using MyWarsha_DTOs.ProductImageDTOs;

namespace MyWarsha_DTOs.ProductDTOs
{
    public class ProductDtoMulti
    {
        public string Name { get; set; } = null!;
        public DateOnly DateAdded { get; set; }
        public string? Description { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public ProductImageDto MainProductImage { get; set; } = null!;
    }
}