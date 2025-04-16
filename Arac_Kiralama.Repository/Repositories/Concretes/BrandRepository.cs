using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Arac_Kiralama.Repository.Repositories.Concretes;

public sealed class BrandRepository(BaseDbContext context) : IBrandRepository
{
   
    public Brand Add(Brand brand)
    {
        brand.CreatedDate = DateTime.UtcNow;
        context.Brands.Add(brand);
        context.SaveChanges();
        return brand;
    }

    public Brand Delete(Brand brand)
    {
       
        context.Brands.Remove(brand);
        context.SaveChanges();
        return brand;
    }

    public bool ExistByNameAndModelYear(string name, string modelYear)
    {
        return context.Brands.Any(x => x.Name == name && x.ModelYear == modelYear);
    }

    public List<Brand> GetAll()
    {
        return context.Brands.ToList();
    }

    public List<Brand> GetBrandsByName(string brandName)
    {
        return context.Brands
            .Where(b => b.Name == brandName)
            .OrderByDescending(b => b.ModelYear)
            .ToList();
    }

    public Brand GetById(int id)
    {
        return context.Brands.Find(id);
    }

    public Brand Update(Brand brand)
    {
        brand.UpdatedDate = DateTime.UtcNow;
        context.Brands.Update(brand);
        context.SaveChanges();
        return brand;
    }
}
