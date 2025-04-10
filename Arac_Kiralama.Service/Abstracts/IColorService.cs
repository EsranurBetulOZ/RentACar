using Arac_Kiralama.Models.Dtos.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts
{
    public interface IColorService
    {
        void Add(ColorAddRequestDto color);
        void Delete(int id);
        void Update(ColorUpdateRequestDto color);
        ColorResponseDto GetById(int id);
        List<ColorResponseDto> GetAll();
    }
}
