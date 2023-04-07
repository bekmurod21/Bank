using Domain.Commons;
using System.Linq.Expressions;

namespace Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> SelectAllAsync();
    }
}
