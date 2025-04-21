using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using CorePackage.Repositories;


namespace Arac_Kiralama.Repository.Repositories.Concretes;

public sealed class FuelRepository : EfRepositoryBase<Fuel, int, BaseDbContext>, IFuelRepository
{
    public FuelRepository(BaseDbContext context) : base(context)
    {
    }

    public bool ExistByFuelName(string name)
    {
        return Context.Fuels.Any(x => x.Name == name);
    }
}