using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_DTOs.PhoneDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        private readonly AppDbContext _context;

        public PhoneRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhoneDto>> GetAll(PaginationPropreties paginationPropreties)
        {
            return await _context.Phone.Select(GetPhoneDtoExpression()).OrderBy(x => x.Id).Skip(paginationPropreties.Skip()).Take(paginationPropreties.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PhoneDto>> GetAll(Expression<Func<Phone, bool>> predicate, PaginationPropreties paginationPropreties)
        {
            return await _context.Phone.Where(predicate).Select(GetPhoneDtoExpression()).OrderBy(x => x.Id).Skip(paginationPropreties.Skip()).Take(paginationPropreties.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<PhoneDto?> Get(Expression<Func<Phone, bool>> predicate)
        {
            return await _context.Phone.Where(predicate).Select(GetPhoneDtoExpression()).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Phone?> GetById(int id)
        {
            return await _context.Phone.FirstOrDefaultAsync(x => x.Id == id);
        }

        public int Count(Expression<Func<Phone, bool>> predicate)
        {
            return _context.Phone.Count(predicate);
        }

        private static Expression<Func<Phone, PhoneDto>> GetPhoneDtoExpression()
        {
            return x => new PhoneDto
            {
                Id = x.Id,
                Number = x.Number,
                ClientId = x.ClientId
            };
        }
    }
}