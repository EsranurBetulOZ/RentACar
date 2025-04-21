using Arac_Kiralama.Models.Dtos.Transmissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts;

public interface ITransmissionService
{
    Task AddAsync(TransmissionAddRequestDto brand);
    Task DeleteAsync(int id);
    Task UpdateAsync(TransmissionUpdateRequestDto brand);
    Task<TransmissionResponseDto> GetByIdAsync(int id);
    Task<List<TransmissionResponseDto>>GetAllAsync();
}
