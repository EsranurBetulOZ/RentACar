using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Brands;

public interface IBrandMapper
{
    Brand ConvertToEntity(BrandAddRequestDto dto);
    Brand ConvertToEntity(BrandUpdateRequestDto dto);
    BrandResponseDto ConvertToResponse(Brand brand);
    List<BrandResponseDto> ConvertToResponseList(List<Brand> brands);
}
