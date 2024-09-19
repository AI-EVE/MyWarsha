using MyWarsha_DTOs.CarGenerationDtos;
using MyWarsha_DTOs.CarMakerDtos;
using MyWarsha_DTOs.CarModelDTOs;

namespace MyWarsha_DTOs.CarInfoDTOs
{
    public class CarInfoDto
    {
        public int Id { get; set; }
        public CarMakerDto? CarMaker { get; set; }
        public CarModelDto? CarModel { get; set; }
        public CarGenerationDto? CarGeneration { get; set; }

    }
}