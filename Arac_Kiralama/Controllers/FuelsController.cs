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

    public IActionResult Index()
    {
        var responseDtos = _fuelService.GetAll();
        return View(responseDtos);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(FuelAddRequestDto fuel)
    {
        try
        {
            _fuelService.Add(fuel);
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
    public IActionResult Update(int id)
    {
        var fuel = _fuelService.GetById(id);
        return View(fuel);
    }
    [HttpPost]
    public IActionResult Update(FuelUpdateRequestDto fuel)
    {
        _fuelService.Update(fuel);
        return RedirectToAction("Index", "Fuels");

    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        try
        {
            _fuelService.Delete(id);
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
