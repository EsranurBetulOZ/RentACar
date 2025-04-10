using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Fuels;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers;

public class FuelsController : Controller
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
    public IActionResult Add(FuelAddRequestDto fuel)
    {
        _fuelService.Add(fuel);
        return RedirectToAction("Index", "Fuels");

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
        _fuelService.Delete(id);
        return RedirectToAction("Index", "Fuels");
    }
}
