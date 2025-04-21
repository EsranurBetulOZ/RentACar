using Arac_Kiralama.Models;
using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Arac_Kiralama.Service.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers;

public class FuelsController : CustomBaseController
{
    private readonly IFuelService _fuelService;

    public FuelsController(IFuelService fuelService)
    {
        _fuelService = fuelService;
    }

    public async Task<IActionResult> Index()
    {
        var responseDtos =await _fuelService.GetAllAsync();
        return View(responseDtos);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(FuelAddRequestDto fuel)
    {
        try
        {
            await _fuelService.AddAsync(fuel);
            return RedirectToAction("Index", "Fuels");
        }
        catch (BusinessException ex)
        {
            ExceptionViewModel viewModel = new()
            {
                Exception = ex,
                Controller = "Fuels",
                Action = "Index"
            };

            return BusinessError(viewModel);
        }
    }
        [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var fuel =await _fuelService.GetByIdAsync(id);
        return View(fuel);
    }
    [HttpPost]
    public async Task<IActionResult> Update(FuelUpdateRequestDto fuel)
    {
       await _fuelService.UpdateAsync(fuel);
        return RedirectToAction("Index", "Fuels");

    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _fuelService.DeleteAsync(id);
            return RedirectToAction("Index", "Fuels");
        }
        catch (NotFoundException ex)
        {
            ExceptionViewModel vm = new()
            {
                Exception = ex,
                Controller = "Fuels",
                Action = "Index"
            };
            return NotFoundError(vm);
        }
       
    }
}
