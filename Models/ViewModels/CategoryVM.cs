using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.ViewModels
{
    public class CategoryVM
    {
        public string Name;
        public string Slug;
        public string Description;
        public string Image;
        public string IdParentCategory;

    }
}
