using Arac_Kiralama.Models.Dtos.Cars;

namespace Arac_Kiralama.Service.Abstracts;

public interface ICarService
{
    Task<CarResponseDto> GetByIdAsync(Guid id);
    Task<List<CarResponseDto>> GetAllAsync();
    Task AddAsync(CarAddRequestDto carAddRequestDto);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(CarUpdateRequestDto carUpdateRequestDto);

    // Filtreleme ve sayfalama için metot
    Task<(List<CarResponseDto> Cars, int TotalCount)> GetFilteredCarsAsync(
        string transmissionType = null,
        string fuelType = null,
        string color = null,
        string brand = null,
        decimal? minPrice = null,
        decimal? maxPrice = null,
        string sortCriteria = null,
        int page = 1,
        int pageSize = 9);

    // Dropdown listeleri için metotlar
    Task<List<string>> GetAllTransmissionsAsync();
    Task<List<string>> GetAllFuelsAsync();
    Task<List<string>> GetAllColorsAsync();
    Task<List<string>> GetAllBrandsAsync();
}
