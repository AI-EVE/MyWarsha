using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_DTOs.CarDTOs;
using MyWarsha_DTOs.CarGenerationDtos;
using MyWarsha_DTOs.CarImageDTOs;
using MyWarsha_DTOs.CarInfoDTOs;
using MyWarsha_DTOs.CarMakerDtos;
using MyWarsha_DTOs.CarModelDTOs;
using MyWarsha_DTOs.ClientDTOs;
using MyWarsha_DTOs.PhoneDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ClientDto?> Get(Expression<Func<Client, bool>> predicate)
        {
            return await _context.Client.Where(predicate).Include(c => c.Phones)
            .Include(c => c.Cars)
                .ThenInclude(car => car.CarInfo)
                    .ThenInclude(carInfo => carInfo.CarMaker)
            .Include(c => c.Cars)
                .ThenInclude(car => car.CarInfo)
                    .ThenInclude(carInfo => carInfo.CarModel)
            .Include(c => c.Cars)
                .ThenInclude(car => car.CarInfo)
                    .ThenInclude(carInfo => carInfo.CarGeneration)
            .Include(c => c.Cars)
                .ThenInclude(car => car.CarImages)
            .Select(client => ClientDto.ToClientDto(client))
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClientDtoMulti>> GetAll(PaginationPropreties paginationPropreties)
        {
            return await _context.Client
            .Select(x => ClientDtoMulti.ToClientDtoMulti(x))
            .Skip(paginationPropreties.Skip())
            .Take(paginationPropreties.PageSize)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<IEnumerable<ClientDtoMulti>> GetAll(Expression<Func<Client, bool>> predicate, PaginationPropreties paginationPropreties)
        {
            return await _context.Client
            .Where(predicate)
            .Select(x => ClientDtoMulti.ToClientDtoMulti(x))
            .Skip(paginationPropreties.Skip())
            .Take(paginationPropreties.PageSize)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Client?> GetById(int id)
        {
            return await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}