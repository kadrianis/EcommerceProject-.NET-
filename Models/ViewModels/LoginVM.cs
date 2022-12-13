using Projet_2022.Data.enums;
using System.ComponentModel.DataAnnotations;

namespace Projet_2022.Views.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage ="Email Required")]
        [Display(Name ="Email ")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password Required")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
