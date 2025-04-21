using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Exceptions.Types;
using AutoMapper;


namespace Arac_Kiralama.Service.Concretes;


public sealed class BrandService(IMapper mapper, IBrandRepository brandRepository) : IBrandService
{
    public async Task<BrandResponseDto> GetByIdAsync(int id)
    {
        var brand = await brandRepository.GetByIdAsync(id);
        var response = mapper.Map<BrandResponseDto>(brand);
        return response;
    }
    public async Task<List<BrandResponseDto>> GetAllAsync()
    {
        var brands = await brandRepository.GetAllAsync(enableTracking: false);
        var responses = mapper.Map<List<BrandResponseDto>>(brands);
        return responses;
    }
    public async Task AddAsync(BrandAddRequestDto brandAddRequestDto)
    {
        bool isPresent = brandRepository.ExistByNameAndModelYear(brandAddRequestDto.Name, brandAddRequestDto.ModelYear);
        if (isPresent)
        {
            throw new BusinessException("Marka ve model mevcut. Tekrar eklenemez");
        }
        Brand brand = mapper.Map<Brand>(brandAddRequestDto);
        await brandRepository.AddAsync(brand);
    }

    public async Task DeleteAsync(int id)
    {
        var brand = await brandRepository.GetByIdAsync(id);

        if (brand is null)
        {
            throw new NotFoundException("İlgili Marka/Model bulunamadı.");
        }

        await brandRepository.DeleteAsync(brand!);
    }

    public async Task UpdateAsync(BrandUpdateRequestDto brandUpdateRequestDto)
    {
        Brand brand = mapper.Map<Brand>(brandUpdateRequestDto);
        await brandRepository.UpdateAsync(brand);
    }

    public List<Brand> GetBrandsByName(string brandName)
    {
        return brandRepository.GetBrandsByName(brandName);
    }

    public async Task<List<Brand>> GetBrandsByNameAsync(string brandName)
    {
        // Task.FromResult ile senkron metodu asenkron hale çeviriyoruz
        return await Task.FromResult(GetBrandsByName(brandName));
    }
}
