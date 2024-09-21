using System.Linq.Expressions;
using MyWarsha_DTOs.CarDTOs;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Interfaces.RepositoriesInterfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<CarDto?> Get(Expression<Func<Car, bool>> predicate);
        Task<Car?> GetById(int id);
        // Task<IEnumerable<CarDto>> GetAll(PaginationPropreties paginationPropreties);
        Task<IEnumerable<CarDto>> GetAll(Expression<Func<Car, bool>> predicate, PaginationPropreties paginationPropreties);
    }
}