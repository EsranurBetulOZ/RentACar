
using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Exceptions.Types;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Mappers.Transmissions;
using System;

namespace Arac_Kiralama.Service.Concretes
{
    public class TansmissionService:ITransmissionService
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly ITransmissionMapper _transmissionMapper;

        public TansmissionService(ITransmissionRepository transmissionRepository, ITransmissionMapper transmissionMapper)
        {
            _transmissionRepository = transmissionRepository;
            _transmissionMapper = transmissionMapper;
        }

        public void Add(TransmissionAddRequestDto dto)
        {
            bool isPresent = _transmissionRepository.ExistByTransmissionName(dto.Name);
            if (isPresent)
            {
                throw new BusinessException("Vites tipi mevcut. Tekrar eklenemez");
            }
            Transmission transmission = _transmissionMapper.ConvertToEntity(dto);
            _transmissionRepository.Add(transmission);
        }

        public void Delete(int id)
        {
            Transmission? transmission = _transmissionRepository.GetById(id);
            if (transmission is null)
            {
                throw new NotFoundException("İlgili vites tipi bulunamadı.");
            }
            _transmissionRepository.Delete(transmission!);
        }

        public List<TransmissionResponseDto> GetAll()
        {
            List<Transmission> transmissions = _transmissionRepository.GetAll();
            List<TransmissionResponseDto> responses = _transmissionMapper.ConvertToResponseList(transmissions);
            return responses;
        }

        public TransmissionResponseDto GetById(int id)
        {
            Transmission? transmission = _transmissionRepository.GetById(id);
            //toDo: Eğer ilgili transmission bulunamazsa exeption Handling mekanizması 
            TransmissionResponseDto dto = _transmissionMapper.ConvertToResponse(transmission!);
            return dto;
        }

        public void Update(TransmissionUpdateRequestDto dto)
        {
            Transmission transmission = _transmissionMapper.ConvertToEntity(dto);
            _transmissionRepository.Update(transmission);
        }
    }
}
