using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetAllAsyncs();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllQueryAsync(Expression<Func<TEntity, bool>> expression);
    }
}
