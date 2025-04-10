using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Models.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Fuels
{
    public sealed class FuelAutoMapperConverter : IFuelMapper
    {
        private readonly IMapper _mapper;

        public FuelAutoMapperConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Fuel ConvertToEntity(FuelAddRequestDto dto)
        {
            return _mapper.Map<Fuel>(dto);
        }

        public Fuel ConvertToEntity(FuelUpdateRequestDto dto)
        {
            return _mapper.Map<Fuel>(dto);
        }

        public FuelResponseDto ConvertToResponse(Fuel fuel)
        {
            return _mapper.Map<FuelResponseDto>(fuel);
        }

        public List<FuelResponseDto> ConvertToResponseList(List<Fuel> fuels)
        {
            return _mapper.Map<List<FuelResponseDto>>(fuels);
        }
    }
}
