using Leasing.Interface;
using Leasing.Models.DTO;
using Leasing.Services;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controllers
{
    public class LeasingController : Controller
    {
        private readonly ILeasingCalculator _calc;

        public LeasingController(ILeasingCalculator calc)
        {
            _calc = calc;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LeasingRequestDTO model)
        {
            var result = _calc.HitungLeasing(model);
            ViewBag.Result = result;
            return View(model);
        }
    }
}
