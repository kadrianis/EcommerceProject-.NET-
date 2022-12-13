using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;

namespace Projet_2022.Data.Services
{
    public class OptionService : EntityBaseRepository<Option>,IOptionService
    {
        public OptionService(AppDbContext context): base(context)
        {

        }
    }
}
