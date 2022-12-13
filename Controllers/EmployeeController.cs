using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IProductService _service;

        public EmployeeController(IProductService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
