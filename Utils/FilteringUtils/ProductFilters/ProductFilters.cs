namespace Utils.FilteringUtils.ProductFilters
{
    public class ProductFilters
    {
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? ProductBrandId { get; set; }
        public bool? IsAvailable { get; set; }
    }
}