using AutoFac.Mediatr.Core;
using AutoFac.Mediatr.Core.Query;
using AutoFac.Mediatr.Core.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoFac.Mediatr.Lab.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;

        public HomeController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(TenantViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return Content("Succeeded");
        }

        public async Task<IActionResult> Index()
        {
            var msg = new GenericQuery<Tenant>();
            var result = await _mediator.Send(msg);
            return View();
        }
    }
}