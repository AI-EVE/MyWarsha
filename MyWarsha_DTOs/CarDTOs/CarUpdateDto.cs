using System.ComponentModel.DataAnnotations;

namespace MyWarsha_DTOs.CarDTOs
{
    public class CarUpdateDto
    {
        [Required]
        public int Id { get; set; }
        public string? Color { get; set; }
        public string? PlateNumber { get; set; } = null!;
        public string? ChassisNumber { get; set; }
        public string? MotorNumber { get; set; }
        public string? Notes { get; set; }
    }
}