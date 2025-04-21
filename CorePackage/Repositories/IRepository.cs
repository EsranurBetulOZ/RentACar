using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackage.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity GetById(TId id);
        TEntity Delete(TEntity entity);
        List<TEntity> GetAll(bool enableTracking = true);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(bool enableTracking = true, CancellationToken cancellationToken = default);
    }
}
