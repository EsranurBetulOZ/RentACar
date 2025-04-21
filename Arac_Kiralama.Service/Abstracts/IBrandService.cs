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
 
    Task AddAsync(BrandAddRequestDto brandAddRequestDto);
    Task DeleteAsync(int id);
    Task UpdateAsync(BrandUpdateRequestDto brandUpdateRequestDto);
    Task<BrandResponseDto> GetByIdAsync(int id);
    Task<List<BrandResponseDto>> GetAllAsync();
    List<Brand> GetBrandsByName(string brandName);
    Task<List<Brand>> GetBrandsByNameAsync(string brandName);
}
