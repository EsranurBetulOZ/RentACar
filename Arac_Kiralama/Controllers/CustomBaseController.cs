using Arac_Kiralama.Models;
using Arac_Kiralama.Service.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;

namespace Arac_Kiralama.Controllers
{
    public class CustomBaseController : Controller
    {
        public IActionResult BusinessError(
            ExceptionViewModel viewModel)
        {
            return PartialView("Partials/Errors/_BusinessErrorPartial",viewModel);
        }
		public IActionResult NotFoundError(ExceptionViewModel viewModel)
		{
			return PartialView("Partials/Errors/_NotFoundErrorPartial", viewModel);
		}


	}
}
