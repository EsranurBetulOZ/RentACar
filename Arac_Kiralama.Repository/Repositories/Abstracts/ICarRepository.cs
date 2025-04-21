using Arac_Kiralama.Models.Entity;
using CorePackage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Abstracts
{
    public interface ICarRepository:IRepository<Car,Guid>
    {
        Task<Car> GetByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Car>> GetAllWithIncludesAsync(bool enableTracking = true, CancellationToken cancellationToken = default);
    }
}
