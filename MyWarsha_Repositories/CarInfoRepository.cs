using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_DTOs.CarGenerationDtos;
using MyWarsha_DTOs.CarInfoDTOs;
using MyWarsha_DTOs.CarMakerDtos;
using MyWarsha_DTOs.CarModelDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class CarInfoRepository : Repository<CarInfo>, ICarInfoRepository
    {
        private readonly AppDbContext _context;
        public CarInfoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CarInfoDto?> Get(Expression<Func<CarInfo, bool>> predicate)
        {
            return await _context.CarInfo.Where(predicate).Select(GetCarInfoDtoExpression()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarInfoDto>> GetAll(PaginationPropreties paginationPropreties)
        {
            return await _context.CarInfo.Select(GetCarInfoDtoExpression()).Skip(paginationPropreties.Skip()).Take(paginationPropreties.PageSize).ToListAsync();
        }

        public async Task<IEnumerable<CarInfoDto>> GetAll(PaginationPropreties paginationPropreties, Expression<Func<CarInfo, bool>> predicate)
        {
            return await _context.CarInfo.Where(predicate).Select(GetCarInfoDtoExpression()).Skip(paginationPropreties.Skip()).Take(paginationPropreties.PageSize).ToListAsync();
        }

        public async Task<CarInfo?> GetById(int id)
        {
            return await _context.CarInfo.FirstOrDefaultAsync(c => c.Id == id);
        }

        private static Expression<Func<CarInfo, CarInfoDto>> GetCarInfoDtoExpression()
        {
            return x => new CarInfoDto
            {
                Id = x.Id,
                CarMaker = new CarMakerDto
                {
                    Id = x.CarMaker.Id,
                    Name = x.CarMaker.Name,
                    Logo = x.CarMaker.Logo,
                    Notes = x.CarMaker.Notes
                },
                CarModel = new CarModelDto
                {
                    Id = x.CarModel.Id,
                    Name = x.CarModel.Name,
                    Notes = x.CarModel.Notes,
                },
                CarGeneration = new CarGenerationDto
                {
                    Id = x.CarGeneration.Id,
                    Name = x.CarGeneration.Name,
                    Notes = x.CarGeneration.Notes
                }
            };
        }
    }
}