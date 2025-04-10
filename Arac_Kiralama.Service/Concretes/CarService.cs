using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Mappers.Brands;
using Arac_Kiralama.Service.Mappers.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kiralama.Service.Concretes
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarMapper _carMapper;

        public CarService(ICarRepository carRepository, ICarMapper carMapper)
        {
            _carRepository = carRepository;
            _carMapper = carMapper;
        }

        public void Add(CarAddRequestDto dto)
        {
            Car car = _carMapper.ConvertToEntity(dto);
            _carRepository.Add(car);
        }

        public void Delete(Guid id)
        {
            Car? car = _carRepository.GetById(id);
            //toDo: Eğer ilgili car bulunamazsa exeption Handling mekanizması 
            _carRepository.Delete(car!);
        }

        public List<CarResponseDto> GetAll()
        {
            List<Car> cars = _carRepository.GetAll();
            List<CarResponseDto> responses = _carMapper.ConvertToResponseList(cars);
            return responses;
        }

        public CarResponseDto GetById(Guid id)
        {
            Car? car = _carRepository.GetById(id);
            //toDo: Eğer ilgili brand bulunamazsa exeption Handling mekanizması 
            CarResponseDto dto = _carMapper.ConvertToResponse(car!);
            return dto;
        }

        public void Update(CarUpdateRequestDto dto)
        {
            Car car = _carMapper.ConvertToEntity(dto);
            _carRepository.Update(car);
        }
    }
}
