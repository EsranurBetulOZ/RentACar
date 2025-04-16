using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Repository.Contexts;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Exceptions.Types;


namespace Arac_Kiralama.Service.Concretes;

public class BrandService: IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IBrandMapper _brandMapper;

    public BrandService(IBrandRepository brandRepository, IBrandMapper brandMapper)
    {
        _brandRepository = brandRepository;
        _brandMapper = brandMapper;
    }

    public void Add(BrandAddRequestDto dto)
    {
        bool isPresent = _brandRepository.ExistByNameAndModelYear(dto.Name,dto.ModelYear);
        if (isPresent)
        {
            throw new BusinessException("Marka ve model mevcut. Tekrar eklenemez");
        }
        Brand brand=_brandMapper.ConvertToEntity(dto);
        _brandRepository.Add(brand);
    }

    public void Delete(int id)
    {
       Brand? brand=_brandRepository.GetById(id);
        if (brand is null)
        {
            throw new NotFoundException("İlgili Marka/Model bulunamadı.");
        }
        
        _brandRepository.Delete(brand!);
    }

    public List<BrandResponseDto> GetAll()
    {
       List<Brand> brands =_brandRepository.GetAll();
       List<BrandResponseDto> responses = _brandMapper.ConvertToResponseList(brands);
        return responses;
    }

    public List<Brand> GetBrandsByName(string brandName)
    {
        return _brandRepository.GetBrandsByName(brandName);
    }

    public BrandResponseDto GetById(int id)
    {
        Brand? brand=_brandRepository.GetById(id);
        //toDo: Eğer ilgili brand bulunamazsa exeption Handling mekanizması 
        BrandResponseDto dto = _brandMapper.ConvertToResponse(brand!);
        return dto;
    }

    public void Update(BrandUpdateRequestDto dto)
    {
        Brand brand = _brandMapper.ConvertToEntity(dto);
        _brandRepository.Update(brand);
    }
}
