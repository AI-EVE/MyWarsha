using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class CarGenerationRepository : Repository<CarGeneration>, ICarGenerationRepository
    {
        private readonly AppDbContext _context;
        public CarGenerationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CarGeneration?> Get(Expression<Func<CarGeneration, bool>> predicate)
        {
            return await _context.CarGeneration.FirstOrDefaultAsync(predicate);
        }

        public async Task<CarGeneration?> GetById(int id)
        {
            return await _context.CarGeneration.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<CarGeneration>> GetAll(PaginationPropreties paginationPropreties)
        {
            return await _context.CarGeneration.Skip(paginationPropreties.Skip())
                .Take(paginationPropreties.PageSize).ToListAsync();
        }

        public async Task<IEnumerable<CarGeneration>> GetAll(Expression<Func<CarGeneration, bool>> predicate, PaginationPropreties paginationPropreties)
        {
            return await _context.CarGeneration.Where(predicate).Skip(paginationPropreties.Skip())
                .Take(paginationPropreties.PageSize).ToListAsync();
        }
    }
}