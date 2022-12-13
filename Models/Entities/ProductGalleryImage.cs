using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class ProductGalleryImage :IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
    }
}
