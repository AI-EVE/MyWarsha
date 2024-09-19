namespace MyWarsha_DTOs.PhoneDTOs
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public int ClientId { get; set; }
    }
}