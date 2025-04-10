using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Fuels
{
    public interface IFuelMapper
    {
        Fuel ConvertToEntity(FuelAddRequestDto dto);
        Fuel ConvertToEntity(FuelUpdateRequestDto dto);
        FuelResponseDto ConvertToResponse(Fuel fuel);
        List<FuelResponseDto> ConvertToResponseList(List<Fuel> fuels);
    }
}
