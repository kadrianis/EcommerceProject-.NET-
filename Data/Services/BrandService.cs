using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;

namespace Projet_2022.Data.Services
{
    public class BrandService : EntityBaseRepository<Brand>,IBrandService
    {
        public BrandService(AppDbContext context): base(context)
        {

        }
    }
}
