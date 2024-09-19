using System.ComponentModel.DataAnnotations;

namespace MyWarsha_Models.Models
{
    public class RelevantDataToTheBought
    {
        public int Id { get; set; }

        [Required]
        public string ShopName { get; set; } = null!;
   
        [Required]
        public DateTime DateOfOrder { get; set; }

        public List<ProductBought> ProductsBought { get; set; } = [];
    }
}