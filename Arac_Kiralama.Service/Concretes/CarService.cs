using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Models.Entity;
using Arac_Kiralama.Repository.Repositories.Abstracts;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Exceptions.Types;
using AutoMapper;
using YetenekStore.Service.Helpers.Cloudinary;


namespace Arac_Kiralama.Service.Concretes
{
    public class CarService(IFileService fileService,IMapper mapper, ICarRepository carRepository) : ICarService
    {
       

      

        public async Task AddAsync(CarAddRequestDto carAddRequestDto)
        {
            Car car = mapper.Map<Car>(carAddRequestDto);

            if (carAddRequestDto.File != null)
            {
                string url =await fileService.UploadImageAsync(carAddRequestDto.File, folderName: "cars-image");
                car.ImageUrl = url;
            }

            await carRepository.AddAsync(car);
        }

        public async Task DeleteAsync(Guid id)
        {
            Car? car = await carRepository.GetByIdAsync(id);

            if (car is null)
            {
                throw new NotFoundException("İlgili Araç bulunamadı.");
            }

            await carRepository.DeleteAsync(car);
        }

        public async Task<List<CarResponseDto>> GetAllAsync()
        {
            var cars = await carRepository.GetAllWithIncludesAsync(enableTracking: false);
            List<CarResponseDto> responses = mapper.Map<List<CarResponseDto>>(cars);
            return responses;
        }

        public async Task<CarResponseDto> GetByIdAsync(Guid id)
        {
            var car = await carRepository.GetByIdWithIncludesAsync(id);

            if (car is null)
            {
                throw new NotFoundException("İlgili Araç bulunamadı.");
            }

            var response = mapper.Map<CarResponseDto>(car);
            return response;
        }

        public async Task UpdateAsync(CarUpdateRequestDto carUpdateRequestDto)
        {
            // Önce mevcut aracı getir
            var existingCar = await carRepository.GetByIdAsync(carUpdateRequestDto.Id);

            if (existingCar == null)
            {
                throw new NotFoundException("Güncellenecek araç bulunamadı.");
            }

            // Temel özellikleri güncelle
            existingCar.Name = carUpdateRequestDto.Name;
            existingCar.Kilometer = carUpdateRequestDto.Kilometer;
            existingCar.DailyPrice = carUpdateRequestDto.DailyPrice;
            existingCar.BrandId = carUpdateRequestDto.BrandId;
            existingCar.ColorId = carUpdateRequestDto.ColorId;
            existingCar.TransmissionId = carUpdateRequestDto.TransmissionId;
            existingCar.FuelId = carUpdateRequestDto.FuelId;

            // Eğer yeni bir dosya yüklendiyse, resmi güncelle
            if (carUpdateRequestDto.File != null && carUpdateRequestDto.File.Length > 0)
            {
                string url =await fileService.UploadImageAsync(carUpdateRequestDto.File, folderName: "cars-image");
                existingCar.ImageUrl = url;
            }

            await carRepository.UpdateAsync(existingCar);
        }

        public async Task<(List<CarResponseDto> Cars, int TotalCount)> GetFilteredCarsAsync(
            string transmissionType = null,
            string fuelType = null,
            string color = null,
            string brand = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            string sortCriteria = null,
            int page = 1,
            int pageSize = 9)
        {
            // Tüm araçları getir
            var query = await carRepository.GetAllWithIncludesAsync(enableTracking: false);

            // Filtreleme işlemleri
            var filteredCars = query.AsQueryable();

            if (!string.IsNullOrWhiteSpace(transmissionType))
                filteredCars = filteredCars.Where(c => c.Transmission.Name == transmissionType);

            if (!string.IsNullOrWhiteSpace(fuelType))
                filteredCars = filteredCars.Where(c => c.Fuel.Name == fuelType);

            if (!string.IsNullOrWhiteSpace(color))
                filteredCars = filteredCars.Where(c => c.Color.Name == color);

            if (!string.IsNullOrWhiteSpace(brand))
                filteredCars = filteredCars.Where(c => c.Brand.Name == brand);

            if (minPrice.HasValue)
                filteredCars = filteredCars.Where(c => c.DailyPrice >= minPrice.Value);

            if (maxPrice.HasValue)
                filteredCars = filteredCars.Where(c => c.DailyPrice <= maxPrice.Value);

            // Toplam kayıt sayısı
            int totalCount = filteredCars.Count();

            // Sıralama işlemleri
            filteredCars = sortCriteria switch
            {
                "fiyatArtan" => filteredCars.OrderBy(c => c.DailyPrice),
                "fiyatAzalan" => filteredCars.OrderByDescending(c => c.DailyPrice),
                "kilometreArtan" => filteredCars.OrderBy(c => c.Kilometer),
                "kilometreAzalan" => filteredCars.OrderByDescending(c => c.Kilometer),
                _ => filteredCars.OrderBy(c => c.DailyPrice)
            };

            // Sayfalama işlemi
            var pagedCars = filteredCars
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // DTO'ya dönüştürme
            var carDtos = mapper.Map<List<CarResponseDto>>(pagedCars);

            return (carDtos, totalCount);
        }

        public async Task<List<string>> GetAllTransmissionsAsync()
        {
            var cars = await carRepository.GetAllWithIncludesAsync(enableTracking: false);
            return cars.Select(c => c.Transmission.Name).Distinct().ToList();
        }

        public async Task<List<string>> GetAllFuelsAsync()
        {
            var cars = await carRepository.GetAllWithIncludesAsync(enableTracking: false);
            return cars.Select(c => c.Fuel.Name).Distinct().ToList();
        }

        public async Task<List<string>> GetAllColorsAsync()
        {
            var cars = await carRepository.GetAllWithIncludesAsync(enableTracking: false);
            return cars.Select(c => c.Color.Name).Distinct().ToList();
        }

        public async Task<List<string>> GetAllBrandsAsync()
        {
            var cars = await carRepository.GetAllWithIncludesAsync(enableTracking: false);
            return cars.Select(c => c.Brand.Name).Distinct().ToList();
        }
    }
}