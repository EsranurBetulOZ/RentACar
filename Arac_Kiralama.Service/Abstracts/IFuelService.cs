using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts;

public interface IFuelService
{
    Task AddAsync(FuelAddRequestDto fuelAddRequestDto);
    Task DeleteAsync(int id);
    Task UpdateAsync(FuelUpdateRequestDto fuelUpdateRequestDto);
    Task<FuelResponseDto> GetByIdAsync(int id);
    Task<List<FuelResponseDto>> GetAllAsync();
}
