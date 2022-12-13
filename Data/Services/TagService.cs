using Projet_2022.Data.IServices;
using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;

namespace Projet_2022.Data.Services
{
    public class TagService : EntityBaseRepository<Tag>,ITagService
    {
        public TagService(AppDbContext context): base(context)
        {

        }
    }
}
