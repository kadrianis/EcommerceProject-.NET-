using Projet_2022.Data.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Entities
{
    public class Order:IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }

        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public float Tax { get; set; }
        [Required]
        public int Shipped { get; set; }
        [Required]
        public int TrackingNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [Required]
        public DateTime DateOfOrder { get; set; }
        public string IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
        public string IdCoupon { get; set; }
        [ForeignKey("IdCoupon")]
        public virtual Coupon Coupon { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }


    }
}
