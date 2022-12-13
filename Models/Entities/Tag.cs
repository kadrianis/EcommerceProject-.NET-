using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Models.Assoc;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Tag : IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<ProductTag> TagProducts { get; set; }
    }
}
