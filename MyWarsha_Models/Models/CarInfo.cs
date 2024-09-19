using System.ComponentModel.DataAnnotations.Schema;
using MyWarsha_DTOs.CarInfoDTOs;

namespace MyWarsha_Models.Models
{
    public class CarInfo
    {
        public int Id { get; set; }

        [ForeignKey("CarMakerId")]
        public CarMaker CarMaker { get; set; } = null!;
        public int CarMakerId { get; set; }

        [ForeignKey("CarModelId")]        
        public CarModel CarModel { get; set; }  = null!;
        public int CarModelId { get; set; }
        
        [ForeignKey("CarGenerationId")]
        public CarGeneration CarGeneration { get; set; } = null!;
        public int CarGenerationId { get; set; }

        public List<Product> Products { get; set; } = [];

        public static CarInfoDto ToDto(CarInfo carInfo)
        {
            return new CarInfoDto
            {
                Id = carInfo.Id,
                CarMaker = CarMaker.ToDto(carInfo.CarMaker),
                CarModel = CarModel.ToDto(carInfo.CarModel),
                CarGeneration = CarGeneration.ToDto(carInfo.CarGeneration)
            };
        }
    }
}