using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers
{
    public class TransmissionsController : Controller
    {
        private readonly ITransmissionService _transmissionService;

        public TransmissionsController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        public IActionResult Index()
        {
            var responseDtos = _transmissionService.GetAll();
            return View(responseDtos);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TransmissionAddRequestDto transmission)
        {

            _transmissionService.Add(transmission);

            return RedirectToAction("Index", "Transmissions");
            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var transmission = _transmissionService.GetById(id);
            return View(transmission);
        }

        [HttpPost]
        public IActionResult Update(TransmissionUpdateRequestDto transmission)
        {
            _transmissionService.Update(transmission);
            return RedirectToAction("Index", "Transmissions");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _transmissionService.Delete(id);
            return RedirectToAction("Index", "Transmissions");
        }

    }
}
