using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Exceptions.Types;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Mappers.Colors;
using AutoMapper;

namespace Arac_Kiralama.Service.Concretes;

public sealed class ColorService(IMapper mapper, IColorRepository colorRepository) : IColorService
{
    public async Task AddAsync(ColorAddRequestDto colorAddRequestDto)
    {
        bool isPresent = colorRepository.ExistByColorName(colorAddRequestDto.Name);
        if (isPresent)
        {
            throw new BusinessException("Renk Adı aynı olmamalıdır");
        }
        Color color = mapper.Map<Color>(colorAddRequestDto);
        await colorRepository.AddAsync(color);
    }
    

    public async Task DeleteAsync(int id)
    {
        var color = await colorRepository.GetByIdAsync(id);

        if (color is null)
        {
            throw new NotFoundException("İlgili Renk bulunamadı.");
        }

        await colorRepository.DeleteAsync(color!);
    }
    

    public async Task<List<ColorResponseDto>> GetAllAsync()
    {
        var colors = await colorRepository.GetAllAsync(enableTracking: false);
        var responses = mapper.Map<List<ColorResponseDto>>(colors);
        return responses;
    }


    public async Task<ColorResponseDto> GetByIdAsync(int id)
    {
        var color = await colorRepository.GetByIdAsync(id);
        var response = mapper.Map<ColorResponseDto>(color);
        return response;
    }

    public async Task UpdateAsync(ColorUpdateRequestDto colorUpdateRequestDto)
    {
        Color color = mapper.Map<Color>(colorUpdateRequestDto);
        await colorRepository.UpdateAsync(color);
    }
}










