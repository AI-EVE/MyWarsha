using Microsoft.AspNetCore.Mvc;
using MyWarsha_DTOs.ProductBoughtDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.FilteringUtils.ProductBoughtFilters;
using Utils.PageUtils;

namespace MyWarsha_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsBoughtController : ControllerBase
    {
        private readonly IProductBoughtRepository _productBoughtRepository;

        public ProductsBoughtController(IProductBoughtRepository productBoughtRepository)
        {
            _productBoughtRepository = productBoughtRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationPropreties paginationPropreties, [FromQuery] ProductBoughtFilters productBoughtFilters)
        {
            var productsBought = await _productBoughtRepository.GetAll(paginationPropreties, productBoughtFilters.GetExpression());
            return Ok(productsBought);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var productBought = await _productBoughtRepository.Get(x => x.Id == id);
            return Ok(productBought);
        }

        [HttpGet("count")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetCount([FromQuery] ProductBoughtFilters productBoughtFilters)
        {
            var count = await _productBoughtRepository.GetCount(productBoughtFilters.GetExpression());
            return Ok(count);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ProductBoughtCreateDto productBoughtDto)
        {
            var productBought = new ProductBought
            {
                PricePerUnit = productBoughtDto.PricePerUnit,
                Discount = productBoughtDto.Discount,
                Count = productBoughtDto.Count,
                Note = productBoughtDto.Note,
                ProductId = productBoughtDto.ProductId,
                ProductsRestockingBillId = productBoughtDto.ProductsRestockingBillId
            };

            await _productBoughtRepository.Add(productBought);
            await _productBoughtRepository.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = productBought.Id }, new {
                productBought.Id,
                productBought.PricePerUnit,
                productBought.Discount,
                productBought.Count,
                productBought.Note,
                productBought.ProductId,
                productBought.ProductsRestockingBillId
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductBoughtUpdateDto productBoughtDto)
        {
            var productBought = await _productBoughtRepository.GetById(id);
            if (productBought == null)
            {
                return NotFound();
            }

            productBought.PricePerUnit = productBoughtDto.PricePerUnit ?? productBought.PricePerUnit;
            productBought.Discount = productBoughtDto.Discount ?? productBought.Discount;
            productBought.Note = productBoughtDto.Note ?? productBought.Note;
            productBought.IsReturned = productBoughtDto.IsReturned ?? productBought.IsReturned;

            _productBoughtRepository.Update(productBought);
            await _productBoughtRepository.SaveChanges();

            return NoContent();
        }


    }
}