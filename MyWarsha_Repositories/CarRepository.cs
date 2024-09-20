using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_DTOs.CarDTOs;
using MyWarsha_DTOs.CarGenerationDtos;
using MyWarsha_DTOs.CarImageDTOs;
using MyWarsha_DTOs.CarInfoDTOs;
using MyWarsha_DTOs.CarMakerDtos;
using MyWarsha_DTOs.CarModelDTOs;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CarDto?> Get(Expression<Func<Car, bool>> predicate)
        {
            return await _context.Car.Where(predicate).Select(GetCarDtoExpression()).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CarDto>> GetAll(PaginationPropreties paginationPropreties)
        {
            return await _context.Car.Select(GetCarDtoExpression()).OrderBy(c => c.Id).Skip(paginationPropreties.Skip())
                .Take(paginationPropreties.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<CarDto>> GetAll(Expression<Func<Car, bool>> predicate, PaginationPropreties paginationPropreties)
        {
            return await _context.Car.Where(predicate).Select(GetCarDtoExpression()).OrderBy(c => c.Id).Skip(paginationPropreties.Skip())
                .Take(paginationPropreties.PageSize).AsNoTracking().ToListAsync();
        }

        public Task<Car?> GetById(int id)
        {
            return _context.Car.FirstOrDefaultAsync(x => x.Id == id);
        }

        private static Expression<Func<Car, CarDto>> GetCarDtoExpression()
        {
            return car => new CarDto
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
                        Name = car.CarInfo.CarMaker.Name,
                        Logo = car.CarInfo.CarMaker.Logo,
                        Notes = car.CarInfo.CarMaker.Notes
                    },
                    CarModel = new CarModelDto
                    {
                        Id = car.CarInfo.CarModel.Id,
                        Name = car.CarInfo.CarModel.Name,
                        Notes = car.CarInfo.CarModel.Notes
                    },
                    CarGeneration = new CarGenerationDto
                    {
                        Id = car.CarInfo.CarGeneration.Id,
                        Name = car.CarInfo.CarGeneration.Name,
                        Notes = car.CarInfo.CarGeneration.Notes
                    }
                 },
                CarImages = car.CarImages != null ? car.CarImages.Select(carImage => new CarImageDto
                {
                    Id = carImage.Id,
                    ImagePath = carImage.ImagePath,
                    IsMain = carImage.IsMain,
                    CarId = carImage.CarId
                }).ToList() : new List<CarImageDto>()
            };
        }
    }
}