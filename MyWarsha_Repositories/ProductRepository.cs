using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_DTOs.ProductDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Get(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductImages)
                .Include(p => p.CarInfoProduct)
                .Where(predicate)
                .Select(p => ProductDto.ToProductDto(p))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDtoMulti>> GetAll(PaginationPropreties paginationPropreties, Expression<Func<Product, bool>> predicate)
        {
            var query = _context.Product
                .Include(p => p.ProductImages)
                .Where(predicate)
                .Select(p => ProductDtoMulti.ToProductDtoMulti(p));
            
            return await paginationPropreties.ApplyPagination(query).ToListAsync();
        }


        public Task<Product?> GetById(int id)
        {
            return _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<int> Count(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Product.CountAsync(predicate);
        }
    }
}