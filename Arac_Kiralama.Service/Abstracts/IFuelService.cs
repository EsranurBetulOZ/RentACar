using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts;

public interface IFuelService
{
    void Add(FuelAddRequestDto fuel);
    void Delete(int id);
    void Update(FuelUpdateRequestDto fuel);
    FuelResponseDto GetById(int id);
    List<FuelResponseDto> GetAll();
}
