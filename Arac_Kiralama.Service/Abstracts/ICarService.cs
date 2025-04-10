using Arac_Kiralama.Models.Dtos.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Abstracts
{
    public interface ICarService
    {

        void Add(CarAddRequestDto car);
        void Delete(Guid id);
        void Update(CarUpdateRequestDto car);
        CarResponseDto GetById(Guid id);
        List<CarResponseDto> GetAll();
    }
}
