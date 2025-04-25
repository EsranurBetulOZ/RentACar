using Arac_Kiralama.Models;
using Arac_Kiralama.Models.Dtos.Brands;
using Arac_Kiralama.Models.Dtos.Colors;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Arac_Kiralama.Service.Exceptions.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers;
[Authorize(Roles = "Admin")]
public class ColorsController : CustomBaseController
{
    private readonly IColorService _colorService;

    public ColorsController(IColorService colorService)
    {
        _colorService = colorService;
    }

    public async Task<IActionResult> Index()
    {
        var responseDtos = await _colorService.GetAllAsync();
        return View(responseDtos);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(ColorAddRequestDto color)
    {

        try
        {
           await _colorService.AddAsync(color);

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
    [HttpGet]
    public async Task< IActionResult> Update(int id)
    {
        var color =await _colorService.GetByIdAsync(id);
        return View(color);
    }

    [HttpPost]
    public async Task< IActionResult> Update(ColorUpdateRequestDto color)
    {
        await _colorService.UpdateAsync(color);
        return RedirectToAction("Index", "Colors");

    }
    [HttpGet]
    public async Task< IActionResult> Delete(int id)
    {
        try {
			await _colorService.DeleteAsync(id);
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
