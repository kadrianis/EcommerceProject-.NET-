using Projet_2022.Data.Repository;
using Projet_2022.Models.Assoc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Entities
{
    public class Product : IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]

        public string Sku { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string PrincipalImage { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public float Ratings { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime AddedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        [Required]
        public int TotalSales { get; set; }
        [Required]
        public int StockStatus { get; set; }

        [Required]
        public string IdBrand { get; set; }
        [ForeignKey("IdBrand")]
        public virtual Brand Brand { get; set; }
        [Required]
        public string IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set;}
        [Required]
        public virtual List<ProductTag> ProductTags { get; set;}
        public virtual List<ProductGalleryImage> ProductGalleryImages { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual List<ProductOption> ProductOptions { get; set; }

    }
}
