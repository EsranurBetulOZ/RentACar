using Arac_Kiralama.Models;
using Arac_Kiralama.Models.Dtos.Transmissions;
using Arac_Kiralama.Service.Abstracts;
using Arac_Kiralama.Service.Concretes;
using Arac_Kiralama.Service.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers
{
    public class TransmissionsController : CustomBaseController
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
            try
            {
                _transmissionService.Add(transmission);

                return RedirectToAction("Index", "Transmissions");
            }

            catch (BusinessException ex)
            {
                ExceptionViewModel viewModel = new()
                {
                    Exception = ex,
                    Controller = "Transmissions",
                    Action = "Index"
                };
                return BusinessError(viewModel);
            }
            
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
            try
            {
                _transmissionService.Delete(id);
                return RedirectToAction("Index", "Transmissions");
            }
           

              catch (NotFoundException ex)
        {
                ExceptionViewModel vm = new()
                {
                    Exception = ex,
                    Controller = "Transmissions",
                    Action = "Index"
                };
                return NotFoundError(vm);
            }
        }

    }
}
