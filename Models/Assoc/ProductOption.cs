using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Assoc
{
    public class ProductOption
    {
        [Required]
        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }

        [Required]
        public string IdOption { get; set; }
        [ForeignKey("IdOption")]
        public virtual Option Option { get; set; }
    }
}
