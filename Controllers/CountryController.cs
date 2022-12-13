using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
