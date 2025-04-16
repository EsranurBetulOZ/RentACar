using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Exceptions.Types;
using Arac_Kiralama.Service.Mappers.Fuels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Concretes
{
    public class FuelService : IFuelService
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IFuelMapper _fuelMapper;

        public FuelService(IFuelRepository fuelRepository, IFuelMapper fuelMapper)
        {
            _fuelRepository = fuelRepository;
            _fuelMapper = fuelMapper;
        }

        public void Add(FuelAddRequestDto dto)
        {
            bool isPresent = _fuelRepository.ExistByFuelName(dto.Name);
            if (isPresent)
            {
                throw new BusinessException("Yakıt türü daha önce eklendi");
            }
            Fuel fuel = _fuelMapper.ConvertToEntity(dto);
            _fuelRepository.Add(fuel);
        }

        public void Delete(int id)
        {
            Fuel? fuel = _fuelRepository.GetById(id);
            if (fuel is null)
            {
                throw new NotFoundException("İlgili yakıt bulunamadı.");
            }
             
            _fuelRepository.Delete(fuel!);
        }

        public List<FuelResponseDto> GetAll()
        {
            List<Fuel> fuels = _fuelRepository.GetAll();
            List<FuelResponseDto> responses = _fuelMapper.ConvertToResponseList(fuels);
            return responses;
        }

        public FuelResponseDto GetById(int id)
        {
            Fuel? fuel = _fuelRepository.GetById(id);
            //toDo: Eğer ilgili fuel bulunamazsa exeption Handling mekanizması 
            FuelResponseDto dto = _fuelMapper.ConvertToResponse(fuel!);
            return dto;
        }

        public void Update(FuelUpdateRequestDto dto)
        {
            Fuel fuel = _fuelMapper.ConvertToEntity(dto);
            _fuelRepository.Update(fuel);
        }
    }
}
