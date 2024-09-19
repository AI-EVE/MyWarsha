using System.ComponentModel.DataAnnotations;
using MyWarsha_DTOs.CarMakerDtos;

namespace MyWarsha_Models.Models
{
    public class CarMaker
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public List<CarModel> CarModels { get; set; } = [];
        public string? Notes { get; set; }
        public string? Logo { get; set; }

        public static CarMakerDto ToDto(CarMaker carMaker)
        {
            return new CarMakerDto
            {
                Id = carMaker.Id,
                Name = carMaker.Name,
                Notes = carMaker.Notes,
                Logo = carMaker.Logo
            };
        }
    }
}