using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;

namespace Projet_2022.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _service;

        public TagController(ITagService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
