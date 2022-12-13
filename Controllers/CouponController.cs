using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _service;

        public CouponController(ICouponService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
