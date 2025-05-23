﻿using Arac_Kiralama.Models.Entity;
using CorePackage.Repositories;


namespace Arac_Kiralama.Repository.Repositories.Abstracts
{
    public interface IBrandRepository:IRepository<Brand, int>
    {
        bool ExistByNameAndModelYear(string name, string modelYear);
        List<Brand> GetBrandsByName(string brandName);
    }
}
