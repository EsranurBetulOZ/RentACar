using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Mappers.Colors;

public interface IColorMapper
{
    Color ConvertToEntity(ColorAddRequestDto dto);
    Color ConvertToEntity(ColorUpdateRequestDto dto);
    ColorResponseDto ConvertToResponse(Color color);
    List<ColorResponseDto> ConvertToResponseList(List<Color> colors);

}
