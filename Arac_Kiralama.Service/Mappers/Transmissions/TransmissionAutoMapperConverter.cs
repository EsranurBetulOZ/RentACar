using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Models.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Transmissions
{
    public sealed class TransmissionAutoMapperConverter : ITransmissionMapper
    {
        private readonly IMapper _mapper;

        public TransmissionAutoMapperConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Transmission ConvertToEntity(TransmissionAddRequestDto dto)
        {
            return _mapper.Map<Transmission>(dto);
        }

        public Transmission ConvertToEntity(TransmissionUpdateRequestDto dto)
        {
            return _mapper.Map<Transmission>(dto);
        }

        public TransmissionResponseDto ConvertToResponse(Transmission transmission)
        {
            return _mapper.Map<TransmissionResponseDto>(transmission);
        }

        public List<TransmissionResponseDto> ConvertToResponseList(List<Transmission> transmissions)
        {
            return _mapper.Map<List<TransmissionResponseDto>>(transmissions);
        }
    }
}
