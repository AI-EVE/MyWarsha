using Microsoft.AspNetCore.Mvc;
using MyWarsha_DTOs.ProductsRestockingBillDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.FilteringUtils.ProductsRestockingBillFilters;
using Utils.PageUtils;

namespace MyWarsha_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsRestockingBillsController : ControllerBase
    {
        private readonly IProductsRestockingBillRepository _productsRestockingBillRepository;

        public ProductsRestockingBillsController(IProductsRestockingBillRepository productsRestockingBillRepository)
        {
            _productsRestockingBillRepository = productsRestockingBillRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductsRestockingBillDtoMulti>>> GetAll([FromQuery] PaginationPropreties paginationPropreties, [FromQuery] ProductsRestockingBillFilters filters)
        {
            var predicate = filters.ToExpression();
            var productsRestockingBills = await _productsRestockingBillRepository.GetAll(paginationPropreties, predicate);
            return Ok(productsRestockingBills);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductsRestockingBillDto?>> GetById(int id)
        {
            var productsRestockingBill = await _productsRestockingBillRepository.Get(x => x.Id == id);
            if (productsRestockingBill == null)
            {
                return NotFound();
            }

            return Ok(productsRestockingBill);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductsRestockingBillDto>> Create(ProductsRestockingBillCreateDto productsRestockingBillCreate)
        {
            var productsRestockingBill = new ProductsRestockingBill
            {
                ShopName = productsRestockingBillCreate.ShopName,
            };

            await _productsRestockingBillRepository.Add(productsRestockingBill);
            await _productsRestockingBillRepository.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = productsRestockingBill.Id }, new 
            {
                Id = productsRestockingBill.Id,
                ShopName = productsRestockingBill.ShopName,
                DateOfOrder = productsRestockingBill.DateOfOrder.ToString("yyyy-MM-dd"),
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Update(int id, ProductsRestockingBillUpdateDto productsRestockingBillUpdate)
        {
            var productsRestockingBill = await _productsRestockingBillRepository.GetById(id);
            if (productsRestockingBill == null)
            {
                return NotFound();
            }

            var IsDateOfOrderValid = DateOnly.TryParse(productsRestockingBillUpdate.DateOfOrder, out DateOnly dateOfOrder);
            productsRestockingBill.ShopName = productsRestockingBillUpdate.ShopName ?? productsRestockingBill.ShopName;
            productsRestockingBill.DateOfOrder = IsDateOfOrderValid ? dateOfOrder : productsRestockingBill.DateOfOrder;

            _productsRestockingBillRepository.Update(productsRestockingBill);
            await _productsRestockingBillRepository.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var productsRestockingBill = await _productsRestockingBillRepository.GetById(id);
            if (productsRestockingBill == null)
            {
                return NotFound();
            }

            _productsRestockingBillRepository.Delete(productsRestockingBill);
            await _productsRestockingBillRepository.SaveChanges();

            return NoContent();
        }
        
    }
}