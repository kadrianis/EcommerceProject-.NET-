using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Projet_2022.Models.Entities;

namespace Projet_2022.Data.Cart
{
    public class Cart
    {
        public string IdCart { get; set; }
        public AppDbContext _context { get; set; }
        public List<CartItem> CartItems { get; set; }
        public Cart(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddItemToCart(Product Product)
        {
            var cartitem = _context.CartItems.FirstOrDefault(n => n.Product.Id == Product.Id && n.IdCart == IdCart);
            if (cartitem==null)
            {
                cartitem = new CartItem()
                {
                    IdCart = IdCart,
                    Product = Product,
                    Amount = 1
                };
                _context.CartItems.Add(cartitem);
                _context.SaveChanges();
            }
            else
            {
                cartitem.Amount ++;
            }
        }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string CartId=session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", CartId);
            return new Cart(context) {IdCart=CartId};
        }
        public void RemoveItemFromCart(Product Product)
        {
            var cartitem = _context.CartItems.FirstOrDefault(n => n.Product.Id == Product.Id && n.IdCart == IdCart);
            if (cartitem != null)
            {
                if (cartitem.Amount > 1)
                {
                    cartitem.Amount--;
                }
                else
                {
                    _context.CartItems.Remove(cartitem);
                }
            }
            else
            {
                cartitem.Amount++;
            }
        }
        public List<CartItem> GetCartItems()
        {
            return CartItems ?? (CartItems = _context.CartItems.Where(n => n.IdCart == IdCart).Include(n => n.Product).ToList());
        }
        public float GetCartTotal()
        {
            var total = _context.CartItems.Where(n => n.IdCart == IdCart).Select(n => n.Product.Price * n.Amount).Sum();
            return total;
        }
        public async Task ClearCartAsync()
        {
            var items = await _context.CartItems.Where(n => n.IdCart == IdCart).ToListAsync();
            _context.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
        public float GetCartTax()
        {
            var total = GetCartTotal();
            return total * 0.18f;
        }
        public float GetCartAfterTax()
        {
            var total = GetCartTotal();
            return total * 0.82f;
        }
    }
}
