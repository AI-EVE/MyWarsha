using MyWarsha_DTOs.CarDTOs;
using MyWarsha_DTOs.PhoneDTOs;

namespace MyWarsha_DTOs.ClientDTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public List<PhoneDto> Phones { get; set; } = new List<PhoneDto>();
        public List<CarDto> Cars { get; set; } = new List<CarDto>();
    }
}