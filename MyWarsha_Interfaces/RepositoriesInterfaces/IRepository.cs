using System.Linq.Expressions;
using Utils.PageUtils;

namespace MyWarsha_Interfaces.RepositoriesInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChanges();
        int Count();
    }
}