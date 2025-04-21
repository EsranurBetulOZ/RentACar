using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Exceptions.Types;
using Arac_Kiralama.Service.Mappers.Transmissions;
using AutoMapper;

namespace Arac_Kiralama.Service.Concretes;

public class TansmissionService(IMapper mapper, ITransmissionRepository transmissionRepository) : ITransmissionService
{
    public async Task AddAsync(TransmissionAddRequestDto transmissionAddRequestDto)
    {
        bool isPresent = transmissionRepository.ExistByTransmissionName(transmissionAddRequestDto.Name);
        if (isPresent)
        {
            throw new BusinessException("Vites Tipi aynı olmamalıdır");
        }
        Transmission transmission = mapper.Map<Transmission>(transmissionAddRequestDto);
        await transmissionRepository.AddAsync(transmission);
    }

    public async Task DeleteAsync(int id)
    {
        var transmission = await transmissionRepository.GetByIdAsync(id);

        if (transmission is null)
        {
            throw new NotFoundException("Vites Tipi bulunamadı.");
        }

        await transmissionRepository.DeleteAsync(transmission!);
    }

    public async Task<List<TransmissionResponseDto>> GetAllAsync()
    {
        var transmissions = await transmissionRepository.GetAllAsync(enableTracking: false);
        var responses = mapper.Map<List<TransmissionResponseDto>>(transmissions);
        return responses;
    }

    public async Task<TransmissionResponseDto> GetByIdAsync(int id)
    {
        var transmission = await transmissionRepository.GetByIdAsync(id);
        var response = mapper.Map<TransmissionResponseDto>(transmission);
        return response;
    }

    public async Task UpdateAsync(TransmissionUpdateRequestDto transmissionUpdateRequestDto)
    {
        Transmission transmission = mapper.Map<Transmission>(transmissionUpdateRequestDto);
        await transmissionRepository.UpdateAsync(transmission);
    }
}


