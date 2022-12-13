using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;
using Projet_2022.Models.Assoc;

namespace Projet_2022.Models.Entities
{
    public class OrderItem : IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public string IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order Order { get; set; }


    }
}
