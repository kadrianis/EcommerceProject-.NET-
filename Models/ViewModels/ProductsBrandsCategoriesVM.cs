using Projet_2022.Models.Entities;

namespace Projet_2022.Models.ViewModels
{
    public class ProductsBrandsCategoriesVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
