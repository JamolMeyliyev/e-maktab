using e_maktab.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.DataLayer;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly EMaktabContext appDbContext;

    public GenericRepository(EMaktabContext appDbContext) =>
        this.appDbContext = appDbContext;

    public virtual async ValueTask<TEntity> InsertAsync(
        TEntity entity)
    {
        var entityEntry = await this.appDbContext
            .AddAsync<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual IQueryable<TEntity> SelectAll() =>
        this.appDbContext.Set<TEntity>();

    public virtual async ValueTask<TEntity?> SelectByIdAsync(int id) =>
        await this.appDbContext.Set<TEntity>().FindAsync(id);

    public virtual async ValueTask<TEntity> SelectByIdWithDetailsAsync(
        Expression<Func<TEntity, bool>> expression,
        string[] includes = null)
    {
        IQueryable<TEntity> entities = this.SelectAll();
        if(includes != null)
        {
            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }
        }
        

        return await entities.FirstOrDefaultAsync(expression);
    }

    public virtual async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = this.appDbContext
            .Update<TEntity>(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entityEntry = this.appDbContext
            .Set<TEntity>()
            .Remove(entity);

        await this.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public virtual async ValueTask<int> SaveChangesAsync() =>
        await this.appDbContext
            .SaveChangesAsync();
}
