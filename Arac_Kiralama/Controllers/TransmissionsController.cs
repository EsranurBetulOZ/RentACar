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

        public async Task<IActionResult> Index()
        {
            var responseDtos = await _transmissionService.GetAllAsync();
            return View(responseDtos);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TransmissionAddRequestDto transmission)
        {
            try
            {
                await _transmissionService.AddAsync(transmission);

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
        public async Task<IActionResult> Update(int id)
        {
            var transmission =await _transmissionService.GetByIdAsync(id);
            return View(transmission);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TransmissionUpdateRequestDto transmission)
        {
            await _transmissionService.UpdateAsync(transmission);
            return RedirectToAction("Index", "Transmissions");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await _transmissionService.DeleteAsync(id);
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
