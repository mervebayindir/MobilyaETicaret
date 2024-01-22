using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace MobilyaETicaret.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _mobilyaETicaretDB;
        private readonly DbSet<TEntity> _dbset;

        public GenericRepository(AppDbContext mobilyaETicaretDB)
        {
            _mobilyaETicaretDB = mobilyaETicaretDB;
            _dbset = _mobilyaETicaretDB.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllQueryAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbset.Where(expression).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbset.Update(entity);
        }
    }
}
