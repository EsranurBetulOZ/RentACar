using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Cars
{
    public interface ICarMapper
    {
        Car ConvertToEntity(CarAddRequestDto dto);
        Car ConvertToEntity(CarUpdateRequestDto dto);
        CarResponseDto ConvertToResponse(Car car);
        List<CarResponseDto> ConvertToResponseList(List<Car> cars);
    }
}
