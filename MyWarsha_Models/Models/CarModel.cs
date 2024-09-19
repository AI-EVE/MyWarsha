using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyWarsha_DTOs.CarModelDTOs;

namespace MyWarsha_Models.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;
        
        public string? Notes { get; set; }

        [ForeignKey("CarMakerId")]
        public CarMaker CarMaker { get; set; } = null!;
        public int CarMakerId { get; set; }
   
        public List<CarGeneration> CarGenerations { get; set; } = [];

        public static CarModelDto ToDto(CarModel carModel)
        {
            return new CarModelDto
            {
                Id = carModel.Id,
                Name = carModel.Name,
                Notes = carModel.Notes,
            };
        }
    }
}