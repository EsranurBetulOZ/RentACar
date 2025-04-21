using Arac_Kiralama.Models.Dtos.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts
{
    public interface IColorService
    {
        Task AddAsync(ColorAddRequestDto colorAddRequestDto);
        Task DeleteAsync(int id);
        Task UpdateAsync(ColorUpdateRequestDto colorUpdateRequestDto);
       Task<ColorResponseDto> GetByIdAsync(int id);
        Task<List<ColorResponseDto>> GetAllAsync();
    }
}
