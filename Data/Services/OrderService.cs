using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Projet_2022.Data.Services
{
    public class OrderService : EntityBaseRepository<Order>,IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Product).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.IdUser == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<CartItem> items, string userId, string userEmailAddress,string userCity, string userZipCode,string userAddress, string userPhone)
        {
            var order = new Order()
            {
                IdUser = userId,
                Email = userEmailAddress,
                City= userCity,
                ZipCode=userZipCode,
                Shipped=0,
                DateOfOrder=DateTime.Now,
                Tax=18/100,
                ShipAddress=userAddress,
                Phone=userPhone
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    IdProduct = item.Product.Id,
                    IdOrder = order.Id,
                    Price = item.Product.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
