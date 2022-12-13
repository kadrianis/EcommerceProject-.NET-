using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.Assoc
{
    public class ProductTag
    {
        public string IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        public string IdTag { get; set; }
        [ForeignKey("IdTag")]
        public virtual Tag Tag { get; set; }
    }
}
