namespace MyWarsha_DTOs.CarImageDTOs
{
    public class CarImageDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = null!;
        public bool IsMain { get; set; }
        public int CarId { get; set; }
    }
}