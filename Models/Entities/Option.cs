
using Projet_2022.Data.Repository;
using Projet_2022.Models.Assoc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Projet_2022.Models.Entities
{
    public class Option:IEntityBase
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IdOptionGroup { get; set; }
        [ForeignKey("IdOptionGroup")]
        public virtual OptionGroup OptionGroup { get; set; }
        public virtual List<ProductOption> ProductsOption { get; set; }
    }
}
