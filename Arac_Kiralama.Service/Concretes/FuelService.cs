using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Exceptions.Types;
using Arac_Kiralama.Service.Mappers.Fuels;
using AutoMapper;

namespace Arac_Kiralama.Service.Concretes;

public class FuelService(IMapper mapper, IFuelRepository fuelRepository) : IFuelService
{
    public async Task AddAsync(FuelAddRequestDto fuelAddRequestDto)
    {
        bool isPresent = fuelRepository.ExistByFuelName(fuelAddRequestDto.Name);
        if (isPresent)
        {
            throw new BusinessException("Yakıt türü daha önce eklendi");
        }
        Fuel fuel = mapper.Map<Fuel>(fuelAddRequestDto);
        await fuelRepository.AddAsync(fuel);
    }

    public async Task DeleteAsync(int id)
    {
        var fuel = await fuelRepository.GetByIdAsync(id);

        if (fuel is null)
        {
            throw new NotFoundException("İlgili Yakıt bulunamadı.");
        }

        await fuelRepository.DeleteAsync(fuel!);
    }

    public async Task<List<FuelResponseDto>> GetAllAsync()
    {
        var fuels = await fuelRepository.GetAllAsync(enableTracking: false);
        var responses = mapper.Map<List<FuelResponseDto>>(fuels);
        return responses;
    }

    public async Task<FuelResponseDto> GetByIdAsync(int id)
    {
        var fuel = await fuelRepository.GetByIdAsync(id);
        var response = mapper.Map<FuelResponseDto>(fuel);
        return response;
    }

    public async Task UpdateAsync(FuelUpdateRequestDto fuelUpdateRequestDto)
    {
        Fuel fuel = mapper.Map<Fuel>(fuelUpdateRequestDto);
        await fuelRepository.UpdateAsync(fuel);
    }
}

