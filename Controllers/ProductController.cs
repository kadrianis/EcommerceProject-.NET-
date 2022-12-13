using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Data.IServices;
using Projet_2022.Data.Static;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;
using System.Xml.Linq;

namespace Projet_2022.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, IBrandService brandService, ICategoryService categoryService)
        {
            _service = service;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> ProductDetail(string id)
        {
            var product=await _service.GetByIdAsync(id);
            var categories = await _categoryService.GetAllAsync();
            var brands= await _brandService.GetAllAsync();
            var productcategoriesbrands = new ProductCategoriesBrands()
            {
                Product = product,
                Brands = brands,
                Categories = categories
            };
            return View(productcategoriesbrands);
        }
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            var categories =await _categoryService.GetAllAsync();
            var brands = await _brandService.GetAllAsync();
            var productscategoriesbrands = new ProductsBrandsCategoriesVM() { Brands = brands, Products = products, Categories = categories };
            return View(productscategoriesbrands);
        }
        [Authorize(UserRoles.Admin)]
        public async Task<IActionResult> Stock()
        {
            var products = await _service.GetAllAsync();
            return View(products);  
        }
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Employee")]

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productvm)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ziwziw");
                return View(productvm);
            }
            var newproduct = new Product()
            {
                Sku = productvm.Sku,
                Name = productvm.Name,
                Slug = productvm.Slug,
                PrincipalImage = productvm.PrincipalImage,
                Description = productvm.Description,
                Ratings = productvm.Ratings,
                Price = productvm.Price,
                AddedAt = DateTime.Now,
                TotalSales = productvm.TotalSales,
                StockStatus = productvm.StockStatus,
                IdBrand = productvm.IdBrand,
                IdCategory = productvm.IdCategory
            };
            await _service.AddAsync(newproduct);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string id)
        {
            var productDetails = await _service.GetByIdAsync(id);

            var response = new ProductVM()
            {
                 Sku = productDetails.Sku,
                 Name = productDetails.Name,
                 Slug = productDetails.Slug,
                 PrincipalImage = productDetails.PrincipalImage,
                 Description = productDetails.Description,
                 Ratings = productDetails.Ratings,
                 Price = productDetails.Price,
                 TotalSales = productDetails.TotalSales,
                 StockStatus = productDetails.StockStatus,
            };
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,ProductVM productDetails)
        {
            var dbproduct = await _service.GetByIdAsync(id);

            if (dbproduct != null)
            {
                dbproduct.Sku = productDetails.Sku;
                dbproduct.Name = productDetails.Name;
                dbproduct.Slug = productDetails.Slug;
                dbproduct.PrincipalImage = productDetails.PrincipalImage;
                dbproduct.Description = productDetails.Description;
                dbproduct.Ratings = productDetails.Ratings;
                dbproduct.Price = productDetails.Price;
                dbproduct.TotalSales = productDetails.TotalSales;
                dbproduct.StockStatus = productDetails.StockStatus;
                await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var dbproduct = await _service.GetByIdAsync(id);

            if (dbproduct != null)
            {

                dbproduct.StockStatus = 0;
                dbproduct.DeletedAt = DateTime.Now;
                await _service.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
