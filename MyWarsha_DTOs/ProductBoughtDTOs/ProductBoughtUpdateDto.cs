using System.ComponentModel.DataAnnotations;

namespace MyWarsha_DTOs.ProductBoughtDTOs
{
    public class ProductBoughtUpdateDto
    {
        [Range(0, double.MaxValue)]
        public decimal? PricePerUnit { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Discount { get; set; }

        [Range(1, int.MaxValue)]
        public bool? IsReturned { get; set; }
        public string? Note { get; set; }
    }
}