using Arac_Kiralama.Models.Dtos.Cars;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Arac_Kiralama.Controllers
    {
        public class CarsController : Controller
        {
            private readonly ICarService _carService;
            private readonly IBrandService _brandService;
            private readonly IColorService _colorService;
            private readonly ITransmissionService _transmissionService;
            private readonly IFuelService _fuelService;

            public CarsController(ICarService carService, IBrandService brandService, IColorService colorService, ITransmissionService transmissionService, IFuelService fuelService)
            {
                _carService = carService;
                _brandService = brandService;
                _colorService = colorService;
                _transmissionService = transmissionService;
                _fuelService = fuelService;
            }

        public IActionResult Index(string vitesTipi, string yakitTipi, decimal? minFiyat, decimal? maxFiyat, string renk, string siralamaKriteri = "fiyatArtan")
        {
            // Tüm araçları getir
            var cars = _carService.GetAll();

            // Filtreleme işlemleri
            if (!string.IsNullOrEmpty(vitesTipi))
            {
                cars = cars.Where(c => c.TransmissionName == vitesTipi).ToList();
            }

            if (!string.IsNullOrEmpty(yakitTipi))
            {
                cars = cars.Where(c => c.FuelName == yakitTipi).ToList();
            }

            if (minFiyat.HasValue)
            {
                cars = cars.Where(c => c.DailyPrice >= minFiyat.Value).ToList();
            }

            if (maxFiyat.HasValue)
            {
                cars = cars.Where(c => c.DailyPrice <= maxFiyat.Value).ToList();
            }

            if (!string.IsNullOrEmpty(renk))
            {
                cars = cars.Where(c => c.ColorName == renk).ToList();
            }

            // Sıralama işlemleri
            switch (siralamaKriteri)
            {
                case "fiyatArtan":
                    cars = cars.OrderBy(c => c.DailyPrice).ToList();
                    break;
                case "fiyatAzalan":
                    cars = cars.OrderByDescending(c => c.DailyPrice).ToList();
                    break;
                    // Model yılı için bir alan eklenirse burada sıralama yapılabilir
                    // case "modelYeni":
                    //     cars = cars.OrderByDescending(c => c.ModelYear).ToList();
                    //     break;
                    // case "modelEski":
                    //     cars = cars.OrderBy(c => c.ModelYear).ToList();
                    //     break;
            }

            // Filtreleme için dropdown listelerini hazırla
            ViewBag.Transmissions = _transmissionService.GetAll().Select(t => t.Name).Distinct().ToList();
            ViewBag.Fuels = _fuelService.GetAll().Select(f => f.Name).Distinct().ToList();
            ViewBag.Colors = _colorService.GetAll().Select(c => c.Name).Distinct().ToList();

            // Filtreleme parametrelerini ViewBag'e ekle (form değerlerini korumak için)
            ViewBag.SelectedVitesTipi = vitesTipi;
            ViewBag.SelectedYakitTipi = yakitTipi;
            ViewBag.SelectedMinFiyat = minFiyat;
            ViewBag.SelectedMaxFiyat = maxFiyat;
            ViewBag.SelectedRenk = renk;
            ViewBag.SelectedSiralamaKriteri = siralamaKriteri;

            return View(cars);
        }

        [HttpGet]
            public IActionResult Add()
            {
                // Dropdown listeleri için verileri hazırla
                ViewBag.Brands = new SelectList(_brandService.GetAll(), "Id", "Name");
                ViewBag.Colors = new SelectList(_colorService.GetAll(), "Id", "Name");
                ViewBag.Transmissions = new SelectList(_transmissionService.GetAll(), "Id", "Name");
                ViewBag.Fuels = new SelectList(_fuelService.GetAll(), "Id", "Name");

                return View();
            }

            [HttpPost]
            public IActionResult Add(CarAddRequestDto car)
            {

                    _carService.Add(car);
                    return RedirectToAction("Index", "Cars");
                

                // Hata durumunda dropdown listelerini tekrar doldur
                //ViewBag.Brands = new SelectList(_brandService.GetAll(), "Id", "Name");
                //ViewBag.Colors = new SelectList(_colorService.GetAll(), "Id", "Name");
                //ViewBag.Transmissions = new SelectList(_transmissionService.GetAll(), "Id", "Name");
                //ViewBag.Fuels = new SelectList(_fuelService.GetAll(), "Id", "Name");

            }
        }
    }



