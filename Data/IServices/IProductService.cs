using Projet_2022.Models.Entities;
using Projet_2022.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Models.ViewModels;

namespace Projet_2022.Data.IServices
{
    public interface IProductService:IEntityBaseRepository<Product>
    {

    }
}
