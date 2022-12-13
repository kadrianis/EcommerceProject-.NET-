using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.ViewModels
{
    public class ProductVM
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string PrincipalImage { get; set; }
        public string Description { get; set; }
        public float Ratings { get; set; }
        public int Price { get; set; }
        public int TotalSales { get; set; }
        public int StockStatus { get; set; }
        public string IdBrand { get; set; }
        public string IdCategory { get; set; }
    }
}
