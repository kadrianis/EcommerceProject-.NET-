using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;

namespace Projet_2022.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>,ICategoryService
    {
        public CategoryService(AppDbContext context): base(context)
        {

        }
    }
}
