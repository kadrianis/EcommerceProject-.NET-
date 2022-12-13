using Microsoft.AspNetCore.Mvc;
using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;

namespace Projet_2022.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBrandService _brandservice;
        private readonly ICategoryService _categoryservice;
        public CategoryController(IBrandService brandservice, ICategoryService categoryservice)
        {
            _brandservice = brandservice;
            _categoryservice = categoryservice;
        }

        public async Task<IActionResult> Category(string id)
		{
            var brands =await _brandservice.GetAllAsync();
            var category = await _categoryservice.GetByIdAsync(id);
            var categories = await _categoryservice.GetAllAsync();
            var categorycategoriesbrands = new CategoryCategoriesBrandsVM() { Category = category, Brands = brands,Categories=categories };
			return View(categorycategoriesbrands);
		}

        public async Task<IActionResult> Create()
        {
            var response = new CategoryVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM categoryvm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryvm);
            }
            var newcategory = new Category()
            {
                Slug=categoryvm.Slug,

                Description=categoryvm.Description,

                Image=categoryvm.Image,

                AddedAt=DateTime.Now,
                IdParentCategory=categoryvm.IdParentCategory
            };
            await _categoryservice.AddAsync(newcategory);
            return RedirectToAction(nameof(Index));
        }
    }
}
