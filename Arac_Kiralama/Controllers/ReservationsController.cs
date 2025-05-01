using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
