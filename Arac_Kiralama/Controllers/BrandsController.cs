using Arac_Kiralama.Models;
using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Repository.Repositories.Concretes;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Arac_Kiralama.Service.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers;

public class BrandsController : CustomBaseController
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task<IActionResult> Index(string search)
    {
        var responseDtos = await _brandService.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(search))
        {
            responseDtos = responseDtos
                .Where(x => x.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
        }

        return View(responseDtos);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(BrandAddRequestDto brand)
    {
        try
        {
            await _brandService.AddAsync(brand);

            return RedirectToAction("Index", "Brands");
        }
        catch (BusinessException ex)
        {
            ExceptionViewModel viewModel = new()
            {
                Exception = ex,
                Controller = "Brands",
                Action = "Index"
            };

            return BusinessError(viewModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var brand = await _brandService.GetByIdAsync(id);
        return View(brand);
    }

    [HttpPost]
    public async Task<IActionResult> Update(BrandUpdateRequestDto brand)
    {
        await _brandService.UpdateAsync(brand);
        return RedirectToAction("Index", "Brands");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _brandService.DeleteAsync(id);
            return RedirectToAction("Index", "Brands");
        }
        catch (NotFoundException ex)
        {
            ExceptionViewModel vm = new()
            {
                Exception = ex,
                Controller = "Brands",
                Action = "Index"
            };
            return NotFoundError(vm);
        }
    }

    
    /*
    public async Task<IActionResult> BrandNameContains(string brandName)
    {
        List<Brand> filteredBrand = await _brandService.GetBrandsByNameAsync(brandName);
        return View(filteredBrand);
    }
    */
}