
using System.ComponentModel.DataAnnotations;

namespace Projet_2022.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "FullName Required")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Email Required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Confirm Password Required")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Not Matching")]
        public string ConfirmPassword { get; set; }
        [Display(Name ="City")]
        public string City { get; set; }
        [Display(Name ="Zipcode")]
        public string Zipcode { get; set; }
        [Display(Name="Phone")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
