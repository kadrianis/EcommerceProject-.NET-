using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;
using System.Runtime.InteropServices;

namespace Projet_2022.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandservice;
        private readonly ICategoryService _categoryservice;

        public BrandController(IBrandService brandservice,ICategoryService categoryservice)
        {
            _brandservice = brandservice;
            _categoryservice = categoryservice;
        }
        public async Task<IActionResult> Index()
        {
            var brands = await _brandservice.GetAllAsync();
            var categories = await _categoryservice.GetAllAsync();
            var brandscategories = new BrandsCategoriesVM() { Brands=brands,Categories=categories};
            return View(brandscategories);
        }
        public async Task<IActionResult> Brand(string id)
        {
            var brand = await _brandservice.GetByIdAsync(id);
            var categories = await _categoryservice.GetAllAsync();
            var brands = await _brandservice.GetAllAsync();
            var brandcategories = new BrandBrandsCategoriesVM() { Brand = brand, Categories = categories, Brands=brands };
            
            return View(brandcategories);
        }
        public async Task<IActionResult> Create()
        {
            var response = new BrandVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandVM brandvm)
        {
            if (!ModelState.IsValid)
            {
                return View(brandvm);
            }
            var newbrand = new Brand()
            {
                Name=brandvm.Name,
                Description=brandvm.Description,
                Logo=brandvm.Logo
            };
            await _brandservice.AddAsync(newbrand);
            return RedirectToAction(nameof(Index));
        }
    }
}
