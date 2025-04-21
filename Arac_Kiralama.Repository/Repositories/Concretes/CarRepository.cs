using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using CorePackage.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Repository.Repositories.Concretes;

public sealed class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<List<Car>> GetAllWithIncludesAsync(bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        var query = Context.Cars
        .Include(c => c.Brand)
        .Include(c => c.Color)
        .Include(c => c.Transmission)
        .Include(c => c.Fuel)
        .AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Car> GetByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Cars
         .Include(c => c.Brand)
         .Include(c => c.Color)
         .Include(c => c.Transmission)
         .Include(c => c.Fuel)
         .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
       public async Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
{
    return await Context.Cars
        .Include(c => c.Brand)
        .Include(c => c.Color)
        .Include(c => c.Transmission)
        .Include(c => c.Fuel)
        .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}

}









