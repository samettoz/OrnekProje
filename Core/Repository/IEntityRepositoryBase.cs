using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
