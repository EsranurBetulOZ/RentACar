using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Brands
{
    public sealed class BrandAutoMapperConverter : IBrandMapper
    {
        private readonly IMapper _mapper;

        public BrandAutoMapperConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Brand ConvertToEntity(BrandAddRequestDto dto)
        {
             return _mapper.Map<Brand>(dto);
        }

        public Brand ConvertToEntity(BrandUpdateRequestDto dto)
        {
            return _mapper.Map<Brand>(dto);
        }

     

        public BrandResponseDto ConvertToResponse(Brand brand)
        {
            return _mapper.Map<BrandResponseDto>(brand);
        }

        public List<BrandResponseDto> ConvertToResponseList(List<Brand> brands)
        {
            return _mapper.Map<List<BrandResponseDto>>(brands);
        }
    }
}
