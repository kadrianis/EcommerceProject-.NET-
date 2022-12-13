using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class Coupon :IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public float Value { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
