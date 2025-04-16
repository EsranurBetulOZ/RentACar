using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts;

public interface IBrandService
{
    void Add(BrandAddRequestDto brand);
    void Delete(int id);
    void Update(BrandUpdateRequestDto brand);
    BrandResponseDto GetById(int id);
    List<BrandResponseDto> GetAll();
    List<Brand> GetBrandsByName(string brandName);
}
