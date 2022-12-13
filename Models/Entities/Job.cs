
using Projet_2022.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace Projet_2022.Models.Entities
{
    public class Job : IEntityBase
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public int Salary { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
