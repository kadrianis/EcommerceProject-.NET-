using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Models.ViewModels;

namespace Projet_2022.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>,IProductService
    {
        public ProductService(AppDbContext context): base(context)
        {

        }


    }
}
