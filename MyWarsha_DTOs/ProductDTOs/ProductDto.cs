using MyWarsha_DTOs.CarInfoDTOs;
using MyWarsha_DTOs.CategoryDTOs;
using MyWarsha_DTOs.ProductBrandDTOs;
using MyWarsha_DTOs.ProductImageDTOs;
using MyWarsha_DTOs.ProductTypeDTOs;

namespace MyWarsha_DTOs.ProductDTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
        public ProductTypeDto ProductType { get; set; } = null!;
        public ProductBrandDto ProductBrand { get; set; } = null!;
        public DateOnly DateAdded { get; set; }
        public string Description { get; set; } = null!;
        public decimal ListPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public List<CarInfoDto> CarInfos { get; set; } = [];
        public List<ProductImageDto> ProductImages { get; set; } = [];
    }
}