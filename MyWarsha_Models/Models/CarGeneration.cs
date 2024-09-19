using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyWarsha_DTOs.CarGenerationDtos;

namespace MyWarsha_Models.Models
{
    public class CarGeneration
    {
        public int Id { get; set; }   
       
        [Required]
        public string Name { get; set; } = null!;
        public string? Notes { get; set; }

        [ForeignKey("CarModelId")]
        public CarModel CarModel { get; set; } = null!;
        public int CarModelId { get; set; }

        public static CarGenerationDto ToDto(CarGeneration carGeneration)
        {
            return new CarGenerationDto
            {
                Id = carGeneration.Id,
                Name = carGeneration.Name,
                Notes = carGeneration.Notes,
            };
        }
    }
}