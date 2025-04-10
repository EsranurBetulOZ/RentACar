
using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Transmissions;

public interface ITransmissionMapper
{
    Transmission ConvertToEntity(TransmissionAddRequestDto dto);
    Transmission ConvertToEntity(TransmissionUpdateRequestDto dto);
    TransmissionResponseDto ConvertToResponse(Transmission transmission);
    List<TransmissionResponseDto> ConvertToResponseList(List<Transmission> transmissions);

}
