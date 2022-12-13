using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Category : IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public DateTime AddedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        [Required]
        public DateTime DeletedAt { get; set; }
        public string IdParentCategory { get; set; }
        [ForeignKey("IdParentCategory")]
        public virtual Category ParentCategory { get; set; }
        public virtual List<Product> Products { get; set; } 
        public virtual List<Category> Categories { get; set; }

    }
}
