using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyWarsha_DataAccess.Data;
using MyWarsha_Interfaces.RepositoriesInterfaces;
using Utils.PageUtils;

namespace MyWarsha_Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            Console.WriteLine("Added");
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public void Delete(T entity)
        {
             _dbSet.Remove(entity);
        }

        public async Task<bool> SaveChanges()
        {
            int changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }   

        

    }
}