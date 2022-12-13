using Projet_2022.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_2022.Models.ViewModels
{
    public class CreateEmployeeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public string IdJob { get; set; }
        public string IdManager { get; set; }
        public bool conge { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
