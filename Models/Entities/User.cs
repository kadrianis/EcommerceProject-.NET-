using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Projet_2022.Data.Repository;

namespace Projet_2022.Models.Entities
{
    public class User : IdentityUser, IEntityBase
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public bool EmailVerification { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public virtual List<Order> Orders { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public string IdJob { get; set; }
        [ForeignKey("IdJob")]
        public virtual Job Job {get;set;}
        public string IdManager { get; set; }
        [ForeignKey("IdManager")]
        public virtual User Manager { get; set; }

        public string IdCountry { get; set; }
        [ForeignKey("IdCountry")]
        public virtual Country Country { get; set; }
        public virtual List<User> Employees { get; set; }
        public bool conge { get; set; }
        public bool Employee { get; set; }
        
    }
}
