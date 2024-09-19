using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWarsha_Models.Models
{
    public class ServiceFee
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }

        public string? Notes { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; } = null!;
        public int ServiceId { get; set; }
    }
}