using Arac_Kiralama.Models;
using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Service.Abstracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Arac_Kiralama.Controllers;

public class CarsController : Controller
{
    private readonly ICarService _carService;
    private readonly IBrandService _brandService;
    private readonly IColorService _colorService;
    private readonly ITransmissionService _transmissionService;
    private readonly IFuelService _fuelService;
    private readonly IMapper _mapper; // IMapper ekleyin

    public CarsController(
        ICarService carService,
        IBrandService brandService,
        IColorService colorService,
        ITransmissionService transmissionService,
        IFuelService fuelService,
        IMapper mapper) // Constructor'a ekleyin
    {
        _carService = carService;
        _brandService = brandService;
        _colorService = colorService;
        _transmissionService = transmissionService;
        _fuelService = fuelService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(
        string vitesTipi = null,
        string yakitTipi = null,
        string renk = null,
        string marka = null,
        decimal? minFiyat = null,
        decimal? maxFiyat = null,
        string siralamaKriteri = "fiyatArtan",
        int sayfa = 1)
    {
        // Filtreleme ve sayfalama ile araçları getir
        var (cars, totalCount) = await _carService.GetFilteredCarsAsync(
            vitesTipi, yakitTipi, renk, marka, minFiyat, maxFiyat, siralamaKriteri, sayfa, 9);

        // Dropdown listeleri için verileri getir
        var transmissions = await _carService.GetAllTransmissionsAsync();
        var fuels = await _carService.GetAllFuelsAsync();
        var colors = await _carService.GetAllColorsAsync();
        var brands = await _carService.GetAllBrandsAsync();

        // ViewModel oluştur
        var model = new CarFilterViewModel
        {
            Cars = cars,
            TransmissionSelectList = new SelectList(transmissions),
            FuelSelectList = new SelectList(fuels),
            ColorSelectList = new SelectList(colors),
            BrandSelectList = new SelectList(brands),

            SelectedTransmission = vitesTipi,
            SelectedFuel = yakitTipi,
            SelectedColor = renk,
            SelectedBrand = marka,
            SelectedMinPrice = minFiyat,
            SelectedMaxPrice = maxFiyat,
            SelectedSortCriteria = siralamaKriteri,

            CurrentPage = sayfa,
            TotalItems = totalCount
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        try
        {
            var car = await _carService.GetByIdAsync(id);
            return View(car);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        await LoadDropdowns();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(CarAddRequestDto car)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns();
            return View(car);
        }

        try
        {
            await _carService.AddAsync(car);
            TempData["SuccessMessage"] = "Araç başarıyla eklendi.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            await LoadDropdowns();
            return View(car);
        }
    }

    [HttpGet]
  
    public async Task<IActionResult> Update(Guid id)
    {
        try
        {
            var car = await _carService.GetByIdAsync(id);

            CarUpdateRequestDto updateDto = new CarUpdateRequestDto
            {
                Id = car.Id,
                Name = car.Name,
                BrandId = car.BrandId,
                ColorId = car.ColorId,
                TransmissionId = car.TransmissionId,
                FuelId = car.FuelId,
                DailyPrice = car.DailyPrice,
                Kilometer = car.Kilometer
            };

            await LoadDropdowns();
            return View(updateDto);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }


    [HttpPost]
    public async Task<IActionResult> Update(CarUpdateRequestDto car)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns();
            return View(car);
        }

        try
        {
            // Eğer dosya yüklendiyse, form verilerini doğru şekilde işle
            if (Request.Form.Files.Count > 0)
            {
                car.File = Request.Form.Files[0];
            }

            await _carService.UpdateAsync(car);
            TempData["SuccessMessage"] = "Araç başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            await LoadDropdowns();
            return View(car);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _carService.DeleteAsync(id);
            TempData["SuccessMessage"] = "Araç başarıyla silindi.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult GetBrandsByName(string brandName)
    {
        if (string.IsNullOrEmpty(brandName))
        {
            return Json(new List<object>());
        }

        // Mevcut senkron metodu kullanın
        var brands = _brandService.GetBrandsByName(brandName);
        return Json(brands.Select(b => new { id = b.Id, modelYear = b.ModelYear }));
    }

    private async Task LoadDropdowns()
    {
        ViewBag.Brands = new SelectList(await _brandService.GetAllAsync(), "Id", "Name");
        ViewBag.Colors = new SelectList(await _colorService.GetAllAsync(), "Id", "Name");
        ViewBag.Transmissions = new SelectList(await _transmissionService.GetAllAsync(), "Id", "Name");
        ViewBag.Fuels = new SelectList(await _fuelService.GetAllAsync(), "Id", "Name");
    }
}