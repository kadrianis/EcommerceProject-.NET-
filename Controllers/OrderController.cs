using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Data.Cart;
using Projet_2022.Data.IServices;
using Projet_2022.Data.Services;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;
using System.Linq;
using System.Security.Claims;

namespace Projet_2022.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly Cart _cart;
        private readonly IOrderService _orderService;
        private readonly IBrandService _brandService;
        public OrderController(IProductService moviesService, Cart cart, IOrderService ordersService,IBrandService brandService)
        {
            _productService = moviesService;
            _cart = cart;
            _orderService = ordersService;
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue("Id");
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public async Task<IActionResult> Cart()
        {
            var items = _cart.GetCartItems();
            _cart.CartItems = items;

            var response = new CartVM()
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal(),
                Brands =  await _brandService.GetAllAsync()
            };


            return View(response);
        }
        public async Task<IActionResult> AddToCart(string id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _cart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(Cart));
        }
        public async Task<IActionResult> RemoveItemFromCart(string id)
        {
            var item = await _productService.GetByIdAsync(id);

            if (item != null)
            {
                _cart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(Cart));
        }
        public async Task<IActionResult> OrderCompleted()
        {
            var items = _cart.GetCartItems();
            string userId = User.FindFirstValue("Id");
            string userEmailAddress = User.FindFirstValue("Email");
            string userZipCode = User.FindFirstValue("ZipCode");
            string userCity = User.FindFirstValue("City");
            string userShippingAdress = User.FindFirstValue("Address");
            string userPhone = User.FindFirstValue("Phonee");
            await _orderService.StoreOrderAsync(items, userId, userEmailAddress, userCity,userZipCode,userShippingAdress,userPhone);
            foreach (var cartitem in items)
            {
                cartitem.Product.TotalSales++;
                cartitem.Product.StockStatus--;
                if (cartitem.Product.StockStatus == 0)
                {
                    _productService.DeleteAsync(cartitem.Product.Id);
                }
            }
            await _cart.ClearCartAsync();

            return View();
        }
    }
}
