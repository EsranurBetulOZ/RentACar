using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using CorePackage.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Arac_Kiralama.Repository.Repositories.Concretes;

public sealed class BrandRepository : EfRepositoryBase<Brand, int, BaseDbContext>, IBrandRepository
{
   

    public BrandRepository(BaseDbContext context) : base(context)
    {
    }

    public bool ExistByNameAndModelYear(string name, string modelYear)
    {
        return Context.Brands.Any(x => x.Name == name && x.ModelYear == modelYear);
    }

    public List<Brand> GetBrandsByName(string brandName)
    {
        return Context.Brands
        .Where(b => b.Name == brandName)
        .OrderByDescending(b => b.ModelYear)
        .ToList();
    }
}