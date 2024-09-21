using LinqKit;
using Microsoft.AspNetCore.Mvc;
using MyWarsha_DTOs.ProductDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.FilteringUtils.ProductFilters;
using Utils.PageUtils;

namespace MyWarsha_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAll([FromQuery] ProductFilters filters, [FromQuery] PaginationPropreties paginationPropreties)
        {
            var predicate = PredicateBuilder.New<Product>(true);

            if (!string.IsNullOrEmpty(filters.Name))
            {
                predicate = predicate.And(p => p.Name.Contains(filters.Name));
            }

            if (filters.CategoryId.HasValue)
            {
                predicate = predicate.And(p => p.CategoryId == filters.CategoryId);
            }

            if (filters.ProductTypeId.HasValue)
            {
                predicate = predicate.And(p => p.ProductTypeId == filters.ProductTypeId);
            }

            if (filters.ProductBrandId.HasValue)
            {
                predicate = predicate.And(p => p.ProductBrandId == filters.ProductBrandId);
            }

            if (filters.IsAvailable.HasValue)
            {
                predicate = predicate.And(p => p.IsAvailable == filters.IsAvailable);
            }

            var products = await _productRepository.GetAll(paginationPropreties, predicate);

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.Get(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                return BadRequest();
            }

            Product product = new Product
            {
                Name = productCreateDto.Name,
                Description = productCreateDto.Description,
                ListPrice = productCreateDto.ListPrice,
                CategoryId = productCreateDto.CategoryId,
                ProductTypeId = productCreateDto.ProductTypeId,
                ProductBrandId = productCreateDto.ProductBrandId,
                SalePrice = productCreateDto.SalePrice,
                Stock = productCreateDto.Stock,
                IsAvailable = productCreateDto.IsAvailable
            };

            await _productRepository.Add(product);
            await _productRepository.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, null);
        }
  
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productUpdateDto.Name ?? product.Name;
            product.Description = productUpdateDto.Description ?? product.Description;
            product.ListPrice = productUpdateDto.ListPrice ?? product.ListPrice;
            product.SalePrice = productUpdateDto.SalePrice ?? product.SalePrice;
            product.Stock = productUpdateDto.Stock ?? product.Stock;
            product.IsAvailable = productUpdateDto.IsAvailable ?? product.IsAvailable;

            _productRepository.Update(product);
            await _productRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(product);
            await _productRepository.SaveChanges();

            return NoContent();
        }

        [HttpGet("count")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Count([FromQuery] ProductFilters filters)
        {
            var predicate = PredicateBuilder.New<Product>(true);

            if (!string.IsNullOrEmpty(filters.Name))
            {
                predicate = predicate.And(p => p.Name.Contains(filters.Name));
            }

            if (filters.CategoryId.HasValue)
            {
                predicate = predicate.And(p => p.CategoryId == filters.CategoryId);
            }

            if (filters.ProductTypeId.HasValue)
            {
                predicate = predicate.And(p => p.ProductTypeId == filters.ProductTypeId);
            }

            if (filters.ProductBrandId.HasValue)
            {
                predicate = predicate.And(p => p.ProductBrandId == filters.ProductBrandId);
            }

            if (filters.IsAvailable.HasValue)
            {
                predicate = predicate.And(p => p.IsAvailable == filters.IsAvailable);
            }

            var count = await _productRepository.Count(predicate);

            return Ok(count);
        }

    }
}