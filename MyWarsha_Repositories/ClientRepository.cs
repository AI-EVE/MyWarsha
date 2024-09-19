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
            return await _context.Client.Where(predicate).Select(GetClientDtoExpression()).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClientDto>> GetAll(PaginationPropreties paginationPropreties)
        {
            return await _context.Client.Select(GetClientDtoExpression()).OrderBy(c => c.Id).Skip(paginationPropreties.Skip())
                .Take(paginationPropreties.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ClientDto>> GetAll(Expression<Func<Client, bool>> predicate, PaginationPropreties paginationPropreties)
        {
            return await _context.Client.Where(predicate).Select(GetClientDtoExpression()).OrderBy(c => c.Id).Skip(paginationPropreties.Skip())
                .Take(paginationPropreties.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<Client?> GetById(int id)
        {
            return await _context.Client.FirstOrDefaultAsync(x => x.Id == id);
        }

        private static Expression<Func<Client, ClientDto>> GetClientDtoExpression()
        {
            return ele => new ClientDto
            {
                Id = ele.Id,
                Name = ele.Name,
                Email = ele.Email,
                Phones = ele.Phones != null ? ele.Phones.Select(phone => new PhoneDto
                {
                    Id = phone.Id,
                    Number = phone.Number,
                    ClientId = phone.ClientId
                }).ToList() : new List<PhoneDto>(),
                Cars = ele.Cars != null ? ele.Cars.Select(car => new CarDto
                {
                    Id = car.Id,
                    Color = car.Color,
                    PlateNumber = car.PlateNumber,
                    ChassisNumber = car.ChassisNumber,
                    MotorNumber = car.MotorNumber,
                    Notes = car.Notes,
                    ClientId = car.ClientId,
                    CarInfo = new CarInfoDto
                    {
                        Id = car.CarInfo.Id,
                        CarMaker = new CarMakerDto
                        {
                            Id = car.CarInfo.CarMaker.Id,
                            Name = car.CarInfo.CarMaker.Name
                        },
                        CarModel = new CarModelDto
                        {
                            Id = car.CarInfo.CarModel.Id,
                            Name = car.CarInfo.CarModel.Name
                        },
                        CarGeneration = new CarGenerationDto
                        {
                            Id = car.CarInfo.CarGeneration.Id,
                            Name = car.CarInfo.CarGeneration.Name
                        }
                    },
                    CarImages = car.CarImages != null ? car.CarImages.Select(carImage => new CarImageDto
                    {
                        Id = carImage.Id,
                        ImagePath = carImage.ImagePath,
                        IsMain = carImage.IsMain,
                        CarId = carImage.CarId
                    }).ToList() : new List<CarImageDto>()
                }).ToList() : new List<CarDto>()
            };
        }
    }
}