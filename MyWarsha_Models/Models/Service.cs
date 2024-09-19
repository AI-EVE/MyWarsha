using System.ComponentModel.DataAnnotations.Schema;

namespace MyWarsha_Models.Models
{
    public class Service
    {
        public int Id { get; set; }

        DateTime Date { get; set; } = DateTime.Now;

        [ForeignKey("ClientId")]
        public Client Client { get; set; } = null!;
        public int ClientId { get; set; }

        [ForeignKey("CarId")]
        public Car Car { get; set; } = null!;
        public int CarId { get; set; }

        public List<ProductToSell> ProductsToSell { get; set; } = [];

        public List<ServiceFee> ServiceFees { get; set; } = [];
    }
}