using Arac_Kiralama.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CorePackage.Repositories
{
    public abstract class EfRepositoryBase<TEntity, TId, TContext> : IRepository<TEntity, TId> where TEntity : Entity<TId>
    where TContext : DbContext
    {
        protected TContext Context { get; }
        protected EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await Context.SaveChangesAsync();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public List<TEntity> GetAll(bool enableTracking = true)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (!enableTracking)
                query = query.AsNoTracking();
            return query.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (!enableTracking)
                query = query.AsNoTracking();
            return await query.ToListAsync(cancellationToken);
        }

        public TEntity GetById(TId id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            return await Context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Update(entity);
            Context.SaveChanges();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
