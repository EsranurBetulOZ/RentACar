﻿using Arac_Kiralama.Models;
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

    public IActionResult Index(string search)
    {
        var responseDtos = _brandService.GetAll();
        //List<BrandResponseDto> responseDtos = new();
        //foreach (var item in brands)
        //{
        //    BrandResponseDto dto = new(Name: item.Name, ModelYear: item.ModelYear);
        //    responseDtos.Add(dto);
        //}
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
    public IActionResult Add(BrandAddRequestDto brand)
    {

        try
        {
            _brandService.Add(brand);

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

            //return View(brand);
        }
    }
    //public IActionResult BrandNameContains(string brandName)
    //{
    //    List<Brand> filteredBrand = Repository.Brands.FindAll(x=>x.Name.Contains(brandName,StringComparison.CurrentCultureIgnoreCase));
    //    return View(filteredBrand);
    //}
    [HttpGet]
    public IActionResult Update(int id)
    {
        var brand = _brandService.GetById(id);
        return View(brand);
    }

    [HttpPost]
    public IActionResult Update(BrandUpdateRequestDto brand)
    {
        _brandService.Update(brand);
        return RedirectToAction("Index", "Brands");

    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        try
        {
            _brandService.Delete(id);
            return RedirectToAction("Index", "Brands");
        }
        
        catch (NotFoundException ex) {
            ExceptionViewModel vm = new()
            {
                Exception = ex,
                Controller = "Brands",
                Action = "Index"
            };
            return NotFoundError(vm);
        }
    }



}
