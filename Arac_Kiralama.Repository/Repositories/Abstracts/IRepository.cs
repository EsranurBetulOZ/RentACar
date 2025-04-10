using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Abstracts;

public interface IRepository<TEntity,TId> where TEntity:Entity<TId>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity GetById(TId id);
    TEntity Delete(TEntity entity);
    List<TEntity> GetAll();
}