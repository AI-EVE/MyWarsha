using Microsoft.AspNetCore.Mvc;
using MyWarsha_Interfaces.RepositoriesInterfaces;

namespace MyWarsha_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceStatusesController : ControllerBase
    {
        private readonly IServiceStatusRepository _serviceStatusRepository;

        public ServiceStatusesController(IServiceStatusRepository serviceStatusRepository)
        {
            _serviceStatusRepository = serviceStatusRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetServiceStatuses()
        {
            var serviceStatuses = await _serviceStatusRepository.GetServiceStatuses();
            return Ok(serviceStatuses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetServiceStatusById(int id)
        {
            var serviceStatus = await _serviceStatusRepository.GetServiceStatusById(id);
            if (serviceStatus == null)
            {
                return NotFound();
            }
            return Ok(serviceStatus);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetServiceStatusByName(string name)
        {
            var serviceStatus = await _serviceStatusRepository.GetServiceStatusByName(name);
            if (serviceStatus == null)
            {
                return NotFound();
            }
            return Ok(serviceStatus);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        // update description of service status
        public async Task<IActionResult> UpdateServiceStatus(int id, [FromBody] string description)
        {
            var serviceStatus = await _serviceStatusRepository.GetServiceStatusById(id);
            if (serviceStatus == null)
            {
                return NotFound();
            }
            serviceStatus.Description = description;
            _serviceStatusRepository.Update(serviceStatus);
            await _serviceStatusRepository.SaveChanges();
            return NoContent();
        }
    }
}