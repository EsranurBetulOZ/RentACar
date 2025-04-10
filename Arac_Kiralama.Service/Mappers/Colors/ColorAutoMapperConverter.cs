using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Models.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Colors
{
    public sealed class ColorAutoMapperConverter : IColorMapper
    {
        private readonly IMapper _mapper;

        public ColorAutoMapperConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Color ConvertToEntity(ColorAddRequestDto dto)
        {
            return _mapper.Map<Color>(dto);
        }

        public Color ConvertToEntity(ColorUpdateRequestDto dto)
        {
            return _mapper.Map<Color>(dto);
        }

        public ColorResponseDto ConvertToResponse(Color color)
        {
            return _mapper.Map<ColorResponseDto>(color);
        }

        public List<ColorResponseDto> ConvertToResponseList(List<Color> colors)
        {
            return _mapper.Map<List<ColorResponseDto>>(colors);
        }
    }
}
