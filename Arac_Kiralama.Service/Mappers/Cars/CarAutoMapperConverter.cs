using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Models.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Cars
{
    public sealed class CarAutoMapperConverter : ICarMapper

    {
        private readonly IMapper _mapper;

        public CarAutoMapperConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Car ConvertToEntity(CarAddRequestDto dto)
        {
            return _mapper.Map<Car>(dto);
        }

        public Car ConvertToEntity(CarUpdateRequestDto dto)
        {
            return _mapper.Map<Car>(dto);
        }

        public CarResponseDto ConvertToResponse(Car car)
        {
            return _mapper.Map<CarResponseDto>(car);
        }

        public List<CarResponseDto> ConvertToResponseList(List<Car> cars)
        {
            return _mapper.Map<List<CarResponseDto>>(cars);
        }
    }
}
