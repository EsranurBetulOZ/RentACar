using Arac_Kiralama.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Arac_Kiralama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Role role = new Role()
            //{
            //    Name="Admin"
            //};
            //Role role1 = new()
            //{
            //    Name="User"
            //};
            //bool sonuc = role == role1;
            //ViewBag.esitMi = sonuc;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
