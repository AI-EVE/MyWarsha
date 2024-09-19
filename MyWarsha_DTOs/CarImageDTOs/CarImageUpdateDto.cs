using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MyWarsha_DTOs.CarImageDTOs
{
    public class CarImageUpdateDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public IFormFile Image { get; set; } = null!;
    }
}