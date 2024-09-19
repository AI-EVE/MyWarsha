using MyWarsha_DTOs.CarImageDTOs;
using MyWarsha_DTOs.CarInfoDTOs;

namespace MyWarsha_DTOs.CarDTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string? Color { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string? ChassisNumber { get; set; }
        public string? MotorNumber { get; set; }
        public string? Notes { get; set; }
        public List<CarImageDto>? CarImages { get; set; } = new List<CarImageDto>();
        public int ClientId { get; set; }
        public CarInfoDto CarInfo { get; set; } = null!;
    }
}