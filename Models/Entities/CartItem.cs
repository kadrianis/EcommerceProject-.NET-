using Projet_2022.Data.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Projet_2022.Models.Entities
{
    public class CartItem:IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        public virtual Product Product { get; set; }
        public int Amount { get; set; }
        [Required]
        public string IdCart { get; set; }
    }
}
