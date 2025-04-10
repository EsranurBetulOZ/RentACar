using Arac_Kiralama.Models.Dtos.Transmissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts;

public interface ITransmissionService
{
    void Add(TransmissionAddRequestDto brand);
    void Delete(int id);
    void Update(TransmissionUpdateRequestDto brand);
    TransmissionResponseDto GetById(int id);
    List<TransmissionResponseDto> GetAll();
}
