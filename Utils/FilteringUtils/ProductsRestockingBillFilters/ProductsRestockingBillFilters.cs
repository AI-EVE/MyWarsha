using System.Linq.Expressions;
using MyWarsha_Models.Models;

namespace Utils.FilteringUtils.ProductsRestockingBillFilters
{
    public class ProductsRestockingBillFilters
    {
        public string? ShopName { get; set; }
        public string? DateOfOrderFrom { get; set; }
        public string? DateOfOrderTo { get; set; }

        public Expression<Func<ProductsRestockingBill, bool>> ToExpression()
        {

            var IsDateOfOrderFromValid = DateOnly.TryParse(DateOfOrderFrom, out DateOnly dateOfOrderFrom);
            var IsDateOfOrderToValid = DateOnly.TryParse(DateOfOrderTo, out DateOnly dateOfOrderTo);

            return x =>
                (ShopName == null || x.ShopName.Contains(ShopName)) &&
                (!IsDateOfOrderFromValid || x.DateOfOrder >= dateOfOrderFrom) &&
                (!IsDateOfOrderToValid || x.DateOfOrder <= dateOfOrderTo);
            
        }
    }
}