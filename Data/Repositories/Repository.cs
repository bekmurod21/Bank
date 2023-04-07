using Data.Context;
using Data.IRepositories;
using Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly BankDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(BankDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<TEntity>();
    }

    public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await dbSet.FirstOrDefaultAsync(predicate);
        if (entity == null)
            return false;
        dbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await dbSet.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public IQueryable<TEntity> SelectAllAsync() =>
        dbSet; 
    

    public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate)
     =>await dbSet.FirstOrDefaultAsync(predicate);

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = dbSet.Update(entity);
        await dbContext.SaveChangesAsync();
        return entry.Entity;
    }
}
