using Projet_2022.Data.Cart;
using Projet_2022.Models.Entities;

namespace Projet_2022.Models.ViewModels
{
    public class CartVM
    {
        public Cart Cart { get; set; }
        public float CartTotal { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public string NameCoupon { get; set; }

    }
}
