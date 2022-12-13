using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;

namespace Projet_2022.Data.Services
{
    public class CartItemService : EntityBaseRepository<CartItem>,ICartItemService
    {
        public CartItemService(AppDbContext context): base(context)
        {

        }
    }
}
