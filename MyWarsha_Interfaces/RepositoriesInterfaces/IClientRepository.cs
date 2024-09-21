using System.Linq.Expressions;
using MyWarsha_DTOs.ClientDTOs;
using MyWarsha_Models.Models;
using Utils.PageUtils;

namespace MyWarsha_Interfaces.RepositoriesInterfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client?> GetById(int id);
        Task<ClientDto?> Get(Expression<Func<Client, bool>> predicate);
        // Task<IEnumerable<ClientDtoMulti>> GetAll(PaginationPropreties paginationPropreties);
        Task<IEnumerable<ClientDtoMulti>> GetAll(Expression<Func<Client, bool>> predicate, PaginationPropreties paginationPropreties);
    }
}