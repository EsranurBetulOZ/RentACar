using Arac_Kiralama.Models;
using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Arac_Kiralama.Service.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers;

public class ColorsController : CustomBaseController
{
    private readonly IColorService _colorService;

    public ColorsController(IColorService colorService)
    {
        _colorService = colorService;
    }

    public IActionResult Index()
    {
        var responseDtos = _colorService.GetAll();
        return View(responseDtos);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(ColorAddRequestDto color)
    {

        try
        {
            _colorService.Add(color);

            return RedirectToAction("Index", "Colors");
        }
        catch (BusinessException ex) {
            ExceptionViewModel viewModel = new()
            {
                Exception = ex,
                Controller="Colors",
                Action="Index"
            };

		return BusinessError(viewModel);
        }
     



    }
    public IActionResult Update(int id)
    {
        var color = _colorService.GetById(id);
        return View(color);
    }

    [HttpPost]
    public IActionResult Update(ColorUpdateRequestDto color)
    {
        _colorService.Update(color);
        return RedirectToAction("Index", "Colors");

    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        try {
			_colorService.Delete(id);
			return RedirectToAction("Index", "Colors");
		}
        catch (NotFoundException ex) {
            ExceptionViewModel vm = new()
            {
               Exception=ex,Controller="Colors",Action="Index"
            };
            return NotFoundError(vm);
        }
      
    }

}
